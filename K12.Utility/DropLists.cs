using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K12.Utility
{
    public  class DropLists
    {
        public readonly static IList<DropList> CountryList;

        public readonly static IList<DropList> AdmisionMethodList; 
        // deserialize JSON directly from a file

    static DropLists()
        {
            CountryList = JsonConvert.DeserializeObject<IList<DropList>>(
                 File.ReadAllText( System.Com  @"Resources/Countries.json")
                );

            AdmisionMethodList = JsonConvert.DeserializeObject<IList<DropList>>(
                  File.ReadAllText(@"Resources/AdmissionMethods.json")
                 );


        }

    }
}
