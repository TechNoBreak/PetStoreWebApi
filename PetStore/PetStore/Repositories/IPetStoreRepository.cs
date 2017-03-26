using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;

using PetStore.Models;
using System.Linq;


namespace PetStore.Repositories
{

    public interface IPetStoreRepository : IDisposable
    {
        IEnumerable<Pet> GetAllPets();
        Pet FindById(int studentId);
        int Add(Pet petEntity);
        void Remove(int petId);
    }
    
}