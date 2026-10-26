
using System.Linq.Expressions;
using GarageFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GarageFlow.Infrastructure.Data;

public class GarageFlowDbContext : DbContext
{
    public GarageFlowDbContext(DbContextOptions<GarageFlowDbContext> options)
        : base(options)
    {
    }

    public DbSet<Workshop> Workshops => Set<Workshop>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();

    public DbSet<SubscriptionPlan> SubscriptionPlans => Set<SubscriptionPlan>();
    public DbSet<Subscription> Subscriptions => Set<Subscription>();

    public DbSet<RepairOrder> RepairOrders => Set<RepairOrder>();
    public DbSet<RepairOrderItem> RepairOrderItems => Set<RepairOrderItem>();
    public DbSet<ServiceTask> ServiceTasks => Set<ServiceTask>();
    public DbSet<TechnicianAssignment> TechnicianAssignments => Set<TechnicianAssignment>();
    public DbSet<Appointment> Appointments => Set<Appointment>();
    public DbSet<VehicleMaintenanceRecord> VehicleMaintenanceRecords => Set<VehicleMaintenanceRecord>();
    public DbSet<MaintenanceReminder> MaintenanceReminders => Set<MaintenanceReminder>();
    public DbSet<ServiceFormTemplate> ServiceFormTemplates => Set<ServiceFormTemplate>();

    public DbSet<PartCategory> PartCategories => Set<PartCategory>();
    public DbSet<Part> Parts => Set<Part>();
    public DbSet<StockMovement> StockMovements => Set<StockMovement>();
    public DbSet<Supplier> Suppliers => Set<Supplier>();
    public DbSet<PurchaseOrder> PurchaseOrders => Set<PurchaseOrder>();
    public DbSet<PurchaseOrderItem> PurchaseOrderItems => Set<PurchaseOrderItem>();

    public DbSet<Invoice> Invoices => Set<Invoice>();
    public DbSet<InvoiceItem> InvoiceItems => Set<InvoiceItem>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<Expense> Expenses => Set<Expense>();
    public DbSet<SupplierPayment> SupplierPayments => Set<SupplierPayment>();

    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // WORKSHOP
        modelBuilder.Entity<Workshop>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(150)
                .IsRequired();

            entity.Property(e => e.PhoneNumber).HasMaxLength(30);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.TaxNumber).HasMaxLength(50);
        });

        // USER
        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Email).HasMaxLength(256).IsRequired();
            entity.Property(e => e.PasswordHash).IsRequired();

            entity.HasIndex(e => e.Email)
                .IsUnique()
                .HasFilter("[IsDeleted] = 0");

            entity.HasOne(e => e.Workshop)
                .WithMany(e => e.Users)
                .HasForeignKey(e => e.WorkshopId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Role)
                .WithMany()
                .HasForeignKey(e => e.RoleId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // ROLE
        modelBuilder.Entity<Role>(entity =>
        {
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();

            entity.HasIndex(e => e.Name).IsUnique();
        });

        // CUSTOMER
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.Property(e => e.FirstName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.LastName).HasMaxLength(100).IsRequired();
            entity.Property(e => e.PhoneNumber).HasMaxLength(30).IsRequired();
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.Address).HasMaxLength(500);

            entity.HasIndex(e => new { e.WorkshopId, e.PhoneNumber });

            entity.HasOne(e => e.Workshop)
                .WithMany(e => e.Customers)
                .HasForeignKey(e => e.WorkshopId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // VEHICLE
        modelBuilder.Entity<Vehicle>(entity =>
        {
            entity.Property(e => e.PlateNumber).HasMaxLength(20).IsRequired();
            entity.Property(e => e.VinNumber).HasMaxLength(50);
            entity.Property(e => e.Brand).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Model).HasMaxLength(100).IsRequired();
            entity.Property(e => e.FuelType).HasMaxLength(30);

            entity.HasIndex(e => new { e.WorkshopId, e.PlateNumber })
                .IsUnique()
                .HasFilter("[IsDeleted] = 0");

            entity.HasOne(e => e.Workshop)
                .WithMany(e => e.Vehicles)
                .HasForeignKey(e => e.WorkshopId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Customer)
                .WithMany(e => e.Vehicles)
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // SUBSCRIPTION PLANS
        modelBuilder.Entity<SubscriptionPlan>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Price).HasPrecision(18, 2);
        });

        // SUBSCRIPTIONS
        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.Property(e => e.Status).HasMaxLength(30).IsRequired();

            entity.HasOne(e => e.Workshop)
                .WithMany()
                .HasForeignKey(e => e.WorkshopId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.SubscriptionPlan)
                .WithMany()
                .HasForeignKey(e => e.SubscriptionPlanId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // REPAIR ORDERS
        modelBuilder.Entity<RepairOrder>(entity =>
        {
            entity.Property(e => e.OrderNumber).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Status).HasMaxLength(30).IsRequired();

            entity.HasIndex(e => new { e.WorkshopId, e.OrderNumber })
                .IsUnique()
                .HasFilter("[IsDeleted] = 0");

            entity.HasOne(e => e.Workshop)
                .WithMany(e => e.RepairOrders)
                .HasForeignKey(e => e.WorkshopId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Vehicle)
                .WithMany(e => e.RepairOrders)
                .HasForeignKey(e => e.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.AssignedTechnician)
                .WithMany()
                .HasForeignKey(e => e.AssignedTechnicianId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // REPAIR ORDER ITEMS
        modelBuilder.Entity<RepairOrderItem>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(500).IsRequired();

            entity.HasOne(e => e.RepairOrder)
                .WithMany(e => e.Items)
                .HasForeignKey(e => e.RepairOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Part)
                .WithMany()
                .HasForeignKey(e => e.PartId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // SERVICE TASKS
        modelBuilder.Entity<ServiceTask>(entity =>
        {
            entity.Property(e => e.Title).HasMaxLength(200).IsRequired();
            entity.Property(e => e.Status).HasMaxLength(30).IsRequired();

            entity.HasOne(e => e.RepairOrder)
                .WithMany()
                .HasForeignKey(e => e.RepairOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.AssignedUser)
                .WithMany()
                .HasForeignKey(e => e.AssignedUserId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // TECHNICIAN ASSIGNMENTS
        modelBuilder.Entity<TechnicianAssignment>(entity =>
        {
            entity.HasOne(e => e.RepairOrder)
                .WithMany()
                .HasForeignKey(e => e.RepairOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // APPOINTMENTS
        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.Property(e => e.Reason).HasMaxLength(300).IsRequired();
            entity.Property(e => e.Status).HasMaxLength(30).IsRequired();

            entity.HasOne(e => e.Customer)
                .WithMany()
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Vehicle)
                .WithMany()
                .HasForeignKey(e => e.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // VEHICLE MAINTENANCE RECORDS
        modelBuilder.Entity<VehicleMaintenanceRecord>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(500).IsRequired();

            entity.HasOne(e => e.Vehicle)
                .WithMany(e => e.MaintenanceRecords)
                .HasForeignKey(e => e.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // MAINTENANCE REMINDERS
        modelBuilder.Entity<MaintenanceReminder>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(500).IsRequired();

            entity.HasOne(e => e.Vehicle)
                .WithMany()
                .HasForeignKey(e => e.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Customer)
                .WithMany()
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // SERVICE FORM TEMPLATES
        modelBuilder.Entity<ServiceFormTemplate>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(150).IsRequired();
        });

        // PART CATEGORIES
        modelBuilder.Entity<PartCategory>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(100).IsRequired();
        });

        // PARTS
        modelBuilder.Entity<Part>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(200).IsRequired();
            entity.Property(e => e.PartNumber).HasMaxLength(100);
            entity.Property(e => e.Barcode).HasMaxLength(100);
            entity.Property(e => e.Unit).HasMaxLength(30);

            entity.HasOne(e => e.PartCategory)
                .WithMany()
                .HasForeignKey(e => e.PartCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Supplier)
                .WithMany(e => e.Parts)
                .HasForeignKey(e => e.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // STOCK MOVEMENTS
        modelBuilder.Entity<StockMovement>(entity =>
        {
            entity.Property(e => e.MovementType).HasMaxLength(30).IsRequired();

            entity.HasOne(e => e.Part)
                .WithMany()
                .HasForeignKey(e => e.PartId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.RepairOrder)
                .WithMany()
                .HasForeignKey(e => e.RepairOrderId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // SUPPLIERS
        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(200).IsRequired();
            entity.Property(e => e.PhoneNumber).HasMaxLength(30);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.TaxNumber).HasMaxLength(50);
        });

        // PURCHASE ORDERS
        modelBuilder.Entity<PurchaseOrder>(entity =>
        {
            entity.Property(e => e.OrderNumber).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Status).HasMaxLength(30).IsRequired();

            entity.HasIndex(e => new { e.WorkshopId, e.OrderNumber })
                .IsUnique()
                .HasFilter("[IsDeleted] = 0");

            entity.HasOne(e => e.Supplier)
                .WithMany(e => e.PurchaseOrders)
                .HasForeignKey(e => e.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(e => e.Items)
                .WithOne(e => e.PurchaseOrder)
                .HasForeignKey(e => e.PurchaseOrderId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // PURCHASE ORDER ITEMS
        modelBuilder.Entity<PurchaseOrderItem>(entity =>
        {
            entity.HasOne(e => e.Part)
                .WithMany()
                .HasForeignKey(e => e.PartId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // INVOICES
        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.Property(e => e.InvoiceNumber).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Status).HasMaxLength(30).IsRequired();

            entity.HasIndex(e => new { e.WorkshopId, e.InvoiceNumber })
                .IsUnique()
                .HasFilter("[IsDeleted] = 0");

            entity.HasOne(e => e.Customer)
                .WithMany()
                .HasForeignKey(e => e.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.RepairOrder)
                .WithMany()
                .HasForeignKey(e => e.RepairOrderId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(e => e.Items)
                .WithOne(e => e.Invoice)
                .HasForeignKey(e => e.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(e => e.Payments)
                .WithOne(e => e.Invoice)
                .HasForeignKey(e => e.InvoiceId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // INVOICE ITEMS
        modelBuilder.Entity<InvoiceItem>(entity =>
        {
            entity.Property(e => e.Description).HasMaxLength(500).IsRequired();
        });

        // PAYMENTS
        modelBuilder.Entity<Payment>(entity =>
        {
            entity.Property(e => e.PaymentMethod).HasMaxLength(50).IsRequired();
            entity.Property(e => e.TransactionReference).HasMaxLength(150);
        });

        // EXPENSES
        modelBuilder.Entity<Expense>(entity =>
        {
            entity.Property(e => e.Category).HasMaxLength(100).IsRequired();
            entity.Property(e => e.Description).HasMaxLength(300).IsRequired();
            entity.Property(e => e.PaymentMethod).HasMaxLength(50);
        });

        // SUPPLIER PAYMENTS
        modelBuilder.Entity<SupplierPayment>(entity =>
        {
            entity.Property(e => e.PaymentMethod).HasMaxLength(50).IsRequired();

            entity.HasOne(e => e.Supplier)
                .WithMany()
                .HasForeignKey(e => e.SupplierId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.PurchaseOrder)
                .WithMany()
                .HasForeignKey(e => e.PurchaseOrderId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // AUDIT LOGS
        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.Property(e => e.Action).HasMaxLength(100).IsRequired();
            entity.Property(e => e.EntityName).HasMaxLength(150).IsRequired();

            entity.HasOne<Workshop>()
                .WithMany()
                .HasForeignKey(e => e.WorkshopId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne<User>()
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // WORKSHOP RELATIONSHIPS
        // Her kaydın geçerli bir atölyeye bağlı olmasını sağlar.

        modelBuilder.Entity<Appointment>()
            .HasOne<Workshop>()
            .WithMany()
            .HasForeignKey(e => e.WorkshopId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<RepairOrderItem>()
            .HasOne<Workshop>()
            .WithMany()
            .HasForeignKey(e => e.WorkshopId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ServiceTask>()
            .HasOne<Workshop>()
            .WithMany()
            .HasForeignKey(e => e.WorkshopId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<TechnicianAssignment>()
            .HasOne<Workshop>()
            .WithMany()
            .HasForeignKey(e => e.WorkshopId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<VehicleMaintenanceRecord>()
            .HasOne<Workshop>()
            .WithMany()
            .HasForeignKey(e => e.WorkshopId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<MaintenanceReminder>()
            .HasOne<Workshop>()
            .WithMany()
            .HasForeignKey(e => e.WorkshopId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ServiceFormTemplate>()
            .HasOne<Workshop>()
            .WithMany()
            .HasForeignKey(e => e.WorkshopId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<PartCategory>()
            .HasOne<Workshop>()
            .WithMany()
            .HasForeignKey(e => e.WorkshopId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Part>()
            .HasOne<Workshop>()
            .WithMany()
            .HasForeignKey(e => e.WorkshopId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<StockMovement>()
            .HasOne<Workshop>()
            .WithMany()
            .HasForeignKey(e => e.WorkshopId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Supplier>()
            .HasOne<Workshop>()
            .WithMany()
            .HasForeignKey(e => e.WorkshopId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<PurchaseOrder>()
            .HasOne<Workshop>()
            .WithMany()
            .HasForeignKey(e => e.WorkshopId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<PurchaseOrderItem>()
            .HasOne<Workshop>()
            .WithMany()
            .HasForeignKey(e => e.WorkshopId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Invoice>()
            .HasOne<Workshop>()
            .WithMany()
            .HasForeignKey(e => e.WorkshopId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<InvoiceItem>()
            .HasOne<Workshop>()
            .WithMany()
            .HasForeignKey(e => e.WorkshopId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Payment>()
            .HasOne<Workshop>()
            .WithMany()
            .HasForeignKey(e => e.WorkshopId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Expense>()
            .HasOne<Workshop>()
            .WithMany()
            .HasForeignKey(e => e.WorkshopId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<SupplierPayment>()
            .HasOne<Workshop>()
            .WithMany()
            .HasForeignKey(e => e.WorkshopId)
            .OnDelete(DeleteBehavior.Restrict);

        // Configure decimal columns consistently.
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                var propertyType = Nullable.GetUnderlyingType(property.ClrType)
                    ?? property.ClrType;

                if (propertyType == typeof(decimal))
                {
                    property.SetPrecision(18);
                    property.SetScale(2);
                }
            }
        }

        // Apply soft-delete query filters to every BaseEntity.
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (typeof(BaseEntity).IsAssignableFrom(entityType.ClrType))
            {
                var parameter = Expression.Parameter(entityType.ClrType, "entity");
                var isDeletedProperty = Expression.Property(
                    parameter,
                    nameof(BaseEntity.IsDeleted));

                var filter = Expression.Lambda(
                    Expression.Not(isDeletedProperty),
                    parameter);

                modelBuilder.Entity(entityType.ClrType)
                    .HasQueryFilter(filter);
            }
        }
    }
}
