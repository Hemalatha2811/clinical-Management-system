using System;
    using System.Collections.Generic;
    
    public partial class Prescription
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Prescription()
        {
            this.Histories = new HashSet<History>();
        }
    
        public int PresId { get; set; }
        public Nullable<int> DoctorId { get; set; }
        public Nullable<int> PatientId { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }

        public string Details { get; set; }
    
        public virtual Doctor Doctor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<History> Histories { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
