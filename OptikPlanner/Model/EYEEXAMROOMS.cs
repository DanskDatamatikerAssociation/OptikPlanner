using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptikPlanner.Model
{
    public partial class EYEEXAMROOMS
    {
        public int? ERO_NBR { get; set; }

        [StringLength(5)]
        public string ERO_OPENTO { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ERO_STAMP { get; set; }

        [StringLength(30)]
        public string ERO_DESC { get; set; }

        [StringLength(5)]
        public string ERO_OPENFROM { get; set; }

        [StringLength(20)]
        public string ERO_SHORTDESC { get; set; }

        public bool ERO_USEFORWEB { get; set; }
    }
}
