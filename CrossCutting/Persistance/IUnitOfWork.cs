using System.Threading.Tasks;

namespace CrossCutting.Persistance
{
    public  interface IUnitOfWork
    {
        int Save();
        Task<int> SaveAsync();
    }
}
