import React, { Fragment } from 'react';
import styles from './Details.module.scss';

function Details(){
    return(
        <Fragment>
            <div className='container mt-5 mb-5'>
                <div className={styles.container}>
                    <div className='row'>
                        <table className={styles.table}>
                            <thead className={styles.head}>
                                <tr>
                                    <th>Room type</th>
                                    <th>Services</th>
                                    <th>Price</th>
                                    <th>Amount</th>
                                    <th>&nbsp;</th>
                                </tr>
                            </thead>
                            <tbody className={styles.body}>
                                <tr>
                                    <td>Single Room</td>
                                    <td>Breakfast, WIFI, TV, Air Condition, etc...</td>
                                    <td>$150</td>
                                    <td>
                                        <select className='form-select'>
                                            <option>0</option>
                                            <option>1 ($150)</option>
                                            <option>2 ($300)</option>
                                            <option>3 ($450)</option>
                                            <option>4 ($600)</option>
                                        </select>
                                    </td>
                                    <td>
                                        <button className={styles.btn}>Details</button>
                                    </td>
                                </tr>
                                <tr>
                                    <td>double Room</td>
                                    <td>Breakfast, WIFI, TV, Air Condition, etc...</td>
                                    <td>$300</td>
                                    <td>
                                        <select className='form-select'>
                                            <option>0</option>
                                            <option>1 ($300)</option>
                                            <option>2 ($600)</option>
                                            <option>3 ($900)</option>
                                            <option>4 ($1200)</option>
                                        </select>
                                    </td>
                                    <td>
                                        <button className={styles.btn}>Details</button>
                                    </td>
                                </tr>
                                <tr>
                                    <td>suit</td>
                                    <td>Breakfast, WIFI, TV, Air Condition, etc...</td>
                                    <td>$500</td>
                                    <td>
                                        <select className='form-select'>
                                            <option>0</option>
                                            <option>1 ($500)</option>
                                            <option>2 ($1000)</option>
                                            <option>3 ($1500)</option>
                                            <option>4 ($2000)</option>
                                        </select>
                                    </td>
                                    <td>
                                        <button className={styles.btn}>Details</button>
                                    </td>
                                </tr>

                            </tbody>
                        </table>
                    </div>
                </div>
            </div>

        </Fragment>
    )
}

export default Details;