using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DummyApi.Services; // using nome.namespace ci permette di utilizzare tutti glielementi di quel determinato namespace
using DummyApi.Model;

namespace DummyApi.Controllers
{
    [Route("api/[controller]")]   // fa in modo che questa classe venga presa come controller
    [ApiController]             // route: specifica il percorso da richiamare.
    public class ProductsController : ControllerBase
    {
        // Controller base:  a diffferenza di quello normale non è in grado di gestire le view
        // ma soltanto le risorse pure.   IMplicitamente andrà a Serializzare gli oggetti restituiti  daI VARI METODI MAPPATI
        // in un formato "standard" cioè il JSON.

        private IProductService _productService = new ScaffoldingProductService();

        [HttpGet] // serve a dire al framework che questo metoedo dovrà rispondere alle chiamate HTTP
        // di tipo(verbo/metodo) GET.
        public IEnumerable<Product> GetAll()
        {
            return _productService.GetaAll(); // cerca nel database la lista stessa.
       
        }

        // POSTMAN-> IN GRADO DI RICERE LE CHIAMATE HTTP

        [HttpPost]

        //HttpPost fa ijn modo di far gestire a questo metodo tutte le chiamate di tipoPOst
        public IActionResult AddProduct([FromBody] Product newProduct)
        {

            _productService.AddProduct(newProduct);

            return Ok(); // è un metodo derivato da basecontroller chwe mi permette di restituire in modo immediato
            // uno stato positivo della chiamata, come risposta.

        }


    }
}
