using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class FUNCIONES : NodoAbstracto
    {
        public FUNCIONES(String Nombre) : base(Nombre)
        {

        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion CREACON DE FUNCIONES");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion CREACON DE FUNCIONES");

            String tipoFuncion = this.Hijos[0].Nombre;
            String NombreFuncion = this.Hijos[1].Nombre;
            int NumeroFuncion = entorno.CantidadDeFunciones() + 1;
            String IdFuncion = "BRAY-FUNC" + NumeroFuncion.ToString();

            System.Diagnostics.Debug.WriteLine("Tipo FUNCIONE " + tipoFuncion);
            System.Diagnostics.Debug.WriteLine("Nombre FUNCIONE " + NombreFuncion);
            System.Diagnostics.Debug.WriteLine("Numero FUNCIONE " + NumeroFuncion);
            System.Diagnostics.Debug.WriteLine("id FUNCIONE " + IdFuncion);
            entorno.AgregarFuncion(IdFuncion, NombreFuncion, tipoFuncion, ListaID1);
            entorno.MostrarFunciones();


            return "FUNCIONUSUARIO";
        }
    }
}