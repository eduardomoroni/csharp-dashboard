namespace VixEng.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Propostas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Propostas()
        {
            PropostasItens = new HashSet<PropostasItens>();
        }

        public long id { get; set; }

        public int numero { get; set; }

        [Required]
        [StringLength(4)]
        public string ano { get; set; }

        [Required]
        [StringLength(12)]
        public string codigo { get; set; }

        public DateTime data { get; set; }

        public long id_cliente { get; set; }

        [StringLength(50)]
        public string contato { get; set; }

        [StringLength(20)]
        public string telefone { get; set; }

        [StringLength(150)]
        public string email { get; set; }

        [Required]
        [StringLength(150)]
        public string obra { get; set; }

        [Required]
        [StringLength(250)]
        public string local_obra { get; set; }

        public decimal? valor_total { get; set; }

        public int? tempo_total { get; set; }

        public int id_condicao_pagamento { get; set; }

        public int prazo_conclusao { get; set; }

        public int id_validade { get; set; }

        public string observacao { get; set; }

        [Required]
        [StringLength(1)]
        public string status { get; set; }

        public string motivo_cancelamento { get; set; }

        public long? id_usuario_cancelou { get; set; }

        public DateTime? data_cancelamento { get; set; }

        public int? id_tipo_cancelamento { get; set; }

        public DateTime? data_aprovacao { get; set; }

        public long? id_usuario_aprovou { get; set; }

        public DateTime? data_inicio_obra { get; set; }

        public DateTime? data_final_obra { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropostasItens> PropostasItens { get; set; }
    }
}
