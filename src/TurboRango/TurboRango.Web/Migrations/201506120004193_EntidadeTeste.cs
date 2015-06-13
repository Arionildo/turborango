namespace TurboRango.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntidadeTeste : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Usuario = c.String(),
                        Restaurante = c.String(),
                        QuantidadeSolicitada = c.Int(nullable: false),
                        Dia = c.DateTime(nullable: false),
                        Inicio = c.Time(nullable: false, precision: 7),
                        Fim = c.Time(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Reservas");
        }
    }
}
