using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class PROCEDIMIENTOS:NodoAbstracto
    {
        public PROCEDIMIENTOS(String Nombre) : base(Nombre)
        {

        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion CREACON DEROCEDIIENTS");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion CREACON DEROCEDIIENTS");
            //PROCEDIMIENTO SIN PARAMETROS NI FUNCIONES
          
                  String NombreProcedimiento = this.Hijos[0].Nombre;
                  int CantidadDeParametros = this.ListaID1.Count;
                  int CantidadDeRetornos = this.ListaR1.Count;
                  String IdProc = "PROC-BRAY" + entorno.CantidadDeProcedimientos();
                  System.Diagnostics.Debug.WriteLine("PROC-NOMBRE " + NombreProcedimiento);
                  System.Diagnostics.Debug.WriteLine("PROC-PARAMETROS " + CantidadDeParametros);
                  System.Diagnostics.Debug.WriteLine("PROC-RETORNOS " + CantidadDeRetornos);
            List<String> Lista1 = new List<String>();
            Lista1 = ListaR1;

            for (int i = 0; i< this.ListaR1.Count ; i++)
            {
                
               
               
                int contador = 0;
                for(int j= 0; j< Lista1.Count; j++)
                {
                    if (Lista1[j] == ListaR1[i])
                    {
                        contador++;
                       
                    }
                }

                if (contador > 1)
                {
                    return "#ERROR EN returnos DE PROCE";
                }

            }


                  if (entorno.ExisteProcedimiento(NombreProcedimiento) == true)
                  {
                //procedimiento Existe por lo cual vamos a revisar sus parametros
                        if (entorno.ExisteListaConLaMismaCantidadDeParametrosEnProc(NombreProcedimiento, this.ListaID1.Count) == true)
                        {
                    //la función tiene la misma cantidad de parametros entonces se procede a ver si son iguales los parametros.
                                if (entorno.MismosParametrosEnProc(NombreProcedimiento,this.ListaID1) == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("PROCEDIMIENTO EXISTENTE");
                                    return "#ERROR EN PARAMETROS DE PROCE";
                                }
                                else
                                {
                                    entorno.AgregarProcedimiento(IdProc, NombreProcedimiento, "PROCEDURE", this.ListaID1, this.ListaR1, this.Hijos[1]);
                                }                        
                        }
                        else
                        {
                            entorno.AgregarProcedimiento(IdProc, NombreProcedimiento, "PROCEDURE", this.ListaID1, this.ListaR1, this.Hijos[1]);

                        }

                  }
                  else
                  {
                      //procedimiento no existe se agrega automaticamente
                      entorno.AgregarProcedimiento(IdProc, NombreProcedimiento, "PROCEDURE", this.ListaID1, this.ListaR1, this.Hijos[1]);
                  }
            entorno.MostrarProcedimientos();
                  
            return "PROCEDIMIENTOS";
        }
    }
}