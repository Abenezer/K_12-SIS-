using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_12.Entity
{
    public static class EntityExtention
    {
        public static string GetFullName(this Person source)

        {
            return source.FName + " " + source.MName;
        }


        public static IDictionary<string,string> GetStudentNames(this ICollection<student_parent> source)
        
            {

            
           return source.Select(x => new KeyValuePair<string, string>(x.Student.ID.ToString(), x.Student.GetFullName()))
    .ToDictionary(x => x.Key, x => x.Value);

         //   return source.Students.Select(s => new { s.Student.ID, s.Student.FName, s.Student.MName }).ToDictionary(s => s.ID, s => s.FName);

        }



    




    }
}
