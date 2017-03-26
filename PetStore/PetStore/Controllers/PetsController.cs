using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PetStore.Repositories;
using PetStore.Models;

namespace PetStore.Controllers
{
    public class PetsController : ApiController
    {
        private IPetStoreRepository _repository;

        public PetsController()
        {
            _repository = new PetStoreRepository(new Models.PetStoreContext());
        }
        public PetsController(IPetStoreRepository petRepository)
        {
            _repository = petRepository;
        }

        // GET: api/Pets1
        // GET All pets
        public IEnumerable<Pet> GetPets()
        {
            return _repository.GetAllPets();
        }

        // GET: api/Pets/5
        // GET Pet by id
        [ResponseType(typeof(Pet))]
        public IHttpActionResult GetPet(int id)
        {
            Pet pet = _repository.FindById(id);
            if (pet == null)
            {
                return NotFound();
            }

            return Ok(pet);
        }

        // POST: api/Pets
        // Create new pet details
        [ResponseType(typeof(Pet))]
        public IHttpActionResult PostPet(Pet pet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _repository.Add(pet);

            return CreatedAtRoute("DefaultApi", new { id = pet.Id }, pet);
        }

        // DELETE: api/Pets/5
        // Delete pet details
        [ResponseType(typeof(Pet))]
        public IHttpActionResult DeletePet(int id)
        {
            Pet pet = _repository.FindById(id);
            if (pet == null)
            {
                return NotFound();
            }
            _repository.Remove(id);

            return Ok(pet);
        }


    }
}