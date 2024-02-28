from fastapi import APIRouter, Depends, Query
from sqlalchemy.orm import Session
from db.db import SessionLocal
from controllers import adoption_controller
from models.adoption import AdoptionIn, AdoptionOut
from typing import Annotated
from .auth_routes import get_current_user
from models.user import UserDB


adoption_router = APIRouter()


# Dependency
def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


@adoption_router.get("/", response_model=list[AdoptionOut])
def read_adoptions(
    current_user: Annotated[UserDB, Depends(get_current_user)],
    db: Session = Depends(get_db),
):
    adoptions = adoption_controller.get_adoptions(db)
    return adoptions


@adoption_router.get("/{id_adoption}", response_model=AdoptionOut)
def read_adoption_by_id(
    current_user: Annotated[UserDB, Depends(get_current_user)],
    id_adoption: int,
    db: Session = Depends(get_db),
):
    adoption = adoption_controller.get_adoption_by_id_adoption(db, id_adoption)
    return adoption


@adoption_router.post("/create", response_model=AdoptionOut)
def create_new_adoption(
    current_user: Annotated[UserDB, Depends(get_current_user)],
    adoption: AdoptionIn,
    db: Session = Depends(get_db),
):
    new_adoption = adoption_controller.create_adoption(db, adoption)
    return new_adoption
