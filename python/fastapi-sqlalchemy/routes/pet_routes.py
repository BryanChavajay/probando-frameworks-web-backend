from fastapi import APIRouter, Depends, HTTPException, Query
from sqlalchemy.orm import Session
from models.pet import PetOut, PetIn
from controllers import pet
from db.db import SessionLocal
from typing import Annotated
from .auth_routes import get_current_user
from models.user import UserDB


router = APIRouter()


# Dependency
def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


@router.get("/", response_model=list[PetOut])
def read_pets(
    current_user: Annotated[UserDB, Depends(get_current_user)],
    db: Session = Depends(get_db),
):
    pets = pet.get_pets(db)
    return pets


@router.get("/{id_pet}", response_model=PetOut)
def read_pet_by_id(
    current_user: Annotated[UserDB, Depends(get_current_user)],
    id_pet: int,
    db: Session = Depends(get_db),
):
    pet_id = pet.get_pet_by_id(db, id_pet)
    if pet_id is None:
        raise HTTPException(status_code=404, detail="No se encontró")
    return pet_id


@router.get("/name/", response_model=list[PetOut])
def read_pet_by_name(
    current_user: Annotated[UserDB, Depends(get_current_user)],
    name: str,
    db: Session = Depends(get_db),
):
    pet_name = pet.get_pet_by_name(db, name)
    return pet_name


@router.post("/create", response_model=PetOut)
def create_new_pet(
    current_user: Annotated[UserDB, Depends(get_current_user)],
    pet_in: PetIn,
    db: Session = Depends(get_db),
):
    db_pet = pet.create_pet(db, pet_in)
    return db_pet
