using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;


namespace LAB10_FASTA
{
    public partial class Form2 : Form
    {
        private List<Form1.FastaSequence> sequences;
        private CartesianChart cartesianChart;

        private class SequenceDisplayItem
        {
            public string Id { get; set; }
            public string Description { get; set; }
            public int Length { get; set; }
        }
        public Form2(List<Form1.FastaSequence> sequences)
        {
            InitializeComponent();
            this.sequences = sequences;

            cartesianChart = new CartesianChart
            {
                Dock = DockStyle.Fill
            };

            panel1.Controls.Add(cartesianChart);

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = new BindingSource { DataSource = ConvertToDisplayList(sequences) };
        }
        private List<SequenceDisplayItem> ConvertToDisplayList(List<Form1.FastaSequence> sequences)
        {
            var list = new List<SequenceDisplayItem>();
            foreach (var seq in sequences)
            {
                list.Add(new SequenceDisplayItem
                {
                    Id = seq.Id,
                    Description = seq.Description,
                    Length = seq.Length
                });
            }
            return list;
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private string GenerateDetails(Form1.FastaSequence seq)
        {
            string sequence = seq.Sequence;
            int length = sequence.Length;

            int countA = sequence.Count(c => c == 'A');
            int countT = sequence.Count(c => c == 'T');
            int countG = sequence.Count(c => c == 'G');
            int countC = sequence.Count(c => c == 'C');

            double gcContent = length > 0 ? ((double)(countG + countC) / length) * 100 : 0;
            int codonCount = length / 3;

            return
                $"Szczegółowe dane o sekwencji {seq.Id}:\n" +
                $"- Zawartość GC: {gcContent:F2}%\n" +
                $"- Liczba kodonów: {codonCount}\n" +
                $"- Liczba A: {countA}\n" +
                $"- Liczba T: {countT}\n" +
                $"- Liczba G: {countG}\n" +
                $"- Liczba C: {countC}";
        }

        private void btnSzczegoly_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Wybierz sekwencję z listy!", "Brak wyboru", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string selectedId = dataGridView1.CurrentRow.Cells["Id"].Value.ToString();
            var selectedSeq = sequences.Find(seq => seq.Id == selectedId);

            if (selectedSeq != null)
            {
                string details = GenerateDetails(selectedSeq);
                richTextBox1.Text = details;
            }
        }

        private void btnWykres_Click(object sender, EventArgs e)
        {
            var labels = sequences.Select(s => s.Id).ToArray();
            var lengths = sequences.Select(s => (double)s.Length).ToArray();

            cartesianChart.Series = new ISeries[]
            {
                new ColumnSeries<double>
                {
                    Values = lengths,
                    Name = "Długość sekwencji"
                }
            };

            cartesianChart.XAxes = new Axis[]
            {
                new Axis
                {
                    Labels = labels,
                    LabelsRotation = 15
                }
            };

            cartesianChart.YAxes = new Axis[]
            {
                new Axis
                {
                    Name = "Długość",
                    MinLimit = 0
                }
            };
        }
        private class SequenceAnalysisResult
        {
            public string Id { get; set; }
            public string Description { get; set; }
            public int Length { get; set; }
            public double GCContent { get; set; }
            public int CodonCount { get; set; }
            public int CountA { get; set; }
            public int CountT { get; set; }
            public int CountG { get; set; }
            public int CountC { get; set; }
        }
        private List<SequenceAnalysisResult> GetAnalysisResults()
        {
            var results = new List<SequenceAnalysisResult>();

            foreach (var seq in sequences)
            {
                string sequence = seq.Sequence;
                int length = sequence.Length;
                int countA = sequence.Count(c => c == 'A');
                int countT = sequence.Count(c => c == 'T');
                int countG = sequence.Count(c => c == 'G');
                int countC = sequence.Count(c => c == 'C');
                double gcContent = length > 0 ? ((double)(countG + countC) / length) * 100 : 0;
                int codonCount = length / 3;

                results.Add(new SequenceAnalysisResult
                {
                    Id = seq.Id,
                    Description = seq.Description,
                    Length = length,
                    GCContent = gcContent,
                    CodonCount = codonCount,
                    CountA = countA,
                    CountT = countT,
                    CountG = countG,
                    CountC = countC
                });
            }

            return results;
        }


        private void btnCSV_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "CSV files (*.csv)|*.csv";
                sfd.Title = "Zapisz wyniki analizy jako CSV";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var sb = new StringBuilder();
                    sb.AppendLine("Id,Description,Length,GCContent(%),CodonCount,CountA,CountT,CountG,CountC");

                    var results = GetAnalysisResults();
                    foreach (var res in results)
                    {
                        sb.AppendLine($"{res.Id},{res.Description},{res.Length},{res.GCContent:F2},{res.CodonCount},{res.CountA},{res.CountT},{res.CountG},{res.CountC}");
                    }

                    File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Wyniki analizy zapisane do pliku CSV.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnJSON_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "JSON files (*.json)|*.json";
                sfd.Title = "Zapisz wyniki analizy jako JSON";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var results = GetAnalysisResults();
                    var json = JsonSerializer.Serialize(results, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(sfd.FileName, json, Encoding.UTF8);
                    MessageBox.Show("Wyniki analizy zapisane do pliku JSON.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
