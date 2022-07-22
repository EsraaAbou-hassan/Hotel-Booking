import React, { Fragment, useEffect,useState } from 'react';

import {Link} from 'react-router-dom'
import styles from '../AdminHome.module.scss';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

import img from '../../../Images/5.jpg';


function ListHotels(){
    let [hotelsData,sethotelsData]=useState([]);
//=========================pick data from Api =============================
let fetchData=()=>{
    fetch('https://localhost:7298/api/Hotels')
    .then(data => data.json())
    .then((res)=>{
     sethotelsData(res);
    });
}
useEffect(()=>{
    fetchData();  
},[]);
//==============================================================================

//===============================delete hotel======================================
const deleteHotel=(hotelId)=>{
    let confirmResult=window.confirm("Are you sure You Want to delete this item");
    if(confirmResult ==true){
        fetch( `https://localhost:7298/api/Hotels/${hotelId}`, { method: 'DELETE' })
        .then((massage)=>{
            
            fetchData();

           
        })
    } 
    toast.success("Hotel deleted Successfully")   
}
   return(
    <Fragment>
        <div className='container mt-5 mb-5'>
               <div className='mb-5'>
                 <Link to='/admin/addHotel' className={styles.add}>Add Hotel</Link>
               </div>
                <div className={styles.container}>
                    <div className='row'>
                        {hotelsData.length===0?<div className="spinner-border text-info mt-5" role="status"></div>:
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
   
                             {hotelsData.map((hotel)=>{
                              return (
                              <tr>
                                       <td><img src={hotel.hotelImages[0].name}/></td>
                                       <td >{hotel.hotelData.name}</td>
                                       <td>{hotel.hotelData.city}</td>
                                       <td>{hotel.hotelData.country}</td>
                                       <td>{hotel.hotelData.description}</td>
                                       <td>{hotel.hotelData.cheapestPrice }</td>
                                       <td> 
                                           <Link to={"/admin/editHotel/" + hotel.hotelData.hotelId }className={styles.edit}>
                                           <i class="fa-solid fa-file-pen"></i>
                                           </Link>  
                                           <button onClick={(()=>deleteHotel(hotel.hotelData.hotelId))} className={styles.del}>
                                               <i class="fa-solid fa-trash"></i>
                                           </button>    
                                       </td>   
                                   </tr> )
                                 })}
                             </tbody>
                           </table>
                        }
                    </div>
                </div>
            </div>

    </Fragment>
   )
}

export default ListHotels;