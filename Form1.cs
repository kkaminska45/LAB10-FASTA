namespace LAB10_FASTA
{
    public partial class Form1 : Form
    {
        private List<FastaSequence> loadedSequences = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public class FastaSequence
        {
            public string Id { get; set; }
            public string Description { get; set; }
            public string Sequence { get; set; }

            public int Length => Sequence.Length;
        }
        private List<FastaSequence> ParseFasta(string[] lines)
        {
            var sequences = new List<FastaSequence>();
            FastaSequence current = null;

            foreach (string line in lines)
            {
                if (line.StartsWith(">"))
                {
                    if (current != null)
                        sequences.Add(current);

                    string header = line.Substring(1).Trim();
                    string[] parts = header.Split(' ', 2);
                    current = new FastaSequence
                    {
                        Id = parts[0],
                        Description = parts.Length > 1 ? parts[1] : "",
                        Sequence = ""
                    };
                }
                else if (current != null)
                {
                    current.Sequence += line.Trim().ToUpper();
                }
            }

            if (current != null)
                sequences.Add(current);

            return sequences;
        }


        private void btnWczytajPlik_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Pliki FASTA (*.fasta;*.fa)|*.fasta;*.fa|Wszystkie pliki (*.*)|*.*",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string[] lines = File.ReadAllLines(openFileDialog.FileName);
                    loadedSequences = ParseFasta(lines);

                    MessageBox.Show($"Wczytano {loadedSequences.Count} sekwencji.", "Sukces", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"B³¹d podczas wczytywania pliku: {ex.Message}", "B³¹d", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public class FastaValidator
        {
            private static readonly HashSet<char> AllowedBases = new() { 'A', 'T', 'G', 'C', 'N' };

            public List<string> Validate(List<Form1.FastaSequence> sequences)
            {
                var errors = new List<string>();

                if (sequences == null || sequences.Count == 0)
                {
                    errors.Add("Brak sekwencji do walidacji.");
                    return errors;
                }

                var seenIds = new HashSet<string>();

                for (int i = 0; i < sequences.Count; i++)
                {
                    var seq = sequences[i];
                    string context = $"Rekord {i + 1} ({seq.Id}): ";

                    if (string.IsNullOrWhiteSpace(seq.Id))
                        errors.Add(context + "Brak identyfikatora.");

                    if (!seenIds.Add(seq.Id))
                        errors.Add(context + "Zduplikowany identyfikator.");

                    if (string.IsNullOrWhiteSpace(seq.Sequence))
                        errors.Add(context + "Brak sekwencji.");

                    if (!string.IsNullOrWhiteSpace(seq.Sequence))
                    {
                        var invalidChars = seq.Sequence.ToUpper().Where(c => !AllowedBases.Contains(c)).Distinct().ToList();
                        if (invalidChars.Any())
                            errors.Add(context + $"Nieprawid³owe znaki w sekwencji: {string.Join(", ", invalidChars)}");
                    }
                }

                return errors;
            }
        }

        private void btnWalidacjaDanych_Click(object sender, EventArgs e)
        {
            var validator = new FastaValidator();
            List<string> errors = validator.Validate(loadedSequences);

            if (errors.Count == 0)
            {
                MessageBox.Show("Plik FASTA jest poprawny!", "Walidacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                string errorMessage = string.Join(Environment.NewLine, errors);
                MessageBox.Show("B³êdy walidacji:\n" + errorMessage, "Walidacja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void brnListaSekwencji_Click(object sender, EventArgs e)
        {
            if (loadedSequences.Count == 0)
            {
                MessageBox.Show("Najpierw wczytaj i zweryfikuj dane FASTA!", "Brak danych", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Form2 listaForm = new Form2(loadedSequences);
            listaForm.Show();
        }
    }
}
