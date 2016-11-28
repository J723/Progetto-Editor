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
    public struct DataColor
    {
        public string Bg_Color { get; set; }

        public string html_BgColor;
        public string html_ForeColor;

        public string css_BgColor;
        public string css_ForeColor;

        public string menu_ForeColor;

        public string txt_ForeColor;

        public DataColor(string Bg, string html_bg, string html_fore, string css_bg, string css_fore, string menu_fore, string txt_Color)
        {
            Bg_Color = Bg;

            html_BgColor = html_bg;
            html_ForeColor = html_fore;

            css_BgColor = css_bg;
            css_ForeColor = css_fore;

            menu_ForeColor = menu_fore;
            txt_ForeColor = txt_Color;
        }

        public void Update(string[] dataColor)
        {
            Bg_Color = dataColor[0];

            html_BgColor = dataColor[1];
            html_ForeColor = dataColor[2];

            css_BgColor = dataColor[3];
            css_ForeColor = dataColor[4];

            menu_ForeColor = dataColor[5];
            txt_ForeColor = dataColor[6];
        }

        public string[] Compact()
        {
            return new string[]
            {
                Bg_Color,
                html_BgColor,
                html_ForeColor,
                css_BgColor,
                css_ForeColor,
                menu_ForeColor,
                txt_ForeColor
            };
        }
    }

    public partial class EditorForm : Form
    {
        public static string[] names = new string[3];

        Color BGColorDark = System.Drawing.ColorTranslator.FromHtml("#171616");
        Color TxtBoxColorDark = System.Drawing.ColorTranslator.FromHtml("#272626");
        Color TextColorWhite = System.Drawing.ColorTranslator.FromHtml("#fff");

        Color BGColorLight = System.Drawing.ColorTranslator.FromHtml("#ececec");
        Color TxtBoxColorLight = System.Drawing.ColorTranslator.FromHtml("#fff");
        Color TextColorBlack = System.Drawing.ColorTranslator.FromHtml("#000");

        string defaultHTML_Content = @"<html>
    <head>
        <link rel=""stylesheet"" type=""text/css"" href="""">
        <title> Sample </title>  
    </head> 
    <body>
    </body>
</html>";
        string defaultCSS_Content = @"body {
}";

        public static DataColor setting;
        FileManager Source_Management;
        string[] filePaths = new string[2];
        string[] FilePaths
        {
            get { return filePaths; }
            set
            {
                if (value.Length > 1)
                {
                    //file solo html e css, gli altri vengono "nullati"
                    for (int i = 0; i < 2; i++)
                        if (FileManager.GetExtension(value[i]) != ".html" && FileManager.GetExtension(value[i]) != ".css")
                            value[i] = null;

                    //non modifica se il valore è nullo---> poi mette nella cella giusta
                    if (value[0] == null)
                    {
                        if (value[1] != null)
                        {
                            if (FileManager.GetExtension(value[1]) == ".css")
                                filePaths[1] = value[1];
                            else
                                filePaths[0] = value[1];
                        }
                    }
                    if (value[1] == null)
                    {
                        if (value[0] != null)
                        {
                            if (FileManager.GetExtension(value[0]) == ".html")
                                filePaths[0] = value[0];
                            else
                                filePaths[1] = value[0];
                        }
                    }

                    //sposta nel primo il file html e nel secondo il css
                    if (FileManager.GetExtension(value[1]) == ".html")
                    {
                        filePaths[0] = value[1];
                        filePaths[1] = value[0];
                    }
                    else
                        filePaths = value;
                }
                else
                {
                    if (FileManager.GetExtension(value[0]) == ".css")
                        filePaths[1] = value[0];
                    else
                        filePaths[0] = value[0];
                }
            }
        }

        public EditorForm()
        {
            InitializeComponent();
            FilePaths = new string[2];
            Source_Management = new FileManager(true);//inizializza il file di risorsa dentro la cartlla del programma
            LoadSetting();
        }

        public void LoadSetting()
        {
            //prova a cercare delle preimpostazioni, se le trova le carica nello struct altrimenti lo inizializza con il tema scuro
            string[] data = new string[0];

            if (Source_Management.Resource_TryToReadLines(out data) && data.Length == 9)
                setting = new DataColor(data[2], data[3], data[4], data[5], data[6], data[7], data[8]);
            else
                setting = new DataColor("#171616", "#272626", "#fff", "#272626", "#fff", "#fff", "#fff");
        }

        private void EditorIsVisible()
        {
            txt_html.Visible = true;
            txt_css.Visible = true;
            Wb_Preview.Visible = true;
            menuStrip.Visible = true;

            btn_new.Visible = false;
            btn_load.Visible = false;
            btn_continue.Visible = false;
        }

        #region Grafica

        private void EditorForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            this.BackColor = ColorTranslator.FromHtml(setting.Bg_Color); ;

            btn_new.FlatStyle = FlatStyle.Flat;
            btn_new.BackColor = Color.Transparent;
            btn_new.ForeColor = TextColorWhite;
            btn_new.Size = new Size(150, 30);
            btn_new.Location = new Point((Width / 2) - (btn_new.Size.Width / 2), (Height / 2) - 200);

            btn_load.FlatStyle = FlatStyle.Flat;
            btn_load.BackColor = Color.Transparent;
            btn_load.ForeColor = TextColorWhite;
            btn_load.Size = new Size(150, 30);
            btn_load.Location = new Point((Width / 2) - (btn_load.Size.Width / 2), Height / 2);

            btn_continue.FlatStyle = FlatStyle.Flat;
            btn_continue.BackColor = Color.Transparent;
            btn_continue.ForeColor = TextColorWhite;
            btn_continue.Size = new Size(150, 30);
            btn_continue.Location = new Point((Width / 2) - (btn_continue.Size.Width / 2), (Height / 2) + 200);

            txt_html.Visible = false;
            txt_css.Visible = false;
            Wb_Preview.Visible = false;
            menuStrip.Visible = false;
            //Pnl_Start.Dock = DockStyle.Fill;
            //Pnl_Start.Controls.Add(btn_new);
            //Pnl_Start.Controls.Add(btn_load);
            //Pnl_Start.Controls.Add(btn_continue);

            //Pnl_Edit.Visible = false;

            //Posizionamento, Stile, Dimensioni TextBox dell'HTML
            txt_html.Height = Height - 100;
            txt_html.Width = Width / 3 - 20;
            txt_html.BackColor = ColorTranslator.FromHtml(setting.html_BgColor);
            txt_html.ForeColor = ColorTranslator.FromHtml(setting.html_ForeColor); ;
            txt_html.BorderStyle = BorderStyle.None;
            txt_html.Font = new Font("Cambria", 16);
            txt_html.Location = new Point(30, 30);

            //Posizionamento, Stile, Dimensioni TextBox del CSS
            txt_css.Height = Height - 100;
            txt_css.Width = Width / 3 - 20;
            txt_css.BackColor = ColorTranslator.FromHtml(setting.css_BgColor); ;
            txt_css.ForeColor = ColorTranslator.FromHtml(setting.css_ForeColor); ;
            txt_css.BorderStyle = BorderStyle.None;
            txt_css.Font = new Font("Cambria", 16);
            txt_css.Location = new Point((Width / 3) + 15, 30);

            //Posizionamento e Dimensioni del visualizzatore WEB
            Wb_Preview.Height = Height - 100;
            Wb_Preview.Width = Width / 3 - 40;
            Wb_Preview.Location = new Point(((Width / 3) * 2), 30);

            //Personalizzazione del Menù
            menuStrip.BackColor = Color.Transparent;
            menuStrip.ForeColor = ColorTranslator.FromHtml(setting.menu_ForeColor);

            scuroToolStripMenuItem.ToolTipText = "Predefinito";

            //Pnl_Edit.Dock = DockStyle.Fill;
            //Pnl_Edit.Controls.Add(menuStrip);
            //Pnl_Edit.Controls.Add(txt_html);
            //Pnl_Edit.Controls.Add(txt_css);
            //Pnl_Edit.Controls.Add(Wb_Preview);
        }

        #endregion

        #region Menu

        private void chiaroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = BGColorLight;

            txt_html.BackColor = TxtBoxColorLight;
            txt_html.ForeColor = TextColorBlack;

            txt_css.BackColor = TxtBoxColorLight;
            txt_css.ForeColor = TextColorBlack;

            menuStrip.ForeColor = TextColorBlack;

            setting = new DataColor("#ececec", "#fff", "#000", "#fff", "#000", "#fff", "#000");
        }

        private void scuroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = BGColorDark;

            txt_html.BackColor = TxtBoxColorDark;
            txt_html.ForeColor = TextColorWhite;

            txt_css.BackColor = TxtBoxColorDark;
            txt_css.ForeColor = TextColorWhite;


            menuStrip.ForeColor = TextColorWhite;

            setting = new DataColor("#171616", "#272626", "#fff", "#272626", "#fff", "#fff", "#fff");
        }

        private void personalizzaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(new PeresonalizationForm(setting).ShowDialog() == DialogResult.OK)
                LoadSetting();
        }

        #endregion

        #region start_Menu        

        private void Btn_LoadProject_Click(object sender, EventArgs e)
        {
            if (!LoadProject())
                MessageBox.Show("C'è stato un errore nelcaricamento dei file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //nuovo
        private void Btn_NewProject_Click(object sender, EventArgs e)
        {
            if (!NewProject())
                MessageBox.Show("impossibile creare un nuovo progetto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //continua dal progetto precedente
        private void Btn_Continue_Click(object sender, EventArgs e)
        {
            if (!ContinueProject())
                MessageBox.Show("Progetto non trovato", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion

        #region STRIP MENU

        private void menu_File_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem  c = (ToolStripMenuItem)sender;

            if (c.Name == apriToolStripMenuItem.Name)
            {
                if (!LoadProject())
                    MessageBox.Show("C'è stato un errore nelcaricamento dei file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (c.Name == salvaToolStripMenuItem.Name)
            {
                SaveSettings();
                return;
            }

            if(c.Name == nuovoToolStripMenuItem.Name)
            {
                if (!NewProject())
                    MessageBox.Show("impossibile creare un nuovo progetto", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(c.Name == chiudiToolStripMenuItem.Name)
            {
                Close();
                return;// (?)
            }
        }

        private void creaCollegamentoCssToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] lines = new string[3];
            if (FileManager.TryToReadLines(FilePaths[0], out lines))
            {
                List<string> ss = new List<string>();
                foreach (string s in lines)
                {
                    ss.Add(s);
                    if (s.Contains("<html>"))
                        ss.Add(@"
<head> 
    <link rel=""stylesheet"" type=""text/css"" href=""" + FilePaths[1] + @""">
</head>
");
                }

                FileManager.TryToWrite(FilePaths[0], ss.ToArray(), false);
                Extract();
            }
        }

        #endregion

        #region Gestione File

        //Apre un progetto esistente
        bool LoadProject()
        {
            //apre il dialog e sceglie i/il file da caricare e ne carica gli indirizzi in FilePaths
            if (FileDialog())
            {
                //se il file scelto è uno--->fa scegliere il nome dell'altro file e lo crea nella stessa cartella
                if (FilePaths[0] == null)
                    if (MessageBox.Show("Creare un nuovo File HTML", "New HTML File", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (new SaveForm(setting, true).ShowDialog() == DialogResult.OK)
                        {
                            string path;
                            if (!FileManager.CreateNewFile(out path, System.IO.Path.GetDirectoryName(FilePaths[1]), names[0], ".html", defaultHTML_Content, true))
                                return false;

                            FilePaths[0] = path;

                            //caricamento della finestra
                            if (Extract())
                            {
                                //imposta il collegamento al file di css
                                PlaceLink();
                            }
                        }                        
                    }
                if (FilePaths[1] == null)
                    if (MessageBox.Show("Creare un nuovo File CSS", "New CSS File", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        if (new SaveForm(setting, false).ShowDialog() == DialogResult.OK)
                        {
                            string path;
                            if (!FileManager.CreateNewFile(out path, System.IO.Path.GetDirectoryName(FilePaths[0]), names[1], ".css", defaultCSS_Content, true))
                                return false;

                            FilePaths[1] = path;
                        }
                    }

                //caricamento della finestra se i file sono due
                if (Extract())
                    return true;
                return false;
            }
            return false;
        }

        //inizializza un nuovo progetto a livello di file
        bool NewProject()
        {
            //Apre il dialog e sceglie la cartella in cui inserirlo
            string dirPath;
            if (FileManager.Browse_Folder("Scegli la cartella in cui creare la cartella del progetto)", out dirPath))
            {
                if (new SaveForm(setting).ShowDialog() == DialogResult.OK)
                {
                    //creazione delle cartelle e dei file---> se non li crea tutti ritorna falso
                    string[] outPath = new string[2];
                    if (
                        !FileManager.CreateDirectory(dirPath, names[2], true) ||
                        !FileManager.CreateNewFile(out outPath[0], dirPath + @"\" + names[2], names[0], ".html", defaultHTML_Content, true) ||
                        !FileManager.CreateNewFile(out outPath[1], dirPath + @"\" + names[2], names[1], ".css", defaultCSS_Content, true)
                        )
                        return false;

                    //Caricamento degli indirizzi
                    FilePaths = outPath;

                    //caricamento della finestra
                    if (Extract())
                    {
                        //imposta il collegamento al file di css
                        PlaceLink();
                    }                    
                }
                return true;    //-------> se ritornasse false apparirebbe la messageBox di errore anche se la creazione è stata abrogata
            }
            return false;
        }

        //continua l'ultimo progetto
        bool ContinueProject()
        {
            //Legge il file di risorse e ne estra l'indirizzo dell'ultimo progetto (riga[0] file html riga[1] file css)
            string[] projectFile;
            if (Source_Management.Resource_TryToReadLines(out projectFile) && projectFile.Length > 1)
            {
                FilePaths[0] = projectFile[0];
                FilePaths[1] = projectFile[1];
            }
            else
                return false;

            //caricamento della finestra
            if (Extract())
                return true;
            return false;
        }

        bool Extract()
        {
            string[] fp = new string[2];
            string[] content = new string[2];

            if (FileManager.TryToRead(FilePaths[0], out content[0]) && FileManager.TryToRead(FilePaths[1], out content[1]))
            {
                txt_html.Text = content[0];
                txt_css.Text = content[1];
                EditorIsVisible();
                Text = "HTML_Preview Preview: - " + System.IO.Path.GetFileName(FilePaths[0]);
                return true;
            }
            return false;
        }

        bool FileDialog()
        {
            string[] fpath = new string[0];

            Dialog:
            if (FileManager.Browse_File("Scegli i file da caricare", out fpath, "Html & Css Files|*html; *css"))
            {
                if (fpath.Length > 2)
                {
                    MessageBox.Show("Scegliere al massimo due file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    goto Dialog;
                }

                else if (fpath.Length == 2 && FileManager.GetExtension(fpath[0]) == FileManager.GetExtension(fpath[1]))
                {
                    MessageBox.Show("Scegliere due file differenti", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    goto Dialog;
                }

                FilePaths = fpath;
                return true;
            }
            return false;
        }

        bool SaveSettings()
        {
            //monta la lista dei dati necessari
            List<string> dataSource = new List<string>();

            dataSource.Add(FilePaths[0]);   //file HTML
            dataSource.Add(FilePaths[1]);   //file CSS

            //codice colori
            foreach (string d in setting.Compact())
                dataSource.Add(d);

            //fa l'update con il file di risorse
            if (Source_Management.Resource_Update(dataSource.ToArray()))
                return true;
            else
                return false;
        }

        //salva le preferenze sul file
        private void EditorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (btn_new.Visible == false)
            {
                if (MessageBox.Show("Sei sicuro di voler chiudere?\nLa prossima volta ricomincerai da qui!", "Closing", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    if (!SaveSettings())
                        MessageBox.Show("Impossibile Salvare i dati", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    e.Cancel = true;
            }
        }
        #endregion

        #region Gestione Textbox

        private void txt_Zone_FileUpdate(object sender, EventArgs e)
        {
            Control t = (Control)sender;

            if (t.Name == txt_html.Name)
            {
                if (!FileManager.TryToWrite(FilePaths[0], txt_html.Text, false))
                {
                    MessageBox.Show("Errore nel tentativo di scrittura sul file HTML", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                if (!FileManager.TryToWrite(FilePaths[1], txt_css.Text, false))
                {
                    MessageBox.Show("Errore nel tentativo di scrittura sul file CSS", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            Wb_Preview.Navigate(FilePaths[0]);
        }

        bool PlaceLink()
        {
            string[] tag = new string[2] { @"href=""", @"""" };
            //ottiene la posizione iniziale del link
            int[] limit = new int[2];
            for (limit[0] = 0; limit[0] < this.txt_html.Text.Length - tag[0].Length; limit[0]++)
                if (txt_html.Text.Substring(limit[0], tag[0].Length) == tag[0])
                    break;
            //ottiene la posizione finale
            for (limit[1] = limit[0]; limit[1] < txt_html.Text.Length - tag[1].Length; limit[1]++)
                if (txt_html.Text.Substring(limit[1], tag[1].Length) == tag[1])
                    break;

            if (limit != null)
            {
                string s = this.txt_html.Text;
                this.txt_html.Text = s.Substring(0, limit[0] + tag[0].Length) + FilePaths[1] + s.Substring(limit[1] + 1);
            }

            return false;
        }

        #endregion
        
    }
}
