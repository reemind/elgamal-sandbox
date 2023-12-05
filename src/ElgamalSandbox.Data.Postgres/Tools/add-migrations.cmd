// ef commands templates for the Rider's terminal
// замените ${Name} на название вашей миграции

cd src/Bars.ReformaGKH.OtherObjects.Api.Data.PostgreSql
dotnet restore
dotnet ef -h
dotnet ef migrations add ${Name} --verbose --project ../../src/Bars.ReformaGKH.OtherObjects.Api.Data.PostgreSql --startup-project ../../src/Bars.ReformaGKH.OtherObjects.Api.Data.Migrator
dotnet ef database update --verbose --project ../../src/Bars.ReformaGKH.OtherObjects.Api.Data.PostgreSql --startup-project ../../src/Bars.ReformaGKH.OtherObjects.Api.Data.Migrator
