using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulador_de_gravidade
{
    internal class Corpo : Corpoabstrato
    {
        private string Nome;
        private double Massa;
        private double Densidade;
        private double PosicaoX;
        private double PosicaoY;
        private double VelocidadeX;
        private double VelocidadeY;
        private double ForcaX;
        private double ForcaY;

        public override string getNome()
        {
            return this.Nome;
        }
        public override double getMassa()
        {
            return this.Massa;
        }

        public override double getVelocidadeX()
        {
            return this.VelocidadeX;
        }

        public override double getVelocidadeY()
        {
            return this.VelocidadeY;
        }

        public override double getPosicaoX()
        {
            return this.PosicaoX;
        }

        public override double getPosicaoY()
        {
            return this.PosicaoY;
        }

       
        public override double getDensidade()
        {
            return this.Densidade;
        }

        public override double getRaio()
        {
           
            double V = this.Massa / this.Densidade;

            return Math.Pow(V / ((4.0 / 3.0) * Math.PI), 1.0 / 3.0);
        }

        public override double getForcaX()
        {
            return this.ForcaX;
        }

        public override double getForcaY()
        {
            return this.ForcaY;
        }

        public void setMassa(double massa)
        {
            this.Massa = massa;
        }
        public override void setVelocidadeX(double velocidadeX)
        {
            this.VelocidadeX = velocidadeX;
        }

        public override void setVelocidadeY(double velocidadeY)
        {
            this.VelocidadeY = velocidadeY;
        }

        public override void setPosicaoX(double posicaoX)
        {
            this.PosicaoX = posicaoX;
        }

        public override void setPosicaoY(double posicaoY)
        {
            this.PosicaoY = posicaoY;
        }

        public override void setDensidade(double densidade)
        {
            this.Densidade = densidade;
        }

        public override void setForcaX(double forcaX)
        {
            this.ForcaX += forcaX;
        }

        public override void setForcaY(double forcaY)
        {
            this.ForcaY += forcaY;
        }

        public override void setNome(string nome)
        {
            this.Nome = nome;
        }

        public Corpo Clonar()
        {
            return new Corpo
            {
                Nome = this.Nome,
                Massa = this.Massa,
                Densidade = this.Densidade,
                PosicaoX = this.PosicaoX,
                PosicaoY = this.PosicaoY,
                VelocidadeX = this.VelocidadeX,
                VelocidadeY = this.VelocidadeY
            };
        }

        public static Corpo operator +(Corpo c1, Corpo c2)
        {
            Corpo novoCorpo = new Corpo();
            novoCorpo.setMassa(c1.getMassa() + c2.getMassa());
            novoCorpo.setDensidade(c1.getDensidade() + c2.getDensidade());
            novoCorpo.setNome(string.Concat(c2.getNome(), c1.getNome()));
        
            novoCorpo.setPosicaoX(((c1.getMassa() * c1.getPosicaoX()) + (c2.getMassa() * c2.getPosicaoX())) / (novoCorpo.getMassa()));
            novoCorpo.setPosicaoY(((c1.getMassa() * c1.getPosicaoY()) + (c2.getMassa() * c2.getPosicaoY())) / (novoCorpo.getMassa()));
           
            novoCorpo.setVelocidadeX(((c1.getMassa() * c1.getVelocidadeX()) + (c2.getMassa() * c2.getVelocidadeX())) / (c1.getMassa() + c2.getMassa()));
            novoCorpo.setVelocidadeY(((c1.getMassa() * c1.getVelocidadeY()) + (c2.getMassa() * c2.getVelocidadeY())) / (c1.getMassa() + c2.getMassa()));
          

            return novoCorpo;
        }
    }
}
