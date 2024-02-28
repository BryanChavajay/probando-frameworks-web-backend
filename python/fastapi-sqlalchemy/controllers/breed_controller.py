from sqlalchemy.orm import Session
from schemas.breed import Breed
from models.breed import BreedIn


def get_breeds(db: Session):
    return db.query(Breed).all()


def get_breed_by_id(db: Session, id: int):
    return db.query(Breed).filter(Breed.id_breed == id).first()


def create_breed(db: Session, breed: BreedIn):
    breed_db = Breed(**breed.model_dump())
    db.add(breed_db)
    db.commit()
    db.refresh(breed_db)
    return breed_db
