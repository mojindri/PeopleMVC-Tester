using assessment_server_side.CSVDataSource;
using assessment_server_side.Models;
using assessment_server_side.Models.Factory;
using NUnit.Framework;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NUnitTest
{
    public class CsvDataSourceTest
    {


        [Test]
        public void CSVFileDataSourceReadTest()
        {
            CSVFIleDataSource cSVFIleDataSource = new CSVFIleDataSource();
            var list = cSVFIleDataSource.ReadAll();
            Assert.IsTrue(list.Count() == 10);
        }

        [Test]
        public void CheckAccessToCSVFile()
        {
            CSVFIleDataSource cSVFIleDataSource = new CSVFIleDataSource();
            var b = File.Exists(cSVFIleDataSource.CSVFilePath);
            Assert.IsTrue(b);
        }
        [Test]
        public void WritePersonsToCSVFile()
        {
            CSVFIleDataSource cSVFIleDataSource = new CSVFIleDataSource();
            var res = cSVFIleDataSource.WriteAll(new List<Person>() {
                new Person (){Id=10,Name="John",Lastname="Doe",City="Sky",Zipcode="12345",FavColourId=1}
            });

            Assert.IsTrue(res);
        }

    }
}