using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;
using AnalizadorCQL.Analizadores;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class TRY_CATCH : NodoAbstracto
    {
        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado TRY_CATCH");
        }

        public TRY_CATCH(String Valor) : base(Valor)
        {

        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("entro a TRY_CATCH");
            bool ok = false;
            String valor1 = "";
            Entorno entorno1 = new Entorno();
            foreach (NodoAbstracto sentencia in this.Hijos[0].Hijos)
            {
                //System.Diagnostics.Debug.WriteLine("CA:"+sentencia.Hijos[0].Ejecutar(entorno).ToString());
               
                 valor1 = sentencia.Ejecutar(entorno1);
                if (valor1.Contains("#Error")==true){
                    ok = true;
                    break;
                    //return "#Error";
                }
            }
            Entorno entorno2 = new Entorno();
            //System.Diagnostics.Debug.WriteLine((this.Hijos[2].Nombre));
            if (ok == true && (this.Hijos[2].Nombre.Contains("arithmeticexception")==true) )
            {
                foreach (NodoAbstracto sentencia in this.Hijos[1].Hijos)
                {

                    valor1 = sentencia.Ejecutar(entorno2);
                    if (valor1.Contains("#Error") == true)
                    {
                        ok = true;
                        return "#Error";
                        //break;
                    }
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("LA EXCEPCION ES INCORRECTA");
            }

            return "TRY_CATCH";
        }
    }
}