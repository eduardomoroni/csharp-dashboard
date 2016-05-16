namespace VixEng.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class databaseModel : DbContext
    {
        public databaseModel()
            : base("name=databaseModel")
        {
        }

        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Bancos> Bancos { get; set; }
        public virtual DbSet<Beneficios> Beneficios { get; set; }
        public virtual DbSet<Cargos> Cargos { get; set; }
        public virtual DbSet<Cidades> Cidades { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Documentos> Documentos { get; set; }
        public virtual DbSet<Fornecedores> Fornecedores { get; set; }
        public virtual DbSet<Funcionarios> Funcionarios { get; set; }
        public virtual DbSet<Propostas> Propostas { get; set; }
        public virtual DbSet<PropostasItens> PropostasItens { get; set; }
        public virtual DbSet<Servicos> Servicos { get; set; }
        public virtual DbSet<Tipo_Beneficio> Tipo_Beneficio { get; set; }
        public virtual DbSet<Tipo_Cancelamento> Tipo_Cancelamento { get; set; }
        public virtual DbSet<Tipo_Documento> Tipo_Documento { get; set; }
        public virtual DbSet<Tipo_Pagamento> Tipo_Pagamento { get; set; }
        public virtual DbSet<UF> UF { get; set; }
        public virtual DbSet<ConsultaCEPBrasil> ConsultaCEPBrasil { get; set; }
        public virtual DbSet<Parametros> Parametros { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.Funcionarios)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.id_user);

            modelBuilder.Entity<Bancos>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Bancos>()
                .Property(e => e.Banco)
                .IsUnicode(false);

            modelBuilder.Entity<Bancos>()
                .Property(e => e.Site)
                .IsUnicode(false);

            modelBuilder.Entity<Bancos>()
                .HasMany(e => e.Funcionarios)
                .WithOptional(e => e.Bancos)
                .HasForeignKey(e => e.id_banco);

            modelBuilder.Entity<Beneficios>()
                .Property(e => e.observacao)
                .IsUnicode(false);

            modelBuilder.Entity<Cargos>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Cargos>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Cargos>()
                .HasMany(e => e.Funcionarios)
                .WithOptional(e => e.Cargos)
                .HasForeignKey(e => e.id_cargo);

            modelBuilder.Entity<Cidades>()
                .Property(e => e.cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Cidades>()
                .HasMany(e => e.Clientes)
                .WithOptional(e => e.Cidades)
                .HasForeignKey(e => e.id_cidade);

            modelBuilder.Entity<Cidades>()
                .HasMany(e => e.Funcionarios)
                .WithOptional(e => e.Cidades)
                .HasForeignKey(e => e.id_cidade);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.tipo_pessoa)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.cnpj_cpf)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.fantasia)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.contato)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.inscricao_estadual)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.inscricao_municipal)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.rg)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.telefone1)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.telefone2)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.telefone3)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.endereco)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.numero)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.complemento)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.bairro)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.cep)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.ponto_referencia)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.site)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<Clientes>()
                .Property(e => e.senha)
                .IsUnicode(false);

            modelBuilder.Entity<Documentos>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Documentos>()
                .Property(e => e.documento)
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedores>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedores>()
                .Property(e => e.cnpj)
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedores>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedores>()
                .Property(e => e.contato)
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedores>()
                .Property(e => e.telefone1)
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedores>()
                .Property(e => e.telefone2)
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedores>()
                .Property(e => e.telefone3)
                .IsUnicode(false);

            modelBuilder.Entity<Fornecedores>()
                .Property(e => e.observacao)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.cpf)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.rg)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.rg_exp)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.endereco)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.numero)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.complemento)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.bairro)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.cep)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.telefone1)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.telefone2)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.telefone3)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.agencia)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.conta)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .Property(e => e.foto)
                .IsUnicode(false);

            modelBuilder.Entity<Funcionarios>()
                .HasMany(e => e.Beneficios)
                .WithRequired(e => e.Funcionarios)
                .HasForeignKey(e => e.id_funcionario)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Funcionarios>()
                .HasMany(e => e.Documentos)
                .WithRequired(e => e.Funcionarios)
                .HasForeignKey(e => e.id_funcionario)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<Propostas>()
                .Property(e => e.ano)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Propostas>()
                .Property(e => e.codigo)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Propostas>()
                .Property(e => e.contato)
                .IsUnicode(false);

            modelBuilder.Entity<Propostas>()
                .Property(e => e.telefone)
                .IsUnicode(false);

            modelBuilder.Entity<Propostas>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<Propostas>()
                .Property(e => e.obra)
                .IsUnicode(false);

            modelBuilder.Entity<Propostas>()
                .Property(e => e.local_obra)
                .IsUnicode(false);

            modelBuilder.Entity<Propostas>()
                .Property(e => e.observacao)
                .IsUnicode(false);

            modelBuilder.Entity<Propostas>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Propostas>()
                .Property(e => e.motivo_cancelamento)
                .IsUnicode(false);

            modelBuilder.Entity<Propostas>()
                .HasMany(e => e.PropostasItens)
                .WithRequired(e => e.Propostas)
                .HasForeignKey(e => e.id_proposta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PropostasItens>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Servicos>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Servicos>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Servicos>()
                .Property(e => e.Status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Servicos>()
                .Property(e => e.Observacao)
                .IsUnicode(false);

            modelBuilder.Entity<Servicos>()
                .Property(e => e.Unidade)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Servicos>()
                .Property(e => e.Observacao2)
                .IsUnicode(false);

            modelBuilder.Entity<Servicos>()
                .Property(e => e.TipoImagem1)
                .IsUnicode(false);

            modelBuilder.Entity<Servicos>()
                .Property(e => e.TipoImagem2)
                .IsUnicode(false);

            modelBuilder.Entity<Servicos>()
                .HasMany(e => e.PropostasItens)
                .WithRequired(e => e.Servicos)
                .HasForeignKey(e => e.id_servico)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_Beneficio>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Beneficio>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Beneficio>()
                .HasMany(e => e.Beneficios)
                .WithRequired(e => e.Tipo_Beneficio)
                .HasForeignKey(e => e.id_tipo_beneficio)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_Cancelamento>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Cancelamento>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Documento>()
                .Property(e => e.tipo_documento1)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Documento>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Documento>()
                .HasMany(e => e.Documentos)
                .WithRequired(e => e.Tipo_Documento)
                .HasForeignKey(e => e.id_tipo_documento)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Tipo_Pagamento>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Tipo_Pagamento>()
                .Property(e => e.status)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UF>()
                .Property(e => e.uf1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<UF>()
                .Property(e => e.extenso)
                .IsUnicode(false);

            modelBuilder.Entity<UF>()
                .HasMany(e => e.Cidades)
                .WithRequired(e => e.UF)
                .HasForeignKey(e => e.id_uf)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ConsultaCEPBrasil>()
                .Property(e => e.cep)
                .IsFixedLength();

            modelBuilder.Entity<ConsultaCEPBrasil>()
                .Property(e => e.endereco)
                .IsUnicode(false);

            modelBuilder.Entity<ConsultaCEPBrasil>()
                .Property(e => e.bairro)
                .IsUnicode(false);

            modelBuilder.Entity<Parametros>()
                .Property(e => e.empresa)
                .IsUnicode(false);

            modelBuilder.Entity<Parametros>()
                .Property(e => e.cnpj)
                .IsUnicode(false);

            modelBuilder.Entity<Parametros>()
                .Property(e => e.endereco)
                .IsUnicode(false);

            modelBuilder.Entity<Parametros>()
                .Property(e => e.bairro)
                .IsUnicode(false);

            modelBuilder.Entity<Parametros>()
                .Property(e => e.cep)
                .IsUnicode(false);

            modelBuilder.Entity<Parametros>()
                .Property(e => e.socio_administrativo)
                .IsUnicode(false);

            modelBuilder.Entity<Parametros>()
                .Property(e => e.telefone)
                .IsUnicode(false);

            modelBuilder.Entity<Parametros>()
                .Property(e => e.site)
                .IsUnicode(false);
        }
    }
}
