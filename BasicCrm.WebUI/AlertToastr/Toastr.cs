using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicCrm.WebUI.AlertToastr
{
    public class Toastr
    {
        public enum NotificationType
        {
            error,
            success,
            warning,
            info
        };
        public static string Alert(string message, string title, NotificationType notificationType)
        {
            var msg = "toastr." + notificationType.ToString().ToLower() + "('" + message + "','" + title + "','" + notificationType + "')" + "";
            return msg;
        }
    }
}
