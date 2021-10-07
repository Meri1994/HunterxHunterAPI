using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DummyApi.Services;
using DummyApi.Models;

namespace DummyApi.Controllers
{   
    // I controller gestiscono INPUT/OUTPUT, questi controoller
    // gestiscono chiamate attraverso il protocollo http ( usando la rete ed uno specifico protoccolo)
    [Route("[controller]")]  // questo specifico controller riceverà le richieste da http, da qualsiasi cosa
    // che sia in grado di fare chiamate HTTP.

    // Rout serve per mappare le chiamate che arrivano su "/nomeController"
    // in modo che vengano gestite dai metodi definiti dentro la classe
    [ApiController] // Questa classe è un controller che gestisce risorse
    public class PersonsController : ControllerBase
    {
        // Gestisco tutte le chiamate di tipo Get
        //[HttpGet]  // Http è un protocollo che si usa per comunicare con il server
        //           // get è un metodo del protoccolo http
        //           // lo mettiamo per dire che se arriva una chiamata get a questo controller fai che la chiamata sia gestita da questo metodo
        //public string HelloWorld()
        //{
        //    return "Ciao"; // QUesta è la risposta che mandiamo al client della chiamata  http

        //}

        // Assegno ad un nostro campo l'istanza (singleton) del service  (nostro "DAO")
        private IPersonService _personService = ScaffoldingPersonService.GetInstance();
        // l'utilizzo di un interface serve ad avere un livello di astrazione
        // rispeto all'implementazione concreta
        //in futuro potro andare a sostituire la classe che sto utilizzando adesso
        // con un'altra che implementa lo stesso contratto

      
        [HttpGet]
        // Questo è un controller e chiede a model
        public List<Person> Get()
        {
            var res = _personService.GetAll(); // chiede la lista

            //Output
            // ritorna la risposta
            return res;
        }

        // modell -> è  l insieme del cervello che compone l'app
        // QUi non cè la view perciò l utente interagisce col controller, esso non risponde direttamente lui
        //perchè lui puo fare solo input e output.. chiede a modem  di fornirgli una risposta..
        // saarà model che restituirà la risposta.. e il controller poi la restituisce a colui che
        // ha richiesto l'info

        // Qua la parte visiva non cè 

        // Noi gestiamo direttamente oggetti c# ci pensa asp.net Core e convertire
        // questi gogetti in stringhe JSON

        // QUESTO è BACKEND

        // CONVIENE USARE L'API PUO ESSERE USATA IN DIVERSI CONTESTI, 
        // HA UN MODO DIVERSO DI SVILUPPARE QUALCOSA, TRALASCIA LA PARTE VISIVA E VUOLE OFFRIRE
        // ATTRAVERSO UN PROTOCOLLO PRECISO ( HTML) UNA DETERMINATA FUNZIONALITA


        // i METODI  fanno in modo che le cose siano chiare, con la chiamta get deve ricere delle informazioni


        [HttpPost]
        public void AddNewPerson([FromBody]Person Person)
        {
            //[fromBody] dice esplicitamente da dove arriva il valore
            // In realta abbiamo visto che funziona anche senza, perche lo prende come "Configurazione" di 
            //default conviene pero includerlo per chiarezza

            // I client ci manderanno stringhe JSON che saranno
            // convertite in oggetti C# dal framework
            _personService.AddPerson(Person);

        }


        // i percorsi definiti tra le graffe sono elementi dinamici (wildcard)
        // servono a far in modo da accettare qualsiasi valore e quel valore potrà
        // essere utilizzato per diversi scopi; nel nostro esempio corrisponde
        // all'id della risorsa richiesta
        [HttpGet("{id}")]

        public Person GetById([FromRoute] int id)
        {

            return _personService.GetById(id);

        }
        
        [HttpDelete("{id}")]
        public void RemoveById( [FromRoute] int id)
        {
            _personService.DeletePerson(id);
        }


        // La differenza del put rispetto al resto è che è leggermente complesso
        //In quanto devo andare a recuperare due informazioni diverse in due parti diverse
        //della chiamata http
        [HttpPut("{id}")]
        public void UpdatePerson([FromRoute] int id, [FromRoute] Person person)
        {

            _personService.UpdatePerson(id, person);
        }

    }
}
