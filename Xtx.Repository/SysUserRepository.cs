using Xtx.Entity.Db1;
using Xtx.Entity.NetCoreDemoDb;
using Xtx.IRepository;
using Zxw.Framework.NetCore.Attributes;
using Zxw.Framework.NetCore.IDbContext;
using Zxw.Framework.NetCore.Repositories;

namespace Xtx.Repository
{
    public class SysUserRepository : BaseRepository<SysUser, string>, ISysUserRepository
    {
        [FromDbContextFactory("db2")]
        public IDbContextCore db2 { get; set; }
        public SysUserRepository(IDbContextCore dbContext) : base(dbContext)
        {

        }

        public object GetSms()
        {
            return db2.Get<SystemSms>();
        }
    }
}
