enable-migrations -ContextTypeName OptionContext -MigrationsDirectory Migrations\OptionContext

add-migration -ConfigurationTypeName Courses.Web.Migrations.CourseMigrations.Configuration "InitialCreate"

update-database -ConfigurationTypeName Courses.Web.Migrations.CourseMigrations.Configuration