//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace K_12.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class student_medication 
    {
        public int student_id { get; set; }
        public int medication_id { get; set; }
        public string Remark { get; set; }
    
        public virtual Medication Medication { get; set; }
        public virtual Student Student { get; set; }
    }
}