using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simulador_de_gravidade
{
    internal class Universo : UniversoAbstrato
    {
        private double gravidade = 6.674184 * Math.Pow(10, -11);
        public int QtdCorpos;
        public int QtdIteracoes;
        public double Tempo;
        public List<Corpo> corpos = new List<Corpo>();

        public override void IteracaoGravitacional(Corpo corpo)
        {
           
            Parallel.ForEach(this.corpos, c =>
            {
                if (c != corpo)
                {
                    corpo.setForcaX(CalcularForca(corpo, c));
                    corpo.setForcaY(CalcularForca(corpo, c));
                }
            });

            AplicaForca(corpo); 
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

            double velocidadeX = corpo.getVelocidadeX() + aceleracaoX * Tempo;
            double velocidadeY = corpo.getVelocidadeY() + aceleracaoY * Tempo;
            corpo.setVelocidadeX(velocidadeX);
            corpo.setVelocidadeY(velocidadeY);

            double posicaoX = corpo.getPosicaoX() + corpo.getVelocidadeX() * Tempo + (aceleracaoX / 2) * (Tempo * Tempo);
            double posicaoY = corpo.getPosicaoY() + corpo.getVelocidadeY() * Tempo + (aceleracaoY / 2) * (Tempo * Tempo);
            corpo.setPosicaoX(posicaoX);
            corpo.setPosicaoY(posicaoY);
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
    }
}
