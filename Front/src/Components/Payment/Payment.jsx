import React, { Fragment } from "react";
import styles from '../Register/Form.module.scss';
import  style  from "./Payment.module.scss";
import {Link,useParams,useNavigate} from 'react-router-dom';
import {useForm} from 'react-hook-form';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import { useState } from "react";
import { useEffect } from "react";
import Swal from 'sweetalert2';
import axios from "axios";



function Payment(){
    const {register,handleSubmit,formState:{errors},reset} = useForm({
        mode: "onTouched"
    });
    let roomId=useParams().id;
    let hotelId=JSON.parse(localStorage.getItem('hotelId'));
    let user=JSON.parse(localStorage.getItem('userLogin'));
    console.log(user);
    let restData=JSON.parse(localStorage.getItem('filterData'));
    console.log(restData);

    const onSuccess=()=> {  
        Swal.fire({   
          text: 'Book Success',  
          icon: 'success',   
          confirmButtonColor: '#478e9a',  
          confirmButtonText: 'OK'  
        });  
      } 
    let navigate=useNavigate();
    let payURL='https://localhost:7298/api/BookingRoomToUsers';
    const onSubmit = (data) => {

        //console.log(data)
        axios.post(payURL,data)
        .then(res=>{
            console.log("book Success",res.data)
        })
        .catch(err=>{
            console.log(err);
        })
        onSuccess();
        navigate('/home')
       
        
    };
    return(
        <Fragment>
            <div className={styles.container}>
                <div className="container">
                     <div className={styles.form}>
                       <form onSubmit={handleSubmit(onSubmit)}>
                       <div className="row">
                            <div className="col-12">
                                <div className="input-group mb-4 d-flex justify-content-center">
                                    <h3>Payment</h3>
                                </div>
                                <div className="input-group mb-4 d-flex flex-column">
                                    <label className="align-self-start mb-2">User Name</label>
                                    <input type="text" className="form-control shadow-sm w-100" placeholder="UserName"
                                    {...register("usename")} value={user.UserName}
                                    name="usename" 
                                    />
                                </div>
                                <div className="input-group mb-4 d-flex flex-column">
                                    <label className="align-self-start mb-2">Hotel Id</label>
                                    <input type="text" className="form-control shadow-sm w-100" placeholder="Hotel Id"
                                    name="hotelId"  value={hotelId}
                                    {...register("hotelId")}
                                    />
                                </div>
                                <div className="input-group mb-4 d-flex flex-column">
                                    <label className="align-self-start mb-2">Room Id</label>
                                    <input type="text" className="form-control shadow-sm w-100" placeholder="Room Id"
                                    name="roomId"  value={roomId}
                                    {...register("roomId")}
                                    />
                                </div>
                                <div className="input-group mb-4 d-flex flex-column">
                                    <label className="align-self-start mb-2">No of Rooms</label>
                                    <input type="text" className="form-control shadow-sm w-100" placeholder="No of rooms"
                                    name="numberOfRooms" value={restData.NumberOfRooms}
                                    {...register("numberOfRooms")}
                                    />
                                </div>
                                <div className="input-group mb-4 d-flex flex-column">
                                    <label className="align-self-start mb-2">No of Adults</label>
                                    <input type="text" className="form-control shadow-sm w-100" placeholder="No of Adults"
                                    name="numberOfAdult" value={restData.NumberOfAdult}
                                    {...register("numberOfAdult")}
                                    />
                                </div>
                                <div className="input-group mb-4 d-flex flex-column">
                                    <label className="align-self-start mb-2">No of Children</label>
                                    <input type="text" className="form-control shadow-sm w-100" placeholder="No of Children"
                                    name="numberOfChildren" value={restData.NumberOfChildren}
                                    {...register("numberOfChildren")}
                                    />
                                </div>
                                <div className="input-group mb-4 d-flex flex-column">
                                    <label className="align-self-start mb-2">Start Date</label>
                                    <input type="text" className="form-control shadow-sm w-100" placeholder="Start Date"
                                    name="startDate"  value={restData.StartDate}
                                    {...register("startDate")}
                                    />
                                </div>
                                <div className="input-group mb-4 d-flex flex-column">
                                    <label className="align-self-start mb-2">End Date</label>
                                    <input type="text" className="form-control shadow-sm w-100" placeholder="End Date"
                                    name="endDate"  value={restData.EndDate}
                                    {...register("endDate")}
                                />
                                </div>
                                
                                <h5 className="mb-4" style={{color:'#327885'}}>Enter Visa Info</h5>
                                <div className="input-group mb-4">
                                    <input type="text" className="form-control shadow-sm" placeholder="Visa Number"
                                    id="visaNo"   name="visaNumber" 
                                    {...register("visaNumber",{required:"visa Number is required"})}
                                    />
                                </div>
                                <p>{errors.visaNumber?.type==='required'&&
                                     <div className={styles.validate}>
                                        <span>visa Number is required</span>
                                     </div>}
                                </p>
                                <div className="input-group mb-4">
                                    <input type="password" className="form-control shadow-sm" placeholder="Visa Password"
                                    id="visaPass" name='visapassword' 
                                    {...register("visapassword",{required:"visa Password is required"})}
                                    />
                                </div>
                                <p>{errors.visapassword?.type==='required'&&
                                     <div className={styles.validate}>
                                        <span>visa Password is required</span>
                                     </div>}
                                </p>
                                <div className="mb-5">
                                     <button className="btn shadow-lg" >Book</button>
                                </div>
                            </div>
                        </div>
                       </form>
                     </div>
                </div>
            </div>
            <div className={style.notify}>
                <ToastContainer position="bottom-left"/>
            </div>
        </Fragment>
    )
}

export default Payment;