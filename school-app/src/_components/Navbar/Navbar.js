import React from 'react';
import { Link, Route, BrowserRouter as Router, Switch } from "react-router-dom";
import "../Navbar/Navbar.css";



export default function NavigationBar(){
    return(
    <div className="topnav">
      <Link to="/contact">Contact</Link>
      <Link to="/login">Login</Link>
      <Link to="/login">Login</Link>
  </div>
    );
}