using CityInfo_8_0_TestSetup.Setup;
using CityInfo_8_0_TestSetup.ViewModels;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.Web.CodeGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo_8_0_TestSetup.Database
{
    public class TestDatabaseFixture
    {
        public DatabaseViewModel DatabaseViewModelObject;
        public static string ?ConnectionString;
        //public const string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=CityInfoDB_Core_8_0_Module_Test;User ID=ltpe2;Password=buchwald34";
        //public const string ConnectionString = "Server=sql.itcn.dk;Database=ltpe5.TCAA;User ID=ltpe.TCAA;Password=5uF68R0Tbt;TrustServerCertificate=True";
        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        private readonly IConfiguration _configuration;

        private static bool IsDevelopment()
        { 
            return (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development");
        }

        // Kode her bliver kun kaldt én gang for hver Test klasse fil. 

        public TestDatabaseFixture()
        {
            if (IsDevelopment())
            {
                ConnectionString = MyConst.DatabaseConnectionStringDevelopment;
                //var builder = new ConfigurationBuilder()
                //    .SetBasePath(System.IO.Directory.GetCurrentDirectory())
                //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                //_configuration = builder.Build();
                //DatabaseContext.SQLConnectionString = _configuration.GetConnectionString("cityInfoDBConnectionString");
            }
            else
            {
                //DatabaseContext.SQLConnectionString = ConnectionString;
                ConnectionString = MyConst.DatabaseConnectionStringRelease;
            }

            Task.Run(async () =>
            {
                //lock (_lock)
                //{
                    if (!_databaseInitialized)
                    {
                        var context = CreateContext();
                        if (IsDevelopment())
                        {
                            await context.Database.EnsureDeletedAsync();
                            await context.Database.EnsureCreatedAsync();
                        }
                        else
                        {
                            try
                            {
                                context.Core_8_0_CityLanguages.RemoveRange(context.Core_8_0_CityLanguages);
                                context.Core_8_0_Languages.RemoveRange(context.Core_8_0_Languages);
                                context.Core_8_0_PointsOfInterest.RemoveRange(context.Core_8_0_PointsOfInterest);
                                context.Core_8_0_Cities.RemoveRange(context.Core_8_0_Cities);
                                context.Core_8_0_Countries.RemoveRange(context.Core_8_0_Countries);
                                await context.SaveChangesAsync();
                            } 
                            catch (Exception Error)
                            { 
                                string ErrorString = Error.ToString();
                            }
                        }

                    //await context.Database.ExecuteSqlRawAsync($"SET FOREIGN_KEY_CHECKS = 0; TRUNCATE TABLE [Core_8_0_CityLanguages]");
                    //await context.Database.ExecuteSqlRawAsync($"SET FOREIGN_KEY_CHECKS = 0; TRUNCATE TABLE [Core_8_0_PointsOfInterest]");
                    //await context.Database.ExecuteSqlRawAsync($"SET FOREIGN_KEY_CHECKS = 0; TRUNCATE TABLE [Core_8_0_Languages]");
                    //await context.Database.ExecuteSqlRawAsync($"SET FOREIGN_KEY_CHECKS = 0; TRUNCATE TABLE [Core_8_0_Cities]");
                    //await context.Database.ExecuteSqlRawAsync($"SET FOREIGN_KEY_CHECKS = 0; TRUNCATE TABLE [Core_8_0_Countries]");

                    //var tableNames = context.Model.GetEntityTypes()
                    //    .Select(t => t.GetTableName())
                    //    .Distinct()
                    //    .ToList();

                    //foreach (var tableName in tableNames)
                    //{
                    //    await context.Database.ExecuteSqlRawAsync($"SET FOREIGN_KEY_CHECKS = 0; TRUNCATE TABLE `{tableName}`;");
                    //}

                    DatabaseViewModelObject = new DatabaseViewModel();
                        await SetupDatabaseData.SeedDatabaseDataWithObject(context, DatabaseViewModelObject);
                       
                        _databaseInitialized = true;
                    }
                  //}
            }).GetAwaiter().GetResult();
        }

        public DatabaseContext CreateContext()
            => new SQLDatabaseUnitTestDatabaseContext(
                new DbContextOptionsBuilder<DatabaseContext>()
                    .UseSqlServer(ConnectionString)
                    .Options, null);
    }
}
