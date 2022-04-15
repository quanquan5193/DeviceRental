using Autofac;
using DeviceRental.Repositories;
using System.Threading.Tasks;

namespace DeviceRental.Handler.ModelHandles.Queries
{
    public class GetListEmployeeQuery : ICommand
    {
    }

    public class GetListEmployeeQueryHandler
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetListEmployeeQueryHandler()
        {
            _employeeRepository = Program.Container.Resolve<IEmployeeRepository>();
        }

        public async Task<ResultObject> Handle(ICommand command)
        {
            var result = await _employeeRepository.GetAll();
            return new ResultObject() { IsSuccess = true, Result = result };
        }
    }
}
