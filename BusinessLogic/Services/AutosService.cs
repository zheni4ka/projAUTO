using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces
{
    public interface IAutosService
    {
        IEnumerable<AutoDto> GetAll();
        AutoDto? GetById(int id);
        int GetCount();
        IEnumerable<CompanyDto> GetCompanies();
        void Create(CreateAutoModel model);
        void 

    }
}
