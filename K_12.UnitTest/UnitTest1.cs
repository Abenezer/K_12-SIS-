using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using K_12.BLL.Service;

namespace K_12.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRepository()
        {

            UnitOfWork uw = new UnitOfWork(new Entity.K_12Entities());

            Entity.Student s = new Entity.Student();
            s.FName = "Abebe";
            s.LName = "kebede";

            uw.Students.Add(s);

            uw.Save();

            Entity.Student s2 = uw.Students.Find(1);

            Assert.AreEqual(s.FName, s2.FName);

            

        }

        [TestMethod]
        public void TestService()
        {
            UnitOfWork uw = new UnitOfWork(new Entity.K_12Entities());

            StudentService ss = new StudentService(uw.Students);

           Assert.IsNotNull(ss.Find(1));
        }

    }
}
