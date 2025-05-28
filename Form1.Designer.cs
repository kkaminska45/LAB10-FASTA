namespace LAB10_FASTA
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
            btnWczytajPlik = new Button();
            btnWalidacjaDanych = new Button();
            brnListaSekwencji = new Button();
            SuspendLayout();
            // 
            // btnWczytajPlik
            // 
            btnWczytajPlik.Location = new Point(35, 19);
            btnWczytajPlik.Name = "btnWczytajPlik";
            btnWczytajPlik.Size = new Size(150, 34);
            btnWczytajPlik.TabIndex = 0;
            btnWczytajPlik.Text = "Wczytaj plik";
            btnWczytajPlik.UseVisualStyleBackColor = true;
            btnWczytajPlik.Click += btnWczytajPlik_Click;
            // 
            // btnWalidacjaDanych
            // 
            btnWalidacjaDanych.Location = new Point(35, 73);
            btnWalidacjaDanych.Name = "btnWalidacjaDanych";
            btnWalidacjaDanych.Size = new Size(150, 34);
            btnWalidacjaDanych.TabIndex = 1;
            btnWalidacjaDanych.Text = "Walidacja danych";
            btnWalidacjaDanych.UseVisualStyleBackColor = true;
            btnWalidacjaDanych.Click += btnWalidacjaDanych_Click;
            // 
            // brnListaSekwencji
            // 
            brnListaSekwencji.Location = new Point(35, 127);
            brnListaSekwencji.Name = "brnListaSekwencji";
            brnListaSekwencji.Size = new Size(150, 34);
            brnListaSekwencji.TabIndex = 2;
            brnListaSekwencji.Text = "Lista sekwencji";
            brnListaSekwencji.UseVisualStyleBackColor = true;
            brnListaSekwencji.Click += brnListaSekwencji_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(218, 183);
            Controls.Add(brnListaSekwencji);
            Controls.Add(btnWalidacjaDanych);
            Controls.Add(btnWczytajPlik);
            Name = "Form1";
            Text = "FASTA";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button btnWczytajPlik;
        private Button btnWalidacjaDanych;
        private Button brnListaSekwencji;
    }
}
