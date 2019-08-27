using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class FUNCIONES_PROPIAS : NodoAbstracto
    {
        public FUNCIONES_PROPIAS(String Valor) : base(Valor)
        {
        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("EJECUTANDO FUNCIONES");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("EJECUTANDO FUNCIONES");
            if (AutoIncrmentable2 == 101)
            {
                String cadena = this.Hijos[0].Nombre;
                string[] separadas;
                separadas = cadena.Split('.');
                String TipoFuncion = separadas[separadas.Length - 1];
                System.Diagnostics.Debug.WriteLine("ES funcion: " + TipoFuncion);
                String Variable = cadena.Replace(TipoFuncion, "").TrimEnd('.');
                System.Diagnostics.Debug.WriteLine("VAriable: " + Variable);
                String TipoVariable = entorno.ObtenerTipo(Variable);
                String ValorVariable = entorno.ObtenerValor(Variable);

                if (TipoVariable.ToUpper().Contains("STRING") == true && TipoFuncion.ToUpper().Contains("LENGTH") == true)
                {
                    int tam = ValorVariable.Length;
                    this.Nombre = "Entero";
                    this.TipoDato = "entero";
                    return tam.ToString();
                }
                else if (TipoVariable.ToUpper().Contains("STRING") == true && TipoFuncion.ToUpper().Contains("TOUPPERCASE") == true)
                {
                    String mayus = ValorVariable.ToUpper();
                    this.Nombre = "Cadena";
                    this.TipoDato = "Cadena";
                    return mayus;
                }
                else if (TipoVariable.ToUpper().Contains("STRING") == true && TipoFuncion.ToUpper().Contains("TOLOWERCASE") == true)
                {
                    String mayus = ValorVariable.ToLower();
                    this.Nombre = "Cadena";
                    this.TipoDato = "Cadena";
                    return mayus;
                }
                else if (TipoVariable.ToUpper().Contains("DATE") == true && TipoFuncion.ToUpper().Contains("GETYEAR") == true)
                {
                    //  System.Diagnostics.Debug.WriteLine("EJECUTANDO FUNCIONES" + ValorVariable);
                    DateTime tam = DateTime.Parse(ValorVariable.Replace("'", ""));
                    this.Nombre = "Entero";
                    this.TipoDato = "entero";
                    return tam.Year.ToString();
                }
                else if (TipoVariable.ToUpper().Contains("DATE") == true && TipoFuncion.ToUpper().Contains("GETMONTH") == true)
                {
                    //  System.Diagnostics.Debug.WriteLine("EJECUTANDO FUNCIONES" + ValorVariable);
                    DateTime tam = DateTime.Parse(ValorVariable.Replace("'", ""));
                    this.Nombre = "Entero";
                    this.TipoDato = "entero";
                    return tam.Month.ToString();
                }
                else if (TipoVariable.ToUpper().Contains("DATE") == true && TipoFuncion.ToUpper().Contains("GETDAY") == true)
                {
                    // System.Diagnostics.Debug.WriteLine("EJECUTANDO FUNCIONES" + ValorVariable);
                    DateTime tam = DateTime.Parse(ValorVariable.Replace("'", ""));
                    this.Nombre = "Entero";
                    this.TipoDato = "entero";
                    return tam.Day.ToString();
                }
                else if (TipoVariable.ToUpper().Contains("TIME") == true && TipoFuncion.ToUpper().Contains("GETHOUR") == true)
                {
                    System.Diagnostics.Debug.WriteLine("EJECUTANDO FUNCIONES" + ValorVariable);
                    DateTime tam = DateTime.Parse(ValorVariable.Replace("'", ""));
                    this.Nombre = "Entero";
                    this.TipoDato = "entero";
                    return tam.Hour.ToString();
                }
                else if (TipoVariable.ToUpper().Contains("TIME") == true && TipoFuncion.ToUpper().Contains("GETMINUTS") == true)
                {
                    System.Diagnostics.Debug.WriteLine("EJECUTANDO FUNCIONES" + ValorVariable);
                    DateTime tam = DateTime.Parse(ValorVariable.Replace("'", ""));
                    this.Nombre = "Entero";
                    this.TipoDato = "entero";
                    return tam.Minute.ToString();
                }
                else if (TipoVariable.ToUpper().Contains("TIME") == true && TipoFuncion.ToUpper().Contains("GETSECONDS") == true)
                {
                    System.Diagnostics.Debug.WriteLine("EJECUTANDO FUNCIONES" + ValorVariable);
                    DateTime tam = DateTime.Parse(ValorVariable.Replace("'", ""));
                    this.Nombre = "Entero";
                    this.TipoDato = "entero";
                    return tam.Second.ToString();
                }

            }

            if(AutoIncrmentable2 == 102)
            {
                String cadena = this.Hijos[0].Nombre;
                if (cadena.ToUpper().Contains("NOW"))
                {
                    DateTime hoy = DateTime.Now;
                    int uno = hoy.Year;
                    int dos = hoy.Month;
                    int tres = hoy.Day;
                    this.Nombre = "Fechas";
                    this.TipoDato = "Fechas";
                    return "'" + uno + "-" + dos + "-" + tres + "'";
                }
                else if (cadena.ToUpper().Contains("TODAY"))
                {
                    DateTime hoy = DateTime.Now;
                    int uno = hoy.Hour;
                    int dos = hoy.Minute;
                    int tres = hoy.Second;
                    this.Nombre = "hora";
                    this.TipoDato = "hora";
                    return "'" + uno + ":" + dos + ":" + tres + "'";
                }
            }

            if(AutoIncrmentable2 == 103)
            {
                System.Diagnostics.Debug.WriteLine("V---------------");
                String cadena = this.Hijos[0].Nombre;
                string[] separadas;
                separadas = cadena.Split('.');
                String TipoFuncion = separadas[separadas.Length - 1];
                System.Diagnostics.Debug.WriteLine("ES funcion: " + TipoFuncion);
                String Variable = cadena.Replace(TipoFuncion, "").TrimEnd('.');
                System.Diagnostics.Debug.WriteLine("VAriable: " + Variable);
                String TipoVariable = entorno.ObtenerTipo(Variable);
                String ValorVariable = entorno.ObtenerValor(Variable);

                String Expresion =  this.Hijos[1].Ejecutar(entorno).ToString();
                String TipoExpresion = this.Hijos[1].Nombre.ToString();
                System.Diagnostics.Debug.WriteLine("Tipo Expresion en parentesis: " + TipoExpresion);
                //System.Diagnostics.Debug.WriteLine("Expresion en parentesis: " + Expresion);

                if (TipoFuncion.ToUpper().Contains("STARTSWITH"))
                {
                    String VariableAFusionar = entorno.ObtenerTipo(Variable);
                    if (TipoExpresion.ToUpper().Contains("ID"))
                    {
                        
                        String ValorVariablexd = entorno.ObtenerValor(Variable);
                        System.Diagnostics.Debug.WriteLine("Expresion en parentesis ID**"+ ValorVariablexd);
                        System.Diagnostics.Debug.WriteLine("Cadena en parentesis ID**" + Expresion);
                        if (ValorVariablexd.StartsWith(Expresion) == true)
                        {
                            this.Nombre = "Booleano";
                            this.TipoDato = "Booleano";
                            return "true";
                        }
                        else
                        {
                            this.Nombre = "Booleano";
                            this.TipoDato = "Booleano";
                            return "false";
                        }


                    }
                    else if (TipoExpresion.ToUpper().Contains("CADENA"))
                    {
                        System.Diagnostics.Debug.WriteLine("Expresion en parentesis CADNEA**");
                        System.Diagnostics.Debug.WriteLine("Expresion en parentesis ID**" + ValorVariable);
                        System.Diagnostics.Debug.WriteLine("Cadena en parentesis ID**" + Expresion);
                        if (ValorVariable.StartsWith(Expresion) == true)
                        {
                            this.Nombre = "Booleano";
                            this.TipoDato = "Booleano";
                            return "true";
                        }
                        else
                        {
                            this.Nombre = "Booleano";
                            this.TipoDato = "Booleano";
                            return "false";
                        }
                    }
                    else
                    {
                        return "#ERROR EN FUNCIONES";
                    }
                }
                if (TipoFuncion.ToUpper().Contains("ENDSWITH"))
                {
                    String VariableAFusionar = entorno.ObtenerTipo(Variable);
                    if (TipoExpresion.ToUpper().Contains("ID"))
                    {

                        String ValorVariablexd = entorno.ObtenerValor(Variable);
                        System.Diagnostics.Debug.WriteLine("Expresion en parentesis ID**" + ValorVariablexd);
                        System.Diagnostics.Debug.WriteLine("Cadena en parentesis ID**" + Expresion);
                        if (ValorVariablexd.EndsWith(Expresion) == true)
                        {
                            this.Nombre = "Booleano";
                            this.TipoDato = "Booleano";
                            return "true";
                        }
                        else
                        {
                            this.Nombre = "Booleano";
                            this.TipoDato = "Booleano";
                            return "false";
                        }


                    }
                    else if (TipoExpresion.ToUpper().Contains("CADENA"))
                    {
                        System.Diagnostics.Debug.WriteLine("Expresion en parentesis CADNEA**");
                        System.Diagnostics.Debug.WriteLine("Expresion en parentesis ID**" + ValorVariable);
                        System.Diagnostics.Debug.WriteLine("Cadena en parentesis ID**" + Expresion);
                        if (ValorVariable.EndsWith(Expresion) == true)
                        {
                            this.Nombre = "Booleano";
                            this.TipoDato = "Booleano";
                            return "true";
                        }
                        else
                        {
                            this.Nombre = "Booleano";
                            this.TipoDato = "Booleano";
                            return "false";
                        }
                    }
                    else
                    {
                        return "#ERROR EN FUNCIONES";
                    }
                }

            }

            if(AutoIncrmentable2 == 104)
            {
                String cadena = this.Hijos[0].Nombre;
                string[] separadas;
                separadas = cadena.Split('.');
                String TipoFuncion = separadas[separadas.Length - 1];
                String Variable = cadena.Replace(TipoFuncion, "").TrimEnd('.');
                String TipoVariable = entorno.ObtenerTipo(Variable);
                String ValorVariable = entorno.ObtenerValor(Variable);
                

                System.Diagnostics.Debug.WriteLine("ES funcion: " + TipoFuncion);
                System.Diagnostics.Debug.WriteLine("VAriable: " + Variable);
                System.Diagnostics.Debug.WriteLine("Varor Varialbe: " + ValorVariable);
                System.Diagnostics.Debug.WriteLine("Tipo Varialbe: " + TipoVariable);

                ///parmetro uno
                //System.Diagnostics.Debug.WriteLine("VAriable: " + this.Hijos[1].Nombre); //Entero o id2
                String TipoParametro1 = this.Hijos[1].Nombre;
                String  ValorPar1 = this.Hijos[1].Ejecutar(entorno).ToString().Replace(" (numero)","");
                
                System.Diagnostics.Debug.WriteLine("Tipo Parametro 1 " + TipoParametro1);
                System.Diagnostics.Debug.WriteLine("Valor Parametro 1 " + ValorPar1);

                String TipoParametro2 = this.Hijos[2].Nombre;
                String ValorPar2 = this.Hijos[2].Ejecutar(entorno).ToString().Replace(" (numero)", "");


                System.Diagnostics.Debug.WriteLine("Tipo Parametro 2 " + TipoParametro2);
                System.Diagnostics.Debug.WriteLine("Valor Parametro 2 " + ValorPar2);
                Boolean Afirmativo1 = false;
                Boolean Afirmativo2 = false;

                if (TipoVariable.ToUpper().Contains("STRING") == true)
                {
                    if (TipoParametro1.ToUpper().Contains("ID2") == true)
                    {
                        String Tipo1x = entorno.ObtenerTipo(this.Hijos[1].NombreVariable.ToString());
                        System.Diagnostics.Debug.WriteLine("Tipo Parametro 1x " + Tipo1x);
                        if (Tipo1x.ToUpper().Contains("INT") == true)
                        {
                            System.Diagnostics.Debug.WriteLine("agirma2-------------------------------");
                          Afirmativo1 = true;
                        }
                        else
                        {
                            return "#ERROR EN FUNCIONES";
                        }
                    }
                    else if(this.Hijos[1].Ejecutar(entorno).ToString().ToUpper().Contains("NUMERO") == true)
                    {
                        System.Diagnostics.Debug.WriteLine("agirma2-------------------------------");
                        Afirmativo1 = true;
                    }
                    else
                    {
                        return "#ERROR EN FUNCIONES";
                    }

                    if (TipoParametro2.ToUpper().Contains("ID2") == true)
                    {
                        String Tipo1x = entorno.ObtenerTipo(this.Hijos[2].NombreVariable.ToString());
                        System.Diagnostics.Debug.WriteLine("Tipo Parametro 1x " + Tipo1x);
                        if (Tipo1x.ToUpper().Contains("INT") == true)
                        {
                            System.Diagnostics.Debug.WriteLine("agirma3-------------------------------");
                            Afirmativo2 = true;
                        }
                        else
                        {
                            return "#ERROR EN FUNCIONES";
                        }
                    }
                    else if (this.Hijos[2].Ejecutar(entorno).ToString().ToUpper().Contains("NUMERO") == true)
                    {
                        System.Diagnostics.Debug.WriteLine("agirma3-------------------------------");
                        Afirmativo2 = true;
                    }
                    else
                    {
                        return "#ERROR EN FUNCIONES";
                    }


                    if(Afirmativo1 == true && Afirmativo2 == true)
                    {
                        System.Diagnostics.Debug.WriteLine("agirma4-------------------------------");
                        if (Int64.Parse(ValorPar1) < Int64.Parse(ValorPar2))
                        {
                            System.Diagnostics.Debug.WriteLine("agirma5-------------------------------" + ValorVariable.Length +  "x" + ValorPar2);
                            if ((ValorVariable.Length > Int32.Parse(ValorPar1)) && (Int32.Parse(ValorPar2)<ValorVariable.Length) )
                            {
                                System.Diagnostics.Debug.WriteLine("agirma6-------------------------------");
                                this.Nombre = "Cadena";
                                this.TipoDato = "Cadena";
                                System.Diagnostics.Debug.WriteLine("Tipsdfsdfadsf" + ValorVariable.Substring(Int32.Parse(ValorPar1), Int32.Parse(ValorPar2))) ;
                                return ValorVariable.Substring(Int32.Parse(ValorPar1), Int32.Parse(ValorPar2)) ;
                            }
                            else
                            {
                                return "#ERROR EN FUNCIONES par incorrectoss";
                            }
                        }
                        else
                        {
                            return "#ERROR EN FUNCIONES no numeros";
                        }
                    }
                    else
                    {
                        return "#ERROR EN FUNCIONES";
                    }

                }
                else
                {
                    return "#ERROR EN FUNCIONES";
                }

            }

            return "#ERROR EN FUNCIONES";
        }
    }
}