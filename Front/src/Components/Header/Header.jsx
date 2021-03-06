import React, { Fragment } from 'react';
import {NavLink,Link,useLocation,useH} from 'react-router-dom';
import styles from './Header.module.scss';
import img from '../../Images/59.jpg'


function Header({setStatus,myStatus,logData,upData}){
    let location=useLocation();
    const GoToSignUp=()=>{
        console.log(location)
          //history.push('/register');
    }
    const defaultStatus=()=>{
        setStatus(false);
    }
    return(
        <Fragment>
            <div className={styles.parentContainer}>
                <div className={styles.bg}>
                  <img src={img} className={styles.bgImg}/>
                  <div className={styles.overlay}></div>
                </div>
                <div className='container w-75 mx-auto'>
                    <div className={styles.navBar}>
                        <div className='row'>
                            <div className='col-md-8 col-6  p-3'>
                                <h4>Booking.com</h4>
                            </div>
                            <div className='col-md-4 col-6 d-flex justify-content-end  '>
                                <Link  to='/register' className='btn text-white mt-3'>{myStatus? logData:upData}</Link>
                                <Link to='/' className='btn text-white mt-3' onClick={defaultStatus}>
                                    Log out
                                </Link>    
                            </div>
                        </div>
                        <div className='row' style={{marginTop:'100px',marginBottom:'-30px'}}>
                            <div className='col-md-6 col-12 mx-auto  text-center text-white p-3'>
                                <p className={styles.para}>Smiple - Unique - Friendly.</p>
                            </div>
                        </div>
                        <div className='row'>
                            <div className='col-md-6 col-12 mx-auto  text-center text-white p-3'>
                                <h2 >Make yourself at home</h2>
                                <h2 className='mt-0'>in our <span className={styles.span}>Hotel.</span></h2>
                            </div>
                        </div>
                    </div>
                </div>        
            </div>
        </Fragment>
    )
}
export default Header;