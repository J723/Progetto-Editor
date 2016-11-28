using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTML_Preview
{
    public partial class PeresonalizationForm : Form
    {
        Color[] colors = new Color[3];

        DataColor set;
        ColorDialog cd;

        string[] convertedColors = new string[3];

        public PeresonalizationForm(DataColor setting)
        {
            InitializeComponent();

            this.BackColor = ColorTranslator.FromHtml(setting.Bg_Color);

            label1.ForeColor = ColorTranslator.FromHtml(setting.txt_ForeColor);
            label1.Location = new Point(((Width / 2) / 2) - (label1.Size.Width / 2), 50);

            label2.ForeColor = ColorTranslator.FromHtml(setting.txt_ForeColor);
            label2.Location = new Point(((Width / 2) / 2) - (label2.Size.Width / 2), 100);

            label3.ForeColor = ColorTranslator.FromHtml(setting.txt_ForeColor);
            label3.Location = new Point(((Width / 2) / 2) - (label3.Size.Width / 2), 150);

            btn_dialog.FlatStyle = FlatStyle.Flat;
            btn_dialog.BackColor = Color.Transparent;
            btn_dialog.ForeColor = ColorTranslator.FromHtml(setting.txt_ForeColor);
            btn_dialog.Size = new Size(75, 30);
            btn_dialog.Location = new Point((Width / 2) - 10, 45);

            btn_editor.FlatStyle = FlatStyle.Flat;
            btn_editor.BackColor = Color.Transparent;
            btn_editor.ForeColor = ColorTranslator.FromHtml(setting.txt_ForeColor);
            btn_editor.Size = new Size(75, 30);
            btn_editor.Location = new Point((Width / 2) - 10, 95);

            btn_character.FlatStyle = FlatStyle.Flat;
            btn_character.BackColor = Color.Transparent;
            btn_character.ForeColor = ColorTranslator.FromHtml(setting.txt_ForeColor);
            btn_character.Size = new Size(75, 30);
            btn_character.Location = new Point((Width / 2) - 10, 145);

            btn_save.FlatStyle = FlatStyle.Flat;
            btn_save.BackColor = Color.Transparent;
            btn_save.ForeColor = ColorTranslator.FromHtml(setting.txt_ForeColor);
            btn_save.Size = new Size(150, 30);
            btn_save.Location = new Point((Width / 2) - (btn_save.Size.Width / 2), 220);

            set = setting;
        }

        private void ColorBtn_Click(object sender, EventArgs e)
        {
            cd = new ColorDialog();

            if(cd.ShowDialog() == DialogResult.OK)
            {
                Button b = (Button)sender;
                switch(b.Name)
                {
                    case "btn_dialog":
                        set.Bg_Color = ColorTranslator.ToHtml(cd.Color);
                        break;

                    case "btn_editor":
                        set.css_BgColor = ColorTranslator.ToHtml(cd.Color);
                        set.html_BgColor = ColorTranslator.ToHtml(cd.Color);
                        break;

                    case "btn_character":
                        set.css_ForeColor = ColorTranslator.ToHtml(cd.Color);
                        set.html_ForeColor = ColorTranslator.ToHtml(cd.Color);
                        set.txt_ForeColor = ColorTranslator.ToHtml(cd.Color);
                        break;
                }
            }               
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            EditorForm.setting = set;
            DialogResult = DialogResult.OK;
        }
    }
}
