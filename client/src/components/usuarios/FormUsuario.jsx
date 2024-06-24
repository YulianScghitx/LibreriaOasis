import React, { useEffect, useState } from 'react';
import { CreateUser } from '../../api/usuarios.api';
import { getComunas } from '../../api/comunas.api';
import { useForm  } from 'react-hook-form';

export const FormUsuario = () => {
  const [formData, setFormData] = useState({
    correo: '',
    rut: '',
    primer_nombre: '',
    segundo_nombre: '',
    apellido_paterno: '',
    apellido_materno: '',
    contrasena: '',
    numero_telefono: '',
    comuna: ''
  });
  const [comunas, setComunas] = useState([]);

  useEffect(()=>{
    ComunasList();
  },[]);
  async function ComunasList() {
    const data = await getComunas();
    setComunas(data);
  }


  const handleChange = (e) => {
    const { name, value } = e.target;
    setFormData({ ...formData, [name]: value });
  };

  const onSubmit = async (e) => {
    e.preventDefault();
    let respuestaPost  = await CreateUser(JSON.stringify(formData));
    if (respuestaPost.ok) {
      alert('Usuario registrado exitosamente');
      window.location.href = "inicio-sesion.html";
    } else {
      let errorMessage = await respuestaPost.text();
      alert('Error al registrar el usuario: ' + errorMessage);
    }
  };



  return (
    <div className="main-content">
      <h2>Registrar Usuario</h2>
      <br />
      <div className="RegistrarUsuario-container">
        <form id="FormularioRegistrarUsuario" onSubmit={onSubmit}>
          <div className="form-group">
            <label htmlFor="correo">Correo</label>
            <input type="email" className="form-control" name="correo" id="correo" required onChange={handleChange} value={formData.correo} />
          </div>
          <div className="form-group">
            <label htmlFor="rut">R.U.T</label>
            <input type="text" className="form-control" name="rut" id="rut" required onChange={handleChange} value={formData.rut} />
          </div>
          <div className="form-group">
            <label htmlFor="primer_nombre">Primer Nombre</label>
            <input type="text" className="form-control" name="primer_nombre" id="primer_nombre" required onChange={handleChange} value={formData.primer_nombre} />
          </div>
          <div className="form-group">
            <label htmlFor="segundo_nombre">Segundo Nombre</label>
            <input type="text" className="form-control" name="segundo_nombre" id="segundo_nombre" onChange={handleChange} value={formData.segundo_nombre} />
          </div>
          <div className="form-group">
            <label htmlFor="apellido_paterno">Apellido Paterno</label>
            <input type="text" className="form-control" name="apellido_paterno" id="apellido_paterno" required onChange={handleChange} value={formData.apellido_paterno} />
          </div>
          <div className="form-group">
            <label htmlFor="apellido_materno">Apellido Materno</label>
            <input type="text" className="form-control" name="apellido_materno" id="apellido_materno" required onChange={handleChange} value={formData.apellido_materno} />
          </div>
          <div className="form-group">
            <label htmlFor="contrasena">Contraseña:</label>
            <input type="password" className="form-control" name="contrasena" id="contrasena" required onChange={handleChange} value={formData.contrasena} />
          </div>
          <div className="form-group">
            <label htmlFor="numero_telefono">Número de teléfono</label>
            <input type="tel" className="form-control" name="numero_telefono" id="numero_telefono" required onChange={handleChange} value={formData.numero_telefono} />
          </div>
          <div className="form-group">
            <label htmlFor="comuna">Comuna</label>
            <select className="form-control" name="comuna" id="comuna" required onChange={handleChange} value={formData.comuna}>
              <option value="">Seleccione una comuna</option>
              {comunas.map( (comu) => {
                return(
                <option value={comu.id} key={comu.id}>
                  {comu.nombre}
                </option>
              );
              })}

            </select>
          </div>
          <br />
          <button type="submit" className="btn btn-primary btn-block">Guardar</button>
        </form>
      </div>
      <br />
    </div>
  )};
