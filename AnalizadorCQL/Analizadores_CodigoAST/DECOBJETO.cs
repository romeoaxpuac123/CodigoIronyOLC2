using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class DECOBJETO : NodoAbstracto
    {
        public DECOBJETO(String Valor) : base(Valor)
        {
            
        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado DELCARCION OBJETO");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado DELCARCION OBJETO");
            String Objeto  = this.Hijos[0].Nombre.ToString();
            String Variable = this.Hijos[1].Nombre.ToString();
            System.Diagnostics.Debug.WriteLine("Objeto " + Objeto);
            System.Diagnostics.Debug.WriteLine("NombreVariable " + Variable);

            if (entorno.ExisteVariable(Objeto)==true)
            {
                if (entorno.ExisteVariable(Variable) == false)
                {
                    entorno.AgregarObjeto(Variable, "OBJETO_BRAY", null,Objeto);
                }
                else
                {
                    return "#ERROR6 ? Exception: ObjectAlreadyExists: instancia con identificador ya existente. .";
                }

            }
            else
            {
                return "#ERROR6 ? Exception: TypeAlreadyExists: User Type con un nombre no existente.";
            }

            /*
            Boolean ObjetoA = entorno.Agregar(Objeto, "Objeto", "Objeto");
            if  (ObjetoA == true)
            {

                System.Diagnostics.Debug.WriteLine("#Error objeto no existen -> " + Objeto);
                return "#ERROR8 NO EXISTE OBJETO";
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("#VAMOS A DECLARAR -> " + Variable);
                Boolean valorsito = entorno.Agregar(Variable, Objeto, "1");
                if(valorsito == false)
                {
                    System.Diagnostics.Debug.WriteLine("#ERROR7 DECLARACION DE OBJETO YA REALIZADA" + Variable);
                    return "#ERROR7 DECLARACION DE OBJETO YA REALIZADA";
                }
            }
            */
            return "DECOBJETO";
        }
    }
}