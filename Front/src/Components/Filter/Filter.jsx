import styles from "./Filter.module.scss";
import React, { useState } from "react";
import DatePicker from "react-datepicker";
import "react-datepicker/dist/react-datepicker.css";
import 'react-country-dropdown/dist/index.css'
import CountryDropdown from 'country-dropdown-with-flags-for-react';
import {Link} from 'react-router-dom';

function Filter() {

    const [startDate, setStartDate] = useState(new Date());
    const [endDate, setEndDate] = useState(new Date());
    return (
        <div className={styles.container}>
            <div className="container ">
                <div className={styles.picker}>
                   <div className="row d-flex mx-auto ">
                        <div className="col-md-12  d-md-flex flex-md-row flex-sm-column  p-0 ">
                            <div className="col-md-1 col-12 mb-2">
                                <CountryDropdown id="UNIQUE_ID" className={styles.country} preferredCountries={['gb', 'us']} value="" handleChange={e => console.log(e.target.value)}></CountryDropdown>
                            </div>
                            <div className="col-md-2 col-12">
                                <DatePicker selected={startDate} onChange={(date) => setStartDate(date)} className={styles.dates} />
                            </div>
                            <div className="col-md-2 col-12">
                               <DatePicker selected={endDate} onChange={(date) => setEndDate(date)} className={styles.dates} />
                            </div>
                            <div className="col-md-2 col-12">
                                <select className={styles.dates}>
                                    <option value="volvo">Adults</option>
                                    <option value="saab">1</option>
                                    <option value="saab">2</option>
                                    <option value="mercedes">3</option>
                                    <option value="audi">4</option>
                                </select>
                            </div>
                            <div className="col-md-2 col-12">
                                <select className={styles.dates}>
                                    <option value="volvo">Children</option>
                                    <option value="saab">1</option>
                                    <option value="saab">2</option>
                                    <option value="mercedes">3</option>
                                    <option value="audi">4</option>
                                </select>
                            </div>
                            <div className="col-md-2 col-12">
                                <select className={styles.dates}>
                                    <option value="volvo">Room</option>
                                    <option value="saab">1</option>
                                    <option value="saab">2</option>
                                    <option value="mercedes">3</option>
                                    <option value="audi">4</option>
                                </select>
                            </div>
                            <div className="col-md-1 col-12">
                                <div className={styles.link}>
                                   <Link to='/hotels' className={styles.btn}>Search</Link>

                                </div>
                            </div>
                        </div>   
                    </div>
                </div>
            </div>
        </div>
    );
}

export default Filter;
