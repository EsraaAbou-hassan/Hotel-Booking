import React, { Fragment } from "react";
import ReserveDetails from "../Components/ReserveDetails/ReserveDetails";
import SecHeader from "../Components/SecondHeader/SecondHeader";

function Reserve(){
    return(
        <Fragment>
            <SecHeader/>
            <ReserveDetails/>
        </Fragment>
    )
}


export default Reserve;