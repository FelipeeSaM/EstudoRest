import Axios from 'axios'

const api = Axios.create( { baseURL : 'https://localhost:59929' } )

export default api;