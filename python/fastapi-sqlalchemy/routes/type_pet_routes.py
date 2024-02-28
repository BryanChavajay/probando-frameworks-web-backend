from fastapi import APIRouter, Depends
from sqlalchemy.orm import Session
from db.db import SessionLocal
from models.type_bet import TypePetIn, TypePetOut
from controllers import type_pet_controller
from .auth_routes import get_current_user
from models.user import UserDB
from typing import Annotated


type_pet_router = APIRouter()


# Dependency
def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


@type_pet_router.get("/", response_model=list[TypePetOut])
def read_types_pet(
    current_user: Annotated[UserDB, Depends(get_current_user)],
    db: Session = Depends(get_db),
):
    types_pets = type_pet_controller.get_types(db)
    return types_pets


@type_pet_router.get("/{id_type}", response_model=TypePetOut)
def read_type_pet_by_id(
    current_user: Annotated[UserDB, Depends(get_current_user)],
    id_type: int,
    db: Session = Depends(get_db),
):
    type_pet = type_pet_controller.get_types_by_id(db, id_type)
    return type_pet


@type_pet_router.post("/create", response_model=TypePetOut)
def create_new_type(
    current_user: Annotated[UserDB, Depends(get_current_user)],
    type_pet: TypePetIn,
    db: Session = Depends(get_db),
):
    new_type_pet = type_pet_controller.create_type(db, type_pet)
    return new_type_pet
