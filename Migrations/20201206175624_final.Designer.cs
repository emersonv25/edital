﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using edital.Data;

namespace edital.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201206175624_final")]
    partial class final
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0-rc.2.20475.6");

            modelBuilder.Entity("edital.Model.Cidade", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int>("estadoid")
                        .HasColumnType("integer");

                    b.Property<string>("nome")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("estadoid");

                    b.ToTable("cidade");
                });

            modelBuilder.Entity("edital.Model.Contato", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("celular")
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("site")
                        .HasColumnType("text");

                    b.Property<string>("telefone")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("contato");
                });

            modelBuilder.Entity("edital.Model.Edital", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime?>("datafim")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("datainicio")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("nome")
                        .HasColumnType("text");

                    b.Property<int>("vigencia")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("edital");
                });

            modelBuilder.Entity("edital.Model.Endereco", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("bairro")
                        .HasColumnType("text");

                    b.Property<string>("cep")
                        .HasColumnType("text");

                    b.Property<int?>("cidadeid")
                        .HasColumnType("integer");

                    b.Property<string>("complemento")
                        .HasColumnType("text");

                    b.Property<string>("logradouro")
                        .HasColumnType("text");

                    b.Property<string>("numero")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("cidadeid");

                    b.ToTable("endereco");
                });

            modelBuilder.Entity("edital.Model.Estado", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<bool>("flgativo")
                        .HasColumnType("boolean");

                    b.Property<string>("nome")
                        .HasColumnType("text");

                    b.Property<string>("uf")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("estado");
                });

            modelBuilder.Entity("edital.Model.Inscricao", b =>
                {
                    b.Property<int>("pessoajuridica_id")
                        .HasColumnType("integer");

                    b.Property<int>("segmento_id")
                        .HasColumnType("integer");

                    b.Property<bool>("flgativo")
                        .HasColumnType("boolean");

                    b.Property<int>("id")
                        .HasColumnType("integer");

                    b.Property<string>("nomeiniciativa")
                        .HasColumnType("text");

                    b.Property<string>("objetivos")
                        .HasColumnType("text");

                    b.Property<int?>("pessoajuridicacnpj")
                        .HasColumnType("integer");

                    b.Property<string>("publicoalvo")
                        .HasColumnType("text");

                    b.Property<int?>("segmentoid")
                        .HasColumnType("integer");

                    b.HasKey("pessoajuridica_id", "segmento_id");

                    b.HasIndex("pessoajuridicacnpj");

                    b.HasIndex("segmentoid");

                    b.ToTable("inscricao");
                });

            modelBuilder.Entity("edital.Model.PessoaJuridica", b =>
                {
                    b.Property<int>("cnpj")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("contatoid")
                        .HasColumnType("integer");

                    b.Property<int?>("enderecoid")
                        .HasColumnType("integer");

                    b.Property<string>("razaosocial")
                        .HasColumnType("text");

                    b.Property<int?>("representanteid")
                        .HasColumnType("integer");

                    b.HasKey("cnpj");

                    b.HasIndex("contatoid");

                    b.HasIndex("enderecoid");

                    b.HasIndex("representanteid");

                    b.ToTable("pessoajuridica");
                });

            modelBuilder.Entity("edital.Model.Representante", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("contatoid")
                        .HasColumnType("integer");

                    b.Property<string>("cpf")
                        .HasColumnType("text");

                    b.Property<int?>("enderecoid")
                        .HasColumnType("integer");

                    b.Property<string>("nome")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("contatoid");

                    b.HasIndex("enderecoid");

                    b.ToTable("representante");
                });

            modelBuilder.Entity("edital.Model.Segmento", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("descricao")
                        .HasColumnType("text");

                    b.Property<int?>("editalid")
                        .HasColumnType("integer");

                    b.Property<string>("segmento")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.HasIndex("editalid");

                    b.ToTable("segmento");
                });

            modelBuilder.Entity("edital.Model.Cidade", b =>
                {
                    b.HasOne("edital.Model.Estado", "estado")
                        .WithMany()
                        .HasForeignKey("estadoid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("estado");
                });

            modelBuilder.Entity("edital.Model.Endereco", b =>
                {
                    b.HasOne("edital.Model.Cidade", "cidade")
                        .WithMany("enderecos")
                        .HasForeignKey("cidadeid");

                    b.Navigation("cidade");
                });

            modelBuilder.Entity("edital.Model.Inscricao", b =>
                {
                    b.HasOne("edital.Model.PessoaJuridica", "pessoajuridica")
                        .WithMany()
                        .HasForeignKey("pessoajuridicacnpj");

                    b.HasOne("edital.Model.Segmento", "segmento")
                        .WithMany("inscricoes")
                        .HasForeignKey("segmentoid");

                    b.Navigation("pessoajuridica");

                    b.Navigation("segmento");
                });

            modelBuilder.Entity("edital.Model.PessoaJuridica", b =>
                {
                    b.HasOne("edital.Model.Contato", "contato")
                        .WithMany()
                        .HasForeignKey("contatoid");

                    b.HasOne("edital.Model.Endereco", "endereco")
                        .WithMany()
                        .HasForeignKey("enderecoid");

                    b.HasOne("edital.Model.Representante", "representante")
                        .WithMany()
                        .HasForeignKey("representanteid");

                    b.Navigation("contato");

                    b.Navigation("endereco");

                    b.Navigation("representante");
                });

            modelBuilder.Entity("edital.Model.Representante", b =>
                {
                    b.HasOne("edital.Model.Contato", "contato")
                        .WithMany()
                        .HasForeignKey("contatoid");

                    b.HasOne("edital.Model.Endereco", "endereco")
                        .WithMany()
                        .HasForeignKey("enderecoid");

                    b.Navigation("contato");

                    b.Navigation("endereco");
                });

            modelBuilder.Entity("edital.Model.Segmento", b =>
                {
                    b.HasOne("edital.Model.Edital", "edital")
                        .WithMany("segmentos")
                        .HasForeignKey("editalid");

                    b.Navigation("edital");
                });

            modelBuilder.Entity("edital.Model.Cidade", b =>
                {
                    b.Navigation("enderecos");
                });

            modelBuilder.Entity("edital.Model.Edital", b =>
                {
                    b.Navigation("segmentos");
                });

            modelBuilder.Entity("edital.Model.Segmento", b =>
                {
                    b.Navigation("inscricoes");
                });
#pragma warning restore 612, 618
        }
    }
}
