using DataAccessLayer.UnitsOfWorks;

namespace DataAccessLayer
{
    public interface IDalService
    {

        IUnitOfWork CreateUnitOfWork();

        IReadOnlyUnitOfWork GetReadOnlyUnitOfWork();
    }
   
    
    public class DalService :IDalService
    {
        private readonly IUnitOfWork _unit;
        
        public DalService(IUnitOfWork unit)
        {
           _unit = unit;
        }


        public IUnitOfWork CreateUnitOfWork() 
        {
            return _unit.CreateNew();
        }

        public IReadOnlyUnitOfWork GetReadOnlyUnitOfWork()
        {
            return _unit.CreateNew();
        }
    }


}
