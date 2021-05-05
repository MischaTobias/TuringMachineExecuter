using System;
using System.IO;
using System.Windows.Forms;
using TuringMachineExecuter.Structures;
using System.Collections.Generic;
using System.Linq;

namespace TuringMachineExecuter
{
    public partial class menuForm : Form {
        TuringMachine TuringMachine;
        Tape TapeStep;

        public menuForm()
        {
            InitializeComponent();
            TuringMachine = new TuringMachine();
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
                if (openFileDialog.ShowDialog() == DialogResult.OK) {
                    
                    var filepath = openFileDialog.FileName;
                    var fileName = Path.GetFileName(filepath);
                    if (openFileDialog.OpenFile().Length != 0) {
                        DialogResult dialogResult = MessageBox.Show($"¿Seguro que desea utilizar {fileName} como la máquina de turing a interpretar?", "Confirmar máquina de turing", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            EnableButtons(true);
                            var onlyFileName = Path.GetFileName(filepath);
                            GenerateTuringMachineFromFile(openFileDialog.OpenFile(), fileName);
                        }
                    } else {
                        MessageBox.Show("ERROR: el archivo se encuentra vacío, intenta nuevamente con uno distinto.");
                    }
                }
            }
            catch
            {
                MessageBox.Show("ERROR: el formato del archivo de entrada es incorrecto, inténtalo nuevamente.");
                EnableButtons(false);
                TuringMachine.SetUse(false);
            }
        }

        private void GenerateTuringMachineFromFile(Stream fileStream, string fileName)
        {
            using (StreamReader reader = new(fileStream))
            {
                var line = reader.ReadLine(); //Qty of States
                var initialState = reader.ReadLine(); //initialState
                var alphabet = reader.ReadLine(); //alphabet
                TuringMachine = new TuringMachine(Convert.ToInt32(line), initialState, alphabet);
                var transitionResult = string.Empty;
                Dictionary<string, string> StateTransitions = new Dictionary<string, string>();
                while ((line = reader.ReadLine()) != null) //Transitions
                {
                    transitionResult = TuringMachine.AddTransition(line);
                    string[] auxtrasition = line.Split(',');
                    string key = auxtrasition[0] + auxtrasition[1];
                    if (!StateTransitions.TryAdd(key, transitionResult))
                    {
                        MessageBox.Show("ERROR: un estado tiene más de una transición con el mismo símbolo.");
                        EnableButtons(false);
                        TuringMachine.SetUse(false);
                        return;
                    }
                    if (transitionResult != "Transición creada correctamente")
                    {
                        MessageBox.Show(transitionResult);
                        EnableButtons(false);
                        TuringMachine.SetUse(false);
                        return;
                    }
                }
                if (!TuringMachine.StatesValidness())
                {
                    MessageBox.Show("ERROR: la máquina cuenta con menos estados de los descritos.");
                    EnableButtons(false);
                    TuringMachine.SetUse(false);
                    return;
                }
                if (TuringMachine.CheckInitialState())
                {
                    lblCurrentNode.Text = TuringMachine.GetInitialState();
                    txtFile.Text = fileName;
                    EnableButtons(false);
                    btnLoadTape.Enabled = true;
                }
                else
                {
                    MessageBox.Show("ERROR: el estado inicial no pertenece al conjunto de estados ingresados en la definición de la máquina.");
                    EnableButtons(false);
                    TuringMachine.SetUse(false);
                }
            }
        }

        private void btnLoadTape_Click(object sender, EventArgs e) {
            if (TuringMachine.IsUsable())
            {
                TapeStep = new Tape();
                if (CheckTape(txtInitTape.Text))
                {
                    var word = "_" + txtInitTape.Text + "_";
                    foreach (var value in word)
                    {
                        TapeStep.WordTape.Add(Convert.ToString(value));
                    }
                    PrintTape(TapeStep.WordTape);
                    TapeStep.CurrentPosition = 0;
                    TuringMachine.SetCurrentNode(TuringMachine.GetInitialNode());
                    EnableButtons(true);
                    btnLoadTape.Enabled = false;
                }
                else
                {
                    MessageBox.Show("ERROR: entrada inválida, intentelo nuevamente.");
                    txtInitTape.Text = "";
                }
            }
            else
            {
                MessageBox.Show("ERROR: el formato del archivo de entrada es incorrecto, por favor inténtelo nuevamente.");
            }
        }

        private bool CheckTape(string newTape)
        {
            if (newTape.Equals(""))
            {
                return false;
            }
            foreach (var character in newTape)
            {
                if (!TuringMachine.CharacterInAlphabet(character))
                {
                    return false;
                }
            }
            return true;
        }

        private void menuForm_Load(object sender, EventArgs e) {
            EnableButtons(false);
            txtFile.Enabled = false;
            btnAutomatic.Enabled = false;
            lblEjecution.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
        }


        public void EnableButtons(bool state) {
            btnAutomatic.Enabled = state;
            btnLoadTape.Enabled = state;
            btnNextStep.Enabled = state;
            btnStop.Enabled = state;
        }

        private void btnNextStep_Click(object sender, EventArgs e)
        {
            btnStop.Enabled = false;
            if (TapeStep == null)
            {
                MessageBox.Show("ERROR: ocurrió un inconveniente en el proceso de ejecución, inténtalo nuevamente");
                return;
            }
            MachineStep();
        }

        public void MachineStep()
        {
            bool acepted = false;
            var letter = TapeStep.WordTape[TapeStep.CurrentPosition];
            Node auxNode = TuringMachine.GetCurrentNode();
            var transition = auxNode.GetTransitions().First(x => x.ReadingCharacter == letter);
            TapeStep.WordTape[TapeStep.CurrentPosition] = transition.WritingCharacter;
            MoveTape(transition, letter);
            PrintTape(TapeStep.WordTape);
            TuringMachine.SetCurrentNode(TuringMachine.GetStates().Find(x => x.GetState() == transition.NextState));
            lblCurrentNode.Text = TuringMachine.GetCurrentNode().GetState();
            lblLastMovement.Text = transition.PrintTransition();
            acepted = true;
            if (TapeStep.Repetitions0 == 10 || TapeStep.RepetitionsD == 10)
            {
                EnableButtons(false);
                tmrAutomatic.Enabled = false;
                DialogResult dialogResult = MessageBox.Show($"La entrada ha sido rechazada, \n ¿desea intentar nuevamente con otra cadena en la cinta?", "¡No hay solución!", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    EnableButtons(true);
                    txtInitTape.Text = "";
                    tape.Items.Clear();
                    return;
                }
                Application.Exit();
            }

            if (!acepted)
            {
                EnableButtons(false);
                lblCurrentNode.Text = TuringMachine.GetCurrentNode().GetState();
                lblLastMovement.Text = "ERROR: transición inválida";
                MessageBox.Show("ERROR: No hay trasición definida");
                tmrAutomatic.Enabled = false;
            }
        }

        private void MoveTape(Transition transition, string letter)
        {
            if (transition.HeadMovement == "d" || transition.HeadMovement == "D")
            {
                TapeStep.CurrentPosition++;
                TapeStep.Repetitions0 = 0;
                if (letter != "_")
                {
                    TapeStep.RepetitionsD = 0;
                }
                else
                {
                    TapeStep.RepetitionsD++;
                    if (TapeStep.CurrentPosition == TapeStep.WordTape.Count)
                        TapeStep.WordTape.Add("_");
                }
                return;
            }

            if (transition.HeadMovement == "i" || transition.HeadMovement == "I")
            {
                TapeStep.CurrentPosition--;
                TapeStep.Repetitions0 = 0;
                TapeStep.RepetitionsD = 0;
                if (TapeStep.CurrentPosition < 0)
                {
                    MessageBox.Show("ERROR: máquina inválida, la cinta no es infinita hacia la izquierda.");
                    EnableButtons(false);
                }
                return;
            }

            if (transition.HeadMovement == "0")
            {
                TapeStep.Repetitions0++;
                TapeStep.RepetitionsD = 0;
                return;
            }

            if (transition.HeadMovement == "p" || transition.HeadMovement == "P")
            {
                TapeStep.Repetitions0 = 0;
                TapeStep.RepetitionsD = 0;
                if (Format())
                {
                    tmrAutomatic.Enabled = false;
                    MessageBox.Show("¡La ejecución ha culminado satisfactoriamente!");
                    Application.Restart();
                    Environment.Exit(0);
                }
                else
                {
                    tmrAutomatic.Enabled = false;
                    MessageBox.Show("ERROR: La máquina de turing cuenta con un formato de salida incorrecto");
                }
                EnableButtons(false);
            }
        }

        public bool Format() {
            string word = "";
            foreach (var item in TapeStep.WordTape)
                word += item;
            string[] array = word.Split('_');
            if (array[0].Length == 0 && array[2].Length == 0 && TapeStep.WordTape[TapeStep.CurrentPosition] == "_")
            {
                return true;
            }
            return false;
        }

        public void PrintTape (List<string> word)
        {
            tape.Items.Clear();
            foreach (var value in word)
            {
                tape.Items.Add(value);
            }
            tape.SetItemChecked(TapeStep.CurrentPosition,true);
        }

        private void btnStop_Click(object sender, EventArgs e) {
            tmrAutomatic.Enabled = false;
            btnAutomatic.Enabled = true;
            btnNextStep.Enabled = true;
            lblEjecution.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
        }

        private void tmrAutomatic_Tick(object sender, EventArgs e) {
            MachineStep();
            btnAutomatic.Enabled = false;
            btnNextStep.Enabled = false;
        }

        private void btnAutomatic_Click(object sender, EventArgs e){
            tmrAutomatic.Enabled = true;
            lblEjecution.Visible = true;
            btnStop.Enabled = true;
            checkBox1.Visible = true;
            checkBox2.Visible = true;
            checkBox3.Visible = true;
            checkBox2.Checked = true;
        }

        private void btnReset_Click(object sender, EventArgs e) {
            Application.Restart();
            Environment.Exit(0);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e) {
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            tmrAutomatic.Interval = 950;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) {
            checkBox1.Checked = false;
            checkBox3.Checked = false;
            tmrAutomatic.Interval = 1500;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e) {
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            tmrAutomatic.Interval = 3000;
        }
    }
}
