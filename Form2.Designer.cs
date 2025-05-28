using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;

namespace LAB10_FASTA

{
    partial class Form2
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
            dataGridView1 = new DataGridView();
            richTextBox1 = new RichTextBox();
            label1 = new Label();
            btnSzczegoly = new Button();
            btnWykres = new Button();
            btnCSV = new Button();
            btnJSON = new Button();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(339, 251);
            dataGridView1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(418, 29);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(239, 188);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 238);
            label1.Location = new Point(366, 127);
            label1.Name = "label1";
            label1.Size = new Size(46, 25);
            label1.TabIndex = 2;
            label1.Text = "--->";
            // 
            // btnSzczegoly
            // 
            btnSzczegoly.Location = new Point(427, 223);
            btnSzczegoly.Name = "btnSzczegoly";
            btnSzczegoly.Size = new Size(221, 29);
            btnSzczegoly.TabIndex = 3;
            btnSzczegoly.Text = "Wyświetl szczegółowe dane";
            btnSzczegoly.UseVisualStyleBackColor = true;
            btnSzczegoly.Click += btnSzczegoly_Click;
            // 
            // btnWykres
            // 
            btnWykres.Location = new Point(455, 371);
            btnWykres.Name = "btnWykres";
            btnWykres.Size = new Size(214, 44);
            btnWykres.TabIndex = 4;
            btnWykres.Text = "Wykres długości sekwencji";
            btnWykres.UseVisualStyleBackColor = true;
            btnWykres.Click += btnWykres_Click;
            // 
            // btnCSV
            // 
            btnCSV.Location = new Point(455, 580);
            btnCSV.Name = "btnCSV";
            btnCSV.Size = new Size(214, 44);
            btnCSV.TabIndex = 5;
            btnCSV.Text = "Zapis do pliku .csv";
            btnCSV.UseVisualStyleBackColor = true;
            btnCSV.Click += btnCSV_Click;
            // 
            // btnJSON
            // 
            btnJSON.Location = new Point(455, 530);
            btnJSON.Name = "btnJSON";
            btnJSON.Size = new Size(214, 44);
            btnJSON.TabIndex = 6;
            btnJSON.Text = "Zapis do pliku .json";
            btnJSON.UseVisualStyleBackColor = true;
            btnJSON.Click += btnJSON_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(12, 315);
            panel1.Name = "panel1";
            panel1.Size = new Size(422, 327);
            panel1.TabIndex = 7;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(681, 663);
            Controls.Add(panel1);
            Controls.Add(btnJSON);
            Controls.Add(btnCSV);
            Controls.Add(btnWykres);
            Controls.Add(btnSzczegoly);
            Controls.Add(label1);
            Controls.Add(richTextBox1);
            Controls.Add(dataGridView1);
            Name = "Form2";
            Text = "Sekwencje";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private RichTextBox richTextBox1;
        private Label label1;
        private Button btnSzczegoly;
        private Button btnWykres;
        private Button btnCSV;
        private Button btnJSON;
        private Panel panel1;
    }
}