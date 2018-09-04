using System.Collections.Generic;
using Solution.CrossCutting.Utils;
using Solution.Domain.Domains;
using Solution.Model.Entities;

namespace Solution.Application.Applications
{
    public sealed class UserApplication : BaseApplication, IUserApplication
    {
        public UserApplication(IUserDomain userDomain)
        {
            UserDomain = userDomain;
        }

        private IUserDomain UserDomain { get; }

        public PagedList<UserEntity> List(PagedListParameters parameters)
        {
            return UserDomain.List(parameters);
        }

        public IEnumerable<UserEntity> List()
        {
            return UserDomain.List();
        }

        public UserEntity Select(long userId)
        {
            return UserDomain.Select(userId);
        }
    }
}
