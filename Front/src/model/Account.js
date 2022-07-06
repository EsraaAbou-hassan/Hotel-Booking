import axios from 'axios';

const URL='https://localhost:7298/api/Acount/Register';


const USERACCOUNT={
    register:(obj)=>{
        return axios.post(URL,obj);
    }
}

export default USERACCOUNT;