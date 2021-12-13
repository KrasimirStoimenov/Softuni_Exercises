import * as api from './api.js';

export const login = api.login;
export const register = api.register;
export const logout = api.logout;

export async function getAllCars() {
    return api.get('/data/cars?sortBy=_createdOn%20desc');
}

export async function getMyCars(userId) {
    return api.get(`/data/cars?where=_ownerId%3D%22${userId}%22&sortBy=_createdOn%20desc`);
}

export async function getCarById(id) {
    return api.get('/data/cars/' + id);
}

export async function createCar(data) {
    return api.post('/data/cars', data);
}

export async function editCar(id, data) {
    return api.put('/data/cars/' + id, data);
}

export async function deleteCarById(id) {
    return api.del('/data/cars/' + id);
}

export async function searchCars(query) {
    return api.get(`/data/cars?where=year%3D${query}`);
}