import React, { Fragment } from "react";
import styles from './Form.module.scss';
import {useForm} from 'react-hook-form';
import USERACCOUNT from '../../model/Account';
import { useState } from "react";
import { useEffect } from "react";
import {Link,useNavigate} from 'react-router-dom';



function Register({setUpData}){
    let [data,setData]=useState([]);
    let [success,setSuccess]=useState(false);
  
    const {register,handleSubmit,formState:{errors},reset,watch,getValues} = useForm({
        mode: "onTouched"
    });
    let Password = watch("Password");
    let navigate=useNavigate();
    
   
    const onSubmit=async(data)=>{
        if(data){
            //setSuccess(true);
            setUpData(data.UserName);
            navigate('/');

        }
        console.log(data);
        USERACCOUNT.register(data)
        .then(res=>{
            console.log(res)
            //localStorage.setItem("registerData",JSON.stringify(data));
        })
        .catch(err=>{
            console.log(err);
        })
       
        reset();
        
    }
   
    return(
        <Fragment>
            {/* {success?(
                <div>Sucees</div>
            ):( */}
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
                                        placeholder="First Name" name="FirstName"
                                        {...register("FirstName",{required:"First Name is required"})}
                                        />
                                    </div>
                                    <p>{errors.FirstName?.type==='required'&&
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
                                        placeholder="Last Name" name="LastName"
                                        {...register("LastName",{required:"Last Name is required"})}
                                        />
                                    </div>
                                    <p>{errors.LastName?.type==='required'&& 
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
                                        placeholder="Example@gmail.com" name="email"
                                        {...register("email",{required:"Email is required",
                                        pattern:/^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$/})}
                                        />
                                    </div>
                                    <p>{errors.email?.type==='required'&&
                                       <div className={styles.validate}>
                                        <span>Email is required</span>
                                       </div>}
                                    </p>
                                    <p>{errors.email?.type==='pattern'&& 
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
                                        placeholder="Country" name="country"
                                        {...register("country",{required:"Country is required"})}
                                        />
                                    </div>
                                    <p>{errors.country?.type==='required'&& 
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
                                        placeholder="City" name="city"
                                        {...register("city",{required:"City is required"})}
                                        />
                                    </div>
                                    <p>{errors.city?.type==='required'&& 
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
                                        placeholder="Confirm Password" name="ConfirmPassword"
                                        {...register("ConfirmPassword",{required:"Confirm Password is required",
                                        validate: (value) => value === Password || "Confirm password does not match"}
                                        
                                        )}
                                        />
                                    </div>
                                    <p>{errors.ConfirmPassword?.type==='required'&& 
                                       <div className={styles.validate}>
                                         <span>Confirm Password is required</span>
                                        </div>}
                                    </p>
                                    <p>{errors.ConfirmPassword?.type==='validate'&& 
                                       <div className={styles.validate}>
                                         <span>Confirm password does not match</span>
                                        </div>}
                                    </p>
                                    <div className="mb-2">
                                        <button  className="btn shadow-lg">Register</button>
                                    </div>
                                    <div className="mt-3">
                                        <span className={styles.para}>Already have Account?</span>
                                        <Link to='/' className={styles.link}> Log in</Link>
                                    </div>
                                </div>
                            </form>
                        </div>
                     </div>
                </div>
            </div>
            {/* )} */}
        </Fragment>
    )
}

export default Register;