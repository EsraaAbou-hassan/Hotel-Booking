//import { getByDisplayValue } from '@testing-library/react';
import axios from 'axios';
let URL='https://localhost:7298/api/Acount/Register';

let USERCRUD={
    getAll:()=>{
        return axios.get(URL);
    },
    getById:(id)=>{
        return axios.get(URL+'/'+id);
    }
    

}

export default USERCRUD;



