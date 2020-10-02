using assessment_server_side.EntityDataSource;
using assessment_server_side.Repository;
using assessment_server_side.Utils;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTest
{
    class PersonContextsTest
    {
        [Test]
        public void EnsureFillingUpDB()
        {
            try
            {
                var csvFile = new FavouriteColorCSVFileRepository();
                var test = csvFile.GetPeople();

                PersonsContext pc = new PersonsContext();

                //Dumb cleaning
                pc.Database.ExecuteSqlCommand("delete  from  [Person];");
                pc.Database.ExecuteSqlCommand("delete  from  [Color];");


            
                pc.Colors.AddRange(UtilColor.Colors);
                pc.Persons.AddRange(test);
                pc.SaveChanges();
                Assert.IsTrue(true);
            }
            catch (Exception )
            {
                Assert.IsTrue(false);
            }
        }
    }
}
