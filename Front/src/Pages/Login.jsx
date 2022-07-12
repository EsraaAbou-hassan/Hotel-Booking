import React, { Fragment } from 'react';
import Login from '../Components/Login/Login';

function LoginScreen({setStatus,setLogData}){
    return(
        <Fragment>
            <Login setStatus={setStatus} setLogData={setLogData}/>
        </Fragment>
    )
}

export default LoginScreen;