import React, { Fragment,useRef,useEffect,useState ,useContext} from 'react';
import{Link, useNavigate} from 'react-router-dom';
import {useForm} from 'react-hook-form';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import AuthContext from '../../Context/AuthProvider';
import USERACCOUNT from '../../model/Account';
import styles from './Login.module.scss';
import img from '../../Images/11.jpg';




function Login({setStatus,setLogData}){
    const {setAuth}=useContext(AuthContext);
    let navigate=useNavigate();
    const {register,handleSubmit,formState:{errors},reset,watch,getValues} = useForm({
        mode: "onTouched"
    });
  
    let userRef=useRef();
    let errRef=useRef();
    let [user,setUser]=useState('');
    let [pwd,setPwd]=useState('');
    let [errMsg,setErrMsg]=useState('');
    let [success,setSuccess]=useState(false);
    useEffect(()=>{
        setErrMsg('');
    },[user,pwd])
   const changeState=()=>{
   
    
   }
    const onSubmit=async(data)=>{
        console.log(data.UserName)
        
        const respone=USERACCOUNT.login(data)
            .then(res=>{
                if(data.UserName=="Admin"){
                    navigate('/admin');
                }   
                else{
                    setStatus(true);
                    setLogData(data.UserName);
                    localStorage.setItem("userLogin",JSON.stringify(data))
                    navigate('/home')
                }   
            })
            .catch(err=>{
                if(!err?.respone){
                    setErrMsg("Invalid Login")    
                }
                console.log(err)
               
            })
            const accessToken=respone?.data?.accessToken;
            const roles=respone?.data?.roles;
            setAuth({data,accessToken,roles});
            setSuccess(true);     
        reset();
    }
   
    console.log(success);

    return(
        <Fragment>
            <div className={styles.container}>
                <div className='container '>
                    <div className={styles.form}>
                        <form onSubmit={handleSubmit(onSubmit)}> 
                            <div className='row '>
                                <div className='col-5 '>
                                    <img src={img}/>
                                </div>
                                <div className='col-7  d-flex justify-content-center '>
                                    <div className={styles.input}>
                                        <div className=''>
                                            <p className={errMsg?`${styles.errMsg}`:`${styles.sucMsg}`}>{errMsg}</p>
                                        </div>
                                        <div className='mb-3 mt-3'>
                                            <h3>LOGIN</h3>
                                        </div>
                                        <div className='input-group '>
                                            <input type="text" 
                                                className="form-control shadow-sm" 
                                                placeholder="User Name" name="UserName"
                                                id='username' autoComplete='off'
                                                ref={userRef}
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
                                        <div className='input-group  '>
                                            <input type="password" 
                                                className="form-control shadow-sm" 
                                                placeholder="Password" name="Password"
                                                id="password"
                                                
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
                                        <div className='input-group d-flex justify-content-center mb-3'>
                                            <button className='btn btn-primary shadow-lg' onClick={changeState}>Log in</button>
                                        </div>
                                        <div className='mb-4'>
                                            <span className={styles.para}>Not Sign in? </span>
                                            <Link className={styles.link} to='/register'>Sign up</Link>
                                        </div>
                                        
                                    </div>
                                </div>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
           
        </Fragment>
    )
}

export default Login;