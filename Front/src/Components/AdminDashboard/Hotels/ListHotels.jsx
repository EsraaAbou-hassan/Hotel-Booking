import React, { Fragment } from 'react';

import {Link} from 'react-router-dom'
import styles from '../AdminHome.module.scss';
import img from '../../../Images/5.jpg'


function ListHotels(){
   return(
    <Fragment>
        <div className='container mt-5 mb-5'>
               <div className='mb-5'>
                 <Link to='/admin/add' className={styles.add}>Add Hotel</Link>
               </div>
                <div className={styles.container}>
                    <div className='row'>
                        <table className={styles.table}>
                        <thead className={styles.head}>
                            <tr>
                                <th>Img</th>
                                <th>Name</th>
                                <th>City</th>
                                <th>Country</th>
                                <th>Desc</th>
                                <th>Min Price</th>
                                <th>Actions</th>     
                            </tr>
                        </thead>
                        <tbody className={styles.body}>
                            <tr>
                                <td><img src={img}/></td>
                                <td >Hotel1</td>
                                <td>Cairo</td>
                                <td>Egypt</td>
                                <td>description</td>
                                <td>150$</td>
                                <td> 
                                    <Link to='/admin/edit/100' className={styles.edit}>
                                       <i class="fa-solid fa-file-pen"></i>
                                    </Link>  
                                    <button className={styles.del}>
                                        <i class="fa-solid fa-trash"></i>
                                    </button>    
                                </td>   
                            </tr>
                            <tr>
                                <td><img src={img}/></td>
                                <td >Hotel1</td>
                                <td>Cairo</td>
                                <td>Egypt</td>
                                <td>description</td>
                                <td>150$</td>
                                <td>    
                                    <Link to='/admin/edit/200' className={styles.edit}>
                                       <i class="fa-solid fa-file-pen"></i>
                                    </Link>  
                                    <button className={styles.del}>
                                        <i class="fa-solid fa-trash"></i>
                                    </button>     
                                </td>    
                            </tr>
                            <tr>
                                <td><img src={img}/></td>
                                <td >Hotel1</td>
                                <td>Cairo</td>
                                <td>Egypt</td>
                                <td>description</td>
                                <td>150$</td>
                                <td>    
                                    <Link to='/admin/edit/300' className={styles.edit}>
                                       <i class="fa-solid fa-file-pen"></i>
                                    </Link>  
                                    <button className={styles.del}>
                                        <i class="fa-solid fa-trash"></i>
                                    </button>     
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

export default ListHotels;