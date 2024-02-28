from pydantic import BaseModel, Field, ConfigDict


class User(BaseModel):
    first_name: str = Field(max_length=50)
    second_name: str = Field(max_length=50, default="")
    others_names: str = Field(max_length=50, default="")
    first_last_names: str = Field(max_length=50)
    second_last_names: str = Field(max_length=50, default="")
    user: str = Field(max_length=50)
    email: str = Field(max_length=128)


class UserIn(User):
    model_config = ConfigDict(from_attributes=True)

    password: str = Field(max_length=256)


class UserOut(User):
    model_config = ConfigDict(
        from_attributes=True,
        json_schema_extra={
            "examples": [
                {
                    "id_user": 1,
                    "first_name": "Rick",
                    "second_name": "Doe",
                    "others_names": "Doe",
                    "first_last_names": "Smith",
                    "second_last_names": "Sanchez",
                    "user": "rickdsmith",
                    "email": "rick@example.com",
                },
                {
                    "id_user": 2,
                    "first_name": "Rick",
                    "second_name": "",
                    "others_names": "",
                    "first_last_names": "Smith",
                    "second_last_names": "",
                    "user": "rickdsmith",
                    "email": "rick@example.com",
                },
            ]
        },
    )

    id_user: int


class UserDB(User):
    model_config = ConfigDict(from_attributes=True)

    id_user: int
    password: str = Field(max_length=256)
