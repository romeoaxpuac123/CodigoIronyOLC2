using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class ELFOR : NodoAbstracto
    {
        public ELFOR(String Valor) : base(Valor)
        {

        
        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado FRO");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado FRO");
            String VariableContador = this.Hijos[0].Hijos[1].Nombre;
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado FRO" + VariableContador);
            Entorno Nuevo = new Entorno();
            entorno.NuevasVariables(Nuevo);
            entorno.NuevasFunciones(Nuevo);
            Boolean elbrak = false;
            this.Hijos[0].Ejecutar(Nuevo);
            while (this.Hijos[1].Ejecutar(Nuevo).ToString().ToUpper().Contains("TRUE") == true)
            {   
                System.Diagnostics.Debug.WriteLine("dentro del while**************+++");
                Entorno Nuevo2 = new Entorno();
                Nuevo.NuevasVariables(Nuevo2);
                String valor1 = "";
                for (int ix = 3; ix < this.Hijos.Count; ix++)
                {
                    valor1 = this.Hijos[ix].Ejecutar(Nuevo2);
                    System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if " + valor1);
                    if (valor1.Contains("BREAK") == true)
                    {
                        //return "BREAK";
                        elbrak = true;
                        break;
                        //return "#Error";
                    }
                    if (valor1.Contains("RETORNO:") == true)
                    {

                        return valor1;
                    }
                    if (valor1.ToUpper().Contains("#ERROR") == true)
                    {

                        return valor1;

                    }
                }
                
                Nuevo2.AsignarNuevosValores(Nuevo);
                this.Hijos[2].Ejecutar(Nuevo);
                if(elbrak == true)
                {
                    break;
                }
            }
            Nuevo.AsignarNuevosValores(entorno);
            System.Diagnostics.Debug.WriteLine("III");

         

            return "FOR";
        }
    }
}