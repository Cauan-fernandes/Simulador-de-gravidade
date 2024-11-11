using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Simulador_de_gravidade
{
    internal class Universo : UniversoAbstrato
    {
        private double gravidade = 6.674184 * Math.Pow(10, -11);
        public int QtdCorpos;
        public int QtdIteracoes;
        public double Tempo;
        private int MinMassa, MaxMassa, MinRaio, MaxRaio;
        private Random Rnd;
        public List<Corpo> corpos = new List<Corpo>();

        public Universo(int qntCorpos, int intervaloTempo, int minMassa, int maxMassa, int minRaio, int maxRaio)
        {
            this.QtdCorpos = qntCorpos;
            this.QtdIteracoes = 0;
            this.Tempo = intervaloTempo;
            this.MinMassa = minMassa;
            this.MaxMassa = maxMassa;
            this.MinRaio = minRaio;
            this.MaxRaio = maxRaio;
            this.Rnd = new Random();
        }

        public List<Corpo> GetCorpos() { return corpos; }
        public int GetQntIteracoes() { return QtdIteracoes; }

        public override void IteracaoGravitacional(Corpo corpo)
        {
            Parallel.ForEach(this.corpos, c =>
            {
                if (c != corpo)
                {
                    double deltaX = c.getPosicaoX() - corpo.getPosicaoX();
                    double deltaY = c.getPosicaoY() - corpo.getPosicaoY();
                    double distancia = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

                    if (distancia > 0)
                    {
                        double forca = (gravidade * corpo.getMassa() * c.getMassa()) / (distancia * distancia);

                        double acelX = forca * (deltaX / distancia) / corpo.getMassa();
                        double acelY = forca * (deltaY / distancia) / corpo.getMassa();

                        corpo.setForcaX(acelX);
                        corpo.setForcaY(acelY);
                    }
                }
            });

            QtdIteracoes++;
            AplicaForca();
        }

        public override double CalcularForca(Corpo corpo1, Corpo corpo2)
        {
            double distancia = CalcularDistancia(corpo1, corpo2);
            return (gravidade * corpo1.getMassa() * corpo2.getMassa()) / (distancia * distancia);
        }

        public override double CalcularDistancia(Corpo corpo1, Corpo corpo2)
        {
            return Math.Sqrt(
                Math.Pow(corpo1.getPosicaoX() - corpo2.getPosicaoX(), 2) +
                Math.Pow(corpo1.getPosicaoY() - corpo2.getPosicaoY(), 2)
            );
        }

        public void AplicaForca(Corpo corpo)
        {
            double aceleracaoX = corpo.getForcaX() / corpo.getMassa();
            double aceleracaoY = corpo.getForcaY() / corpo.getMassa();

            double posicaoX = corpo.getPosicaoX() + corpo.getVelocidadeX() * Tempo + (aceleracaoX / 2) * Tempo * Tempo;
            double posicaoY = corpo.getPosicaoY() + corpo.getVelocidadeY() * Tempo + (aceleracaoY / 2) * Tempo * Tempo;

            corpo.setPosicaoX(posicaoX);
            corpo.setPosicaoY(posicaoY);

            corpo.setVelocidadeX(corpo.getVelocidadeX() + aceleracaoX * Tempo);
            corpo.setVelocidadeY(corpo.getVelocidadeY() + aceleracaoY * Tempo);
        }

        public void AplicaForca()
        {
            Parallel.For(0, corpos.Count, i =>
            {
                Corpo corpoA = corpos[i];
                double acelX = 0;
                double acelY = 0;

                foreach (Corpo corpoB in corpos)
                {
                    if (corpoA != corpoB)
                    {
                        double deltaX = corpoB.getPosicaoX() - corpoA.getPosicaoX();
                        double deltaY = corpoB.getPosicaoY() - corpoA.getPosicaoY();
                        double distancia = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);

                        if (distancia > 0)
                        {
                            double forca = (gravidade * corpoA.getMassa() * corpoB.getMassa()) / (distancia * distancia);

                            acelX += forca * (deltaX / distancia) / corpoA.getMassa();
                            acelY += forca * (deltaY / distancia) / corpoA.getMassa();
                        }
                    }
                }

                corpoA.setVelocidadeX(corpoA.getVelocidadeX() + acelX * Tempo);
                corpoA.setVelocidadeY(corpoA.getVelocidadeY() + acelY * Tempo);

                corpoA.setPosicaoX(corpoA.getPosicaoX() + corpoA.getVelocidadeX() * Tempo);
                corpoA.setPosicaoY(corpoA.getPosicaoY() + corpoA.getVelocidadeY() * Tempo);
            });
        }


        public void VerificaColisao()
        {
            var colisoes = new ConcurrentBag<(Corpo, Corpo)>();

            Parallel.For(0, this.corpos.Count, i =>
            {
                for (int j = i + 1; j < this.corpos.Count; j++)
                {
                    Corpo corpoA = this.corpos[i];
                    Corpo corpoB = this.corpos[j];

                    double distancia = CalcularDistancia(corpoA, corpoB);

                    if (distancia < corpoA.getRaio() + corpoB.getRaio())
                    {
                        colisoes.Add((corpoA, corpoB));
                    }
                }
            });

            List<Corpo> novosCorpos = new List<Corpo>();

            foreach (var (corpoA, corpoB) in colisoes)
            {
                Corpo novoCorpo = corpoA + corpoB;
                novosCorpos.Add(novoCorpo);

                lock (this.corpos)
                {
                    this.corpos.RemoveAll(x => x.getNome() == corpoA.getNome() || x.getNome() == corpoB.getNome());
                }
            }

            lock (this.corpos)
            {
                this.corpos.AddRange(novosCorpos);
            }
        }

        public void GerarCorposAleatorios()
        {
            for (int i = 0; i < QtdCorpos; i++)
            {
                Corpo corpo = new Corpo();

                corpo.setNome($"Corpo_{i + 1}");
                corpo.setMassa(Rnd.NextDouble() * (MaxMassa - MinMassa) + MinMassa);
                corpo.setDensidade(Rnd.NextDouble() * (MaxRaio - MinRaio) + MinRaio);

                // Posições e velocidades iniciais aleatórias
                corpo.setPosicaoX(Rnd.NextDouble() * (1920 - 2 * corpo.getDensidade()) + corpo.getDensidade());
                corpo.setPosicaoY(Rnd.NextDouble() * (1080 - 2 * corpo.getDensidade()) + corpo.getDensidade());
                corpo.setVelocidadeX(0);
                corpo.setVelocidadeY(0);
                this.corpos.Add(corpo);
            }
        }
    }
}
