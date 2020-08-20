using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using System.IO;
using System.Threading;

namespace Mail_Bomber
{
    public partial class Form1 : Form
    {
        bool run = false;

        public Form1()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        Thread myThread = null;

        public void send() 
        {
            string sendermail = txtsenderemail.Text;
            string senderpw = txtpw.Text;
            string smtp = txtsmtp.Text;
            string target = txttargetemail.Text;
            string subject = txtsubject.Text;
            string message = txtmessage.Text;
            string filepath = txtfilepath.Text;
            int i = 1;
            progressBar1.Value = 0;

            if (checkBox1.Checked)
            {
                if (!string.IsNullOrEmpty(txtfilepath.Text))
                {
                    string path = txtfilepath.Text;
                    string emailline;
                    int lines = File.ReadLines(path).Count();
                    progressBar1.Maximum = lines;
                    progressBar1.Visible = true;

                    if (File.Exists(path))
                    {
                        StreamReader sreader = null;
                        try
                        {
                            sreader = new StreamReader(path);
                            while ((emailline = sreader.ReadLine()) != null)
                            {
                                if (radioyahoo.Checked)
                                {
                                    try
                                    {
                                        run = true;

                                        MailMessage myMail = new MailMessage();
                                        SmtpClient SmtpServer = new SmtpClient(smtp);

                                        myMail.From = new MailAddress(sendermail);
                                        myMail.To.Add(emailline);
                                        myMail.Subject = subject;
                                        myMail.Body = message;

                                        //SmtpServer.Port = 465;
                                        SmtpServer.Credentials = new System.Net.NetworkCredential(sendermail, senderpw);
                                        SmtpServer.EnableSsl = true;
                                        SmtpServer.Send(myMail);

                                        progressBar1.Value += 1;

                                        //MessageBox.Show("E-Mail to " + emailline + " has been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        if (progressBar1.Value == lines)
                                        {
                                            MessageBox.Show(lines.ToString() + " E-Mails have been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("E-Mail to " + emailline + " was not sent. Error.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else if (radiogmail.Checked)
                                {
                                    try
                                    {
                                        run = true;

                                        MailMessage myMail = new MailMessage();
                                        SmtpClient SmtpServer = new SmtpClient(smtp);

                                        myMail.From = new MailAddress(sendermail);
                                        myMail.To.Add(emailline);
                                        myMail.Subject = subject;
                                        myMail.Body = message;

                                        SmtpServer.Port = 587;
                                        SmtpServer.Credentials = new System.Net.NetworkCredential(sendermail, senderpw);
                                        SmtpServer.EnableSsl = true;
                                        SmtpServer.Send(myMail);

                                        progressBar1.Value += 1;

                                        //MessageBox.Show("E-Mail to " + emailline + " has been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        if (progressBar1.Value == lines)
                                        {
                                            MessageBox.Show(lines.ToString() + " E-Mails have been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("E-Mail to " + emailline + " was not sent. Error.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                                else if (radiomanual.Checked)
                                {
                                    int port = Convert.ToInt32(txtPort.Text);

                                    if (chkssl.Checked)
                                    {
                                        try
                                        {
                                            run = true;

                                            MailMessage myMail = new MailMessage();
                                            SmtpClient SmtpServer = new SmtpClient(smtp);

                                            myMail.From = new MailAddress(sendermail);
                                            myMail.To.Add(emailline);
                                            myMail.Subject = subject;
                                            myMail.Body = message;

                                            SmtpServer.Port = port;
                                            SmtpServer.Credentials = new System.Net.NetworkCredential(sendermail, senderpw);

                                            SmtpServer.EnableSsl = true;
                                            SmtpServer.Send(myMail);

                                            progressBar1.Value += 1;

                                            //MessageBox.Show("E-Mail to " + emailline + " has been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            if (progressBar1.Value == lines)
                                            {
                                                MessageBox.Show(lines.ToString() + " E-Mails have been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("E-Mail to " + emailline + " was not sent. Error.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                    else
                                    {
                                        try
                                        {
                                            run = true;

                                            MailMessage myMail = new MailMessage();
                                            SmtpClient SmtpServer = new SmtpClient(smtp);

                                            myMail.From = new MailAddress(sendermail);
                                            myMail.To.Add(emailline);
                                            myMail.Subject = subject;
                                            myMail.Body = message;

                                            SmtpServer.Port = port;
                                            SmtpServer.Credentials = new System.Net.NetworkCredential(sendermail, senderpw);

                                            //SmtpServer.EnableSsl = true;
                                            SmtpServer.Send(myMail);

                                            progressBar1.Value += 1;

                                            //MessageBox.Show("E-Mail to " + emailline + " has been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            if (progressBar1.Value == lines)
                                            {
                                                MessageBox.Show(lines.ToString() + "E-Mails have been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("E-Mail to " + emailline + " was not sent. Error.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        }
                                    }
                                }
                            }
                        }
                        finally
                        {
                            if (sreader != null)
                                sreader.Close();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Insert filepath!");
                }


            }
            else
            {
                if (txtsenderemail.Text.Length == 0 || txtpw.Text.Length == 0 || txtmailscount.Text.Length == 0 || txtsmtp.Text.Length == 0)
                {
                    MessageBox.Show("Error. Insert information.");
                }
                else
                {
                    if (radioyahoo.Checked)
                    {
                        int count = Convert.ToInt32(txtmailscount.Text);
                        progressBar1.Maximum = count;

                        while (i <= count)
                        {
                            try
                            {
                                run = true;

                                MailMessage myMail = new MailMessage();
                                SmtpClient SmtpServer = new SmtpClient(smtp);

                                myMail.From = new MailAddress(sendermail);
                                myMail.To.Add(target);
                                myMail.Subject = subject;
                                myMail.Body = message;

                                //SmtpServer.Port = 465;
                                SmtpServer.Credentials = new System.Net.NetworkCredential(sendermail, senderpw);
                                SmtpServer.EnableSsl = true;
                                SmtpServer.Send(myMail);

                                progressBar1.Value += 1;
                                i++;

                                if (progressBar1.Value == count)
                                {
                                    MessageBox.Show(count.ToString() + " E-Mails have been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }

                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("E-Mail to " + target + " was not sent. Error.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    if (radiogmail.Checked)
                    {
                        int count = Convert.ToInt32(txtmailscount.Text);
                        progressBar1.Maximum = count;

                        while (i <= count)
                        {
                            try
                            {
                                run = true;

                                MailMessage myMail = new MailMessage();
                                SmtpClient SmtpServer = new SmtpClient(smtp);

                                myMail.From = new MailAddress(sendermail);
                                myMail.To.Add(target);
                                myMail.Subject = subject;
                                myMail.Body = message;

                                SmtpServer.Port = 587;
                                SmtpServer.Credentials = new System.Net.NetworkCredential(sendermail, senderpw);
                                SmtpServer.EnableSsl = true;
                                SmtpServer.Send(myMail);

                                progressBar1.Value += 1;
                                i++;

                                if (progressBar1.Value == count)
                                {
                                    MessageBox.Show(count.ToString() + " E-Mails have been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("E-Mail to " + target + " was not sent. Error.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }

                    if (radiomanual.Checked)
                    {
                        int port = Convert.ToInt32(txtPort.Text);
                        int count = Convert.ToInt32(txtmailscount.Text);
                        progressBar1.Maximum = count;

                        if (chkssl.Checked)
                        {
                            while (i <= count)
                            {
                                try
                                {
                                    run = true;

                                    MailMessage myMail = new MailMessage();
                                    SmtpClient SmtpServer = new SmtpClient(smtp);

                                    myMail.From = new MailAddress(sendermail);
                                    myMail.To.Add(target);
                                    myMail.Subject = subject;
                                    myMail.Body = message;

                                    SmtpServer.Port = port;
                                    SmtpServer.Credentials = new System.Net.NetworkCredential(sendermail, senderpw);

                                    SmtpServer.EnableSsl = true;
                                    SmtpServer.Send(myMail);

                                    progressBar1.Value += 1;
                                    i++;

                                    if (progressBar1.Value == count)
                                    {
                                        MessageBox.Show(count.ToString() + " E-Mails have been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("E-Mail to " + target + " was not sent. Error.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        else
                        {
                            while (i <= count)
                            {
                                try
                                {
                                    run = true;

                                    MailMessage myMail = new MailMessage();
                                    SmtpClient SmtpServer = new SmtpClient(smtp);

                                    myMail.From = new MailAddress(sendermail);
                                    myMail.To.Add(target);
                                    myMail.Subject = subject;
                                    myMail.Body = message;

                                    SmtpServer.Port = port;
                                    SmtpServer.Credentials = new System.Net.NetworkCredential(sendermail, senderpw);

                                    //SmtpServer.EnableSsl = true;
                                    SmtpServer.Send(myMail);

                                    progressBar1.Value += 1;

                                    i++;

                                    if (progressBar1.Value == count)
                                    {
                                        MessageBox.Show(count.ToString() + " E-Mails have been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("E-Mail to " + target + " was not sent. Error.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                }
            }
        }


        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmdStart_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            myThread = new Thread(() => send());
            myThread.Start();

            //string sendermail = txtsenderemail.Text;
            //string senderpw = txtpw.Text;
            //string smtp = txtsmtp.Text;
            //string target = txttargetemail.Text;
            //string subject = txtsubject.Text;
            //string message = txtmessage.Text;
            //string filepath = txtfilepath.Text;
            //int i = 1;

         


            

            //if (checkBox1.Checked)
            //{
            //    if (!string.IsNullOrEmpty(txtfilepath.Text))
            //    {
            //        string path = txtfilepath.Text;
            //        string emailline;
            //        int lines = File.ReadLines(path).Count();
            //        progressBar1.Maximum = lines;
            //        progressBar1.Visible = true;

            //        if (File.Exists(path))
            //        {
            //            StreamReader sreader = null;
            //            try
            //            {
            //                sreader = new StreamReader(path);
            //                while ((emailline = sreader.ReadLine()) != null)
            //                {
            //                    if (radioyahoo.Checked)
            //                    {
            //                        try
            //                        {
            //                            run = true;

            //                            MailMessage myMail = new MailMessage();
            //                            SmtpClient SmtpServer = new SmtpClient(smtp);

            //                            myMail.From = new MailAddress(sendermail);
            //                            myMail.To.Add(emailline);
            //                            myMail.Subject = subject;
            //                            myMail.Body = message;

            //                            //SmtpServer.Port = 465;
            //                            SmtpServer.Credentials = new System.Net.NetworkCredential(sendermail, senderpw);
            //                            SmtpServer.EnableSsl = true;
            //                            SmtpServer.Send(myMail);

            //                            progressBar1.Value += 1;

            //                            //MessageBox.Show("E-Mail to " + emailline + " has been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                            if (progressBar1.Value == lines)
            //                            {
            //                                MessageBox.Show(lines.ToString() + " E-Mails have been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                            }
            //                        }
            //                        catch (Exception ex)
            //                        {
            //                            MessageBox.Show("E-Mail to " + emailline + " was not sent. Error.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                        }
            //                    }
            //                    else if (radiogmail.Checked)
            //                    {
            //                        try
            //                        {
            //                            run = true;

            //                            MailMessage myMail = new MailMessage();
            //                            SmtpClient SmtpServer = new SmtpClient(smtp);

            //                            myMail.From = new MailAddress(sendermail);
            //                            myMail.To.Add(emailline);
            //                            myMail.Subject = subject;
            //                            myMail.Body = message;

            //                            SmtpServer.Port = 587;
            //                            SmtpServer.Credentials = new System.Net.NetworkCredential(sendermail, senderpw);
            //                            SmtpServer.EnableSsl = true;
            //                            SmtpServer.Send(myMail);

            //                            progressBar1.Value += 1;

            //                            //MessageBox.Show("E-Mail to " + emailline + " has been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                            if (progressBar1.Value == lines)
            //                            {
            //                                MessageBox.Show(lines.ToString() + " E-Mails have been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                            }
            //                        }
            //                        catch (Exception ex)
            //                        {
            //                            MessageBox.Show("E-Mail to " + emailline + " was not sent. Error.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                        }
            //                    }
            //                    else if (radiomanual.Checked)
            //                    {
            //                        int port = Convert.ToInt32(txtPort.Text);

            //                        if (chkssl.Checked)
            //                        {
            //                            try
            //                            {
            //                                run = true;

            //                                MailMessage myMail = new MailMessage();
            //                                SmtpClient SmtpServer = new SmtpClient(smtp);

            //                                myMail.From = new MailAddress(sendermail);
            //                                myMail.To.Add(emailline);
            //                                myMail.Subject = subject;
            //                                myMail.Body = message;

            //                                SmtpServer.Port = port;
            //                                SmtpServer.Credentials = new System.Net.NetworkCredential(sendermail, senderpw);

            //                                SmtpServer.EnableSsl = true;
            //                                SmtpServer.Send(myMail);

            //                                progressBar1.Value += 1;

            //                                //MessageBox.Show("E-Mail to " + emailline + " has been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                                if (progressBar1.Value == lines)
            //                                {
            //                                    MessageBox.Show(lines.ToString() + " E-Mails have been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                                }
            //                            }
            //                            catch (Exception ex)
            //                            {
            //                                MessageBox.Show("E-Mail to " + emailline + " was not sent. Error.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                            }
            //                        }
            //                        else
            //                        {
            //                            try
            //                            {
            //                                run = true;

            //                                MailMessage myMail = new MailMessage();
            //                                SmtpClient SmtpServer = new SmtpClient(smtp);

            //                                myMail.From = new MailAddress(sendermail);
            //                                myMail.To.Add(emailline);
            //                                myMail.Subject = subject;
            //                                myMail.Body = message;

            //                                SmtpServer.Port = port;
            //                                SmtpServer.Credentials = new System.Net.NetworkCredential(sendermail, senderpw);

            //                                //SmtpServer.EnableSsl = true;
            //                                SmtpServer.Send(myMail);

            //                                progressBar1.Value += 1;

            //                                //MessageBox.Show("E-Mail to " + emailline + " has been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                                if (progressBar1.Value == lines)
            //                                {
            //                                    MessageBox.Show(lines.ToString() + "E-Mails have been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                                }
            //                            }
            //                            catch (Exception ex)
            //                            {
            //                                MessageBox.Show("E-Mail to " + emailline + " was not sent. Error.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                            }
            //                        }
            //                    }
            //                }
            //            }
            //            finally
            //            {
            //                if (sreader != null)
            //                    sreader.Close();
            //            }
            //        } 
            //    }
            //    else 
            //    {
            //        MessageBox.Show("Insert filepath!");
            //    }
                

            //}
            ////non-file-sending
            //else
            //{
            //    if (txtsenderemail.Text.Length == 0 || txtpw.Text.Length == 0 || txtmailscount.Text.Length == 0 || txtsmtp.Text.Length == 0)
            //    {
            //        MessageBox.Show("Error. Insert information.");
            //    }
            //    else 
            //    {
            //        if (radioyahoo.Checked)
            //        {
            //            int count = Convert.ToInt32(txtmailscount.Text);
            //            progressBar1.Maximum = count;

            //            while (i <= count)
            //            {
            //                try
            //                {
            //                    run = true;

            //                    MailMessage myMail = new MailMessage();
            //                    SmtpClient SmtpServer = new SmtpClient(smtp);

            //                    myMail.From = new MailAddress(sendermail);
            //                    myMail.To.Add(target);
            //                    myMail.Subject = subject;
            //                    myMail.Body = message;

            //                    //SmtpServer.Port = 465;
            //                    SmtpServer.Credentials = new System.Net.NetworkCredential(sendermail, senderpw);
            //                    SmtpServer.EnableSsl = true;
            //                    SmtpServer.Send(myMail);

            //                    progressBar1.Value += 1;
            //                    i++;

            //                    if (progressBar1.Value == count)
            //                    {
            //                        MessageBox.Show(count.ToString() + " E-Mails have been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                    }

            //                }
            //                catch (Exception ex)
            //                {
            //                    MessageBox.Show("E-Mail to " + target + " was not sent. Error.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                }
            //            }
            //        }

            //        if (radiogmail.Checked)
            //        {
            //            int count = Convert.ToInt32(txtmailscount.Text);
            //            progressBar1.Maximum = count;

            //            while (i <= count)
            //            {
            //                try
            //                {
            //                    run = true;

            //                    MailMessage myMail = new MailMessage();
            //                    SmtpClient SmtpServer = new SmtpClient(smtp);

            //                    myMail.From = new MailAddress(sendermail);
            //                    myMail.To.Add(target);
            //                    myMail.Subject = subject;
            //                    myMail.Body = message;

            //                    SmtpServer.Port = 587;
            //                    SmtpServer.Credentials = new System.Net.NetworkCredential(sendermail, senderpw);
            //                    SmtpServer.EnableSsl = true;
            //                    SmtpServer.Send(myMail);

            //                    progressBar1.Value += 1;
            //                    i++;

            //                    if (progressBar1.Value == count)
            //                    {
            //                        MessageBox.Show(count.ToString() + " E-Mails have been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                    }
            //                }
            //                catch (Exception ex)
            //                {
            //                    MessageBox.Show("E-Mail to " + target + " was not sent. Error.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                }
            //            }
            //        }

            //        if (radiomanual.Checked)
            //        {
            //            int port = Convert.ToInt32(txtPort.Text);
            //            int count = Convert.ToInt32(txtmailscount.Text);
            //            progressBar1.Maximum = count;

            //            if (chkssl.Checked)
            //            {
            //                while (i <= count)
            //                {
            //                    try
            //                    {
            //                        run = true;

            //                        MailMessage myMail = new MailMessage();
            //                        SmtpClient SmtpServer = new SmtpClient(smtp);

            //                        myMail.From = new MailAddress(sendermail);
            //                        myMail.To.Add(target);
            //                        myMail.Subject = subject;
            //                        myMail.Body = message;

            //                        SmtpServer.Port = port;
            //                        SmtpServer.Credentials = new System.Net.NetworkCredential(sendermail, senderpw);

            //                        SmtpServer.EnableSsl = true;
            //                        SmtpServer.Send(myMail);

            //                        progressBar1.Value += 1;
            //                        i++;

            //                        if (progressBar1.Value == count)
            //                        {
            //                            MessageBox.Show(count.ToString() + " E-Mails have been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                        }
            //                    }
            //                    catch (Exception ex)
            //                    {
            //                        MessageBox.Show("E-Mail to " + target + " was not sent. Error.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                while (i <= count)
            //                {
            //                    try
            //                    {
            //                        run = true;

            //                        MailMessage myMail = new MailMessage();
            //                        SmtpClient SmtpServer = new SmtpClient(smtp);

            //                        myMail.From = new MailAddress(sendermail);
            //                        myMail.To.Add(target);
            //                        myMail.Subject = subject;
            //                        myMail.Body = message;

            //                        SmtpServer.Port = port;
            //                        SmtpServer.Credentials = new System.Net.NetworkCredential(sendermail, senderpw);

            //                        //SmtpServer.EnableSsl = true;
            //                        SmtpServer.Send(myMail);

            //                        progressBar1.Value += 1;

            //                        i++;

            //                        if (progressBar1.Value == count)
            //                        {
            //                            MessageBox.Show(count.ToString() + " E-Mails have been sent.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //                        }
            //                    }
            //                    catch (Exception ex)
            //                    {
            //                        MessageBox.Show("E-Mail to " + target + " was not sent. Error.\n" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
        }

        private void radioyahoo_CheckedChanged(object sender, EventArgs e)
        {
            txtsmtp.Text = "smtp.mail.yahoo.com";
            txtPort.Visible = false;
            lblPort.Visible = false;
            chkssl.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            txtPort.Visible = true;
            lblPort.Visible = true;
            txtsmtp.Text = "";
            chkssl.Visible = true;
        }

        private void radiogmail_CheckedChanged(object sender, EventArgs e)
        {
            txtsmtp.Text = "smtp.gmail.com";
            txtPort.Visible = false;
            lblPort.Visible = false;
            chkssl.Visible = false;
        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            run = false;
            myThread.Suspend();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            label7.Visible = false;
            txtmailscount.Visible = false;
            txttargetemail.Visible = false;
            label4.Visible = false;

            if (checkBox1.Checked == false)
            {
                label7.Visible = true;
                txtmailscount.Visible = true;
                txttargetemail.Visible = true;
                label4.Visible = true;
            }
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            
        }

        private void cmddialog_Click(object sender, EventArgs e)
        {
            OpenFileDialog fdia = new OpenFileDialog();
            fdia.Filter = "txt files (*.txt)|*.txt";
            if(fdia.ShowDialog() == DialogResult.OK)
            {
                txtfilepath.Text = fdia.FileName;
            }
            
        }
    }
}
