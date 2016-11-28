using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileManagement;

namespace HTML_Preview
{
    public partial class SaveForm : Form
    {
        public static string[] NomiFile = new string[2];
        int type = 0;

        public SaveForm(DataColor setting)
        {
            InitializeComponent();

            BackColor = ColorTranslator.FromHtml(setting.Bg_Color);

            label3.ForeColor = ColorTranslator.FromHtml(setting.txt_ForeColor);
            label3.Location = new Point(((Width / 2) / 2) - (label3.Size.Width / 2), 99);

            label1.ForeColor = ColorTranslator.FromHtml(setting.txt_ForeColor);
            label1.Location = new Point(((Width / 2) / 2) - (label1.Size.Width / 2), 66);

            label2.ForeColor = ColorTranslator.FromHtml(setting.txt_ForeColor);
            label2.Location = new Point(((Width / 2) / 2) - (label2.Size.Width / 2), 99);

            txt_htmlName.BackColor = ColorTranslator.FromHtml(setting.html_BgColor);
            txt_htmlName.ForeColor = ColorTranslator.FromHtml(setting.html_ForeColor);
            txt_htmlName.Location = new Point((Width / 2) - 10, 66);
            txt_htmlName.BorderStyle = BorderStyle.None;

            txt_cssName.BackColor = ColorTranslator.FromHtml(setting.css_BgColor);
            txt_cssName.ForeColor = ColorTranslator.FromHtml(setting.css_ForeColor);
            txt_cssName.Location = new Point((Width / 2) - 10, 99);
            txt_cssName.BorderStyle = BorderStyle.None;

            txt_FolderName.BackColor = ColorTranslator.FromHtml(setting.css_BgColor);
            txt_FolderName.ForeColor = ColorTranslator.FromHtml(setting.css_ForeColor);
            txt_FolderName.Location = new Point((Width / 2) - 10, 33);
            txt_FolderName.BorderStyle = BorderStyle.None;

            btn_save.FlatStyle = FlatStyle.Flat;
            btn_save.BackColor = Color.Transparent;
            btn_save.ForeColor = ColorTranslator.FromHtml(setting.txt_ForeColor);
            btn_save.Size = new Size(150, 30);
            btn_save.Location = new Point((Width / 2) - (btn_save.Size.Width / 2), 220);
        }

        public SaveForm(DataColor setting, bool newHtml):this(setting)
        {
            label3.Visible = false;
            txt_FolderName.Visible = false;

            if (newHtml)
            {
                txt_htmlName.Location = new Point((Width / 2) - 10, 100);
                label1.Location = new Point(((Width / 2) / 2) - (label1.Size.Width / 2), 100);

                txt_cssName.Visible = false;
                label2.Visible = false;
                type = 1;
            }
            else
            {
                txt_cssName.Location = new Point((Width / 2) - 10, 100);
                label2.Location = new Point(((Width / 2) / 2) - (label2.Size.Width / 2), 100);

                txt_htmlName.Visible = false;
                label1.Visible = false;
                type = 2;
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            switch (type)
            {
                case 0:
                    if (txt_htmlName.Text == null || txt_cssName.Text == null || txt_FolderName.Text == null)
                    {
                        MessageBox.Show("Inserisci i nomi dei File HTML e CSS");
                        return;
                    }
                    break;

                case 1:
                    if (txt_htmlName.Text == null)
                    {
                        MessageBox.Show("Inserisci il nome del File");
                        return;
                    }
                    break;

                case 2:
                    if (txt_cssName.Text == null)
                    {
                        MessageBox.Show("Inserisci il nome del File");
                        return;
                    }
                    break;
            }

            EditorForm.names[0] = txt_htmlName.Text;
            EditorForm.names[1] = txt_cssName.Text;
            EditorForm.names[2] = txt_FolderName.Text;

            DialogResult = DialogResult.OK;
        }
    }
}
