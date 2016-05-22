using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System.Text;
using System.Transactions;

namespace UnitTestProject1
{
    //[TestFixture]
    [TestClass]
    public class MailTest
    {
        Mail m = new Mail("costea.mara94@gmail.com", "TEST_subj", "TEeest"); 
        [SetUp]
        public void Initialize()
        {
            m = new Mail("costea.mara94@gmail.com","TEST_subj","TEeest");   
        }

       [TestMethod]
        public void testMailSend() //verific daca se trimite mailul
        {
            NUnit.Framework.Assert.IsTrue(m.sendMail());
        }

       [TestMethod]
       public void testMailSendAddress() //verific daca se trim mailul cu adresa incorecta
       {
           Mail m1 = new Mail("", "Subject", "Message");
           NUnit.Framework.Assert.IsFalse(m1.sendMail());
       }

      [TestMethod]
       public void testPassEncryption()
       {
           String pass = "parola1";
           byte[] encr = m.cryptPass(pass);
           StringBuilder result = new StringBuilder(encr.Length * 2);

           for (int i = 0; i < encr.Length; i++)
               result.Append(encr[i].ToString());
           NUnit.Framework.Assert.AreNotSame(pass, result.ToString());
       }

        [TestMethod]
        public void testMailBuilderInstance() //daca se creaza un obiect nou de tip mail
        {
            Mail email = new MailBuilder().To("costea.mara94@gmail.com").Subject("TEST_subj").Message("TEeest").buildMail();
            NUnit.Framework.Assert.IsInstanceOf(typeof(Mail), email);
        }

        [TestMethod]
        public void testMailBuilderValue() //daca se creaza un nou obiect email = mail
        {
            Mail email = new MailBuilder().To("costea.mara94@gmail.com").Subject("TEST_subj").Message("TEeest").buildMail();
            NUnit.Framework.Assert.IsTrue(email.Equals(m));
        }

        [TestMethod]
        public void testVerifyMailAddress() //testez daca adresa mail e corecta
        {
            bool verif = m.validateAddress("costea.mara94@gmail.com");
            NUnit.Framework.Assert.IsTrue(verif);
        }

        [TestMethod]
        public void testInsertMailDb() //testez daca se insereaza in db
        {
            using (TransactionScope scope = new TransactionScope())
            {
                bool rez = m.insertMailDB();
                NUnit.Framework.Assert.IsTrue(rez);
            }
        }
    }
}
