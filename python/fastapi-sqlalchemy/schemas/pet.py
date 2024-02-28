from sqlalchemy import Column, ForeignKey, Integer, String, Date
from sqlalchemy.orm import relationship
from db.db import Base
from schemas.type_pet import TypePet
from schemas.breed import Breed


class Pet(Base):
    __tablename__ = "mascotas"

    id_pet = Column(
        name="codigomascota",
        type_=Integer,
        autoincrement="auto",
        nullable=False,
        primary_key=True,
    )
    name = Column(name="nombre", type_=String, nullable=False)
    id_type_pet = Column(
        Integer, ForeignKey("tiposMascotas.codigotipomascota"), name="codigotipomascota"
    )
    id_breed = Column(Integer, ForeignKey("razas.codigoraza"), name="codigoraza")
    check_in_date = Column(name="fechaingreso", type_=Date)
    birthday = Column(name="fechanacimiento", type_=Date)
    description = Column(name="observaciones", type_=String)

    type_pet = relationship("TypePet", back_populates="pets")
    breed = relationship("Breed", back_populates="pets")
    adoptions = relationship("Adoption", back_populates="pets")
