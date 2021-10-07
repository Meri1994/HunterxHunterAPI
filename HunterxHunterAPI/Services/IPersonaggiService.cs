using HunterxHunterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HunterxHunterAPI.Services
{
    interface IPersonaggiService
    {

        //Elenco
        List<Personaggi> GetAll();
        //Cerca
        Personaggi GetById(int id);
        //Insert
        bool AddPersonaggio(Personaggi p);
        //Modifica
        bool UpdatePersonaggio(int id, Personaggi p);
        //Elimina
        bool DeletePersonaggio(int id);

    }
}
