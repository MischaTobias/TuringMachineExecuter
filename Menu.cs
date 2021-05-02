using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TuringMachineExecuter.Structures;
using System.Collections.Generic;

namespace TuringMachineExecuter
{
    public partial class menuForm : Form
    {
        TuringMachine TuringMachine;
        Tape TapeStep;

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
            }
        }

        private void btnLoadTape_Click(object sender, EventArgs e) {
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
            }
            else
            {
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



        private void btnNextStep_Click(object sender, EventArgs e)
        {
            if (TapeStep != null)
                MachineStep();
            else
                MessageBox.Show("Error de Ejecucion");
        }

        public void MachineStep()
        {
            bool acepted = false;
            var letter = TapeStep.WordTape[TapeStep.CurrentPosition];
            Node auxNode = TuringMachine.CurrentNode;
            foreach (var item in auxNode.Transitions)
            {
                if (item.ReadingCharacter == letter)
                {
                    TapeStep.WordTape[TapeStep.CurrentPosition] = item.WritingCharacter;
                    if (item.HeadMovement == "d" || item.HeadMovement == "D")
                    {
                        TapeStep.CurrentPosition++;
                        TapeStep.Repetitions0 = 0;
                        TapeStep.RepetitionsD = 0;
                        TapeStep.RepetitionsI++;
                    }
                    else if (item.HeadMovement == "i" || item.HeadMovement == "I")
                    {
                        TapeStep.CurrentPosition--;
                        TapeStep.Repetitions0 = 0;
                        TapeStep.RepetitionsD = 0;
                        TapeStep.RepetitionsI++;

                    }
                    else if (item.HeadMovement == "0")
                    {
                        TapeStep.Repetitions0++;
                        TapeStep.RepetitionsD = 0;
                        TapeStep.RepetitionsI = 1;
                    }
                    if (item.HeadMovement == "p" || item.HeadMovement == "P")
                    {
                        TapeStep.Repetitions0 = 0;
                        TapeStep.RepetitionsI = 0;
                        TapeStep.RepetitionsD = 0;
                        if (formart())
                            MessageBox.Show("Fin de la Ejecución");
                        else
                            MessageBox.Show("Formato de Salida Incorrecto");
                        btnAutomatic.Enabled = false;
                        btnNextStep.Enabled = false;
                        btnStop.Enabled = false;
                    }
                    printTape(TapeStep.WordTape);
                    TuringMachine.CurrentNode = TuringMachine.States.Find(x => x.State == item.NextState);
                    lblCurrentNode.Text = TuringMachine.CurrentNode.State;
                    lblLastMovement.Text = item.PrintTransition();
                    acepted = true;
                }
                if (TapeStep.Repetitions0 == 10 || TapeStep.RepetitionsI == 10 || TapeStep.RepetitionsD == 10)
                {
                    MessageBox.Show("Entro un bucle (No Hay solución)");
                    btnAutomatic.Enabled = false;
                    btnNextStep.Enabled = false;
                    btnStop.Enabled = false;
                }
            }
            if (!acepted)
            {
                btnAutomatic.Enabled = false;
                btnNextStep.Enabled = false;
                btnStop.Enabled = false;
                lblCurrentNode.Text = TuringMachine.CurrentNode.State;
                lblLastMovement.Text = "Transición No Existente";
                MessageBox.Show("ERROR: No hay Trasicion");
            }
        }

        public bool formart()
        {
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

        private void btnStop_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
    }
}
