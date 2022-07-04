import { Fragment } from "react";
import { Routes, Route } from "react-router-dom";

import Home from './Pages/Home';
import Hotels from './Pages/Hotels';
import Rooms from './Pages/Rooms';
import RoomsDetails from "./Pages/RoomsDetails";
import Reserve from "./Pages/Reserve";
import LoginScreen from "./Pages/Login";
import RegisterScreen from "./Pages/Register";
import PaymentScreen from "./Pages/Payment";




function App() {
  return (
   <Fragment>
     <Routes>
        <Route path='/' exact element={<Home/>}/>
        <Route path='/hotels' element={<Hotels/>}/>
        <Route path='/rooms' element={<Rooms/>}/>
        <Route path='/roomsdetails' element={<RoomsDetails/>}/>
        <Route path='/0' element={<Reserve/>}/>
        <Route path='/login'  element={<LoginScreen/>}/>
        <Route path='/register' element={<RegisterScreen/>}/>
        <Route path='/payment' element={<PaymentScreen/>}/>
     </Routes>
   </Fragment>
  );
}

export default App;
