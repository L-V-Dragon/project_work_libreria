// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function searchProdotti() {
    let stringaDiRicerca = document.getElementById('input_search').value;
    debugger;
    loadProdotti(stringaDiRicerca);
}

function loadProdotti(searchString) {
    axios.get('/api/Apiamministrazione', {
        params: {
            search: searchString
        }
    })
}