using assessment_server_side.Repository;

using assessment_server_side.Exceptions;
using NUnit.Framework;
using NUnitTest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

using assessment_server_side.Models;

namespace NUnitTest
{
    class CSVRepository
    {

        [Test]
        public void EnsureGetPeopleReturnsAllRecordsProperly()
        {
            FavouriteColorCSVFileRepository favCSVFileRepo = new FavouriteColorCSVFileRepository();
            var peopleTest = favCSVFileRepo.GetPeople();
            Assert.IsTrue(peopleTest.Count() >= 10);
        }

        [Test]
        public void EnsureGetPersonWorksProperly()
        {
            FavouriteColorCSVFileRepository favCSVFileRepo = new FavouriteColorCSVFileRepository();
            var person = favCSVFileRepo.GetPerson(2);
            Assert.IsTrue(person.Id == 2);
        }
        [Test]
        public void EnsureGetPersonDealsWithUnknownIdProperly()
        {
            FavouriteColorCSVFileRepository favCSVFileRepo = new FavouriteColorCSVFileRepository();
            try
            {
                var person = favCSVFileRepo.GetPerson(322);
                Assert.IsTrue(false);
            }
            catch (PersonNotExistException)
            {
                Assert.IsTrue(true);
            }
        }
        [Test]
        public void EnsureGetPersonByColorWorksProperly()
        {
            FavouriteColorCSVFileRepository favCSVFileRepo = new FavouriteColorCSVFileRepository();
            var person = favCSVFileRepo.GetPeopleByColor("blau");
            Assert.IsTrue(person.Count() >= 2);
        }
        [Test]
        public void EnsureGetPersonByColorDealsWithUknownStringsProperly()
        {
            try
            {
                FavouriteColorCSVFileRepository favCSVFileRepo = new FavouriteColorCSVFileRepository();
                var person = favCSVFileRepo.GetPeopleByColor("blauklasjdlkasjdlsakdjsalkdj");
                Assert.IsTrue(false);
            }
            catch (ColorNotExistException)
            {
                Assert.IsTrue(true);
            }
        }
        [Test]
        public void EnsureSavePeopleWorksProperly()
        {
          
                FavouriteColorCSVFileRepository favCSVFileRepo = new FavouriteColorCSVFileRepository();
                var ps = new List<Person>() { new Person() { Id = 10, Name = "John", Lastname = "Doe", City = "Sky", Zipcode = "12345", FavColourId = 1 } };
                var ok = favCSVFileRepo.SavePeople(ps);
                Assert.IsTrue(ok);
           
        }
        [Test]
        public void EnsureSavePeopleDealsWithNullColorProperly()
        {
            try
            {
                FavouriteColorCSVFileRepository favCSVFileRepo = new FavouriteColorCSVFileRepository();
                var ps = new List<Person>() { new Person() { Id = 10, Name = "John", Lastname = "Doe", City = "Sky", Zipcode = "12345"} };
                var ok = favCSVFileRepo.SavePeople(ps);
                Assert.IsTrue(false);
            }
            catch (ColorIsNullException)
            {
                Assert.IsTrue(true);
            }
        }
        [Test]
        public void EnsureSavePeopleDealsWithEmptyPeopleInputProperly()
        {
            try
            {
                FavouriteColorCSVFileRepository favCSVFileRepo = new FavouriteColorCSVFileRepository();
                var ps = new List<Person>();
                var ok = favCSVFileRepo.SavePeople(ps);
                Assert.IsTrue(false);
            }
            catch (NoPeopleForUpdateException)
            {
                Assert.IsTrue(true);
            }
        }
    }
}
