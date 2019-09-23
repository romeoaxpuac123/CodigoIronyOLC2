using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class Asignar : NodoAbstracto
    {
        public override void Ejecutar()
        {
            throw new NotImplementedException();
        }
        public Asignar(String Valor) : base(Valor)
        {
            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado declarar");
        }
        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado asignar");
            String sali = entorno.ObtenerValor(this.Hijos[0].Nombre);
            System.Diagnostics.Debug.WriteLine("VAR" + this.Hijos[0].Nombre);
            System.Diagnostics.Debug.WriteLine("tipo de la expresion" + this.Hijos[1].TipoDato);

            if (this.Hijos[1].TipoDato == "CAST")
            {
                System.Diagnostics.Debug.WriteLine("vamos con los casteos");

                String ValorACastear = this.Hijos[1].Hijos[2].Ejecutar(entorno);
                System.Diagnostics.Debug.WriteLine("Valor a Castear:" + ValorACastear);

                String TipoACastear = this.Hijos[1].Hijos[2].NombreVariable;
                System.Diagnostics.Debug.WriteLine("Tipo del valor a Caster:" + TipoACastear);

                String SINOESVARIABLE = this.Hijos[1].Hijos[2].TipoDato;
                System.Diagnostics.Debug.WriteLine("Tipo del valor a Caster:" + SINOESVARIABLE);

                String TipoACastear2 = "";
               if (TipoACastear != null)
                {
                    TipoACastear2 =  entorno.ObtenerTipo(TipoACastear);
               }
                
                String TipoCasteo =  this.Hijos[1].Hijos[0].Nombre;
                System.Diagnostics.Debug.WriteLine("Tipo Casteo:" + TipoCasteo);


                if ((TipoCasteo.ToUpper().Contains("DATE") && entorno.ObtenerTipo(this.Hijos[0].Nombre).ToUpper().Contains("DATE") == true)
                 && (SINOESVARIABLE.ToUpper().Contains("CADENA") == true || TipoACastear2.ToUpper().Contains("STRING") == true)
                )
                {
                    //Casteo de las fechas
                    System.Diagnostics.Debug.WriteLine("CASTEO DATE - STRINGx");
                    if ((ValorACastear.ToUpper().Contains("A") || ValorACastear.ToUpper().Contains("B") || ValorACastear.ToUpper().Contains("C") || ValorACastear.ToUpper().Contains("D") || ValorACastear.ToUpper().Contains("D") || ValorACastear.ToUpper().Contains("E") || ValorACastear.ToUpper().Contains("F") || ValorACastear.ToUpper().Contains("G")
                        || ValorACastear.ToUpper().Contains("H") || ValorACastear.ToUpper().Contains("I") || ValorACastear.ToUpper().Contains("J") || ValorACastear.ToUpper().Contains("K") || ValorACastear.ToUpper().Contains("L") || ValorACastear.ToUpper().Contains("M") || ValorACastear.ToUpper().Contains("Ñ") || ValorACastear.ToUpper().Contains("O")
                        || ValorACastear.ToUpper().Contains("P") || ValorACastear.ToUpper().Contains("Q") || ValorACastear.ToUpper().Contains("R") || ValorACastear.ToUpper().Contains("S") || ValorACastear.ToUpper().Contains("T") || ValorACastear.ToUpper().Contains("U") || ValorACastear.ToUpper().Contains("V") || ValorACastear.ToUpper().Contains("W")
                        || ValorACastear.ToUpper().Contains("X") || ValorACastear.ToUpper().Contains("Y") || ValorACastear.ToUpper().Contains("Z"))

                        )
                    {

                        System.Diagnostics.Debug.WriteLine("#ERROR5 TIPO DE CASTEO INCORRECTO");
                        return "#ERROR5 TIPO DE CASTEO INCORRECTO";
                    }
                    else
                    {
                        if (ValorACastear.Contains("-") == false)
                        {
                            System.Diagnostics.Debug.WriteLine("#ERROR5 TIPO DE CASTEO INCORRECTO");
                            return "#ERROR5 TIPO DE CASTEO INCORRECTO";
                        }
                        else
                        {
                            entorno.AsignarValor(this.Hijos[0].Nombre, "'"+ValorACastear + "'");
                        }

                    }



                }
                else if ((TipoCasteo.ToUpper().Contains("STRING") && entorno.ObtenerTipo(this.Hijos[0].Nombre).ToUpper().Contains("STRING") == true)
                && (SINOESVARIABLE.ToUpper().Contains("FECHAS") == true || TipoACastear2.ToUpper().Contains("DATE") == true)
                )
                {
                    //Casteo de las fechas
                    System.Diagnostics.Debug.WriteLine("CASTEO STRING - DATE");
                    entorno.AsignarValor(this.Hijos[0].Nombre, ValorACastear.Replace(" (fechas)", ""));

                }
                else if ((TipoCasteo.ToUpper().Contains("TIME") && entorno.ObtenerTipo(this.Hijos[0].Nombre).ToUpper().Contains("TIME") == true)
                    && (SINOESVARIABLE.ToUpper().Contains("CADENA") == true || TipoACastear2.ToUpper().Contains("STRING") == true)
                )
                {
                    //Casteo de las horas
                    System.Diagnostics.Debug.WriteLine("CASTEO TIME- STRING" + ValorACastear);
                    if (ValorACastear.ToUpper().Contains("A") || ValorACastear.ToUpper().Contains("B") || ValorACastear.ToUpper().Contains("C") || ValorACastear.ToUpper().Contains("D")
                        || ValorACastear.ToUpper().Contains("D") || ValorACastear.ToUpper().Contains("E") || ValorACastear.ToUpper().Contains("F") || ValorACastear.ToUpper().Contains("G")
                        || ValorACastear.ToUpper().Contains("H") || ValorACastear.ToUpper().Contains("I") || ValorACastear.ToUpper().Contains("J") || ValorACastear.ToUpper().Contains("K")
                        || ValorACastear.ToUpper().Contains("L") || ValorACastear.ToUpper().Contains("M") || ValorACastear.ToUpper().Contains("Ñ") || ValorACastear.ToUpper().Contains("O")
                        || ValorACastear.ToUpper().Contains("P") || ValorACastear.ToUpper().Contains("Q") || ValorACastear.ToUpper().Contains("R") || ValorACastear.ToUpper().Contains("S")
                        || ValorACastear.ToUpper().Contains("T") || ValorACastear.ToUpper().Contains("U") || ValorACastear.ToUpper().Contains("V") || ValorACastear.ToUpper().Contains("W")
                        || ValorACastear.ToUpper().Contains("X") || ValorACastear.ToUpper().Contains("Y") || ValorACastear.ToUpper().Contains("Z")
                        )
                    {
                        System.Diagnostics.Debug.WriteLine("#ERROR5 TIPO DE CASTEO INCORRECTO");
                        return "#ERROR5 TIPO DE CASTEO INCORRECTO";
                    }
                    else
                    {
                        if (ValorACastear.Contains(":") == false)
                        {
                            System.Diagnostics.Debug.WriteLine("#ERROR5 TIPO DE CASTEO INCORRECTO");
                            return "#ERROR5 TIPO DE CASTEO INCORRECTO";
                        }
                        else
                        {
                            entorno.AsignarValor(this.Hijos[0].Nombre, "'"+ ValorACastear.Replace(" (fechas)"+ "'", ""));
                        }

                    }


                }
                else if ((TipoCasteo.ToUpper().Contains("STRING") && entorno.ObtenerTipo(this.Hijos[0].Nombre).ToUpper().Contains("STRING") == true)
                  && (SINOESVARIABLE.ToUpper().Contains("HORA") == true || TipoACastear2.ToUpper().Contains("TIME") == true)
                 )
                {
                    //Casteo de las horas
                    System.Diagnostics.Debug.WriteLine("CASTEO STRING-TIME");
                    entorno.AsignarValor(this.Hijos[0].Nombre, ValorACastear.Replace(" (hora)", ""));

                }
                else if ((TipoCasteo.ToUpper().Contains("INT") && entorno.ObtenerTipo(this.Hijos[0].Nombre).ToUpper().Contains("INT") == true)
                  && (SINOESVARIABLE.ToUpper().Contains("CADENA") == true || TipoACastear2.ToUpper().Contains("STRING") == true)
                 )
                {
                    //Casteo de las horas
                    System.Diagnostics.Debug.WriteLine("CASTEO STRING-INT");
                    if (ValorACastear.ToUpper().Contains("A") || ValorACastear.ToUpper().Contains("B") || ValorACastear.ToUpper().Contains("C") || ValorACastear.ToUpper().Contains("D")
                      || ValorACastear.ToUpper().Contains("D") || ValorACastear.ToUpper().Contains("E") || ValorACastear.ToUpper().Contains("F") || ValorACastear.ToUpper().Contains("G")
                      || ValorACastear.ToUpper().Contains("H") || ValorACastear.ToUpper().Contains("I") || ValorACastear.ToUpper().Contains("J") || ValorACastear.ToUpper().Contains("K")
                      || ValorACastear.ToUpper().Contains("L") || ValorACastear.ToUpper().Contains("M") || ValorACastear.ToUpper().Contains("Ñ") || ValorACastear.ToUpper().Contains("O")
                      || ValorACastear.ToUpper().Contains("P") || ValorACastear.ToUpper().Contains("Q") || ValorACastear.ToUpper().Contains("R") || ValorACastear.ToUpper().Contains("S")
                      || ValorACastear.ToUpper().Contains("T") || ValorACastear.ToUpper().Contains("U") || ValorACastear.ToUpper().Contains("V") || ValorACastear.ToUpper().Contains("W")
                      || ValorACastear.ToUpper().Contains("X") || ValorACastear.ToUpper().Contains("Y") || ValorACastear.ToUpper().Contains("Z") || ValorACastear.ToUpper().Contains(".")
                      )
                    {
                        System.Diagnostics.Debug.WriteLine("#ERROR5 TIPO DE CASTEO INCORRECTO");
                        return "#ERROR5 TIPO DE CASTEO INCORRECTO";
                    }
                    else
                    {
                        entorno.AsignarValor(this.Hijos[0].Nombre, ValorACastear);
                    }
                    //entorno.AsignarValor(this.Hijos[0].Nombre, ValorACastear.Replace(" (hora)", ""));

                }
                else if ((TipoCasteo.ToUpper().Contains("STRING") && entorno.ObtenerTipo(this.Hijos[0].Nombre).ToUpper().Contains("STRING") == true)
                 && (SINOESVARIABLE.ToUpper().Contains("ENTERO") == true || TipoACastear2.ToUpper().Contains("INT") == true)
                )
                {
                    System.Diagnostics.Debug.WriteLine("CASTEO int string");
                    entorno.AsignarValor(this.Hijos[0].Nombre, ValorACastear.Replace(" (Entero)", ""));
                }
                else if ((TipoCasteo.ToUpper().Contains("STRING") && entorno.ObtenerTipo(this.Hijos[0].Nombre).ToUpper().Contains("STRING") == true)
                && (SINOESVARIABLE.ToUpper().Contains("DECIMAL") == true || TipoACastear2.ToUpper().Contains("DOUBLE") == true)
               )
                {
                    System.Diagnostics.Debug.WriteLine("CASTEO DECIMAL string");
                    entorno.AsignarValor(this.Hijos[0].Nombre, ValorACastear.Replace(".", ","));
                }
                else if ((TipoCasteo.ToUpper().Contains("DOUBLE") && entorno.ObtenerTipo(this.Hijos[0].Nombre).ToUpper().Contains("DOUBLE") == true)
                  && (SINOESVARIABLE.ToUpper().Contains("CADENA") == true || TipoACastear2.ToUpper().Contains("STRING") == true)
                 )
                {
                    //Casteo de las horas
                    System.Diagnostics.Debug.WriteLine("CASTEO STRING-DOUBLE");
                    if (ValorACastear.ToUpper().Contains("A") || ValorACastear.ToUpper().Contains("B") || ValorACastear.ToUpper().Contains("C") || ValorACastear.ToUpper().Contains("D")
                      || ValorACastear.ToUpper().Contains("D") || ValorACastear.ToUpper().Contains("E") || ValorACastear.ToUpper().Contains("F") || ValorACastear.ToUpper().Contains("G")
                      || ValorACastear.ToUpper().Contains("H") || ValorACastear.ToUpper().Contains("I") || ValorACastear.ToUpper().Contains("J") || ValorACastear.ToUpper().Contains("K")
                      || ValorACastear.ToUpper().Contains("L") || ValorACastear.ToUpper().Contains("M") || ValorACastear.ToUpper().Contains("Ñ") || ValorACastear.ToUpper().Contains("O")
                      || ValorACastear.ToUpper().Contains("P") || ValorACastear.ToUpper().Contains("Q") || ValorACastear.ToUpper().Contains("R") || ValorACastear.ToUpper().Contains("S")
                      || ValorACastear.ToUpper().Contains("T") || ValorACastear.ToUpper().Contains("U") || ValorACastear.ToUpper().Contains("V") || ValorACastear.ToUpper().Contains("W")
                      || ValorACastear.ToUpper().Contains("X") || ValorACastear.ToUpper().Contains("Y") || ValorACastear.ToUpper().Contains("Z") || ValorACastear.ToUpper().Contains(".")
                      )
                    {
                        System.Diagnostics.Debug.WriteLine("#ERROR5 TIPO DE CASTEO INCORRECTO");
                        return "#ERROR5 TIPO DE CASTEO INCORRECTO";
                    }
                    else
                    {
                        entorno.AsignarValor(this.Hijos[0].Nombre, ValorACastear);
                    }
                    //entorno.AsignarValor(this.Hijos[0].Nombre, ValorACastear.Replace(" (hora)", ""));

                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("#ERROR5 TIPO DE CASTEO INCORRECTO");
                    return "#ERROR5 TIPO DE CASTEO INCORRECTO";
                }



                System.Diagnostics.Debug.WriteLine("fin los casteos");
                return "";

            }
            System.Diagnostics.Debug.WriteLine("VARX" + this.Hijos[0].Nombre);
            System.Diagnostics.Debug.WriteLine("tipo de la expresionX" + this.Hijos[1].TipoDato);
            System.Diagnostics.Debug.WriteLine("tipo de la expresion" + this.Hijos[1].Hijos[0].Nombre);
            System.Diagnostics.Debug.WriteLine("valor" + this.Hijos[1].Ejecutar(entorno).Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", ""));
            String Variable1 = this.Hijos[1].Ejecutar(entorno).Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(".",",");
            String TipoDato1 = "";
            String var = this.Hijos[0].Nombre;
            Boolean x = false;
            if (this.Hijos[1].Hijos[0].Nombre.Contains("@"))
            {
                Variable1 = entorno.ObtenerValor(this.Hijos[1].Hijos[0].Nombre);
                TipoDato1 = entorno.ObtenerTipo(this.Hijos[1].Hijos[0].Nombre);
            }
            else if (var.Contains("@") == true){
                //Variable1 = entorno.ObtenerValor(var);
                TipoDato1 = entorno.ObtenerTipo(var).Replace(" ","");
                x = true;
                
            }

           
            System.Diagnostics.Debug.WriteLine("variable1x:" + Variable1 + "-");
            System.Diagnostics.Debug.WriteLine("variable1x:" + TipoDato1 + "-");
            System.Diagnostics.Debug.WriteLine("variable1x:" + var + "-");
            //System.Diagnostics.Debug.WriteLine("SOY ROMOE AXPUAC");
            if ((entorno.ObtenerTipo(var).ToString().ToUpper().Contains("INT")) &&
                ( TipoDato1.ToUpper().Contains("INT") || TipoDato1.ToUpper().Contains("DOUBLE"))
                )
            {
                if(this.Hijos[1].Nombre == "INCREMENTO")
                {
                    System.Diagnostics.Debug.WriteLine("asignacion decremento");
                    entorno.AsignarValor(var, (Int64.Parse(Variable1) - 1).ToString());
                }
                if (this.Hijos[1].Nombre == "DECREMENTO")
                {
                    System.Diagnostics.Debug.WriteLine("asignacion decremento");
                    entorno.AsignarValor(var, (Int64.Parse(Variable1) + 1).ToString());
                }

                // return sali;
            }
        
            Boolean DecimalEntero = true;
            Boolean ElBool = true;
            
                if (this.Hijos[1].TipoDato =="entero" || this.Hijos[1].TipoDato == "decimal" || TipoDato1.ToUpper().Contains("INT") || TipoDato1.ToUpper().Contains("DOUBLE"))
                {
                    DecimalEntero = false;
                }
                if (Variable1.ToUpper() == "TRUE" || Variable1.ToUpper() == "FALSE")
                {
                    ElBool = false;
                }

            System.Diagnostics.Debug.WriteLine("SOY ROMOE AXPUAC" + var + "->" +DecimalEntero);

            if (sali.ToUpper().Contains("#ERROR")== false)
            {
                
                if (entorno.ObtenerTipo(this.Hijos[0].Nombre).ToUpper().Contains("INT")
                    &&(this.Hijos[1].Nombre.ToString() == "Entero" || this.Hijos[1].Nombre.ToString() == "Decimal"|| this.Hijos[1].Nombre == "EXP") 
                    && DecimalEntero == false                   
                    ) 
                {
                    
                    //ASIGANACION DE UNA VARIABLE DE TIPO ENTERO
                    System.Diagnostics.Debug.WriteLine("la variable es entera" + Variable1);
                    if (Variable1.Contains(","))
                    {
                        entorno.AsignarValor(this.Hijos[0].Nombre, Variable1.Remove(Variable1.IndexOf(",")));
                       return "ASIGNAR";
                    }
                    else
                    {
                        entorno.AsignarValor(this.Hijos[0].Nombre, Variable1);
                        return "ASIGNAR";
                    }
                  
                }
                else if (entorno.ObtenerTipo(this.Hijos[0].Nombre).ToUpper().Contains("DOUBLE")
                    && (this.Hijos[1].Nombre.ToString() == "Entero" || this.Hijos[1].Nombre.ToString() == "Decimal" || this.Hijos[1].Nombre == "EXP")
                    && DecimalEntero == false
                 )
                {
                    //ASIGANACION DE UNA VARIABLE DE TIPO DOUBLE
                    System.Diagnostics.Debug.WriteLine("la variable es decimal");
                    entorno.AsignarValor(this.Hijos[0].Nombre, Variable1);
                    return "ASIGNAR";
                }
                else if (entorno.ObtenerTipo(this.Hijos[0].Nombre).ToUpper().Contains("BOOLEAN")
                    && (this.Hijos[1].Nombre.ToString().Contains("Booleano") || this.Hijos[1].Nombre == "EXP")
                    && ElBool == false

                    )
                {
                    //ASIGANACION DE UNA VARIABLE DE TIPO voolena
                    //System.Diagnostics.Debug.WriteLine("la variable es boleano");
                    entorno.AsignarValor(this.Hijos[0].Nombre, Variable1);
                    return "ASIGNAR";

                }
                else if (entorno.ObtenerTipo(this.Hijos[0].Nombre).ToUpper().Contains("STRING")
                    && (this.Hijos[1].Nombre.ToString().Contains("Cadena") || this.Hijos[1].Nombre == "EXP")
                    //&& ElBool == false

                    )
                {
                    //ASIGANACION DE UNA VARIABLE DE TIPO string
                    System.Diagnostics.Debug.WriteLine("la variable es StringX");
                    entorno.AsignarValor(this.Hijos[0].Nombre, Variable1);

                    return "ASIGNAR";
                }
                else if (entorno.ObtenerTipo(this.Hijos[0].Nombre).ToUpper().Contains("DATE")
                   && (this.Hijos[1].Nombre.ToString().Contains("Fecha") || this.Hijos[1].Nombre == "EXP")
                   //&& ElBool == false

                   )
                {
                    //ASIGANACION DE UNA VARIABLE DE TIPO fechas
                    entorno.AsignarValor(this.Hijos[0].Nombre, Variable1);
                    return "ASIGNAR";

                }
                else if (entorno.ObtenerTipo(this.Hijos[0].Nombre).ToUpper().Contains("TIME")
                   && (this.Hijos[1].Nombre.ToString().Contains("hora") || this.Hijos[1].Nombre == "EXP")
                   //&& ElBool == false

                   )
                {
                    //ASIGANACION DE UNA VARIABLE DE TIPO fechas
                    entorno.AsignarValor(this.Hijos[0].Nombre, Variable1);
                    return "ASIGNAR";

                }
                else if (this.Hijos[1].TipoDato == "id2")
                {
                    String TIPO1 = entorno.ObtenerTipo(this.Hijos[1].NombreVariable);
                    String TIPO2 = entorno.ObtenerTipo(this.Hijos[0].Nombre);
                    //System.Diagnostics.Debug.WriteLine("AAAAAH PERRO ERES UN ID DE TIPO2" + entorno.ObtenerTipo(this.Hijos[1].NombreVariable));
                   // System.Diagnostics.Debug.WriteLine("AAAAAH PERRO ERES UN ID DE TIPO1" + entorno.ObtenerTipo(this.Hijos[0].Nombre));
                    if (TIPO1.ToUpper().Contains(TIPO2.ToUpper()))
                    {
                        System.Diagnostics.Debug.WriteLine("SON DEL MISMO TIPO");
                        entorno.AsignarValor(this.Hijos[0].Nombre, entorno.ObtenerValor(this.Hijos[1].NombreVariable));
                        return "ASIGNAR";
                    }
                    else
                    {
                        if (TIPO1.ToUpper().Contains("INT") && TIPO2.ToUpper().Contains("DOUBLE"))
                        {
                            entorno.AsignarValor(this.Hijos[0].Nombre, entorno.ObtenerValor(this.Hijos[1].NombreVariable));
                            return "ASIGNAR";

                        }
                        else if (TIPO1.ToUpper().Contains("DOUBLE") && TIPO2.ToUpper().Contains("INT"))
                        {
                            entorno.AsignarValor(this.Hijos[0].Nombre, entorno.ObtenerValor(this.Hijos[1].NombreVariable));
                            return "ASIGNAR";

                        }
                        else {

                            System.Diagnostics.Debug.WriteLine("DIFERENTE TIPO");
                            return "#Error3" + "#ERROR: Asignaccion incorrect con variable " + var;
                        }
                        
                    }

                   
                }
               
                else if(Variable1.ToUpper().Contains("TRUE")|| Variable1.ToUpper().Contains("FALSE"))
                {
                    if (entorno.ObtenerTipo(var).ToUpper().Contains("BOOL") == true)
                    {
                        entorno.AsignarValor(var, Variable1);
                        return "ASIGNAR";
                    }
                }

                else
                {
                    System.Diagnostics.Debug.WriteLine("#Error3 asiganacion incorrecta");
                    return "#Error3" + "#ERROR: Asignaccion incorrect con variable " + var;
                }


                

            }
            //System.Diagnostics.Debug.WriteLine("**********************" + this.Hijos[0].AutoIncrmentable);
            
            sali = entorno.ObtenerValor(this.Hijos[1].Nombre);
            return sali;
        }
    }
}