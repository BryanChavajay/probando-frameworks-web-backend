from pydantic import BaseModel, Field, ConfigDict


class BreedIn(BaseModel):
    model_config = ConfigDict(from_attributes=True)

    breed: str = Field(max_length=128)


class BreedOut(BaseModel):
    model_config = ConfigDict(from_attributes=True)

    id_breed: int
    breed: str = Field(max_length=128)
