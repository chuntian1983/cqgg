using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Modules.AD
{
    /// <summary>
    /// ListItems�б�
    /// </summary>
    public class Collection
    {
        public Collection()
        {
            //
            // TODO: �ڴ˴���ӹ��캯���߼�
            //
        }

         /// <summary>
        /// ���listitem
        /// </summary>
        /// <returns></returns>
        public static ListItemCollection ADFlag()
        {
            ListItemCollection ltc = new ListItemCollection();
            ltc.Add(new ListItem("��������", "0"));
            ltc.Add(new ListItem("��ͨ��̬���", "static"));
            ltc.Add(new ListItem("����Ư�����", "float"));
            ltc.Add(new ListItem("���������", "leftroll"));
            ltc.Add(new ListItem("�Ҳ�������", "rightroll"));
            ltc.Add(new ListItem("���������", "leftpair"));
            ltc.Add(new ListItem("�Ҳ�������", "rightpair"));
            ltc.Add(new ListItem("�������", "pop"));
            return ltc;
        }
    }
}
