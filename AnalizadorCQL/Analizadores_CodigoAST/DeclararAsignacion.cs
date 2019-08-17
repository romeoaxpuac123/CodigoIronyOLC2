using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class DeclararAsignacion : NodoAbstracto
    {
        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado declararasiganar");
        }
        public DeclararAsignacion(String Valor) : base(Valor)
        {

        }
        public override string Ejecutar(Entorno entorno)
        {
            String tipo = this.Hijos[0].Nombre;
            String id = this.Hijos[1].Nombre;
            String valor = this.Hijos[2].Ejecutar(entorno);
            entorno.Agregar(id, tipo, valor);
            return "";
        }
    }
}