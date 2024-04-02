import { Adoption } from "./entities/adoption.js";

export async function getAdoptions() {
  const adoptions = await Adoption.findAll();
  return adoptions;
}

export async function getAdoptionById({ id }) {
  const adoption = await Adoption.findByPk(id);
  return adoption;
}

/**
 * @param {object} adoption
 * @param {number} petId
 * @param {number} adopterId
 * @param {Date} adoptionDate
 * @param {number} userId
 * @param {string} observations
 */
export async function createAdoption(adoption) {
  const newAdoption = await Adoption.create({
    ...adoption,
  });
  return newAdoption;
}
