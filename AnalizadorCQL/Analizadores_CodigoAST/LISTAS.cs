﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class LISTAS : NodoAbstracto
    {
        public LISTAS(String Valor) : base(Valor)
        {

        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado listas");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado listas");

            if(AutoIncrmentable2 == 88)
            {
                String NombreLista = this.Hijos[0].Nombre.ToString();
                String TipoLista = this.Hijos[1].Nombre.ToString();

                System.Diagnostics.Debug.WriteLine("NOMBRE " + NombreLista);
                System.Diagnostics.Debug.WriteLine("TIPO: " + TipoLista);
                Boolean Existencia = false;
                if (this.TipoDato == "SET")
                {
                    Existencia = entorno.Agregar(NombreLista.Replace(" (id2)", ""), TipoLista.Replace(" (Keyword)", ""),"SETBRAY");

                }
                else
                {
                    Existencia = entorno.Agregar(NombreLista.Replace(" (id2)", ""), TipoLista.Replace(" (Keyword)",""), "LISTBRAY");

                }
                 if (Existencia == false)
                {
                    return "#ERROR LISTA YA EXISTENTE";
                }
                else {
                    System.Diagnostics.Debug.WriteLine("lista exitosa");
                }



            }
            if (AutoIncrmentable2 == 99)
            {
                System.Diagnostics.Debug.WriteLine("PARAMETROS" + ListaID1[0]);
                String nOMBRE = this.Hijos[0].Nombre.Replace(" (id2)", "");
                String gorra = ListaID1[0].Replace(" (id2)", "");
                String tipolista = "lista";
                Boolean iguales = true;
                if (this.ListaID1[0].Contains("(id2)"))
                {
                    tipolista = entorno.ObtenerTipo(gorra);
                }
                else
                {
                    if (ListaID1[0].ToUpper().Contains("(CADENA)"))
                    {
                        tipolista = "STRING";
                    }
                    else if (ListaID1[0].ToUpper().Contains("(NUMERO)")) {
                        tipolista = "INT";
                    }
                    else if (ListaID1[0].ToUpper().Contains("(NUMDECIMAL)"))
                    {
                        tipolista = "DOUBLE";
                    }
                    else if (ListaID1[0].ToUpper().Contains("(KEYWORD)") && ((ListaID1[0].ToUpper().Contains("TRUE"))|| (ListaID1[0].ToUpper().Contains("FALSE"))))
                    {
                        tipolista = "BOOLEANO";
                    }
                    else if (ListaID1[0].ToUpper().Contains("(FECHAS)"))
                    {
                        tipolista = "DATE";
                    }
                    else if (ListaID1[0].ToUpper().Contains("(HORA)"))
                    {
                        tipolista = "TIME";
                    }
                }

                System.Diagnostics.Debug.WriteLine("TIPO PAR1" + tipolista);
                for (int i= 0; i < ListaID1.Count; i++)
                {
                    String gorrax = ListaID1[i].Replace(" (id2)", "");
                    String tipolistax = "lista";
                    if (this.ListaID1[0].Contains("(id2)"))
                    {
                        tipolistax = entorno.ObtenerTipo(gorra);
                    }
                    else
                    {
                        if (ListaID1[i].ToUpper().Contains("(CADENA)"))
                        {
                            tipolistax = "STRING";
                        }
                        else if (ListaID1[i].ToUpper().Contains("(NUMERO)"))
                        {
                            tipolistax = "INT";
                        }
                        else if (ListaID1[i].ToUpper().Contains("(NUMDECIMAL)"))
                        {
                            tipolistax = "DOUBLE";
                        }
                        else if (ListaID1[i].ToUpper().Contains("(KEYWORD)") && ((ListaID1[0].ToUpper().Contains("TRUE")) || (ListaID1[0].ToUpper().Contains("FALSE"))))
                        {
                            tipolistax = "BOOLEANO";
                        }
                        else if (ListaID1[i].ToUpper().Contains("(FECHAS)"))
                        {
                            tipolistax = "DATE";
                        }
                        else if (ListaID1[i].ToUpper().Contains("(HORA)"))
                        {
                            tipolistax = "TIME";
                        }
                    }
                    if(tipolistax != tipolista)
                    {
                        iguales = false;
                    }
                    
                }

                if(iguales == false)
                {
                    System.Diagnostics.Debug.WriteLine("ERROR EN PARAMETROS");
                    return "#ERROR LISTA PARAMETROS DIFERENTES";
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("CREAR LISTA");
                    if (this.TipoDato == "SET")
                    {
                        entorno.Agregar(nOMBRE, tipolista, "SET");
                    }
                    else
                    {
                        entorno.Agregar(nOMBRE, tipolista, "LISTA");
                    }
                   
                    for(int i = 0; i < ListaID1.Count; i++)
                    {
                        String NOmbrx = ListaID1[i].ToString().Replace(" (id2)", "").Replace(" (Keyword)", "").Replace(" (cadena)", "").Replace(" (id)", "").Replace(" (numero)", "").Replace(" (numdecimal)", "").Replace(" (Fechas)", "").Replace(" (hora)", "");
                    entorno.AgregarLista(nOMBRE, NOmbrx);
                    }
                   
                    entorno.Mostrar(nOMBRE);
                }

            }

            if (AutoIncrmentable2 == 22)
            {
                //declarando lista
                String NombreLista = this.Hijos[0].Nombre.ToString();

                System.Diagnostics.Debug.WriteLine("NOMBRE " + NombreLista);
                Boolean Existencia = false;
                if (this.TipoDato == "SET")
                {
                    Existencia = entorno.Agregar(NombreLista.Replace(" (id2)", ""), "nulo", "SET");
                }
                else{
                     Existencia = entorno.Agregar(NombreLista.Replace(" (id2)", ""), "nulo", "LISTA");
                }
                
                if (Existencia == false)
                {
                    return "#ERROR LISTA YA EXISTENTE";
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("lista exitosa");
                }
            }

            if (AutoIncrmentable2 == 33)
            {
               

                System.Diagnostics.Debug.WriteLine("PARAMETROS" + ListaID1[0]);
                String nOMBRE = this.Hijos[0].Nombre.Replace(" (id2)", "");
                String gorra = ListaID1[0].Replace(" (id2)", "");
                String tipolista = "lista";
                Boolean iguales = true;
                if (this.ListaID1[0].Contains("(id2)"))
                {
                    tipolista = entorno.ObtenerTipo(gorra);
                }
                else
                {
                    if (ListaID1[0].ToUpper().Contains("(CADENA)"))
                    {
                        tipolista = "STRING";
                    }
                    else if (ListaID1[0].ToUpper().Contains("(NUMERO)"))
                    {
                        tipolista = "INT";
                    }
                    else if (ListaID1[0].ToUpper().Contains("(NUMDECIMAL)"))
                    {
                        tipolista = "DOUBLE";
                    }
                    else if (ListaID1[0].ToUpper().Contains("(KEYWORD)") && ((ListaID1[0].ToUpper().Contains("TRUE")) || (ListaID1[0].ToUpper().Contains("FALSE"))))
                    {
                        tipolista = "BOOLEANO";
                    }
                    else if (ListaID1[0].ToUpper().Contains("(FECHAS)"))
                    {
                        tipolista = "DATE";
                    }
                    else if (ListaID1[0].ToUpper().Contains("(HORA)"))
                    {
                        tipolista = "TIME";
                    }
                }

                System.Diagnostics.Debug.WriteLine("TIPO PAR1" + tipolista);
                for (int i = 0; i < ListaID1.Count; i++)
                {
                    String gorrax = ListaID1[i].Replace(" (id2)", "");
                    String tipolistax = "lista";
                    if (this.ListaID1[0].Contains("(id2)"))
                    {
                        tipolistax = entorno.ObtenerTipo(gorra);
                    }
                    else
                    {
                        if (ListaID1[i].ToUpper().Contains("(CADENA)"))
                        {
                            tipolistax = "STRING";
                        }
                        else if (ListaID1[i].ToUpper().Contains("(NUMERO)"))
                        {
                            tipolistax = "INT";
                        }
                        else if (ListaID1[i].ToUpper().Contains("(NUMDECIMAL)"))
                        {
                            tipolistax = "DOUBLE";
                        }
                        else if (ListaID1[i].ToUpper().Contains("(KEYWORD)") && ((ListaID1[0].ToUpper().Contains("TRUE")) || (ListaID1[0].ToUpper().Contains("FALSE"))))
                        {
                            tipolistax = "BOOLEANO";
                        }
                        else if (ListaID1[i].ToUpper().Contains("(FECHAS)"))
                        {
                            tipolistax = "DATE";
                        }
                        else if (ListaID1[i].ToUpper().Contains("(HORA)"))
                        {
                            tipolistax = "TIME";
                        }
                    }
                    if (tipolistax != tipolista)
                    {
                        iguales = false;
                    }

                 }
                if (iguales == false)
                {
                    System.Diagnostics.Debug.WriteLine("ERROR EN PARAMETROS");
                    return "#ERROR LISTA PARAMETROS DIFERENTES";
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("CREAR LISTA");
                    entorno.EliminarVariable(nOMBRE);
                    if(this.TipoDato == "SET")
                    {
                        entorno.Agregar(nOMBRE, tipolista, "SET");
                    }
                    else
                    {
                        entorno.Agregar(nOMBRE, tipolista, "LISTA");
                    }
                    for (int i = 0; i < ListaID1.Count; i++)
                    {
                        String NOmbrx = ListaID1[i].ToString().Replace(" (id2)", "").Replace(" (Keyword)", "").Replace(" (cadena)", "").Replace(" (id)", "").Replace(" (numero)", "").Replace(" (numdecimal)", "").Replace(" (Fechas)", "").Replace(" (hora)", "");
                        entorno.AgregarLista(nOMBRE, NOmbrx);
                    }

                    entorno.Mostrar(nOMBRE);
                }

            }


            if (AutoIncrmentable2 ==101)
            {
                String NombreListax = this.Hijos[0].Nombre.ToString().Replace(" (id2)", "");
                String TipoLista = this.Hijos[1].Nombre.ToString().Replace(" (Keyword)","");

                System.Diagnostics.Debug.WriteLine("NOMBREx " + NombreListax);
                System.Diagnostics.Debug.WriteLine("TIPOx: " + TipoLista);
                String tipoxxxxxx = entorno.ObtenerTipo(NombreListax);
                if (tipoxxxxxx.ToUpper().Contains("NUL") == true)
                {
                    entorno.EliminarVariable(NombreListax);
                    Boolean Existencia = entorno.Agregar(NombreListax.Replace(" (id2)", ""), "LISTABRAY", TipoLista.Replace(" (Keyword)", ""));
                    if (Existencia == false)
                    {
                        return "#ERROR LISTA YA EXISTENTE";
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("lista exitosax");
                    }
                }
                else
                {
                    return "#ERROR LISTA YA INSTANCIADA";
                }


            }

            if(this.TipoDato == "SET")
            {
                System.Diagnostics.Debug.WriteLine("lista exitosax nombre" + this.Hijos[0].Nombre.ToString());
                String tipo = entorno.ObtenerTipo(this.Hijos[0].Nombre.ToString());
                System.Diagnostics.Debug.WriteLine("lista exitosax tipo" + tipo);
                entorno.ordenarlista(this.Hijos[0].Nombre.ToString(), tipo);
                entorno.EliminarRepetidos(this.Hijos[0].Nombre.ToString());
                entorno.Mostrar(this.Hijos[0].Nombre.ToString());
            }
            return "LISTAS";
        }
    }
}