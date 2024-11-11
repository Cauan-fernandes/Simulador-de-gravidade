namespace Simulador_de_gravidade
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PainelControles = new Panel();
            BotaoGerar = new Button();
            InputMinRaio = new NumericUpDown();
            InputMaxRaio = new NumericUpDown();
            LabelRaios = new Label();
            InputMaxMassa = new NumericUpDown();
            InputMinMassa = new NumericUpDown();
            LabelMassas = new Label();
            InputTempoIteracoes = new NumericUpDown();
            LabelTempoIteracoes = new Label();
            LabelNumCorpos = new Label();
            InputNumCorpos = new NumericUpDown();
            BotaoParar = new Button();
            BotaoIniciar = new Button();
            Espaco = new Panel();
            LabelNumIteracoes = new Label();
            PainelControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)InputMinRaio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)InputMaxRaio).BeginInit();
            ((System.ComponentModel.ISupportInitialize)InputMaxMassa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)InputMinMassa).BeginInit();
            ((System.ComponentModel.ISupportInitialize)InputTempoIteracoes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)InputNumCorpos).BeginInit();
            Espaco.SuspendLayout();
            SuspendLayout();
            // 
            // PainelControles
            // 
            PainelControles.Controls.Add(BotaoGerar);
            PainelControles.Controls.Add(InputMinRaio);
            PainelControles.Controls.Add(InputMaxRaio);
            PainelControles.Controls.Add(LabelRaios);
            PainelControles.Controls.Add(InputMaxMassa);
            PainelControles.Controls.Add(InputMinMassa);
            PainelControles.Controls.Add(LabelMassas);
            PainelControles.Controls.Add(InputTempoIteracoes);
            PainelControles.Controls.Add(LabelTempoIteracoes);
            PainelControles.Controls.Add(LabelNumCorpos);
            PainelControles.Controls.Add(InputNumCorpos);
            PainelControles.Controls.Add(BotaoParar);
            PainelControles.Controls.Add(BotaoIniciar);
            PainelControles.Dock = DockStyle.Top;
            PainelControles.Location = new Point(0, 0);
            PainelControles.Name = "PainelControles";
            PainelControles.Size = new Size(870, 69);
            PainelControles.TabIndex = 0;
            // 
            // BotaoGerar
            // 
            BotaoGerar.Location = new Point(202, 3);
            BotaoGerar.Name = "BotaoGerar";
            BotaoGerar.Size = new Size(75, 63);
            BotaoGerar.TabIndex = 12;
            BotaoGerar.Text = "Gerar";
            BotaoGerar.UseVisualStyleBackColor = true;
            BotaoGerar.Click += BotaoGerar_Click;
            // 
            // InputMinRaio
            // 
            InputMinRaio.Location = new Point(612, 36);
            InputMinRaio.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            InputMinRaio.Minimum = new decimal(new int[] { 10, 0, 0, 65536 });
            InputMinRaio.Name = "InputMinRaio";
            InputMinRaio.Size = new Size(94, 23);
            InputMinRaio.TabIndex = 11;
            InputMinRaio.Value = new decimal(new int[] { 500, 0, 0, 65536 });
            // 
            // InputMaxRaio
            // 
            InputMaxRaio.Location = new Point(712, 36);
            InputMaxRaio.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            InputMaxRaio.Minimum = new decimal(new int[] { 10, 0, 0, 65536 });
            InputMaxRaio.Name = "InputMaxRaio";
            InputMaxRaio.Size = new Size(89, 23);
            InputMaxRaio.TabIndex = 10;
            InputMaxRaio.Value = new decimal(new int[] { 3000, 0, 0, 65536 });
            // 
            // LabelRaios
            // 
            LabelRaios.AutoSize = true;
            LabelRaios.Location = new Point(482, 40);
            LabelRaios.Name = "LabelRaios";
            LabelRaios.Size = new Size(114, 15);
            LabelRaios.TabIndex = 9;
            LabelRaios.Text = "Raio min e max (m):";
            // 
            // InputMaxMassa
            // 
            InputMaxMassa.Location = new Point(712, 9);
            InputMaxMassa.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            InputMaxMassa.Minimum = new decimal(new int[] { 100, 0, 0, 65536 });
            InputMaxMassa.Name = "InputMaxMassa";
            InputMaxMassa.Size = new Size(89, 23);
            InputMaxMassa.TabIndex = 8;
            InputMaxMassa.Value = new decimal(new int[] { 50000, 0, 0, 0 });
            // 
            // InputMinMassa
            // 
            InputMinMassa.Location = new Point(612, 9);
            InputMinMassa.Maximum = new decimal(new int[] { 1000000000, 0, 0, 0 });
            InputMinMassa.Minimum = new decimal(new int[] { 100, 0, 0, 65536 });
            InputMinMassa.Name = "InputMinMassa";
            InputMinMassa.Size = new Size(94, 23);
            InputMinMassa.TabIndex = 7;
            InputMinMassa.Value = new decimal(new int[] { 100000, 0, 0, 65536 });
            // 
            // LabelMassas
            // 
            LabelMassas.AutoSize = true;
            LabelMassas.Location = new Point(482, 9);
            LabelMassas.Name = "LabelMassas";
            LabelMassas.Size = new Size(127, 15);
            LabelMassas.TabIndex = 6;
            LabelMassas.Text = "Massa min e max (Kg):";
            // 
            // InputTempoIteracoes
            // 
            InputTempoIteracoes.Location = new Point(412, 36);
            InputTempoIteracoes.Maximum = new decimal(new int[] { 5000, 0, 0, 0 });
            InputTempoIteracoes.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            InputTempoIteracoes.Name = "InputTempoIteracoes";
            InputTempoIteracoes.Size = new Size(64, 23);
            InputTempoIteracoes.TabIndex = 5;
            InputTempoIteracoes.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // LabelTempoIteracoes
            // 
            LabelTempoIteracoes.AutoSize = true;
            LabelTempoIteracoes.Location = new Point(283, 38);
            LabelTempoIteracoes.Name = "LabelTempoIteracoes";
            LabelTempoIteracoes.Size = new Size(112, 15);
            LabelTempoIteracoes.TabIndex = 4;
            LabelTempoIteracoes.Text = "Tempo Iterações (s):";
            // 
            // LabelNumCorpos
            // 
            LabelNumCorpos.AutoSize = true;
            LabelNumCorpos.Location = new Point(283, 9);
            LabelNumCorpos.Name = "LabelNumCorpos";
            LabelNumCorpos.Size = new Size(111, 15);
            LabelNumCorpos.TabIndex = 3;
            LabelNumCorpos.Text = "Numero de Corpos:";
            // 
            // InputNumCorpos
            // 
            InputNumCorpos.Location = new Point(412, 7);
            InputNumCorpos.Maximum = new decimal(new int[] { 200, 0, 0, 0 });
            InputNumCorpos.Minimum = new decimal(new int[] { 20, 0, 0, 0 });
            InputNumCorpos.Name = "InputNumCorpos";
            InputNumCorpos.Size = new Size(64, 23);
            InputNumCorpos.TabIndex = 2;
            InputNumCorpos.Value = new decimal(new int[] { 130, 0, 0, 0 });
            // 
            // BotaoParar
            // 
            BotaoParar.Enabled = false;
            BotaoParar.Location = new Point(84, 3);
            BotaoParar.Name = "BotaoParar";
            BotaoParar.Size = new Size(75, 63);
            BotaoParar.TabIndex = 1;
            BotaoParar.Text = "Parar";
            BotaoParar.UseVisualStyleBackColor = true;
            BotaoParar.Click += BotaoParar_Click;
            // 
            // BotaoIniciar
            // 
            BotaoIniciar.Enabled = false;
            BotaoIniciar.Location = new Point(3, 3);
            BotaoIniciar.Name = "BotaoIniciar";
            BotaoIniciar.Size = new Size(75, 63);
            BotaoIniciar.TabIndex = 0;
            BotaoIniciar.Text = "Iniciar";
            BotaoIniciar.UseVisualStyleBackColor = true;
            BotaoIniciar.Click += BotaoIniciar_Click;
            // 
            // Espaco
            // 
            Espaco.BackColor = Color.Black;
            Espaco.Controls.Add(LabelNumIteracoes);
            Espaco.Dock = DockStyle.Fill;
            Espaco.Location = new Point(0, 69);
            Espaco.Name = "Espaco";
            Espaco.Size = new Size(870, 381);
            Espaco.TabIndex = 1;
            Espaco.Paint += Espaco_Paint;
            // 
            // LabelNumIteracoes
            // 
            LabelNumIteracoes.AutoSize = true;
            LabelNumIteracoes.ForeColor = Color.Yellow;
            LabelNumIteracoes.Location = new Point(3, 3);
            LabelNumIteracoes.Name = "LabelNumIteracoes";
            LabelNumIteracoes.Size = new Size(0, 15);
            LabelNumIteracoes.TabIndex = 13;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(870, 450);
            Controls.Add(Espaco);
            Controls.Add(PainelControles);
            Name = "Form1";
            Text = "Simulador de gravidade";
            PainelControles.ResumeLayout(false);
            PainelControles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)InputMinRaio).EndInit();
            ((System.ComponentModel.ISupportInitialize)InputMaxRaio).EndInit();
            ((System.ComponentModel.ISupportInitialize)InputMaxMassa).EndInit();
            ((System.ComponentModel.ISupportInitialize)InputMinMassa).EndInit();
            ((System.ComponentModel.ISupportInitialize)InputTempoIteracoes).EndInit();
            ((System.ComponentModel.ISupportInitialize)InputNumCorpos).EndInit();
            Espaco.ResumeLayout(false);
            Espaco.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel PainelControles;
        private Button BotaoParar;
        private Button BotaoIniciar;
        private Label LabelNumCorpos;
        private NumericUpDown InputNumCorpos;
        private Label LabelTempoIteracoes;
        private NumericUpDown InputTempoIteracoes;
        private Label LabelMassas;
        private NumericUpDown InputMinMassa;
        private NumericUpDown InputMaxMassa;
        private NumericUpDown InputMinRaio;
        private NumericUpDown InputMaxRaio;
        private Label LabelRaios;
        private Panel Espaco;
        private Button BotaoGerar;
        private Label LabelNumIteracoes;
    }
}
