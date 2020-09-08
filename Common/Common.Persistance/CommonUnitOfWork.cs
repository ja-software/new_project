using Common.Application.Persistance;
using Common.Application.Persistance.Abstraction;
using Common.Persistance.Concrete;
using CrossCutting.Persistance.UnitOfWork;
using System.Threading.Tasks;

namespace UserManagement.Persistance
{
    public class CommonUnitOfWork : UnitOfWork, ICommonUnitOfWork
    {

        public CommonUnitOfWork(CommonDbContext context)
             : base(context)
        {
            this.Context = context;
        }

        ~CommonUnitOfWork()
        {
            Dispose(true);
        }

        private CommonDbContext Context { get; }

        ISystemSettingRepository systemSettingRepository;
        public ISystemSettingRepository SystemSettingRepository
        {
            get
            {
                if (systemSettingRepository == null)
                    systemSettingRepository = new SystemSettingRepository(Context);

                return systemSettingRepository;
            }
        }

        IAttachmentTypeRepository attachmentTypeRepository;
        public IAttachmentTypeRepository AttachmentTypeRepository
        {
            get
            {
                if (attachmentTypeRepository == null)
                    attachmentTypeRepository = new AttachmentTypeRepository(Context);

                return attachmentTypeRepository;
            }
        }

        IAttachmentRepository attachmentRepository;
        public IAttachmentRepository AttachmentRepository
        {
            get
            {
                if (attachmentRepository == null)
                    attachmentRepository = new AttachmentRepository(Context);

                return attachmentRepository;
            }
        }

        public new int Save()
        {
            //TODO : add audit trails code
            return base.Save();
        }

        public async new Task<int> SaveAsync()
        {
            //TODO : add audit trails code
            return await base.SaveAsync();
        }

    }
}
