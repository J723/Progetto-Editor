namespace HTML_Preview
{
    partial class PeresonalizationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_dialog = new System.Windows.Forms.Button();
            this.btn_editor = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_character = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Colore Finestra";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Colore Editor";
            // 
            // btn_dialog
            // 
            this.btn_dialog.Location = new System.Drawing.Point(161, 53);
            this.btn_dialog.Name = "btn_dialog";
            this.btn_dialog.Size = new System.Drawing.Size(75, 23);
            this.btn_dialog.TabIndex = 1;
            this.btn_dialog.Text = "Scegli";
            this.btn_dialog.UseVisualStyleBackColor = true;
            this.btn_dialog.Click += new System.EventHandler(this.ColorBtn_Click);
            // 
            // btn_editor
            // 
            this.btn_editor.Location = new System.Drawing.Point(161, 107);
            this.btn_editor.Name = "btn_editor";
            this.btn_editor.Size = new System.Drawing.Size(75, 23);
            this.btn_editor.TabIndex = 3;
            this.btn_editor.Text = "Scegli";
            this.btn_editor.UseVisualStyleBackColor = true;
            this.btn_editor.Click += new System.EventHandler(this.ColorBtn_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(106, 212);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 6;
            this.btn_save.Text = "Salva";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_character
            // 
            this.btn_character.Location = new System.Drawing.Point(161, 156);
            this.btn_character.Name = "btn_character";
            this.btn_character.Size = new System.Drawing.Size(75, 23);
            this.btn_character.TabIndex = 5;
            this.btn_character.Text = "Scegli";
            this.btn_character.UseVisualStyleBackColor = true;
            this.btn_character.Click += new System.EventHandler(this.ColorBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Colore Carattere";
            // 
            // PeresonalizationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_character);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_editor);
            this.Controls.Add(this.btn_dialog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "PeresonalizationForm";
            this.Text = "PeresonalizationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_dialog;
        private System.Windows.Forms.Button btn_editor;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_character;
        private System.Windows.Forms.Label label3;
    }
}