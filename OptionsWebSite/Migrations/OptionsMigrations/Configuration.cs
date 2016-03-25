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
                new YearTerm { Year=2015,Term=20,IsDefault=false},
                new YearTerm { Year=2015,Term=30,IsDefault=false},
                new YearTerm { Year=2016,Term=10,IsDefault=false},
                new YearTerm { Year=2016,Term=30,IsDefault=true}
            };
            context.YearTerms.AddOrUpdate(s => s.YearTermId, yearTerms.ToArray());

            List<Option> options = new List<Option>()
            {
                new Option {Title="Data Communications",IsActive=true },
                new Option {Title="Client Server",IsActive=true },
                new Option {Title="Digital Processing",IsActive=true },
                new Option {Title="Information Systems",IsActive=true },
                new Option {Title="Database",IsActive=false },
                new Option {Title="Web & Mobile",IsActive=true },
                new Option {Title="Tech Pro",IsActive=false },
            };
            context.Options.AddOrUpdate(o => o.OptionId, options.ToArray());

            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice
            {
                ChoiceId = 1,
                YearTermId = 4,
                StudentId = "A00111111",
                StudentFirstName = "John",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 2,
                ThirdChoiceOptionId = 3,
                FourthChoiceOptionId = 4,
                SelectionDate = DateTime.Now
            });

            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice
            {
                ChoiceId = 2,
                YearTermId = 4,
                StudentId = "A00222222",
                StudentFirstName = "James",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 2,
                ThirdChoiceOptionId = 3,
                FourthChoiceOptionId = 4,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice
            {
                ChoiceId = 3,
                YearTermId = 4,
                StudentId = "A00333333",
                StudentFirstName = "Jeff",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 3,
                ThirdChoiceOptionId = 2,
                FourthChoiceOptionId = 6,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice
            {
                ChoiceId = 4,
                YearTermId = 4,
                StudentId = "A00444444",
                StudentFirstName = "Jane",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 2,
                ThirdChoiceOptionId = 3,
                FourthChoiceOptionId = 6,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice
            {
                ChoiceId = 5,
                YearTermId = 4,
                StudentId = "A00555555",
                StudentFirstName = "Jim",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 2,
                ThirdChoiceOptionId = 6,
                FourthChoiceOptionId = 4,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice
            {
                ChoiceId = 6,
                YearTermId = 4,
                StudentId = "A00666666",
                StudentFirstName = "Janice",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 6,
                ThirdChoiceOptionId = 4,
                FourthChoiceOptionId = 2,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice
            {
                ChoiceId = 7,
                YearTermId = 4,
                StudentId = "A00777777",
                StudentFirstName = "Jenny",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 2,
                ThirdChoiceOptionId = 3,
                FourthChoiceOptionId = 4,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice
            {
                ChoiceId = 8,
                YearTermId = 4,
                StudentId = "A00888888",
                StudentFirstName = "Jox",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 2,
                ThirdChoiceOptionId = 3,
                FourthChoiceOptionId = 4,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice
            {
                ChoiceId = 9,
                YearTermId = 4,
                StudentId = "A00999999",
                StudentFirstName = "Jan",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 3,
                ThirdChoiceOptionId = 6,
                FourthChoiceOptionId = 4,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice
            {
                ChoiceId = 10,
                YearTermId = 4,
                StudentId = "A00101010",
                StudentFirstName = "Johnny",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 4,
                ThirdChoiceOptionId = 2,
                FourthChoiceOptionId = 3,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice
            {
                ChoiceId = 11,
                YearTermId = 3,
                StudentId = "A00111111",
                StudentFirstName = "Jeremy",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 2,
                ThirdChoiceOptionId = 3,
                FourthChoiceOptionId = 4,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice
            {
                ChoiceId = 12,
                YearTermId = 3,
                StudentId = "A00222222",
                StudentFirstName = "Justin",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 2,
                ThirdChoiceOptionId = 6,
                FourthChoiceOptionId = 4,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice
            {
                ChoiceId = 13,
                YearTermId = 3,
                StudentId = "A00333333",
                StudentFirstName = "Jupiter",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 2,
                ThirdChoiceOptionId = 6,
                FourthChoiceOptionId = 4,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice
            {
                ChoiceId = 14,
                YearTermId = 3,
                StudentId = "A00444444",
                StudentFirstName = "Jerimiah",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 3,
                ThirdChoiceOptionId = 2,
                FourthChoiceOptionId = 4,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice
            {
                ChoiceId = 15,
                YearTermId = 3,
                StudentId = "A00555555",
                StudentFirstName = "Jered",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 7,
                ThirdChoiceOptionId = 4,
                FourthChoiceOptionId = 2,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice
            {
                ChoiceId = 16,
                YearTermId = 3,
                StudentId = "A00666666",
                StudentFirstName = "Jacky",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 2,
                ThirdChoiceOptionId = 7,
                FourthChoiceOptionId = 4,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice
            {
                ChoiceId = 17,
                YearTermId = 3,
                StudentId = "A00777777",
                StudentFirstName = "Joanne",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 4,
                ThirdChoiceOptionId = 7,
                FourthChoiceOptionId = 2,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice
            {
                ChoiceId = 18,
                YearTermId = 3,
                StudentId = "A00888888",
                StudentFirstName = "Jonnah",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 3,
                ThirdChoiceOptionId = 2,
                FourthChoiceOptionId = 7,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice
            {
                ChoiceId = 19,
                YearTermId = 3,
                StudentId = "A00999999",
                StudentFirstName = "Jedidiah",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 1,
                SecondChoiceOptionId = 4,
                ThirdChoiceOptionId = 2,
                FourthChoiceOptionId = 7,
                SelectionDate = DateTime.Now
            });
            context.Choices.AddOrUpdate(c => c.ChoiceId, new Choice
            {
                ChoiceId = 20,
                YearTermId = 3,
                StudentId = "A00202020",
                StudentFirstName = "Jay",
                StudentLastName = "Smith",
                FirstChoiceOptionId = 5,
                SecondChoiceOptionId = 4,
                ThirdChoiceOptionId = 3,
                FourthChoiceOptionId = 2,
                SelectionDate = DateTime.Now
            });
            context.SaveChanges();
        }
    }
}
