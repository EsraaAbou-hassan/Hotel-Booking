import React, { Fragment } from "react";
import styles from './Register.module.scss';


function Register(){
    return(
        <Fragment>
            <div className={styles.container}>
                <div className="container">
                     <div className={styles.form}>
                        <div className="row">
                            <div className="col-12">
                                <div className="input-group mb-4 d-flex justify-content-center">
                                    <h3>Register</h3>
                                </div>
                                <div className="input-group mb-4">
                                    <span className="input-group-text " id="basic-addon1">
                                       <i class="fa-solid fa-user"></i>
                                    </span>
                                    <input type="text" className="form-control shadow-sm" placeholder="First Name"/>
                                </div>
                                <div className="input-group mb-4">
                                    <span className="input-group-text" id="basic-addon1"> 
                                        <i class="fa-solid fa-user"></i>
                                    </span>
                                    <input type="text" className="form-control shadow-sm" placeholder="Last Name"/>
                                </div>
                                <div className="input-group mb-4">
                                    <span className="input-group-text" id="basic-addon1"> 
                                         <i class="fa-solid fa-envelope"></i>
                                    </span>
                                    <input type="Email" className="form-control shadow-sm" placeholder="Email"/>
                                </div>
                                <div className="input-group mb-4">
                                    <span className="input-group-text" id="basic-addon1">
                                       <i class="fa-solid fa-location-dot"></i>
                                    </span>
                                    <input type="text" className="form-control shadow-sm" placeholder="Address"/>
                                </div>
                                <div className="input-group mb-4">
                                    <span className="input-group-text" id="basic-addon1">
                                        <i class="fa-solid fa-key"></i>
                                    </span>
                                    <input type="password" className="form-control shadow-sm" placeholder="Password"/>
                                </div>
                                <div className="mb-5">
                                     <button className="btn shadow-lg">Register</button>
                                </div>
                            </div>
                        </div>
                     </div>
                </div>
            </div>
        </Fragment>
    )
}

export default Register;