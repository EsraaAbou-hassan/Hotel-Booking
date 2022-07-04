import React, { Fragment } from 'react';
import styles from './Login.module.scss';
import img from '../../Images/11.jpg';

function Login(){
    return(
        <Fragment>
            <div className={styles.container}>
                <div className='container '>
                    <div className={styles.form}>
                        <div className='row '>
                            <div className='col-5 '>
                                <img src={img}/>
                            </div>
                            <div className='col-7  d-flex justify-content-center '>
                                <div className={styles.input}>
                                    <div className='mb-3'>
                                        <h3>LOGIN</h3>
                                    </div>
                                    <div className='input-group mb-3 '>
                                        <input type="email" placeholder='Email' className="form-control shadow-sm"/>
                                    </div>
                                    <div className='input-group mb-3 mt-3'>
                                        <input type="text" placeholder='Password' className="form-control shadow-sm"/>
                                    </div>
                                    <div className='input-group d-flex justify-content-center mt-3'>
                                        <button className='btn btn-primary shadow-lg'>Log in</button>
                                    </div>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </Fragment>
    )
}

export default Login;