using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Transactions;

namespace UnitTestProject1
{
    [TestClass]
    public class ProjectTest
    {
        Project p = new Project();
        User u = new User("nume", "mail");
        private TransactionScope scope;
      
        [SetUp]
        public void Initialize()
        {
           Project p = new Project();
           scope = new TransactionScope();
        }

        [TestMethod]
        public void testDateFormat() //test daca data e in formatul care trebuie
        {
            NUnit.Framework.Assert.IsTrue(p.checkDateFormat("22052016"));
        }

        [TestMethod]
        public void testDateConversion() //test daca se conv string in datetime
        {
            NUnit.Framework.Assert.IsInstanceOf(typeof(DateTime), p.convertDate("23062014")); 
        }

        [TestMethod]
        public void testDateOrder() //verific daca data start < data end
        {
            DateTime start = (DateTime) p.convertDate("23072016");
            DateTime end = (DateTime) p.convertDate("30072016");
            p.setStartDate(start);
            p.setEndDate(end);
            NUnit.Framework.Assert.IsTrue(p.checkDateStartEnd());
        }

        [TestMethod]
        public void testUserList()  //se adauga user in lista
        {
            p.add(u);
            NUnit.Framework.Assert.IsNotEmpty(p.userList);
        }

        [TestMethod]
        public void testInsertIntoDB() //daca se insereaza in bd
        {
            using (TransactionScope scope = new TransactionScope())
            {
                DateTime start = (DateTime) p.convertDate("23072016");
                DateTime end = (DateTime) p.convertDate("30072016");
                p = new Project("ProjTest1", "Ro", "Host", "C1", "YE", "", 5, start, end);
                int rez = p.InsertIntoDB();
                NUnit.Framework.Assert.AreEqual(1, rez);
            }
        
        }


    }
}
