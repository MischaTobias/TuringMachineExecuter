
namespace TuringMachineExecuter
{
    partial class menuForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menuForm));
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.txtInitTape = new System.Windows.Forms.TextBox();
            this.btnAutomatic = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnNextStep = new System.Windows.Forms.Button();
            this.lblLastMovement = new System.Windows.Forms.Label();
            this.btnLoadTape = new System.Windows.Forms.Button();
            this.tape = new System.Windows.Forms.CheckedListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitleUno = new System.Windows.Forms.Label();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCurrentNode = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.tmrAutomatic = new System.Windows.Forms.Timer(this.components);
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLoadFile.Location = new System.Drawing.Point(55, 61);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(106, 24);
            this.btnLoadFile.TabIndex = 0;
            this.btnLoadFile.Text = "Cargar máquina";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // txtInitTape
            // 
            this.txtInitTape.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtInitTape.Location = new System.Drawing.Point(167, 141);
            this.txtInitTape.Name = "txtInitTape";
            this.txtInitTape.Size = new System.Drawing.Size(252, 23);
            this.txtInitTape.TabIndex = 1;
            // 
            // btnAutomatic
            // 
            this.btnAutomatic.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAutomatic.Location = new System.Drawing.Point(53, 227);
            this.btnAutomatic.Name = "btnAutomatic";
            this.btnAutomatic.Size = new System.Drawing.Size(90, 24);
            this.btnAutomatic.TabIndex = 2;
            this.btnAutomatic.Text = "Automática";
            this.btnAutomatic.UseVisualStyleBackColor = true;
            this.btnAutomatic.Click += new System.EventHandler(this.btnAutomatic_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStop.Location = new System.Drawing.Point(284, 227);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(134, 24);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Detener ejecución";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnNextStep
            // 
            this.btnNextStep.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNextStep.Location = new System.Drawing.Point(147, 227);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(132, 24);
            this.btnNextStep.TabIndex = 4;
            this.btnNextStep.Text = "Ejecutar un paso";
            this.btnNextStep.UseVisualStyleBackColor = true;
            this.btnNextStep.Click += new System.EventHandler(this.btnNextStep_Click);
            // 
            // lblLastMovement
            // 
            this.lblLastMovement.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLastMovement.AutoSize = true;
            this.lblLastMovement.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLastMovement.Location = new System.Drawing.Point(192, 334);
            this.lblLastMovement.Name = "lblLastMovement";
            this.lblLastMovement.Size = new System.Drawing.Size(115, 19);
            this.lblLastMovement.TabIndex = 12;
            this.lblLastMovement.Text = "lblLastMovement";
            // 
            // btnLoadTape
            // 
            this.btnLoadTape.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLoadTape.Location = new System.Drawing.Point(53, 138);
            this.btnLoadTape.Name = "btnLoadTape";
            this.btnLoadTape.Size = new System.Drawing.Size(106, 23);
            this.btnLoadTape.TabIndex = 14;
            this.btnLoadTape.Text = "Ingresar";
            this.btnLoadTape.UseVisualStyleBackColor = true;
            this.btnLoadTape.Click += new System.EventHandler(this.btnLoadTape_Click);
            // 
            // tape
            // 
            this.tape.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tape.FormattingEnabled = true;
            this.tape.Location = new System.Drawing.Point(461, 61);
            this.tape.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.tape.Name = "tape";
            this.tape.Size = new System.Drawing.Size(89, 256);
            this.tape.TabIndex = 15;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(38, 45);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(390, 61);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // lblTitleUno
            // 
            this.lblTitleUno.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitleUno.AutoSize = true;
            this.lblTitleUno.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lblTitleUno.Location = new System.Drawing.Point(55, 37);
            this.lblTitleUno.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblTitleUno.Name = "lblTitleUno";
            this.lblTitleUno.Size = new System.Drawing.Size(138, 19);
            this.lblTitleUno.TabIndex = 17;
            this.lblTitleUno.Text = "Selección de archivo:";
            // 
            // txtFile
            // 
            this.txtFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFile.Location = new System.Drawing.Point(167, 62);
            this.txtFile.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(252, 23);
            this.txtFile.TabIndex = 18;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(38, 127);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(390, 52);
            this.pictureBox2.TabIndex = 19;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(55, 118);
            this.label1.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 19);
            this.label1.TabIndex = 20;
            this.label1.Text = "Cinta de entrada:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(55, 202);
            this.label4.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(147, 19);
            this.label4.TabIndex = 21;
            this.label4.Text = "Métodos de ejecución:";
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox3.Location = new System.Drawing.Point(38, 212);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(390, 52);
            this.pictureBox3.TabIndex = 22;
            this.pictureBox3.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(55, 313);
            this.label2.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 19);
            this.label2.TabIndex = 23;
            this.label2.Text = "Estado actual:";
            // 
            // lblCurrentNode
            // 
            this.lblCurrentNode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCurrentNode.AutoSize = true;
            this.lblCurrentNode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentNode.Location = new System.Drawing.Point(164, 313);
            this.lblCurrentNode.Name = "lblCurrentNode";
            this.lblCurrentNode.Size = new System.Drawing.Size(103, 19);
            this.lblCurrentNode.TabIndex = 10;
            this.lblCurrentNode.Text = "lblCurrentNode";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(55, 334);
            this.label5.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 19);
            this.label5.TabIndex = 24;
            this.label5.Text = "Última transición:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(461, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 19);
            this.label3.TabIndex = 25;
            this.label3.Text = "Cinta:";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox4.Location = new System.Drawing.Point(447, 45);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(118, 285);
            this.pictureBox4.TabIndex = 26;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox5.Location = new System.Drawing.Point(38, 301);
            this.pictureBox5.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(390, 62);
            this.pictureBox5.TabIndex = 27;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(55, 292);
            this.label6.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(178, 19);
            this.label6.TabIndex = 28;
            this.label6.Text = "Estado actual de ejecución:";
            // 
            // pictureBox6
            // 
            this.pictureBox6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox6.Location = new System.Drawing.Point(38, 212);
            this.pictureBox6.Margin = new System.Windows.Forms.Padding(1, 2, 1, 2);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(390, 52);
            this.pictureBox6.TabIndex = 22;
            this.pictureBox6.TabStop = false;
            // 
            // tmrAutomatic
            // 
            this.tmrAutomatic.Interval = 1500;
            this.tmrAutomatic.Tick += new System.EventHandler(this.tmrAutomatic_Tick);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(447, 339);
            this.btnReset.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(118, 23);
            this.btnReset.TabIndex = 29;
            this.btnReset.Text = "Empezar de nuevo";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // menuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(603, 394);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.lblTitleUno);
            this.Controls.Add(this.tape);
            this.Controls.Add(this.btnLoadTape);
            this.Controls.Add(this.lblLastMovement);
            this.Controls.Add(this.lblCurrentNode);
            this.Controls.Add(this.btnNextStep);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnAutomatic);
            this.Controls.Add(this.txtInitTape);
            this.Controls.Add(this.btnLoadFile);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox5);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "menuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TM Executer";
            this.Load += new System.EventHandler(this.menuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.TextBox txtInitTape;
        private System.Windows.Forms.Button btnAutomatic;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnNextStep;
        private System.Windows.Forms.Label lblLastMovement;
        private System.Windows.Forms.Button btnLoadTape;
        private System.Windows.Forms.CheckedListBox checkedTape;
        private System.Windows.Forms.CheckedListBox tape;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitleUno;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCurrentNode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox6;
        private System.Windows.Forms.Timer automaticEjecution;
        private System.Windows.Forms.Timer tmrAutomaticEjecution;
        private System.Windows.Forms.Timer tmrAutomatic;
        private System.Windows.Forms.Button btnReset;
    }
}