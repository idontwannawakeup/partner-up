from torch_geometric.data import Data
from sklearn.preprocessing import LabelEncoder
import pandas as pd
import torch
import warnings
warnings.filterwarnings('ignore')


def predict_for_new_job_v1(new_job_desc, model, data, le_job_title, le_skills, le_category, resumes, job_descriptions, skill_weight=0.25, title_weight=0.85, k=5):
    """
    Predict top candidates for a new job description using normalized similarity scores.

    Args:
        new_job_desc (dict): New job description with 'job_title' and 'skills'.
        model (GAE): Trained GAE model.
        data (Data): PyTorch Geometric Data object.
        le_job_title (LabelEncoder): Encoder for job titles.
        le_skills (dict): Encoder for skills.
        le_category (LabelEncoder): Encoder for categories.
        resumes (DataFrame): Candidate data.
        job_descriptions (DataFrame): Job data.
        skill_weight (float): Weight for normalized skill overlap.
        title_weight (float): Weight for title match.
        k (int): Number of top candidates to return.

    Returns:
        DataFrame: Top-k candidates with match details.
    """
    # Encode job title and skills
    try:
        job_title = le_job_title.transform([new_job_desc['job_title']])[0]
    except ValueError:
        job_title = le_job_title.transform(['unknown'])[0]

    skills_vector = [0] * len(le_skills)
    for skill in new_job_desc['skills']:
        if skill in le_skills:
            skills_vector[le_skills[skill]] = 1

    new_job_features = torch.tensor([job_title] + skills_vector, dtype=torch.float).unsqueeze(0)

    # Project or truncate the new job features to match data.x dimensions
    if new_job_features.size(1) > data.x.size(1):  # Truncate if too large
        new_job_features_projected = new_job_features[:, :data.x.size(1)]
    else:  # Pad if too small
        padding = torch.zeros((1, data.x.size(1) - new_job_features.size(1)))
        new_job_features_projected = torch.cat([new_job_features, padding], dim=1)

    new_job_features_projected = new_job_features_projected.to(data.x.device)

    # Append the new node to the feature matrix
    updated_x = torch.cat([data.x, new_job_features_projected], dim=0)

    # Encode the entire graph, including the new job node
    new_node_index = data.x.size(0)
    model.eval()
    with torch.no_grad():
        z = model.encode(updated_x, data.val_pos_edge_index, data.val_pos_edge_weight)
        new_job_embedding = z[new_node_index].unsqueeze(0)
        candidate_embeddings = z[len(data.x) - len(resumes):]

    # Compute similarity scores
    raw_scores = torch.matmul(new_job_embedding, candidate_embeddings.T).cpu().numpy().flatten()

    # Adjust and normalize scores
    predictions = []
    for idx, candidate in resumes.iterrows():
        candidate_id = candidate['candidate_id']
        candidate_job_title = candidate['job_title']
        candidate_skills = candidate['skills']
        candidate_recommendation_id = candidate['recommendation_id']

        # Skill overlap normalization
        job_skills = set(new_job_desc['skills'])
        mutual_skills = job_skills.intersection(candidate_skills)
        normalized_skill_score = len(mutual_skills) / max(len(job_skills), len(candidate_skills))

        # Title similarity
        title_score = 1 if job_title == candidate_job_title else 0

        # Final score calculation
        final_score = raw_scores[idx] * ((normalized_skill_score * skill_weight) + (title_score * title_weight))

        predictions.append({
            "Job ID": "New Job",
            "Job Title": le_job_title.inverse_transform([job_title])[0],
            "Candidate ID": candidate_id,
            "Candidate Recommendation ID": candidate_recommendation_id,
            "Candidate Job Title": le_job_title.inverse_transform([candidate_job_title])[0],
            # "Match Percentage": final_score * 100,  # Convert to percentage
            "OG Score": raw_scores[idx],
            "Match Score": final_score,
            "Mutual Skills": mutual_skills,
            "Job Skills": list(job_skills),
            "Candidate Skills": candidate_skills
        })

    # Convert to DataFrame and sort
    predictions_df = pd.DataFrame(predictions)
    return predictions_df.sort_values(by="Match Score", ascending=False).head(k)
