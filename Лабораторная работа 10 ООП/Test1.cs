using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlacesLib;
using System;
using System.Collections.Generic;
using System.Net;
using System.Numerics;
namespace PlacesTests
{
    [TestClass]
    public class PlacesTests
    {
        // проверка ограничений в свойствах
        [TestMethod]
        public void Place_EmptyName_Throws()
        {
            Assert.Throws<ArgumentException>(() => new Place(" "));
        }
        [TestMethod]
        public void City_NegativePopulation_Throws()
        {
            Assert.Throws<ArgumentException>(() => new City("A", -1, "R"));
        }
        // конструктор копирования и Equals
        [TestMethod]
        public void CopyConstructor_MakesEqualObject()
        {
            City a = new City("Тюмень", 100, "Тюменская область");
            City b = new City(a);
            Assert.IsTrue(a.Equals(b));
        }
        [TestMethod]
        public void Equals_DifferentTypes_IsFalse()
        {
            Place p = new Place("A");
            City c = new City("A", 1, "B");
            Assert.IsFalse(p.Equals(c));
        }
        // интерфейсы
        [TestMethod]
        public void CompareTo_OrdersByName()
        {
            Place a = new Place("Аа");
            Place b = new Place("Бб");
            Assert.IsTrue(a.CompareTo(b) < 0);
        }
        [TestMethod]
        public void Clone_Megapolis_IsIndependent()
        {
            Megapolis m = new Megapolis("М", 2000000, "О", 5, new int[] { 1, 2, 3 });
            Megapolis copy = (Megapolis)m.Clone();
            m.DistrictAreas[0] = 99;
            Assert.AreEqual(1, copy.DistrictAreas[0]);
        }
        [TestMethod]
        public void ShallowCopy_Megapolis_SharesArray()
        {
            Megapolis m = new Megapolis("М", 2000000, "О", 5, new int[] { 1, 2, 3 });
            Megapolis copy = (Megapolis)m.ShallowCopy();
            m.DistrictAreas[0] = 99;
            Assert.AreEqual(99, copy.DistrictAreas[0]);
        }
        // апросы части 2 на заранее известном массиве
        static Place[] Sample()
        {
            Place[] arr = new Place[5];
            arr[0] = new City("A", 100, "R1");
            arr[1] = new Megapolis("B", 2000000, "R1", 5, new int[] { 1 });
            arr[2] = new City("C", 50, "R2");
            arr[3] = new Address("A", "Ленина", 1, 1);
            arr[4] = new Region("R1", "A", 10);
            return arr;
        }
        [TestMethod]
        public void Query_CityNamesInRegion()
        {
            List<string> r = PlaceQueries.CityNamesInRegion(Sample(), "R1");
            Assert.AreEqual(2, r.Count);
            Assert.AreEqual("A", r[0]);
            Assert.AreEqual("B", r[1]);
        }
        [TestMethod]
        public void Query_TotalPopulation()
        {
            Assert.AreEqual(2000100L, PlaceQueries.TotalPopulation(Sample(), "R1"));
        }
        [TestMethod]
        public void Query_CountMegapolisesAndPlainCities()
        {
            Assert.AreEqual(1, PlaceQueries.CountMegapolises(Sample()));
            Assert.AreEqual(2, PlaceQueries.CountPlainCities(Sample()));
        }
    }
}