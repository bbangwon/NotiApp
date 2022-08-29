namespace NotiApp.Models
{
    public interface IMyNotificationRepository
    {
        public void CompleteNotificationByUserid(int userId);
        void CompleteNotificationByUserid(int userId, int id);
        MyNotification? GetNotificationByUserid(int userId);
        bool IsNotification(int userId);
    }
}