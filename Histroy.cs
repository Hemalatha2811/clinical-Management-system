 using System;
    using System.Collections.Generic;
    
    public partial class History
    {
        public int HistoryId { get; set; }
        public Nullable<int> PresId { get; set; }
        public Nullable<int> DoctorId { get; set; }
        public Nullable<int> PatientId { get; set; }
    
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
        public virtual Prescription Prescription { get; set; }
    }
