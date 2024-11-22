from components.gae import GAE
from sklearn.preprocessing import LabelEncoder
from ast import literal_eval
import pandas as pd
import numpy as np
import os
import torch
import pickle
import warnings

warnings.filterwarnings('ignore')


def load_model():
    # Define the folder for loading the model
    model_folder = "gae-model-v1"

    # Load the GAE model
    model_path = os.path.join(model_folder, "model.pth")
    encoders_path = os.path.join(model_folder, "encoders_metadata.pkl")
    data_path = os.path.join(model_folder, "graph_data.pkl")

    # Load encoders and metadata
    with open(encoders_path, "rb") as f:
        encoders_metadata = pickle.load(f)
        le_job_title = encoders_metadata["le_job_title"]
        le_skills = encoders_metadata["le_skills"]
        le_category = encoders_metadata["le_category"]
        num_node_features = encoders_metadata["num_node_features"]

    print("Encoders and metadata loaded successfully.")

    # Load the graph data object
    with open(data_path, "rb") as f:
        loaded_data = pickle.load(f)
    print("Graph data loaded successfully.")

    # Initialize and load the GAE model
    loaded_model = GAE(num_node_features, 16)  # Ensure architecture matches
    loaded_model.load_state_dict(torch.load(model_path))
    loaded_model.eval()
    print("Model loaded successfully.")

    return loaded_model, loaded_data, le_job_title, le_skills, le_category, num_node_features


def load_data():
    random_seed = 62
    np.random.seed(random_seed)

    job_descriptions = pd.read_csv('./data/processed/job_descriptions_processed-v5.csv')
    resumes = pd.read_csv('./data/processed/general-resume-dataset-processed-v6.csv', converters={'skills': literal_eval})

    job_descriptions = job_descriptions.sample(frac=1, random_state=random_seed).head(20000)

    job_descriptions['skills'] = job_descriptions['skills'].apply(literal_eval)

    job_descriptions['job_title'].fillna('unknown', inplace=True)
    resumes['job_title'].fillna('unknown', inplace=True)
    resumes['category'].fillna('unknown', inplace=True)

    job_descriptions['job_id'] = range(1, len(job_descriptions) + 1)
    resumes['candidate_id'] = range(1, len(resumes) + 1)

    all_titles = job_descriptions['job_title'].tolist() + resumes['job_title'].tolist()
    all_titles.append('unknown')
    all_categories = resumes['category'].tolist()
    all_categories.append('unknown')

    le_job_title = LabelEncoder()
    le_category = LabelEncoder()
    le_job_title.fit(all_titles)
    le_category.fit(all_categories)

    job_descriptions['job_title'] = le_job_title.transform(job_descriptions['job_title'])
    resumes['job_title'] = le_job_title.transform(resumes['job_title'])
    resumes['category'] = le_category.transform(resumes['category'])

    all_skills = set(skill for skills in job_descriptions['skills'].tolist() + resumes['skills'].tolist() for skill in skills)
    le_skills = {skill: i for i, skill in enumerate(all_skills)}

    nodes = []
    edges = []
    node_features = []

    jobs_from_edges = []
    candidates_from_edges = []
    jobs_and_candidates_from_edges = []

    skill_weight_multiplier = 125
    title_weight = 200

    for i, row in job_descriptions.iterrows():
        nodes.append(row['job_id'])
        skills_vector = [0] * len(le_skills)
        if row['skills']:
            for skill in row['skills']:
                skills_vector[le_skills[skill]] = 1
        node_features.append([row['job_title']] + skills_vector)

    for i, row in resumes.iterrows():
        nodes.append(row['candidate_id'] + len(job_descriptions))
        skills_vector = [0] * len(le_skills)
        if row['skills']:
            for skill in row['skills']:
                skills_vector[le_skills[skill]] = 1
        node_features.append([row['job_title']] + skills_vector)

    job_descriptions['skills'] = job_descriptions['skills'].apply(set)
    resumes['skills'] = resumes['skills'].apply(set)
    return job_descriptions, resumes
