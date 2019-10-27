const apiUrl = "https://localhost:5001/api"
export default {
  user: {
    getAll: `${apiUrl}/user`,
    getById: `${apiUrl}/user/@id`,
    delete: `${apiUrl}/user/@id`,
    create: `${apiUrl}/user`,
  }
}