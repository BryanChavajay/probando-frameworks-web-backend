from fastapi import APIRouter, Depends, HTTPException, Query
from sqlalchemy.orm import Session
from models.adopter import AdopterIn, AdopterOut
from controllers import adopter_controller
from db.db import SessionLocal
from typing import Annotated
from .auth_routes import get_current_user
from models.user import UserDB

adopter_router = APIRouter()


# Dependency
def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


@adopter_router.get("/", response_model=list[AdopterOut])
def read_adopters(
    current_user: Annotated[UserDB, Depends(get_current_user)],
    db: Session = Depends(get_db),
):
    adopters = adopter_controller.get_adopters(db)
    return adopters


@adopter_router.get("/{id_adopter}", response_model=AdopterOut)
def read_adopter_by_id(
    current_user: Annotated[UserDB, Depends(get_current_user)],
    id_adopter: int,
    db: Session = Depends(get_db),
):
    adopter = adopter_controller.get_adopter_by_id(db, id_adopter)
    return adopter


@adopter_router.get("/name/", response_model=list[AdopterOut])
def read_adopter_by_name(
    current_user: Annotated[UserDB, Depends(get_current_user)],
    adopter_name: Annotated[
        str,
        Query(
            alias="adopter-name",
            description="The first name of the adopter who is searching",
        ),
    ],
    db: Session = Depends(get_db),
):
    adopters = adopter_controller.get_adopter_by_name(db, adopter_name)
    return adopters


@adopter_router.post("/create", response_model=AdopterOut)
def crea_new_adopter(
    current_user: Annotated[UserDB, Depends(get_current_user)],
    adopter: AdopterIn,
    db: Session = Depends(get_db),
):
    new_adopter = adopter_controller.create_adopter(db, adopter)
    return new_adopter
