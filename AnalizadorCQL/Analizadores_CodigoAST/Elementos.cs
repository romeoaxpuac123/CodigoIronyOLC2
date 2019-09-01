using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class Elementos
    {
        String Nombre;
        String tipo;
        String Valor;

        public Elementos(String Nombre, String Tipo, String Valor)
        {
            this.Nombre = Nombre;
            this.tipo = Tipo;
            this.Valor = Valor;
        }

    }
}