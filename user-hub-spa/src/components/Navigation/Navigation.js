import React from 'react';
import './Navigation.css';
import Home from "../Home/Home";
import {
    BrowserRouter as Router,
    Switch,
    Route,   
    NavLink
  } from "react-router-dom";


const navigation = (props) => {
    return (
      
        <Router>
        <div>
          <nav className="navbar navbar-expand-lg navbar-light bg-light">
              <div className="container-fluid">
              {/* <a className="navbar-brand" href="/home">Navbar</a> */}
              {/* <NavLink to="/home" className="navbar-brand">Navbar</NavLink> */}
             
              <ul className="nav navbar-nav">
              <li className="nav-item">
                <NavLink to="/users" className="nav-link">Users</NavLink>
              </li>
             
             
            </ul>
              </div>
          

           
          </nav>
  
        
         <div className="container">
         <Switch>
       
            <Route path="/users" >
              {/* <Home /> */}
            </Route>
                  
          </Switch>
         </div>
        </div>
      </Router>
    )
            }

export default navigation;