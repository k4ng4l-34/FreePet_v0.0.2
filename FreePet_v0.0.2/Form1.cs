using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace FreePet_v0._0._2
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\\Kayitlar.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataReader dr;
        int catid = 1, dogid = 1, birdid = 1;
        
        public void catrefresh()
        {
            conn.Open();
            cmd = new OleDbCommand("Select * From cats where id=(" + catid + ")", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblName.Text = dr["ad"].ToString();
                lblAge.Text = dr["yas"].ToString();
                lblCins.Text = dr["cins"].ToString();
                lblOwn.Text = dr["sahip_ad"].ToString();
                lblEngel.Text = dr["engel"].ToString();
                rtbAbout.Text = dr["about"].ToString();
                lblTel.Text = dr["tel"].ToString();
            }
            conn.Close();
        }
        public void dogrefresh()
        {
            conn.Open();
            cmd = new OleDbCommand("Select * From dogs where id=(" + dogid + ")", conn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lblName.Text = dr["ad"].ToString();
                lblAge.Text = dr["yas"].ToString();
                lblCins.Text = dr["cins"].ToString();
                lblOwn.Text = dr["sahip_ad"].ToString();
                lblEngel.Text = dr["engel"].ToString();
                rtbAbout.Text = dr["about"].ToString();
                lblTel.Text = dr["tel"].ToString();
            }
            conn.Close();
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        #region PictureBox Panel

        PictureBox temp;
        private void button2_Click(object sender, EventArgs e)
        {
            if (temp == null) temp = pictureBox4;
            Point tempY = new Point(17, temp.Location.Y + temp.Size.Height + 15);
            for (int i = 1; i <= 4; i++)
            {
                PictureBox p = new PictureBox();
                p.Name = "p" + i;
                p.Location = tempY;
                p.Size = new Size(223, 155);
                p.Tag = "p" + i;
                p.BorderStyle = BorderStyle.FixedSingle;
                p.Image = Image.FromFile("D:\\icons8-back-48.png");
                p.SizeMode = PictureBoxSizeMode.Zoom;
                panel3.Controls.Add(p);
                tempY = new Point(17, p.Location.Y + p.Size.Height + 15);
                temp = p;
            }

            PictureBox p2 = new PictureBox();
            p2.Location = tempY;
            p2.Size = new Size(0, 0);
            panel3.Controls.Add(p2);
           
        }
        #endregion
        #region navBar Click Events
        private void navBarItem1_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            catrefresh();
            xtraTabPage1.PageVisible = true;
        }

        private void navBarItem2_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            dogrefresh();
            xtraTabPage2.PageVisible = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void xtraTabControl1_CloseButtonClick(object sender, EventArgs e)
        {
            ClosePageButtonEventArgs arg = e as ClosePageButtonEventArgs;
            (arg.Page as XtraTabPage).PageVisible = false;
        }
        #endregion

        #region Buttons
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            catid++;
            catrefresh();
        }
       
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            catid--;
            catrefresh();
        }
        #endregion
    }
}
