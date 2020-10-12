using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PersonneLibrary;

namespace EntrepriseUnitTest
{
    [TestClass]
    public class EntrepriseUnitTest
    {
        private static Service production;
        private static Entreprise entreprise; // on suppose que service et entreprise ont déjà été testés

        [ClassInitialize]
        public static void CreationService(TestContext context) // on évite la redondance : on ne fait pas de tests sur service
        {
            production = new Service(1, "Production");
            entreprise = new Entreprise();
        }

        [TestMethod]
        // [ExpectedException typeof(nomException)]
        [ExpectedException typeof(Exception)]
        public void TestAjoutPersonne()
        {
            entreprise.AjouterPersonne(null);
        }
    }
}
