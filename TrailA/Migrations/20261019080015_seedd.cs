using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TrailA.Migrations
{
    /// <inheritdoc />
    public partial class seedd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "CreatedAt", "Email", "FullName", "Password", "Role" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "ahmed@example.com", "Ahmed Hassan", "123456", "Candidate" },
                    { 2, new DateTime(2026, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "sara@example.com", "Sara Mohammed", "123456", "Employer" },
                    { 3, new DateTime(2026, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "omar@example.com", "Omar Ali", "123456", "Admin" },
                    { 4, new DateTime(2026, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "hamza@example.com", "Hamza Ahmed", "123456", "Candidate" }
                });

            migrationBuilder.InsertData(
                table: "candidateProfiles",
                columns: new[] { "Id", "Phone", "ResumeUrl", "Skill", "UserId", "YearsOfExperince" },
                values: new object[,]
                {
                    { 1, "012345678", "example.com/resume1", "ASP.NET core", 1, 3 },
                    { 2, "01098765432", "example.com/resume2", "Java", 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "companies",
                columns: new[] { "Id", "Description", "Location", "Name", "UserId", "Website" },
                values: new object[,]
                {
                    { 1, "Software Develpoment Company", "Cairo", "Tech Solutions", 2, "https://TechSolutions.example.com" },
                    { 2, "IT Cons Company", "Giza", "Future Systems", 2, "https://FutureSystems.example.com" }
                });

            migrationBuilder.InsertData(
                table: "jobs",
                columns: new[] { "Id", "CompanyId", "DeadLine", "Description", "EmploymentType", "Location", "PostedDate", "Salary", "Status", "Title" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Developing apis using .nwt core", "FullTime", "Cairo", new DateTime(2026, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 30000m, "Open", "Backend Developer" },
                    { 2, 2, new DateTime(2026, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Developing Web interfaces", "FullTime", "Giza", new DateTime(2026, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 25000m, "Open", "Frontend Developer" }
                });

            migrationBuilder.InsertData(
                table: "applications",
                columns: new[] { "Id", "ApplicationDate", "CandidateProfileId", "CoverLetter", "JobId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "interested in backend development", 1, "Pending" },
                    { 2, new DateTime(2026, 10, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "interested in web technolgy", 2, "UnderReview" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "applications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "applications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "candidateProfiles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "candidateProfiles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "jobs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "jobs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
