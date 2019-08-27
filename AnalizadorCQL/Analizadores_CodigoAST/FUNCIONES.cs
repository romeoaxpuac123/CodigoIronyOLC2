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
            Boolean ExisteFuncion = entorno.ExisteFuncion(NombreFuncion);
            
            Boolean CantidadDeParametrosIguales = entorno.ExisteListaConLaMismaCantidadDeParametros(NombreFuncion,this.ListaID1.Count);

            Boolean ExistenMismoParametros = entorno.MismosParametros(NombreFuncion, this.ListaID1);

            System.Diagnostics.Debug.WriteLine("bien");
            System.Diagnostics.Debug.WriteLine("Tipo FUNCIONE " + tipoFuncion);
            System.Diagnostics.Debug.WriteLine("Nombre FUNCIONE " + NombreFuncion);
            System.Diagnostics.Debug.WriteLine("Numero FUNCIONE " + NumeroFuncion);
            System.Diagnostics.Debug.WriteLine("id FUNCIONE " + IdFuncion);
            System.Diagnostics.Debug.WriteLine("Existe FUNCIONE? " + ExisteFuncion);
            System.Diagnostics.Debug.WriteLine("Parametros Iguales? " + CantidadDeParametrosIguales);
            //entorno.AgregarFuncion(IdFuncion, NombreFuncion, tipoFuncion, ListaID1);
            //entorno.MostrarFunciones();
            if(ExisteFuncion == true)
            {
                //la funcion ya existe entonces se pasa a revisar las otras condiciones :D
                if(CantidadDeParametrosIguales == true)
                {
                    //la función tiene la misma cantidad de parametros entonces se procede a ver si son iguales los parametros.
                    if(ExistenMismoParametros == true)
                    {
                        System.Diagnostics.Debug.WriteLine("#ERROR EN PARAMETROS DE FUNCION");
                        return "#ERROR EN PARAMETROS DE FUNCION";
                    }
                    else
                    {
                        entorno.AgregarFuncion(IdFuncion, NombreFuncion, tipoFuncion, ListaID1, this.Hijos[2]);
                    }

                }
                else
                {
                    //la función tiene diferente cantidad de parametros
                    entorno.AgregarFuncion(IdFuncion, NombreFuncion, tipoFuncion, ListaID1, this.Hijos[2]);

                }
            }
            else
            {
                //la función no existe así que se agrega todo sin problemas
                entorno.AgregarFuncion(IdFuncion, NombreFuncion, tipoFuncion, ListaID1, this.Hijos[2]);
            }
            entorno.MostrarFunciones();
           /* System.Diagnostics.Debug.WriteLine("PROBANDO ACCIONES");
            this.Hijos[2].Ejecutar(entorno);
            String valor1 = "";
            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos)
            {
                System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                valor1 = sentencia.Ejecutar(entorno);
                if (valor1.Contains("#Error") == true)
                {
                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                    break;
                    //return "#Error";
                }
                if (valor1.Contains("BREAK") == true)
                {
                    return "BREAK";
                    //return "#Error";
                }

            }
            System.Diagnostics.Debug.WriteLine("FIN ACCIONES");
            */
            return "FUNCIONUSUARIO";
        }
    }
}