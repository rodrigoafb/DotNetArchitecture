using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Solution.Application.Applications;
using Solution.CrossCutting.AspNetCore.Attributes;
using Solution.Model.Entities;
using Solution.Model.Models;

namespace Solution.Web.App
{
    [ApiController]
    [RouteController]
    public class UserServiceController : ControllerBase
    {
        public UserServiceController(IUserApplication userApplication)
        {
            UserApplication = userApplication;
        }

        private IUserApplication UserApplication { get; }

        [AllowAnonymous]
        [HttpGet]
        public IEnumerable<UserEntity> Get()
        {
            return UserApplication.List();
        }
    }
}
