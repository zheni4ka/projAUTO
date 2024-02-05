using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.Entities;
using DataAccess;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Services
{
    internal class AutosService : IAutosServices
    {
        private readonly IMapper mapper;
        private readonly CarSalonDbContext dbContext;
        public AutosService(IMapper mapper, CarSalonDbContext db)
        {
            this.mapper = mapper;
            dbContext = db;
        }
        public void Create(AutoDto product)
        {

            if (product != null)
            {
                dbContext.Autos.Add(mapper.Map<Auto>(product));
                dbContext.SaveChanges();
            }
            else return;

        }

        public void Remove(int id)
        {
            var tmp = dbContext.Autos.Find(id);
            if (tmp != null)
            {
                dbContext.Remove(tmp);
                dbContext.SaveChanges();
            }
            else return;
        }

        public void Edit(AutoDto auto)
        {
            dbContext.Autos.Update(mapper.Map<Auto>(auto));
            dbContext.SaveChanges();
        }

        public AutoDto? GetById(int id)
        {
            var item = dbContext.Autos.Find(id);
            if (item != null)
            {
                dbContext.Entry(item).Reference(x => x.Company).Load();
                return mapper.Map<AutoDto>(item);
            }
            else return null;
        }

        public IEnumerable<AutoDto> Get(IEnumerable<int> ids)
        {
            return mapper.Map<List<AutoDto>>(dbContext.Autos
                .Include(x => x.Company)
                .Where(x => ids.Contains(x.Id))
                .ToList());
        }

        public IEnumerable<AutoDto> GetAll()
        {
            return mapper.Map<List<AutoDto>>(dbContext.Autos.Include(x => x.Company).ToList());
        }

        public IEnumerable<CompanyDto> GetAllCompanies()
        {
            return mapper.Map<List<CompanyDto>>(dbContext.Companies.ToList());
        }

    }
}
