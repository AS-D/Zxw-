using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xtx.IRepository;

namespace TestApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    { 
        private readonly ISysUserRepository sysUserRepository;

        public TestController(ISysUserRepository  sysUserRepository)
        {
            this.sysUserRepository = sysUserRepository;
        }
        //[HttpGet]
        //public object Get()
        //{
        //    return yyxUsersRepository.Get();
        //}

        [HttpGet(Name = "GetSms")]
        public object GetSms()
        {
            return sysUserRepository.GetSms();
        }
    }
}
