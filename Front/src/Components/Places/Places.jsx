import React, { Fragment,useEffect,useState  } from 'react';
import OwlCarousel from 'react-owl-carousel';
import 'owl.carousel/dist/assets/owl.carousel.css';
import 'owl.carousel/dist/assets/owl.theme.default.css';
import styles  from './Places.module.scss';
import img from '../../Images/8.jpg';
import axios from 'axios';

function Places(){
    // prep variable for carry top rated hotel
    let [topRatedHotels,settopRatedHotels]=useState([])

    // catch top rated hotels
    let topURL='https://localhost:7298/api/Hotels/TopRating';
    useEffect(()=>{
       // axios.get(topURL)
       axios.get(topURL)

        .then(res=>{
            
            console.log(res.data)
            if(res.data.length!=0){
                settopRatedHotels(res.data);

            }
        })
        .catch(err=>{
            console.log(err)
        })
        
    })

    const setting={    
        // autoplay:true,
        autoplay:true,
        autoplayTimeout:2000,
        responsive:{
            0:{
                items:1
            },
            600:{
                items:2
            },
            1000:{
                items:4
            },
           
            }
        }
        console.log(topRatedHotels);

    return(
        <Fragment>
            <div className='container'>
                <div className={styles.container}>
                    <div className='row'>
                        <div className='mt-5 col-12 text-center'>
                        <h2 className={styles.h2}>Top Rated Rentals </h2>
                        </div>
                    </div>
                    <div className='row w-md-75 w-sm-100 mx-auto mt-4'>
                    <OwlCarousel className='owl-theme' loop margin={10} nav {...setting}>
                        
                    {

                        topRatedHotels.map((TopRatedhotel,i)=>{
                            return(
                            <div key={i} className={styles.items}>
                                
                                <div className="card shadow-sm" >
                                <img src={TopRatedhotel.hotelImages[0].name} className="card-img-top" alt="hotel-name" />
                                    <div class="card-body">
                                        <h5 className="card-title">{TopRatedhotel.hotelData.name}</h5>
                                        <div className="starts w-50 my-3 d-flex justify-content-between">
                                            <i class="fa-solid fa-star text-warning"></i>
                                            <i class="fa-solid fa-star text-warning"></i>
                                            <i class="fa-solid fa-star text-warning"></i>
                                            <i class="fa-solid fa-star text-warning"></i>
                                            <i class="fa-solid fa-star text-warning"></i>
                                        </div>
                                        <p className="card-text">
                                            <i style={{"color":'#327885'}} class="fa-solid fa-city me-3"></i>
                                            {TopRatedhotel.hotelData.city}</p>
                                        <p className="card-text">
                                            <i style={{"color":'#327885'}} class="fa-solid fa-globe me-3"></i>
                                                {TopRatedhotel.hotelData.country}
                                        </p>
                                        <p>
                                          <i className="fa-solid fa-bell-concierge me-3" style={{"color":'#327885',fontSize:'20px'}}></i>
                                          <span >{TopRatedhotel.feature.map((item,i)=>{
                                            return(
                                                <span key={i}>{item.name}, </span>
                                            )
                                          })}</span>

                                        </p>    
                                    </div>
                                   <div className="card-footer">
                                    <div className="d-flex  justify-content-between">
                                        <div className="description">
                                        <p className="lead mt-2">{TopRatedhotel.hotelData.description}</p>
                                        </div>
                                        <div className="book-btn d-flex align-items-center">
                                        <div className="data">
                                        <strong className="mb-3  text-center" style={{marginTop:'-10px'}}>{TopRatedhotel.hotelData.cheapestPrice
                                        } $</strong>
                                        {/* <a href="#" className="btn btn-primary custom-btn">Book now</a> */}
                                        </div>
                                        
         
                                        </div>
         
                                    </div>
                                   </div>
                                    </div>
                                    {/* <img src={img} className={styles.img}/>
                                    <div className={styles.overlay}>
                                        <h4>Cairo</h4>
                                    </div> */}
                                </div>
                                )
                        }
                            )
                         
                           
                    }
 
                    </OwlCarousel>
                    </div>
                </div>
          
                <div className={styles.divider}></div>
  
            </div>
        </Fragment>
    )
}
export default Places;