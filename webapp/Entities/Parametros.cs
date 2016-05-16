namespace VixEng.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Parametros
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(100)]
        public string empresa { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string cnpj { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(100)]
        public string endereco { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(30)]
        public string bairro { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id_cidade { get; set; }

        [Key]
        [Column(Order = 5)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long id_uf { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(12)]
        public string cep { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(100)]
        public string socio_administrativo { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(20)]
        public string telefone { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(50)]
        public string site { get; set; }
    }
}
