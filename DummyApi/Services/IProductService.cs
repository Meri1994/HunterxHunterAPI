using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DummyApi.Model;

namespace DummyApi.Services
{
    interface IProductService
    {
       // il service deve fornire in qualche modo un IEnumerable di product.
        // IEnumerable -> è un interfaccia 
        // Le collection sono dei generic, in quanto devo definire il tipo degli oggetti nella collection
        // perciò è un generic.
        // IEnumerable : puo essere usato anche senza il generico ed essere utilizzato come collezione.
        IEnumerable<Product> GetaAll();
        Product GetById(int id);
        void AddProduct(Product product);
        void UpdateProduct(int id, Product product);
        void Delete(int id);

        // Il vantaggio principale di usare l'interfaccia ad astrarre l'implementazione 
        //in quanto io addottando l interfaccia come tipo formale .. faccio in modo che il resto della mia app.. 
        // che garantisce lo stesso contratto
        // Mi va ad estrarre e di  mantenere un distaccamento dell utilizzo stesso dalla parte dell implementazione
        // che puo cambiare con il tempo.


    }
}
