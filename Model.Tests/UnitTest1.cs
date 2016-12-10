using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;
using System.Linq;

namespace Model.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void Setup()
        {
            Database.SetInitializer(new DbInitializer());
            using (JardinContext context = GetContext())
            {
                context.Database.Initialize(true);
            }
        }

        private static JardinContext GetContext()
        {
            return new JardinContext();
        }

        [TestMethod]
        public void CanGetPersonne()
        {
            using (var context = GetContext())
            {
                Assert.AreEqual(6, context.Personnes.ToList().Count);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public void DetecteLesEditionsConcurrentes()
        {
            using (JardinContext contexteDeAlex = GetContext())
            {
                using (JardinContext contexteDeYagami = GetContext())
                {
                    var PersonneDeAlex = contexteDeAlex.Personnes.First();
                    var PersonneDeYagami = contexteDeYagami.Personnes.First();

                    PersonneDeAlex.Nom = "Hey";
                    contexteDeAlex.SaveChanges();

                    PersonneDeYagami.Nom = "Ho";
                    contexteDeYagami.SaveChanges();
                }
            }
        }
    }
}