﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DoXM_Server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DoXMUserOptions",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    ConsolePrompt = table.Column<string>(maxLength: 5, nullable: true),
                    CommandModeShortcutDoXM = table.Column<string>(maxLength: 10, nullable: true),
                    CommandModeShortcutPSCore = table.Column<string>(maxLength: 10, nullable: true),
                    CommandModeShortcutWinPS = table.Column<string>(maxLength: 10, nullable: true),
                    CommandModeShortcutCMD = table.Column<string>(maxLength: 10, nullable: true),
                    CommandModeShortcutBash = table.Column<string>(maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoXMUserOptions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    OrganizationName = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommandContexts",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    CommandMode = table.Column<string>(nullable: true),
                    CommandText = table.Column<string>(nullable: true),
                    SenderUserID = table.Column<string>(nullable: true),
                    SenderConnectionID = table.Column<string>(nullable: true),
                    TargetMachineIDs = table.Column<string>(nullable: true),
                    PSCoreResults = table.Column<string>(nullable: true),
                    CommandResults = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    OrganizationID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommandContexts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CommandContexts_Organizations_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organizations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DoXMUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    UserOptions = table.Column<string>(nullable: true),
                    OrganizationID = table.Column<string>(nullable: true),
                    PermissionGroups = table.Column<string>(nullable: true),
                    IsAdministrator = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoXMUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DoXMUsers_Organizations_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organizations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EventLogs",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    EventType = table.Column<int>(nullable: false),
                    Message = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    StackTrace = table.Column<string>(nullable: true),
                    OrganizationID = table.Column<string>(nullable: true),
                    TimeStamp = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLogs", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EventLogs_Organizations_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organizations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InviteLinks",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    InvitedUser = table.Column<string>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: false),
                    DateSent = table.Column<DateTime>(nullable: false),
                    OrganizationID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InviteLinks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_InviteLinks_Organizations_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organizations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Is64Bit = table.Column<bool>(nullable: false),
                    IsOnline = table.Column<bool>(nullable: false),
                    LastOnline = table.Column<DateTime>(nullable: false),
                    MachineName = table.Column<string>(nullable: true),
                    OrganizationID = table.Column<string>(nullable: true),
                    OSArchitecture = table.Column<int>(nullable: false),
                    OSDescription = table.Column<string>(nullable: true),
                    Platform = table.Column<string>(nullable: true),
                    ProcessorCount = table.Column<int>(nullable: false),
                    TotalMemory = table.Column<double>(nullable: false),
                    FreeStorage = table.Column<double>(nullable: false),
                    TotalStorage = table.Column<double>(nullable: false),
                    FreeMemory = table.Column<double>(nullable: false),
                    CurrentUser = table.Column<string>(nullable: true),
                    Tags = table.Column<string>(maxLength: 200, nullable: true),
                    ServerVerificationToken = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Machines_Organizations_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organizations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SharedFiles",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    FileName = table.Column<string>(nullable: true),
                    ContentType = table.Column<string>(nullable: true),
                    FileContents = table.Column<byte[]>(nullable: true),
                    Timestamp = table.Column<DateTime>(nullable: false),
                    OrganizationID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedFiles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SharedFiles_Organizations_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organizations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_DoXMUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "DoXMUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_DoXMUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "DoXMUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_DoXMUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "DoXMUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_DoXMUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "DoXMUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drives",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    DriveType = table.Column<int>(nullable: false),
                    RootDirectory = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DriveFormat = table.Column<string>(nullable: true),
                    FreeSpace = table.Column<double>(nullable: false),
                    TotalSize = table.Column<double>(nullable: false),
                    VolumeLabel = table.Column<string>(nullable: true),
                    MachineID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drives", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Drives_Machines_MachineID",
                        column: x => x.MachineID,
                        principalTable: "Machines",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PermissionGroups",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    OrganizationID = table.Column<string>(nullable: true),
                    MachineID = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionGroups", x => x.ID);
                    table.ForeignKey(
                        name: "FK_PermissionGroups_Machines_MachineID",
                        column: x => x.MachineID,
                        principalTable: "Machines",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PermissionGroups_Organizations_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organizations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_CommandContexts_OrganizationID",
                table: "CommandContexts",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_DoXMUsers_OrganizationID",
                table: "DoXMUsers",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "DoXMUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "DoXMUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Drives_MachineID",
                table: "Drives",
                column: "MachineID");

            migrationBuilder.CreateIndex(
                name: "IX_EventLogs_OrganizationID",
                table: "EventLogs",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_InviteLinks_OrganizationID",
                table: "InviteLinks",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_OrganizationID",
                table: "Machines",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionGroups_MachineID",
                table: "PermissionGroups",
                column: "MachineID");

            migrationBuilder.CreateIndex(
                name: "IX_PermissionGroups_OrganizationID",
                table: "PermissionGroups",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_SharedFiles_OrganizationID",
                table: "SharedFiles",
                column: "OrganizationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CommandContexts");

            migrationBuilder.DropTable(
                name: "DoXMUserOptions");

            migrationBuilder.DropTable(
                name: "Drives");

            migrationBuilder.DropTable(
                name: "EventLogs");

            migrationBuilder.DropTable(
                name: "InviteLinks");

            migrationBuilder.DropTable(
                name: "PermissionGroups");

            migrationBuilder.DropTable(
                name: "SharedFiles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "DoXMUsers");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}
