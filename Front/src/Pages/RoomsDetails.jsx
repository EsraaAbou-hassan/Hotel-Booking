import { Fragment } from 'react';
import SecHeader from '../Components/SecondHeader/SecondHeader';
import Details from '../Components/RoomsDetails/Details';
import Footer from '../Components/Footer/Footer';

function RoomsDetails(){
    return(
        <Fragment>
            <SecHeader/>
            <Details/>
        </Fragment>
    )
}

export default RoomsDetails;