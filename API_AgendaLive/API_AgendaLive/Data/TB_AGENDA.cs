using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_AgendaLive.Data
{
    [Table("TB_AGENDA")]
    public class TB_AGENDA
    {
            [Display(Name = "Código")]
            [Column("Id")]
            public int id { get; set; }

            [Display(Name = "Nome da Live")]
            [Column("liveName")]
            public string liveName { get; set; }

            [Display(Name = "Nome do Canal")]
            [Column("channelName")]
            public string channelName { get; set; }

            [Display(Name = "Email")]
            [Column("liveDate")]
            public DateTime liveDate { get; set; }

            [Display(Name = "Link da Live")]
            [Column("liveLink")]
            public string liveLink { get; set; }

            [Display(Name = "Dia da Live")]
            [Column("registrationDate")]
            public DateTime registrationDate { get; set; }

    }
}


