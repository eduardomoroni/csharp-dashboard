namespace VixEng.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tipo_Pagamento
    {
        public int id { get; set; }

        [Required]
        [StringLength(250)]
        public string descricao { get; set; }

        [Required]
        [StringLength(1)]
        public string status { get; set; }
    }
}
