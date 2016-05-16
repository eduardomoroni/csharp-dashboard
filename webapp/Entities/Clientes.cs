namespace VixEng.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Clientes
    {
        public long id { get; set; }

        [Required]
        [StringLength(1)]
        public string status { get; set; }

        public DateTime data_cadastro { get; set; }

        [Required]
        [StringLength(1)]
        public string tipo_pessoa { get; set; }

        [Required]
        [StringLength(20)]
        public string cnpj_cpf { get; set; }

        [Required]
        [StringLength(150)]
        public string nome { get; set; }

        [StringLength(250)]
        public string fantasia { get; set; }

        [StringLength(250)]
        public string contato { get; set; }

        [StringLength(30)]
        public string inscricao_estadual { get; set; }

        [StringLength(30)]
        public string inscricao_municipal { get; set; }

        public DateTime? data_nascimento { get; set; }

        [StringLength(20)]
        public string rg { get; set; }

        [StringLength(14)]
        public string telefone1 { get; set; }

        [StringLength(14)]
        public string telefone2 { get; set; }

        [StringLength(14)]
        public string telefone3 { get; set; }

        public string endereco { get; set; }

        [StringLength(10)]
        public string numero { get; set; }

        [StringLength(100)]
        public string complemento { get; set; }

        [StringLength(150)]
        public string bairro { get; set; }

        public long? id_cidade { get; set; }

        public long? id_uf { get; set; }

        [StringLength(11)]
        public string cep { get; set; }

        [StringLength(250)]
        public string ponto_referencia { get; set; }

        [StringLength(250)]
        public string site { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(50)]
        public string login { get; set; }

        [StringLength(150)]
        public string senha { get; set; }

        public DateTime? data_inclusao { get; set; }

        public virtual Cidades Cidades { get; set; }
    }
}
