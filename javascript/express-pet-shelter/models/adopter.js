import { Adopter } from "./entities/adopter.js";

export async function getAdopter() {
  const adoption = await Adopter.findAll();
  return adoption;
}

export async function getAdopterById({ id }) {
  const adopter = await Adopter.findByPk(id);
  return adopter;
}

/**
 * @param {object} adopter
 * @param {string} name
 * @param {string} direction
 * @param {string} phone
 * @param {string} email
 */
export async function createAdopter(adopter) {
  const newAdopter = await Adopter.create({
    ...adopter,
  });
  return newAdopter;
}

export async function updateAdopter(adopter, id) {
  const adopterUpdated = await Adopter.update(
    { ...adopter },
    {
      where: {
        adopterId: id,
      },
    }
  );
  return adopterUpdated;
}
