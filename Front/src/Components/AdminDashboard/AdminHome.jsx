import React, { Fragment } from 'react';
import { Link ,Routes,Route} from 'react-router-dom';
import styles from './AdminHome.module.scss';
import ListHotels from './Hotels/ListHotels';
import AddHotel from './Hotels/AddHotel';
import UpdateHotel from './Hotels/UpdateHotel';


function AdminHome(){  
 return(
    <Fragment>
        <div className={styles.container}>
            <nav className="navbar navbar-expand-lg bg-light shadow-lg p-4">
                <div className="container-fluid">
                    <a className="navbar-brand" href="#">Admin Dashboard</a>
                    <button className="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                       <i className="fa-solid fa-bars"></i>
                    </button>
                    <div className="collapse navbar-collapse" id="navbarSupportedContent">
                        <ul className="navbar-nav me-auto mb-2 mb-lg-0">
                            <li className="nav-item">
                               <Link to='/admin/hotels' className='nav-link active d-md-none d-sm-block' style={{textDecoration:'none'}}>Hotels</Link>
                            </li>  
                            <li className="nav-item">
                               <a className="nav-link  d-md-none d-sm-block" aria-current="page" href="#">Rooms</a>
                            </li>  
                            <li className="nav-item">
                               <a className="nav-link  d-md-none d-sm-block" aria-current="page" href="#">Users</a>
                            </li>   
                        </ul>
                    </div>
                </div>
            </nav>
            <div className={styles.content}>
               <div className='container-fluid'>
                    <div className='row'>
                        <div className='col-md-3 col-12 p-0 d-lg-block d-none'>
                           <div className={styles.sideBar}>
                               <div className={styles.hotel}>
                                   <i className="fa-solid fa-archway"></i>
                                   <Link to='/admin/hotels' className={styles.link}>Hotels</Link>
                               </div>
                               <div className={styles.room}>
                                   <i className="fa-solid fa-bed"></i>
                                   <Link to='/admin/rooms' className={styles.link}>Rooms</Link>
                               </div>
                               <div className={styles.user}>
                                   <i className="fa-solid fa-users"></i>
                                   <Link to='/admin/users' className={styles.link}>Users</Link>
                               </div>
                           </div>
                        </div>
                        
                            <div className='col-lg-9 col-12  p-0'>
                                <div className={styles.content}>
                                      <Routes>
                                         <Route path='/hotels'  element={<ListHotels/>}/>
                                         <Route path='/add'  element={<AddHotel/>}/>
                                         <Route path='/edit/:id'  element={<UpdateHotel/>}/>
                                     </Routes>
                                </div>
                            </div>   
                    </div>
               </div>
            </div>
        </div>
    </Fragment>
 )
}

export default AdminHome