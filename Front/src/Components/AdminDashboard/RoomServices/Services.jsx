import React, { Fragment ,useEffect,useState} from 'react';
import {Link} from 'react-router-dom'
import styles from '../AdminHome.module.scss';
import ServiceCRUD from './model/serviceAPI';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';


function Services(){
    

    let [service,serService]=useState([]);
    const listData=()=>{
        ServiceCRUD.getAll()
        .then(res=>{
            console.log(res.data);
            serService(res.data)
        })
        .catch(res=>{console.log(res)})
    }
    useEffect(()=>{
        listData();
    },[])
    const delService=(id)=>{
        let confirmMsg=window.confirm('Are you sure You Want to delete this item');
        if(confirmMsg===true){
            ServiceCRUD.deleteService(id)
            .then(res=>{
                console.log("deleted succussfully")
                listData();
                toast.success("Service deleted Successfully")
            })
            .catch(err=>{console.log(err)})     
        }
    }
   return(
    <Fragment>
        <div className='container mt-5 mb-5'>
               <div className='mb-5'>
                 <Link to='/admin/addService' className={styles.add}>Add Service</Link>
               </div>
                <div className={styles.container}>
                    <div className='row w-md-75 w-sm-100'>
                    {service.length===0?<div className="spinner-border text-info mt-5" role="status"></div>:
                           <table className={styles.table}>
                           <thead className={styles.head}>
                               <tr>
                                   <th>#</th>
                                   <th>Service</th>
                                   <th>Actions</th>     
                               </tr>
                           </thead>
                           <tbody className={styles.body}>
                               {service.map((item,index)=>{
                                   return(
                                       <tr key={index}>
                                           <td>{index+1}</td>
                                           <td>{item.name}</td>
                                           <td> 
                                           <Link to={"/admin/editService/" + item.serviceId }className={styles.edit}>
                                               <i class="fa-solid fa-file-pen"></i>
                                           </Link>  
                                           <button onClick={()=>delService(item.serviceId)} className={styles.del}>
                                               <i class="fa-solid fa-trash"></i>
                                           </button>  
                                           <ToastContainer position="top-right"/>  
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

export default Services;