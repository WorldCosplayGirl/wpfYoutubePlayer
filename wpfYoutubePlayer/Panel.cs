using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wpfYoutubePlayer
{
    public partial class Panel : Form
    {
        protected internal string rtnval="";
        protected internal bool topest;

        public Panel()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var text = txtUrl.Text;

                if (!txtUrl.Text.Contains("youtube.com"))
                {
                    MessageBox.Show("Youtube網址未包含，請重試");
                    return;
                }

                if (txtUrl.Text.Contains("watch?v="))
                {
                    text = @"https://www.youtube.com/v/" + text.Substring(text.IndexOf("v=") + 2) + "&autoplay=1";
                }

                DialogResult = DialogResult.OK;

                rtnval = text;
                topest = chkTopset.Checked;
            }
            catch(Exception ex)
            {
                MessageBox.Show("發生錯誤：\n" + ex.Message);
                DialogResult = DialogResult.Abort;
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Retry;
        }
    }
}
