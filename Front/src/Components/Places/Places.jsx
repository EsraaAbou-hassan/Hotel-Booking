import React, { Fragment } from 'react';
import OwlCarousel from 'react-owl-carousel';
import 'owl.carousel/dist/assets/owl.carousel.css';
import 'owl.carousel/dist/assets/owl.theme.default.css';
import styles  from './Places.module.scss';
import img from '../../Images/4.jpg';


function Places(){
    const setting={    
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
            }
            }
        }
    return(
        <Fragment>
            <div className='container'>
                <div className={styles.container}>
                    <div className='row'>
                        <div className='mt-5 col-12 text-center'>
                        <h2 className={styles.h2}>Place to visit</h2>
                        </div>
                    </div>
                    <div className='row w-md-75 w-sm-100 mx-auto mt-4'>
                    <OwlCarousel className='owl-theme' loop margin={10} nav {...setting}>
                        <div className={styles.items}>
                            <img src={img} className={styles.img}/>
                            <div className={styles.overlay}>
                                <h4>Cairo</h4>
                            </div>
                        </div>
                        <div className={styles.items}>
                            <img src={img} className={styles.img}/>
                            <div className={styles.overlay}>
                                <h4>Alex</h4>
                            </div>
                        </div>
                        <div className={styles.items}>
                            <img src={img} className={styles.img}/>
                            <div className={styles.overlay}>
                                <h4>Luxor</h4>
                            </div>
                        </div>
                        <div className={styles.items}>
                            <img src={img} className={styles.img}/>
                            <div className={styles.overlay}>
                                <h4>Dubi</h4>
                            </div>
                        </div>
                        <div className={styles.items}>
                            <img src={img} className={styles.img}/>
                            <div className={styles.overlay}>
                                <h4>Italy</h4>
                            </div>
                        </div>
                        <div className={styles.items}>
                            <img src={img} className={styles.img}/>
                            <div className={styles.overlay}>
                                <h4>Paris</h4>
                            </div>
                        </div>
                    </OwlCarousel>
                    </div>
                </div>
          
                <div className={styles.divider}></div>
  
            </div>
        </Fragment>
    )
}
export default Places;