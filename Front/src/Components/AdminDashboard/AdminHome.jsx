import React, { Fragment } from 'react';
import styles from './AdminHome.module.scss';
<<<<<<< HEAD


function AdminHome(){
 return(
    <Fragment>
        <div className={styles.container}>
            <nav class="navbar navbar-expand-lg bg-light shadow-lg p-4">
                <div class="container-fluid">
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                            <li class="nav-item">
                               <a class="nav-link active" aria-current="page" href="#">Admin Dashboard</a>
=======
import USERCRUD from '../../model/User';
import { useState } from 'react';
import { useEffect } from 'react';


function AdminHome(){
    let [array,setAaary]=useState([]);
    useEffect(()=>{
        USERCRUD.getAll()
        .then(res=>{
            console.log(res.data);
        })
        .catch(err=>{
            console.log(err);
        })
    },[])

 return(
    <Fragment>
        <div className={styles.container}>
            <nav className="navbar navbar-expand-lg bg-light shadow-lg p-4">
                <div className="container-fluid">
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                    <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                            <li className="nav-item">
                               <a className="nav-link active" aria-current="page" href="#">Admin Dashboard</a>
>>>>>>> 75b07c7564801afadad13c07dfdafd00827ca0a2
                            </li>  
                        </ul>
                    </div>
                </div>
            </nav>
<<<<<<< HEAD
            <div className={styles.content}>
=======
            {/* <div className={styles.content}>
>>>>>>> 75b07c7564801afadad13c07dfdafd00827ca0a2
               
                    <div className='row'>
                        <div className='col-3 border'></div>
                        <div className='col-9 border'></div>
                    </div>
                
<<<<<<< HEAD
            </div>
=======
            </div> */}
>>>>>>> 75b07c7564801afadad13c07dfdafd00827ca0a2
        </div>
    </Fragment>
 )
}

export default AdminHome