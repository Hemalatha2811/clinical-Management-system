 using System;
    using System.Collections.Generic;
    
    public partial class Sheduler
    {
        public int SheId { get; set; }
        public Nullable<int> DoctorId { get; set; }
        public string Timeavailability { get; set; }
    
        public virtual Doctor Doctor { get; set; }
    }
