from sqlalchemy.orm import Session
from schemas.user import User
from models.user import UserIn
from passlib.context import CryptContext
from models.user import UserDB


def get_users(db: Session):
    return db.query(User).all()


def get_user_by_id(db: Session, id: int):
    return db.query(User).filter(User.id_user == id).first()


def get_user_by_email(db: Session, emial: str):
    return db.query(User).filter(User.email == emial).first()


def create_user(db: Session, user: UserIn):
    pwd_context = CryptContext(schemes=["bcrypt"], deprecated="auto")
    user_dict = user.model_dump()
    hashed_password = pwd_context.hash(user_dict.pop("password"))
    user_db = User(**user_dict, password=hashed_password)

    db.add(user_db)
    db.commit()
    db.refresh(user_db)
    return user_db


def get_user_db(db: Session, email: str) -> UserDB | None:
    user_sqlalchemy = db.query(User).filter(User.email == email).first()
    if user_sqlalchemy:
        # Convertir el objeto SQLAlchemy al modelo Pydantic UserDB
        user_pydantic = UserDB.model_validate(user_sqlalchemy)
        return user_pydantic
    else:
        return None  # O manejar la situación si el usuario no se encuentra
