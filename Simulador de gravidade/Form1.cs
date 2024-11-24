namespace Simulador_de_gravidade
{
    public partial class Form1 : Form
    {
        private Universo Universo;
        private bool Simulando = false;
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void BotaoGerar_Click(object sender, EventArgs e)
        {
            Simulando = false;
            BotaoParar.Enabled = false;
            LabelNumIteracoes.Text = "";
            try
            {
                int qntCorpos = (int)InputNumCorpos.Value;
                if (qntCorpos <= 0)
                {
                    MessageBox.Show("O número de corpos deve ser maior que zero.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int minMassa = (int)InputMinMassa.Value;
                int maxMassa = (int)InputMaxMassa.Value;
                if (minMassa <= 0 || maxMassa <= 0 || minMassa > maxMassa)
                {
                    MessageBox.Show("A massa mínima deve ser maior que zero e a massa máxima deve ser maior que a massa mínima.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int minRaio = (int)InputMinRaio.Value;
                int maxRaio = (int)InputMaxRaio.Value;
                if (minRaio <= 0 || maxRaio <= 0 || minRaio > maxRaio)
                {
                    MessageBox.Show("O raio mínimo deve ser maior que zero e o raio máximo deve ser maior que o raio mínimo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int intervaloTempo = (int)InputTempoIteracoes.Value;

                Universo = new Universo(qntCorpos, intervaloTempo, minMassa, maxMassa, minRaio, maxRaio);

                Universo.GerarCorposAleatorios();

                Espaco.Invalidate();
                this.BotaoIniciar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao gerar os corpos: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Espaco_Paint(object sender, PaintEventArgs e)
        {
            if (Universo != null)
            {
                e.Graphics.Clear(Color.Black);

                foreach (var corpo in Universo.GetCorpos())
                {
                    float posX = (float)corpo.getPosicaoX();
                    float posY = (float)corpo.getPosicaoY();
                    float raio = (float)(corpo.getRaio());

                    // Ajusta a posição para evitar que o corpo saia dos limites da área de desenho
                    posX = Math.Min(Math.Max(posX, raio), Espaco.Width - raio);
                    posY = Math.Min(Math.Max(posY, raio), Espaco.Height - raio);

                    e.Graphics.FillEllipse(Brushes.White, posX - raio, posY - raio, raio * 2, raio * 2);
                }
            }
        }

        private async void BotaoIniciar_Click(object sender, EventArgs e)
        {
            try
            {
                Simulando = true;
                BotaoParar.Enabled = true;
                BotaoIniciar.Enabled = false;

                int maxIteracoes = (int)InputTempoIteracoes.Value; 
                int iteracoesRealizadas = 0;

               
                while (Universo.GetCorpos().Count > 1 && Simulando)
                {
                    foreach (var corpo in Universo.GetCorpos())
                    {
                        Universo.IteracaoGravitacional(corpo); 
                    }

                    Universo.VerificaColisao(); 
                    iteracoesRealizadas++;

                   
                    if (iteracoesRealizadas >= maxIteracoes)
                    {
                        Espaco.Invalidate(); 
                        LabelNumIteracoes.Text = $"Qtd Iterações: {Universo.GetQntIteracoes()}"; 
                        iteracoesRealizadas = 0; 

                    await Task.Delay(10);
                }

            
                if (!Simulando)
                {
                    BotaoParar.Enabled = false;
                    BotaoIniciar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private void BotaoParar_Click(object sender, EventArgs e)
        {
            if (Simulando)
            {
                Simulando = false;
                BotaoParar.Enabled = false;
                BotaoIniciar.Enabled = true;
            }
            else
            {
                MessageBox.Show("A simulação não está em andamento.");
            }
        }
    
    }
}
