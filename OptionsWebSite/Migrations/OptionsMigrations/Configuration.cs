namespace OptionsWebSite.Migrations.OptionsMigrations
{
    using DiplomaDataModel.Option;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DiplomaDataModel.Option.OptionContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\OptionsMigrations";
        }

        protected override void Seed(DiplomaDataModel.Option.OptionContext context)
        {
            List<YearTerm> yearTerms = new List<YearTerm>()
            {
                new YearTerm { YearTermId = 1, Year=2015,Term=20,IsDefault=false},
                new YearTerm { YearTermId = 2, Year=2015,Term=30,IsDefault=false},
                new YearTerm { YearTermId = 3, Year=2016,Term=10,IsDefault=false},
                new YearTerm { YearTermId = 4, Year=2016,Term=30,IsDefault=true}
            };
            context.YearTerms.AddOrUpdate(s => s.YearTermId, yearTerms.ToArray());

            List<Option> options = new List<Option>()
            {
                new Option {OptionId = 1,Title="Data Communications",IsActive=true },
                new Option {OptionId = 2,Title="Client Server",IsActive=true },
                new Option {OptionId = 3,Title="Digital Processing",IsActive=true },
                new Option {OptionId = 4,Title="Information Systems",IsActive=true },
                new Option {OptionId = 5,Title="Database",IsActive=false },
                new Option {OptionId = 6,Title="Web & Mobile",IsActive=true },
                new Option {OptionId = 7,Title="Tech Pro",IsActive=false },
            };
            context.Options.AddOrUpdate(o => o.OptionId, options.ToArray());




            List<Choice> choices = new List<Choice>()
            {
                new Choice {ChoiceId= 1, YearTermId= 2, StudentId= "A00000001", StudentFirstName= "Alliam", StudentLastName= "Dabson", FirstChoiceOptionId= 1, SecondChoiceOptionId= 7, ThirdChoiceOptionId= 4, FourthChoiceOptionId= 3, SelectionDate=  DateTime.Now},
                new Choice {ChoiceId= 2, YearTermId= 2, StudentId= "A00000002", StudentFirstName= "Billiam", StudentLastName= "Dab", FirstChoiceOptionId= 2, SecondChoiceOptionId= 6, ThirdChoiceOptionId= 4, FourthChoiceOptionId= 1, SelectionDate=  DateTime.Now},
                new Choice {ChoiceId= 3, YearTermId= 2, StudentId= "A00000003", StudentFirstName= "Carlliam", StudentLastName="Dabocious" , FirstChoiceOptionId= 3, SecondChoiceOptionId= 5, ThirdChoiceOptionId= 4, FourthChoiceOptionId= 2, SelectionDate=  DateTime.Now},
                new Choice {ChoiceId= 4, YearTermId= 2, StudentId= "A00000004", StudentFirstName= "Dilliam", StudentLastName= "Daberla", FirstChoiceOptionId= 4, SecondChoiceOptionId= 3, ThirdChoiceOptionId= 5, FourthChoiceOptionId= 6, SelectionDate=  DateTime.Now},
                new Choice {ChoiceId= 5, YearTermId= 2, StudentId= "A00000005", StudentFirstName= "Elliam", StudentLastName= "Dabba", FirstChoiceOptionId= 5, SecondChoiceOptionId= 4, ThirdChoiceOptionId= 3, FourthChoiceOptionId= 7, SelectionDate=  DateTime.Now},
                new Choice {ChoiceId= 6, YearTermId= 2, StudentId= "A00000006", StudentFirstName= "Filliam", StudentLastName= "Dabdoo", FirstChoiceOptionId= 6, SecondChoiceOptionId= 2, ThirdChoiceOptionId= 3, FourthChoiceOptionId= 4, SelectionDate=  DateTime.Now},
                new Choice {ChoiceId= 7, YearTermId= 2, StudentId= "A00000007", StudentFirstName= "Gilliam", StudentLastName= "Dabbad", FirstChoiceOptionId= 7, SecondChoiceOptionId= 1, ThirdChoiceOptionId= 3, FourthChoiceOptionId= 4, SelectionDate=  DateTime.Now},
                new Choice {ChoiceId= 8, YearTermId= 2, StudentId= "A00000008", StudentFirstName= "Hilliam", StudentLastName= "Dabby", FirstChoiceOptionId= 6, SecondChoiceOptionId= 2, ThirdChoiceOptionId= 3, FourthChoiceOptionId= 4, SelectionDate=  DateTime.Now},
                new Choice {ChoiceId= 9, YearTermId= 2, StudentId= "A00000009", StudentFirstName= "Igor", StudentLastName= "Smith", FirstChoiceOptionId= 5, SecondChoiceOptionId= 3, ThirdChoiceOptionId= 4, FourthChoiceOptionId= 2, SelectionDate=  DateTime.Now},
                new Choice {ChoiceId= 10, YearTermId= 2, StudentId= "A00000010", StudentFirstName= "Jilliam", StudentLastName= "Dabrin", FirstChoiceOptionId=4, SecondChoiceOptionId= 5, ThirdChoiceOptionId= 3, FourthChoiceOptionId= 1, SelectionDate=  DateTime.Now},
                new Choice {ChoiceId= 11, YearTermId= 3, StudentId= "A00000011", StudentFirstName= "Killiam", StudentLastName= "Dabsious", FirstChoiceOptionId=3, SecondChoiceOptionId= 4, ThirdChoiceOptionId= 2, FourthChoiceOptionId= 1, SelectionDate=  DateTime.Now},
                new Choice {ChoiceId= 12, YearTermId= 3, StudentId= "A00000012", StudentFirstName= "Lilliam", StudentLastName= "Dablina", FirstChoiceOptionId=2, SecondChoiceOptionId= 6, ThirdChoiceOptionId= 1, FourthChoiceOptionId= 4, SelectionDate=  DateTime.Now},
                new Choice {ChoiceId= 13, YearTermId= 3, StudentId= "A00000013", StudentFirstName= "Milliam", StudentLastName= "Dablino", FirstChoiceOptionId=1, SecondChoiceOptionId= 7, ThirdChoiceOptionId= 2, FourthChoiceOptionId= 3, SelectionDate=  DateTime.Now},
                new Choice {ChoiceId= 14, YearTermId= 3, StudentId= "A00000014", StudentFirstName= "Nilliam", StudentLastName= "Dabchu", FirstChoiceOptionId=2, SecondChoiceOptionId= 6, ThirdChoiceOptionId= 1, FourthChoiceOptionId= 3, SelectionDate=  DateTime.Now},
                new Choice {ChoiceId= 15, YearTermId= 3, StudentId= "A00000015", StudentFirstName= "Olliam", StudentLastName= "Dabjunior", FirstChoiceOptionId=3, SecondChoiceOptionId= 5, ThirdChoiceOptionId= 2, FourthChoiceOptionId= 1, SelectionDate=  DateTime.Now},
                new Choice {ChoiceId= 16, YearTermId= 3, StudentId= "A00000016", StudentFirstName= "Philliam", StudentLastName= "Dabiel", FirstChoiceOptionId=4, SecondChoiceOptionId= 3, ThirdChoiceOptionId= 2, FourthChoiceOptionId= 1, SelectionDate=  DateTime.Now},
                new Choice {ChoiceId= 17, YearTermId= 3, StudentId= "A00000017", StudentFirstName= "Quilliam", StudentLastName= "Dabpras", FirstChoiceOptionId=5, SecondChoiceOptionId= 4, ThirdChoiceOptionId= 2, FourthChoiceOptionId= 1, SelectionDate=  DateTime.Now},
                new Choice {ChoiceId= 18, YearTermId= 3, StudentId= "A00000018", StudentFirstName= "Rilliam", StudentLastName= "DabDabDab", FirstChoiceOptionId=6, SecondChoiceOptionId= 2, ThirdChoiceOptionId= 1, FourthChoiceOptionId= 3, SelectionDate=  DateTime.Now},
                new Choice {ChoiceId= 19, YearTermId= 3, StudentId= "A00000019", StudentFirstName= "Silliam", StudentLastName= "Dabyumsum", FirstChoiceOptionId=7, SecondChoiceOptionId= 1, ThirdChoiceOptionId= 2, FourthChoiceOptionId= 3, SelectionDate=  DateTime.Now},
                new Choice {ChoiceId= 20, YearTermId= 3, StudentId= "A00000020", StudentFirstName= "Tilliam", StudentLastName= "Dabluz", FirstChoiceOptionId=6, SecondChoiceOptionId= 2, ThirdChoiceOptionId= 7, FourthChoiceOptionId= 3, SelectionDate=  DateTime.Now},

            };
            context.Choices.AddOrUpdate(c => c.ChoiceId, choices.ToArray());
        }
    }
}
