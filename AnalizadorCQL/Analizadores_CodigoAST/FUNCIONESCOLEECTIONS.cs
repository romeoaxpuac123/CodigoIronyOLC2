using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class FUNCIONESCOLEECTIONS : NodoAbstracto
    {
        public FUNCIONESCOLEECTIONS(String Nombre) : base(Nombre)
        {

        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion funpro");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion funpro");
            if (AutoIncrmentable2 == 90)
            {
                String cadena = this.Hijos[0].Nombre;
                string[] separadas;
                separadas = cadena.Split('.');
                String TipoFuncion = separadas[separadas.Length - 1];
                System.Diagnostics.Debug.WriteLine("ES funcion" + TipoFuncion);
                String ElColector = cadena.Replace(TipoFuncion, "").TrimEnd('.');
                System.Diagnostics.Debug.WriteLine("Colector" + ElColector);
                String TipoColector = entorno.ObtenerTipo(ElColector);
                String ValorColector = entorno.ObtenerValor(ElColector);
                System.Diagnostics.Debug.WriteLine("Verificando el tamaño de la lista" + ElColector);
                if (TipoColector == null)
                {
                    return "#ERROR, LISTA NO VALIDA";
                }
                if (entorno.Agregar(ElColector, "list", "list") == false)
                {
                    if (TipoFuncion.ToUpper().Contains("SIZE") == true)
                    {
                        System.Diagnostics.Debug.WriteLine("Verificando el tamaño de la lista" + ElColector + "=" + entorno.TotalLista(ElColector).ToString());
                        this.TipoDato = "entero";
                        return entorno.TotalLista(ElColector).ToString();
                    }
                    else if (TipoFuncion.ToUpper().Contains("CLEAR") == true) {
                        entorno.liMPIARLista(ElColector);
                        System.Diagnostics.Debug.WriteLine("LIMPIANDO  la lista" + ElColector);
                        
                        
                    }
                }
                else
                {
                    return "#ERRORfc, LISTA NO EXISTE " + ElColector;
                }


            }
            else if(this.AutoIncrmentable2 == 9099)
            {
                String cadena = this.Hijos[0].Nombre;
                string[] separadas;
                separadas = cadena.Split('.');
                String TipoFuncion = separadas[separadas.Length - 1];
                System.Diagnostics.Debug.WriteLine("ES funcion" + TipoFuncion);
                String ElColector = cadena.Replace(TipoFuncion, "").TrimEnd('.');
                System.Diagnostics.Debug.WriteLine("Colector" + ElColector);
                String TipoColector = entorno.ObtenerTipo(ElColector);
                String ValorColector = entorno.ObtenerValor(ElColector);
                String TipoVariable = "";
                if (this.Hijos[2].Nombre.Contains("(id2)"))
                {
                    TipoVariable = entorno.ObtenerTipo(this.Hijos[2].Nombre.Replace(" (id2)", ""));
                }
                else
                {
                    if (this.Hijos[2].Nombre.ToUpper().Contains("(CADENA)"))
                    {
                        TipoVariable = "STRING";
                    }
                    else if (this.Hijos[2].Nombre.ToUpper().Contains("(NUMERO)"))
                    {
                        TipoVariable = "INT";
                    }
                    else if (this.Hijos[2].Nombre.ToUpper().Contains("(NUMDECIMAL)"))
                    {
                        TipoVariable = "DOUBLE";
                    }
                    else if (this.Hijos[2].Nombre.ToUpper().Contains("(KEYWORD)") && ((ListaID1[0].ToUpper().Contains("TRUE")) || (ListaID1[0].ToUpper().Contains("FALSE"))))
                    {
                        TipoVariable = "BOOLEANO";
                    }
                    else if (this.Hijos[2].Nombre.ToUpper().Contains("(FECHAS)"))
                    {
                        TipoVariable = "DATE";
                    }
                    else if (this.Hijos[2].Nombre.ToUpper().Contains("(HORA)"))
                    {
                        TipoVariable = "TIME";
                    }
                }
                if (TipoColector == null)
                {
                    return "#ERRORfc, LISTA NO VALIDA " + ElColector;
                }
                String TPOSICION = "";
                if (this.Hijos[1].Nombre.Contains("(id2)"))
                {
                    TPOSICION = entorno.ObtenerTipo(this.Hijos[1].Nombre.Replace(" (id2)", ""));
                }
                else if(this.Hijos[1].Nombre.ToUpper().Contains("(NUMERO)"))
                    {
                    TPOSICION = this.Hijos[1].Nombre.Replace(" (numero)","");
                }
                if(int.Parse(TPOSICION) > 0)
                {
                    System.Diagnostics.Debug.WriteLine("MODIFICANDO UN ELEMENTO DE LA LISTA" + ElColector);
                    if (entorno.Agregar(ElColector, "", "")==false)
                    {
                        entorno.MODIFICARLista(ElColector, int.Parse(TPOSICION), this.Hijos[2].Nombre.Replace(" (id2)", "").Replace(" (Keyword)", "").Replace(" (cadena)", "").Replace(" (id)", "").Replace(" (numero)", "").Replace(" (numdecimal)", "").Replace(" (Fechas)", "").Replace(" (hora)", ""));
                    }
                    else
                    {
                        return "#ERRORfc , LA LISTA NO EXISTE " + ElColector;
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("el inidice MODIFICANDO UN ELEMENTO DE LA LISTA es error" + ElColector);
                    return "#ERRORfc, INDICE MAL PUESTO en " + ElColector;
                }
                
            }
            else if (this.Hijos[1].Nombre == ".")
            {
                //System.Diagnostics.Debug.WriteLine("ES funcion");
                String cadena = this.Hijos[0].Nombre;
                string[] separadas;
                separadas = cadena.Split('.');
                String TipoFuncion = separadas[separadas.Length - 1];
                System.Diagnostics.Debug.WriteLine("ES funcion" + TipoFuncion);
                String ElColector = cadena.Replace(TipoFuncion, "").TrimEnd('.');
                System.Diagnostics.Debug.WriteLine("Colector" + ElColector);
                String TipoColector = entorno.ObtenerTipo(ElColector);
                String ValorColector = entorno.ObtenerValor(ElColector);
                String TipoVariable = "";
                System.Diagnostics.Debug.WriteLine("insertar" + ValorColector);
                if (TipoColector == null)
                {
                    return "#ERRORfc, LISTA NO VALIDA " + ElColector;
                }

               
                if (this.Hijos[2].Nombre.Contains("(id2)"))
                {
                    TipoVariable = entorno.ObtenerTipo(this.Hijos[2].Nombre.Replace(" (id2)",""));
                }
                else
                {
                    if (this.Hijos[2].Nombre.ToUpper().Contains("(CADENA)"))
                    {
                        TipoVariable = "STRING";
                    }
                    else if (this.Hijos[2].Nombre.ToUpper().Contains("(NUMERO)"))
                    {
                        TipoVariable = "INT";
                    }
                    else if (this.Hijos[2].Nombre.ToUpper().Contains("(NUMDECIMAL)"))
                    {
                        TipoVariable = "DOUBLE";
                    }
                    else if (this.Hijos[2].Nombre.ToUpper().Contains("(KEYWORD)") && ((this.Hijos[2].Nombre.ToUpper().Contains("TRUE")) || (this.Hijos[2].Nombre.ToUpper().Contains("FALSE"))))
                    {
                        TipoVariable = "BOOLEAN";
                    }
                    else if (this.Hijos[2].Nombre.ToUpper().Contains("(FECHAS)"))
                    {
                        TipoVariable = "DATE";
                    }
                    else if (this.Hijos[2].Nombre.ToUpper().Contains("(HORA)"))
                    {
                        TipoVariable = "TIME";
                    }
                    System.Diagnostics.Debug.WriteLine("insertarX" + ValorColector);
                }
                if (TipoColector == null)
                {
                    return "#ERRORfc, LISTA NO VALIDA " + ElColector;
                }
                if (TipoFuncion.ToUpper().Contains("INSERT"))
                {
                    //CODIGO PARA INSIERTAR EN UNA LISTA
                    if (ValorColector.ToUpper().Contains("LIST"))
                    {
                        System.Diagnostics.Debug.WriteLine("ES UNA LISTA>" + TipoColector + "tv>" + TipoVariable);
                        if(TipoColector == null)
                        {
                            return "#ERRORfc, LISTA NO VALIDA " + ElColector;
                        }
                        else if (TipoColector.ToUpper() == TipoVariable.ToUpper())
                        {
                            entorno.AgregarLista(ElColector, this.Hijos[2].Nombre.Replace(" (id2)", "").Replace(" (Keyword)", "").Replace(" (cadena)", "").Replace(" (id)", "").Replace(" (numero)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (hora)", ""));
                        }
                        else
                        {
                            return "#ERRORfc, PARAMETROS DIFERENTES en " + ElColector;
                        }
                        entorno.Mostrar(ElColector);

                    }
                    else if (ValorColector.ToUpper().Contains("SET")) {
                        System.Diagnostics.Debug.WriteLine("ES UNA SET>" + TipoColector + "tv>" + TipoVariable);
                        if (TipoColector == null)
                        {
                            return "#ERRORfc, LISTA NO VALIDA " + ElColector;
                        }
                        else if(TipoColector.ToUpper() == TipoVariable.ToUpper())
                        {
                            entorno.Mostrar(ElColector);
                            entorno.AgregarLista(ElColector, this.Hijos[2].Nombre.Replace(" (id2)", "").Replace(" (Keyword)", "").Replace(" (cadena)", "").Replace(" (id)", "").Replace(" (numero)", "").Replace(" (numdecimal)", "").Replace(" (Fechas)", "").Replace(" (hora)", ""));
                            System.Diagnostics.Debug.WriteLine("redmi2>");
                            entorno.ordenarlista(ElColector, TipoVariable);
                            entorno.EliminarRepetidos(ElColector);
                            entorno.Mostrar(ElColector);
                        }
                        else
                        {
                            return "#ERRORfc, PARAMETROS DIFERENTES en " + ElColector;
                        }
                        entorno.Mostrar(ElColector);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("VARIABLE NO ES COLECTION");
                        return "#ERRORfc no es colecto " + ElColector; ;
                    }


                }
                else if (TipoFuncion.ToUpper().Contains("GET"))
                {
                    //CODIGO PARA GET EN UNA LISTA
                    if (TipoColector == null)
                    {
                        return "#ERRORfc, LISTA NO VALIDA " + ElColector; ;
                    }
                    
                    
                    entorno.Mostrar(ElColector);
                    System.Diagnostics.Debug.WriteLine("El elemento es: en la pos:" + entorno.PosicionLista2(ElColector, Int32.Parse(this.Hijos[2].Nombre.Replace(" (id2)", "").Replace(" (Keyword)", "").Replace(" (cadena)", "").Replace(" (id)", "").Replace(" (numero)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (hora)", ""))));

                    return entorno.PosicionLista2(ElColector,Int32.Parse( this.Hijos[2].Nombre.Replace(" (id2)", "").Replace(" (Keyword)", "").Replace(" (cadena)", "").Replace(" (id)", "").Replace(" (numero)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (hora)", "")));
                }
                if (TipoFuncion.ToUpper().Contains("REMOVE"))
                {
                    //CODIGO PARA REMOVER EN UNA LISTA
                    if (TipoColector == null)
                    {
                        return "#ERRORfc, LISTA NO VALIDA " + ElColector; ;
                    }
                    Boolean borrar =  entorno.RemoverLista(ElColector, this.Hijos[2].Nombre.Replace(" (id2)", "").Replace(" (Keyword)", "").Replace(" (cadena)", "").Replace(" (id)", "").Replace(" (numero)", "").Replace(" (numdecimal)", "").Replace(" (Fechas)", "").Replace(" (hora)", ""));
                    if (borrar==true)
                    {
                        System.Diagnostics.Debug.WriteLine("LA VARIABLE FUE ELIMINADA");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("LA VARIABLE NO EXISTE EN LA LISTA");
                    }
                    entorno.Mostrar(ElColector);
                }
                if (TipoFuncion.ToUpper().Contains("CONTAINS"))
                {
                    if (TipoColector == null)
                    {
                        return "#ERRORfc, LISTA NO VALIDA " + ElColector; ;
                    }
                    //CODIGO PARA CONSTAIN EN UNA LISTA
                    Boolean borrar = entorno.ExisteEnLista(ElColector, this.Hijos[2].Nombre.Replace(" (id2)", "").Replace(" (Keyword)", "").Replace(" (cadena)", "").Replace(" (id)", "").Replace(" (numero)", "").Replace(" (numdecimal)", "").Replace(" (Fechas)", "").Replace(" (hora)", ""));
                    if (borrar == true)
                    {
                        System.Diagnostics.Debug.WriteLine("LA VARIABLE SI EXISTE EN LA LISTA");
                        this.TipoDato = "Booleano";
                        return "true";
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("LA VARIABLE NO EXISTE EN LA LISTA");
                        this.TipoDato = "Booleano";
                        return "false";
                    }

                }



            }
            return "funciones";
        }
    }
}