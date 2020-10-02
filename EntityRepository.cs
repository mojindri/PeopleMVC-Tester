using assessment_server_side.EntityDataSource;
using assessment_server_side.Exceptions;
using assessment_server_side.Models;
using assessment_server_side.Repository;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NUnitTest
{
    class EntityRepository
    {
        [Test]
        public void EnsureGetPeopleReturnsAllRecordsProperly()
        {
            FavouriteColorEntityFrameworkRepository favCSVFileRepo = new FavouriteColorEntityFrameworkRepository();
            var peopleTest = favCSVFileRepo.GetPeople();
            Assert.IsTrue(peopleTest.Count() >= 10);
        }

        [Test]
        public void EnsureGetPersonWorksProperly()
        {
            FavouriteColorEntityFrameworkRepository favCSVFileRepo = new FavouriteColorEntityFrameworkRepository();
            var person = favCSVFileRepo.GetPerson(2);
            Assert.IsTrue(person.Id == 2);
        }
        [Test]
        public void EnsureGetPersonDealsWithUnknownIdProperly()
        {
            FavouriteColorEntityFrameworkRepository favCSVFileRepo = new FavouriteColorEntityFrameworkRepository();
            try
            {
                var person = favCSVFileRepo.GetPerson(334);
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
            FavouriteColorEntityFrameworkRepository favCSVFileRepo = new FavouriteColorEntityFrameworkRepository();
            var person = favCSVFileRepo.GetPeopleByColor("blau");
            Assert.IsTrue(person.Count() >= 2);
        }
        [Test]
        public void EnsureGetPersonByColorDealsWithUknownStringsProperly()
        {
            try
            {
                FavouriteColorEntityFrameworkRepository favCSVFileRepo = new FavouriteColorEntityFrameworkRepository();
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

            FavouriteColorEntityFrameworkRepository favCSVFileRepo = new FavouriteColorEntityFrameworkRepository();
            var ps = new List<Person>() { new Person() { Id = 10, Name = "John", Lastname = "Doe", City = "Sky", Zipcode = "12345", FavColourId = 1 } };
            var ok = favCSVFileRepo.SavePeople(ps);
            Assert.IsTrue(ok);

        }
        [Test]
        public void EnsureSavePeopleDealsWithNullColorProperly()
        {
            try
            {
                FavouriteColorEntityFrameworkRepository favCSVFileRepo = new FavouriteColorEntityFrameworkRepository();
                var ps = new List<Person>() { new Person() { Id = 10, Name = "John", Lastname = "Doe", City = "Sky", Zipcode = "12345" } };
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
                FavouriteColorEntityFrameworkRepository favCSVFileRepo = new FavouriteColorEntityFrameworkRepository();
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
