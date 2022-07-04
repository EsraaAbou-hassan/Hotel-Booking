import React ,{Fragment}from 'react';
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faFacebookF, faInstagram } from "@fortawesome/free-brands-svg-icons";
import styles from "./Footer.module.scss";

const Footer = () => {
    return (
        <Fragment>
            
          <div className={styles.container}>
            <div className='container'>
            <div className="container">
              <div className="row">
                <div className={styles.ready}>
                    <div>
                        <p><strong>Ready for your next trip ?</strong></p>
                        <p>let's get started</p>
                    </div>
                    <button>Contact Us</button>
                </div>
              </div>  
           </div>
            <div className={styles.others}>
                {/* <img src={logo} alt="" /> */}
               <div className="container w-100">
                  <div className="row">
                    <div className="col-md-12">
                        <div className={styles.links}>
                            <div className="row">
                                <div className="col-md-3 col-6">
                                    <div className={styles.features}>
                                       <p><strong>Countries</strong></p>
                                        <p>Regions</p>
                                        <p>Districts</p>
                                        <p>Hotels</p>
                                    </div>
                                </div>
                                <div className="col-md-3 col-6">
                                    <div className={styles.features}>
                                        <p><strong>places</strong></p>
                                        <p>Discover</p>
                                        <p>Reviews</p>
                                        <p>Travel Communities</p>
                                    </div>
                                </div>
                                <div className="col-md-3 col-6">
                                    <div className={styles.features}>
                                        <p><strong>Company</strong></p>
                                        <p>About us</p>
                                        <p>Careers</p>
                                        <p>Contact us</p>
                                    </div>
                                </div>
                                <div className="col-md-3 col-6">
                                    <div className={styles.features}>
                                        <p><strong>Coronavirus (COVID-19)</strong></p>
                                        <p>Customer Service help</p>
                                        <p>Sustainability</p>
                                        <p>Safety resource centre</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="col-md-6 col-12 mx-auto">
                        <div className={styles.followUs}>   
                            <div className="row mt-4 ">
                                <div className=''>
                                    <div className={styles.features}>
                                        <input type="text" placeholder="Email Address" />
                                        <button>Subscribe</button>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                  </div>
               </div>
            </div>

            <div className={styles.divider}></div>
            <div className={styles.copyRights}>
                <div className="row">
                  <div className="col-12 d-flex justify-content-center">
                    <p><strong>Copy Right Reserved © 2021 booking.com</strong></p>
                  </div>
                </div>
            </div>
            </div>  
          </div>
  
        </Fragment>
       
    );
}

export default Footer;