using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentRegistrationAPI.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CollegeName",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollegeName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollegeName", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "DetailsCategory",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailsCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "QuestionType",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionTypeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeID = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CollegeNamesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                    table.ForeignKey(
                        name: "FK_User_CollegeName_CollegeNamesID",
                        column: x => x.CollegeNamesID,
                        principalTable: "CollegeName",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_UserTypes_UserTypeID",
                        column: x => x.UserTypeID,
                        principalTable: "UserTypes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FieldQuestion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsersID = table.Column<int>(type: "int", nullable: false),
                    DetailsCategoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldQuestion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_FieldQuestion_DetailsCategory_DetailsCategoryID",
                        column: x => x.DetailsCategoryID,
                        principalTable: "DetailsCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FieldQuestion_User_UsersID",
                        column: x => x.UsersID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationQuestion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollegeNamesID = table.Column<int>(type: "int", nullable: false),
                    FieldQuestionsID = table.Column<int>(type: "int", nullable: false),
                    QuestionTypesID = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                   
                    UsersID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationQuestion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApplicationQuestion_CollegeName_CollegeNamesID",
                        column: x => x.CollegeNamesID,
                        principalTable: "CollegeName",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationQuestion_FieldQuestion_FieldQuestionsID",
                        column: x => x.FieldQuestionsID,
                        principalTable: "FieldQuestion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ApplicationQuestion_QuestionType_QuestionTypesID",
                        column: x => x.QuestionTypesID,
                        principalTable: "QuestionType",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationQuestion_User_UsersID",
                        column: x => x.UsersID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Choices",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DisplayText = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    
                    FieldQuestionsID = table.Column<int>(type: "int", nullable: true),
                   
                    UsersID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Choices", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Choices_FieldQuestion_FieldQuestionsID",
                        column: x => x.FieldQuestionsID,
                        principalTable: "FieldQuestion",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Choices_User_UsersID",
                        column: x => x.UsersID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "StudentSubmissions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollegeNamesID = table.Column<int>(type: "int", nullable: false),
                    ApplicationQuestionsID = table.Column<int>(type: "int", nullable: false),
                    Answers = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DetailsCategoryID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsersID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubmissions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_StudentSubmissions_ApplicationQuestion_ApplicationQuestionsID",
                        column: x => x.ApplicationQuestionsID,
                        principalTable: "ApplicationQuestion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubmissions_CollegeName_CollegeNamesID",
                        column: x => x.CollegeNamesID,
                        principalTable: "CollegeName",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StudentSubmissions_DetailsCategory_DetailsCategoryID",
                        column: x => x.DetailsCategoryID,
                        principalTable: "DetailsCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubmissions_User_UsersID",
                        column: x => x.UsersID,
                        principalTable: "User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ResponseLogs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentSubmissionsID = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UsersID = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseLogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ResponseLogs_StudentSubmissions_StudentSubmissionsID",
                        column: x => x.StudentSubmissionsID,
                        principalTable: "StudentSubmissions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResponseLogs_User_UsersID",
                        column: x => x.UsersID,
                        principalTable: "User",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationQuestion_CollegeNamesID",
                table: "ApplicationQuestion",
                column: "CollegeNamesID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationQuestion_FieldQuestionsID",
                table: "ApplicationQuestion",
                column: "FieldQuestionsID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationQuestion_QuestionTypesID",
                table: "ApplicationQuestion",
                column: "QuestionTypesID");

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationQuestion_UsersID",
                table: "ApplicationQuestion",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_Choices_FieldQuestionsID",
                table: "Choices",
                column: "FieldQuestionsID");

            migrationBuilder.CreateIndex(
                name: "IX_Choices_UsersID",
                table: "Choices",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_FieldQuestion_DetailsCategoryID",
                table: "FieldQuestion",
                column: "DetailsCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_FieldQuestion_UsersID",
                table: "FieldQuestion",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseLogs_StudentSubmissionsID",
                table: "ResponseLogs",
                column: "StudentSubmissionsID");

            migrationBuilder.CreateIndex(
                name: "IX_ResponseLogs_UsersID",
                table: "ResponseLogs",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubmissions_ApplicationQuestionsID",
                table: "StudentSubmissions",
                column: "ApplicationQuestionsID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubmissions_CollegeNamesID",
                table: "StudentSubmissions",
                column: "CollegeNamesID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubmissions_DetailsCategoryID",
                table: "StudentSubmissions",
                column: "DetailsCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubmissions_UsersID",
                table: "StudentSubmissions",
                column: "UsersID");

            migrationBuilder.CreateIndex(
                name: "IX_User_CollegeNamesID",
                table: "User",
                column: "CollegeNamesID");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeID",
                table: "User",
                column: "UserTypeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Choices");

            migrationBuilder.DropTable(
                name: "ResponseLogs");

            migrationBuilder.DropTable(
                name: "StudentSubmissions");

            migrationBuilder.DropTable(
                name: "ApplicationQuestion");

            migrationBuilder.DropTable(
                name: "FieldQuestion");

            migrationBuilder.DropTable(
                name: "QuestionType");

            migrationBuilder.DropTable(
                name: "DetailsCategory");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "CollegeName");

            migrationBuilder.DropTable(
                name: "UserTypes");
        }
    }
}
