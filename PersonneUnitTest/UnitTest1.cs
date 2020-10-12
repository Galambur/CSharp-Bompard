﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PersonneLibrary;

namespace PersonneUnitTest
{
    [TestClass]
    public class PersonneUnitTest
    {
        private Service production;
        private void CreationService()
        {
            production = new Service(1, "Production");
        }

        [TestMethod]
        public void TestSalaireBrutEmploye()
        {
            Employe employe = new Employe(2, "KERBAN", "Henry", new DateTime(1981, 09, 24), 2000, production, 5);
            Assert.AreEqual(2000, employe.SalaireBrut);
        }

        [TestMethod]
        public void TestSupplementSalaireEmploye()
        {
            Employe employe = new Employe(2, "KERBAN", "Henry", new DateTime(1981, 09, 24), 2000, production, 5);
            Assert.AreEqual(0, employe.SupplementSalaire); // un employe n'a pas de prime
        }

        [TestMethod]
        public void TestSalaireNetEmploye() // on fait un test de la plus petite partie possible : on va pas tester cadre et employee en même temps
        {
            Employe employe = new Employe(2, "KERBAN", "Henry", new DateTime(1981, 09, 24), 2000, production, 5);

            double salaireNet = employe.SalaireNet;
            Assert.AreEqual(1600, salaireNet);
        }
    }
}
