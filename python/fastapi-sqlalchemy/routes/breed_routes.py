from fastapi import APIRouter, Depends
from sqlalchemy.orm import Session
from db.db import SessionLocal
from models.breed import BreedIn, BreedOut
from controllers import breed_controller
from .auth_routes import get_current_user
from models.user import UserDB
from typing import Annotated


breed_router = APIRouter()


# Dependency
def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


@breed_router.get("/", response_model=list[BreedOut])
def read_breeds(
    current_user: Annotated[UserDB, Depends(get_current_user)],
    db: Session = Depends(get_db),
):
    breeds = breed_controller.get_breeds(db)
    return breeds


@breed_router.get("/{id_breed}", response_model=BreedOut)
def read_breed_by_id(
    current_user: Annotated[UserDB, Depends(get_current_user)],
    id_breed: int,
    db: Session = Depends(get_db),
):
    breed = breed_controller.get_breed_by_id(db, id_breed)
    return breed


@breed_router.post("/create", response_model=BreedOut)
def create_new_breed(
    current_user: Annotated[UserDB, Depends(get_current_user)],
    breed: BreedIn,
    db: Session = Depends(get_db),
):
    new_breed = breed_controller.create_breed(db, breed)
    return new_breed
