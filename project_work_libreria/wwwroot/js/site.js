// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Cliente API Funzioni------------
function searchProdotto() {
    let stringaDiRicerca = document.getElementById("SearchBar").value;
    loadProdotti(stringaDiRicerca);
}

function loadProdotti(searchString) {
    axios.get('/api/Apiamministrazione', {
        params: {
            search: searchString
        }
    }).then((res) => {

        console.log('risultato ok', res);

        if (res.data.length == 0) {

            document.getElementById("js_no_found").classList.remove('d-none');
            document.getElementById("Contenuto_utente").classList.add('d-none');

        } else {

            document.getElementById("Contenuto_utente").classList.remove('d-none');
            document.getElementById("js_no_found").classList.add('d-none');

            document.getElementById("Contenuto_utente").innerHTML = '';

            res.data.forEach(libro => {

                console.log('libro', libro);

                document.getElementById("Contenuto_utente").innerHTML +=
                    `
        <div class="m-3 card p-3" style="max-width: 500px;">
        <div class="row no-gutters">
        <div class="col-md-4">
        <img src="${libro.foto}" class="card-img" alt="Immagine libro">
        </div>
        <div class="col-md-8">
        <div class="card-body">
        <h5 class="card-title">${libro.titolo}</h5>
        <p class="card-text">Trama: ${libro.trama}</p>
        <h4 class="card-text">Genere: ${libro.genere.nome}</h4>
        <h4 class="card-text">Prezzo: ${libro.prezzo}$</h4>
        <a class="btn btn-warning btn-lg " href="/Cliente/Dettagli/${libro.id}">
        <span class="glyphicon glyphicon-book"></span> Dettagli</a>
        <a href="" class="btn btn-info btn-lg ">
        <span class="glyphicon glyphicon-tag"></span> Ordina</a>
        </div>
        </div>
        </div>
        </div>


`;
            });
            document.getElementById("spinner-loader").classList.add('d-none');
        }
    }).catch((error) => {
        console.log(error);
    });
}
//------------

//Amministratore funzioni----------
function searchTabella() {
    let stringaDiRicerca = document.getElementById("input_search").value;
    loadTabella(stringaDiRicerca);
}

function loadTabella(searchString) {
    axios
        .get("/api/Apiamministrazione", {
            params: {
                search: searchString,
            },
        })
        .then((res) => {
            console.log("risultato ok", res);
            document.getElementById("Tabella").innerHTML = '';
            res.data.forEach((libro) => {
                console.log("libro", libro);
                document.getElementById("Tabella").innerHTML += `
               
<tr class="text-white">
            
            <td>${libro.isbn}</td>
            <td>${libro.titolo}</td>
            <td>${libro.prezzo}</td>
            <td>${libro.quantita}</td>
            <td>${libro.like}</td>
                    <td class="miei-buttons-post">
                        
                        <a class="btn btn-warning btn-sm" href="/Update/${libro.id}">
                            <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-activity"><polygon points="14 2 18 6 7 17 3 17 3 13 14 2"></polygon><line x1="3" y1="22" x2="21" y2="22"></line></svg>
                        </a>
                            <a type="submit" href="Amministrazione/Delete/${libro.id}" class="btn btn-danger btn-sm">
                                <svg xmlns="http://www.w3.org/2000/svg" width="24" height="24" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" class="feather feather-activity"><polyline points="3 6 5 6 21 6"></polyline><path d="M19 6v14a2 2 0 0 1-2 2H7a2 2 0 0 1-2-2V6m3 0V4a2 2 0 0 1 2-2h4a2 2 0 0 1 2 2v2"></path><line x1="10" y1="11" x2="10" y2="17"></line><line x1="14" y1="11" x2="14" y2="17"></line></svg>
                            </a>

                         
                   
                            <a href="#" class="btn btn-info btn-lg">
                            <span class="glyphicon glyphicon-shopping-cart"></span> Ordina
                            </a>
                   
                    </td>
        </tr>

`;
            });
        })
        .catch((error) => {
            console.log(error);
        });
}
//--------