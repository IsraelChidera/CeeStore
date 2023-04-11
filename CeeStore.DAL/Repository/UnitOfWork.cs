﻿using Microsoft.EntityFrameworkCore;

namespace CeeStore.DAL.Repository
{
    public class UnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
        private Dictionary<Type, object> _repositories;
        private readonly TContext _context;

        public UnitOfWork(TContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories == null) _repositories = new Dictionary<Type, object>();

            var type = typeof(TEntity);
            if (!_repositories.ContainsKey(type)) _repositories[type] = new Repository<TEntity>(_context);
            return (IRepository<TEntity>)_repositories[type];
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }


    }

}
