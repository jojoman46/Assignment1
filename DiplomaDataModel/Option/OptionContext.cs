using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiplomaDataModel.Option
{
    public class OptionContext : DbContext
    {
        public OptionContext() : base("DefaultConnection") { }

        public DbSet<Choice> Choices { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<YearTerm> YearTerms { get; set; }
    }
}
