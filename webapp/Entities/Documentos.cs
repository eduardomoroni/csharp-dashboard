namespace VixEng.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Documentos
    {
        public long id { get; set; }

        public long id_funcionario { get; set; }

        public long id_tipo_documento { get; set; }

        public DateTime data { get; set; }

        [Required]
        public string descricao { get; set; }

        [Required]
        [StringLength(250)]
        public string documento { get; set; }

        public virtual Funcionarios Funcionarios { get; set; }

        public virtual Tipo_Documento Tipo_Documento { get; set; }
    }
}
