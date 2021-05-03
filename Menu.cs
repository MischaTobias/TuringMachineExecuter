using System;
using System.IO;
using System.Windows.Forms;
using TuringMachineExecuter.Structures;
using System.Collections.Generic;

namespace TuringMachineExecuter
{
    public partial class menuForm : Form {
        TuringMachine TuringMachine;
        Tape TapeStep;

        public menuForm() {
            InitializeComponent();
            TuringMachine = new TuringMachine();
        }

        private void btnLoadFile_Click(object sender, EventArgs e) {
            var openFileDialog = new OpenFileDialog() {
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
                    if (dialogResult == DialogResult.Yes)
                    {
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
                                    enableButtons(false);
                                    TuringMachine.Usable = false;
                                    break;
                                }
                            }
                            if (TuringMachine.States.Count != TuringMachine.NoOfStates)
                            {
                                MessageBox.Show("Entrada inválida, tiene menos estados de los indicados");
                                enableButtons(false);
                                TuringMachine.Usable = false;
                                return;
                            }
                            if (TuringMachine.CheckInitialState())
                            {
                                lblCurrentNode.Text = TuringMachine.InitialState;
                                txtFile.Text = fileName;
                                enableButtons(true);
                                TuringMachine.Usable = true;
                            }
                            else
                            {
                                MessageBox.Show("Entrada inválida, el estado inicial no pertenece al conjunto de estados ingresados");
                                enableButtons(false);
                                TuringMachine.Usable = false;
                            }
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("El formato del archivo de entrada es incorrecto, \npor favor inténtelo nuevamente.");
                enableButtons(false);
                TuringMachine.Usable = false;
            }
        }

        private void btnLoadTape_Click(object sender, EventArgs e) {
            if (TuringMachine.Usable)
            {
                TapeStep = new Tape();
                if (CheckTape(txtInitTape.Text))
                {
                    var word = "_" + txtInitTape.Text + "_";
                    foreach (var value in word)
                        TapeStep.WordTape.Add(Convert.ToString(value));
                    printTape(TapeStep.WordTape);
                    TapeStep.CurrentPosition = 0;
                    TuringMachine.CurrentNode = TuringMachine.States.Find(x => x.State == TuringMachine.InitialState);
                    enableButtons(true);
                    btnLoadTape.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Entrada inválida, intente nuevamente, por favor");
                    txtInitTape.Text = "";
                }
            }
            else
            {
                MessageBox.Show("El formato del archivo de entrada es incorrecto, \npor favor inténtelo nuevamente.");
            }
        }

        private bool CheckTape(string newTape) {
            foreach (var character in newTape) {
                if (!TuringMachine.Alphabet.Contains(character)) {
                    return false;
                }
            }
            if (newTape.Equals("")) {
                return false;
            }
            return true;
        }

        private void menuForm_Load(object sender, EventArgs e) {
            enableButtons(false);
            txtFile.Enabled = false;
            btnAutomatic.Enabled = false;
            lblEjecution.Visible = false;
            checkBox1.Visible = false;
            checkBox2.Visible = false;
            checkBox3.Visible = false;
        }


        public void enableButtons(bool state) {
            btnAutomatic.Enabled = state;
            btnLoadTape.Enabled = state;
            btnNextStep.Enabled = state;
            btnStop.Enabled = state;
        }

        private void btnNextStep_Click(object sender, EventArgs e) {
            btnStop.Enabled = false;
            if (TapeStep != null)
                MachineStep();
            else
                MessageBox.Show("Error de Ejecucion");
        }

        public void MachineStep() {
            bool acepted = false;
            var letter = TapeStep.WordTape[TapeStep.CurrentPosition];
            Node auxNode = TuringMachine.CurrentNode;
            foreach (var item in auxNode.Transitions) {
                if (item.ReadingCharacter == letter) {
                    TapeStep.WordTape[TapeStep.CurrentPosition] = item.WritingCharacter;
                    if (item.HeadMovement == "d" || item.HeadMovement == "D") {
                        TapeStep.CurrentPosition++;
                        TapeStep.Repetitions0 = 0;
                        if (letter != " ")
                        {
                            TapeStep.RepetitionsD = 0;
                        }
                        else
                        {
                            TapeStep.RepetitionsD++;
                        }
                    } else if (item.HeadMovement == "i" || item.HeadMovement == "I") {
                        TapeStep.CurrentPosition--;
                        TapeStep.Repetitions0 = 0;
                        TapeStep.RepetitionsD = 0;
                        if (TapeStep.CurrentPosition < 0)
                        {
                            MessageBox.Show("MT inválida, la cinta no es infinita hacia la izquierda");
                            enableButtons(false);
                        }
                    }
                    else if (item.HeadMovement == "0")
                    {
                        TapeStep.Repetitions0++;
                        TapeStep.RepetitionsD = 0;
                    }
                    if (item.HeadMovement == "p" || item.HeadMovement == "P")
                    {
                        TapeStep.Repetitions0 = 0;
                        TapeStep.RepetitionsD = 0;
                        if (formart()) {
                            tmrAutomatic.Enabled = false;
                            MessageBox.Show("Fin de la Ejecución");
                            
                        }else {
                            tmrAutomatic.Enabled = false;
                            MessageBox.Show("Formato de Salida Incorrecto");
                            
                        }
                        enableButtons(false);
                    }
                    printTape(TapeStep.WordTape);
                    TuringMachine.CurrentNode = TuringMachine.States.Find(x => x.State == item.NextState);
                    lblCurrentNode.Text = TuringMachine.CurrentNode.State;
                    lblLastMovement.Text = item.PrintTransition();
                    acepted = true;
                }
                if (TapeStep.Repetitions0 == 10 || TapeStep.RepetitionsD == 10) {
                    enableButtons(false);
                    tmrAutomatic.Enabled = false;
                    DialogResult dialogResult = MessageBox.Show($"La máquina entró en un bucle, \n ¿desea intentar nuevamente con otra cadena en la cinta?", "¡No hay solución!", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes) {
                        enableButtons(true);
                        txtInitTape.Text = "";
                        tape.Items.Clear();
                        break;
                    }else {
                        Application.Exit();
                    }
                }
            }
            if (!acepted) {
                enableButtons(false);
                lblCurrentNode.Text = TuringMachine.CurrentNode.State;
                lblLastMovement.Text = "Transición No Existente";
                MessageBox.Show("ERROR: No hay Trasicion");
                tmrAutomatic.Enabled = false;
            }
        }

        public bool formart() {
            string word = "";
            foreach (var item in TapeStep.WordTape)
                word += item;
            string[] array = word.Split('_');
            if (array[0].Length == 0)
                if (array[2].Length == 0)
                    if (TapeStep.WordTape[TapeStep.CurrentPosition] == "_")
                        return true;
            return false;
        }

        public void printTape (List<string> word)
        {
            tape.Items.Clear();
            foreach (var value in word)
                tape.Items.Add(value);
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

        private void pictureBox5_Click(object sender, EventArgs e)
        {

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
            tmrAutomatic.Interval = 1000;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e) {
            tmrAutomatic.Interval = 1500;
            checkBox1.Checked = false;
            checkBox3.Checked = false;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e) {
            tmrAutomatic.Interval = 3000;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
        }
    }
}
