namespace VixEng.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ConsultaCEPBrasil")]
    public partial class ConsultaCEPBrasil
    {
        [Key]
        [Column(Order = 0)]
        public long id { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string cep { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id_uf { get; set; }

        [Key]
        [Column(Order = 3)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id_cidade { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(150)]
        public string endereco { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(150)]
        public string bairro { get; set; }
    }
}
