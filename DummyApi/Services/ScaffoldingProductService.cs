using DummyApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DummyApi.Services //  è parte dell funzionamento dell'incapsulamento
{
    public class ScaffoldingProductService : IProductService
    {
        // Scaffolding: non sono dati presi al trove ma vado a creare manualmente degli oggetti
        // che verranno utilizzati dati nostri metodi
        private List<Product> _products = new List<Product> // incapsulo questo metodo, per mantenere all interno di questo
        {                                           // classe..
            // Adottiamo le convinzioni di C# e mettiamo _ davanti i campi privati!!!( under score)

            // ora inseriamo dei dati di scaffolding( gestion dei dati da livello di codice in modo da avere un risultato
            // immediato e per mettere alla prova la nsotra implementazione
             // QUa si fa uso dei setter.. 
            new Product
            {
                Id = 1, Name = "Mouse da gaming", Category = "Gaming", Price = 19.99
            },
            new Product
            {
                Id = 2, Name = "Notebook", Category = "Informatica", Price = 1200.99
            },
            new Product
            {
                Id = 3, Name = "Caricabatteria type-c", Category = "Accessori", Price = 9.99
            },

        };
        // Il costruttore si fa quando si impone di passare certi parametri
        // in questo caso non lo faccio, uso il costruttore implicito attraverso il setter, e accanto
        // a new product non è necassario () , solo se crreavo una lista vuota dovevo inserire le parentesi
        // per invocare il costruttore vuoto.
        // il prodotto che arriva al metodo molto probabilmente sarà sprovvisto di ID
        // Dobbiamo assegnargliene uno noi
        private int _lastId = 4;
        public void AddProduct(Product product)
        {
            product.Id = _lastId++;
            _products.Add(product);
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> GetaAll()
        {
            return _products;

        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(int id, Product product)
        {
            throw new NotImplementedException();
        }


    }
}
