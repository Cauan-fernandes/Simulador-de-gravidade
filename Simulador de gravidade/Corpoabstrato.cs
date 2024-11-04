using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulador_de_gravidade
{
    abstract class Corpoabstrato
    {
        public abstract string getNome();
        public abstract double getMassa();
        public abstract double getVelocidadeX();
        public abstract double getVelocidadeY();
        public abstract double getRaio();
        public abstract double getPosicaoX();
        public abstract double getPosicaoY();
        public abstract double getDensidade();
        public abstract double getForcaX();
        public abstract double getForcaY();
        public abstract void setVelocidadeX(double velocidadeX);
        public abstract void setVelocidadeY(double velocidadeY);
        public abstract void setPosicaoX(double posicaoX);
        public abstract void setPosicaoY(double posicaoY);
        public abstract void setDensidade(double densidade);
        public abstract void setForcaX(double forcaX);
        public abstract void setForcaY(double forcaY);
        public abstract void setNome(string nome);
    }
}
