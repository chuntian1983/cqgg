﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Modules.Question;
using Modules.Answer;

public partial class SysAdmin_Question_ReferDel : System.Web.UI.Page
{
    QuestionDAL dal = new QuestionDAL();
    AnswerDAL dal1 = new AnswerDAL();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["ReferId"] != null && Request.QueryString["ReferId"].ToString() != "")
        {
            int referid = Int32.Parse(Request.QueryString["ReferId"].ToString());
            if (dal1.Exists(referid) == true)
            {
                dal1.Delete(referid);
            } 
            dal.Delete(referid);
            Response.Redirect("ReferList.aspx");
        }
    }
}
