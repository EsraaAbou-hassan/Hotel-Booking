import React, { Fragment } from 'react';
import styles from '../../Register/Form.module.scss';
import {Link,useParams,useNavigate} from 'react-router-dom';
import {useForm} from 'react-hook-form';
import { useEffect } from 'react';
import ServiceCRUD from './model/serviceAPI';
import Swal from 'sweetalert2';

function UpdateService(){
    const {register,handleSubmit,formState:{errors},reset,setValue} = useForm({
        mode: "onTouched"
    });
    
    let param=useParams().id;
    useEffect(()=>{
        fetch(`https://localhost:7298/api/Services/${param}`)
        .then(data => data.json())
        .then((res)=>{
        const fields = ['name'];
        fields.forEach(field => setValue(field, res[field]));
    })

    })
    
    const onSuccess=()=> {  
        Swal.fire({   
          text: 'Service Updated Successfully',  
          icon: 'success',   
          confirmButtonColor: '#478e9a',  
          confirmButtonText: 'OK'  
        });  
      } 
    let navigate=useNavigate();
    const onSubmit=async(data)=>{  
        ServiceCRUD.UpdateService(param,{
            name:data.name,
        })
        .then(res=>{
            console.log(res);
            onSuccess();
            navigate('/admin/services')
        })
        .catch(err=>{console.log(err)})
        reset();    
    }
  return(
    <Fragment>
        <div className={styles.container} style={{height:'100%',backgroundImage:'none'}}>
                <div className="container" >
                     <div className={styles.form} style={{backgroundColor:'#F2F5FC',marginTop:'150px'}} >
                        <div className="row" >
                            <form onSubmit={handleSubmit(onSubmit)}>
                                <div className="col-12">
                                    <div className="input-group mb-4 d-flex justify-content-center">
                                        <h3>Update Service</h3>
                                    </div>
                                    <div class="mb-3">
                                        <input type="text" class="form-control" name="name" placeholder='Serive'
                                          {...register("name",{required:"Serive is required"})}
                                         
                                        />
                                    </div>
                                    <p>{errors.name?.type==='required'&&
                                     <div className={styles.validate}>
                                        <span>Serive is required</span>
                                     </div>}
                                    </p>
                                    <div className="mb-3 mt-3">
                                        <button  className="btn shadow-lg">Update</button>
                                    </div>
                                    <div className="mt-3">
                                        <Link to='/admin/services' className={styles.link}>Back to List</Link>
                                    </div>
                                </div>
                            </form>
                        </div>
                     </div>
                </div>
            </div>
    </Fragment>
  )
}

export default UpdateService;