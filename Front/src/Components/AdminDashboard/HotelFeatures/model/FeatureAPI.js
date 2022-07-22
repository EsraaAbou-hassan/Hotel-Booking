import axios from 'axios';
const URL='https://localhost:7298/api/Features';

const FeatureCRUD={
    getAll:()=>{
        return axios.get(URL);
    },
    getById:(id)=>{
        return axios.get(URL+'/'+id);
    },
    addFeature:(obj)=>{
        return axios.post('https://localhost:7298/api/Features/Add',obj);
    },
    UpdateFeature:(id,newObj)=>{
        return axios.put('https://localhost:7298/api/Features/Update'+'/'+id,newObj);
    },
    deleteFeature:(id)=>{
        return axios.delete('https://localhost:7298/api/Features/Delete'+'/'+id);
    }

}

export default FeatureCRUD;