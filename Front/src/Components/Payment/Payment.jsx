import React, { Fragment } from "react";
import styles from '../Register/Form.module.scss';
import  style  from "./Payment.module.scss";
import {Link} from 'react-router-dom';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';



function Payment(){
    const notify = () => toast.success("Book succeed");
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
                                <div className="input-group">
                                   <p><strong>Card password:</strong></p>
                                </div>
                                <div className="input-group mb-4">
                                    <input type="password" className="form-control shadow-sm" placeholder="Card number"/>
                                </div>
                                <div className="mb-5">
                                     <button className="btn shadow-lg" onClick={notify}>Book</button>
                                </div>
                            </div>
                        </div>
                     </div>
                </div>
            </div>
            <div className={style.notify}>
                <ToastContainer position="bottom-left"/>
            </div>
        </Fragment>
    )
}

export default Payment;