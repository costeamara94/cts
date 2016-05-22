using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;

namespace UnitTestProject1
{
    [TestClass]
    public class DBConnection_test
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void ConnectToDbInstance() //testeaza daca se face conexiunea la bd
        {
            DBConnection cs = DBConnection.getDbInstance();
            SqlConnection conn = cs.GetDBConnection();
            Assert.IsNotNull(conn);
        }

        [TestMethod]
        public void CreateDbInstance() //testeaza daca se creaza o noua instanta 
        {
            DBConnection cs = DBConnection.getDbInstance();
            Assert.IsInstanceOfType(cs, typeof(DBConnection));
        }


    }
}
