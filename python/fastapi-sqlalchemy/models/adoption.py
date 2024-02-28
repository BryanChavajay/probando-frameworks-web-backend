from pydantic import BaseModel, Field, ConfigDict
from datetime import date


class Adoption(BaseModel):
    id_pet: int = Field(ge=1)
    id_adopter: int = Field(ge=1)
    date_adoption: date
    id_user: int = Field(ge=1)
    description: str = Field(max_length=256)


class AdoptionIn(Adoption):
    model_config = ConfigDict(from_attributes=True)

    pass


class AdoptionOut(Adoption):
    model_config = ConfigDict(
        from_attributes=True,
        json_schema_extra={
            "examples": [
                {
                    "id_adoption": 1,
                    "id_pet": 1,
                    "id_adopter": 1,
                    "date_adoption": "2020-12-31",
                    "id_user": 1,
                    "description": "lorem ipsum...",
                }
            ]
        },
    )

    id_adoption: int
