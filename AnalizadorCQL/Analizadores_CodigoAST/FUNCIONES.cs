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
            System.Diagnostics.Debug.WriteLine("Mismos Parametros? " + ExistenMismoParametros);


            #region AGREGAR FUNCION

            if (ExisteFuncion == true)
            {
                if (CantidadDeParametrosIguales == true)
                {
                    if (ExistenMismoParametros == true)
                    {
                        return "#ERROR FunctionAlreadyExists: Funcion:" + NombreFuncion + " ya existente";
                    }
                    else
                    {
                        entorno.AgregarFuncion(IdFuncion, NombreFuncion, tipoFuncion, ListaID1, this.Hijos[2]);

                    }
                }
                else
                {
                    entorno.AgregarFuncion(IdFuncion, NombreFuncion, tipoFuncion, ListaID1, this.Hijos[2]);

                }

            }
            else
            {
                entorno.AgregarFuncion(IdFuncion, NombreFuncion, tipoFuncion, ListaID1, this.Hijos[2]);

            }

            #endregion
 


            return "FUNCIONUSUARIO";
        }
       
    }
}