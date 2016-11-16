using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OptikPlanner.Model
{
    public partial class APTDETAILS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int APD_STAMP { get; set; }

        public int APD_CALENDAR { get; set; }

        public int APD_USER { get; set; }

        public int APD_ROOM { get; set; }

        [Required]
        [StringLength(5)]
        public string APD_TIMETO { get; set; }

        [StringLength(1)]
        public string APD_STATUS { get; set; }

        [StringLength(11)]
        public string APD_CPR { get; set; }

        [StringLength(30)]
        public string APD_LAST { get; set; }

        public DateTime? APD_DATE { get; set; }

        [Required]
        [StringLength(5)]
        public string APD_TIMEFROM { get; set; }

        [Column(TypeName = "image")]
        public byte[] APD_DESCRIPTION { get; set; }

        public int? APD_CUSTOMER { get; set; }

        [StringLength(30)]
        public string APD_FIRST { get; set; }

        public int APD_TYPE { get; set; }

        public int? APD_SMSREMINDER { get; set; }

        [StringLength(25)]
        public string APD_MOBILE { get; set; }

        public int? APD_SMSMESSAGE { get; set; }

        public int? APD_SMSMESSAGE_SENT { get; set; }

        public Guid? APD_WEBREF { get; set; }

        [StringLength(50)]
        public string APD_EMAIL { get; set; }

        public APTDETAILS(int id, USERS user, EYEEXAMROOMS room, DateTime date, string timeFrom, string timeTo, CUSTOMERS customer, string description)
        {
            APD_CALENDAR = 1;
            APD_STAMP = id;
            APD_USER = user.US_STAMP;
            APD_FIRST = customer.CS_FIRSTNAME;
            APD_LAST = customer.CS_LASTNAME;
            APD_CPR = customer.CS_CPRNO;
            APD_ROOM = room.ERO_STAMP;
            APD_DATE = date;
            APD_TIMEFROM = timeFrom;
            APD_TIMETO = timeTo;
            APD_CUSTOMER = customer.CS_STAMP;
            APD_DESCRIPTION = Encoding.ASCII.GetBytes(description);
        }

        public APTDETAILS()
        {
            
        }
    }
}
