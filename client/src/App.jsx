import { useState } from 'react';
import './App.css';
import TiendaNavbar from './components/TiendaNavbar';
import Footer from './components/Footer';
import { BrowserRouter, Routes, Route, Outlet} from 'react-router-dom';
import Usuarios from './pages/Usuarios';
import { FormUsuario } from "./components/usuarios/FormUsuario";

function App() {
  const [count, setCount] = useState(0)

  return (
    <BrowserRouter>
       
                    

        <Routes>
          <Route  path="/"  element={<Layout></Layout>}>
            <Route index element={<Home></Home>}/>              
            <Route path="usuarios" element={<Usuarios/>}>
              
            </Route>
            <Route path="usuarios/registrar" element={<FormUsuario/>}/>
          </Route>

        </Routes>
        <Footer></Footer> 

    </BrowserRouter>
  );
}

function Layout() {
  return(
    <div className='wrapper'>
      <TiendaNavbar></TiendaNavbar>
      <Outlet ></Outlet>
    </div>
  );
}

function Home() {
  return (
    <div className='p-4'>
      Home
    </div>
  )
}


export default App;