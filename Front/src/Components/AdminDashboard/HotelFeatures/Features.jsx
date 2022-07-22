import React, { Fragment } from 'react';
import { useEffect } from 'react';
import { useState } from 'react';
import {Link} from 'react-router-dom'
import styles from '../AdminHome.module.scss';
import FeatureCRUD from './model/FeatureAPI';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';



function Features(){
    let [feature,setFeature]=useState([]);
    const listData=()=>{
        FeatureCRUD.getAll()
        .then(res=>{
            console.log(res.data);
            setFeature(res.data)
        })
        .catch(res=>{console.log(res)})
    }
    useEffect(()=>{
        listData();
    },[])
    const delFeature=(id)=>{
        let confirmMsg=window.confirm('Are you sure You Want to delete this item');
        if(confirmMsg===true){
            FeatureCRUD.deleteFeature(id)
            .then(res=>{
                console.log("deleted succussfully")
                listData();
                toast.success("Feature deleted Successfully")
            })
            .catch(err=>{console.log(err)})      
        }
    }
   return(
    <Fragment>
        <div className='container mt-5 mb-5'>
               <div className='mb-5'>
                 <Link to='/admin/addFeature' className={styles.add}>Add Feature</Link>
               </div>
                <div className={styles.container}>
                    <div className='row w-md-75 w-sm-100'>
                       {feature.length===0?<div className="spinner-border text-info mt-5" role="status"></div>:
                           <table className={styles.table}>
                           <thead className={styles.head}>
                               <tr>
                                   <th>#</th>
                                   <th>Feature</th>
                                   <th>Actions</th>     
                               </tr>
                           </thead>
                           <tbody className={styles.body}>
                               {feature.map((item,index)=>{
                                   return(
                                       <tr key={index}>
                                           <td>{index+1}</td>
                                           <td>{item.name}</td>
                                           <td> 
                                           <Link to={"/admin/editFeature/" + item.featureId }className={styles.edit}>
                                               <i class="fa-solid fa-file-pen"></i>
                                           </Link>  
                                           <button onClick={()=>delFeature(item.featureId)} className={styles.del}>
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

export default Features;