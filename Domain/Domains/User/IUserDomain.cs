using System.Collections.Generic;
using Solution.CrossCutting.Utils;
using Solution.Model.Entities;
using Solution.Model.Models;

namespace Solution.Domain.Domains
{
    public interface IUserDomain : IBaseDomain
    {
        PagedList<UserEntity> List(PagedListParameters parameters);

        IEnumerable<UserEntity> List();

        UserEntity Select(long userId);
    }
}
