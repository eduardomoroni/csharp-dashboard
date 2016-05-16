namespace VixEng.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PropostasItens
    {
        public long id { get; set; }

        public long id_proposta { get; set; }

        public long id_servico { get; set; }

        public int numero { get; set; }

        public int quantidade { get; set; }

        public decimal valor_tabela { get; set; }

        public decimal preco_unitario { get; set; }

        public decimal preco_total { get; set; }

        [Required]
        [StringLength(1)]
        public string status { get; set; }

        public decimal tempo { get; set; }

        public virtual Propostas Propostas { get; set; }

        public virtual Servicos Servicos { get; set; }
    }
}
