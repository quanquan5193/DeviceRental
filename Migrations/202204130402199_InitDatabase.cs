namespace DeviceRental.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DeviceRentals",
                c => new
                {
                    DeviceId = c.Int(nullable: false),
                    EmployeeId = c.Int(nullable: false),
                    StartDate = c.DateTime(nullable: false),
                    EndDate = c.DateTime(),
                })
                .PrimaryKey(t => new { t.DeviceId, t.EmployeeId })
                .ForeignKey("dbo.Devices", t => t.DeviceId)
                .ForeignKey("dbo.Employees", t => t.EmployeeId)
                .Index(t => t.DeviceId)
                .Index(t => t.EmployeeId);

            CreateTable(
                "dbo.Devices",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    DeviceName = c.String(nullable: false, maxLength: 256),
                    Price = c.Double(nullable: false),
                    Quantity = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Employees",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(nullable: false, maxLength: 256),
                })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.DeviceRentals", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.DeviceRentals", "DeviceId", "dbo.Devices");
            DropIndex("dbo.DeviceRentals", new[] { "EmployeeId" });
            DropIndex("dbo.DeviceRentals", new[] { "DeviceId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Devices");
            DropTable("dbo.DeviceRentals");
        }
    }
}
