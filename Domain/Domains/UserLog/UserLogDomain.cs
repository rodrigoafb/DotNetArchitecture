using Solution.Domain.Domains.UserLog;
using Solution.Infrastructure.Database;
using Solution.Model.Enums;

namespace Solution.Domain.Domains
{
    public sealed class UserLogDomain : BaseDomain, IUserLogDomain
    {
        public UserLogDomain(IDatabaseUnitOfWork databaseUnitOfWork)
        {
            DatabaseUnitOfWork = databaseUnitOfWork;
        }

        private IDatabaseUnitOfWork DatabaseUnitOfWork { get; }

        public void Save(long userId, LogType logType)
        {
            var userLog = UserLogFactory.Create(userId, logType);
            DatabaseUnitOfWork.UserLogRepository.Add(userLog);
            DatabaseUnitOfWork.SaveChanges();
        }
    }
}
