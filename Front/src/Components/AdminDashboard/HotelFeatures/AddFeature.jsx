import React, { Fragment } from 'react';
import styles from '../../Register/Form.module.scss';
import {Link,useNavigate} from 'react-router-dom';
import {useForm} from 'react-hook-form';
import FeatureCRUD from './model/FeatureAPI';
import Swal from 'sweetalert2'

function AddFeature(){
    const {register,handleSubmit,formState:{errors},reset} = useForm({
        mode: "onTouched"
    });
    const onSuccess=()=> {  
        Swal.fire({   
          text: 'Feature Added Successfully',  
          icon: 'success',   
          confirmButtonColor: '#478e9a',  
          confirmButtonText: 'OK'  
        });  
      } 
    let navigate=useNavigate(); 
    const onSubmit=async(data)=>{ 
        FeatureCRUD.addFeature({
            name:data.name
        })
        .then(res=>{
            console.log(res.data)
            onSuccess();
            console.log("Add Successfully");
            navigate('/admin/features')
            reset();    
        })  
        .catch(err=>{console.log(err)})
      
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
                                        <h3>Add Feature</h3>
                                    </div>
                                    <div class="mb-3">
                                        <input type="text" class="form-control" name="name" placeholder='Feauture'
                                         {...register("name",{required:"Feauture is required"})}
                                        />
                                    </div>
                                    <p>{errors.name?.type==='required'&&
                                     <div className={styles.validate}>
                                        <span>Feature is required</span>
                                     </div>}
                                    </p>
                                    <div className="mb-3 mt-3">
                                        <button  className="btn shadow-lg">Add</button>
                                    </div>
                                    <div className="mt-3">
                                        <Link to='/admin/features' className={styles.link}>Back to List</Link>
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

export default AddFeature;