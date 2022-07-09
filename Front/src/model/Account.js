import axios from 'axios';

const URL='https://localhost:7298/api/Acount/Register';
const URLOG='https://localhost:7298/api/Acount/Login';


const USERACCOUNT={
    register:(obj)=>{
        return axios.post(URL,obj);
    },
    login:(obj)=>{
        return axios.post(URLOG,obj);
    }
}

export default USERACCOUNT;