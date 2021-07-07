using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using sample.Entities;

namespace sample.Data
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AcademicPosition> AcademicPosition { get; set; }
        public virtual DbSet<ApproveStep> ApproveStep { get; set; }
        public virtual DbSet<AttachFiles> AttachFiles { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Districts> Districts { get; set; }
        public virtual DbSet<Leavedoc> Leavedoc { get; set; }
        public virtual DbSet<ManagementPosotion> ManagementPosotion { get; set; }
        public virtual DbSet<Masterstatus> Masterstatus { get; set; }
        public virtual DbSet<Provinces> Provinces { get; set; }
        public virtual DbSet<Quota> Quota { get; set; }
        public virtual DbSet<Subdistricts> Subdistricts { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserDetail> UserDetail { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=127.0.0.1;port=3306;user=root;database=leave_system", x => x.ServerVersion("10.4.19-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AcademicPosition>(entity =>
            {
                entity.ToTable("academic_position");

                entity.Property(e => e.AcademicPositionId)
                    .HasColumnName("Academic_Position_ID")
                    .HasColumnType("int(11)")
                    .HasComment("รหัสตำแหน่งทางวิชาการ");

                entity.Property(e => e.AcademicPositionName)
                    .IsRequired()
                    .HasColumnName("Academic_Position_Name")
                    .HasColumnType("varchar(120)")
                    .HasComment("ชื่อตำแหน่งทางวิชาการ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ActiveStatus)
                    .IsRequired()
                    .HasColumnType("char(1)")
                    .HasComment(@"สถานะการใช้งาน 
0 = Active 
1 = Inactive")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<ApproveStep>(entity =>
            {
                entity.ToTable("approve_step");

                entity.HasIndex(e => e.LeaveId)
                    .HasName("LeaveID");

                entity.HasIndex(e => e.MasterStatusId)
                    .HasName("MasterStatus_ID");

                entity.Property(e => e.ApproveStepId)
                    .HasColumnName("Approve_Step_ID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LeaveId)
                    .HasColumnName("LeaveID")
                    .HasColumnType("int(11)")
                    .HasComment("รหัสเอกสารการลา");

                entity.Property(e => e.MasterStatusId)
                    .HasColumnName("MasterStatus_ID")
                    .HasColumnType("int(11)")
                    .HasComment("สถานะการอนุมัติ");

                entity.Property(e => e.SubmitDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .HasComment("วันที่อนุมัติ");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(11)")
                    .HasComment("รหัสผู้ใช้งาน");

                entity.HasOne(d => d.Leave)
                    .WithMany(p => p.ApproveStep)
                    .HasForeignKey(d => d.LeaveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("approve_step_ibfk_3");

                entity.HasOne(d => d.MasterStatus)
                    .WithMany(p => p.ApproveStep)
                    .HasForeignKey(d => d.MasterStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("approve_step_ibfk_1");
            });

            modelBuilder.Entity<AttachFiles>(entity =>
            {
                entity.HasKey(e => e.AttachId)
                    .HasName("PRIMARY");

                entity.ToTable("attach_files");

                entity.HasIndex(e => e.LeaveId)
                    .HasName("LeaveID");

                entity.Property(e => e.AttachId)
                    .HasColumnName("AttachID")
                    .HasColumnType("int(11)")
                    .HasComment("รหัสไฟล์แนบ");

                entity.Property(e => e.ActiveStatus)
                    .IsRequired()
                    .HasColumnType("char(1)")
                    .HasComment(@"สถานะการใช้งาน
0 = Active
1 = Inactive")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.AttachFiles1)
                    .IsRequired()
                    .HasColumnName("AttachFiles")
                    .HasColumnType("varchar(255)")
                    .HasComment("ไฟล์แนบ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LeaveId)
                    .HasColumnName("LeaveID")
                    .HasColumnType("int(11)")
                    .HasComment("รหัสเอกสารการลา");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Leave)
                    .WithMany(p => p.AttachFiles)
                    .HasForeignKey(d => d.LeaveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("attach_files_ibfk_1");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.DepId)
                    .HasName("PRIMARY");

                entity.ToTable("department");

                entity.HasIndex(e => e.DeanUserId)
                    .HasName("Dean_UserID");

                entity.HasIndex(e => e.HeadOfDepUserId)
                    .HasName("HeadOfDep_UserID");

                entity.Property(e => e.DepId)
                    .HasColumnName("DepID")
                    .HasColumnType("int(11)")
                    .HasComment("รหัสสาขา/แผนก");

                entity.Property(e => e.DeanUserId)
                    .HasColumnName("Dean_UserID")
                    .HasColumnType("int(11)")
                    .HasComment("ชื่อคณบดี");

                entity.Property(e => e.DepName)
                    .IsRequired()
                    .HasColumnType("varchar(30)")
                    .HasComment("ชื่อสาขา/แผนก")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.HeadOfDepUserId)
                    .HasColumnName("HeadOfDep_UserID")
                    .HasColumnType("int(11)")
                    .HasComment("ชื่อหัวหน้าภาค/หัวหน้าแผนก");

                entity.HasOne(d => d.DeanUser)
                    .WithMany(p => p.DepartmentDeanUser)
                    .HasForeignKey(d => d.DeanUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("department_ibfk_2");

                entity.HasOne(d => d.HeadOfDepUser)
                    .WithMany(p => p.DepartmentHeadOfDepUser)
                    .HasForeignKey(d => d.HeadOfDepUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("department_ibfk_1");
            });

            modelBuilder.Entity<Districts>(entity =>
            {
                entity.ToTable("districts");

                entity.HasIndex(e => e.Code)
                    .HasName("ux_districts_code")
                    .IsUnique();

                entity.HasIndex(e => e.ProvinceId)
                    .HasName("ix_districts_province_id");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NameInEnglish)
                    .IsRequired()
                    .HasColumnName("name_in_english")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NameInThai)
                    .IsRequired()
                    .HasColumnName("name_in_thai")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProvinceId)
                    .HasColumnName("province_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Province)
                    .WithMany(p => p.Districts)
                    .HasForeignKey(d => d.ProvinceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_districts_provinces");
            });

            modelBuilder.Entity<Leavedoc>(entity =>
            {
                entity.HasKey(e => e.LeaveId)
                    .HasName("PRIMARY");

                entity.ToTable("leavedoc");

                entity.HasIndex(e => e.DistrictsId)
                    .HasName("disstrict_id");

                entity.HasIndex(e => e.ProvincesId)
                    .HasName("province_id");

                entity.HasIndex(e => e.StatusId)
                    .HasName("StatusID");

                entity.HasIndex(e => e.SubDistrictsId)
                    .HasName("sub-district_id");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserID");

                entity.Property(e => e.LeaveId)
                    .HasColumnName("LeaveID")
                    .HasColumnType("int(11)")
                    .HasComment("รหัสการลา");

                entity.Property(e => e.DistrictsId)
                    .HasColumnName("districts_id")
                    .HasColumnType("int(11)")
                    .HasComment("รหัสอำเภอ");

                entity.Property(e => e.DocId)
                    .HasColumnName("DocID")
                    .HasColumnType("varchar(10)")
                    .HasComment("เลขหนังสือราชการ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastDate)
                    .HasColumnType("date")
                    .HasComment("วันที่สิ้นสุดการลา");

                entity.Property(e => e.LeaveReason)
                    .IsRequired()
                    .HasColumnType("varchar(150)")
                    .HasComment("เหตุผลการลา")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.PlaceName)
                    .HasColumnName("place_name")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'0'")
                    .HasComment("ชื่อสถานที่")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ProvincesId)
                    .HasColumnName("provinces_id")
                    .HasColumnType("int(11)")
                    .HasComment("รหัสจังหวัด");

                entity.Property(e => e.StartDate)
                    .HasColumnType("date")
                    .HasComment("วันที่เริ่มการลา");

                entity.Property(e => e.StatusId)
                    .HasColumnName("StatusID")
                    .HasColumnType("int(11)")
                    .HasComment("รหัสสถานะการดำเนินการ");

                entity.Property(e => e.SubDistrictsId)
                    .HasColumnName("sub-districts_id")
                    .HasColumnType("int(11)")
                    .HasComment("รหัสตำบล");

                entity.Property(e => e.SubmitDate)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .HasComment("วันที่ทำการลา");

                entity.Property(e => e.TotalLeaveDate)
                    .HasColumnType("int(11)")
                    .HasComment("จำนวนวันที่ลา");

                entity.Property(e => e.TotalParticipants)
                    .HasColumnType("int(11)")
                    .HasComment("จำนวนผู้ร่วมเดินทาง");

                entity.Property(e => e.UpdateFile)
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .HasComment("วันที่อัพเดทเอกสารการลา");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(11)")
                    .HasComment("รหัสประจำตัวผู้ใช้งาน");

                entity.HasOne(d => d.Districts)
                    .WithMany(p => p.Leavedoc)
                    .HasForeignKey(d => d.DistrictsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("leavedoc_ibfk_5");

                entity.HasOne(d => d.Provinces)
                    .WithMany(p => p.Leavedoc)
                    .HasForeignKey(d => d.ProvincesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("leavedoc_ibfk_6");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Leavedoc)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("leavedoc_ibfk_2");

                entity.HasOne(d => d.SubDistricts)
                    .WithMany(p => p.Leavedoc)
                    .HasForeignKey(d => d.SubDistrictsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("leavedoc_ibfk_4");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Leavedoc)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("leavedoc_ibfk_3");
            });

            modelBuilder.Entity<ManagementPosotion>(entity =>
            {
                entity.HasKey(e => e.ManagementPositionId)
                    .HasName("PRIMARY");

                entity.ToTable("management_posotion");

                entity.Property(e => e.ManagementPositionId)
                    .HasColumnName("Management_Position_ID")
                    .HasColumnType("int(11)")
                    .HasComment("รหัสตำแหน่งบริหาร");

                entity.Property(e => e.ActiveStatus)
                    .IsRequired()
                    .HasColumnType("char(1)")
                    .HasComment(@"สถานะการใช้งาน
0 = Active
1 = Inactive")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ManagementName)
                    .IsRequired()
                    .HasColumnName("Management_Name")
                    .HasColumnType("varchar(120)")
                    .HasComment("ชื่อตำแหน่งบริหาร")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Masterstatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PRIMARY");

                entity.ToTable("masterstatus");

                entity.Property(e => e.StatusId)
                    .HasColumnName("StatusID")
                    .HasColumnType("int(11)")
                    .HasComment("รหัสสถานะการดำเนินการ");

                entity.Property(e => e.ActiveStatus)
                    .IsRequired()
                    .HasColumnType("varchar(1)")
                    .HasComment(@"สถานะการใช้งาน
0 = Active
1 = Inactive")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasColumnType("char(1)")
                    .HasComment(@"ชื่อสถานะ
 0 = กำลังดำเนินการ 1 = อนุมัติ 2 = ไม่อนุมัติ")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Provinces>(entity =>
            {
                entity.ToTable("provinces");

                entity.HasIndex(e => e.Code)
                    .HasName("ux_provinces_code")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("int(11)");

                entity.Property(e => e.NameInEnglish)
                    .IsRequired()
                    .HasColumnName("name_in_english")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NameInThai)
                    .IsRequired()
                    .HasColumnName("name_in_thai")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");
            });

            modelBuilder.Entity<Quota>(entity =>
            {
                entity.ToTable("quota");

                entity.HasIndex(e => e.UserId)
                    .HasName("UserID");

                entity.Property(e => e.QuotaId)
                    .HasColumnName("QuotaID")
                    .HasColumnType("int(11)")
                    .HasComment("รหัสสิทธิ์");

                entity.Property(e => e.QuataAmount)
                    .HasColumnType("int(2)")
                    .HasComment("จำนวนการลา");

                entity.Property(e => e.QuataStatus)
                    .IsRequired()
                    .HasColumnType("char(1)")
                    .HasComment(@"สถานะการใช้งาน
0 = Active
1 = Inactive")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(11)")
                    .HasComment("รหัสประจำตัวผู้ใช้งาน");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Quota)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("quota_ibfk_1");
            });

            modelBuilder.Entity<Subdistricts>(entity =>
            {
                entity.ToTable("subdistricts");

                entity.HasIndex(e => e.Code)
                    .HasName("ux_subdistricts_code")
                    .IsUnique();

                entity.HasIndex(e => e.DistrictId)
                    .HasName("ix_subdistricts_district_id");

                entity.HasIndex(e => e.ZipCode)
                    .HasName("ix_subdistricts_zip_code");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .HasColumnName("code")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DistrictId)
                    .HasColumnName("district_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Latitude)
                    .HasColumnName("latitude")
                    .HasColumnType("decimal(6,3)");

                entity.Property(e => e.Longitude)
                    .HasColumnName("longitude")
                    .HasColumnType("decimal(6,3)");

                entity.Property(e => e.NameInEnglish)
                    .HasColumnName("name_in_english")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.NameInThai)
                    .IsRequired()
                    .HasColumnName("name_in_thai")
                    .HasColumnType("varchar(150)")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ZipCode)
                    .HasColumnName("zip_code")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Subdistricts)
                    .HasForeignKey(d => d.DistrictId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_subdistricts_districts");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => e.AcademicPositionId)
                    .HasName("Academic_Position_ID");

                entity.HasIndex(e => e.DepId)
                    .HasName("DepID");

                entity.HasIndex(e => e.ManagementPositionId)
                    .HasName("Management_Position_ID");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .HasColumnType("int(11)")
                    .HasComment("รหัสประจำตัวผู้ใช้งาน");

                entity.Property(e => e.AcademicPositionId)
                    .HasColumnName("Academic_Position_ID")
                    .HasColumnType("int(11)")
                    .HasComment("รหัสตำแหน่งทางวิชาการ");

                entity.Property(e => e.DepId)
                    .HasColumnName("DepID")
                    .HasColumnType("int(11)")
                    .HasComment("รหัสสาขา/แผนก");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnType("varchar(120)")
                    .HasComment("อีเมลผู้ใช้งาน")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("ชื่อผู้ใช้งาน")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("varchar(50)")
                    .HasComment("นามสกุลผู้ใช้งาน")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.Property(e => e.ManagementPositionId)
                    .HasColumnName("Management_Position_ID")
                    .HasColumnType("int(11)")
                    .HasComment("รหัสตำแหน่งทางบริหาร");

                entity.Property(e => e.Signature)
                    .IsRequired()
                    .HasMaxLength(120)
                    .IsFixedLength()
                    .HasComment("ลายเซ็น");

                entity.Property(e => e.UserStatus)
                    .IsRequired()
                    .HasColumnType("char(1)")
                    .HasComment(@"สถานะผู้ใช้งาน
0 = Staff
1 = Other User
")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.AcademicPosition)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.AcademicPositionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_ibfk_2");

                entity.HasOne(d => d.Dep)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.DepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_ibfk_1");

                entity.HasOne(d => d.ManagementPosition)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.ManagementPositionId)
                    .HasConstraintName("user_ibfk_3");
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.ToTable("user_detail");

                entity.HasIndex(e => e.LeaveId)
                    .HasName("LeaveID");

                entity.Property(e => e.UserDetailId)
                    .HasColumnName("UserDetailID")
                    .HasColumnType("int(11)");

                entity.Property(e => e.LeaveId)
                    .HasColumnName("LeaveID")
                    .HasColumnType("int(11)")
                    .HasComment("รหัสเอกสารการลา");

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasColumnName("UserID")
                    .HasColumnType("varchar(255)")
                    .HasComment("ไอดีผู้เข้าร่วม")
                    .HasCharSet("utf8")
                    .HasCollation("utf8_general_ci");

                entity.HasOne(d => d.Leave)
                    .WithMany(p => p.UserDetail)
                    .HasForeignKey(d => d.LeaveId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_detail_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
