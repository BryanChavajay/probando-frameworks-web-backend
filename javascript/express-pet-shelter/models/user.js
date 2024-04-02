import { User } from "./entities/user.js";
import { Op } from "sequelize";

export async function getUsers() {
  const users = await User.findAll({
    attributes: [
      "userId",
      "firstName",
      "secondName",
      "othersNames",
      "firstLastname",
      "secondLastName",
      "user",
      "email",
    ],
  });
  return users;
}

export async function getUserById({ id }) {
  const user = await User.findByPk(id, {
    attributes: [
      "userId",
      "firstName",
      "secondName",
      "othersNames",
      "firstLastname",
      "secondLastName",
      "user",
      "email",
    ],
  });
  return user;
}

export async function getUserByEmailOrUser(emailOrUsername) {
  const userSearch = await User.findOne({
    where: {
      [Op.or]: [{ email: emailOrUsername }, { user: emailOrUsername }],
    },
    attributes: ["userId", "user", "email", "password"],
  });
  return userSearch;
}

/**
 * @param {object} user
 * @param {string} firstname
 * @param {string} secondName
 * @param {string} otherNames
 * @param {string} firstLastName
 * @param {string} secondLastName
 * @param {string} user
 * @param {string} email
 * @param {string} password
 */
export async function createUser(user) {
  const newUser = await User.create({
    ...user,
  });
  const userCreated = await User.findByPk(newUser["userId"], {
    attributes: [
      "userId",
      "firstName",
      "secondName",
      "othersNames",
      "firstLastname",
      "secondLastName",
      "user",
      "email",
    ],
  });
  return userCreated;
}

export async function updateUser(user, id) {
  const userUpdated = await User.update(
    { ...user },
    {
      where: {
        userId: id,
      },
    }
  );
  return userUpdated;
}
