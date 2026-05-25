using ERP.Core.Database.Domain.Entities.Payrolls;

namespace ERP.Core.Database.Application.Commons.Interfaces.Repositories.Payrolls
{
    public interface IHolidaysRepository : IRepository<Holidays>
    {
        Task<Holidays> RegisterHoliday(Holidays deduction); 
    }
}