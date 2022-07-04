import React, { Fragment } from 'react';
import styles from './Gallery.module.scss';

import img1 from '../../Images/17.webp';
import img2 from '../../Images/18.jpg';
import img3 from '../../Images/19.jpg';
import img4 from '../../Images/48.jpg';

function Gallery(){
    return(
        <Fragment>
            <div className='container  w-md-75 w-sm-100 p-3'>
                <div className={styles.container}>
                    <div className='row'>
                        <div className='mt-5 col-12 text-center'>
                        <h2 className={styles.h2}>Gallery</h2>
                        </div>
                    </div>
                    <div className='row mt-5'>
                        <div className='col-3'>
                            <div className={styles.myDiv} ></div>
                        </div>
                    </div>
                    <div className={styles.gallery}>
                        <div className='row'>
                            <div className='col-md-3 col-6 mb-5'>
                                <img src={img1} />
                            </div>
                            <div className='col-md-3 col-6 mb-5'>
                                <img src={img2} />
                            </div>
                            <div className='col-md-3 col-6 mb-5'>
                                <img src={img3} />
                            </div>
                            <div className='col-md-3 col-6 mb-5'>
                                <img src={img4} />
                            </div>
                        </div>
                    </div>
                    <div className={styles.gallery}>
                        <div className='row'>
                            <div className='col-md-3 col-6 mb-5'>
                                <img src={img1} />

                            </div>
                            <div className='col-md-3 col-6 mb-5'>
                                <img src={img2} />
                            </div>
                            <div className='col-md-3 col-6 mb-5'>
                                <img src={img3} />
                            </div>
                            <div className='col-md-3 col-6 mb-5'>
                                <img src={img4} />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </Fragment>
    )
}

export default Gallery;