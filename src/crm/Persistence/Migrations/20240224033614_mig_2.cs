using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("bdc51dc2-688e-4acd-84e6-7c6db245886c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6c002084-d751-438d-b0f4-aed2fccfed88"));

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("4f376bc4-48a1-4f60-81d3-20ca512bc0b9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Administration", null },
                    { new Guid("65e327d4-b892-4d88-8f21-c40cbabf68b1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Accounting", null },
                    { new Guid("731d1968-0cc5-492e-bec8-50cf4d8360a9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Technical", null },
                    { new Guid("c55c0cd6-8aa1-4939-a9cb-7f6014832177"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Marketing", null },
                    { new Guid("fb89c2dd-ff38-4fce-9ea6-56401546d574"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Sale", null }
                });

            migrationBuilder.InsertData(
                table: "DocumentTypes",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("4ec39d53-6f1d-4186-a61d-ad35c5ed3450"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Video", null },
                    { new Guid("a787e8c8-688c-4136-997a-78480d8fcba4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "PDF", null },
                    { new Guid("e5006e3e-125f-4ede-b420-68228c519986"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Audio", null },
                    { new Guid("fc122d1d-76e2-43b0-95f9-77549243963e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Word", null }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("b3c738fa-9804-4d9e-ac55-cde249bfde18"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Male", null },
                    { new Guid("f4927897-d35f-4831-852d-8e1b627a2ef3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Female", null }
                });

            migrationBuilder.InsertData(
                table: "OfferStatus",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("22923ffb-c916-4da2-b719-5b9e7c7df54d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "In Progress", null },
                    { new Guid("b5ffa64c-f30e-4eb6-bab7-50a2c908a81b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Resolved", null },
                    { new Guid("bb49bce3-3fd5-4275-8a85-19067eb16b97"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Closed", null },
                    { new Guid("dc6dcf57-f1a2-4b20-b21e-6e6ba51c88a1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Open", null }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "ParentId", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("05f7c4c3-414b-405e-8bab-ef442319eaa9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Istanbul-Avrupa", null, null },
                    { new Guid("53943039-b33c-467d-a008-2e0d95ba87bb"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Ankara", null, null },
                    { new Guid("d16e0e90-ff92-4042-aef0-b57b806c2e92"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Istanbul-Anadolu", null, null }
                });

            migrationBuilder.InsertData(
                table: "RequestStatus",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("64f4fcf1-52d4-44fd-b718-fefd83cc75f5"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Closed", null },
                    { new Guid("91c80db3-b5f9-47d5-a3ce-5408ba570b90"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Open", null },
                    { new Guid("afe3c2fc-706b-43e7-8103-15752f60f31e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "In Progress", null },
                    { new Guid("c55d4f44-ced4-49e7-858f-3e702c3d0ea1"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Resolved", null }
                });

            migrationBuilder.InsertData(
                table: "StatusTypes",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("44781ae5-867b-4ffd-8630-975ebd3ce1e4"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Archive", null },
                    { new Guid("5ca52076-eb28-428c-9807-fbe11e5982a7"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Black Listed", null },
                    { new Guid("fb8acafb-1989-404c-8819-97a2c130c279"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Active", null }
                });

            migrationBuilder.InsertData(
                table: "TaskStatus",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "Name", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("49f1ab92-50bd-402d-8ce0-99f8ae905165"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Open", null },
                    { new Guid("5f13e38a-b5dc-4d99-a4d8-0229f9ec598c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Closed", null },
                    { new Guid("627ca954-1817-4a61-8e39-7de70cd6a611"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Resolved", null },
                    { new Guid("9a15da5f-dd81-4128-9e43-7e65e8c217b9"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "In Progress", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("155119c8-1191-4ea2-af66-a28a314d5540"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@alikemaluysal.com", new byte[] { 153, 0, 215, 176, 4, 239, 242, 114, 228, 238, 65, 169, 195, 129, 142, 58, 6, 167, 116, 49, 148, 156, 36, 36, 92, 231, 236, 209, 181, 64, 235, 214, 170, 156, 217, 37, 216, 0, 166, 142, 121, 16, 64, 124, 8, 180, 218, 190, 34, 34, 132, 44, 54, 35, 100, 226, 12, 134, 216, 248, 74, 40, 100, 0 }, new byte[] { 83, 232, 152, 11, 65, 132, 213, 220, 195, 232, 71, 59, 112, 170, 183, 224, 26, 29, 140, 148, 255, 106, 184, 55, 82, 83, 196, 154, 153, 44, 197, 72, 133, 216, 175, 251, 81, 54, 42, 7, 221, 69, 59, 223, 189, 123, 112, 99, 84, 191, 24, 48, 26, 193, 199, 133, 201, 179, 243, 23, 206, 153, 59, 79, 211, 253, 193, 121, 226, 215, 226, 215, 104, 118, 43, 100, 18, 144, 248, 207, 118, 115, 41, 41, 16, 15, 119, 172, 63, 171, 93, 70, 237, 65, 25, 17, 166, 104, 21, 162, 113, 170, 9, 213, 32, 104, 200, 150, 247, 251, 250, 196, 200, 173, 132, 183, 78, 85, 78, 182, 247, 17, 133, 138, 61, 87, 182, 114 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("99b7bf86-2530-4075-8862-264efd540658"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("155119c8-1191-4ea2-af66-a28a314d5540") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("4f376bc4-48a1-4f60-81d3-20ca512bc0b9"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("65e327d4-b892-4d88-8f21-c40cbabf68b1"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("731d1968-0cc5-492e-bec8-50cf4d8360a9"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("c55c0cd6-8aa1-4939-a9cb-7f6014832177"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("fb89c2dd-ff38-4fce-9ea6-56401546d574"));

            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("4ec39d53-6f1d-4186-a61d-ad35c5ed3450"));

            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("a787e8c8-688c-4136-997a-78480d8fcba4"));

            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("e5006e3e-125f-4ede-b420-68228c519986"));

            migrationBuilder.DeleteData(
                table: "DocumentTypes",
                keyColumn: "Id",
                keyValue: new Guid("fc122d1d-76e2-43b0-95f9-77549243963e"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("b3c738fa-9804-4d9e-ac55-cde249bfde18"));

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: new Guid("f4927897-d35f-4831-852d-8e1b627a2ef3"));

            migrationBuilder.DeleteData(
                table: "OfferStatus",
                keyColumn: "Id",
                keyValue: new Guid("22923ffb-c916-4da2-b719-5b9e7c7df54d"));

            migrationBuilder.DeleteData(
                table: "OfferStatus",
                keyColumn: "Id",
                keyValue: new Guid("b5ffa64c-f30e-4eb6-bab7-50a2c908a81b"));

            migrationBuilder.DeleteData(
                table: "OfferStatus",
                keyColumn: "Id",
                keyValue: new Guid("bb49bce3-3fd5-4275-8a85-19067eb16b97"));

            migrationBuilder.DeleteData(
                table: "OfferStatus",
                keyColumn: "Id",
                keyValue: new Guid("dc6dcf57-f1a2-4b20-b21e-6e6ba51c88a1"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("05f7c4c3-414b-405e-8bab-ef442319eaa9"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("53943039-b33c-467d-a008-2e0d95ba87bb"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d16e0e90-ff92-4042-aef0-b57b806c2e92"));

            migrationBuilder.DeleteData(
                table: "RequestStatus",
                keyColumn: "Id",
                keyValue: new Guid("64f4fcf1-52d4-44fd-b718-fefd83cc75f5"));

            migrationBuilder.DeleteData(
                table: "RequestStatus",
                keyColumn: "Id",
                keyValue: new Guid("91c80db3-b5f9-47d5-a3ce-5408ba570b90"));

            migrationBuilder.DeleteData(
                table: "RequestStatus",
                keyColumn: "Id",
                keyValue: new Guid("afe3c2fc-706b-43e7-8103-15752f60f31e"));

            migrationBuilder.DeleteData(
                table: "RequestStatus",
                keyColumn: "Id",
                keyValue: new Guid("c55d4f44-ced4-49e7-858f-3e702c3d0ea1"));

            migrationBuilder.DeleteData(
                table: "StatusTypes",
                keyColumn: "Id",
                keyValue: new Guid("44781ae5-867b-4ffd-8630-975ebd3ce1e4"));

            migrationBuilder.DeleteData(
                table: "StatusTypes",
                keyColumn: "Id",
                keyValue: new Guid("5ca52076-eb28-428c-9807-fbe11e5982a7"));

            migrationBuilder.DeleteData(
                table: "StatusTypes",
                keyColumn: "Id",
                keyValue: new Guid("fb8acafb-1989-404c-8819-97a2c130c279"));

            migrationBuilder.DeleteData(
                table: "TaskStatus",
                keyColumn: "Id",
                keyValue: new Guid("49f1ab92-50bd-402d-8ce0-99f8ae905165"));

            migrationBuilder.DeleteData(
                table: "TaskStatus",
                keyColumn: "Id",
                keyValue: new Guid("5f13e38a-b5dc-4d99-a4d8-0229f9ec598c"));

            migrationBuilder.DeleteData(
                table: "TaskStatus",
                keyColumn: "Id",
                keyValue: new Guid("627ca954-1817-4a61-8e39-7de70cd6a611"));

            migrationBuilder.DeleteData(
                table: "TaskStatus",
                keyColumn: "Id",
                keyValue: new Guid("9a15da5f-dd81-4128-9e43-7e65e8c217b9"));

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("99b7bf86-2530-4075-8862-264efd540658"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("155119c8-1191-4ea2-af66-a28a314d5540"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("6c002084-d751-438d-b0f4-aed2fccfed88"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "admin@alikemaluysal.com", new byte[] { 168, 98, 78, 176, 248, 160, 227, 18, 41, 102, 97, 138, 24, 77, 12, 168, 91, 68, 130, 156, 64, 42, 21, 124, 36, 17, 188, 168, 60, 172, 224, 212, 118, 143, 237, 239, 66, 224, 172, 230, 245, 30, 186, 22, 227, 47, 94, 122, 49, 15, 126, 6, 221, 97, 175, 73, 100, 227, 170, 73, 3, 236, 237, 220 }, new byte[] { 164, 167, 134, 73, 62, 67, 141, 236, 199, 33, 22, 85, 8, 221, 45, 63, 194, 26, 53, 28, 129, 180, 2, 205, 32, 246, 24, 251, 200, 152, 178, 250, 115, 0, 34, 112, 64, 89, 176, 168, 230, 128, 20, 91, 223, 15, 248, 9, 54, 25, 148, 188, 160, 246, 145, 71, 93, 41, 22, 93, 71, 21, 104, 237, 236, 57, 224, 76, 25, 215, 192, 224, 83, 105, 32, 144, 185, 181, 68, 71, 177, 5, 31, 250, 128, 34, 219, 161, 128, 27, 107, 109, 159, 96, 241, 52, 21, 177, 172, 95, 53, 12, 51, 16, 56, 2, 123, 138, 66, 78, 116, 166, 138, 76, 220, 157, 53, 160, 25, 252, 234, 70, 234, 103, 183, 223, 173, 66 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("bdc51dc2-688e-4acd-84e6-7c6db245886c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("6c002084-d751-438d-b0f4-aed2fccfed88") });
        }
    }
}
