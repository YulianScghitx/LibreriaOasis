import axios from 'axios';


const urlWebAPIUsuarios = 'https://localhost:7025/comunas';

export const getComunas = async () => {
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