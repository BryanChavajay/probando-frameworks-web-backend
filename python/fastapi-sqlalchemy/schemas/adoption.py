from sqlalchemy import Column, ForeignKey, Integer, String, Date
from sqlalchemy.orm import relationship
from db.db import Base
from schemas.pet import Pet
from schemas.adopter import Adopter
from schemas.user import User


class Adoption(Base):
    __tablename__ = "adopciones"

    id_adoption = Column(
        name="codigoadopcion",
        type_=Integer,
        autoincrement="auto",
        primary_key=True,
        nullable=False,
    )
    id_pet = Column(Integer, ForeignKey("mascotas.codigomascota"), name="codigomascota")
    id_adopter = Column(
        Integer,
        ForeignKey("adoptadores.codigoadoptador"),
        name="codigoadoptador",
        nullable=False,
    )
    date_adoption = Column(name="fechaadopcion", type_=Date)
    id_user = Column(
        Integer, ForeignKey("usuarios.codigousuario"), name="codigousuario"
    )
    description = Column(name="observaciones", type_=String(length=256))

    pets = relationship("Pet", back_populates="adoptions")
    adopters = relationship("Adopter", back_populates="adoptions")
    users = relationship("User", back_populates="adoptions")
