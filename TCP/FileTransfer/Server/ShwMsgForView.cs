using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace Server
{
    public class ShwMsgForView
    {
        delegate void ShwMsgforViewCallBack(ListBox listbox, string text);
        public static void ShwMsgforView(ListBox listbox, string text)
        {
            if (listbox.InvokeRequired)
            {
                ShwMsgforViewCallBack shwMsgforViewCallBack = ShwMsgforView;
                listbox.Invoke(shwMsgforViewCallBack, new object[] { listbox, text });
            }
            else
            {
                listbox.Items.Add(text);
                listbox.SelectedIndex = listbox.Items.Count - 1;
                listbox.ClearSelected();
            }
        }
    }
}