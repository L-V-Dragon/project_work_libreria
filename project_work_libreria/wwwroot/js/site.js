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
    //questa parte ricrea le tabelle all interno di Cliente index ogni cambiamento
    //che si fa alla view index delle card deve venir applicato anche qua
                document.getElementById("Contenuto_utente").innerHTML +=
                    `

    <section class="listaLibri">


		<div class="containerLibri">
			<div class="card">
				        <div class="content">
					        <div class="imgBx">
						        <img src="${libro.foto}">
					        </div>
					        <div class="contentBx">
						        <h3>${libro.titolo}<br><span>${libro.autore} </span></h3>
					        </div>
				        </div>
				<ul class="sci p-0">
					<li>
						<a class="btn btn-warning btn" href="/Cliente/Dettagli/${libro.id}">
                        <span class="glyphicon glyphicon-book"></span> Dettagli</a>
					</li>
					<li>
						 <td align="left"><div class="heart"></div></td><td align="left"></td><td align="right"></td>
					</li>
					<li>
						<a href="/Cliente/Ordine/${libro.id}" class="btn btn-info  ">
                         <span class="glyphicon glyphicon-tag"></span> Ordina</a>
					</li>
				</ul>
			</div>
			
			
				
		
		</div>
	</section>

 

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
//questa parte ricrea le tabelle all interno di amministazione index ogni cambiamento
//che si fa alla view index delle tabelle deve venir applicato anche qua
                document.getElementById("Tabella").innerHTML += `
               
<tr class="text-white">
            
            <td>${libro.isbn}</td>
            <td>${libro.titolo}</td>
            <td>${libro.prezzo}</td>
            <td class="js">${libro.quantita}</td>
            <td>${libro.like}</td>
                    <td class="miei-buttons-post">
                        
                        <a class="btn btn-warning btn-sm" href="Update/${libro.id}">
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

`; resetcolor()
            });
        }) 
        .catch((error) => {
            console.log(error);
        });
}

function resetcolor() {

    let list = document.getElementsByClassName("js");

    for (let i = 0; i < list.length; i++) {
        if (list[i].innerHTML < 5) {
            list[i].classList.add("text-danger");
        }       
    }
}

function changeClass(event) {
    event.currentTarget.classList.toggle("is-active");
}

window.onload =async function afterWebPageLoad() {
    await new Promise(r => setTimeout(r, 250));

    let likes = document.getElementsByClassName("heart");

    for (let i = 0; i < likes.length; i++) {

        likes[i].addEventListener("click", changeClass, false);
    }

    //$(function () {
    //    $(".heart").on("click", function () {
    //        $(this).toggleClass("is-active");
    //    });
    //});

}




function aggiornaPrezzo() {
    let quantita = parseInt(document.getElementById("QuantitaLibri").value);
    let prezzo = parseFloat(document.getElementById("PrezzoLibro").innerHTML.replace(",", "."));
    let quantitaDisponibile = document.getElementById("QuantitaMagazzino").value;
    let quantitaCheck = quantitaDisponibile - quantita;
    debugger;
    let totale = prezzo * quantita;
    document.getElementById("TotaleParziale").innerHTML = totale;
    document.getElementById("Totale").innerHTML = totale;
    debugger;
    if (quantitaCheck < 0) {
        document.getElementById("BottoneCompra").disabled = true;
        document.getElementById("disponibilita").classList.remove("text-success");
        document.getElementById("disponibilita").classList.add("text-muted");
        document.getElementById("iconaDisponibilita").classList.remove("text-success");
        document.getElementById("iconaDisponibilita").classList.add("text-muted");
    } else {
        document.getElementById("BottoneCompra").disabled = false;
        document.getElementById("disponibilita").classList.remove("text-muted");
        document.getElementById("disponibilita").classList.add("text-success");
        document.getElementById("iconaDisponibilita").classList.remove("text-muted");
        document.getElementById("iconaDisponibilita").classList.add("text-success");

    }
    
}
