using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptikPlanner.Model
{
    public partial class USERS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int US_STAMP { get; set; }

        [StringLength(10)]
        public string US_USERINIT { get; set; }

        [StringLength(64)]
        public string US_USERNAME { get; set; }

        [StringLength(11)]
        public string US_CPRNO { get; set; }

        [StringLength(64)]
        public string US_ADRESS { get; set; }

        public int? US_ZIPCODE { get; set; }

        [StringLength(16)]
        public string US_PASSWORD { get; set; }

        [StringLength(16)]
        public string US_CASHDRAWERPASSWORD { get; set; }

        [StringLength(1)]
        public string US_OPTICIAN { get; set; }

        [StringLength(1)]
        public string US_SALESPERSON { get; set; }

        [StringLength(1)]
        public string US_STOCKACCESS { get; set; }

        [StringLength(16)]
        public string US_PHONE { get; set; }

        [StringLength(16)]
        public string US_PHONEMOBILE { get; set; }

        public int? US_COLOR { get; set; }

        public int? US_SORTERING { get; set; }

        public int? US_USERGROUP { get; set; }

        public int? US_ENABLED { get; set; }

        public int? US_STAMPCOPY { get; set; }

        public bool US_USEFORWEB { get; set; }

        public override string ToString()
        {
            return String.Format(US_USERNAME);
        }
    }


}
