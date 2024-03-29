﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class FUN_RETORNO : NodoAbstracto
    {
        public FUN_RETORNO(String Nombre) : base(Nombre)
        {

        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion funCIONES URUAIOAR");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion funCIONES URUAIOAR------" + this.TipoDato + "x---");
            

                    //LA FUCNION SE ENCONTRO
                    //   this.TipoDato = "entero";
                    //   System.Diagnostics.Debug.WriteLine("Ejecucion funCIONES URUAIOAR------" + this.TipoDato);
                         
                              if (this.AutoIncrmentable2 == 54)
                              {
                                  String NombreFuncion = this.Hijos[0].Nombre;
                                  System.Diagnostics.Debug.WriteLine("NOMBRE FUNCION: 54" + NombreFuncion);
                                  NodoAbstracto Acciones = entorno.NodoSinParametros(NombreFuncion);
                                  String Retorno = "";
                System.Diagnostics.Debug.WriteLine("NOMBRE FUNCION: 54->" + Acciones.Hijos.Count);
                
                if (Acciones == null)
                                  {
                                      return "#ERROR101 FUNCION NO EXISTENTE";
                                  }
                                  else
                                  {

                                      String valor1 = "";
                                      Entorno x = new Entorno();
                                    entorno.NuevasFunciones(x);
                                    entorno.NuevasVariables(x);
                                    for (int i = 0; i < Acciones.Hijos.Count;i++)

                                      {
                                          System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                          valor1 = Acciones.Hijos[i].Ejecutar(x);
                                          if (valor1.Contains("#Error") == true)
                                          {
                                              System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                              return "#ERROR101 EN FUNCION";
                                              //return "#Error";
                                          }
                                          if (valor1.Contains("RETORNO:") == true)
                                          {

                                              Retorno = valor1;
                                              break;
                                          }

                                      }
                                     x.AsignarNuevosValores(entorno);
                                  }

                                  System.Diagnostics.Debug.WriteLine("valor retorno: "+ Retorno);

                                  string[] separadas;
                                  separadas = Retorno .Split(',');

                                  string[] separadas2;
                                  separadas2 = separadas[0].Split(':');

                                  string[] separadas3;
                                  separadas3 = separadas[1].Split(':');
                                  String TipoRetorno = separadas3[1];

                                  if (TipoRetorno.ToUpper().Contains("INT"))
                                  {
                                      TipoRetorno = "entero";
                                  }
                                  else if (TipoRetorno.ToUpper().Contains("DOUBLE"))
                                  {
                                      TipoRetorno = "decimal";
                                  }
                                  else if (TipoRetorno.ToUpper().Contains("STRING"))
                                  {
                                      TipoRetorno = "cadena";
                                  }
                                  else if (TipoRetorno.ToUpper().Contains("BOOLEANO"))
                                  {
                                      TipoRetorno = "Booleano";
                                  }
                                  else if (TipoRetorno.ToUpper().Contains("DATE"))
                                  {
                                      TipoRetorno = "Fechas";
                                  }
                                  else if (TipoRetorno.ToUpper().Contains("TIME"))
                                  {
                                      TipoRetorno = "hora";
                                  }



                                  this.TipoDato = TipoRetorno;
                                  return separadas2[1];
                              }

            if(this.AutoIncrmentable2 == 345)
            {
                System.Diagnostics.Debug.WriteLine("VAMOS A BUSCAR LA FUNCION");
                String NombreFuncion = this.Hijos[0].Nombre;
                this.Hijos[0].TipoDato = this.TipoDato;
                System.Diagnostics.Debug.WriteLine("NOMBRE FUNCION Romeo: " + NombreFuncion);
                Boolean MismaCantidadDeParametros = entorno.ExisteListaConLaMismaCantidadDeParametros(NombreFuncion, this.ListaID1.Count);
                entorno.MostrarFunciones();
                List<String> Insulto = new List<String>();
                ///Empiezo 
                ///
                System.Diagnostics.Debug.WriteLine("NOMBRE FUNCIONx:red2 " + NombreFuncion + "->" + MismaCantidadDeParametros +"->" + this.ListaID1.Count);
                if (MismaCantidadDeParametros == true)
                {
                    
                    for (int i = 0; i < this.Parametros.Count; i++)
                    {
                        String valor1 = "";
                        String TipoDatoxd = "";
                        System.Diagnostics.Debug.WriteLine("NOMBRE FUNCION:-------------------------------> " + this.Parametros[i].Ejecutar(entorno) + "->" + i);
                        valor1 = this.Parametros[i].Ejecutar(entorno).Replace(" (numero)","").Replace(" (numdecimal)","");
                        TipoDatoxd = this.Parametros[i].TipoDato;
                        //System.Diagnostics.Debug.WriteLine("TIPO DATO:-" + TipoDatoxd);
                        if (TipoDatoxd == "entero")
                        {
                            valor1 = valor1 + " (numero)";
                        }
                        else if (TipoDatoxd == "decimal")
                        {
                            valor1 = valor1 + " (numdecimal)";
                        }
                        else if (TipoDatoxd == "cadena")
                        {
                            valor1 = valor1 + " (cadena)";
                        }
                        else if (TipoDatoxd == "Booleano")
                        {
                            valor1 = valor1 + " (Keyword)";
                        }
                        else if (TipoDatoxd.Contains("id2"))
                        {

                            String TipoDEId2 = entorno.ObtenerTipo(this.ListaID1[i].Replace(" (id2)",""));
                            
                            System.Diagnostics.Debug.WriteLine("TIPO DATO:--------------" + TipoDEId2);
                            if (TipoDEId2.ToUpper().Contains("INT") == true)
                            {
                                valor1 = valor1 + " (numero)";
                            }
                            else if (TipoDEId2.ToUpper().Contains("DOUBLE") == true)
                            {
                                valor1 = valor1 + " (numdecimal)";
                            }
                            else if (TipoDEId2.ToUpper().Contains("BOOL") == true)
                            {
                                valor1 = valor1 + " (Keyword)";
                            }
                            else if (TipoDEId2.ToUpper().Contains("STRING") == true)
                            {
                                valor1 = valor1 + " (cadena)";
                            }

                        }
                        else
                        {
                            valor1 = valor1 + this.Parametros[i].TipoDato;
                        }
                        

                        Insulto.Add(valor1);

                       

                    }
                    List<String> TiposParametros = new List<String>();
                    List<String> ValoresParametros = new List<String>();
                    for (int i = 0; i < Insulto.Count; i++)
                    {
                        String TipoRetorno = Insulto[i];
                        System.Diagnostics.Debug.WriteLine("ROME PAR->"+ TipoRetorno);
                        

                            /// verificando el tipo de cada uno de los elementos y se agregará a una lista
                            if (TipoRetorno.ToUpper().Contains("NUMERO"))
                            {
                                ValoresParametros.Add(Insulto[i].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (Keyword)", "").Replace(" (cadena)", ""));
                                TipoRetorno = "int";
                            }
                            else if (TipoRetorno.ToUpper().Contains("DECIMAL"))
                            {
                                TipoRetorno = "double";
                                ValoresParametros.Add(Insulto[i].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (Keyword)", "").Replace(" (cadena)", ""));

                            }
                            else if (TipoRetorno.ToUpper().Contains("CADENA"))
                            {
                                TipoRetorno = "String";
                                ValoresParametros.Add(Insulto[i].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (Keyword)", "").Replace(" (cadena)", ""));

                            }
                            else if (TipoRetorno.ToUpper().Contains("(KEYWORD)") && (TipoRetorno.ToUpper().Contains("TRUE") || TipoRetorno.ToUpper().Contains("FALSE")))
                            {
                                TipoRetorno = "Booleano";
                                ValoresParametros.Add(Insulto[i].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (Keyword)", "").Replace(" (cadena)", ""));

                            }
                            else if (TipoRetorno.ToUpper().Contains("FECHAS"))
                            {
                                TipoRetorno = "Date";
                                ValoresParametros.Add(Insulto[i].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (Keyword)", "").Replace(" (cadena)", ""));

                            }
                            else if (TipoRetorno.ToUpper().Contains("HORA"))
                            {
                                TipoRetorno = "Time";
                                ValoresParametros.Add(Insulto[i].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (Keyword)", "").Replace(" (cadena)", ""));

                            }
                            else if (TipoRetorno.ToUpper().Contains("(ID2)"))
                            {
                                TipoRetorno = entorno.ObtenerTipo(TipoRetorno.Replace(" (id2)", ""));
                                ValoresParametros.Add(entorno.ObtenerValor(Insulto[i].Replace(" (id2)", "")));
                            }

                            TiposParametros.Add(TipoRetorno.Replace(" ", ""));
                        
                    }
                    Boolean MismosParametros = entorno.MismosParametros2(NombreFuncion, TiposParametros);
                    System.Diagnostics.Debug.WriteLine("ROMEOLOG" + MismosParametros);
                    if (MismosParametros == true)
                    {
                        //LA FUCNION SE ENCONTRO
                        System.Diagnostics.Debug.WriteLine(NombreFuncion + "ENCONTADA..");
                        //LA FUCNION SE ENCONTRO
                        System.Diagnostics.Debug.WriteLine(NombreFuncion + "ENCONTADA..");
                        // Ahora vamos a Encontrar el tipo y nombre de los parametors junto con sus valores
                        List<String> Listaxx = new List<String>();
                        Listaxx = entorno.MismosParametros3(NombreFuncion, TiposParametros);
                        Entorno Xx = new Entorno();

                        //Xx = entorno;
                        for (int i = 0; i < Listaxx.Count; i++)
                        {
                            string[] separadasx;
                            separadasx = Listaxx[i].Split('*');
                            System.Diagnostics.Debug.WriteLine("Tipo: " + separadasx[0] + " Nombre: " + separadasx[1] + " Valor: " + ValoresParametros[i]);
                            Xx.Agregar(separadasx[1], separadasx[0], ValoresParametros[i]);
                        }
                        NodoAbstracto Nodo = entorno.ElNodoParametros(NombreFuncion, TiposParametros);

                        String valor1 = "";
                        String Retorno = "";
                        entorno.NuevasFunciones(Xx);
                        entorno.NuevasVariables(Xx);

                        for(int u = 0; u < Nodo.Hijos.Count; u++)

                        {
                            System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if de funretorno");
                            valor1 = Nodo.Hijos[u].Ejecutar(Xx);
                            if (valor1.Contains("#Error") == true)
                            {
                                System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                return "#ERROR101 EN FUNCION";
                                //return "#Error";
                            }
                            if (valor1.Contains("RETORNO:") == true)
                            {
                                System.Diagnostics.Debug.WriteLine("cahiasdjfiassssssssssssssssssssss");
                                Retorno = valor1;
                                break;
                            }

                        }
                        System.Diagnostics.Debug.WriteLine("valor retorno: " + Retorno);

                        string[] separadas;
                        separadas = Retorno.Split(',');

                        string[] separadas2;
                        separadas2 = separadas[0].Split(':');

                        string[] separadas3;
                        separadas3 = separadas[1].Split(':');
                        String TipoRetorno = separadas3[1];
                        String TipoRetornox = "";
                        if (TipoRetorno.ToUpper().Contains("INT"))
                        {
                            TipoRetornox = "entero";
                        }
                        else if (TipoRetorno.ToUpper().Contains("DOUBLE"))
                        {
                            TipoRetornox = "decimal";
                        }
                        else if (TipoRetorno.ToUpper().Contains("STRING"))
                        {
                            TipoRetornox = "cadena";
                        }
                        else if (TipoRetornox.ToUpper().Contains("BOOLEANO"))
                        {
                            TipoRetornox = "Booleano";
                        }
                        else if (TipoRetornox.ToUpper().Contains("DATE"))
                        {
                            TipoRetornox = "Fechas";
                        }
                        else if (TipoRetorno.ToUpper().Contains("TIME"))
                        {
                            TipoRetornox = "hora";

                        }


                        //this.Nombre == "EXP";
                        this.TipoDato = TipoRetornox;
                        //System.Diagnostics.Debug.WriteLine("Ejecucion funCIONES URUAIOAR------" + this.TipoDato);
                        Xx.AsignarNuevosValores(entorno);
                        return separadas2[1];
                    }
                    else
                    {
                        return "#ERROR103 LA FUNCION NO SE ENCONTRO";
                    }
                        

                }
                else
                {
                    return "#ERROR103 LA FUNCIÓN A UTILIZAR NO EXISTE";
                }
                /*
                for (int i = 0; i < this.Parametros.Count; i++)
                {
                    System.Diagnostics.Debug.WriteLine("NOMBRE FUNCION: " + this.Parametros[i].Nombre +"->" + i);
                    String valor1 = "";
                    String Retorno = "";
                    String TipoDatoxd = "";
                   
                    /*
                     * foreach (NodoAbstracto sentencia in this.Parametros[i].Hijos)

                    {

                        TipoDatoxd = sentencia.TipoDato;
                        valor1 = sentencia.Ejecutar(entorno);
                        if (valor1.Contains("#Error") == true)
                        {
                            
                            return "#ERROR EN FUNCION";
                            //return "#Error";
                        }
                        if (valor1.Contains("RETORNO:") == true)
                        {
                            System.Diagnostics.Debug.WriteLine("cahiasdjfiassssssssssssssssssssss");
                            Retorno = valor1;
                            break;
                        }

                    }
                    System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if valor->" + valor1 + " Tipo->"+TipoDatoxd);
                    if(TipoDatoxd == "entero")
                    {
                        valor1 = valor1 + " (numero)";
                    }
                    else if (TipoDatoxd == "decimal")
                    {
                        valor1 = valor1 + " (numdecimal)";
                    }
                    else if (TipoDatoxd == "cadena")
                    {
                        valor1 = valor1 + " (cadena)";
                    }
                    else if (TipoDatoxd == "Booleano")
                    {
                        valor1 = valor1 + " (Keyword)";
                    }
                    else if (TipoDatoxd == "id2")
                    {
                        valor1 = valor1 + " (numero)";
                    }
                    else
                    {
                        valor1 = valor1 + " (" + TipoDatoxd + ")";
                    }

                    this.ListaID1.Add(valor1);
                    
                }
            

                //termiano

                /*

                System.Diagnostics.Debug.WriteLine("NOMBRE FUNCION: saflog" + this.ListaID1.Count);
                if (MismaCantidadDeParametros == true)
                {
                    List<String> TiposParametros   = new List<String>();
                    List<String> ValoresParametros = new List<String>();
                    System.Diagnostics.Debug.WriteLine("MISMA CANTIDAD DE PARAMETROS EN FUNCION" + NombreFuncion);

                    for (int i = 0; i<this.ListaID1.Count; i++)
                    {
                        String TipoRetorno = this.ListaID1[i];
                        System.Diagnostics.Debug.WriteLine(this.ListaID1[i]);
                        /// verificando el tipo de cada uno de los elementos y se agregará a una lista
                        if (TipoRetorno.ToUpper().Contains("NUMERO"))
                        {
                            ValoresParametros.Add(this.ListaID1[i].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (Keyword)","").Replace(" (cadena)", ""));
                            TipoRetorno = "int";
                        }
                        else if (TipoRetorno.ToUpper().Contains("DECIMAL"))
                        {
                            TipoRetorno = "double";
                            ValoresParametros.Add(this.ListaID1[i].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (Keyword)", "").Replace(" (cadena)", ""));

                        }
                        else if (TipoRetorno.ToUpper().Contains("CADENA"))
                        {
                            TipoRetorno = "String";
                            ValoresParametros.Add(this.ListaID1[i].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (Keyword)", "").Replace(" (cadena)", ""));

                        }
                        else if (TipoRetorno.ToUpper().Contains("(KEYWORD)")&& (TipoRetorno.ToUpper().Contains("TRUE")|| TipoRetorno.ToUpper().Contains("FALSE")) )
                        {
                            TipoRetorno = "Booleano";
                            ValoresParametros.Add(this.ListaID1[i].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (Keyword)", "").Replace(" (cadena)", ""));

                        }
                        else if (TipoRetorno.ToUpper().Contains("FECHAS"))
                        {
                            TipoRetorno = "Date";
                            ValoresParametros.Add(this.ListaID1[i].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (Keyword)", "").Replace(" (cadena)", ""));

                        }
                        else if (TipoRetorno.ToUpper().Contains("HORA"))
                        {
                            TipoRetorno = "Time";
                            ValoresParametros.Add(this.ListaID1[i].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (Keyword)", "").Replace(" (cadena)",""));

                        }
                        else if (TipoRetorno.ToUpper().Contains("(ID2)"))
                        {
                            TipoRetorno = entorno.ObtenerTipo(TipoRetorno.Replace(" (id2)", ""));
                            ValoresParametros.Add(entorno.ObtenerValor(this.ListaID1[i].Replace(" (id2)", "")));
                        }

                        TiposParametros.Add(TipoRetorno.Replace(" ",""));
                    }
                    Boolean MismosParametros = entorno.MismosParametros2(NombreFuncion, TiposParametros);
                    System.Diagnostics.Debug.WriteLine("ROMEOLOG" + MismosParametros);
                    if (MismosParametros == true)
                    {
                        //LA FUCNION SE ENCONTRO
                        System.Diagnostics.Debug.WriteLine(NombreFuncion + "ENCONTADA..");
                        // Ahora vamos a Encontrar el tipo y nombre de los parametors junto con sus valores
                        List<String> Listaxx = new List<String>();
                        Listaxx = entorno.MismosParametros3(NombreFuncion, TiposParametros);
                        Entorno Xx = new Entorno();

                        //Xx = entorno;
                        for(int i = 0; i < Listaxx.Count; i++)
                        {
                            string[] separadasx;
                            separadasx = Listaxx[i].Split('*');
                            System.Diagnostics.Debug.WriteLine("Tipo: " + separadasx[0] + " Nombre: " +separadasx[1] + " Valor: "+ValoresParametros[i]);
                            Xx.Agregar(separadasx[1], separadasx[0], ValoresParametros[i]);
                        }
                        NodoAbstracto Nodo = entorno.ElNodoParametros(NombreFuncion, TiposParametros);

                        String valor1 = "";
                        String Retorno = "";
                        entorno.NuevasFunciones(Xx);
                        foreach (NodoAbstracto sentencia in Nodo.Hijos)

                        {
                            System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                            valor1 = sentencia.Ejecutar(Xx);
                            if (valor1.Contains("#Error") == true)
                            {
                                System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                return "#ERROR EN FUNCION";
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

                        string[] separadas;
                        separadas = Retorno.Split(',');

                        string[] separadas2;
                        separadas2 = separadas[0].Split(':');

                        string[] separadas3;
                        separadas3 = separadas[1].Split(':');
                        String TipoRetorno = separadas3[1];
                        String TipoRetornox = "";
                        if (TipoRetorno.ToUpper().Contains("INT"))
                        {
                            TipoRetornox = "entero";
                        }
                        else if (TipoRetorno.ToUpper().Contains("DOUBLE"))
                        {
                            TipoRetornox = "decimal";
                        }
                        else if (TipoRetorno.ToUpper().Contains("STRING"))
                        {
                            TipoRetornox = "cadena";
                        }
                        else if (TipoRetornox.ToUpper().Contains("BOOLEANO"))
                        {
                            TipoRetornox = "Booleano";
                        }
                        else if (TipoRetornox.ToUpper().Contains("DATE"))
                        {
                            TipoRetornox = "Fechas";
                        }
                        else if (TipoRetorno.ToUpper().Contains("TIME"))
                        {
                            TipoRetornox = "hora";

                        }


                        //this.Nombre == "EXP";
                        this.TipoDato = TipoRetornox;
                        //System.Diagnostics.Debug.WriteLine("Ejecucion funCIONES URUAIOAR------" + this.TipoDato);
                        return separadas2[1];

                    }
                    else
                    {
                        return "#ERROR TIPO DE PARAMETROS INCORRECTO";
                    }

                    ///Verificando Si el tipo de Parametros es igual

                }
                else
                {

                    return "#ERROR CANTIDAD DE PARAMETROS INCORRECTO";
                }
                */
                
            }

                  
                    return "FuncionesPropias";
        }
    }
}