import React, { Fragment } from 'react';
import styles from './ReserveDetails.module.scss';


function ReserveDetails(){
   return(
    <Fragment>
        <div className={styles.container}>
            <div className='container mt-5 '>
                <div className='row'>
                    <div className='alert alert-primary'>
                        <p><strong>Room type:</strong> Single</p>
                        <p><strong>Service:</strong> WIFI, Air Condition,....</p>
                        <p><strong>Price:</strong> $150</p>
                        <p><strong>Amount:</strong> 2 Rooms</p>
                        <p><strong>Total:</strong> $300</p>
                        <button className='btn btn-primary'>Reserve</button>
                    </div>
                </div>
            </div>
        </div>
    </Fragment>
   )
}
export default ReserveDetails;