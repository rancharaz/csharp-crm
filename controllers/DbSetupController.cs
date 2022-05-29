using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jpddoocp.models;

namespace jpddoocp.controllers
{
    class DbSetupController
    {
        public DbSetupController()
        {
            new DbSetupModel().SetupTables();
        }
    }
}
