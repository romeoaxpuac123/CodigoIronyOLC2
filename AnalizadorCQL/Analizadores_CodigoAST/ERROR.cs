using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class ERROR : NodoAbstracto
    {
        public ERROR(String Valor) : base(Valor)
        {

        }

        public override void Ejecutar()
        {
            throw new NotImplementedException();
        }

        public override string Ejecutar(Entorno entorno)
        {
            return "#ERROR-BRAY";
        }
    }
}