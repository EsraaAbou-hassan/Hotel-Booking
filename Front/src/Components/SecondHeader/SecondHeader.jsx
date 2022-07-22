import React, { Fragment } from "react";
import { Link } from "react-router-dom";
import styles from './SecondHeader.module.scss';
function SecHeader({myStatus,logData,upData}){
   return(
    <Fragment>
        <div className={styles.container}>
            <div className={styles.header}>
                <div className="container">
                    <div className="row">
                    <nav className="navbar navbar-expand-lg bg-light">
                        <div className="container-fluid">
                            <a className="navbar-brand" href="#">Booking.com</a>
                            <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                              <i class="fa-solid fa-bars"></i>
                            </button>
                            <div className="collapse navbar-collapse" id="navbarSupportedContent">
                            <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                                <li className="nav-item">
                                  <Link className="nav-link active" aria-current="page" to='/home'>Home</Link>
                                </li>
                            </ul>
                            <form>
                                <button className='btn' style={{color:'#fff'}}>{myStatus? logData:upData}</button>
                                <button className='btn'> {myStatus?"Log out":"Log in"}</button> 
                            </form>
                            </div>
                        </div>
                    </nav>
                </div>
            </div>
          </div>
        </div>
    </Fragment>
   )
}

export default SecHeader;