using System.Data.Entity;

namespace OptikPlanner.Model
{
    public partial class OptikItDbContext : DbContext
    {
        public OptikItDbContext()
            : base("name=OptikItDbContext")
        {
            //base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<APTDETAILS> APTDETAILS { get; set; }
        public virtual DbSet<CUSTOMERS> CUSTOMERS { get; set; }
        public virtual DbSet<EYEEXAMROOMS> EYEEXAMROOMS { get; set; }
        public virtual DbSet<USERS> USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<APTDETAILS>()
                .Property(e => e.APD_TIMETO)
                .IsUnicode(false);

            modelBuilder.Entity<APTDETAILS>()
                .Property(e => e.APD_STATUS)
                .IsUnicode(false);

            modelBuilder.Entity<APTDETAILS>()
                .Property(e => e.APD_CPR)
                .IsUnicode(false);

            modelBuilder.Entity<APTDETAILS>()
                .Property(e => e.APD_LAST)
                .IsUnicode(false);

            modelBuilder.Entity<APTDETAILS>()
                .Property(e => e.APD_TIMEFROM)
                .IsUnicode(false);

            modelBuilder.Entity<APTDETAILS>()
                .Property(e => e.APD_FIRST)
                .IsUnicode(false);

            modelBuilder.Entity<APTDETAILS>()
                .Property(e => e.APD_MOBILE)
                .IsUnicode(false);

            modelBuilder.Entity<APTDETAILS>()
                .Property(e => e.APD_EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_CPRNO)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_FIRSTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_LASTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_ADRESS1)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_ADRESS2)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_PHONEPRIVATE)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_PHONEPRIVATEEXT)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_PHONEWORK)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_PHONEWORKEXT)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_PHONEWORKAVAIL)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_PHONEMOBILE)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_PHONEMOBILEEXT)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_PHONEMOBILEAVAIL)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_FAX)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_FAXEXT)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_AVAILABLEATA)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_OCCUPATION)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_HOBBY)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_EMAILCOMMERCIALS)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_RECEIVEMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_TILTULATION)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_GENDER)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_SUBDANMARK)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_SUB58)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_SUBPENSIONER)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_LEGALGUARDIANCPR)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_LEGALGUARDIANFIRSTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_LEGALGUARDIANLASTNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_LEGALGUARDIANPHONE)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_SUB97)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_MAILCOMMERCIALS)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_RABAT)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_TLFOPFBEM)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_KOMMUNENAVN)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_PBSSTATUS)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_PBSCPRNR)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_PBSREGNR)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_PBSKONTONR)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_PBSAFTALENR)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_MODFIRST)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_MODLAST)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_MODADRESSE)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_MODCOUNTRY)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_RECIEVEEMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_OLDPBSCUSTNO)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_MODEANCODE)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_PBSLINE1)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_PBSLINE2)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_WEB_USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_WEBSITE)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_ATT)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMERS>()
                .Property(e => e.CS_BONUSCARD_REF)
                .IsUnicode(false);

            modelBuilder.Entity<EYEEXAMROOMS>()
                .Property(e => e.ERO_OPENTO)
                .IsUnicode(false);

            modelBuilder.Entity<EYEEXAMROOMS>()
                .Property(e => e.ERO_DESC)
                .IsUnicode(false);

            modelBuilder.Entity<EYEEXAMROOMS>()
                .Property(e => e.ERO_OPENFROM)
                .IsUnicode(false);

            modelBuilder.Entity<EYEEXAMROOMS>()
                .Property(e => e.ERO_SHORTDESC)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.US_USERINIT)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.US_USERNAME)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.US_CPRNO)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.US_ADRESS)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.US_PASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.US_CASHDRAWERPASSWORD)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.US_OPTICIAN)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.US_SALESPERSON)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.US_STOCKACCESS)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.US_PHONE)
                .IsUnicode(false);

            modelBuilder.Entity<USERS>()
                .Property(e => e.US_PHONEMOBILE)
                .IsUnicode(false);
        }
    }
}
