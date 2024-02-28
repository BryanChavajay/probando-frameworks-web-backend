from fastapi import FastAPI
from routes import adopter_routes
from routes import adoption_routes
from routes import breed_routes
from routes import pet_routes
from routes import type_pet_routes
from routes import user_routes
from routes import auth_routes

app = FastAPI(
    summary="This is an API for practice :)", title="API Pet Shelter", version="0.01"
)

app.include_router(
    adopter_routes.adopter_router, prefix="/api/v1/adopter", tags=["Adopters"]
)
app.include_router(
    adoption_routes.adoption_router, prefix="/api/v1/adoption", tags=["Adoptions"]
)
app.include_router(pet_routes.router, prefix="/api/v1/pets", tags=["Pets"])
app.include_router(breed_routes.breed_router, prefix="/api/v1/breed", tags=["breeds"])
app.include_router(
    type_pet_routes.type_pet_router, prefix="/api/v1/types", tags=["TypesPets"]
)
app.include_router(user_routes.user_router, prefix="/api/v1/users", tags=["Users"])
app.include_router(auth_routes.auth_router, tags=["auth"])
