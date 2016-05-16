namespace VixEng.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Servicos
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Servicos()
        {
            PropostasItens = new HashSet<PropostasItens>();
        }

        public long Id { get; set; }

        [Required]
        [StringLength(250)]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        [StringLength(1)]
        public string Status { get; set; }

        [Required]
        public string Observacao { get; set; }

        [StringLength(3)]
        public string Unidade { get; set; }

        public decimal? Preco { get; set; }

        public decimal? Tempo { get; set; }

        [Column(TypeName = "image")]
        public byte[] Imagem1 { get; set; }

        [Column(TypeName = "image")]
        public byte[] Imagem2 { get; set; }

        public string Observacao2 { get; set; }

        [StringLength(50)]
        public string TipoImagem1 { get; set; }

        [StringLength(50)]
        public string TipoImagem2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PropostasItens> PropostasItens { get; set; }
    }
}
