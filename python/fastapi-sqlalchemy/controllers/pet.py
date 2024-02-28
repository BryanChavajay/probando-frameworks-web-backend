from sqlalchemy.orm import Session
from schemas.pet import Pet
from models.pet import PetIn


def get_pets(db: Session):
    return db.query(Pet).all()


def get_pet_by_id(db: Session, id: int):
    return db.query(Pet).filter(Pet.id_pet == id).first()


def get_pet_by_name(db: Session, name: str):
    result = db.query(Pet).filter(Pet.name == name).all()
    print(result)
    return result


def create_pet(db: Session, pet_in: PetIn):
    pet_db = Pet(**pet_in.model_dump()) #model_dump() Desestructuring PetIn in a dic
    db.add(pet_db)
    db.commit()
    db.refresh(pet_db)
    return pet_db
