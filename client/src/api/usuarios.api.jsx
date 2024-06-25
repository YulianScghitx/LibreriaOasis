import React, { useState, useEffect } from 'react';
import axios from 'axios';


const urlWebAPIUsuarios = 'https://localhost:7025/usuarios';

export const getAllUsuarios = async () => {
    let data;  
    await axios.get(urlWebAPIUsuarios).then(
        res => data = res.data
    ).catch(
        error =>{
            data = undefined;
            console.log(error);
        }
    );
    return data;
};


export const CreateUser = async (user) => {
    try {
        const response = await axios.post(urlWebAPIUsuarios, user, {headers:{'Content-Type': 'application/json'}})
        return response;
    } catch (error) {
        console.log(error)
        throw error;
    }

};
