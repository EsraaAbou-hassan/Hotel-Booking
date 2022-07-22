import React, { Fragment } from 'react';
import SecHeader from '../Components/SecondHeader/SecondHeader';
import ListRooms from '../Components/ListRooms/ListRooms';
import Footer from '../Components/Footer/Footer';
function Rooms({myStatus,logData,upData}){
    return(
         <Fragment>
            <SecHeader myStatus={myStatus} logData={logData} upData={upData}/>
            <ListRooms/>
            <Footer/>
         </Fragment>
    )
}

export default Rooms;