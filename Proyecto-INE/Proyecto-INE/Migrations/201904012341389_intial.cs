namespace Proyecto_INE.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidato",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartidoPoliticoId = c.Int(nullable: false),
                        PuestoId = c.Int(nullable: false),
                        NombreCandidato = c.String(nullable: false, maxLength: 100),
                        ApellidoPaternoCandidato = c.String(nullable: false, maxLength: 100),
                        ApellidoMaternoCandidato = c.String(nullable: false, maxLength: 100),
                        FechaNacimientoCandidato = c.DateTime(nullable: false),
                        MunicipioId = c.Int(nullable: false),
                        PaisId = c.Int(nullable: false),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estado", t => t.EstadoId, cascadeDelete: true)
                .ForeignKey("dbo.Municipio", t => t.MunicipioId, cascadeDelete: true)
                .ForeignKey("dbo.Pais", t => t.PaisId, cascadeDelete: true)
                .ForeignKey("dbo.PartidoPolitico", t => t.PartidoPoliticoId, cascadeDelete: true)
                .ForeignKey("dbo.Puesto", t => t.PuestoId, cascadeDelete: true)
                .Index(t => t.PartidoPoliticoId)
                .Index(t => t.PuestoId)
                .Index(t => t.MunicipioId)
                .Index(t => t.PaisId)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        PaisId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pais", t => t.PaisId, cascadeDelete: false)
                .Index(t => t.PaisId);
            
            CreateTable(
                "dbo.Municipio",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        EstadoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estado", t => t.EstadoId, cascadeDelete: false)
                .Index(t => t.EstadoId);
            
            CreateTable(
                "dbo.Persona",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                        ApellidoPaterno = c.String(nullable: false, maxLength: 100),
                        ApellidoMaterno = c.String(nullable: false, maxLength: 100),
                        PaisId = c.Int(nullable: false),
                        EstadoId = c.Int(nullable: false),
                        MunicipioId = c.Int(nullable: false),
                        Colonia = c.String(nullable: false, maxLength: 100),
                        Calle = c.String(nullable: false, maxLength: 100),
                        NumeroExterior = c.String(nullable: false, maxLength: 100),
                        NumeroInterior = c.String(maxLength: 100),
                        CodigoPostal = c.Int(nullable: false),
                        ClaveElector = c.String(nullable: false, maxLength: 100),
                        Curp = c.String(nullable: false, maxLength: 100),
                        AñoRegistro = c.Int(nullable: false),
                        Emision = c.Int(nullable: false),
                        Vigencia = c.Int(nullable: false),
                        FechaNacimiento = c.String(),
                        Sexo = c.String(nullable: false, maxLength: 100),
                        CIC = c.String(nullable: false, maxLength: 100),
                        voto = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Estado", t => t.EstadoId, cascadeDelete: true)
                .ForeignKey("dbo.Municipio", t => t.MunicipioId, cascadeDelete: true)
                .ForeignKey("dbo.Pais", t => t.PaisId, cascadeDelete: true)
                .Index(t => t.PaisId)
                .Index(t => t.EstadoId)
                .Index(t => t.MunicipioId);
            
            CreateTable(
                "dbo.Pais",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PartidoPolitico",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Puesto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Cargo = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Voto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CandidatoId = c.Int(nullable: false),
                        votos = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Candidato", t => t.CandidatoId, cascadeDelete: true)
                .Index(t => t.CandidatoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Voto", "CandidatoId", "dbo.Candidato");
            DropForeignKey("dbo.Candidato", "PuestoId", "dbo.Puesto");
            DropForeignKey("dbo.Candidato", "PartidoPoliticoId", "dbo.PartidoPolitico");
            DropForeignKey("dbo.Candidato", "PaisId", "dbo.Pais");
            DropForeignKey("dbo.Candidato", "MunicipioId", "dbo.Municipio");
            DropForeignKey("dbo.Candidato", "EstadoId", "dbo.Estado");
            DropForeignKey("dbo.Estado", "PaisId", "dbo.Pais");
            DropForeignKey("dbo.Persona", "PaisId", "dbo.Pais");
            DropForeignKey("dbo.Persona", "MunicipioId", "dbo.Municipio");
            DropForeignKey("dbo.Persona", "EstadoId", "dbo.Estado");
            DropForeignKey("dbo.Municipio", "EstadoId", "dbo.Estado");
            DropIndex("dbo.Voto", new[] { "CandidatoId" });
            DropIndex("dbo.Persona", new[] { "MunicipioId" });
            DropIndex("dbo.Persona", new[] { "EstadoId" });
            DropIndex("dbo.Persona", new[] { "PaisId" });
            DropIndex("dbo.Municipio", new[] { "EstadoId" });
            DropIndex("dbo.Estado", new[] { "PaisId" });
            DropIndex("dbo.Candidato", new[] { "EstadoId" });
            DropIndex("dbo.Candidato", new[] { "PaisId" });
            DropIndex("dbo.Candidato", new[] { "MunicipioId" });
            DropIndex("dbo.Candidato", new[] { "PuestoId" });
            DropIndex("dbo.Candidato", new[] { "PartidoPoliticoId" });
            DropTable("dbo.Voto");
            DropTable("dbo.Puesto");
            DropTable("dbo.PartidoPolitico");
            DropTable("dbo.Pais");
            DropTable("dbo.Persona");
            DropTable("dbo.Municipio");
            DropTable("dbo.Estado");
            DropTable("dbo.Candidato");
        }
    }
}
