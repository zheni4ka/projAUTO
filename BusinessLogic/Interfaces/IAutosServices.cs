using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces
{
    public interface IAutosServices
    {
        IEnumerable<AutoDto> GetAll();
        IEnumerable<AutoDto> Get(IEnumerable<int> ids);
        AutoDto? GetById(int id);
        void Create(CreateAutoModel model);
        void Edit(AutoDto auto);
        void Remove(int id);
    }
}
