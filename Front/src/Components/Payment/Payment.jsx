import React, { Fragment } from "react";
import styles from '../Register/Register.module.scss';



function Payment(){
    return(
        <Fragment>
            <div className={styles.container}>
                <div className="container">
                     <div className={styles.form}>
                        <div className="row">
                            <div className="col-12">
                                <div className="input-group mb-4 d-flex justify-content-center">
                                    <h3>Payment</h3>
                                </div>
                                <div className="input-group">
                                   <p><strong>Card type:</strong></p>
                                </div>
                                <div className="input-group mb-4">
                                   <select class="form-select" aria-label="Default select example">
                                        <option selected>--Select--</option>
                                        <option value="1">Master Card</option>
                                        <option value="2">Visa</option>
                                        <option value="3">Credit Card</option>
                                    </select>
                                </div>
                                <div className="input-group">
                                   <p><strong>Card number:</strong></p>
                                </div>
                                <div className="input-group mb-4">
                                    <input type="text" className="form-control shadow-sm" placeholder="Card number"/>
                                </div>
                                <div className="mb-5">
                                     <button className="btn shadow-lg">Book</button>
                                </div>
                            </div>
                        </div>
                     </div>
                </div>
            </div>
        </Fragment>
    )
}

export default Payment;