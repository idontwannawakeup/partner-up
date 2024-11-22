from fastapi import FastAPI
from fastapi.middleware.cors import CORSMiddleware
from pydantic import BaseModel, Field
import ssl

from components.load import load_model, load_data
from components.recommendations import predict_for_new_job_v1


class JobDescription(BaseModel):
    profession: str = Field(alias="profession")
    skills: list[str] = Field(alias="skills")


ssl._create_default_https_context = ssl._create_unverified_context

app = FastAPI()

origins = [
    "http://localhost",
    "http://localhost:8080",
    "http://localhost:3000",
]

app.add_middleware(
    CORSMiddleware,
    allow_origins=origins,
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"]
)


@app.post("/predict-candidate")
def predict_candidate(model: JobDescription):
    loaded_model, loaded_data, le_job_title, le_skills, le_category, num_node_features = load_model()
    job_descriptions, resumes = load_data()
    new_job = {
        "job_title": model.profession,
        "skills": model.skills
    }

    candidates_df = predict_for_new_job_v1(
        new_job_desc=new_job,
        model=loaded_model,
        data=loaded_data,
        le_job_title=le_job_title,
        le_skills=le_skills,
        le_category=le_category,
        resumes=resumes,
        job_descriptions=job_descriptions,
        k=5
    )

    candidates = [{
        "recommendationId": row["Candidate Recommendation ID"],
        "profession": str(row["Candidate Job Title"]),
        "skills": list(row["Candidate Skills"])
    } for index, row in candidates_df.iterrows()]
    print(candidates)

    return candidates
