using MVPSample.Common;

using System.Windows.Forms;

namespace MVPSample.Views;

internal class MessageView : IMessageView
{
    public void ShowMessage(string message)
    {
        MessageBox.Show(message, "Сообщение");
    }
}
