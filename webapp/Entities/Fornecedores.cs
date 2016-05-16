namespace VixEng.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Fornecedores
    {
        public long id { get; set; }

        [Required]
        [StringLength(250)]
        public string nome { get; set; }

        [Required]
        [StringLength(20)]
        public string cnpj { get; set; }

        [StringLength(150)]
        public string email { get; set; }

        [StringLength(250)]
        public string contato { get; set; }

        [StringLength(20)]
        public string telefone1 { get; set; }

        [StringLength(20)]
        public string telefone2 { get; set; }

        [StringLength(20)]
        public string telefone3 { get; set; }

        public string observacao { get; set; }
    }
}
