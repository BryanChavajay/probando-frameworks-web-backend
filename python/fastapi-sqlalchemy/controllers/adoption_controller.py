from sqlalchemy.orm import Session
from schemas.adoption import Adoption
from models.adoption import AdoptionIn


def get_adoptions(db: Session):
    return db.query(Adoption).all()


def get_adoption_by_id_adoption(db: Session, id: int):
    return db.query(Adoption).filter(Adoption.id_adoption == id).first()


def create_adoption(db: Session, adoption: AdoptionIn):
    adoption_db = Adoption(**adoption.model_dump())
    db.add(adoption_db)
    db.commit()
    db.refresh(adoption_db)
    return adoption_db
