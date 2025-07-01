namespace PokemonRomEditor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnOpenRom = new Button();
            lblFile = new Label();
            ofdOpenRom = new OpenFileDialog();
            SuspendLayout();
            // 
            // btnOpenRom
            // 
            btnOpenRom.Location = new Point(0, 0);
            btnOpenRom.Name = "btnOpenRom";
            btnOpenRom.Size = new Size(75, 23);
            btnOpenRom.TabIndex = 0;
            btnOpenRom.Text = "Abrir ROM";
            btnOpenRom.UseVisualStyleBackColor = true;
            btnOpenRom.Click += button1_Click;
            // 
            // lblFile
            // 
            lblFile.AutoSize = true;
            lblFile.Location = new Point(271, 140);
            lblFile.Name = "lblFile";
            lblFile.Size = new Size(163, 15);
            lblFile.TabIndex = 1;
            lblFile.Text = "Nenhum arquivo selecionado";
            lblFile.Click += lblFile_Click;
            // 
            // ofdOpenRom
            // 
            ofdOpenRom.FileName = "ofdOpenRom";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblFile);
            Controls.Add(btnOpenRom);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOpenRom;
        private Label lblFile;
        private OpenFileDialog ofdOpenRom;
    }
}
