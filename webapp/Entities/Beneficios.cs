namespace VixEng.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Beneficios
    {
        public long id { get; set; }

        [Display(Name = "Funcionário")]
        public long id_funcionario { get; set; }

        [Display(Name = "Benefício")]
        public int id_tipo_beneficio { get; set; }

        [Display(Name = "Observação")]
        public string observacao { get; set; }

        public virtual Funcionarios Funcionarios { get; set; }

        [Display(Name = "Beneficio")]
        public virtual Tipo_Beneficio Tipo_Beneficio { get; set; }
    }
}
