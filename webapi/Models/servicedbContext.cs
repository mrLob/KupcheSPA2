using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace webapi.Models
{
    public partial class servicedbContext : DbContext
    {
        public virtual DbSet<Activitytypes> Activitytypes { get; set; }
        public virtual DbSet<Addresses> Addresses { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<Companyactivity> Companyactivity { get; set; }
        public virtual DbSet<Companyorders> Companyorders { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Currencies> Currencies { get; set; }
        public virtual DbSet<Files> Files { get; set; }
        public virtual DbSet<Goods> Goods { get; set; }
        public virtual DbSet<Images> Images { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
        public virtual DbSet<Nomenclatures> Nomenclatures { get; set; }
        public virtual DbSet<Orderfiles> Orderfiles { get; set; }
        public virtual DbSet<Orderimages> Orderimages { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Positions> Positions { get; set; }
        public virtual DbSet<Pricelist> Pricelist { get; set; }
        public virtual DbSet<Rooms> Rooms { get; set; }
        public virtual DbSet<Roomusers> Roomusers { get; set; }
        public virtual DbSet<Rules> Rules { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<Signinup> Signinup { get; set; }
        public virtual DbSet<Subcategory> Subcategory { get; set; }
        public virtual DbSet<Supercategories> Supercategories { get; set; }
        public virtual DbSet<Units> Units { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                string dbServer = "86.57.161.56"; 
                string dbUser = "KupecApp";
                string dbPass = "Forma7369milk";
                optionsBuilder.UseMySql("Server="+dbServer
                +";user="+dbUser
                +";password="+dbPass+
                ";database=servicedb;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Activitytypes>(entity =>
            {
                entity.HasKey(e => e.IdActivityTypes);

                entity.ToTable("activitytypes");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("fk_ActivityTypes_Category_idx");

                entity.HasIndex(e => e.ChildOf)
                    .HasName("fk_ActivityTypes_1_idx");

                entity.Property(e => e.IdActivityTypes)
                    .HasColumnName("idActivityTypes")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdditionTime)
                    .HasColumnName("addition_time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.CategoryId).HasColumnType("int(11)");

                entity.Property(e => e.ChildOf)
                    .HasColumnName("Child_Of")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Activitytypes)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("fk_ActivityTypes_Category");

                entity.HasOne(d => d.ChildOfNavigation)
                    .WithMany(p => p.InverseChildOfNavigation)
                    .HasForeignKey(d => d.ChildOf)
                    .HasConstraintName("fk_ActivityTypes_Child");
            });

            modelBuilder.Entity<Addresses>(entity =>
            {
                entity.HasKey(e => e.IdAddress);

                entity.ToTable("addresses");

                entity.HasIndex(e => e.CityId)
                    .HasName("fk_Address_City_idx");

                entity.Property(e => e.IdAddress)
                    .HasColumnName("idAddress")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdditionTime)
                    .HasColumnName("addition_time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.CityId).HasColumnType("int(11)");

                entity.Property(e => e.Flat).HasMaxLength(45);

                entity.Property(e => e.Geomap).HasMaxLength(45);

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Number).HasColumnType("int(11)");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Zip)
                    .HasColumnName("ZIP")
                    .HasMaxLength(45);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Address_City");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.IdCity);

                entity.ToTable("city");

                entity.HasIndex(e => e.CountryId)
                    .HasName("fk_City_1_idx");

                entity.Property(e => e.IdCity)
                    .HasColumnName("idCity")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdditionTime)
                    .HasColumnName("addition_time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.CountryId).HasColumnType("int(11)");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.City)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_City_Country");
            });

            modelBuilder.Entity<Companies>(entity =>
            {
                entity.HasKey(e => e.IdCompany);

                entity.ToTable("companies");

                entity.HasIndex(e => e.AddressId)
                    .HasName("fk_Company_Addresses_idx");

                entity.HasIndex(e => e.ImageId)
                    .HasName("fk_Company_Images_idx");

                entity.Property(e => e.IdCompany)
                    .HasColumnName("idCompany")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.About).HasColumnType("mediumtext");

                entity.Property(e => e.AdditionTime)
                    .HasColumnName("addition_time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.AddressId).HasColumnType("int(11)");

                entity.Property(e => e.Contacts)
                    .IsRequired()
                    .HasColumnType("tinytext");

                entity.Property(e => e.ImageId).HasColumnType("int(11)");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Pan)
                    .IsRequired()
                    .HasColumnName("PAN")
                    .HasMaxLength(45);

                entity.Property(e => e.ShortName).HasMaxLength(45);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Company_Addresses");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.ImageId)
                    .HasConstraintName("fk_Company_Images");
            });

            modelBuilder.Entity<Companyactivity>(entity =>
            {
                entity.HasKey(e => e.IdCompanyActivity);

                entity.ToTable("companyactivity");

                entity.HasIndex(e => e.ActivityTypeId)
                    .HasName("fk_CompanyActivity_1_idx");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("fk_CompanyActivity_2_idx");

                entity.Property(e => e.IdCompanyActivity)
                    .HasColumnName("idCompanyActivity")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ActivityTypeId).HasColumnType("int(11)");

                entity.Property(e => e.AdditionTime)
                    .HasColumnName("addition_time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.CompanyId).HasColumnType("int(11)");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.HasOne(d => d.ActivityType)
                    .WithMany(p => p.Companyactivity)
                    .HasForeignKey(d => d.ActivityTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CompanyActivity_1");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Companyactivity)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_CompanyActivity_2");
            });

            modelBuilder.Entity<Companyorders>(entity =>
            {
                entity.HasKey(e => e.IdCompanyOrders);

                entity.ToTable("companyorders");

                entity.HasIndex(e => e.IdCompanies)
                    .HasName("fk_Company_idx");

                entity.HasIndex(e => e.IdOrders)
                    .HasName("fk_Order_idx");

                entity.Property(e => e.IdCompanyOrders)
                    .HasColumnName("idCompanyOrders")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdCompanies)
                    .HasColumnName("idCompanies")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdOrders)
                    .HasColumnName("idOrders")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Companies)
                    .WithMany(p => p.Companyorders)
                    .HasForeignKey(d => d.IdCompanies)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Company");

                entity.HasOne(d => d.Orders)
                    .WithMany(p => p.Companyorders)
                    .HasForeignKey(d => d.IdOrders)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Order");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(e => e.IdCountry);

                entity.ToTable("country");

                entity.Property(e => e.IdCountry)
                    .HasColumnName("idCountry")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdditionTime)
                    .HasColumnName("addition_time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ShortName).HasMaxLength(45);
            });

            modelBuilder.Entity<Currencies>(entity =>
            {
                entity.HasKey(e => e.IdCurrencies);

                entity.ToTable("currencies");

                entity.Property(e => e.IdCurrencies)
                    .HasColumnName("idCurrencies")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdditionTime)
                    .HasColumnName("addition_time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Files>(entity =>
            {
                entity.HasKey(e => e.IdFiles);

                entity.ToTable("files");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_Files_Users_idx");

                entity.Property(e => e.IdFiles)
                    .HasColumnName("idFiles")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdditionTime)
                    .HasColumnName("addition_time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL")
                    .HasMaxLength(45);

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Files)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Files_Users");
            });

            modelBuilder.Entity<Goods>(entity =>
            {
                entity.HasKey(e => e.IdGoods);

                entity.ToTable("goods");

                entity.HasIndex(e => e.NomenclaturesId)
                    .HasName("fk_Goods_1_idx");

                entity.HasIndex(e => e.SubcategoryId)
                    .HasName("fk_Goods_Subcategory_idx");

                entity.HasIndex(e => e.UnitId)
                    .HasName("fk_Goods_Measure_idx");

                entity.Property(e => e.IdGoods)
                    .HasColumnName("idGoods")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdditionTime)
                    .HasColumnName("addition_time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Cost)
                    .HasColumnType("decimal(6,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.NomenclaturesId).HasColumnType("int(11)");

                entity.Property(e => e.Params).HasColumnType("mediumtext");

                entity.Property(e => e.SubcategoryId).HasColumnType("int(11)");

                entity.Property(e => e.UnitId).HasColumnType("int(11)");

                entity.HasOne(d => d.Nomenclatures)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.NomenclaturesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Goods_1");

                entity.HasOne(d => d.Subcategory)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.SubcategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Goods_Subcategory");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Goods)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("fk_Goods_Measure");
            });

            modelBuilder.Entity<Images>(entity =>
            {
                entity.HasKey(e => e.IdImages);

                entity.ToTable("images");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_Images_Users_idx");

                entity.Property(e => e.IdImages)
                    .HasColumnName("idImages")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdditionTime)
                    .HasColumnName("addition_time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);

                entity.Property(e => e.Path)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Images)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("fk_Images_Users");
            });

            modelBuilder.Entity<Messages>(entity =>
            {
                entity.HasKey(e => e.MsgId);

                entity.ToTable("messages");

                entity.HasIndex(e => e.RoomId)
                    .HasName("fk_Messages_Room_idx");

                entity.HasIndex(e => e.UsersId)
                    .HasName("fk_Messages_Users_idx");

                entity.Property(e => e.MsgId)
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdditionTime)
                    .HasColumnName("addition_time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsViewed)
                    .HasColumnName("is_viewed")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.RoomId).HasColumnType("int(11)");

                entity.Property(e => e.Text)
                    .IsRequired()
                    .HasColumnType("mediumtext");

                entity.Property(e => e.UsersId).HasColumnType("int(11)");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Messages_Room");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Messages_Users");
            });

            modelBuilder.Entity<Nomenclatures>(entity =>
            {
                entity.HasKey(e => e.IdNomenclatures);

                entity.ToTable("nomenclatures");

                entity.Property(e => e.IdNomenclatures)
                    .HasColumnName("idNomenclatures")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdditionTime)
                    .HasColumnName("addition_time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(450);
            });

            modelBuilder.Entity<Orderfiles>(entity =>
            {
                entity.HasKey(e => e.IdOrderFiles);

                entity.ToTable("orderfiles");

                entity.HasIndex(e => e.FileId)
                    .HasName("fk_OrderFiles_Files_idx");

                entity.HasIndex(e => e.OrderId)
                    .HasName("fk_OrderFiles_Orders_idx");

                entity.Property(e => e.IdOrderFiles)
                    .HasColumnName("idOrderFiles")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.FileId).HasColumnType("int(11)");

                entity.Property(e => e.OrderId).HasColumnType("int(11)");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.Orderfiles)
                    .HasForeignKey(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OrderFiles_Files");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderfiles)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OrderFiles_Orders");
            });

            modelBuilder.Entity<Orderimages>(entity =>
            {
                entity.HasKey(e => e.IdOrderImages);

                entity.ToTable("orderimages");

                entity.HasIndex(e => e.ImageId)
                    .HasName("fk_OrderImages_Images_idx");

                entity.HasIndex(e => e.OrderId)
                    .HasName("fk_OrderImages_Orders_idx");

                entity.Property(e => e.IdOrderImages)
                    .HasColumnName("idOrderImages")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ImageId).HasColumnType("int(11)");

                entity.Property(e => e.OrderId).HasColumnType("int(11)");

                entity.HasOne(d => d.Image)
                    .WithMany(p => p.Orderimages)
                    .HasForeignKey(d => d.ImageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OrderImages_Images");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.Orderimages)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_OrderImages_Orders");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.IdOrders);

                entity.ToTable("orders");

                entity.HasIndex(e => e.UsersId)
                    .HasName("fk_Orders_1_idx");

                entity.Property(e => e.IdOrders)
                    .HasColumnName("idOrders")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdditionTime)
                    .HasColumnName("addition_time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Caption)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Cost)
                    .HasColumnType("decimal(6,2)")
                    .HasDefaultValueSql("'0.00'");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("mediumtext");

                entity.Property(e => e.Geomap)
                    .IsRequired()
                    .HasMaxLength(45)
                    .HasDefaultValueSql("'0.0.0'");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.ThereFiles)
                    .HasColumnName("there_files")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ThereImages)
                    .HasColumnName("there_images")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.UpTo).HasColumnType("datetime");

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasColumnName("URL")
                    .HasMaxLength(100);

                entity.Property(e => e.UsersId).HasColumnType("int(11)");

                entity.Property(e => e.Viewers)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UsersId)
                    .HasConstraintName("fk_Orders_Users");
            });

            modelBuilder.Entity<Positions>(entity =>
            {
                entity.HasKey(e => e.IdPositions);

                entity.ToTable("positions");

                entity.Property(e => e.IdPositions)
                    .HasColumnName("idPositions")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdditionTime)
                    .HasColumnName("addition_time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(145);

                entity.Property(e => e.ShortName).HasMaxLength(45);
            });

            modelBuilder.Entity<Pricelist>(entity =>
            {
                entity.HasKey(e => e.IdPricelist);

                entity.ToTable("pricelist");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("fk_Pricelist_Company_idx");

                entity.HasIndex(e => e.CurrencyId)
                    .HasName("fk_Pricelist_Currency_idx");

                entity.HasIndex(e => e.GoodsId)
                    .HasName("fk_Pricelist_Goods_idx");

                entity.Property(e => e.IdPricelist)
                    .HasColumnName("idPricelist")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdditionTime)
                    .HasColumnName("addition_time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.CompanyId).HasColumnType("int(11)");

                entity.Property(e => e.Count).HasDefaultValueSql("'0'");

                entity.Property(e => e.CurrencyId).HasColumnType("int(11)");

                entity.Property(e => e.GoodsId).HasColumnType("int(11)");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Pricelist)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Pricelist_Company");

                entity.HasOne(d => d.Currency)
                    .WithMany(p => p.Pricelist)
                    .HasForeignKey(d => d.CurrencyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Pricelist_Currency");

                entity.HasOne(d => d.Goods)
                    .WithMany(p => p.Pricelist)
                    .HasForeignKey(d => d.GoodsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Pricelist_Goods");
            });

            modelBuilder.Entity<Rooms>(entity =>
            {
                entity.HasKey(e => e.IdRooms);

                entity.ToTable("rooms");

                entity.HasIndex(e => e.CreatorId)
                    .HasName("fk_Rooms_1_idx");

                entity.Property(e => e.IdRooms)
                    .HasColumnName("idRooms")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdditionTime)
                    .HasColumnName("addition_time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.CreatorId).HasColumnType("int(11)");

                entity.Property(e => e.IsCompanyRoom)
                    .HasColumnName("is_CompanyRoom")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Creator)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.CreatorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Rooms_Users");
            });

            modelBuilder.Entity<Roomusers>(entity =>
            {
                entity.HasKey(e => e.IdRoomUsers);

                entity.ToTable("roomusers");

                entity.HasIndex(e => e.RoomId)
                    .HasName("fk_RoomUsers_Rooms_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_RoomUsers_Users_idx");

                entity.Property(e => e.IdRoomUsers)
                    .HasColumnName("idRoomUsers")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdditionTime)
                    .HasColumnName("addition_time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("tinyint(4)");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.RoomId).HasColumnType("int(11)");

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.Room)
                    .WithMany(p => p.Roomusers)
                    .HasForeignKey(d => d.RoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_RoomUsers_Rooms");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Roomusers)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_RoomUsers_Users");
            });

            modelBuilder.Entity<Rules>(entity =>
            {
                entity.HasKey(e => e.IdRules);

                entity.ToTable("rules");

                entity.Property(e => e.IdRules)
                    .HasColumnName("idRules")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdditionTime)
                    .HasColumnName("addition_time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Sessions>(entity =>
            {
                entity.HasKey(e => e.IdSessions);

                entity.ToTable("sessions");

                entity.HasIndex(e => e.UserId)
                    .HasName("fk_Sessions_Users_idx");

                entity.Property(e => e.IdSessions)
                    .HasColumnName("idSessions")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.BeginTime)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Ip)
                    .HasColumnName("IP")
                    .HasMaxLength(45);

                entity.Property(e => e.UserId).HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Sessions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Sessions_Users");
            });

            modelBuilder.Entity<Signinup>(entity =>
            {
                entity.HasKey(e => e.IdSignInUp);

                entity.ToTable("signinup");

                entity.HasIndex(e => e.Token)
                    .HasName("Token_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdSignInUp)
                    .HasColumnName("idSignInUp")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ActivatedIn)
                    .HasColumnName("activated_in")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMail")
                    .HasMaxLength(200);

                entity.Property(e => e.ExpiredIn)
                    .HasColumnName("expired_in")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.IsActivated)
                    .HasColumnName("is_activated")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<Subcategory>(entity =>
            {
                entity.HasKey(e => e.IdSubcategory);

                entity.ToTable("subcategory");

                entity.HasIndex(e => e.CategoryId)
                    .HasName("fk_Subcategory_Catrgory_idx");

                entity.HasIndex(e => e.OfChild)
                    .HasName("fk_Subcategory_1_idx");

                entity.Property(e => e.IdSubcategory)
                    .HasColumnName("idSubcategory")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdditionTime)
                    .HasColumnName("addition_time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.CategoryId).HasColumnType("int(11)");

                entity.Property(e => e.Info).HasColumnType("text");

                entity.Property(e => e.IsCategory)
                    .HasColumnName("is_Category")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.OfChild)
                    .HasColumnName("of_Child")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Subcategory)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Subcategory_Catrgory");

                entity.HasOne(d => d.OfChildNavigation)
                    .WithMany(p => p.InverseOfChildNavigation)
                    .HasForeignKey(d => d.OfChild)
                    .HasConstraintName("fk_Subcategory_Child");
            });

            modelBuilder.Entity<Supercategories>(entity =>
            {
                entity.HasKey(e => e.IdSuperCategories);

                entity.ToTable("supercategories");

                entity.Property(e => e.IdSuperCategories)
                    .HasColumnName("idSuperCategories")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdditionTime)
                    .HasColumnName("addition_time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Units>(entity =>
            {
                entity.HasKey(e => e.IdUnit);

                entity.ToTable("units");

                entity.Property(e => e.IdUnit)
                    .HasColumnName("idUnit")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdditionTime)
                    .HasColumnName("addition_time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(145);

                entity.Property(e => e.ShortName)
                    .IsRequired()
                    .HasMaxLength(45);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.IdUsers);

                entity.ToTable("users");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("fk_Users_Companyes_idx");

                entity.HasIndex(e => e.PositionId)
                    .HasName("fk_Users_Positions_idx");

                entity.HasIndex(e => e.RulesId)
                    .HasName("fk_Users_Rules_idx");

                entity.Property(e => e.IdUsers)
                    .HasColumnName("idUsers")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.AdditionTime)
                    .HasColumnName("addition_time")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.CompanyId).HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("EMail")
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.IsBlocked)
                    .HasColumnName("is_blocked")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.IsDeleted)
                    .HasColumnName("is_deleted")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("last_update")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.PassHash).HasMaxLength(128);

                entity.Property(e => e.PassSalt).HasMaxLength(128);

                entity.Property(e => e.PositionId).HasColumnType("int(11)");

                entity.Property(e => e.RulesId).HasColumnType("int(11)");

                entity.Property(e => e.SecondName).HasMaxLength(200);

                entity.Property(e => e.Telephone).HasMaxLength(20);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("fk_Users_Company");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Users_Positions");

                entity.HasOne(d => d.Rules)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RulesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_Users_Rules");
            });
        }
    }
}
