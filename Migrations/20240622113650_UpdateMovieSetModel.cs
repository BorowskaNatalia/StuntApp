using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Stunt.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMovieSetModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Horses",
                columns: table => new
                {
                    IdHorse = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    isAvailable = table.Column<bool>(type: "INTEGER", nullable: false),
                    Status = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horses", x => x.IdHorse);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    IdLocation = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.IdLocation);
                });

            migrationBuilder.CreateTable(
                name: "MovieSets",
                columns: table => new
                {
                    IdMovieSet = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Adderss = table.Column<string>(type: "TEXT", nullable: false),
                    Budget = table.Column<double>(type: "REAL", nullable: false),
                    StartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieSets", x => x.IdMovieSet);
                });

            migrationBuilder.CreateTable(
                name: "Owners",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Owners", x => x.IdPerson);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Surname = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Birthdate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Alias = table.Column<string>(type: "TEXT", nullable: true),
                    JoiningDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Salary = table.Column<double>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.IdPerson);
                });

            migrationBuilder.CreateTable(
                name: "MovieHorses",
                columns: table => new
                {
                    IdHorse = table.Column<int>(type: "INTEGER", nullable: false),
                    IdMovieSet = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieHorses", x => new { x.IdMovieSet, x.IdHorse });
                    table.ForeignKey(
                        name: "FK_MovieHorses_Horses_IdHorse",
                        column: x => x.IdHorse,
                        principalTable: "Horses",
                        principalColumn: "IdHorse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieHorses_MovieSets_IdMovieSet",
                        column: x => x.IdMovieSet,
                        principalTable: "MovieSets",
                        principalColumn: "IdMovieSet",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StuntLeaders",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StuntLeaders", x => x.IdPerson);
                    table.ForeignKey(
                        name: "FK_StuntLeaders_People_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "People",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stuntmen",
                columns: table => new
                {
                    IdPerson = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Rank = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stuntmen", x => x.IdPerson);
                    table.ForeignKey(
                        name: "FK_Stuntmen_People_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "People",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainings",
                columns: table => new
                {
                    IdTraining = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdLocation = table.Column<int>(type: "INTEGER", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    IdStuntLeader = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainings", x => x.IdTraining);
                    table.ForeignKey(
                        name: "FK_Trainings_Locations_IdLocation",
                        column: x => x.IdLocation,
                        principalTable: "Locations",
                        principalColumn: "IdLocation",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trainings_StuntLeaders_IdStuntLeader",
                        column: x => x.IdStuntLeader,
                        principalTable: "StuntLeaders",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieStuntmans",
                columns: table => new
                {
                    IdMovieSet = table.Column<int>(type: "INTEGER", nullable: false),
                    IdPerson = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartureDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    MovieStuntmanId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieStuntmans", x => new { x.IdMovieSet, x.IdPerson });
                    table.ForeignKey(
                        name: "FK_MovieStuntmans_MovieSets_IdMovieSet",
                        column: x => x.IdMovieSet,
                        principalTable: "MovieSets",
                        principalColumn: "IdMovieSet",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieStuntmans_Stuntmen_IdPerson",
                        column: x => x.IdPerson,
                        principalTable: "Stuntmen",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExamTrainings",
                columns: table => new
                {
                    IdTraining = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ExaminerLicence = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamTrainings", x => x.IdTraining);
                    table.ForeignKey(
                        name: "FK_ExamTrainings_Trainings_IdTraining",
                        column: x => x.IdTraining,
                        principalTable: "Trainings",
                        principalColumn: "IdTraining",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GroupTrainings",
                columns: table => new
                {
                    IdTraining = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Difficulty = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupTrainings", x => x.IdTraining);
                    table.ForeignKey(
                        name: "FK_GroupTrainings_Trainings_IdTraining",
                        column: x => x.IdTraining,
                        principalTable: "Trainings",
                        principalColumn: "IdTraining",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HorseTraining",
                columns: table => new
                {
                    HorsesIdHorse = table.Column<int>(type: "INTEGER", nullable: false),
                    TrainingsIdTraining = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorseTraining", x => new { x.HorsesIdHorse, x.TrainingsIdTraining });
                    table.ForeignKey(
                        name: "FK_HorseTraining_Horses_HorsesIdHorse",
                        column: x => x.HorsesIdHorse,
                        principalTable: "Horses",
                        principalColumn: "IdHorse",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HorseTraining_Trainings_TrainingsIdTraining",
                        column: x => x.TrainingsIdTraining,
                        principalTable: "Trainings",
                        principalColumn: "IdTraining",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StuntmanTraining",
                columns: table => new
                {
                    StuntmansIdPerson = table.Column<int>(type: "INTEGER", nullable: false),
                    TrainingsIdTraining = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StuntmanTraining", x => new { x.StuntmansIdPerson, x.TrainingsIdTraining });
                    table.ForeignKey(
                        name: "FK_StuntmanTraining_Stuntmen_StuntmansIdPerson",
                        column: x => x.StuntmansIdPerson,
                        principalTable: "Stuntmen",
                        principalColumn: "IdPerson",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StuntmanTraining_Trainings_TrainingsIdTraining",
                        column: x => x.TrainingsIdTraining,
                        principalTable: "Trainings",
                        principalColumn: "IdTraining",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingTypeMappings",
                columns: table => new
                {
                    TrainingId = table.Column<int>(type: "INTEGER", nullable: false),
                    TrainingType = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingTypeMappings", x => new { x.TrainingId, x.TrainingType });
                    table.ForeignKey(
                        name: "FK_TrainingTypeMappings_Trainings_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Trainings",
                        principalColumn: "IdTraining",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HorseTraining_TrainingsIdTraining",
                table: "HorseTraining",
                column: "TrainingsIdTraining");

            migrationBuilder.CreateIndex(
                name: "IX_MovieHorses_IdHorse",
                table: "MovieHorses",
                column: "IdHorse");

            migrationBuilder.CreateIndex(
                name: "IX_MovieStuntmans_IdPerson",
                table: "MovieStuntmans",
                column: "IdPerson");

            migrationBuilder.CreateIndex(
                name: "IX_StuntmanTraining_TrainingsIdTraining",
                table: "StuntmanTraining",
                column: "TrainingsIdTraining");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_IdLocation_DateTime",
                table: "Trainings",
                columns: new[] { "IdLocation", "DateTime" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_IdStuntLeader",
                table: "Trainings",
                column: "IdStuntLeader");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExamTrainings");

            migrationBuilder.DropTable(
                name: "GroupTrainings");

            migrationBuilder.DropTable(
                name: "HorseTraining");

            migrationBuilder.DropTable(
                name: "MovieHorses");

            migrationBuilder.DropTable(
                name: "MovieStuntmans");

            migrationBuilder.DropTable(
                name: "Owners");

            migrationBuilder.DropTable(
                name: "StuntmanTraining");

            migrationBuilder.DropTable(
                name: "TrainingTypeMappings");

            migrationBuilder.DropTable(
                name: "Horses");

            migrationBuilder.DropTable(
                name: "MovieSets");

            migrationBuilder.DropTable(
                name: "Stuntmen");

            migrationBuilder.DropTable(
                name: "Trainings");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "StuntLeaders");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
