namespace VixEng.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Utils;
    public partial class Funcionarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Funcionarios()
        {
            Beneficios = new HashSet<Beneficios>();
            Documentos = new HashSet<Documentos>();
        }

        public long id { get; set; }

        public int? id_cargo { get; set; }

        [Required]
        [Display(Name = "Nome", Prompt = "Nome")]
        [StringLength(150)]
        public string nome { get; set; }

        [StringLength(150)]
        public string email { get; set; }

        [Required]
        [StringLength(20)]
        [VixEng.Utils.CustomValidationCPF(ErrorMessage = "CPF inválido")]
        public string cpf { get; set; }

        [StringLength(20)]
        public string rg { get; set; }

        public DateTime? rg_data_emissao { get; set; }

        [StringLength(10)]
        public string rg_exp { get; set; }

        public DateTime? data_nascimento { get; set; }

        [MaxWords(10)]
        public string endereco { get; set; }

        [StringLength(50)]
        public string numero { get; set; }

        [StringLength(100)]
        public string complemento { get; set; }

        [StringLength(150)]
        public string bairro { get; set; }

        [Display(Name = "Cidade", Prompt = "Cidade")]
        public long? id_cidade { get; set; }

        [Display(Name = "Estado", Prompt = "Estado")]
        [ForeignKey("UF")]
        public long? id_uf { get; set; }

        [StringLength(11)]
        public string cep { get; set; }

        [StringLength(15)]
        public string telefone1 { get; set; }

        [StringLength(15)]
        public string telefone2 { get; set; }

        [StringLength(15)]
        public string telefone3 { get; set; }

        [Required]
        [StringLength(1)]
        public string status { get; set; }

        public int? id_banco { get; set; }

        [StringLength(30)]
        public string agencia { get; set; }

        [StringLength(30)]
        public string conta { get; set; }

        public DateTime? data_admissao { get; set; }

        public decimal? salario { get; set; }

        [StringLength(150)]
        public string foto { get; set; }

        [StringLength(128)]
        public string id_user { get; set; }

        public virtual AspNetUsers AspNetUsers { get; set; }

        public virtual Bancos Bancos { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Beneficios> Beneficios { get; set; }

        public virtual Cargos Cargos { get; set; }

        public virtual Cidades Cidades { get; set; }


        public virtual UF UF { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Documentos> Documentos { get; set; }

        //Retorna se o funcionario é um usuario do sistema
        public bool isUser()
        {
            return this.id_user != null;
        }
    }
}
