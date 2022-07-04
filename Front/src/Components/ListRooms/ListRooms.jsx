import React, { Fragment } from 'react';
import styles from './ListRooms.module.scss';
import img1 from '../../Images/17.webp';
import img2 from '../../Images/18.jpg';
import img3 from '../../Images/19.jpg';
import img4 from '../../Images/48.jpg';

function ListRooms(){
    return(
        <Fragment>
            <div className='container mt-5 p-3'>
                <div className={styles.container}>
                    <div className='row'>
                        <div className='col-12'>
                            <h2 className={styles.h2}>Hotel Name</h2>
                            <div className='d-flex mt-3'>
                                <i class="fa-solid fa-location-dot"></i>
                                <p className={styles.para}>cairo,street 10 Egypt</p>
                            </div>
                        </div>
                    </div>
                    <div className={styles.gallery}>
                        <div className='row'>
                            <div className='col-md-3 col-6'>
                                <img src={img1} />
                            </div>
                            <div className='col-md-3 col-6'>
                                <img src={img2} />
                            </div>
                            <div className='col-md-3 col-6'>
                                <img src={img3} />
                            </div>
                            <div className='col-md-3 col-6'>
                                <img src={img4} />
                            </div>
                        </div>
                    </div>
                    <div className={styles.gallery}>
                        <div className='row'>
                            <div className='col-md-3 col-6'>
                                <img src={img1} />
                            </div>
                            <div className='col-md-3 col-6 '>
                                <img src={img2} />
                            </div>
                            <div className='col-md-3 col-6 '>
                                <img src={img3} />
                            </div>
                            <div className='col-md-3 col-6'>
                                <img src={img4} />
                            </div>
                        </div>
                    </div>
                    <div className='row'>
                        <div className='col-12'>
                            <h2>Description</h2>
                            <p>description for hotel like it's name, it's location</p>
                            <p>hotel service like air condition, breakfast, jym, etc...</p>
                            <button className='btn btn-primary'>Availability</button>
                        </div>
                    </div>
                </div>
            </div>
        </Fragment>
    )
}
export default ListRooms;