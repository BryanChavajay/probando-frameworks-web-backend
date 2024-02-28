from sqlalchemy import Column, Integer, String
from sqlalchemy.orm import relationship
from db.db import Base


class TypePet(Base):
    __tablename__ = "tiposMascotas"

    id_type_pet = Column(
        name="codigotipomascota",
        type_=Integer,
        autoincrement="auto",
        primary_key=True,
        nullable=False,
    )
    type_pet = Column(name="tipo", type_=String(length=128))

    pets = relationship("Pet", back_populates="type_pet")
