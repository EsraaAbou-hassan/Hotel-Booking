import React, { Fragment } from 'react';
import styles from './List.module.scss';
import img from '../../Images/34.jpg';
import Filter from '../Filter/Filter';
import {Link} from 'react-router-dom';


function List(){
    return(
        <Fragment>
           <div className='container mt-5'>
            <div className={styles.container}>
               <div className='row'>
                <div className='col-md-3 col-12'>
                    <div className={styles.sideBar}>
                    </div>
                </div>
                <div className='col-md-9 col-12'>
                    <div className={styles.block}>
                        <div className='row'>
                            <div className='col-md-3 col-4'>
                                <img src={img}/>
                            </div>
                            <div className='col-md-6 col-5'>
                                <h2>Hotel Name</h2>
                                <p>details</p>
                                <p>details</p>
                                <p>details</p>
                            </div>
                            <div className='col-3 d-flex  flex-column justify-content-end align-items-end'>
                                <p><strong>$150</strong></p>
                                <Link to='/rooms' className='btn btn-primary'>availability</Link>
                            </div>
                        </div>
                    </div>
                    <div className={styles.block}>
                        <div className='row'>
                            <div className='col-md-3 col-4'>
                                <img src={img}/>
                            </div>
                            <div className='col-md-6 col-5'>
                                <h2>Hotel Name</h2>
                                <p>details</p>
                                <p>details</p>
                                <p>details</p>
                            </div>
                            <div className='col-3 d-flex  flex-column justify-content-end align-items-end'>
                                <p><strong>$150</strong></p>
                                <button className='btn btn-primary'>availability</button>
                            </div>
                        </div>
                    </div>
                    <div className={styles.block}>
                        <div className='row'>
                            <div className='col-md-3 col-4'>
                                <img src={img}/>
                            </div>
                            <div className='col-md-6 col-5'>
                                <h2>Hotel Name</h2>
                                <p>details</p>
                                <p>details</p>
                                <p>details</p>
                            </div>
                            <div className='col-3 d-flex  flex-column justify-content-end align-items-end'>
                                <p><strong>$150</strong></p>
                                <button className='btn btn-primary'>availability</button>
                            </div>
                        </div>
                    </div>
                    <div className={styles.block}>
                        <div className='row'>
                            <div className='col-md-3 col-4'>
                                <img src={img}/>
                            </div>
                            <div className='col-md-6 col-5'>
                                <h2>Hotel Name</h2>
                                <p>details</p>
                                <p>details</p>
                                <p>details</p>
                            </div>
                            <div className='col-3 d-flex  flex-column justify-content-end align-items-end'>
                                <p><strong>$150</strong></p>
                                <button className='btn btn-primary'>availability</button>
                            </div>
                        </div>
                    </div>
                 </div>
               </div>
            </div>
            <pre>








            </pre>
           </div>
        </Fragment>
    )
}

export default List;