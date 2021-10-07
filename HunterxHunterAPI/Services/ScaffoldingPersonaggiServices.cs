using HunterxHunterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Utility;

namespace HunterxHunterAPI.Services
{
    public class ScaffoldingPersonaggiServices : IPersonaggiService
    {

        private Database db;

        private static ScaffoldingPersonaggiServices _instance;

        private ScaffoldingPersonaggiServices ()
        {
            db = new Database("hunterxhunter");

        }

        public static ScaffoldingPersonaggiServices GetInstance()
        {
            if (_instance == null)
                _instance = new ScaffoldingPersonaggiServices();
            return _instance;

        }


        public bool AddPersonaggio(Personaggi p)
        {
            string query = $"insert into personaggi ( nome, potenza, dob) values" +
                $"('{p.Name}', {p.Power}, '{p.Dob.Year}-{p.Dob.Month}-{p.Dob.Day}')";


            return db.Update(query);
          
        }

        public bool DeletePersonaggio(int id)
        {
            string query = $"delete from personaggi where id = {id}";

            return db.Update(query);
        }

        public List<Personaggi> GetAll()
        {
            List<Personaggi> ris = new List<Personaggi>();

            string query = "select * from personaggi";

            List<Dictionary<string,string>> righe = db.Read(query);

            foreach(Dictionary<string,string> riga in righe)
            {
                Personaggi p = new Personaggi();
                p.FromDictionary(riga);

                ris.Add(p);
            }
            return ris;
        }

        public Personaggi GetById(int id)
        {
            string query = $"select * from personaggi where id =  {id} ";
            Dictionary<string, string> riga = db.ReadOne(query);

            Personaggi p = new Personaggi();

            p.FromDictionary(riga);

            return p;


            
        }

        public bool UpdatePersonaggio(int id,  Personaggi p)
        {

            return db.Update($"update personaggi set nome = '{p.Name}', potenza = {p.Power},  '{p.Dob}' where id = {p.Id};" );
        }
    }
}
