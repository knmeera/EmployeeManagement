namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialemptables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        DeptName = c.String(),
                        Enable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        EmpNo = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        DOB = c.String(),
                        Stree1 = c.String(),
                        Street2 = c.String(),
                        City = c.String(),
                        Pin = c.String(),
                        District = c.String(),
                        State = c.String(),
                        TotalYearsOfExp = c.Single(nullable: false),
                        WorkState = c.String(),
                        WorkLoad = c.Single(nullable: false),
                        Country = c.String(),
                        Address = c.String(),
                        DeptID = c.Int(nullable: false),
                        PofilePic = c.String(),
                        Enable = c.Boolean(nullable: false),
                        Department_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Department", t => t.Department_ID)
                .Index(t => t.Department_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Department_ID", "dbo.Department");
            DropIndex("dbo.Employees", new[] { "Department_ID" });
            DropTable("dbo.Employees");
            DropTable("dbo.Department");
        }
    }
}
