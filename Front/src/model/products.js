import axios from "axios";
let URL="http://localhost:3001/products";

let PRDCURD={
    getAll:()=>{
        return axios.get(URL);
    },
    getById:(id)=>{
        return axios.get(URL+'/'+id);
     },
     addObj:(newObj)=>{
        return axios.post(URL,newObj);
     }
}

export default PRDCURD;