from sqlalchemy import Column, ForeignKey, Integer, String
from sqlalchemy.orm import relationship
from db.db import Base


class Adopter(Base):
    __tablename__ = "adoptadores"

    id_adopter = Column(
        name="codigoadoptador",
        type_=Integer,
        autoincrement="auto",
        primary_key=True,
        nullable=False,
    )
    name = Column(name="nombre", type_=String(length=128), nullable=False)
    address = Column(name="direccion", type_=String(length=256))
    phone_number = Column(name="telefono", type_=String(length=8))
    email = Column(name="correoelectronico", type_=String(length=128))

    adoptions = relationship("Adoption", back_populates="adopters", primaryjoin="Adoption.id_adopter == Adopter.id_adopter")
