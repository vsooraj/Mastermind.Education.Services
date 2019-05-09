using Mastermind.Education.Services.ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mastermind.Education.Services.Entities
{
    public class Course : BaseEntity
    {
        public string Name { get; set; }
        public int NoOfDays { get; set; }
    }
}
