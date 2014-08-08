using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MGT
{
    public partial class aboutWindow : Form
    {
        public aboutWindow()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openLinkConfluenceAbout();
        }


        private void openLinkConfluenceAbout()
        {
            System.Diagnostics.Process.Start("https://confluence.mail.ru/pages/viewpage.action?pageId=31984704#id-%D0%9F%D1%80%D0%B8%D0%BA%D0%BB%D0%B0%D0%B4%D0%BD%D0%BE%D0%B9%D0%B8%D0%BD%D1%81%D1%82%D1%80%D1%83%D0%BC%D0%B5%D0%BD%D1%82%D0%B0%D1%80%D0%B8%D0%B9-MGT");
        }
    }
}
