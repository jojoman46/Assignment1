using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaDataModel.Option
{
    public class YearTerm
    {
        [Key, Display(Name = "Year / Semester")]
        public int YearTermId { get; set; }
        public int Year { get; set; }
        public int Term { get; set; }
        public bool IsDefault { get; set; }
    }
}
