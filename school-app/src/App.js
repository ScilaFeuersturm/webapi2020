import React from "react";
import "./App.css";
import { Link, Route, BrowserRouter as Router, Switch } from "react-router-dom";
import Login from './_components/Login/Login'
import Contact from './_components/Contact/Contact'
import NavigationBar from './_components/Navbar/Navbar'
import Footer from './_components/Footer/Footer'

function HomePage() {
  return (
    <>
      <NavigationBar></NavigationBar>
      <div>
      <Footer/>
      </div>
      
    </>
  );
}
function NotFound() {
  return <h1>No se encontro lo que buscaba...</h1>;
}

function App () {
    return (
      <div className="App">
      <Router>
        <Switch>
          <Route exact path="/">
            <HomePage />
          </Route>
          <Route exact path="/login">
            <Login />
          </Route>
          <Route exact path="/contact">
            <Contact/>
          </Route>
          <Route path="*">
            <NotFound />
          </Route>
        </Switch>
      </Router>
    </div>

    );
}


export default App;
