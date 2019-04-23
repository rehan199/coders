using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace module1
{
    public partial class Create : System.Web.UI.Page
    {
        Class1 asd = new Class1();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                
                string msg = "";
                string SQL;
                //SQL = "select 'abc' as a,'xzs'as b ";
                //SQL += " union select 'abc1' as a,'xzs1'as b ";
                //SQL += " union select 'abc2' as a,'xzs2'as b ";
                //SQL += " union select 'abc3' as a,'xzs3'as b ";
                SQL = "select Users.UID as U_ID,  Users.userName as user_Name,Resume_Creation1.LastUsed as Last_Used, Resume_Creation1.DataSize as Data_Size from Users inner join Resume_Creation1 on Users.UID = Resume_Creation1.UID";
                DataTable dt;
                dt = asd.GetDataTable(SQL, out msg);
                GRD_User.DataSource = dt;
                GRD_User.DataBind();
            }
        }



        protected void GRD_Province_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "remove")
            {
                string msg = "";
                GridView tempgrd = (GridView)sender;
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int rowIndex = row.RowIndex;
                string id = tempgrd.DataKeys[rowIndex].Value.ToString();
                string SQL;
                // SQL = "delete from Users where UID=" + id + "";
                SQL = "delete from Users where UID=" + id + "";
                asd.ExecuteCommand(SQL, out msg);
                if (msg == "")
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('delete successfully!')", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('some error!')", true);
                }
            }
            else if (e.CommandName == "Email")
            {

                GridView tempgrd = (GridView)sender;
                GridViewRow row = (GridViewRow)(((ImageButton)e.CommandSource).NamingContainer);
                int rowIndex = row.RowIndex;
                string id = tempgrd.DataKeys[rowIndex].Value.ToString();
                string SQL;
                string body = " Welcome . Congratulation. <br />" +
                               " You are selected for job interview <br />"+
                               " Please be prepared  <br />";
       
                DataTable dt;
                SendEmail("Agency Property", "tayyabasuleman175@gmail.com", "Tayyaba", "tayyabasuleman175@gmail.com", "Account Confirmation", body, "", "");
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('mail sent successfully!')", true);

            }

        }

        public static void SendEmail(string FromName, string FromEmail, string ToName, string ToEmail, string Subjecttt, string body, string CC, string File)
        {
            try
            {
                System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
                MailAddress from = new MailAddress(FromEmail, FromName);
                MailAddress To = new MailAddress(ToEmail, ToName);
                mail.From = from;
                mail.To.Add(To);
                if (CC != "")
                    mail.Bcc.Add(CC);
                if (File != "")
                {
                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment(HttpContext.Current.Server.MapPath("~/img/" + File));
                    mail.Attachments.Add(attachment);
                }
                mail.IsBodyHtml = true;
                mail.Body = body;
                MailMessage message = new MailMessage(from, To);
                mail.Subject = Subjecttt;
                mail.IsBodyHtml = true;
                SmtpClient mailer = new SmtpClient();
                mailer.Host = "smtp.1and1.com";
                mailer.Credentials = new System.Net.NetworkCredential("test@systelligence.com", "test123");
                mailer.Send(mail);
            }

            catch (SmtpException ex)
            {

            }
        }

    }
}