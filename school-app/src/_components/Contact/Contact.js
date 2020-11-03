import React from 'react';
import { Button, FormGroup, FormControl, ControlLabel } from "react-bootstrap";
import NavigationBar from '../Navbar/Navbar'


export default function Contact(){

    return(
        <div>
          <NavigationBar></NavigationBar>
        <div>
        <form>
          <FormGroup>
            <ControlLabel>Email</ControlLabel>
            <FormControl
              autoFocus
              type="email"
            />
          </FormGroup>

          <FormGroup>
            <ControlLabel>Nombre</ControlLabel>
            <FormControl
              type="text"
            />
          </FormGroup>

          <FormGroup>
            <ControlLabel>Telefono</ControlLabel>
            <FormControl
              autoFocus
              type="text"
            />
          </FormGroup>

          <FormGroup>
            <ControlLabel>Consulta</ControlLabel>
            <FormControl
              autoFocus
              type="text"
            />
          </FormGroup>



          <Button block bsSize="large">
            Enviar Consulta
          </Button>
        </form>
      </div>
        </div>
    );
}