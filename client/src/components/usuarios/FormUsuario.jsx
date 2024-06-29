import React, { useEffect, useState } from 'react';
import { CreateUser } from '../../api/usuarios.api';
import { getComunas } from '../../api/comunas.api';
import { useForm } from 'react-hook-form';
import { Container, Form, Button, Row, Col } from 'react-bootstrap';
export const FormUsuario = () => {

  const { register, handleSubmit, formState: { errors } } = useForm();
  const [comunas, setComunas] = useState([]);

  useEffect(()=>{
    ComunasList();
  },[]);

  async function ComunasList() {
    const data = await getComunas();
    setComunas(data);
  }

  const onSubmit = async (formData) => {
    try {
      let json = JSON.stringify(formData)
      let respuestaPost  = await CreateUser(json);
      if (respuestaPost && respuestaPost.status == 201) {
        alert('Usuario registrado exitosamente');
      } else {
        alert('Error al registrar el usuario');
      }
    } catch (error) {
      alert('Error al registrar el usuario:' + error.respuestaPost.data);
    }  
   
  };



  return (
    <Container className="main-content">
    <h2>Registrar Usuario</h2>
    <br />
    <Row className="justify-content-md-center">
      <Col>
        <Form id="FormularioRegistrarUsuario" onSubmit={handleSubmit(onSubmit)}>
          <Form.Group controlId="correo">
            <Form.Label>Correo</Form.Label>
            <Form.Control
              type="email"
              {...register('correo', { required: true })}
              isInvalid={!!errors.correo}
            />
            <Form.Control.Feedback type="invalid">Correo es requerido</Form.Control.Feedback>
          </Form.Group>

          <Form.Group controlId="rut">
            <Form.Label>R.U.T</Form.Label>
            <Form.Control
              type="text"
              {...register('rut', { required: true })}
              isInvalid={!!errors.rut}
            />
            <Form.Control.Feedback type="invalid">R.U.T es requerido</Form.Control.Feedback>
          </Form.Group>

          <Form.Group controlId="primer_nombre">
            <Form.Label>Primer Nombre</Form.Label>
            <Form.Control
              type="text"
              {...register('primer_nombre', { required: true })}
              isInvalid={!!errors.primer_nombre}
            />
            <Form.Control.Feedback type="invalid">Primer Nombre es requerido</Form.Control.Feedback>
          </Form.Group>

          <Form.Group controlId="segundo_nombre">
            <Form.Label>Segundo Nombre</Form.Label>
            <Form.Control
              type="text"
              {...register('segundo_nombre')}
            />
          </Form.Group>

          <Form.Group controlId="apellido_paterno">
            <Form.Label>Apellido Paterno</Form.Label>
            <Form.Control
              type="text"
              {...register('apellido_paterno', { required: true })}
              isInvalid={!!errors.apellido_paterno}
            />
            <Form.Control.Feedback type="invalid">Apellido Paterno es requerido</Form.Control.Feedback>
          </Form.Group>

          <Form.Group controlId="apellido_materno">
            <Form.Label>Apellido Materno</Form.Label>
            <Form.Control
              type="text"
              {...register('apellido_materno', { required: true })}
              isInvalid={!!errors.apellido_materno}
            />
            <Form.Control.Feedback type="invalid">Apellido Materno es requerido</Form.Control.Feedback>
          </Form.Group>

          <Form.Group controlId="contrasena">
            <Form.Label>Contraseña</Form.Label>
            <Form.Control
              type="password"
              {...register('contrasena', { required: true })}
              isInvalid={!!errors.contrasena}
            />
            <Form.Control.Feedback type="invalid">Contraseña es requerido</Form.Control.Feedback>
          </Form.Group>

          <Form.Group controlId="numero_telefono">
            <Form.Label>Número de teléfono</Form.Label>
            <Form.Control
              type="tel"
              {...register('numero_telefono', { required: true })}
              isInvalid={!!errors.numero_telefono}
            />
            <Form.Control.Feedback type="invalid">Número de teléfono es requerido</Form.Control.Feedback>
          </Form.Group>

          <Form.Group controlId="comuna">
            <Form.Label>Comuna</Form.Label>
            <Form.Control
              as="select"
              {...register('comuna', { required: true })}
              isInvalid={!!errors.comuna}
            >
              <option value="">Seleccione una comuna</option>
              {comunas.map( (comu) => {
                return(
                <option value={comu.id} key={comu.id}>
                  {comu.nombre}
                </option>
              );
              })}
            </Form.Control>
            <Form.Control.Feedback type="invalid">Comuna es requerida</Form.Control.Feedback>
          </Form.Group>
          <br />
          <Button type="submit" className="btn btn-primary btn-block">Guardar</Button>
        </Form>
      </Col>
    </Row>
    <br />
  </Container>
  )};
