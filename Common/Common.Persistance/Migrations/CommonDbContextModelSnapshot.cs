﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserManagement.Persistance;

namespace Common.Persistance.Migrations
{
    [DbContext(typeof(CommonDbContext))]
    partial class CommonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Common.Domain.Module.Attachment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AttachmentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("ContentType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescriptionAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DescriptionEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Extention")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FileName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ItemOrder")
                        .HasColumnType("int");

                    b.Property<string>("TitleAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TitleEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AttachmentTypeId");

                    b.ToTable("Attachments","common");
                });

            modelBuilder.Entity("Common.Domain.Module.AttachmentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AllowedFilesExtension")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ImageMaxHeight")
                        .HasColumnType("int");

                    b.Property<int?>("ImageMaxWidth")
                        .HasColumnType("int");

                    b.Property<bool>("IsImage")
                        .HasColumnType("bit");

                    b.Property<bool>("IsMandatory")
                        .HasColumnType("bit");

                    b.Property<int>("MaxSizeInMegabytes")
                        .HasColumnType("int");

                    b.Property<string>("NameAr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameEn")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("AttachmentTypes","common");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AllowedFilesExtension = "pdf,jpg,png",
                            Code = "AvatarImage",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            IsImage = true,
                            IsMandatory = false,
                            MaxSizeInMegabytes = 2,
                            NameEn = "Personal image"
                        });
                });

            modelBuilder.Entity("Common.Domain.Module.SystemSetting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Desc_Ar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Desc_En")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GroupName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsManaged")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSticky")
                        .HasColumnType("bit");

                    b.Property<string>("Key")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Secure")
                        .HasColumnType("bit");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ValueType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SystemSettings","common");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ApplicationId = "AuthenticationGeneral",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Desc_En = "Should 'Remember Me' checkbox be displayed on login form?",
                            IsActive = true,
                            IsManaged = false,
                            IsSticky = false,
                            Key = "AllowRememberMe",
                            Secure = false,
                            Value = "True"
                        },
                        new
                        {
                            Id = 2,
                            ApplicationId = "AuthenticationGeneral",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Desc_En = "Enable/Disable forgot password feature",
                            IsActive = true,
                            IsManaged = false,
                            IsSticky = false,
                            Key = "AllowForgotPassword",
                            Secure = false,
                            Value = "True"
                        },
                        new
                        {
                            Id = 3,
                            ApplicationId = "AuthenticationGeneral",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Desc_En = "Should user confirm his account ?",
                            IsActive = true,
                            IsManaged = false,
                            IsSticky = false,
                            Key = "RequireConfirmedAccount",
                            Secure = false,
                            Value = "False"
                        },
                        new
                        {
                            Id = 4,
                            ApplicationId = "AuthenticationThrottling",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Desc_En = "Should the system throttle authentication attempts?",
                            IsActive = true,
                            IsManaged = false,
                            IsSticky = false,
                            Key = "AllowThrottleAuthentication",
                            Secure = false,
                            Value = "True"
                        },
                        new
                        {
                            Id = 5,
                            ApplicationId = "AuthenticationThrottling",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Desc_En = "Number of minutes to lock the user out for after specified maximum numbers.",
                            IsActive = true,
                            IsManaged = false,
                            IsSticky = false,
                            Key = "LockoutTime",
                            Secure = false,
                            Value = "5"
                        },
                        new
                        {
                            Id = 6,
                            ApplicationId = "AuthenticationThrottling",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Desc_En = "Maximum number of incorrect login attempts before lockout.",
                            IsActive = true,
                            IsManaged = false,
                            IsSticky = false,
                            Key = "MaximumNumberOfAttempts",
                            Secure = false,
                            Value = "3"
                        },
                        new
                        {
                            Id = 7,
                            ApplicationId = "General",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Desc_En = "Default culture.",
                            IsActive = true,
                            IsManaged = false,
                            IsSticky = false,
                            Key = "DefaultCulture",
                            Secure = false,
                            Value = "en-US"
                        },
                        new
                        {
                            Id = 8,
                            ApplicationId = "Smtp",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Desc_En = "Smtp Server.",
                            IsActive = true,
                            IsManaged = false,
                            IsSticky = false,
                            Key = "SmtpServer",
                            Secure = false,
                            Value = ""
                        },
                        new
                        {
                            Id = 9,
                            ApplicationId = "Smtp",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Desc_En = "Smtp UserName.",
                            IsActive = true,
                            IsManaged = false,
                            IsSticky = false,
                            Key = "SmtpUserName",
                            Secure = false,
                            Value = ""
                        },
                        new
                        {
                            Id = 10,
                            ApplicationId = "Smtp",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Desc_En = "Smtp Password.",
                            IsActive = true,
                            IsManaged = false,
                            IsSticky = false,
                            Key = "SmtpPassword",
                            Secure = false,
                            Value = ""
                        },
                        new
                        {
                            Id = 11,
                            ApplicationId = "Smtp",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Desc_En = "Is Smtp Authenticated.",
                            IsActive = true,
                            IsManaged = false,
                            IsSticky = false,
                            Key = "IsSmtpAuthenticated",
                            Secure = false,
                            Value = "False"
                        },
                        new
                        {
                            Id = 12,
                            ApplicationId = "Smtp",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Desc_En = "Smtp Port.",
                            IsActive = true,
                            IsManaged = false,
                            IsSticky = false,
                            Key = "SmtpPort",
                            Secure = false,
                            Value = "0"
                        },
                        new
                        {
                            Id = 13,
                            ApplicationId = "Smtp",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Desc_En = "Smtp Enable SSL.",
                            IsActive = true,
                            IsManaged = false,
                            IsSticky = false,
                            Key = "SmtpEnableSSL",
                            Secure = false,
                            Value = "False"
                        },
                        new
                        {
                            Id = 14,
                            ApplicationId = "Attachment",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Desc_En = "Attachment folder path.",
                            IsActive = true,
                            IsManaged = false,
                            IsSticky = false,
                            Key = "AttachmentPath",
                            Secure = false,
                            Value = "C:\\UserManagementImages"
                        },
                        new
                        {
                            Id = 15,
                            ApplicationId = "Attachment",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Desc_En = "should system save files in database.",
                            IsActive = true,
                            IsManaged = false,
                            IsSticky = false,
                            Key = "SaveFilesToDatabase",
                            Secure = false,
                            Value = "False"
                        });
                });

            modelBuilder.Entity("Common.Domain.Module.Attachment", b =>
                {
                    b.HasOne("Common.Domain.Module.AttachmentType", "AttachmentType")
                        .WithMany()
                        .HasForeignKey("AttachmentTypeId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
