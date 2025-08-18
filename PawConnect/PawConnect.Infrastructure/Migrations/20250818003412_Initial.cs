using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PawConnect.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "species",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_species", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "volunteers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    first_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    last_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    middle_name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: true),
                    description = table.Column<string>(type: "text", nullable: false),
                    experience_in_years = table.Column<int>(type: "integer", nullable: false),
                    email_email = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    phone_number_phone = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    donation = table.Column<string>(type: "jsonb", nullable: false),
                    social_networks = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_volunteers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "breed",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    species_id = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_breed", x => x.id);
                    table.ForeignKey(
                        name: "FK_breed_species_species_id",
                        column: x => x.species_id,
                        principalTable: "species",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "pets",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    description = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    color = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    health_info = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: false),
                    weight_in_kg = table.Column<double>(type: "double precision", nullable: false),
                    height_in_cm = table.Column<double>(type: "double precision", nullable: false),
                    is_castrated = table.Column<bool>(type: "boolean", nullable: false),
                    birth_date = table.Column<DateOnly>(type: "date", nullable: false),
                    is_vaccinated = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    volunteer_id = table.Column<Guid>(type: "uuid", nullable: true),
                    breed_breed_id = table.Column<Guid>(type: "uuid", nullable: false),
                    contact_number_phone = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    location_building_number = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    location_city = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    location_country = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    location_postal_code = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    location_street = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    species_species_id = table.Column<Guid>(type: "uuid", nullable: false),
                    donation = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pets", x => x.id);
                    table.ForeignKey(
                        name: "FK_pets_volunteers_volunteer_id",
                        column: x => x.volunteer_id,
                        principalTable: "volunteers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_breed_species_id",
                table: "breed",
                column: "species_id");

            migrationBuilder.CreateIndex(
                name: "IX_pets_volunteer_id",
                table: "pets",
                column: "volunteer_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "breed");

            migrationBuilder.DropTable(
                name: "pets");

            migrationBuilder.DropTable(
                name: "species");

            migrationBuilder.DropTable(
                name: "volunteers");
        }
    }
}
