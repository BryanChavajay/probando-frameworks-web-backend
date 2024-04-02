import { Pet } from "./entities/pet.js";

export async function getPets() {
  const pets = await Pet.findAll();
  return pets;
}

export async function getPetById({ id }) {
  const pet = await Pet.findByPk(id);
  return pet;
}

/**
 * @param {object} pet
 * @param {string} name
 * @param {Date} birthday
 * @param {number} typePet
 * @param {number} typeBreed
 * @param {Date} dateAdmission
 * @param {string} observations
 */
export async function createPet(pet) {
  const newPet = await Pet.create({
    ...pet,
  });
  return newPet;
}

export async function updatePet(pet, id) {
  const petUpdated = await Pet.update(
    { ...pet },
    {
      where: {
        petId: id,
      },
    }
  );
  return petUpdated;
}
