﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Zxw.Framework.NetCore.DbContextCore;
using Zxw.Framework.NetCore.Options;

#nullable disable

namespace Xtx.Entity.NetCoreDemoDb
{
    public partial class NetcoredemoContext : SqlServerDbContext
    {
      

        public NetcoredemoContext(DbContextOption options)
            : base(options)
        {
        }

        public virtual DbSet<SysMenu> SysMenu { get; set; }
        public virtual DbSet<SysPermission> SysPermission { get; set; }
        public virtual DbSet<SysRole> SysRole { get; set; }
        public virtual DbSet<SysUser> SysUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysMenu>(entity =>
            {
                entity.Property(e => e.SysMenuId).HasMaxLength(36);

                entity.Property(e => e.Identity)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.MenuIcon).HasMaxLength(50);

                entity.Property(e => e.MenuName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.MenuPath).HasMaxLength(255);

                entity.Property(e => e.ParentId).HasMaxLength(255);

                entity.Property(e => e.RouteUrl)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.SortIndex).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<SysPermission>(entity =>
            {
                entity.Property(e => e.SysPermissionId).HasMaxLength(36);
            });

            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.Property(e => e.SysRoleId).HasMaxLength(36);

                entity.Property(e => e.NodePath).HasMaxLength(255);

                entity.Property(e => e.SysRoleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.Property(e => e.SysUserId).HasMaxLength(36);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("EMail");

                entity.Property(e => e.LatestLoginIp)
                    .HasMaxLength(100)
                    .HasColumnName("LatestLoginIP");

                entity.Property(e => e.SysPassword)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SysUserName)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Telephone).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}