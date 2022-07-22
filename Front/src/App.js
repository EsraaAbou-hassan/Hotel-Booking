import { Fragment, useState } from "react";
import { Routes, Route } from "react-router-dom";

import Home from './Pages/Home';
import Hotels from './Pages/Hotels';
import Rooms from './Pages/Rooms';
import RoomsDetails from "./Pages/RoomsDetails";
import Reserve from "./Pages/Reserve";
import LoginScreen from "./Pages/Login";
import RegisterScreen from "./Pages/Register";
import PaymentScreen from "./Pages/Payment";
import Admin from "./Pages/Admin";




function App() {
 let [status,setStatus]=useState(false);
 let [logData,setLogData]=useState();
 let [upData,setUpData]=useState();
 
  return (
   <Fragment>
     <Routes>
        <Route path='/' exact element={<LoginScreen setStatus={setStatus} setLogData={setLogData}/>}/>
        <Route path='/home' exact element={<Home setStatus={setStatus} myStatus={status}  logData={logData} upData={upData}/>}/>
        <Route path='/hotels' element={<Hotels myStatus={status}  logData={logData} upData={upData}/>}/>
        <Route path='/rooms/:id' element={<Rooms myStatus={status}  logData={logData} upData={upData}/>}/>
        <Route path='/roomsdetails' element={<RoomsDetails/>}/>
        <Route path='/reserve' element={<Reserve/>}/>
        <Route path='/register' element={<RegisterScreen setUpData={setUpData}/>}/>
        <Route path='/payment/:id' element={<PaymentScreen/>}/>
        <Route path='/admin/*' element={<Admin/>}/>
     </Routes>
   </Fragment>
  );
}

export default App;
