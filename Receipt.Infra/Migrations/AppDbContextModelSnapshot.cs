﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Receipt.Infra.Data;

#nullable disable

namespace Receipt.Infra.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.3");

            modelBuilder.Entity("Receipt.Domain.Entity.CustomerDetail", b =>
                {
                    b.Property<int>("CustomerDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AadharNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Address")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContDetails")
                        .HasColumnType("TEXT");

                    b.Property<string>("ContactNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CreateuserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("CustomerName")
                        .HasColumnType("TEXT");

                    b.Property<string>("EmaiId")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsMain")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Ocupation")
                        .HasColumnType("TEXT");

                    b.Property<string>("PanNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("Religin")
                        .HasColumnType("TEXT");

                    b.Property<int>("SiteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UpdateuserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CustomerDetailsId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("SiteId");

                    b.ToTable("customerDetails");
                });

            modelBuilder.Entity("Receipt.Domain.Entity.CustomerMaster", b =>
                {
                    b.Property<int>("CustomerMasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("BanakhatDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("BanakhatNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CreateuserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DastavgDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("DastavgNo")
                        .HasColumnType("TEXT");

                    b.Property<string>("FinacialName")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsBanakhat")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SiteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UpdateuserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WingDetailId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WingMasterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CustomerMasterId");

                    b.HasIndex("SiteId");

                    b.HasIndex("WingDetailId");

                    b.HasIndex("WingMasterId");

                    b.ToTable("customerMasters");
                });

            modelBuilder.Entity("Receipt.Domain.Entity.ReceiptDetail", b =>
                {
                    b.Property<int>("ReceiptId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Amount")
                        .HasColumnType("REAL");

                    b.Property<string>("AmountInWord")
                        .HasColumnType("TEXT");

                    b.Property<string>("BankName")
                        .HasColumnType("TEXT");

                    b.Property<string>("BranchName")
                        .HasColumnType("TEXT");

                    b.Property<string>("CheqNeftRtgsNo")
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CreateuserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsCancel")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsPrint")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PaymentDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReceiptDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReceiptNo")
                        .HasColumnType("TEXT");

                    b.Property<string>("ReceivedAs")
                        .HasColumnType("TEXT");

                    b.Property<int>("SiteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UpdateuserId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WingDetailId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("WingMasterId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ReceiptId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("UserId");

                    b.HasIndex("WingDetailId");

                    b.HasIndex("WingMasterId");

                    b.ToTable("receiptDetails");
                });

            modelBuilder.Entity("Receipt.Domain.Entity.SiteMaster", b =>
                {
                    b.Property<int>("SiteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CreateuserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Display_Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RegistrationDetails")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SiteName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UpdateuserId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SiteId");

                    b.HasIndex("UserId");

                    b.ToTable("siteMasters");
                });

            modelBuilder.Entity("Receipt.Domain.Entity.UserMaster", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CreateuserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("First_Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Last_Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UpdateuserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("userMasters");
                });

            modelBuilder.Entity("Receipt.Domain.Entity.WingDetail", b =>
                {
                    b.Property<int>("WingDetailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Amount")
                        .HasColumnType("REAL");

                    b.Property<double?>("Carpate")
                        .HasColumnType("REAL");

                    b.Property<string>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CreateuserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("East")
                        .HasColumnType("TEXT");

                    b.Property<string>("FlatNo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("FlowrName")
                        .HasColumnType("TEXT");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Land")
                        .HasColumnType("REAL");

                    b.Property<string>("North")
                        .HasColumnType("TEXT");

                    b.Property<double?>("OpenTarrace")
                        .HasColumnType("REAL");

                    b.Property<int>("SiteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("South")
                        .HasColumnType("TEXT");

                    b.Property<double?>("Total")
                        .HasColumnType("REAL");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UpdateuserId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.Property<double?>("Wb")
                        .HasColumnType("REAL");

                    b.Property<string>("West")
                        .HasColumnType("TEXT");

                    b.Property<int?>("WingMasterId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("WingName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("WingDetailId");

                    b.HasIndex("SiteId");

                    b.HasIndex("UserId");

                    b.HasIndex("WingMasterId");

                    b.ToTable("wingDetails");
                });

            modelBuilder.Entity("Receipt.Domain.Entity.WingMaster", b =>
                {
                    b.Property<int>("WingMasterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CreatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CreateuserId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("DisplayName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("EndNumber")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("FloarCount")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("HouseCount")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SiteId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("StartNumber")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UpdatedAt")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UpdateuserId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("WingMasterId");

                    b.HasIndex("SiteId");

                    b.HasIndex("UserId");

                    b.ToTable("DbwingMasters");
                });

            modelBuilder.Entity("Receipt.Domain.Entity.CustomerDetail", b =>
                {
                    b.HasOne("Receipt.Domain.Entity.CustomerMaster", "Customer")
                        .WithMany("CustomerDetails")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Receipt.Domain.Entity.SiteMaster", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Site");
                });

            modelBuilder.Entity("Receipt.Domain.Entity.CustomerMaster", b =>
                {
                    b.HasOne("Receipt.Domain.Entity.SiteMaster", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Receipt.Domain.Entity.WingDetail", "WingDetail")
                        .WithMany("CustomerMasters")
                        .HasForeignKey("WingDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Receipt.Domain.Entity.WingMaster", "WingMaster")
                        .WithMany("CustomerMasters")
                        .HasForeignKey("WingMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Site");

                    b.Navigation("WingDetail");

                    b.Navigation("WingMaster");
                });

            modelBuilder.Entity("Receipt.Domain.Entity.ReceiptDetail", b =>
                {
                    b.HasOne("Receipt.Domain.Entity.CustomerMaster", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Receipt.Domain.Entity.UserMaster", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("Receipt.Domain.Entity.WingDetail", "WingDetail")
                        .WithMany()
                        .HasForeignKey("WingDetailId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Receipt.Domain.Entity.WingMaster", "WingMaster")
                        .WithMany()
                        .HasForeignKey("WingMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("User");

                    b.Navigation("WingDetail");

                    b.Navigation("WingMaster");
                });

            modelBuilder.Entity("Receipt.Domain.Entity.SiteMaster", b =>
                {
                    b.HasOne("Receipt.Domain.Entity.UserMaster", "User")
                        .WithMany("siteMasters")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Receipt.Domain.Entity.WingDetail", b =>
                {
                    b.HasOne("Receipt.Domain.Entity.SiteMaster", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Receipt.Domain.Entity.UserMaster", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.HasOne("Receipt.Domain.Entity.WingMaster", "WingMaster")
                        .WithMany("WingDetails")
                        .HasForeignKey("WingMasterId");

                    b.Navigation("Site");

                    b.Navigation("User");

                    b.Navigation("WingMaster");
                });

            modelBuilder.Entity("Receipt.Domain.Entity.WingMaster", b =>
                {
                    b.HasOne("Receipt.Domain.Entity.SiteMaster", "Site")
                        .WithMany()
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Receipt.Domain.Entity.UserMaster", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Site");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Receipt.Domain.Entity.CustomerMaster", b =>
                {
                    b.Navigation("CustomerDetails");
                });

            modelBuilder.Entity("Receipt.Domain.Entity.UserMaster", b =>
                {
                    b.Navigation("siteMasters");
                });

            modelBuilder.Entity("Receipt.Domain.Entity.WingDetail", b =>
                {
                    b.Navigation("CustomerMasters");
                });

            modelBuilder.Entity("Receipt.Domain.Entity.WingMaster", b =>
                {
                    b.Navigation("CustomerMasters");

                    b.Navigation("WingDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
