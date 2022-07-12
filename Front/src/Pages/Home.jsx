import React, { Fragment } from 'react';
import Header from "../Components/Header/Header";
import Places from '../Components/Places/Places';
import Gallery from '../Components/Gallery/Gallery';
import Footer from '../Components/Footer/Footer';
import Filter from '../Components/Filter/Filter';


function Home({setStatus,myStatus,logData,upData}){
  return(
    <Fragment>
      <Header setStatus={setStatus} myStatus={myStatus} logData={logData} upData={upData}/>
      <Filter/>
      <Places/>
      <Gallery/>
      <Footer/>
    </Fragment>
  )
}

export default Home;