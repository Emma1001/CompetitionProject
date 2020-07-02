namespace Competition.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CompetitionDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Athletes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        TeamId = c.Int(nullable: false),
                        Discipline = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AthleteToDisciplines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AthleteId = c.Int(nullable: false),
                        DisciplineId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Athletes", t => t.AthleteId, cascadeDelete: true)
                .ForeignKey("dbo.Disciplines", t => t.DisciplineId, cascadeDelete: true)
                .Index(t => t.AthleteId)
                .Index(t => t.DisciplineId);
            
            CreateTable(
                "dbo.Disciplines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DisciplineName = c.String(),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AthleteToDisciplines", "DisciplineId", "dbo.Disciplines");
            DropForeignKey("dbo.AthleteToDisciplines", "AthleteId", "dbo.Athletes");
            DropForeignKey("dbo.Athletes", "TeamId", "dbo.Teams");
            DropIndex("dbo.AthleteToDisciplines", new[] { "DisciplineId" });
            DropIndex("dbo.AthleteToDisciplines", new[] { "AthleteId" });
            DropIndex("dbo.Athletes", new[] { "TeamId" });
            DropTable("dbo.Disciplines");
            DropTable("dbo.AthleteToDisciplines");
            DropTable("dbo.Teams");
            DropTable("dbo.Athletes");
        }
    }
}
