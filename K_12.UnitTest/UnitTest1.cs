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

            Entity.Contact c = new Entity.Contact();
            c.FName = "Abebe";
            c.LName = "kebede";

            uw.Contacts.Add(c);

            uw.Save();

            Entity.Contact c2 = uw.Contacts.Find(1);

            Assert.AreEqual(c.FName, c2.FName);



        }

        [TestMethod]
        public void TestCascadeInsert()
        {

            Entity.Application app = new Entity.Application();
            app.FName = "Abebe";
            app.LName = "Kebede";

            Entity.Contact c = new Entity.Contact();
            c.FName = "Aster";
            c.LName = "Chala";
            c.Address = new Entity.Address();
            c.Address.Email = "Abebe@gmail.com";


           // app.Contacts.Add(c);


            UnitOfWork uw = new UnitOfWork(new Entity.K_12Entities());
            //IApplicationService app_servie = new ApplicationService(uw.Applications);

            // app_servie.Insert(app);
            uw.Contacts.Add(c);

            uw.Save();
            

            //Entity.Application a2 = app_servie.Find(1);
            Assert.AreEqual(uw.Contacts.Find(1).Address.Email, c.Address.Email);
        }
        

        [TestMethod]
        public void TestService()
        {
            UnitOfWork uw = new UnitOfWork(new Entity.K_12Entities());

          IContactService cont_serv = new ContactService(uw.Contacts);

            Entity.Contact c = cont_serv.Find(1);

            Entity.Address a = new Entity.Address();

            a.Email= "abebaaae@gmail.com";
           
            c.Address = a;
           
            cont_serv.Update(c);

            uw.Save();

            Entity.Contact c2 = cont_serv.Find(1);


            Assert.AreEqual(c.Address.Email, c2.Address.Email);
        }

    }
}
