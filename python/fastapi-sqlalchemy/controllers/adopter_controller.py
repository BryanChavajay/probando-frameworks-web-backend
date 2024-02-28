from sqlalchemy.orm import Session
from schemas.adopter import Adopter
from models.adopter import AdopterIn


def get_adopters(db: Session):
    return db.query(Adopter).all()


def get_adopter_by_name(db: Session, name: str):
    return db.query(Adopter).filter(Adopter.name == name).all()


def get_adopter_by_id(db: Session, id: int):
    return db.query(Adopter).filter(Adopter.id_adopter == id).first()


def create_adopter(db: Session, adopter: AdopterIn):
    adopter_db = Adopter(
        **adopter.model_dump()
    )  # model_dump() Desestructuring PetIn in a dic
    db.add(adopter_db)
    db.commit()
    db.refresh(adopter_db)
    return adopter_db
