using Kendo.Mvc.UI;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_12.WEB.Utilities
{
    public  class DropLists
    {
        public readonly static ICollection<Country> CountryList;

        public readonly static  string[] NationalityList;

        public readonly static ICollection<DropDownListItem> AdmisionMethodList; 

        
        // deserialize JSON directly from a file

    static DropLists()
        {
            string path = System.Web.HttpContext.Current.Server.MapPath("~/Resources");



            CountryList = JsonConvert.DeserializeObject<ICollection<Country>>(
                 File.ReadAllText(Path.Combine(path, "Countries.json"))
                );

            AdmisionMethodList = JsonConvert.DeserializeObject<Dictionary<string, string>>(
                 File.ReadAllText(Path.Combine(path, "AdmissionMethods.json"))
                ).ToDropDownList();

            NationalityList = JsonConvert.DeserializeObject<string[]>(
                 File.ReadAllText(Path.Combine(path, "Nationalities.json"))
                );


        }

    }
}
