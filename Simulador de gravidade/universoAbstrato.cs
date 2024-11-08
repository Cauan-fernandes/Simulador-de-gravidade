using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulador_de_gravidade
{
    abstract class UniversoAbstrato
    {
       
            public abstract double CalcularForca(Corpo corpo1, Corpo corpo2);
            public abstract void IteracaoGravitacional(Corpo corpo);
            public abstract double CalcularDistancia(Corpo corpo1, Corpo corpo2);
    
    }
}
