import axios from 'axios';
let URL='https://localhost:7298/api/Users';

let USERCRUD={
    getAll:()=>{
        return axios.get(URL);
    },
    getById:(id)=>{
        return axios.get(URL+'/'+id);
    }
    

}

export default USERCRUD;



