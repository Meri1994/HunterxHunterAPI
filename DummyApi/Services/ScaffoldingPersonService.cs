using DummyApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DummyApi.Services
{
    // Un servizio è un elemento che mi fornisce la business logic
    // Per una parte dell'applicazione
    public class ScaffoldingPersonService : IPersonService
    {
        // Implementazione del Singleton
        private static ScaffoldingPersonService _instance;

        public static ScaffoldingPersonService GetInstance()
        {
            if (_instance == null)
                _instance = new ScaffoldingPersonService();
            return _instance;

            // return instance ??= new ScoffoldingPersonService();
        }

        private List<Person> _people = new List<Person>
        { // Io vado a instanziare dei dati per vedere il funzionamento del server

            // definiamo delle proprietà, le graffe delimitano la mia lista, è un campo
            new Person
            {
                Id = 1,  Name = "Mario", Age = 25
            },
             new Person
            {
                Id = 2,  Name = "Paola", Age = 22
            },
              new Person
            {
                Id = 3,  Name = "Francesca", Age = 35
            },
        };


        private int _lastId = 4;
        public void AddPerson(Person person)
        {
            person.Id = _lastId++; // aggiungiamo la persona di id.. con l'autoincrement
            _people.Add(person);   // lo aggiungiamo l oggetto person a _people
        }

        public void DeletePerson(int id)
        {
            // quando è -1 vuol dire che non esiste l'oggetto ricercato
            var indexOfPerson = _people.FindIndex(p => p.Id == id);
            if(indexOfPerson >= 0)
            {
                _people.RemoveAt(indexOfPerson);
            }
            // pe rrimuovere
            // _people.RemoveAll(p => p.Id == id);

        }

        public List<Person> GetAll()
        {
            return _people;
        }

        public Person GetById(int id)
        {
            //linq

            return _people.Where(p => p.Id == id).FirstOrDefault();
            
            //WHere deriva da linq
            //  qui chiede di trovare nella lista people gli ogggetti di tipo p.Id che sia uguale all'id del metodo
            // La condizione deve essere rispettata, e siccome me ne serve uno posso mettere First
            // pero potremmo avere dei problemi in quanto se il predicato non mi restituisce nulla..
            // mi darebbe qualcosa/ Enumerable di vuoto  perciò meglio usare FirstOrDefault, il valore di default nel caso nell Enumerable 
            // non ci darebbe nulla


            


        }

        public void UpdatePerson(int id, Person person)
        {
            var indexOdExisting = _people.FindIndex(p => p.Id == id);
             if( indexOdExisting >= 0)
             {
                person.Id = id;
                _people[indexOdExisting] = person;
             }


        }
    }
}
