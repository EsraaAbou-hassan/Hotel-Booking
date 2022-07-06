import React, { Fragment } from "react";
import styles from './Register.module.scss';
import {useForm} from 'react-hook-form';
import USERACCOUNT from '../../model/Account';
import { useState } from "react";
import { useEffect } from "react";


function Register(){
    let [data,setData]=useState([]);
    useEffect(()=>{
        

    },[])
    const {register,handleSubmit,formState:{errors},reset,watch,getValues} = useForm({
        mode: "onTouched"
    });
    let Password = watch("Password");
    const onSubmit=(data)=>{
        console.log(data);
        USERACCOUNT.register(data)
        .then(res=>{
            console.log(res)
        })
        .catch(err=>{
            console.log(err);
        })
       
        reset();
        
    }
   
    return(
        <Fragment>
            <div className={styles.container}>
                <div className="container">
                     <div className={styles.form}>
                        <div className="row">
                            <form onSubmit={handleSubmit(onSubmit)}>
                                <div className="col-12">
                                    <div className="input-group mb-4 d-flex justify-content-center">
                                        <h3>Register</h3>
                                    </div>
                                    <div className="input-group mb-4">
                                        <span className="input-group-text " id="basic-addon1">
                                        <i className="fa-solid fa-user"></i>
                                        </span>
                                        <input type="text" 
                                        className="form-control shadow-sm"
                                        placeholder="First Name" name="FName"
                                        {...register("FName",{required:"First Name is required"})}
                                        />
                                    </div>
                                    <p>{errors.FName?.type==='required'&&
                                     <div className={styles.validate}>
                                        <span>First Name is required</span>
                                     </div>}
                                    </p>
                                    <div className="input-group mb-4">
                                        <span className="input-group-text" id="basic-addon1"> 
                                            <i className="fa-solid fa-user"></i>
                                        </span>
                                        <input type="text" 
                                        className="form-control shadow-sm" 
                                        placeholder="Last Name" name="LName"
                                        {...register("LName",{required:"Last Name is required"})}
                                        />
                                    </div>
                                    <p>{errors.LName?.type==='required'&& 
                                       <div className={styles.validate}>
                                        <span>Last Name is required</span>
                                       </div>}
                                    </p>
                                    <div className="input-group mb-4">
                                        <span className="input-group-text" id="basic-addon1"> 
                                            <i className="fa-solid fa-user"></i>
                                        </span>
                                        <input type="text" 
                                        className="form-control shadow-sm" 
                                        placeholder="User Name" name="UserName"
                                        {...register("UserName",{required:"User Name is required",pattern:/^[^\s]+$/})}
                                        />
                                    </div>
                                    <p>{errors.UserName?.type==='required'&& 
                                       <div className={styles.validate}>
                                        <span>UserName is required</span>
                                       </div>}
                                    </p>
                                    <p>{errors.UserName?.type==='pattern'&& 
                                       <div className={styles.validate}>
                                        <span>No spaces allowed</span>
                                       </div>}
                                    </p>
                                    <div className="input-group mb-4">
                                        <span className="input-group-text" id="basic-addon1"> 
                                            <i className="fa-solid fa-envelope"></i>
                                        </span>
                                        <input type="Email" 
                                        className="form-control shadow-sm" 
                                        placeholder="Example@gmail.com" name="Email"
                                        {...register("Email",{required:"Email is required",
                                        pattern:/^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/})}
                                        />
                                    </div>
                                    <p>{errors.Email?.type==='required'&&
                                       <div className={styles.validate}>
                                        <span>Email is required</span>
                                       </div>}
                                    </p>
                                    <p>{errors.Email?.type==='pattern'&& 
                                       <div className={styles.validate}>
                                        <span>Email should be Example@gmail.com</span>
                                       </div>}
                                    </p>
                                    <div className="input-group mb-4">
                                        <span className="input-group-text" id="basic-addon1">
                                        <i className="fa-solid fa-location-dot"></i>
                                        </span>
                                        <input type="text" 
                                        className="form-control shadow-sm" 
                                        placeholder="Country" name="Country"
                                        {...register("Country",{required:"Country is required"})}
                                        />
                                    </div>
                                    <p>{errors.Country?.type==='required'&& 
                                       <div className={styles.validate}>
                                        <span>Country is required</span>
                                       </div>}
                                    </p>
                                    <div className="input-group mb-4">
                                        <span className="input-group-text" id="basic-addon1">
                                        <i className="fa-solid fa-location-dot"></i>
                                        </span>
                                        <input type="text" 
                                        className="form-control shadow-sm" 
                                        placeholder="City" name="City"
                                        {...register("City",{required:"City is required"})}
                                        />
                                    </div>
                                    <p>{errors.City?.type==='required'&& 
                                      <div className={styles.validate}>
                                        <span>City is required</span>
                                      </div>}
                                    </p>
                                    <div className="input-group mb-4">
                                        <span className="input-group-text" id="basic-addon1">
                                            <i className="fa-solid fa-key"></i>
                                        </span>
                                        <input type="password" 
                                        className="form-control shadow-sm" 
                                        placeholder="Password" name="Password"
                                        {...register("Password",{required:"Password is required",
                                        pattern:/^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})([^\s]+$)/
                                        })}
                                        />
                                    </div>
                                    <p>{errors.Password?.type==='required'&& 
                                      <div className={styles.validate}>
                                        <span>Password is required</span>
                                      </div>}
                                    </p>
                                    <p>{errors.Password?.type==='pattern'&& 
                                      <div className={styles.validate}>
                                        <span>Password should containe Lowercase, Uppercase, Number, Special Characters
                                            and at least 8 charcters and no spaces allowed
                                            
                                        </span>
                                      </div>}
                                    </p>
                                    <div className="input-group mb-4">
                                        <span className="input-group-text" id="basic-addon1">
                                            <i className="fa-solid fa-key"></i>
                                        </span>
                                        <input type="password" 
                                        className="form-control shadow-sm" 
                                        placeholder="Confirm Password" name="ConfirmPass"
                                        {...register("ConfirmPass",{required:"ConfirmPass is required",
                                        validate: (value) => value === Password || "Confirm password does not match"}
                                        
                                        )}
                                        />
                                    </div>
                                    <p>{errors.ConfirmPass?.type==='required'&& 
                                       <div className={styles.validate}>
                                         <span>Confirm Password is required</span>
                                        </div>}
                                    </p>
                                    <p>{errors.ConfirmPass?.type==='validate'&& 
                                       <div className={styles.validate}>
                                         <span>Confirm password does not match</span>
                                        </div>}
                                    </p>
                                    <div className="mb-2">
                                        <button className="btn shadow-lg">Register</button>
                                    </div>
                                </div>
                            </form>
                        </div>
                     </div>
                </div>
            </div>
        </Fragment>
    )
}

export default Register;