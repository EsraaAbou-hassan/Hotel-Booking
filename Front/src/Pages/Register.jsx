import React, { Fragment } from 'react';
import Register from '../Components/Register/Register';

function RegisterScreen({setUpData}){

    return(
        <Fragment>
            <Register setUpData={setUpData}/>

        </Fragment>
    )
}

export default RegisterScreen;