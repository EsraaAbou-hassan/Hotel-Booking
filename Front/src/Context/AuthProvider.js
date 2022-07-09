import {createContext,Fragment,useState} from 'react';


const AuthContext=createContext({});

export const AuthProvider=({children})=>{
    let [auth,setAuth]=useState({});
    return(
        <Fragment>
            <AuthContext.Provider value={{auth,setAuth}}>
                {children}
            </AuthContext.Provider>

        </Fragment>
    )
} 


export default AuthContext;