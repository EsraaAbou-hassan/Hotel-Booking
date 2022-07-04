import React, { Fragment } from 'react';
import SecHeader from '../Components/SecondHeader/SecondHeader';
import ListRooms from '../Components/ListRooms/ListRooms';
function Rooms(){
    return(
         <Fragment>
            <SecHeader/>
            <ListRooms/>
         </Fragment>
    )
}

export default Rooms;