using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace MyChannel.Core.Data
{
    public partial class ModelContext : DbContext
    {
        public ModelContext()
        {
        }

        public ModelContext(DbContextOptions<ModelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<About> Abouts { get; set; } = null!;
        public virtual DbSet<Channel> Channels { get; set; } = null!;
        public virtual DbSet<Channelsub> Channelsubs { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<Contact> Contacts { get; set; } = null!;
        public virtual DbSet<Feedback> Feedbacks { get; set; } = null!;
        public virtual DbSet<Footer> Footers { get; set; } = null!;
        public virtual DbSet<Home> Homes { get; set; } = null!;
        public virtual DbSet<Login> Logins { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<Report> Reports { get; set; } = null!;
        public virtual DbSet<Respon> Respons { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Teammember> Teammembers { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Video> Videos { get; set; } = null!;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseOracle("Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)(PORT=1521))(CONNECT_DATA=(SID=xe)));User Id=C##LKSA;Password=Test321;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("C##LKSA")
                .UseCollation("USING_NLS_COMP");

            modelBuilder.Entity<About>(entity =>
            {
                entity.ToTable("ABOUT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Contents)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("CONTENTS");

                entity.Property(e => e.Homeid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("HOMEID");

                entity.Property(e => e.Imagename)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.Abouts)
                    .HasForeignKey(d => d.Homeid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKABOUT");
            });

            modelBuilder.Entity<Channel>(entity =>
            {
                entity.ToTable("CHANNEL");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Backimage)
                    .HasMaxLength(1500)
                    .IsUnicode(false)
                    .HasColumnName("BACKIMAGE");

                entity.Property(e => e.Channelname)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CHANNELNAME");

                entity.Property(e => e.Description)
                    .HasMaxLength(800)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Imagename)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("IMAGENAME");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Channels)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKCHANNEL");
            });

            modelBuilder.Entity<Channelsub>(entity =>
            {
                entity.ToTable("CHANNELSUB");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Channelid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CHANNELID");

                entity.Property(e => e.Channelname)
                    .HasMaxLength(800)
                    .IsUnicode(false)
                    .HasColumnName("CHANNELNAME");

                entity.Property(e => e.Description)
                    .HasMaxLength(800)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Imagename)
                    .HasMaxLength(800)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME");

                entity.Property(e => e.Subuserid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("SUBUSERID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Channelsubs)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKUSERCH");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("COMMENTS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Commentdate)
                    .HasColumnType("DATE")
                    .HasColumnName("COMMENTDATE");

                entity.Property(e => e.Content)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.Property(e => e.Videoid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("VIDEOID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKUSERCOM");

                entity.HasOne(d => d.Video)
                    .WithMany(p => p.Comments)
                    .HasForeignKey(d => d.Videoid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKVID");
            });

            modelBuilder.Entity<Contact>(entity =>
            {
                entity.ToTable("CONTACT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Content)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Homeid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("HOMEID");

                entity.Property(e => e.Name)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Subject)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("SUBJECT");

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.Homeid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKCONTACT");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.ToTable("FEEDBACK");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Content)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT");

                entity.Property(e => e.Dtaeofsend)
                    .HasColumnType("DATE")
                    .HasColumnName("DTAEOFSEND");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKFED");
            });

            modelBuilder.Entity<Footer>(entity =>
            {
                entity.ToTable("FOOTER");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Contents)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CONTENTS");

                entity.Property(e => e.Facebook)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("FACEBOOK");

                entity.Property(e => e.Gmail)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("GMAIL");

                entity.Property(e => e.Instagram)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("INSTAGRAM");

                entity.Property(e => e.Whatsapp)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("WHATSAPP");

                entity.Property(e => e.X)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Home>(entity =>
            {
                entity.ToTable("HOME");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Contents)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("CONTENTS");

                entity.Property(e => e.Footerid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("FOOTERID");

                entity.Property(e => e.Imagename)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME");

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.HasOne(d => d.Footer)
                    .WithMany(p => p.Homes)
                    .HasForeignKey(d => d.Footerid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKHOME");
            });


           

            modelBuilder.Entity<Login>(entity =>
            {
                entity.ToTable("LOGIN");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("PASSWORD");

                entity.Property(e => e.Roleid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("ROLEID");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.Property(e => e.Username)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("USERNAME");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.Roleid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKROLEID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Logins)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKUSERID");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.HasKey(e => e.Nid)
                    .HasName("SYS_C008568");

                entity.ToTable("NOTIFICATION");

                entity.Property(e => e.Nid)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("NID");

                entity.Property(e => e.Dtaeofsend)
                    .HasColumnType("DATE")
                    .HasColumnName("DTAEOFSEND");

                entity.Property(e => e.Message)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("MESSAGE");

                entity.Property(e => e.Reportid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("REPORTID");

                entity.Property(e => e.Status)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.HasOne(d => d.Report)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.Reportid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKCNOTUF");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.ToTable("PAYMENT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Cardholdername)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CARDHOLDERNAME");

                entity.Property(e => e.Cardnumber)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CARDNUMBER");

                entity.Property(e => e.Cvv)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CVV");

                entity.Property(e => e.Expirydate)
                    .HasColumnType("DATE")
                    .HasColumnName("EXPIRYDATE");

                entity.Property(e => e.Paymentdate)
                    .HasColumnType("DATE")
                    .HasColumnName("PAYMENTDATE");

                entity.Property(e => e.Totalamount)
                    .HasColumnType("FLOAT")
                    .HasColumnName("TOTALAMOUNT");

                entity.Property(e => e.Userid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.Userid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKUSERPAY");
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("REPORT");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Channelid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CHANNELID");

                entity.Property(e => e.Content)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("CONTENT");

                entity.Property(e => e.Dtaeofsend)
                    .HasColumnType("DATE")
                    .HasColumnName("DTAEOFSEND");

                entity.Property(e => e.Status)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.Channelid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKCHA");
            });

            modelBuilder.Entity<Respon>(entity =>
            {
                entity.ToTable("RESPONS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Commentid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("COMMENTID");

                entity.Property(e => e.Replaycomment)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("REPLAYCOMMENT");

                entity.Property(e => e.Usercid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("USERCID");

                entity.HasOne(d => d.Comment)
                    .WithMany(p => p.Respons)
                    .HasForeignKey(d => d.Commentid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKCOM");

                entity.HasOne(d => d.Userc)
                    .WithMany(p => p.Respons)
                    .HasForeignKey(d => d.Usercid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKRESPON");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("ROLE");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Rolename)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ROLENAME");
            });

            modelBuilder.Entity<Teammember>(entity =>
            {
                entity.ToTable("TEAMMEMBERS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Homeid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("HOMEID");

                entity.Property(e => e.Imagename)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("IMAGENAME");

                entity.Property(e => e.Linkedin)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("LINKEDIN");

                entity.Property(e => e.Membername)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MEMBERNAME");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PHONENUMBER");

                entity.Property(e => e.Role)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.HasOne(d => d.Home)
                    .WithMany(p => p.Teammembers)
                    .HasForeignKey(d => d.Homeid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKTEAM");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("USERS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Age)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("AGE");

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CITY");

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("COUNTRY");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("DATE")
                    .HasColumnName("DATEOFBIRTH");

                entity.Property(e => e.Emaile)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("EMAILE");

                entity.Property(e => e.Firstname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("FIRSTNAME");

                entity.Property(e => e.Image)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("IMAGE");

                entity.Property(e => e.Lastname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LASTNAME");

                entity.Property(e => e.Phonenumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PHONENUMBER");

                entity.Property(e => e.Registerdate)
                    .HasColumnType("DATE")
                    .HasColumnName("REGISTERDATE");
            });

            modelBuilder.Entity<Video>(entity =>
            {
                entity.ToTable("VIDEOS");

                entity.Property(e => e.Id)
                    .HasColumnType("NUMBER(38)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Channelid)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("CHANNELID");

                entity.Property(e => e.Description)
                    .HasMaxLength(800)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION");

                entity.Property(e => e.Imageurl)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("IMAGEURL");

                entity.Property(e => e.Numberofdislike)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("NUMBEROFDISLIKE");

                entity.Property(e => e.Numberofdisplay)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("NUMBEROFDISPLAY");

                entity.Property(e => e.Numberoflike)
                    .HasColumnType("NUMBER(38)")
                    .HasColumnName("NUMBEROFLIKE");

                entity.Property(e => e.Sizeofvideo)
                    .HasColumnType("FLOAT")
                    .HasColumnName("SIZEOFVIDEO");

                entity.Property(e => e.Uploadedate)
                    .HasColumnType("DATE")
                    .HasColumnName("UPLOADEDATE");

                entity.Property(e => e.Videotitle)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("VIDEOTITLE");

                entity.Property(e => e.Videourl)
                    .HasMaxLength(800)
                    .IsUnicode(false)
                    .HasColumnName("VIDEOURL");

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.Videos)
                    .HasForeignKey(d => d.Channelid)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FKCHAE");
            });

           

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
