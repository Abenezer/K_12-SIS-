using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_12.BLL.Constants
{
  public static class AdmissionMethods
    {
        public static readonly string FIFO = "FIFO";
        public static readonly string MANUAL = "MANUAL";
        //public static readonly string FIFO = "FIFO";
    }


   public static class ApplicationStatuses
    {
        public static readonly string[] avarailbleStatuses = { "Accepted", "Rejected", "Pending", "Waiting", "Admited" };


        public static readonly string ACCEPTED = "Accepted";
        public static readonly string REJECTED = "Rejected";
        public static readonly string PENDING = "Pending";
        public static readonly string WAITING = "Waiting";
        public static readonly string ADMITED = "Admited";
        //public static readonly string FIFO = "FIFO";
    }

    public static class RegistrationStatus
    {
        public static readonly string[] avarailbleStatuses = { "Pending", "Confirmed" };


    
        public static readonly string PENDING = "Pending";
        public static readonly string CONFIRMED = "Confirmed";
      
    }
}
