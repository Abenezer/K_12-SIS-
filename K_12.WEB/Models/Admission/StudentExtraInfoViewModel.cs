using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace K_12.WEB.Models.Admission
{
    public class StudentExtraInfoViewModel
    {
        public StudentExtraInfoViewModel()
        {
            MedicationsList = new List<Entity.student_medication>();
            MedicationsList.Add(new Entity.student_medication());

          Languages = new HashSet<string>();
           Contacts = new HashSet<Entity.Contact>();


            Entity.Contact firstContact = new Entity.Contact();
           
            firstContact.Address= new Entity.Address();

            firstContact.Address.PhoneBooks.Add(new Entity.PhoneBook() { Type = "Mobile" });
            firstContact.Address.PhoneBooks.Add(new Entity.PhoneBook() { Type = "Office" });

            Contacts.Add(firstContact); 

        }

        public bool isOnMedication { get; set; }
        public Nullable<int> PrevSchoolId { get; set; }
        public IList<Entity.student_medication> MedicationsList { get; set; }

       public  ICollection<string> Languages { get; set; }
      public  ICollection<Entity.Contact> Contacts { get; set; }
    }
}