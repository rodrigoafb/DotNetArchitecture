using System.Collections.Generic;
using Solution.CrossCutting.Utils;
using Solution.Model.Entities;

namespace Solution.Application.Applications
{
    public interface IUserApplication : IBaseApplication
    {
        PagedList<UserEntity> List(PagedListParameters parameters);

        IEnumerable<UserEntity> List();

        UserEntity Select(long userId);
    }
}
