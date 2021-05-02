using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TuringMachineExecuter.Structures;

namespace TuringMachineExecuter
{
    public partial class menuForm : Form
    {
        TuringMachine TuringMachine;

        public menuForm()
        {
            InitializeComponent();
        }

        private void btnLoadFile_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog()
            {
                Filter = "Text files (*.txt)|*.txt",
                Title = "MT a ejecutar"
            };

            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filepath = openFileDialog.FileName;
                    var fileName = Path.GetFileName(filepath);
                    DialogResult dialogResult = MessageBox.Show($"¿Quiere continuar y colocar {fileName} como la MT a ejecutar?", "Confirmar MT", MessageBoxButtons.YesNo);
                    //if (dialogResult == DialogResult.Yes)
                   // {
                        enableButtons(true);
                        var onlyFileName = Path.GetFileName(filepath);
                        var fileStream = openFileDialog.OpenFile();
                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            var line = reader.ReadLine(); //Qty of States
                            var initialState = reader.ReadLine(); //initialState
                            var alphabet = reader.ReadLine(); //alphabet
                            TuringMachine = new TuringMachine(Convert.ToInt32(line), initialState, alphabet);
                            var transitionResult = string.Empty;
                            while ((line = reader.ReadLine()) != null) //Transitions
                            {
                                transitionResult = TuringMachine.AddTransition(line);
                                if (transitionResult != "Transición creada correctamente")
                                {
                                    MessageBox.Show(transitionResult);
                                    TuringMachine.Usable = false;
                                    break;
                                }
                            }
                            if (TuringMachine.States.Count != TuringMachine.NoOfStates)
                            {
                                MessageBox.Show("Entrada inválida, tiene menos estados de los indicados");
                                TuringMachine.Usable = false;
                                return;
                            }
                            if (TuringMachine.CheckInitialState())
                            {
                                lblCurrentNode.Text = TuringMachine.InitialState;
                                txtFile.Text = fileName;
                            }
                            else
                            {
                                MessageBox.Show("Entrada inválida, el estado inicial no pertenece al conjunto de estados ingresados");
                                TuringMachine.Usable = false;
                            }
                        }
                    //}
                    //else
                    //{
                        return;
                    //}
                }
            }
            catch
            {
                MessageBox.Show("El formato del archivo de entrada es incorrecto, \npor favor inténtelo nuevamente.");
            }
        }

        private void btnLoadTape_Click(object sender, EventArgs e) {
            if (CheckTape(txtInitTape.Text)) {
                tape.Items.Clear();
                foreach (var value in txtInitTape.Text) {
                    tape.Items.Add(value);
                }
            } else {
                MessageBox.Show("Entrada inválida, intente nuevamente, por favor");
            }

        }

        private bool CheckTape(string newTape) {
            foreach (var character in newTape) {
                if (!TuringMachine.Alphabet.Contains(character)) {
                    return false;
                }
            }
            return true;
        }

        private void dgvTape_CellContentClick(object sender, DataGridViewCellEventArgs e) {

        }

        private void menuForm_Load(object sender, EventArgs e) {
            enableButtons(false);
            txtFile.Enabled = false;
            
        }


        public void enableButtons(bool state) {
            btnAutomatic.Enabled = state;
            btnLoadTape.Enabled = state;
            btnNextStep.Enabled = state;
            btnStop.Enabled = state;
        }

        private void checkedTape_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkedTape_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void tape_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
