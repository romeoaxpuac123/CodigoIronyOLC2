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
            Entorno x = new Entorno();
            //x = entorno;
            System.Diagnostics.Debug.WriteLine("INICIOES ACCIONES");
            // viendo si los retornos son iguales
            String valor1 = "";
            String Retorno = "";
            Boolean hayr = false;
            entorno.NuevasFunciones(x);
            entorno.NuevasVariables(x);
            for (int i = 0; i < ListaID1.Count; i++)
            {
                string[] separadas;
                separadas = ListaID1[i].Split('*');
                String Valorxxxx = "";
                if (separadas[0].ToUpper().Contains("STRING"))
                {
                    Valorxxxx = " ";
                }
                if (separadas[0].ToUpper().Contains("INT"))
                {
                    Valorxxxx = "0";
                }
                if (separadas[0].ToUpper().Contains("DOUBLE"))
                {
                    Valorxxxx = "2.2";
                }
                if (separadas[0].ToUpper().Contains("BOOLEAN"))
                {
                    Valorxxxx = "false";
                }
                if (separadas[0].ToUpper().Contains("DATE"))
                {
                    Valorxxxx = "'2019-1-1'";
                }
                if (separadas[0].ToUpper().Contains("TIME"))
                {
                    Valorxxxx = "'1::1:1'";
                }
                x.Agregar(separadas[1], separadas[0], Valorxxxx);
            }

            this.Hijos[1].Nombre = "S";
            for(int p = 0; p < this.Hijos[1].Hijos.Count;p++)

            {
               // System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                 System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if frutero" + this.Hijos[1].Hijos[p].Nombre.ToString());
                //valor1 = sentencia.Ejecutar(x);

                if(("RETORNO"== this.Hijos[1].Hijos[p].Nombre.ToString())||
                    ("DECLARARASIGNAR" == this.Hijos[1].Hijos[p].Nombre.ToString())||
                    ("DECLARAR" == this.Hijos[1].Hijos[p].Nombre.ToString())
                    )
                {
                    valor1 = this.Hijos[1].Hijos[p].Ejecutar(x);
                    if (valor1.Contains("RETORNO:") == true)
                    {
                        hayr = true;
                        Retorno = valor1;
                        //Retorno = valor1;

                    }
                    if (valor1.ToUpper().Contains("#ERROR") == true)
                    {
                        System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if" + valor1);

                        return valor1;
                        //return "#Error";
                    }

                }
                

            }
            System.Diagnostics.Debug.WriteLine("FIN ACCIONES" + Retorno);

            Retorno = Retorno.TrimEnd('?');
            string[] separadasX;
            separadasX = Retorno.Split('?');

            if(separadasX.Length != this.ListaR1.Count)
            {
                System.Diagnostics.Debug.WriteLine("#ERROR EN PROC RETORNOS NO COINCIDEN EN CATIDAD");
                return "#ERROR EN PROC123 RETORNOS NO COINCIDEN EN CATIDAD";
            }
            else
            {
               
               for(int i = 0; i< separadasX.Length; i++)
                {
                    string[] separadasXy;
                    separadasXy = separadasX[i].Split(',');
                    System.Diagnostics.Debug.WriteLine("#" + separadasXy[1]);
                    if (this.ListaR1[i].ToUpper().Contains(separadasXy[1].ToUpper())==false){
                        return "#ERROR EN PROC123 RETORNOS NO COINCIDEN EN tipo";
                    }

                }
                

            }


            //verificando que no se repita el nombre de las variables en el retorno
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
                    return "#ERROR111 NumberReturnsException: "+ NombreProcedimiento+" la cantidad de variables de retorno no coincide con la cantidad de retornos ";
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
                                    return "#ERROR111 ProcedureAlreadyExists: procedure"+ NombreProcedimiento +" ya existente";
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