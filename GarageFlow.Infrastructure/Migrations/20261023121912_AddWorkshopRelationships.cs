using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GarageFlow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddWorkshopRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_VehicleMaintenanceRecords_WorkshopId",
                table: "VehicleMaintenanceRecords",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_TechnicianAssignments_WorkshopId",
                table: "TechnicianAssignments",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_WorkshopId",
                table: "Suppliers",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierPayments_WorkshopId",
                table: "SupplierPayments",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_StockMovements_WorkshopId",
                table: "StockMovements",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTasks_WorkshopId",
                table: "ServiceTasks",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceFormTemplates_WorkshopId",
                table: "ServiceFormTemplates",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairOrderItems_WorkshopId",
                table: "RepairOrderItems",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItems_WorkshopId",
                table: "PurchaseOrderItems",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_WorkshopId",
                table: "Payments",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_Parts_WorkshopId",
                table: "Parts",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_PartCategories_WorkshopId",
                table: "PartCategories",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceReminders_WorkshopId",
                table: "MaintenanceReminders",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_WorkshopId",
                table: "InvoiceItems",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_WorkshopId",
                table: "Expenses",
                column: "WorkshopId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_WorkshopId",
                table: "Appointments",
                column: "WorkshopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_Workshops_WorkshopId",
                table: "Appointments",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_Workshops_WorkshopId",
                table: "Expenses",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Workshops_WorkshopId",
                table: "InvoiceItems",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Workshops_WorkshopId",
                table: "Invoices",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceReminders_Workshops_WorkshopId",
                table: "MaintenanceReminders",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PartCategories_Workshops_WorkshopId",
                table: "PartCategories",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parts_Workshops_WorkshopId",
                table: "Parts",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Workshops_WorkshopId",
                table: "Payments",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderItems_Workshops_WorkshopId",
                table: "PurchaseOrderItems",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_Workshops_WorkshopId",
                table: "PurchaseOrders",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RepairOrderItems_Workshops_WorkshopId",
                table: "RepairOrderItems",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceFormTemplates_Workshops_WorkshopId",
                table: "ServiceFormTemplates",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceTasks_Workshops_WorkshopId",
                table: "ServiceTasks",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockMovements_Workshops_WorkshopId",
                table: "StockMovements",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SupplierPayments_Workshops_WorkshopId",
                table: "SupplierPayments",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Workshops_WorkshopId",
                table: "Suppliers",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TechnicianAssignments_Workshops_WorkshopId",
                table: "TechnicianAssignments",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleMaintenanceRecords_Workshops_WorkshopId",
                table: "VehicleMaintenanceRecords",
                column: "WorkshopId",
                principalTable: "Workshops",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_Workshops_WorkshopId",
                table: "Appointments");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_Workshops_WorkshopId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Workshops_WorkshopId",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Workshops_WorkshopId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceReminders_Workshops_WorkshopId",
                table: "MaintenanceReminders");

            migrationBuilder.DropForeignKey(
                name: "FK_PartCategories_Workshops_WorkshopId",
                table: "PartCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Parts_Workshops_WorkshopId",
                table: "Parts");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Workshops_WorkshopId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderItems_Workshops_WorkshopId",
                table: "PurchaseOrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_Workshops_WorkshopId",
                table: "PurchaseOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_RepairOrderItems_Workshops_WorkshopId",
                table: "RepairOrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceFormTemplates_Workshops_WorkshopId",
                table: "ServiceFormTemplates");

            migrationBuilder.DropForeignKey(
                name: "FK_ServiceTasks_Workshops_WorkshopId",
                table: "ServiceTasks");

            migrationBuilder.DropForeignKey(
                name: "FK_StockMovements_Workshops_WorkshopId",
                table: "StockMovements");

            migrationBuilder.DropForeignKey(
                name: "FK_SupplierPayments_Workshops_WorkshopId",
                table: "SupplierPayments");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Workshops_WorkshopId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_TechnicianAssignments_Workshops_WorkshopId",
                table: "TechnicianAssignments");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleMaintenanceRecords_Workshops_WorkshopId",
                table: "VehicleMaintenanceRecords");

            migrationBuilder.DropIndex(
                name: "IX_VehicleMaintenanceRecords_WorkshopId",
                table: "VehicleMaintenanceRecords");

            migrationBuilder.DropIndex(
                name: "IX_TechnicianAssignments_WorkshopId",
                table: "TechnicianAssignments");

            migrationBuilder.DropIndex(
                name: "IX_Suppliers_WorkshopId",
                table: "Suppliers");

            migrationBuilder.DropIndex(
                name: "IX_SupplierPayments_WorkshopId",
                table: "SupplierPayments");

            migrationBuilder.DropIndex(
                name: "IX_StockMovements_WorkshopId",
                table: "StockMovements");

            migrationBuilder.DropIndex(
                name: "IX_ServiceTasks_WorkshopId",
                table: "ServiceTasks");

            migrationBuilder.DropIndex(
                name: "IX_ServiceFormTemplates_WorkshopId",
                table: "ServiceFormTemplates");

            migrationBuilder.DropIndex(
                name: "IX_RepairOrderItems_WorkshopId",
                table: "RepairOrderItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderItems_WorkshopId",
                table: "PurchaseOrderItems");

            migrationBuilder.DropIndex(
                name: "IX_Payments_WorkshopId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Parts_WorkshopId",
                table: "Parts");

            migrationBuilder.DropIndex(
                name: "IX_PartCategories_WorkshopId",
                table: "PartCategories");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceReminders_WorkshopId",
                table: "MaintenanceReminders");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceItems_WorkshopId",
                table: "InvoiceItems");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_WorkshopId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_WorkshopId",
                table: "Appointments");
        }
    }
}
