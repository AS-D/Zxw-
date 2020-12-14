using Microsoft.EntityFrameworkCore;
using Xtx.Entity.Db1;
using Zxw.Framework.NetCore.DbContextCore;
using Zxw.Framework.NetCore.Options;

namespace Xtx.EntityFramework.Core.DbContexts
{
    public class Db1Context : SqlServerDbContext
    {

        public Db1Context(DbContextOption option) : base(option) { }

        public virtual DbSet<SystemSms> SystemSms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SystemSms>(entity =>
            {
                entity.HasComment("系统短信模块表");

                entity.Property(e => e.Id).HasComment("Id");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasComment("电话号码"); 

                entity.Property(e => e.ScourceType).HasComment("来源类型");
                 
                entity.Property(e => e.SmsContent)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasComment("短信内容"); 

                entity.Property(e => e.SmsType).HasComment("短信类型");
            });

        }

    }
}