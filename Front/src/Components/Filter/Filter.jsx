import styles from "./Filter.module.scss";
import React, { useState } from "react";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import 'react-country-dropdown/dist/index.css'
import CountryDropdown from 'country-dropdown-with-flags-for-react';
import {Link} from 'react-router-dom';
import Select from 'react-select';
// import {country} from './CountryData.js';

function Filter() {

//================================Data=========================================
const country=
[
{ value:"Cairo" , label:"Cairo"},
{ value:"Giza" , label:"Giza"},
{ value:"Alexandria" , label:"Alexandria"},
{ value:"Dakahlia" , label:"Dakahlia"},
{ value:"Red Sea" , label:"Red Sea"},
{ value:"Beheira" , label:"Beheira"},
{ value:"Fayoum" , label:"Fayoum"},
{ value:"Ismailia" , label:"Ismailia"},
{ value:"Menofia" , label:"Menofia"},
{ value:"Minya" , label:"Minya"},
{ value:"Qaliubiya" , label:"Qaliubiya"},
{ value:"New Valley" , label:"New Valley"},
{ value:"Suez" , label:"Suez"},
{ value:"Aswan" , label:"Aswan"},
{ value:"Assiut" , label:"Assiut"},
{ value:"Beni Suef" , label:"Beni Suef"},
{ value:"Port Said" , label:"Port Said"},
{ value:"Damietta" , label:"Damietta"},
{ value:"Sharkia" , label:"Sharkia"},
{ value:"South Sinai" , label:"South Sinai"},
{ value:"Kafr Al sheikh" , label:"Kafr Al sheikh"},
{ value:"Matrouh" , label:"Matrouh"},
{ value:"Damietta" , label:"Damietta"},
{ value:"Luxor" , label:"Luxor"},
{ value:"Qena" , label:"Qena"},
{ value:"North Sinai" , label:"North Sinai"},
{ value:"Sohag" , label:"Sohag"},
];

//===============================================
    const [startDate, setStartDate] = useState(new Date());
    const [endDate, setEndDate] = useState(new Date());
    return (
        <div className={styles.container}>
            <div className="container my-5">
                   <div className="row">
                        <div className="col-md-12  d-md-flex flex-md-row flex-sm-column  p-0  align-items-center justify-content-between my-2">
                            <div className="col-md-4 col-12 mb-2 px-3">
                                {/* <CountryDropdown id="UNIQUE_ID" className={styles.country} preferredCountries={['gb', 'us']} value="" handleChange={e => console.log(e.target.value)}></CountryDropdown> */}
                                <div className="goining-part" style={{marginTop:'15px',}}>
                                    <Select
                                        // value={selectedOption}
                                        // onChange={this.handleChange}
                                        options={country}
                                        placeholder="Going to"
                                    />

                                </div>
                                
                            </div>
                            <div className="col-md-2 col-12  px-3 my-3 ">
                            <span >check-in</span>
                            <div className="date d-flex align-items-center justify-content-between">
                            <i class="fa-solid fa-calendar"></i>                         
                            <DatePicker selected={startDate}  onChange={(date) => setStartDate(date)} className={styles.dates}/>
                            </div>
                            </div>

                            <div className="col-md-2 col-12  px-3 my-3 ">
                            <span >check-out</span>
                            <div className="date d-flex align-items-center justify-content-between">
                            <i class="fa-solid fa-calendar"></i>                         
                            <DatePicker selected={endDate}  onChange={(date) => setEndDate(date)} className={styles.dates}/>
                            </div>
                            </div>
                            
                            

                            <div className="col-md-4 col-12  px-3">
                                <div className="row justify-content-between align-content-center">
                                <div className="col-md-3 my-3">
                                    <span >rooms</span>
                                        <div className="date d-flex align-items-center justify-content-between">
                                        <i class="fa-solid fa-door-closed"></i>
                                        <select className={styles.dates}>
                                                <option value="1">1</option>
                                                <option value="2">2</option>
                                                <option value="3">3</option>
                                                <option value="4">4</option>
                                            </select>                         
                                        </div>
                               </div>
                               <div className="col-md-3 my-3">
                                    <span >Adults</span>
                                        <div className="date d-flex align-items-center justify-content-between">
                                        <i class="fa-solid fa-person"></i>  
                                        <select className={styles.dates}>
                                                <option value="1">1</option>
                                                <option value="2">2</option>
                                                <option value="3">3</option>
                                                <option value="4">4</option>
                                            </select>                         
                                        </div>
                               </div>

                               <div className="col-md-3 my-3 ">
                                    <span >children</span>
                                        <div className="date d-flex align-items-center justify-content-between">
                                        <i class="fa-solid fa-children"></i>
                                        <select className={styles.dates}>
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
                                   <Link to='/hotels' className={styles.btn}>Search</Link>
                                </div>
                               </div>

                            </div>
                    </div>
            </div>
        </div>
    );
}

export default Filter;
