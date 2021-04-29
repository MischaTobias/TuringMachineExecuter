﻿
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(menuForm));
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnAutomatic = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnNextStep = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTuringFile = new System.Windows.Forms.Label();
            this.dgvCinta = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblCurrentNode = new System.Windows.Forms.Label();
            this.lblLastMovement = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCinta)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLoadFile.Location = new System.Drawing.Point(29, 24);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(140, 35);
            this.btnLoadFile.TabIndex = 0;
            this.btnLoadFile.Text = "Cargar Máquina";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Location = new System.Drawing.Point(29, 109);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 23);
            this.textBox1.TabIndex = 1;
            // 
            // btnAutomatic
            // 
            this.btnAutomatic.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAutomatic.Location = new System.Drawing.Point(29, 193);
            this.btnAutomatic.Name = "btnAutomatic";
            this.btnAutomatic.Size = new System.Drawing.Size(140, 35);
            this.btnAutomatic.TabIndex = 2;
            this.btnAutomatic.Text = "Ejecución automática";
            this.btnAutomatic.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            this.btnStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStop.Location = new System.Drawing.Point(29, 300);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(140, 35);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Detener ejecución";
            this.btnStop.UseVisualStyleBackColor = true;
            // 
            // btnNextStep
            // 
            this.btnNextStep.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnNextStep.Location = new System.Drawing.Point(29, 245);
            this.btnNextStep.Name = "btnNextStep";
            this.btnNextStep.Size = new System.Drawing.Size(140, 35);
            this.btnNextStep.TabIndex = 4;
            this.btnNextStep.Text = "Ejecutar un paso";
            this.btnNextStep.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(29, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Cinta de entrada";
            // 
            // lblTuringFile
            // 
            this.lblTuringFile.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTuringFile.AutoSize = true;
            this.lblTuringFile.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTuringFile.Location = new System.Drawing.Point(185, 29);
            this.lblTuringFile.Name = "lblTuringFile";
            this.lblTuringFile.Size = new System.Drawing.Size(15, 19);
            this.lblTuringFile.TabIndex = 6;
            this.lblTuringFile.Text = "-";
            // 
            // dgvCinta
            // 
            this.dgvCinta.AllowUserToAddRows = false;
            this.dgvCinta.AllowUserToDeleteRows = false;
            this.dgvCinta.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvCinta.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvCinta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCinta.Location = new System.Drawing.Point(207, 190);
            this.dgvCinta.Name = "dgvCinta";
            this.dgvCinta.ReadOnly = true;
            this.dgvCinta.RowTemplate.Height = 25;
            this.dgvCinta.Size = new System.Drawing.Size(514, 90);
            this.dgvCinta.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(403, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "Estado Actual";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(414, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Cinta Actual";
            // 
            // lblCurrentNode
            // 
            this.lblCurrentNode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCurrentNode.AutoSize = true;
            this.lblCurrentNode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentNode.Location = new System.Drawing.Point(452, 65);
            this.lblCurrentNode.Name = "lblCurrentNode";
            this.lblCurrentNode.Size = new System.Drawing.Size(15, 19);
            this.lblCurrentNode.TabIndex = 10;
            this.lblCurrentNode.Text = "-";
            // 
            // lblLastMovement
            // 
            this.lblLastMovement.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLastMovement.AutoSize = true;
            this.lblLastMovement.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblLastMovement.Location = new System.Drawing.Point(452, 346);
            this.lblLastMovement.Name = "lblLastMovement";
            this.lblLastMovement.Size = new System.Drawing.Size(15, 19);
            this.lblLastMovement.TabIndex = 12;
            this.lblLastMovement.Text = "-";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(301, 300);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(318, 21);
            this.label6.TabIndex = 11;
            this.label6.Text = "Última transición/movimiento realizado";
            // 
            // menuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(759, 450);
            this.Controls.Add(this.lblLastMovement);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblCurrentNode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvCinta);
            this.Controls.Add(this.lblTuringFile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNextStep);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnAutomatic);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnLoadFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "menuForm";
            this.Text = "TM Executer";
            this.Load += new System.EventHandler(this.Menu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCinta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnAutomatic;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnNextStep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTuringFile;
        private System.Windows.Forms.DataGridView dgvCinta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblCurrentNode;
        private System.Windows.Forms.Label lblLastMovement;
        private System.Windows.Forms.Label label6;
    }
}