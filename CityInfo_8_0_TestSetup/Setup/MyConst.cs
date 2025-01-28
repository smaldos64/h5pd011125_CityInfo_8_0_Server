using Azure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityInfo_8_0_TestSetup.Setup
{
    public static class MyConst
    {
        public const string UnitTestUserName = "LTPE_UnitTest";
        public const string IntegrationTestUserName = "LTPE_IntegrationTest";

        public const string ControllerAndMethodForDetermingEnvironment = "api/BuildInfo/configuration";
        public const string DatabaseConnectionStringDevelopment = "Server=(localdb)\\mssqllocaldb;Database=CityInfoDB_Core_8_0_Module_Test;User ID=ltpe2;Password=buchwald34";
        public const string DatabaseConnectionStringRelease = "Server=sql.itcn.dk;Database=ltpe5.TCAA;User ID=ltpe.TCAA;Password=5uF68R0Tbt;TrustServerCertificate=True";
    }
}
