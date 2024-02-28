from typing import Type
from sqlalchemy.orm import Session
from schemas.type_pet import TypePet
from models.type_bet import TypePetIn


def get_types(db: Session):
    return db.query(TypePet).all()


def get_types_by_id(db: Session, id: int):
    return db.query(TypePet).filter(TypePet.id_type_pet == id).first()


def create_type(db: Session, type_pet: TypePetIn):
    breed_db = TypePet(**type_pet.model_dump())
    db.add(breed_db)
    db.commit()
    db.refresh(breed_db)
    return breed_db
