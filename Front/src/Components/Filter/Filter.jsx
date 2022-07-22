import styles from "./Filter.module.scss";
import React, { useState } from "react";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import 'react-country-dropdown/dist/index.css'
import CountryDropdown from 'country-dropdown-with-flags-for-react';
import {Link,useNavigate} from 'react-router-dom';
import Select from 'react-select';
import {useForm} from 'react-hook-form';
import axios from 'axios'
// import {country} from './CountryData.js';

function Filter() {
    const {register,handleSubmit,formState:{errors},reset} = useForm({
        mode: "onTouched"
    });
    let navigate=useNavigate();
let url='https://localhost:7298/api/BookingRoomToUsers/ChooseHotel';    
const onSubmit=(data)=>{
    console.log(data);
    localStorage.setItem('filterData', JSON.stringify(data));
    axios.post(url,{
        city:data.city,
        StartDate:data.StartDate,
        EndDate:data.EndDate,
        numberOfAdult:data.NumberOfAdult,
        numberOfChildren:data.NumberOfChildren,
        numberOfRooms:data.NumberOfRooms
    })
    .then(res=>{
        if(res.data){
            localStorage.setItem('data', JSON.stringify(res.data));
        }
       
        //console.log(res.data);
    })
    .catch(err=>{console.log(err)})
     navigate('/hotels');

}

   
    return (
        <div className={styles.container}>
            <div className="container my-5">
                   <div className="row">
                         <form onSubmit={handleSubmit(onSubmit)}>
                         <div className="col-md-12  d-md-flex flex-md-row flex-sm-column  p-0  align-items-center justify-content-between my-2">
                               <div className="col-md-4 col-12  px-3" style={{marginBottom:'11px'}}>
                                {/* <CountryDropdown id="UNIQUE_ID" className={styles.country} preferredCountries={['gb', 'us']} value="" handleChange={e => console.log(e.target.value)}></CountryDropdown> */}
                                <div  style={{marginTop:'10px',}}>
                                <span className="mb-2">City</span>
                                <select className="form-control"
                                    name="city" {...register("city")}
                                    >
                                        <option>Select</option>
                                        <option>Cairo</option>
                                        <option>Alexandria</option>
                                        <option>Aswan</option>
                                        <option>Port Said</option>
                                        <option>Luxor</option>
                                        <option>Ismailia</option>
                                        <option>Suez</option>
                                        <option>Matrouh</option>
                                        <option>Red Sea</option>
                                        <option>Sharm</option>
                                        <option>Hurghada</option>
                                        <option> Tanta</option>
                                        <option> Mansoura</option>
                                        <option> Damietta</option>

                                        <option> Sainaa</option>
                                        

                                    </select>
                                   
                                </div>    
                                </div>
                                <div className="col-md-2 col-12  px-3 my-3 ">
                                <span className="mb-2">check-in</span>
                                <div className="date d-flex align-items-center justify-content-between">                       
                                <input type='date' name="StartDate" {...register("StartDate")} className='form-control'
                               
                                />
                                </div>
                                </div>

                                <div className="col-md-2 col-12  px-3 my-3 ">
                                <span className="mb-2">check-out</span>
                                <div className='d-flex align-items-center'>                      
                                <input type='date' name="EndDate" {...register("EndDate")} className='form-control'
                                
                                />
                                </div>
                                </div>
                                <div className="col-md-4 col-12  px-3">
                                    <div className="row justify-content-between align-content-center">
                                    <div className="col-md-3 mt-2">
                                        <span className="mb-2">rooms</span>
                                            <div className="date d-flex align-items-center justify-content-between">
                                            <i class="fa-solid fa-door-closed"></i>
                                            <select className={styles.dates} name="NumberOfRooms" {...register("NumberOfRooms")}>
                                                    <option value="1">1</option>
                                                    <option value="2">2</option>
                                                    <option value="3">3</option>
                                                    <option value="4">4</option>
                                                </select>                         
                                            </div>
                                </div>
                                <div className="col-md-3 mt-2">
                                        <span className="mb-2">Adults</span>
                                            <div className="date d-flex align-items-center justify-content-between">
                                            <i class="fa-solid fa-person"></i>  
                                            <select className={styles.dates} name="NumberOfAdult" {...register("NumberOfAdult")}>
                                                    <option value="1">1</option>
                                                    <option value="2">2</option>
                                                    <option value="3">3</option>
                                                    <option value="4">4</option>
                                                </select>                         
                                            </div>
                                </div>

                                <div className="col-md-3 mt-2 ">
                                        <span className="mb-2">children</span>
                                            <div className="date d-flex align-items-center justify-content-between">
                                            <i class="fa-solid fa-children"></i>
                                            <select className={styles.dates} name="NumberOfChildren" {...register("NumberOfChildren")}>
                                                    <option value="1">1</option>
                                                    <option value="2">2</option>
                                                    <option value="3">3</option>
                                                    <option value="4">4</option>
                                                </select>                         
                                            </div>
                                </div>

                                    </div>
                                    

                                
                                </div> 
    
                            </div>   

                            <div className="col-md-12 col-12  my-3">
                                <div className="row align-item-center justify-content-center">
                                <div className={styles.link}>
                                     <button className={styles.btn}>Search</button>
                                    </div>
                                </div>
                            </div>
                         </form>
                    </div>
            </div>
        </div>
    );
}

export default Filter;
