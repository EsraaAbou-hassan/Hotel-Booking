import React, { Fragment } from 'react';
import styles from './AdminHome.module.scss';


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
                            </li>  
                        </ul>
                    </div>
                </div>
            </nav>
            <div className={styles.content}>
               
                    <div className='row'>
                        <div className='col-3 border'></div>
                        <div className='col-9 border'></div>
                    </div>
                
            </div>
        </div>
    </Fragment>
 )
}

export default AdminHome