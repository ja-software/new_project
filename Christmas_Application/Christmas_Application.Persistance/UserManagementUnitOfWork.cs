using System;
using System.Threading.Tasks;
using UserManagement.Application.Persistance;
using UserManagement.Application.Persistance.Abstraction;
using UserManagement.Persistance.Concrete;

namespace UserManagement.Persistance
{
    public class UserManagementUnitOfWork :IUserManagementUnitOfWork
    {

        public UserManagementUnitOfWork(ApplicationDbContext context)
        {
            this.Context = context;
        }

        ~UserManagementUnitOfWork()
        {
            Dispose(true);
        }

        private ApplicationDbContext Context { get; }

        #region Repositories

        IPolicyRepository policyRepository;
        public IPolicyRepository PolicyRepository
        {
            get
            {
                if (policyRepository == null)
                    policyRepository = new PolicyRepository(Context);

                return policyRepository;
            }
        }


        IApplicationPolicyRoleRepository applicationPolicyRoleRepository;
        public IApplicationPolicyRoleRepository ApplicationPolicyRoleRepository
        {
            get
            {
                if (applicationPolicyRoleRepository == null)
                    applicationPolicyRoleRepository = new ApplicationPolicyRoleRepository(Context);

                return applicationPolicyRoleRepository;
            }
        }

        #endregion


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
