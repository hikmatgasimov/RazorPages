using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPages.Services.Migrations
{
    public partial class spGetEmployeeById : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string info = @"create procedure spGetEmployeeById
                         @id int 
                         as
                         begin
                         select * from Employees
                        where id=@id
                         end";
            migrationBuilder.Sql(info);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            string drop = @"drop procedure  spGetEmployeeById";
            migrationBuilder.Sql(drop);
        }
    }
}
