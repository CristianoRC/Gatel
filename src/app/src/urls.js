const apiUrl = "http://192.168.0.4:5000/api"
export default {
  user: {
    getAll: `${apiUrl}/user`,
    getById: `${apiUrl}/user/@id`,
    delete: `${apiUrl}/user/@id`,
    edit: `${apiUrl}/user/@id`,
    create: `${apiUrl}/user`,
  },
  vehicle: {
    getAll: `${apiUrl}/vehicle`,
    create: `${apiUrl}/vehicle`,
    edit: `${apiUrl}/vehicle/@plate`
  },
  acessControll: {
    verifyVehicle: `${apiUrl}/access`
  }
}