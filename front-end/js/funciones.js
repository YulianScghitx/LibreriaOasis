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

function insertarNavBar() {
    const navBarHTML = `
        <div class="container-fluid">
            <a class="navbar-brand" href="index.html">Inicio</a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
              <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
              <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                <li class="nav-item">
                  <a class="nav-link active" aria-current="page" href="inicio-sesion.html">Inicio sesión</a>
                </li>
                <li class="nav-item ">
                  <a class="nav-link active" href="listar-usuario.html">Listar Usuario</a>
                </li>
                <li class="nav-item dropdown">
                  <a class="nav-link active dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                    Libros
                  </a>
                  <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                    <li><a class="dropdown-item" href="listar-libro.html">Listar Libros</a></li>
                    <li><a class="dropdown-item" href="listar-categoria.html">Listar Categorias</a></li>
                    <li><hr class="dropdown-divider"></li>
                    <li><a class="dropdown-item" href="crear-libro.html">Crear Libros</a></li>
                    <li><a class="dropdown-item" href="crear-categoria.html">Crear Categorias</a></li>
                  </ul>
                </li>
              </ul>
              <div class="d-flex">
                <button type="button" class="btn btn-outline-danger" onclick="window.location.href='carrito.html'">
                    <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-cart-check" viewBox="0 0 16 16">
                    <path d="M11.354 6.354a.5.5 0 0 0-.708-.708L8 8.293 6.854 7.146a.5.5 0 1 0-.708.708l1.5 1.5a.5.5 0 0 0 .708 0z"></path>
                    <path d="M.5 1a.5.5 0 0 0 0 1h1.11l.401 1.607 1.498 7.985A.5.5 0 0 0 4 12h1a2 2 0 1 0 0 4 2 2 0 0 0 0-4h7a2 2 0 1 0 0 4 2 2 0 0 0 0-4h1a.5.5 0 0 0 .491-.408l1.5-8A.5.5 0 0 0 14.5 3H2.89l-.405-1.621A.5.5 0 0 0 2 1zm3.915 10L3.102 4h10.796l-1.313 7zM6 14a1 1 0 1 1-2 0 1 1 0 0 1 2 0m7 0a1 1 0 1 1-2 0 1 1 0 0 1 2 0"></path>
                    </svg>
                  </button>
              </div>
            </div>
        </div>
    `;
    document.querySelector('nav.navbar').innerHTML = navBarHTML;
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