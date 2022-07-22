import React, { Fragment } from 'react';
import styles from './List.module.scss';
import img from '../../Images/34.jpg';
import Filter from '../Filter/Filter';
import {Link} from 'react-router-dom';
import { useState } from 'react';
import { useEffect } from 'react';


function List(){
    
const [listHotels,setHotels]=useState([]);
    
useEffect(()=>{
    let data=JSON.parse(window.localStorage.getItem("data"));
    if(data){
        setHotels(data);
    }
    console.log(data);
    console.log(listHotels)
   
   
},[])

    return(
        <Fragment>
           <div className='container mt-5'>
            <div className={styles.container}>
               <div className='row'>
                
                <div className='col-md-9 col-12 mx-auto'>
                    {listHotels.map((item,index)=>{
                                return(
                                    <div className={styles.block} key={index}>
                                      <div className='row'>
                                        <div className='col-md-3 col-4'>
                                            <img src={item.hotelImages[0].name}/>
                                        </div>
                                        <div className='col-md-6 col-5' >
                                            <h2 style={{color:'#327885'}}>{item.hotelData.name}</h2>
                                            <p><strong>City: </strong>{item.hotelData.city}</p>
                                            <p><strong>Country: </strong>{item.hotelData.country}</p>
                                            <p><strong>Des: </strong>{item.hotelData.description}</p>
                                            <p><strong>Min Price: </strong>${item.hotelData.cheapestPrice}</p>
                                        </div>
                                        <div className='col-3 d-flex  flex-column justify-content-end align-items-end'>
                                            <Link to={`/rooms/${item.hotelData.hotelId}`} className={styles.btnAval}>availability</Link>
                                        </div>
                                    </div>
                                </div>
                                    
                                )
                            })}   
                 </div>
               </div>
            </div>
            <pre>

            

                   





            </pre>
           </div>
        </Fragment>
    )
}

export default List;