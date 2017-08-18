using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Drawing.Imaging;
using System.Drawing;

public partial class Controls_ValidateCode : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string randomCode = this.GetRandomCode(4);
        this.Session["CheckCode"] = randomCode;
        this.SetPageNoCache();
        this.CreateImage(randomCode);
    }
    private string GetRandomCode(int CodeCount)
    {
        string[] strArray = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,i,J,K,M,N,P,Q,R,S,T,U,W,X,Y,Z".Split(new char[] { ',' });
        string str2 = "";
        int num = -1;
        Random random = new Random();
        for (int i = 0; i < CodeCount; i++)
        {
            if (num != -1)
            {
                random = new Random((num * i) * ((int)DateTime.Now.Ticks));
            }
            int index = random.Next(0x21);
            while (num == index)
            {
                index = random.Next(0x21);
            }
            num = index;
            str2 = str2 + strArray[index];
        }
        return str2;
    }
    private string CreateRandomCode(int codeCount)
    {
        string[] strArray = "0,1,2,3,4,5,6,7,8,9,A,B,C,D,E,F,G,H,i,J,K,M,N,P,Q,R,S,T,U,W,X,Y,Z".Split(new char[] { ',' });
        string str2 = "";
        int num = -1;
        Random random = new Random();
        for (int i = 0; i < codeCount; i++)
        {
            if (num != -1)
            {
                random = new Random((i * num) * ((int)DateTime.Now.Ticks));
            }
            int index = random.Next(0x23);
            if (num == index)
            {
                return this.CreateRandomCode(codeCount);
            }
            num = index;
            str2 = str2 + strArray[index];
        }
        return str2;
    }

    private void CreateImage(string checkCode)
    {
        try
        {
            int width = checkCode.Length * 14;
            Bitmap image = new Bitmap(width, 20);
            Graphics graphics = Graphics.FromImage(image);
            Font font = new Font("Arial ", 10f);
            Brush brush = new SolidBrush(Color.Black);
            Brush brush2 = new SolidBrush(Color.FromArgb(0xa6, 8, 8));
            graphics.Clear(ColorTranslator.FromHtml("#99C1CB"));
            char[] chArray = checkCode.ToCharArray();
            for (int i = 0; i < chArray.Length; i++)
            {
                if ((chArray[i] >= '0') && (chArray[i] <= '9'))
                {
                    graphics.DrawString(chArray[i].ToString(), font, brush2, (float)(3 + (i * 12)), 3f);
                }
                else
                {
                    graphics.DrawString(chArray[i].ToString(), font, brush, (float)(3 + (i * 12)), 3f);
                }
            }
            MemoryStream stream = new MemoryStream();
            image.Save(stream, ImageFormat.Jpeg);
            base.Response.Cache.SetNoStore();
            base.Response.ClearContent();
            base.Response.ContentType = "image/Jpeg";
            base.Response.BinaryWrite(stream.ToArray());
            graphics.Dispose();
            image.Dispose();
        }
        catch (Exception ex)
        {
            // SystemErrorPlug.ErrorRecord("时间:[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]类名:[" + this.GetType().Name + "],行号:[" + Component.GetLineNum().ToString() + "行],错误信息:[" + ex.Message + "]");
        }
    }
    private void SetPageNoCache()
    {
        base.Response.Buffer = true;
        base.Response.ExpiresAbsolute = DateTime.Now.AddSeconds(-1.0);
        base.Response.Expires = 0;
        base.Response.CacheControl = "no-cache";
        base.Response.AppendHeader("Pragma", "No-Cache");
    }
}