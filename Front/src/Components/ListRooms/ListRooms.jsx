import React, { Fragment } from 'react';
import styles from './ListRooms.module.scss';
import img1 from '../../Images/17.webp';
import img2 from '../../Images/18.jpg';
import img3 from '../../Images/19.jpg';
import img4 from '../../Images/48.jpg';
import {Link,useParams} from 'react-router-dom';
import { useState } from 'react';
import { useEffect } from 'react';
import axios from 'axios';


function ListRooms(){
    let id=useParams().id;
    localStorage.setItem("hotelId",JSON.stringify(id));
    let url='https://localhost:7298/api/BookingRoomToUsers/ChooseRoom';
    let [roomData,setRooms]=useState([]);
    useEffect(()=>{
        axios.post(url+'?'+"id="+id)
        .then(res=>{
            console.log(res.data);
            setRooms(res.data);
            console.log("room data",roomData)
        })
        .catch(err=>{console.log(err)})
       
    },[])
    
    return(
        <Fragment>
            <div className='container mt-5 p-3' style={{marginBottom:'450px'}}>
                <div className={styles.container}>
                    <div className='row d-flex justify-content-around' >
                        {roomData.length===0?<div className="spinner-border text-info mt-5" role="status"></div>:
                           
                           <div className='d-flex justify-content-around'>
                              {roomData.map((item,index)=>{
                            return(
                               <div className='col-md-3 col-9 mb-3 ' key={item.roomData.roomId}>
                                   <div className="card shadow-lg" style={{overflow: 'hidden'}}>
                                       <img src={img1} />
                                       <div className="card-body">
                                           <h5 className="card-title">{item.roomData.description}</h5>
                                           <p className="card-text"><strong>Max People: </strong>{item.roomData.maxPeople}</p>
                                           <p className="card-text">
                                           <p>{item.service.map((ser,i)=>{
                                             return(
                                                <div key={i}>
                                                    <span><strong>Service: </strong>{ser.name}</span>

                                                </div>
                                             )

                                           })}</p>
                                           {item.roomData.roomsInHotel?.map(item=>{
                                                  if(item.hotelId==id){

                                                    return(
                                                        <div>
                                                        
                                                         <span key={item.roomId}><strong>price: </strong>${item.price}</span>
                                                             <div className='mt-4' style={{height:'40px'}}>
                                                                 <Link to={`/payment/${item.roomId}`} className={styles.btnRes}>Reserve</Link>
                                                             </div>
                                                        </div>
                                                       )
                                                }
                                                
                                           })} 
                                           </p>
                                           
                                             
                                       </div>
                                   </div>   
                               </div>
                            )
                            
                       })}
                               

                           </div>
                        
                        
                        }
                    </div>
                    
                    
                </div>
            </div>
        </Fragment>
    )
}
export default ListRooms;