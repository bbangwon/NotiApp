using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;

namespace NotiApp.Models
{
    public class MyNotificationRepository : IMyNotificationRepository
    {
        private IDbConnection? db;

        public MyNotificationRepository(string connectionString)
        {
            db = new SqlConnection(connectionString);
        }

        /// <summary>
        /// 특정 사용자에 대한 알림이 있는가?
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool IsNotification(int userId)
        {
            bool r = false;
            string sql = "Select Count(*) From MyNoti Where UserId = @UserId And IsComplete = 0";
            int count = db.Query<int>(sql, new { UserId = userId }).Single();

            if (count > 0)
                r = true;

            return r;
        }

        /// <summary>
        /// 특정 사용자의 최신 알림 메시지 반환
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public MyNotification? GetNotificationByUserid(int userId)
        {
            string sql = "Select Top 1 * From MyNoti Where UserId = @UserId And IsComplete = 0";
            return db.Query<MyNotification>(sql, new { UserId = userId }).SingleOrDefault();
        }

        /// <summary>
        /// 특정 사용자의 특정 알림에 대해 확인했다고 설정
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="id"></param>
        public void CompleteNotificationByUserid(int userId, int id)
        {
            string sql = "Update MyNoti Set IsComplete = 1 Where UserId = @UserId And Id = @Id";
            db.Execute(sql, new { UserId = userId, Id = id });
        }

        /// <summary>
        /// 특정 사용자의 모든 알림을 확인으로 처리
        /// </summary>
        /// <param name="userId"></param>
        public void CompleteNotificationByUserid(int userId)
        {
            string sql = "Update MyNoti Set IsComplete = 1 Where UserId = @UserId";
            db.Execute(sql, new { UserId = userId });
        }
    }
}