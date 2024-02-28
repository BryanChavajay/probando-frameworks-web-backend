from fastapi import APIRouter, Depends
from sqlalchemy.orm import Session
from db.db import SessionLocal
from models.user import UserIn, UserOut
from controllers import user_controller
from .auth_routes import get_current_user
from models.user import UserDB
from typing import Annotated


user_router = APIRouter()


# Dependency
def get_db():
    db = SessionLocal()
    try:
        yield db
    finally:
        db.close()


@user_router.get("/", response_model=list[UserOut])
def read_user(
    current_user: Annotated[UserDB, Depends(get_current_user)],
    db: Session = Depends(get_db),
):
    users = user_controller.get_users(db)
    return users


@user_router.get("/{id_user}", response_model=UserOut)
def read_user_by_id(
    current_user: Annotated[UserDB, Depends(get_current_user)],
    id_user: int,
    db: Session = Depends(get_db),
):
    user = user_controller.get_user_by_id(db, id_user)
    return user


@user_router.get("/emial/", response_model=list[UserOut])
def read_user_by_email(
    current_user: Annotated[UserDB, Depends(get_current_user)],
    email: str,
    db: Session = Depends(get_db),
):
    user = user_controller.get_user_by_email(db, email)
    return user


@user_router.post("/create", response_model=UserOut)
def create_new_user(
    current_user: Annotated[UserDB, Depends(get_current_user)],
    user: UserIn,
    db: Session = Depends(get_db),
):
    new_user = user_controller.create_user(db, user)
    return new_user
