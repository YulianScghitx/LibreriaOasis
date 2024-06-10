function insertarFooter() {
    const footerHTML = `
        <div class="container">
            <p>&copy; 2024 Libreria Oasis. Todos los derechos reservados.</p>
            <div class="mb-2">
            </div>
            <p>
                <a href="#" class="text-white me-2">Política de Privacidad</a>
                <a href="#" class="text-white">Términos de Servicio</a>
            </p>
        </div>
    `;
    document.querySelector('footer').innerHTML = footerHTML;
}

async function fetchGetData(urlWebAPI) {
    try {
        const respuesta = await fetch(urlWebAPI, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        return respuesta;
    } catch (error) {
        console.error('Error:', error);
        throw error;
    }
}

async function fetchDeleteData(urlWebAPI) {
    try {
        const respuesta = await fetch(urlWebAPI, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        });

        return respuesta;
    } catch (error) {
        console.error('Error:', error);
        throw error;
    }
}

async function fetchPostData(urlWebAPI, jsonData) {
    try {
        const respuesta = await fetch(urlWebAPI, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(jsonData)
        });

        return respuesta;
    } catch (error) {
        console.error('Error:', error);
        throw error;
    }
}

async function fetchPutData(urlWebAPI, jsonData) {
    try {
        const respuesta = await fetch(urlWebAPI, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(jsonData)
        });

        return respuesta;
    } catch (error) {
        console.error('Error:', error);
        throw error;
    }
}