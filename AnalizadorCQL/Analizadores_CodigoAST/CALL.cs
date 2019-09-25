using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class CALL:NodoAbstracto
    {
        public CALL(String Valor) : base(Valor)
        {

        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado CALL");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado CALL");
            String NombreProcedimiento = this.Hijos[0].Nombre;


            System.Diagnostics.Debug.WriteLine("nombre proc-->" + NombreProcedimiento);
            System.Diagnostics.Debug.WriteLine("part proc-->" + this.ListaID1.Count);
            if (entorno.ExisteProcedimiento(NombreProcedimiento) == true)
            {
                //vamos a ver si existen las variables
                for(int i = 0; i< this.ListaID1.Count; i++)
                {
                    System.Diagnostics.Debug.WriteLine("nombre proc-->" + this.ListaID1[i]);
                    if (entorno.ExisteVariable(this.ListaID1[i]) == false)
                    {
                        return "#ERROR una de las variables del call no existe";
                    }
                    
                }
                //procedimientos para ver si el procedimiento cumple con los parametros
                Boolean MismaCantidadDeParametros = entorno.ExisteListaConLaMismaCantidadDeParametrosEnProc(NombreProcedimiento , this.ListaR1.Count);
                //tIENE LA MISMA CANTIDAD DE PARAMETROS
                if (MismaCantidadDeParametros == true)
                {
                    List<String> TiposParametros = new List<String>();
                    List<String> ValoresParametros = new List<String>();
                    System.Diagnostics.Debug.WriteLine("MISMA CANTIDAD DE PARAMETROS EN proc" + NombreProcedimiento);

                    for (int i = 0; i < this.ListaR1.Count; i++)
                    {
                        String TipoRetorno = this.ListaR1[i];
                        System.Diagnostics.Debug.WriteLine(this.ListaR1[i]);
                        /// verificando el tipo de cada uno de los elementos y se agregará a una lista
                        if (TipoRetorno.ToUpper().Contains("NUMERO"))
                        {
                            ValoresParametros.Add(this.ListaR1[i].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (Keyword)", "").Replace(" (cadena)", ""));
                            TipoRetorno = "int";
                        }
                        else if (TipoRetorno.ToUpper().Contains("DECIMAL"))
                        {
                            TipoRetorno = "double";
                            ValoresParametros.Add(this.ListaR1[i].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (Keyword)", "").Replace(" (cadena)", ""));

                        }
                        else if (TipoRetorno.ToUpper().Contains("CADENA"))
                        {
                            TipoRetorno = "String";
                            ValoresParametros.Add(this.ListaR1[i].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (Keyword)", "").Replace(" (cadena)", ""));

                        }
                        else if (TipoRetorno.ToUpper().Contains("(KEYWORD)") && (TipoRetorno.ToUpper().Contains("TRUE") || TipoRetorno.ToUpper().Contains("FALSE")))
                        {
                            TipoRetorno = "Booleano";
                            ValoresParametros.Add(this.ListaR1[i].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (Keyword)", "").Replace(" (cadena)", ""));

                        }
                        else if (TipoRetorno.ToUpper().Contains("FECHAS"))
                        {
                            TipoRetorno = "Date";
                            ValoresParametros.Add(this.ListaR1[i].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (Keyword)", "").Replace(" (cadena)", ""));

                        }
                        else if (TipoRetorno.ToUpper().Contains("HORA"))
                        {
                            TipoRetorno = "Time";
                            ValoresParametros.Add(this.ListaR1[i].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (Keyword)", "").Replace(" (cadena)", ""));

                        }
                        else if (TipoRetorno.ToUpper().Contains("(ID2)"))
                        {
                            TipoRetorno = entorno.ObtenerTipo(TipoRetorno.Replace(" (id2)", ""));
                            ValoresParametros.Add(entorno.ObtenerValor(this.ListaR1[i].Replace(" (id2)", "")));
                        }

                        TiposParametros.Add(TipoRetorno.Replace(" ", ""));
                    }
                    Boolean MismosParametros = entorno.MismosParametros2Proc(NombreProcedimiento, TiposParametros);
                   
                    if (MismosParametros == true)
                    {
                        List<String> Listaxx = new List<String>();
                        Listaxx = entorno.MismosParametros3Proc(NombreProcedimiento, TiposParametros);
                        Entorno Xx = new Entorno();

                        //Xx = entorno;
                        for (int i = 0; i < Listaxx.Count; i++)
                        {
                            string[] separadasx;
                            separadasx = Listaxx[i].Split('*');
                            System.Diagnostics.Debug.WriteLine("Tipo: " + separadasx[0] + " Nombre: " + separadasx[1] + " Valor: " + ValoresParametros[i]);
                            Xx.Agregar(separadasx[1], separadasx[0], ValoresParametros[i]);
                        }
                        NodoAbstracto Nodo = entorno.ElNodoParametrosProc(NombreProcedimiento , TiposParametros);
                        System.Diagnostics.Debug.WriteLine("ROMEOLOG" + Listaxx .Count);
                        String valor1 = "";
                        String Retorno = "";
                        entorno.NuevasFunciones(Xx);
                        entorno.NuevasVariables(Xx);
                        //foreach (NodoAbstracto sentencia in Nodo.Hijos)
                        for (int pu = 0; pu < Nodo.Hijos.Count;pu++)
                        {
                            ///Espacio para Agregar variables
                            

                            valor1 = Nodo.Hijos[pu].Ejecutar(Xx);
                            if (valor1.Contains("#Error") == true)
                            {
                                System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                return valor1;
                                //return "#Error";
                            }
                            if (valor1.Contains("RETORNO:") == true)
                            {
                                System.Diagnostics.Debug.WriteLine("cahiasdjfiassssssssssssssssssssss");
                                Retorno = valor1;
                                break;
                            }

                        }

                        ///eliminar funciones

                        System.Diagnostics.Debug.WriteLine("valor retorno: " + Retorno);
                        Retorno = Retorno.TrimEnd('?').Replace("RETORNO:","");
                        string[] separadasX;
                        separadasX = Retorno.Split('?');

                        if (separadasX.Length != this.ListaID1.Count)
                        {
                            System.Diagnostics.Debug.WriteLine("#ERROR EN PROC RETORNOS NO COINCIDEN EN CATIDAD");
                            return "#ERROR EN PROC123 "+ NombreProcedimiento +"RETORNOS NO COINCIDEN EN CATIDAD";
                        }
                        else
                        {
                            
                            for (int i = 0; i < separadasX.Length; i++)
                            {
                                string[] separadasXy;
                                separadasXy = separadasX[i].Split(',');
                                System.Diagnostics.Debug.WriteLine(this.ListaID1[i]+ "#Retorno" + separadasXy[1]);
                                String eltipo = entorno.ObtenerTipo(this.ListaID1[i]);
                                if (eltipo.ToUpper().Contains(separadasXy[1].ToUpper()) == false)
                                {
                                  return "#ERROR EN PROC123 RETORNOS NO COINCIDEN EN tipo";
                                }

                            }
                            //codigo para asignar variables
                            System.Diagnostics.Debug.WriteLine("VAMOOOOOOOOOS ASIGNAR");
                            for (int i = 0; i < separadasX.Length; i++)
                            {
                                string[] separadasXy;
                                separadasXy = separadasX[i].Split(',');
                                System.Diagnostics.Debug.WriteLine(this.ListaID1[i] + "#Retorno" + separadasXy[0]);
                                String eltipo = entorno.ObtenerTipo(this.ListaID1[i]);
                               
                                    entorno.AsignarValor(this.ListaID1[i], separadasXy[0]);
                                

                            }

                        }

                    }
                    else
                    {

                    }
                }
                else
                {
                    return "#ERROR111 NumberReturnsException: " + NombreProcedimiento + " la cantidad de variables de retorno no coincide con la cantidad de retornos ";
                }




            }
            else
            {
                return "#ERROR PROC123 "+ NombreProcedimiento+" NO EXISTENTE";
            }
            return "CALL";
        }
    }
}