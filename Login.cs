 using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class login
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public login()
        {
            this.Patients = new HashSet<Patient>();
        }
    
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [Display(Name = "RePassword")]
        [DataType(DataType.Password)]

        [Compare("Password", ErrorMessage = "confirm password does not match")]
        public string RePassword { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Patient> Patients { get; set; }
    }
