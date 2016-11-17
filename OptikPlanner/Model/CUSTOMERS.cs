using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OptikPlanner.Model
{
    public partial class CUSTOMERS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CS_STAMP { get; set; }

        public int CS_CUSTNO { get; set; }

        public DateTime? CS_CREATIONDATE { get; set; }

        [StringLength(11)]
        public string CS_CPRNO { get; set; }

        [StringLength(50)]
        public string CS_FIRSTNAME { get; set; }

        [StringLength(50)]
        public string CS_LASTNAME { get; set; }

        [StringLength(60)]
        public string CS_ADRESS1 { get; set; }

        [StringLength(60)]
        public string CS_ADRESS2 { get; set; }

        public int? CS_ZIPCODE { get; set; }

        public int? CS_COUNTYNO { get; set; }

        [StringLength(25)]
        public string CS_PHONEPRIVATE { get; set; }

        [StringLength(4)]
        public string CS_PHONEPRIVATEEXT { get; set; }

        [Column(TypeName = "image")]
        public byte[] CS_PHONEPRIVATEAVAIL { get; set; }

        [StringLength(25)]
        public string CS_PHONEWORK { get; set; }

        [StringLength(4)]
        public string CS_PHONEWORKEXT { get; set; }

        [StringLength(25)]
        public string CS_PHONEWORKAVAIL { get; set; }

        [StringLength(25)]
        public string CS_PHONEMOBILE { get; set; }

        [StringLength(4)]
        public string CS_PHONEMOBILEEXT { get; set; }

        [StringLength(25)]
        public string CS_PHONEMOBILEAVAIL { get; set; }

        [StringLength(25)]
        public string CS_FAX { get; set; }

        [StringLength(4)]
        public string CS_FAXEXT { get; set; }

        [StringLength(25)]
        public string CS_AVAILABLEATA { get; set; }

        [StringLength(32)]
        public string CS_OCCUPATION { get; set; }

        [StringLength(32)]
        public string CS_HOBBY { get; set; }

        [StringLength(50)]
        public string CS_EMAIL { get; set; }

        [StringLength(1)]
        public string CS_EMAILCOMMERCIALS { get; set; }

        [StringLength(1)]
        public string CS_RECEIVEMAIL { get; set; }

        [StringLength(1)]
        public string CS_TILTULATION { get; set; }

        [StringLength(1)]
        public string CS_GENDER { get; set; }

        [StringLength(1)]
        public string CS_SUBDANMARK { get; set; }

        [StringLength(1)]
        public string CS_SUB58 { get; set; }

        [StringLength(32)]
        public string CS_SUBPENSIONER { get; set; }

        [StringLength(11)]
        public string CS_LEGALGUARDIANCPR { get; set; }

        [StringLength(32)]
        public string CS_LEGALGUARDIANFIRSTNAME { get; set; }

        [StringLength(32)]
        public string CS_LEGALGUARDIANLASTNAME { get; set; }

        [StringLength(25)]
        public string CS_LEGALGUARDIANPHONE { get; set; }

        [StringLength(1)]
        public string CS_SUB97 { get; set; }

        [StringLength(1)]
        public string CS_MAILCOMMERCIALS { get; set; }

        public int? CS_PAYMENTCONDITION { get; set; }

        [StringLength(16)]
        public string CS_RABAT { get; set; }

        public int CS_CUSTGROUP { get; set; }

        public int? CS_OWNOPTICIAN { get; set; }

        public int? CS_OJENLAEGE { get; set; }

        public DateTime? CS_TLFOPFDATO { get; set; }

        [StringLength(80)]
        public string CS_TLFOPFBEM { get; set; }

        [StringLength(50)]
        public string CS_KOMMUNENAVN { get; set; }

        [StringLength(10)]
        public string CS_PBSSTATUS { get; set; }

        [StringLength(11)]
        public string CS_PBSCPRNR { get; set; }

        [StringLength(4)]
        public string CS_PBSREGNR { get; set; }

        [StringLength(10)]
        public string CS_PBSKONTONR { get; set; }

        [StringLength(9)]
        public string CS_PBSAFTALENR { get; set; }

        public double? CS_PBSMAX { get; set; }

        public double? CS_PBSMIN { get; set; }

        public DateTime? CS_PBSDATE { get; set; }

        public int? CS_USER { get; set; }

        public DateTime? CS_LASTGLASSES { get; set; }

        public DateTime? CS_LASTLENS { get; set; }

        public int? CS_MODTAGER { get; set; }

        [StringLength(50)]
        public string CS_MODFIRST { get; set; }

        [StringLength(50)]
        public string CS_MODLAST { get; set; }

        [StringLength(50)]
        public string CS_MODADRESSE { get; set; }

        public int? CS_MODZIPCODE { get; set; }

        [StringLength(50)]
        public string CS_MODCOUNTRY { get; set; }

        [StringLength(1)]
        public string CS_RECIEVEEMAIL { get; set; }

        [StringLength(25)]
        public string CS_OLDPBSCUSTNO { get; set; }

        [StringLength(15)]
        public string CS_MODEANCODE { get; set; }

        [StringLength(38)]
        public string CS_PBSLINE1 { get; set; }

        [StringLength(38)]
        public string CS_PBSLINE2 { get; set; }

        [StringLength(20)]
        public string CS_WEB_USERNAME { get; set; }

        public float? CS_BALANCE { get; set; }

        public int? CS_PBSCOUNTRY { get; set; }

        public int CS_COMMERCIALS_SMS { get; set; }

        public int CS_COMMERCIALS_EMAIL { get; set; }

        public int CS_COMMERCIALS_LETTER { get; set; }

        public int CS_DEBTORTYPE { get; set; }

        public int? CS_OLDMODTAGERNO { get; set; }

        [StringLength(50)]
        public string CS_WEBSITE { get; set; }

        public long? CS_EANCODE { get; set; }

        public int CS_FORCED_REFNO { get; set; }

        public int CS_ACTIVE { get; set; }

        public int CS_CANEDIT { get; set; }

        public int? CS_VATCODES { get; set; }

        public int? CS_PAYINFO { get; set; }

        [StringLength(50)]
        public string CS_ATT { get; set; }

        public int? CS_CUSTOMERDEBTOR { get; set; }

        public int? CS_BONUSCARD { get; set; }

        [StringLength(20)]
        public string CS_BONUSCARD_REF { get; set; }

        public DateTime? CS_BIRTHDAY { get; set; }

        public override string ToString()
        {
            return String.Format($"{CS_FIRSTNAME} {CS_LASTNAME}");
        }
    }
}
