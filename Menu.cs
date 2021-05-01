using System;
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

        private void Menu_Load(object sender, EventArgs e)
        {

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
