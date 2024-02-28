from sqlalchemy import Column, Integer, String
from db.db import Base
from sqlalchemy.orm import relationship


class Breed(Base):
    __tablename__ = "razas"

    id_breed = Column(
        name="codigoraza",
        type_=Integer,
        autoincrement="auto",
        nullable=False,
        primary_key=True,
    )
    breed = Column(name="raza", type_=String(length=128))

    pets = relationship("Pet", back_populates="breed")
