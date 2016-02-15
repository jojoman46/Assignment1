using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaDataModel.Option
{
    public class Option
    {
        [Key]
        public int OptionId { get; set; }
        [MaxLength(50)]
        public string Title { get; set; }
        public bool IsActive { get; set; }
    }
}
