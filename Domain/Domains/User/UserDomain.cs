using System.Collections.Generic;
using Solution.CrossCutting.Utils;
using Solution.Infrastructure.Database;
using Solution.Model.Entities;
using Solution.Model.Models;

namespace Solution.Domain.Domains
{
    public sealed class UserDomain : BaseDomain, IUserDomain
    {
        public UserDomain(IDatabaseUnitOfWork databaseUnitOfWork)
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        public PagedList<UserEntity> List(PagedListParameters parameters)
        {
            return DatabaseUnitOfWork.UserRepository.List(parameters);
        }

        public IEnumerable<UserEntity> List()
        {
            return DatabaseUnitOfWork.UserRepository.List();
        }

        public UserEntity Select(long userId)
        {
            return DatabaseUnitOfWork.UserRepository.Select(userId);
        }
    }
}
