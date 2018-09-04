using System;
using Solution.Model.Entities;
using Solution.Model.Enums;

namespace Solution.Domain.Domains.UserLog
{
    public static class UserLogFactory
    {
        public static UserLogEntity Create(long userId, LogType logType)
        {
            return new UserLogEntity
            {
                UserId = userId,
                LogType = logType,
                DateTime = DateTime.UtcNow
            };
        }
    }
}
