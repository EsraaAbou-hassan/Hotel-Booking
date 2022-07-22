import axios from 'axios';
const URL='https://localhost:7298/api/Services';

const ServiceCRUD={
    getAll:()=>{
        return axios.get(URL);
    },
    getById:(id)=>{
        return axios.get(URL+'/'+id);
    },
    addService:(obj)=>{
        return axios.post('https://localhost:7298/api/Services/Add',obj);
    },
    UpdateService:(id,newObj)=>{
        return axios.put(URL+'/'+id,newObj);
    },
    deleteService:(id)=>{
        return axios.delete('https://localhost:7298/api/Services/Delete'+'/'+id);
    }

}
export default ServiceCRUD;