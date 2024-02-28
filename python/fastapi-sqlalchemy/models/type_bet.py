from pydantic import BaseModel, Field, ConfigDict


class TypePetIn(BaseModel):
    model_config = ConfigDict(from_attributes=True)

    type_pet: str = Field(max_length=128)


class TypePetOut(BaseModel):
    model_config = ConfigDict(from_attributes=True)

    id_type_pet: int
    type_pet: str = Field(max_length=128)
