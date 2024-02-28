from pydantic import BaseModel, Field, ConfigDict


class AdopterBase(BaseModel):
    name: str = Field(max_length=128)
    address: str = Field(max_length=256)
    phone_number: str = Field(max_length=8)
    email: str = Field(max_length=128)


class AdopterIn(AdopterBase):
    model_config = ConfigDict(from_attributes=True)

    pass


class AdopterOut(AdopterBase):
    model_config = ConfigDict(
        from_attributes=True,
        json_schema_extra={
            "examples": [
                {
                    "id_adopter": 1,
                    "name": "John Doe",
                    "address": "Guatemala City",
                    "phone_number": "55555555",
                    "email": "johndoe@example.com",
                }
            ]
        },
    )

    id_adopter: int
