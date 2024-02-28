from sqlalchemy import Column, ForeignKey, Integer, String
from sqlalchemy.orm import relationship
from db.db import Base


class User(Base):
    __tablename__ = "usuarios"

    id_user = Column(
        name="codigousuario",
        type_=Integer,
        autoincrement="auto",
        primary_key=True,
        nullable=False,
    )
    first_name = Column(name="primernombre", type_=String(length=50))
    second_name = Column(name="segundonombre", type_=String(length=50))
    others_names = Column(name="otrosnombres", type_=String(length=50))
    first_last_names = Column(name="primerapellido", type_=String(length=50))
    second_last_names = Column(name="segundoapellido", type_=String(length=50))
    user = Column(name="usuario", type_=String(length=50))
    email = Column(name="correoelectronico", type_=String(length=128))
    password = Column(name="contrasenia", type_=String(length=256))

    adoptions = relationship("Adoption", back_populates="users")
