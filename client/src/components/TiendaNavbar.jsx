import React from 'react';
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import { Link } from 'react-router-dom';
import NavDropdown from 'react-bootstrap/NavDropdown';



const TiendaNavbar = () =>{
    return(
        
        <Navbar className="navbar navbar-expand-lg navbar-dark bg-dark">
            <Container className="container-fluid">
            <Navbar.Brand  as={Link} className="navbar-brand" to="/">Inicio</Navbar.Brand>
            <Navbar.Toggle aria-controls="basic-navbar-nav" />
            <Navbar.Collapse  className="nav-link active" >
                <Nav>
                    <Nav.Link className="nav-link active" aria-current="page" to="/inicio-sesion" >Inicio sesión</Nav.Link>
                    <Link className="nav-link active" as={Link} to="/usuarios" >Listar Usuario</Link>
                    <NavDropdown title="Usuarios" id="basic-navbar-nav">
                        <NavDropdown.Item as={Link} to={'/usuarios'}>Listar Usuario</NavDropdown.Item>
                        <NavDropdown.Item as={Link} to={'/usuarios/registrar'}>
                            Registrar Usuario
                        </NavDropdown.Item>
                        <NavDropdown.Item href="#action/3.3">Something</NavDropdown.Item>
                        <NavDropdown.Divider />
                        <NavDropdown.Item href="#action/3.4">
                            Separated link
                        </NavDropdown.Item>
                    </NavDropdown>
                </Nav>
            </Navbar.Collapse>

            <div className="d-flex">
                <button type="button" className="btn btn-outline-danger">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" className="bi bi-cart-check" viewBox="0 0 16 16">
                    <path d="M11.354 6.354a.5.5 0 0 0-.708-.708L8 8.293 6.854 7.146a.5.5 0 1 0-.708.708l1.5 1.5a.5.5 0 0 0 .708 0z"></path>
                    <path d="M.5 1a.5.5 0 0 0 0 1h1.11l.401 1.607 1.498 7.985A.5.5 0 0 0 4 12h1a2 2 0 1 0 0 4 2 2 0 0 0 0-4h7a2 2 0 1 0 0 4 2 2 0 0 0 0-4h1a.5.5 0 0 0 .491-.408l1.5-8A.5.5 0 0 0 14.5 3H2.89l-.405-1.621A.5.5 0 0 0 2 1zm3.915 10L3.102 4h10.796l-1.313 7zM6 14a1 1 0 1 1-2 0 1 1 0 0 1 2 0m7 0a1 1 0 1 1-2 0 1 1 0 0 1 2 0"></path>
                    </svg>
                </button>
            </div>

            </Container>
        </Navbar>

    );

};

export default TiendaNavbar;