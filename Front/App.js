import React,{useState,useEffect} from 'react';
import {Route,Routes} from 'react-router-dom';
import Header from './component/Header';
import Home from './Pages/Home';
import Cart from './Pages/Cart';
import Bill from './Pages/Bill';
import UsersHome from './Pages/UsersHome';
import PRDCURD from './model/products';
import CATCURD from './model/categories';
import './styles/App.css';

function App() {
  let [product,setProducts]=useState([]);
  let [category,setCategories]=useState([]);
  let [cartItems,setCartItems]=useState([]);
  
  const subTotal=cartItems.reduce((total,current)=>total + current.price * current.qty ,0);
  const tax=subTotal * 0.15;
  const shipping=subTotal>2000 ? 0 : 30;
  const totalPrice = subTotal + tax + shipping;
 
  useEffect(()=>{
     PRDCURD.getAll()
     .then(res=>{
      //console.log(res);
      setProducts(res.data);
     })
     .catch(err=>{
      console.log(err);
     })
     CATCURD.getAll()
        .then(res=>{
            console.log(res);
            setCategories(res.data);
        })
        .catch(err=>{
            console.log(err);
        })
  },[])
  let addProduct=(product)=>{
    
    let itemExits=cartItems.find(item=>item.id===product.id);
    if(!itemExits){
      setCartItems([...cartItems,{...product,qty:1}]);
      console.log(cartItems);
    }
    else{ 
      setCartItems(cartItems.map(item=>item.id===product.id?{...itemExits,qty:itemExits.qty + 1 } : item))
    }
  }
  let removeProduct=(product)=>{
    let exists=cartItems.find(item=>item.id===product.id);
    if(exists.qty===1){
      setCartItems(cartItems.filter(item=>item.id !== product.id));
    }
    else{
      setCartItems(cartItems.map(item=>item.id===product.id?{...exists,qty:exists.qty - 1 } : item))
    }
  }
  
  return (
    
    <div className="App">
      <Header countItems={cartItems.length}/>
      <div className='container'> 
           <Routes>
              <Route path='/' exact element={<Home categories={category} products={product} handleAddProduct={addProduct}/>}/>
              <Route path='/cart' element={<Cart cartItems={cartItems}
               handleAddProduct={addProduct} 
               handleRemoveProduct={removeProduct}
               subTotal={subTotal}
               tax={tax}
               shipping={shipping}
               totalPrice={totalPrice}
               />}/>
              <Route path='/bill' element={<Bill cartItems={cartItems}
               subTotal={subTotal}
               tax={tax}
               shipping={shipping}
               totalPrice={totalPrice}
              />}/>
              <Route path='/user/*' exact element={<UsersHome/>}/>
           </Routes> 
      </div>
    </div>
  );
}

export default App;
