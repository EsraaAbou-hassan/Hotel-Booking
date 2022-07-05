import axios from "axios";
let URL="http://localhost:3001/users";

let  USERCURD={
    getAll:()=>{
        return axios.get(URL);
    },
    getById:(id)=>{
        return axios.get(URL+'/'+id);
     },
     addObj:(newObj)=>{
        return axios.post(URL,newObj);
     },
     editObj:(id,newObj)=>{
        return axios.put(URL+'/'+id,newObj);
     },
     deleteObj:(id)=>{
        return axios.delete(URL+'/'+id)
     }
}

export default USERCURD;