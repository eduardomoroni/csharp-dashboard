namespace VixEng.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UF")]
    public partial class UF
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UF()
        {
            Cidades = new HashSet<Cidades>();
        }

        public long id { get; set; }

        [Column("uf")]
        [Required]
        [StringLength(2)]
        public string uf1 { get; set; }

        [StringLength(50)]
        public string extenso { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Cidades> Cidades { get; set; }
    }
}
