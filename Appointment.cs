using System;
    using System.Collections.Generic;
    
    public partial class Appointment
    {
        public int AppoinmentId { get; set; }
        public Nullable<int> PatientId { get; set; }
        public Nullable<int> DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }

        public string Appointmentdate { get; set; }
        public string AppointmentTime { get; set; }
    
        public virtual Doctor Doctor { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
