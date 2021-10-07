using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DummyApi.Models; // INseriamo l'using cosi abbiamo accesso ai suoi elementi

namespace DummyApi.Services
{
    interface IPersonService
    {

        // Definire un contrato per tutte le classi che lo implementano:
        // Fornire le operazioni CRUD sugli oggetti di tipo Person

        List<Person> GetAll(); // Grazie all'using del namespace di Person riesco a richiamare Person.

        Person GetById(int id);

        void AddPerson(Person person); // Col metodo void modifico la lista aggiungendone un nuovo elemento
        void UpdatePerson(int id, Person person);
        void DeletePerson(int id);

      // COn l interfaccia obbligo le classi a usare questi metodi 
    }
}
