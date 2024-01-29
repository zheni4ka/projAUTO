using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class AutoDto
    {
        public int Id { get; set; }
        public string Mark { get; set; }
        public string Model { get; set; }
        public int Speed { get; set; }
        public int YearRelease { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int CompanyId { get; set; }
        public Company? Company { get; set; }
        public string ImgURL { get; set; }
    }
}
