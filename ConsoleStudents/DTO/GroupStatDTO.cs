using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleStudents.DTO
{
    public class GroupStatDTO
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public int? IdSpecial { get; set; }

        public int StudentCount { get; set; }
    }
}
