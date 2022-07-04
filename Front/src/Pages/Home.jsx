import React, { Fragment } from 'react';
import Header from "../Components/Header/Header";
import Places from '../Components/Places/Places';
import Gallery from '../Components/Gallery/Gallery';
import Footer from '../Components/Footer/Footer';
import Filter from '../Components/Filter/Filter';


function Home(){
  return(
    <Fragment>
      <Header/>
      <Filter/>
      <Places/>
      <Gallery/>
      <Footer/>
    </Fragment>
  )
}

export default Home;