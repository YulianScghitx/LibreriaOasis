import React, { useState, useEffect } from 'react';
import { getAllUsuarios } from '../../api/usuarios.api';
import User from '../../types/types' 


const UserList = ({ urlWebAPIUsuarios }) => {
    const [users, setUsers] = useState([]);

    useEffect(() => {
        ( async () =>{
            let data = getAllUsuarios();
            setUsers(data);
        })();
       
    }, [urlWebAPIUsuarios]);

    const desactivarUsuarios = (rut) => {
        
        console.log("Desactivar usuario with RUT:", rut);
    };

    return (
        <table className="table">
            <thead>
                <tr>
                    <th>RUT</th>
                    <th>Email</th>
                    <th>First Name</th>
                    <th>Last Name</th>
                    <th>Action</th>
                </tr>
            </thead>
            <tbody id="listaUsuarios">
                {users.map((user, index) => (
                    <tr key={index}>
                        <td>{user.rut}</td>
                        <td>{user.correo}</td>
                        <td>{user.primer_nombre} {user.segundo_nombre}</td>
                        <td>{user.apellido_paterno} {user.apellido_materno}</td>
                        <td>
                            <button 
                                className="btn btn-danger btn-sm" 
                                onClick={() => desactivarUsuarios(user.rut)}
                            >
                                Desactivar
                            </button>
                        </td>
                    </tr>
                ))}
            </tbody>
        </table>
    );
};

export default UserList;