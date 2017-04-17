using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using K_12.BLL.Service;
using System.Linq;

namespace K_12.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRepository()
        {

            UnitOfWork uw = new UnitOfWork(new Entity.K_12Entities());

            Entity.Contact c = new Entity.Contact();
            c.FName = "Wende";
            c.LName = "kebede";
           
            uw.Contacts.Add(c);

            uw.Save();

            Entity.Contact c2 = uw.Contacts.Find(c.ID);

            Assert.AreEqual(c.FName, c2.FName);



        }

        [TestMethod]
        public void TestCascadeInsert()
        {

            Entity.Applicant app = new Entity.Applicant();
            app.FName = "Abebe";
            app.LName = "Kebede";

            Entity.Contact c = new Entity.Contact();
            c.FName = "Aster";
            c.LName = "Chala";
            c.Address = new Entity.Address();
            c.Address.Email = "Abebe@gmail.com";


           // app.Contacts.Add(c);


            UnitOfWork uw = new UnitOfWork(new Entity.K_12Entities());
            //IApplicantService app_servie = new ApplicantService(uw.Applicants);

            // app_servie.Insert(app);
            uw.Contacts.Add(c);

            uw.Save();
            

            //Entity.Applicant a2 = app_servie.Find(1);
            Assert.AreEqual(uw.Contacts.Find(c.ID).Address.Email, c.Address.Email);
        }
        

        [TestMethod]
        public void TestService()
        {
            UnitOfWork uw = new UnitOfWork(new Entity.K_12Entities());

          IContactService cont_serv = new ContactService(uw.Contacts);

            Entity.Contact c = cont_serv.Find(2);

            Entity.Address a = new Entity.Address();

            a.Email= "abebaaae@gmail.com";
           
            c.Address = a;
           
            cont_serv.Update(c);

            uw.Save();

            Entity.Contact c2 = cont_serv.Find(c.ID);


            Assert.AreEqual(c.Address.Email, c2.Address.Email);
        }

        [TestMethod]
        public void TestLang()
        {
            UnitOfWork uw = new UnitOfWork(new Entity.K_12Entities());
            Entity.Student s = new Entity.Student();
            s.Languages.Add(uw.Languages.Find("ENG"));
            uw.Students.Add(s);
            uw.Save();

            Assert.IsNotNull(uw.Students.Find(s.ID).Languages.First());



        }

        [TestMethod]
        public void TestAppStatus()
        {
            var context = new Entity.K_12Entities();
            UnitOfWork uw = new UnitOfWork(context);
            Entity.Application a  = uw.Applications.Find(11);
            a.app_status = "Waiting";
            uw.Applications.Update(a);
            uw.Save();
            Assert.AreEqual(uw.Applications.Find(11).app_status, "Waiting");



        }

        [TestMethod]
        public void TestMultiKeys()
        {
            var context = new Entity.K_12Entities();
            UnitOfWork uw = new UnitOfWork(context);
            var cls = uw.Classs.Find(22, 21); //order matters 

            Assert.IsNotNull(cls);

        }


        [TestMethod]
        public void TestDelete()
        {
            var context = new Entity.K_12Entities();
            UnitOfWork uw = new UnitOfWork(context);
            uw.student_sections.Delete(7);

            uw.Save();
            Assert.IsNull(uw.student_sections.Find(7));

        }



    }
}
