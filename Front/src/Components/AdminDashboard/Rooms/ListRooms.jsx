import React, { Fragment, useState,useEffect  } from 'react';
import {Link} from 'react-router-dom'
import styles from '../AdminHome.module.scss';
import axios from 'axios';
import RoomCRUD from './model/RoomAPI';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import img from '../../../Images/5.jpg';



function ListRooms(){
    let [rooms,setRooms]=useState([]);
    const listData=()=>{
        RoomCRUD.getAll()
        .then(res=>{
            //console.log(res.data)
            setRooms(res.data)
        })
        .catch(err=>{console.log(err)});  

    }
    useEffect(()=>{
        listData();
    },[])
    function deleteRoom(roomId){
        console.log(roomId)
        let confirmResult=window.confirm("Are you sure You Want to delete this item");
        if(confirmResult ===true){
            RoomCRUD.delRoom(roomId)
            .then(res=>{
                listData();
            })
            .catch(err=>{console.log(err)})
        }  
        toast.success("Room deleted Successfully")     
 }
   return(
    <Fragment>
        <div className='container mt-5 mb-5'>
               <div className='mb-5'>
                 <Link to='/admin/addRoom' className={styles.add}>Add Room</Link>
               </div>
                <div className={styles.container}>
                    <div className='row'>
                        {rooms.length===0?<div className="spinner-border text-info mt-5" role="status"></div>:
                             <table className={styles.table}>
                             <thead className={styles.head}>
                                 <tr>
                                     <th>Img</th>
                                     <th>Type</th>
                                     <th>Room no</th>
                                     <th>maxPeople</th>
                                     <th>Desc</th>
                                     <th>Price</th>
                                     <th>Actions</th>     
                                 </tr>
                             </thead>
                             <tbody className={styles.body}>
                                 {rooms.map((item,index)=>{
                                     return(
                                         <tr key={item.roomId}>
                                             <td><img src={item.roomImages[0]?.name}/></td>
                                             <td>{item.roomData.type}</td>
                                             <td>{item.roomData.roomNumber}</td>
                                             <td>{item.roomData.maxPeople}</td>
                                             <td>{item.roomData.description}</td>
                                             <td>
                                                 {item.roomData.roomsInHotel[0]?.price}
                                             </td>
                                             <td> 
                                                 <Link to={"/admin/editRoom/" + item.roomData.roomId }className={styles.edit}>
                                                     <i class="fa-solid fa-file-pen"></i>
                                                 </Link>  
                                                 <button onClick={(()=>deleteRoom(item.roomData.roomId))} className={styles.del}>
                                                     <i class="fa-solid fa-trash"></i>
                                                 </button>    
                                             </td>   
                                         </tr>
                                     )
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

export default ListRooms;