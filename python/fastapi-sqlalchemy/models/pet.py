from pydantic import BaseModel, Field, ConfigDict
from datetime import date


class PetBase(BaseModel):
    name: str = Field(title="Name of the pet", max_length=128)
    id_type_pet: int
    id_breed: int
    check_in_date: date
    birthday: date | None = None
    description: str | None = Field(default=None, title="Observations", max_length=256)


class PetIn(PetBase):
    model_config = ConfigDict(from_attributes=True)

    pass


class PetOut(PetBase):
    model_config = ConfigDict(
        from_attributes=True,
        json_schema_extra={
            "examples": [
                {
                    "id_pet": 1,
                    "name": "Bob",
                    "id_type_pet": 1,
                    "id_breed": 1,
                    "check_in_date": "2020-12-31",
                    "birthday": "2020-12-31",
                    "description": "Some description",
                }
            ]
        },
    )

    id_pet: int
