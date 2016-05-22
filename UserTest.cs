using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Transactions;

namespace UnitTestProject1
{
    [TestClass]
    public class UserTest
    {
        private TransactionScope scope;
        private User u = new User("Mara","test@ceva.com");

        [TestMethod]
        public void testUpdate() //testez daca se trimit mailuri
        {
            using (scope = new TransactionScope())
            {
                bool res = u.update("costea.mara94@gmail.com");
                Assert.IsFalse(res);
            }
        }

        [TestMethod]
        public void testInsertUser() //testez daca se insereaza userul in db
        {
            using (scope = new TransactionScope())
            {
                DateTime birthdate = (DateTime)u.convertDate("12021955");
                User user = new User("Mara", "mail@gmail.com", "username", "pass", "ro", "bucharest", birthdate);
                int rezultat = user.DB_InsertUser();
                Assert.AreEqual(1, rezultat);
            }
        }

        [TestMethod]
        public void testGetRole() //testez daca intoarce rolul userului
        {
            using (scope = new TransactionScope())
            {
                String role = u.getUserRole("mara12");
                Assert.AreEqual("user", role);
            }
        }

        [TestMethod]
        public void testVerifyLogin() //testez daca gasesc userul si pass in db
        {
            using (scope = new TransactionScope())
            {
                int rez = u.verifyLogin("mara12", "1234");
                Assert.AreEqual(1, rez);
            }
        }

        [TestMethod]
        public void testVerifyMailAddress() //testez daca adresa mail a userului e corecta
        {
            bool verif = u.validateMailAddress();
            Assert.IsTrue(verif);
        }

        [TestMethod]
        public void testVerifyUsername() //testez daca numele introdus de user contine numai litere
        {
            bool rez = u.validateUserName("MaraCostea");
            Assert.IsTrue(rez);
        }

        [TestMethod]
        public void testVerifyUsernameSpaces() //testez daca numele introdus de user contine numai litere+spatii
        {
            bool rez = u.validateUserName2("Mara Costea");
            Assert.IsTrue(rez);
        }

    }
    }
