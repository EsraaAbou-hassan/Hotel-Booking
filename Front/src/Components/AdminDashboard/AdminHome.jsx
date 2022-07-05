import React, { Fragment } from 'react';
import styles from './AdminHome.module.scss';
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
                            </li>  
                        </ul>
                    </div>
                </div>
            </nav>
            {/* <div className={styles.content}>
               
                    <div className='row'>
                        <div className='col-3 border'></div>
                        <div className='col-9 border'></div>
                    </div>
                
            </div> */}
        </div>
    </Fragment>
 )
}

export default AdminHome