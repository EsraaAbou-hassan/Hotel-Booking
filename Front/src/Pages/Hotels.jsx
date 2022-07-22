import React, { Fragment } from 'react';
//import Header from '../Components/Header/Header';
import SecHeader from '../Components/SecondHeader/SecondHeader';
import List from '../Components/ListHotels/List';
import Footer from '../Components/Footer/Footer';
function ListHotels({myStatus,logData,upData}){
    return(
        <Fragment>
            <SecHeader myStatus={myStatus} logData={logData} upData={upData}/>
            <List/>
            <Footer/>
        </Fragment>
        
    )

}
export default ListHotels;