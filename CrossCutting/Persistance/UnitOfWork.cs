using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace CrossCutting.Persistance.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork 
    {

        public UnitOfWork(DbContext context)
        {
            this.Context = context;
        }

        ~UnitOfWork()
        {
            Dispose(true);
        }

        private DbContext Context { get; }

        
        public int Save()
        {
            return this.Context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await this.Context.SaveChangesAsync();
        }


        private bool disposed = false;

        public void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
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

}
