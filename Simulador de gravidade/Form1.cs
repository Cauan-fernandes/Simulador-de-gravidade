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
                Universo.SalvarValoresIniciaisCorpos();

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
                //Mantém o tamanho do universo desenhado proporcional à distancia dos corpos
                //Assim todos os corpos ficam sempre dentro da tela.

                e.Graphics.Clear(Color.Black);

                double minX = Universo.GetCorpos().Min(c => c.getPosicaoX());
                double maxX = Universo.GetCorpos().Max(c => c.getPosicaoX());
                double minY = Universo.GetCorpos().Min(c => c.getPosicaoY());
                double maxY = Universo.GetCorpos().Max(c => c.getPosicaoY());

                double universoLargura = maxX - minX;
                double universoAltura = maxY - minY;

                int larguraPainel = Espaco.Width;
                int alturaPainel = Espaco.Height;

                // pega a escala (a menor escala entre largura e altura para manter proporção)
                double escala = Math.Min(larguraPainel / universoLargura, alturaPainel / universoAltura);

                // Ajusta para centralizar os corpos no painel
                double deslocamentoX = -minX * escala + (larguraPainel - (universoLargura * escala)) / 2;
                double deslocamentoY = -minY * escala + (alturaPainel - (universoAltura * escala)) / 2;

                // Desenha cada corpo
                foreach (var corpo in Universo.GetCorpos())
                {
                    float posX = (float)(corpo.getPosicaoX() * escala + deslocamentoX);
                    float posY = (float)(corpo.getPosicaoY() * escala + deslocamentoY);
                    float raio = (float)(corpo.getRaio() * escala);

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
                        LabelNumIteracoes.Text = $"Qtd Iterações: {Universo.GetQtdIteracoes()}";
                        iteracoesRealizadas = 0;

                        await Task.Delay(10);
                    }


                    if (!Simulando)
                    {
                        BotaoParar.Enabled = false;
                        BotaoIniciar.Enabled = true;
                    }
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
        }

        private void Salvar_Click(object sender, EventArgs e)
        {
            BotaoParar_Click(sender, e);
            if (Universo == null || Universo.GetCorpos().Count == 0)
            {
                MessageBox.Show("Nenhum universo foi criado para salvar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Arquivo de Texto (*.txt)|*.txt",
                Title = "Salvar Universo"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                    {
                        //primeira linha
                        writer.WriteLine(Universo.GetQtdIteracoes());

                        //corpos
                        foreach (var corpo in Universo.GetValoresIniciaisCorpos())
                        {
                            writer.WriteLine($"{corpo.getNome()};{corpo.getMassa()};{corpo.getDensidade()};" +
                                             $"{corpo.getPosicaoX()};{corpo.getPosicaoY()};" +
                                             $"{corpo.getVelocidadeX()};{corpo.getVelocidadeY()}");
                        }
                    }

                    MessageBox.Show("Universo salvo com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao salvar o universo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Carregar_Click(Object sender, EventArgs e)
        {
            BotaoParar_Click(sender, e);
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Arquivo de Texto (*.txt)|*.txt",
                Title = "Carregar Universo"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                    {
                        // Lê a primeira linha
                        int qntIteracoes = int.Parse(reader.ReadLine());

                        // Cria um novo universo
                        Universo = new Universo(0, 10, 1, 1, 1, 1);
                        Universo.SetQtdIteracoes(qntIteracoes);

                        // Lê os corpos
                        string linha;
                        while ((linha = reader.ReadLine()) != null)
                        {
                            string[] dados = linha.Split(';');
                            Corpo corpo = new Corpo();
                            corpo.setNome(dados[0]);
                            corpo.setMassa(double.Parse(dados[1]));
                            corpo.setDensidade(double.Parse(dados[2]));
                            corpo.setPosicaoX(double.Parse(dados[3]));
                            corpo.setPosicaoY(double.Parse(dados[4]));
                            corpo.setVelocidadeX(double.Parse(dados[5]));
                            corpo.setVelocidadeY(double.Parse(dados[6]));


                            Universo.GetCorpos().Add(corpo);
                        }
                    }

                    Espaco.Invalidate();
                    BotaoIniciar.Enabled = true;
                    MessageBox.Show("Universo carregado com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erro ao carregar o universo: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    
    }
}
