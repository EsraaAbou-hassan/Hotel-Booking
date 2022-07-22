import axios from 'axios';
const URL='https://localhost:7298/api/Rooms';

const RoomCRUD={
    getAll:()=>{
        return axios.get(URL);
    },
    getById:(id)=>{
        return axios.get(URL+'/'+id);
    },
    addRoom:(obj)=>{
        return axios.post(URL,obj);
    },
    updateRoom:(id,newObj)=>{
        return axios.put(URL+'/'+id,newObj);
    },
    delRoom:(id)=>{
        return axios.delete(URL+'/'+id);
    }

}


export default RoomCRUD;