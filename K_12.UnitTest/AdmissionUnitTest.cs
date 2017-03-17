using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using K_12.BLL.Service;
using System.Linq;

namespace K_12.UnitTest
{
    [TestClass]
    public class AdmissionUnitTest
    {

        private UnitOfWork uw;
        private IAdmissionService admissionservice; 


       [TestInitialize] 
       public void init ()
        {
            uw = new UnitOfWork(new Entity.K_12Entities());

            admissionservice = new AdmissionService(new StudentService(uw.Students), new ParentService(uw.Parents));

        }



        [TestMethod]
        public void TestStudentInsert()
        {
            

            Entity.Student std = new Entity.Student() { FName="Abebe",MName="Kebede", LName="Chala"};


            Entity.Parent p1 = new Entity.Parent() { FName = "Kebede", MName = "Chala" };
            std.Parents.Add(new Entity.student_parent() { Parent = p1, Relation = "Father" });

            admissionservice.StudentService.Insert(std);
            uw.Save();

            Assert.AreEqual(std.Parents.First().Parent.FName, admissionservice.ParentService.Find(p1.ID).FName);

        }
    }
}
