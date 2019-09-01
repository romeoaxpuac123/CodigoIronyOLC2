using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class ASIGNACIONOBJETOS : NodoAbstracto
    {
        public ASIGNACIONOBJETOS(String Valor) : base(Valor)
        {

        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado ASIGNACION OBJETO");
        }

        public override string Ejecutar(Entorno entorno)
        {
            List<String> Valores = new List<String>();
            for (int i = this.ListaID1.Count-1; i >= 0; i--)
            {
                Valores.Add(this.ListaID1[i]);
            }
            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado DELCARCION-INSTANCIA OBJETO");
            if(this.AutoIncrmentable2 == 9999)
            {
                String Objeto1 = this.Hijos[0].Nombre.ToString().Replace(" (id)","");
                String Objeto2 = this.Hijos[2].Nombre.ToString().Replace(" (id)", "");
                String Variable = this.Hijos[1].Nombre.ToString().Replace(" (id2)", "");

                if (Objeto1 == Objeto2)
                {
                    if (entorno.ExisteVariable(Objeto1) == true)
                    {
                        if (entorno.ExisteVariable(Variable) == false)
                        {
                            List<Simbolo> ListaParametrosUT = entorno.ElementosUT(Objeto1);



                            if (ListaParametrosUT.Count == this.ListaID1.Count)
                            {
                                for (int i = 0; i < ListaParametrosUT.Count; i++)
                                {
                                    //Revisando que los Parametros Cumplan con el Tipo del objeto
                                   // System.Diagnostics.Debug.WriteLine("Nombre: ->" + ListaParametrosUT[i].ObtenerId() + " Tipo-> " + ListaParametrosUT[i].ObtenerTipo() + " Valor-> " + ListaParametrosUT[i].ObtenerValor());
                                   // System.Diagnostics.Debug.WriteLine("Nombrel: ->" + Valores[i]);
                                    //Verificando si tiene }
                                    if (Valores[i].Contains("}") == true)
                                    {
                                        String[] separadas;
                                        separadas = Valores[i].Split('}');
                                        String ElObjeto = separadas[1];
                                        System.Diagnostics.Debug.WriteLine("NOMBRE OBJETO PARAMETRO}: " + ElObjeto.Replace(" (id)", "").Replace("AS", "").Replace(" ", ""));
                                        System.Diagnostics.Debug.WriteLine("NOMBRE OBJETO UT}: " + ListaParametrosUT[i].ObtenerTipo());

                                        if (entorno.ExisteVariable(ElObjeto.Replace(" (id)", "").Replace("AS", "").Replace(" ", "")) == true)
                                        {
                                            //CODIGO PARA AGREGAR VALORES A UN ATRIBUTO UT
                                            ListaParametrosUT[i].AsignarValor("OBJETO_BRAY");
                                            List<Simbolo> ListaParametrosUT2 = entorno.ElementosUT(ElObjeto.Replace(" (id)", "").Replace("AS", "").Replace(" ", ""));
                                            #region INSTANCIAR UN SUB OBJETO
                                            String[] separadasx;
                                            separadasx = separadas[0].Split(',');
                                            List<String> Valores2 = new List<String>();
                                            for (int i2 = separadasx.Length - 1; i2 >= 0; i2--)
                                            {
                                                Valores2.Add(separadasx[i2]);
                                            }

                                            if(Valores2.Count == ListaParametrosUT2.Count)
                                            {
                                                for (int x = 0; x < Valores2.Count; x++)
                                                {
                                                    System.Diagnostics.Debug.WriteLine(x + "parametro sub:" + Valores2[x].Replace("{", "") + " NV " + ListaParametrosUT2[x].ObtenerId());
                                                    String TipoVariable = "";
                                                    String ValorDeLaVariable = "";
                                                    //procedimiento que mira si las variables son iguales
                                                    if (Valores2[x].ToUpper().Contains("(CADENA)"))
                                                    {
                                                        TipoVariable = "STRING";
                                                        ValorDeLaVariable = (Valores2[x].ToUpper().Replace(" (cadena)", "").Replace(" (CADENA)", "").Replace("{", ""));
                                                    }
                                                    else if (Valores2[x].ToUpper().Contains("(NUMERO)"))
                                                    {
                                                        TipoVariable = "INT";
                                                        ValorDeLaVariable = (Valores2[x].ToUpper().Replace(" (numero)", "").Replace(" (NUMERO)", "").Replace("{", ""));
                                                    }
                                                    else if (Valores2[x].ToUpper().Contains("(NUMDECIMAL)"))
                                                    {
                                                        TipoVariable = "DOUBLE";
                                                        ValorDeLaVariable = (Valores2[x].ToUpper().Replace(" (numdecimal)", "").Replace(" (NUMDECIMAL)", "").Replace("{", ""));
                                                    }
                                                    else if (Valores2[x].ToUpper().Contains("(KEYWORD)") && ((Valores2[x].ToUpper().Contains("TRUE")) || (Valores2[x].ToUpper().Contains("FALSE"))))
                                                    {
                                                        TipoVariable = "BOOLEANO";
                                                        ValorDeLaVariable = (Valores2[x].ToUpper().Replace(" (Keyword)", "").Replace(" (KEYWORD)", "").Replace("{", ""));
                                                    }
                                                    else if (Valores2[x].ToUpper().Contains("(FECHAS)"))
                                                    {
                                                        TipoVariable = "DATE";
                                                        ValorDeLaVariable = (Valores2[x].ToUpper().Replace(" (Fechas)", "").Replace(" (FECHAS)", "").Replace("{", ""));
                                                    }
                                                    else if (Valores2[x].ToUpper().Contains("(HORA)"))
                                                    {
                                                        TipoVariable = "TIME";
                                                        ValorDeLaVariable = (Valores2[x].ToUpper().Replace(" (hora)", "").Replace(" (HORA)", "").Replace("{", ""));
                                                    }
                                                    else if (Valores[x].ToUpper().Contains(" (ID2)"))
                                                    {
                                                        TipoVariable = entorno.ObtenerTipo(Valores2[x].Replace(" (id2)", ""));
                                                        ValorDeLaVariable = entorno.ObtenerValor(Valores2[x].Replace(" (id2)", "").Replace("{", ""));
                                                    }
                                                    else if (Valores2[x].ToUpper().Contains("NULL"))
                                                    {
                                                        TipoVariable = "OBJETO_BRAY";
                                                        ValorDeLaVariable = "null";
                                                    }
                                                    System.Diagnostics.Debug.WriteLine("NOMBRE OBJETO PARAMETRO}->: " + ListaParametrosUT2[x].ObtenerId());
                                                    System.Diagnostics.Debug.WriteLine("NOMBRE OBJETO UT}->: " + ListaParametrosUT2[x].ObtenerTipo());
                                                    System.Diagnostics.Debug.WriteLine("Valor OBJETO UT}->: " + ValorDeLaVariable);
                                                    ListaParametrosUT2[x].AsignarValor(ValorDeLaVariable);
                                                   
                                                
                                                }
                                                String xx = ListaParametrosUT[i].ObtenerId();
                                                entorno.AgregarObjeto(Variable + "." + xx, "OBJETO_BRAY", ListaParametrosUT2);
                                            }
                                            else
                                            {
                                                return "#ERROR6 ? Exception: TypeAlreadyExists: User Type con un nombre/parametros no existente. 4";

                                            }



                                            #endregion
                                        }
                                        else
                                        {
                                            return "#ERROR6 ? Exception: TypeAlreadyExists: User Type con un nombre/parametros no existente. 4";
                                        }

                                    }
                                    else
                                    {
                                        String TipoVariable = "";
                                        String ValorDeLaVariable = "";
                                        //procedimiento que mira si las variables son iguales
                                        if (Valores[i].ToUpper().Contains("(CADENA)"))
                                        {
                                            TipoVariable = "STRING";
                                            ValorDeLaVariable = (Valores[i].ToUpper().Replace(" (cadena)", ""));
                                        }
                                        else if (Valores[i].ToUpper().Contains("(NUMERO)"))
                                        {
                                            TipoVariable = "INT";
                                            ValorDeLaVariable = (Valores[i].ToUpper().Replace(" (numero)", ""));
                                        }
                                        else if (Valores[i].ToUpper().Contains("(NUMDECIMAL)"))
                                        {
                                            TipoVariable = "DOUBLE";
                                            ValorDeLaVariable = (Valores[i].ToUpper().Replace(" (numdecimal)", ""));
                                        }
                                        else if (Valores[i].ToUpper().Contains("(KEYWORD)") && ((ListaID1[0].ToUpper().Contains("TRUE")) || (ListaID1[0].ToUpper().Contains("FALSE"))))
                                        {
                                            TipoVariable = "BOOLEANO";
                                            ValorDeLaVariable = (Valores[i].ToUpper().Replace(" (Keyword)", ""));
                                        }
                                        else if (Valores[i].ToUpper().Contains("(FECHAS)"))
                                        {
                                            TipoVariable = "DATE";
                                            ValorDeLaVariable = (Valores[i].ToUpper().Replace(" (Fechas)", ""));
                                        }
                                        else if (Valores[i].ToUpper().Contains("(HORA)"))
                                        {
                                            TipoVariable = "TIME";
                                            ValorDeLaVariable = (Valores[i].ToUpper().Replace(" (hora)", ""));
                                        }
                                        else if (Valores[i].ToUpper().Contains(" (ID2)"))
                                        {
                                            TipoVariable = entorno.ObtenerTipo(Valores[i].Replace(" (id2)", ""));
                                            ValorDeLaVariable = entorno.ObtenerValor(Valores[i].Replace(" (id2)", ""));
                                        }
                                        else if (Valores[i].ToUpper().Contains("NULL"))
                                        {
                                            TipoVariable = "OBJETO_BRAY";
                                            ValorDeLaVariable = "null";
                                        }
                                        System.Diagnostics.Debug.WriteLine("NOMBRE OBJETO PARAMETRO: " + TipoVariable);
                                        System.Diagnostics.Debug.WriteLine("NOMBRE OBJETO UT: " + ListaParametrosUT[i].ObtenerTipo());
                                        System.Diagnostics.Debug.WriteLine("Valor OBJETO UT: " + ValorDeLaVariable);
                                        if (TipoVariable == "OBJETO_BRAY")
                                        {
                                            System.Diagnostics.Debug.WriteLine("NOMBRE OBJETO UTxx: " + ListaParametrosUT[i].ObtenerValor());
                                            //asignar null a algo XD
                                            entorno.AgregarObjeto(Variable + "." + ListaParametrosUT[i].ObtenerId(), "OBJETO_BRAY", null);

                                            if (ListaParametrosUT[i].ObtenerValor() == "null")
                                            {
                                                //agregamos null
                                                ListaParametrosUT[i].AsignarValor(ValorDeLaVariable);
                                               // entorno.AgregarObjeto(Objeto1 + "." + ListaParametrosUT[i].ObtenerId(), "OBJETO_BRAY", null);

                                            }
                                            else
                                            {
                                                return "#ERROR6 ? Exception: TypeAlreadyExists: User Type con un nombre/parametros no existente. 4";
                                            }

                                        }
                                        else if ((TipoVariable.ToUpper().Contains("#ERROR")))
                                        {
                                            return "#ERROR6 ? Exception: TypeAlreadyExists: User Type con un nombre/parametros no existente. 4";
                                        }
                                        else if ((TipoVariable.ToUpper().Replace(" ", "") != ListaParametrosUT[i].ObtenerTipo().ToUpper().Replace(" ", "")))
                                        {
                                            return "#ERROR6 ? Exception: TypeAlreadyExists: User Type con un nombre/parametros no existente. 4";
                                        }
                                        else
                                        {
                                            ///codigo para asignar XD
                                            ListaParametrosUT[i].AsignarValor(ValorDeLaVariable);
                                        }

                                    }
                                }
                                for (int i = 0; i < ListaParametrosUT.Count; i++)
                                {
                                    //Revisando que los Parametros Cumplan con el Tipo del objeto
                                 //   System.Diagnostics.Debug.WriteLine("la nueva lista ->" + ListaParametrosUT[i].ObtenerId() + " Tipo-> " + ListaParametrosUT[i].ObtenerTipo() + " Valor-> " + ListaParametrosUT[i].ObtenerValor());

                                }

                            }
                            else
                            {
                                return "#ERROR6 ? Exception: TypeAlreadyExists: User Type con un nombre/parametros no existente. 4";
                            }

                            entorno.AgregarObjeto(Variable, "OBJETO_BRAY", ListaParametrosUT);
                        }
                        else
                        {
                            return "#ERROR6 ? Exception: ObjectAlreadyExists: instancia con identificador ya existente. 4";
                        }
                    }
                    else
                    {
                        return "#ERROR6 ? Exception: ObjectAlreadyExists: instancia con identificador ya existente. 4";
                    }
                }
                else
                {
                    return "#ERROR6 ? Exception: TypeAlreadyExists: User Type con un nombre no existente. 4";
                }


                

            }

            if (AutoIncrmentable2 == 18000)
            {
                String Objeto1 = this.Hijos[0].Nombre.ToString().Replace(" (id)", "");
                String Objeto2 = this.Hijos[2].Nombre.ToString().Replace(" (id)", "");
                String Variable = this.Hijos[1].Nombre.ToString().Replace(" (id2)", "");

                if (Objeto1 == Objeto2)
                {
                    if (entorno.ExisteVariable(Objeto1) == true)
                    {
                       // System.Diagnostics.Debug.WriteLine("Nombre: loooooooooog");
                        if (entorno.ExisteVariable(Variable) == true)
                        {
                            List<Simbolo> ListaParametrosUT = entorno.ElementosUT(Objeto1);

                            //System.Diagnostics.Debug.WriteLine("Nombre: loooooooooog");
                            if (ListaParametrosUT.Count == this.ListaID1.Count)
                            {
                                //System.Diagnostics.Debug.WriteLine("Nombre: loooooooooog");
                                for (int i = 0; i < ListaParametrosUT.Count; i++)
                                {
                                    //Revisando que los Parametros Cumplan con el Tipo del objeto
                                    // System.Diagnostics.Debug.WriteLine("Nombre: ->" + ListaParametrosUT[i].ObtenerId() + " Tipo-> " + ListaParametrosUT[i].ObtenerTipo() + " Valor-> " + ListaParametrosUT[i].ObtenerValor());
                                    // System.Diagnostics.Debug.WriteLine("Nombrel: ->" + Valores[i]);
                                    //Verificando si tiene }
                                    if (Valores[i].Contains("}") == true)
                                    {
                                        String[] separadas;
                                        separadas = Valores[i].Split('}');
                                        String ElObjeto = separadas[1];
                                        System.Diagnostics.Debug.WriteLine("NOMBRE OBJETO PARAMETRO}: " + ElObjeto.Replace(" (id)", "").Replace("AS", "").Replace(" ", ""));
                                        System.Diagnostics.Debug.WriteLine("NOMBRE OBJETO UT}: " + ListaParametrosUT[i].ObtenerTipo());

                                        if (entorno.ExisteVariable(ElObjeto.Replace(" (id)", "").Replace("AS", "").Replace(" ", "")) == true)
                                        {
                                            //CODIGO PARA AGREGAR VALORES A UN ATRIBUTO UT
                                            ListaParametrosUT[i].AsignarValor("OBJETO_BRAY");
                                            List<Simbolo> ListaParametrosUT2 = entorno.ElementosUT(ElObjeto.Replace(" (id)", "").Replace("AS", "").Replace(" ", ""));
                                            #region INSTANCIAR UN SUB OBJETO
                                            String[] separadasx;
                                            separadasx = separadas[0].Split(',');
                                            List<String> Valores2 = new List<String>();
                                            for (int i2 = separadasx.Length - 1; i2 >= 0; i2--)
                                            {
                                                Valores2.Add(separadasx[i2]);
                                            }

                                            if (Valores2.Count == ListaParametrosUT2.Count)
                                            {
                                                for (int x = 0; x < Valores2.Count; x++)
                                                {
                                                    System.Diagnostics.Debug.WriteLine(x + "parametro sub:" + Valores2[x].Replace("{", "") + " NV " + ListaParametrosUT2[x].ObtenerId());
                                                    String TipoVariable = "";
                                                    String ValorDeLaVariable = "";
                                                    //procedimiento que mira si las variables son iguales
                                                    if (Valores2[x].ToUpper().Contains("(CADENA)"))
                                                    {
                                                        TipoVariable = "STRING";
                                                        ValorDeLaVariable = (Valores2[x].ToUpper().Replace(" (cadena)", "").Replace(" (CADENA)", "").Replace("{", ""));
                                                    }
                                                    else if (Valores2[x].ToUpper().Contains("(NUMERO)"))
                                                    {
                                                        TipoVariable = "INT";
                                                        ValorDeLaVariable = (Valores2[x].ToUpper().Replace(" (numero)", "").Replace(" (NUMERO)", "").Replace("{", ""));
                                                    }
                                                    else if (Valores2[x].ToUpper().Contains("(NUMDECIMAL)"))
                                                    {
                                                        TipoVariable = "DOUBLE";
                                                        ValorDeLaVariable = (Valores2[x].ToUpper().Replace(" (numdecimal)", "").Replace(" (NUMDECIMAL)", "").Replace("{", ""));
                                                    }
                                                    else if (Valores2[x].ToUpper().Contains("(KEYWORD)") && ((Valores2[x].ToUpper().Contains("TRUE")) || (Valores2[x].ToUpper().Contains("FALSE"))))
                                                    {
                                                        TipoVariable = "BOOLEANO";
                                                        ValorDeLaVariable = (Valores2[x].ToUpper().Replace(" (Keyword)", "").Replace(" (KEYWORD)", "").Replace("{", ""));
                                                    }
                                                    else if (Valores2[x].ToUpper().Contains("(FECHAS)"))
                                                    {
                                                        TipoVariable = "DATE";
                                                        ValorDeLaVariable = (Valores2[x].ToUpper().Replace(" (Fechas)", "").Replace(" (FECHAS)", "").Replace("{", ""));
                                                    }
                                                    else if (Valores2[x].ToUpper().Contains("(HORA)"))
                                                    {
                                                        TipoVariable = "TIME";
                                                        ValorDeLaVariable = (Valores2[x].ToUpper().Replace(" (hora)", "").Replace(" (HORA)", "").Replace("{", ""));
                                                    }
                                                    else if (Valores[x].ToUpper().Contains(" (ID2)"))
                                                    {
                                                        TipoVariable = entorno.ObtenerTipo(Valores2[x].Replace(" (id2)", ""));
                                                        ValorDeLaVariable = entorno.ObtenerValor(Valores2[x].Replace(" (id2)", "").Replace("{", ""));
                                                    }
                                                    else if (Valores2[x].ToUpper().Contains("NULL"))
                                                    {
                                                        TipoVariable = "OBJETO_BRAY";
                                                        ValorDeLaVariable = "null";
                                                    }
                                                    System.Diagnostics.Debug.WriteLine("NOMBRE OBJETO PARAMETRO}->: " + ListaParametrosUT2[x].ObtenerId());
                                                    System.Diagnostics.Debug.WriteLine("NOMBRE OBJETO UT}->: " + ListaParametrosUT2[x].ObtenerTipo());
                                                    System.Diagnostics.Debug.WriteLine("Valor OBJETO UT}->: " + ValorDeLaVariable);
                                                    ListaParametrosUT2[x].AsignarValor(ValorDeLaVariable);


                                                }
                                                String xx = ListaParametrosUT[i].ObtenerId();
                                                entorno.AgregarObjeto(Variable + "." + xx, "OBJETO_BRAY", ListaParametrosUT2);
                                            }
                                            else
                                            {
                                                return "#ERROR6 ? Exception: TypeAlreadyExists: User Type con un nombre/parametros no existente. 4";

                                            }



                                            #endregion
                                        }
                                        else
                                        {
                                            return "#ERROR6 ? Exception: TypeAlreadyExists: User Type con un nombre/parametros no existente. 4";
                                        }

                                    }
                                    else
                                    {
                                        String TipoVariable = "";
                                        String ValorDeLaVariable = "";
                                        //procedimiento que mira si las variables son iguales
                                        if (Valores[i].ToUpper().Contains("(CADENA)"))
                                        {
                                            TipoVariable = "STRING";
                                            ValorDeLaVariable = (Valores[i].ToUpper().Replace(" (cadena)", ""));
                                        }
                                        else if (Valores[i].ToUpper().Contains("(NUMERO)"))
                                        {
                                            TipoVariable = "INT";
                                            ValorDeLaVariable = (Valores[i].ToUpper().Replace(" (numero)", ""));
                                        }
                                        else if (Valores[i].ToUpper().Contains("(NUMDECIMAL)"))
                                        {
                                            TipoVariable = "DOUBLE";
                                            ValorDeLaVariable = (Valores[i].ToUpper().Replace(" (numdecimal)", ""));
                                        }
                                        else if (Valores[i].ToUpper().Contains("(KEYWORD)") && ((ListaID1[0].ToUpper().Contains("TRUE")) || (ListaID1[0].ToUpper().Contains("FALSE"))))
                                        {
                                            TipoVariable = "BOOLEANO";
                                            ValorDeLaVariable = (Valores[i].ToUpper().Replace(" (Keyword)", ""));
                                        }
                                        else if (Valores[i].ToUpper().Contains("(FECHAS)"))
                                        {
                                            TipoVariable = "DATE";
                                            ValorDeLaVariable = (Valores[i].ToUpper().Replace(" (Fechas)", ""));
                                        }
                                        else if (Valores[i].ToUpper().Contains("(HORA)"))
                                        {
                                            TipoVariable = "TIME";
                                            ValorDeLaVariable = (Valores[i].ToUpper().Replace(" (hora)", ""));
                                        }
                                        else if (Valores[i].ToUpper().Contains(" (ID2)"))
                                        {
                                            TipoVariable = entorno.ObtenerTipo(Valores[i].Replace(" (id2)", ""));
                                            ValorDeLaVariable = entorno.ObtenerValor(Valores[i].Replace(" (id2)", ""));
                                        }
                                        else if (Valores[i].ToUpper().Contains("NULL"))
                                        {
                                            TipoVariable = "OBJETO_BRAY";
                                            ValorDeLaVariable = "null";
                                        }
                                        System.Diagnostics.Debug.WriteLine("NOMBRE OBJETO PARAMETRO: " + TipoVariable);
                                        System.Diagnostics.Debug.WriteLine("NOMBRE OBJETO UT: " + ListaParametrosUT[i].ObtenerTipo());
                                        System.Diagnostics.Debug.WriteLine("Valor OBJETO UT: " + ValorDeLaVariable);

                                        if (TipoVariable == "OBJETO_BRAY")
                                        {
                                            System.Diagnostics.Debug.WriteLine("NOMBRE OBJETO UTxx: " + ListaParametrosUT[i].ObtenerValor());
                                            entorno.AgregarObjeto(Variable + "." + ListaParametrosUT[i].ObtenerId(), "OBJETO_BRAY", null);
                                            //asignar null a algo XD
                                            if (ListaParametrosUT[i].ObtenerValor() == "null")
                                            {
                                                //agregamos null
                                                ListaParametrosUT[i].AsignarValor(ValorDeLaVariable);
                                                


                                            }
                                            else
                                            {
                                                return "#ERROR6 ? Exception: TypeAlreadyExists: User Type con un nombre/parametros no existente. 4";
                                            }

                                        }
                                        else if ((TipoVariable.ToUpper().Contains("#ERROR")))
                                        {
                                            return "#ERROR6 ? Exception: TypeAlreadyExists: User Type con un nombre/parametros no existente. 4";
                                        }
                                        else if ((TipoVariable.ToUpper().Replace(" ", "") != ListaParametrosUT[i].ObtenerTipo().ToUpper().Replace(" ", "")))
                                        {
                                            return "#ERROR6 ? Exception: TypeAlreadyExists: User Type con un nombre/parametros no existente. 4";
                                        }
                                        else
                                        {
                                            ///codigo para asignar XD
                                            ListaParametrosUT[i].AsignarValor(ValorDeLaVariable);
                                        }

                                    }
                                }
                                for (int i = 0; i < ListaParametrosUT.Count; i++)
                                {
                                    //Revisando que los Parametros Cumplan con el Tipo del objeto
                                    //   System.Diagnostics.Debug.WriteLine("la nueva lista ->" + ListaParametrosUT[i].ObtenerId() + " Tipo-> " + ListaParametrosUT[i].ObtenerTipo() + " Valor-> " + ListaParametrosUT[i].ObtenerValor());

                                }

                            }
                            else
                            {
                                return "#ERROR6 ? Exception: TypeAlreadyExists: User Type con un nombre/parametros no existente. 4";
                            }

                            entorno.EliminarVariable(Variable);
                            entorno.AgregarObjeto(Variable, "OBJETO_BRAY", ListaParametrosUT);
                        }
                        else
                        {
                            return "#ERROR6 ? Exception: ObjectAlreadyExists: instancia con identificador ya existente. 4";
                        }
                    }
                    else
                    {
                        return "#ERROR6 ? Exception: ObjectAlreadyExists: instancia con identificador ya existente. 4";
                    }
                }
                else
                {
                    return "#ERROR6 ? Exception: TypeAlreadyExists: User Type con un nombre no existente. 4";
                }

            }


            entorno.MostrarObjetosx();

            return "ASIGNACION-OBJETO";
        }
    }
}