using Xtx.Entity.NetCoreDemoDb;
using Zxw.Framework.NetCore.Attributes;
using Zxw.Framework.NetCore.Repositories;

namespace Xtx.IRepository
{
    [FromDbContextFactoryInterceptor]
    public interface ISysUserRepository : IRepository<SysUser, string>
    {
        object GetSms();
    }
}
