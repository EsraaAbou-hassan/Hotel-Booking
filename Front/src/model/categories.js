import axios from "axios";
let URL="http://localhost:3001/categories";

let CATCURD={
    getAll:()=>{
        return axios.get(URL);
    }
}

export default CATCURD;