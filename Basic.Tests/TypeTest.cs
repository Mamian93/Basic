using Basic.Core.Models;
using Basic.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Basic.Tests
{
    public class TypeTest
    {
        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Damian";
            MakeUppercase(ref name);

            Assert.Equal("DAMIAN", name);
        }

        private void MakeUppercase(ref string name)
        {
           name = name.ToUpper();
        }

        [Fact]
        public void ValueTypes()
        {
            int num = GetInt();
            SetInt(ref num);

            Assert.Equal(43, num);
        }

        private void SetInt(ref int num)
        {
            num = 43;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpIsPassByReferences()
        {
            var sport1 = GetSport("Sport 1");
            GetSportSetNameRef(ref sport1, "New era");

            Assert.Equal("New era", sport1.name);
        }

        private void GetSportSetNameRef(ref SportService sport, string name)
        {
            sport = new SportService(name);
        }

        [Fact]
        public void CSharpIsPassByValue()
        {
            var sport1 = GetSport("Sport 1");
            GetSportSetName(sport1, "New era");

            Assert.Equal("New era", sport1.name);
        }

        private void GetSportSetName(SportService sport, string name)
        {
            sport.name = name;
        }

        [Fact]
        public void NameTestDifferentObjects()
        {
            var sport1 = GetSport("Sport 1");
            var sport2 = GetSport("Sport 2");

            Assert.Equal("Sport 1", sport1.name);
            Assert.Equal("Sport 2", sport2.name);
        }

        [Fact]
        public void NameTestTheSameObject()
        {
            var sport1 = GetSport("Sport 1");
            var sport2 = sport1;

            Assert.Equal(sport2.name, sport1.name);
        }

        [Fact]
        public void NameTestTheSameObjectChangeInSecond()
        {
            var sport1 = GetSport("Sport 1");
            var sport2 = sport1;
            sport2.name = "Sport 2";

            Assert.NotEqual("Sport 1", sport1.name);
            Assert.Equal("Sport 2", sport1.name);
        }

        [Fact]
        public void ObjectReferencesTest()
        {
            var sport1 = GetSport("Sport 1");
            var sport2 = sport1;

            Assert.Same(sport1, sport2);
        }

        [Fact]
        public void ListPassingByReferencesWithReturn()
        {
            var stringList = new List<string>
            {
                "jeden", "dwa"
            };

            var modifyList = AddItemsToList(stringList);

            Assert.Equal(stringList.Count, modifyList.Count);
        }

        [Fact]
        public void ListPassingByReferencesWithoutReturn()
        {
            var stringList = new List<string>
            {
                "jeden", "dwa"
            };

            AddItemsToListVoid(stringList);

            Assert.Equal(3, stringList.Count);
        }

        private void AddItemsToListVoid(List<string> stringList)
        {
            stringList.Add("trzy");
        }

        private List<string> AddItemsToList(List<string> stringList)
        {
            stringList.Add("trzy");
            return stringList;
        }

        private SportService GetSport(string name)
        {
            return new SportService(name);
        }
    }
}
