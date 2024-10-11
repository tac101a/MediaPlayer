using HandyControl.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Media_Player_App
{
    static class MessageBox
    {
        /// <author>Nguyen Tuan Khanh</author>
        /// <summary>
        /// HIện message box thông báo
        /// </summary>
        /// <param name="type">MessageType</param>
        /// <param name="caption">string</param>
        /// <param name="message">string</param>
        static public void Show(MessageType type, string caption, string message)
        {
            var MessageBoxInfo = new MessageBoxInfo
            {
                Message = message,
                Caption = caption
            };
            switch (type)
            {
                case MessageType.Info:
                    MessageBoxInfo.Button = MessageBoxButton.OK;
                    MessageBoxInfo.IconBrushKey = ResourceToken.SuccessBrush;
                    MessageBoxInfo.IconKey = ResourceToken.SuccessGeometry;
                    break;
                case MessageType.Warn:
                    MessageBoxInfo.Button = MessageBoxButton.OKCancel;
                    MessageBoxInfo.IconBrushKey = ResourceToken.WarningBrush;
                    MessageBoxInfo.IconKey = ResourceToken.WarningGeometry;
                    break;
                case MessageType.Error:
                    MessageBoxInfo.Button = MessageBoxButton.OK;
                    MessageBoxInfo.IconBrushKey = ResourceToken.AccentBrush;
                    MessageBoxInfo.IconKey = ResourceToken.ErrorGeometry;
                    break;
                default:
                    return;
            }
            HandyControl.Controls.MessageBox.Show(MessageBoxInfo);
        }

        internal static void Show(string v)
        {
            throw new NotImplementedException();
        }
    }

    enum MessageType
    {
        Info = 0,
        Warn = 1,
        Error = 2,
        Confirm = 3,
    }
}
