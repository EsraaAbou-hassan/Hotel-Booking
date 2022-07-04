import React, { Fragment } from 'react';
//import Header from '../Components/Header/Header';
import SecHeader from '../Components/SecondHeader/SecondHeader';
import List from '../Components/ListHotels/List';
import Footer from '../Components/Footer/Footer';
function ListHotels(){
    return(
        <Fragment>
            <SecHeader/>
            <List/>
            <Footer/>
        </Fragment>
        
    )

}
export default ListHotels;