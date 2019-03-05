using AnalysisTool.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AnalysisTool.Services
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoCollection<TEntity> _context;

        public Repository(IMongoCollection<TEntity> context) {
            _context = context;
            
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {            
            return _context.Find(predicate).SingleOrDefault();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _context.Find(assessment => true).ToList();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Find(predicate).ToEnumerable();
        }

        public void Add(TEntity entity)
        {
            _context.InsertOne(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            foreach(var entity in entities)
            {
                _context.InsertOne(entity);
            }
        }        


        public void Remove(TEntity entity)
        {
            _context.DeleteOne(context => context == entity);            
        }

        

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            foreach(var entity in entities)
            {
                _context.DeleteOne(context => context == entity);
            }
        }




    }
}
