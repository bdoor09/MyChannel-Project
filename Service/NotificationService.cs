using MyChannel.Core.Data;
using MyChannel.Core.DTO;
using MyChannel.Core.Repository;
using MyChannel.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Infra.Service
{
    public class NotificationService: INotificationService
    {
        private readonly INotificationRepoistory NotificationRepoistory;
        public NotificationService(INotificationRepoistory _notificationRepoistory)
        {
            this.NotificationRepoistory = _notificationRepoistory;
        }


        public void CreateNotification(Notification notification)
        {
            NotificationRepoistory.CreateNotification(notification);
        }

        public void UpdateNotification(Notification notification)
        {
            NotificationRepoistory.UpdateNotification(notification);
        }

        public void DeleteNotification(int id)
        {
            NotificationRepoistory.DeleteNotification(id);
        }
        public List<Notification> GetAllNotification()
        {
            return NotificationRepoistory.GetAllNotification();
        }

        public Notification GetNotificationByID(int id)
        {
            return NotificationRepoistory.GetNotificationByID(id);
        }

        public bool CheckNotificatio(Notify notify)
        {
            return NotificationRepoistory.CheckNotificatio(notify);
        }
    
        public Notify DeleteNotfyByRId(int p_rid)
        {
            return NotificationRepoistory.DeleteNotfyByRId(p_rid);
        }
    }
}
