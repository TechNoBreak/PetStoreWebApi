using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetStore.Repositories;
using System.Data.Entity;
using System.Linq.Expressions;
using PetStore.Models;
using System.Data;



namespace PetStore.Repositories 
{
    public class PetStoreRepository : IPetStoreRepository
    {
        private readonly PetStoreContext _context;
        public PetStoreRepository(PetStoreContext context)
        {
            _context = context;
        }

        public IEnumerable<Pet> GetAllPets()
        {
            return _context.Pets.ToList();
        }
        public Pet FindById(int studentId)
        {
            return _context.Pets.Find(studentId);
        }

        public int Add(Pet petEntity)
        {
            int result = -1;
            if (petEntity != null)
            {
                _context.Pets.Add(petEntity);
                _context.SaveChanges();
                result = petEntity.Id;
            }
            return result;

        }

        public void Remove(int id)
        {
            Pet petEntity = _context.Pets.Find(id);
            _context.Pets.Remove(petEntity);
            _context.SaveChanges();

        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
    //[Dependency]
    //public class PetStoreRepository<TEntity> : IPetStoreRepository<Pet, int>
    //{
      
    //    public PetStoreEntities context { get; set; }

    //    public IEnumerable<Pet> Get()
    //    {
    //        return context.Pets.ToList();
    //    }

    //    public Pet Get(int id)
    //    {
    //        return context.Pets.Find(id);
    //    }

    //    public void Add(Pet entity)
    //    {
    //        context.Pets.Add(entity);
    //        context.SaveChanges();
    //    }

    //    public void Remove(Pet entity)
    //    {
    //        var obj = context.Pets.Find(entity.Id);
    //        context.Pets.Remove(obj);
    //        context.SaveChanges();
    //    }

        //protected readonly DbContext Context;

        //public PetStoreRepository(DbContext context)
        //{
        //    Context = context;
        //}

        //public TEntity Get(int id)
        //{
        //    return Context.Set<TEntity>().Find(id);
        //}

        //public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        //{
        //    return Context.Set<TEntity>().Where(predicate);
        //}

        //public void Add(TEntity entity)
        //{
        //    Context.Set<TEntity>().Add(entity);
        //}
    //}
}