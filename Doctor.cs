using System;
    using System.Collections.Generic;
    
    public partial class Doctor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Doctor()
        {
            this.Appointments = new HashSet<Appointment>();
            this.Histories = new HashSet<History>();
            this.Prescriptions = new HashSet<Prescription>();
            this.Shedulers = new HashSet<Sheduler>();
        }
    
        public int DoctorId { get; set; }
        public string Name { get; set; }
        public Nullable<int> Age { get; set; }
        public string Speciality { get; set; }
        public string Experience { get; set; }
        public string Availability { get; set; }
        public string AvailabilityTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Appointment> Appointments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<History> Histories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Prescription> Prescriptions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sheduler> Shedulers { get; set; }
    }
