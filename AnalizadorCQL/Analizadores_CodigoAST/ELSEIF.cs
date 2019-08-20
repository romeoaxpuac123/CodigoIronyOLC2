using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class ELSEIF : NodoAbstracto

    {
        public ELSEIF(String Valor) : base(Valor)
        {


        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado IF ELSE");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado IF ELSE");

            
            String ValorExpresion = this.Hijos[0].Ejecutar(entorno);
            String valor1 = "";
            if (ValorExpresion.ToUpper().Contains("TRUE"))
            {
                System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                foreach (NodoAbstracto sentencia in this.Hijos[1].Hijos)
                {
                    System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                    valor1 = sentencia.Ejecutar(entorno);
                    if (valor1.Contains("#Error") == true)
                    {
                        System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                        break;
                        //return "#Error";
                    }

                }
                //ValorExpresion = this.Hijos[0].Ejecutar(entorno);
            }
            else
            {
                
                // primer ELSE IF 
                String Expresion1 = this.Hijos[2].Hijos[0].Nombre;
                System.Diagnostics.Debug.WriteLine("EL ESE 1" + Expresion1);
                String ValorElse = "FALSE";
                int hijo1 = 1;
                String Expresion2 = "";
                String Expresion3 = "";
                String Expresion4 = "";
                String Expresion5 = "";
                String Expresion6 = "";
                String Expresion7 = "";
                String Expresion8 = "";
                String Expresion9 = "";
                String Expresion10 = "";
                ///PARA EL PRIMER ELSE IF
                ///
                if (hijo1 == 1)
                {
                    if (Expresion1.Contains("SINO") && ValorElse.Contains("FALSE"))
                    {
                        String ValorExpresion1 = this.Hijos[2].Hijos[1].Ejecutar(entorno);
                        System.Diagnostics.Debug.WriteLine("EL bool 1" + ValorExpresion1);
                        hijo1 = 2;
                        ValorElse = ValorExpresion1.ToUpper();
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[2].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    break;
                                    //return "#Error";
                                }

                            }
                        Expresion2 = this.Hijos[2].Hijos[0].Hijos[0].Nombre;
                        System.Diagnostics.Debug.WriteLine("EL ESE 2" + Expresion2);
                    }
                    else if (ValorElse.Contains("FALSE"))
                    {
                        System.Diagnostics.Debug.WriteLine("caca");
                        String ValorExpresion1 = this.Hijos[2].Hijos[0].Ejecutar(entorno);
                        System.Diagnostics.Debug.WriteLine("EL bool 1" + ValorExpresion1);

                        ValorElse = ValorExpresion1.ToUpper();
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[1].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    break;
                                    //return "#Error";
                                }

                            }
                    }
                }
                //para el segundo els if
                if (hijo1 == 2) {
                    if (Expresion2.Contains("SINO") && ValorElse.Contains("FALSE"))
                    {
                        String ValorExpresion1 = this.Hijos[2].Hijos[0].Hijos[1].Ejecutar(entorno);
                        System.Diagnostics.Debug.WriteLine("EL bool 2" + ValorExpresion1);
                        hijo1 = 3;
                        ValorElse = ValorExpresion1.ToUpper();
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[0].Hijos[2].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    break;
                                    //return "#Error";
                                }

                            }
                        Expresion3 = this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Nombre;
                        //System.Diagnostics.Debug.WriteLine("EL ESE 2" + Expresion2);
                    }
                    else if(ValorElse.Contains("FALSE"))
                    {
                        System.Diagnostics.Debug.WriteLine("caca");
                        String ValorExpresion1 = this.Hijos[2].Hijos[0].Hijos[0].Ejecutar(entorno);
                        System.Diagnostics.Debug.WriteLine("EL bool 1" + ValorExpresion1);

                        ValorElse = ValorExpresion1.ToUpper();
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[0].Hijos[1].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    break;
                                    //return "#Error";
                                }

                            }
                    }


                }
                // para el tercero
                if(hijo1 == 3)
                {
                    if (Expresion3.Contains("SINO") && ValorElse.Contains("FALSE"))
                    {
                        String ValorExpresion1 = this.Hijos[2].Hijos[0].Hijos[0].Hijos[1].Ejecutar(entorno);
                        System.Diagnostics.Debug.WriteLine("EL bool 2" + ValorExpresion1);
                        hijo1 = 4;
                        ValorElse = ValorExpresion1.ToUpper();
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[0].Hijos[0].Hijos[2].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    break;
                                    //return "#Error";
                                }

                            }
                        Expresion4 = this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Nombre;
                        //System.Diagnostics.Debug.WriteLine("EL ESE 2" + Expresion2);
                    }
                    else if (ValorElse.Contains("FALSE"))
                    {
                        System.Diagnostics.Debug.WriteLine("caca");
                        String ValorExpresion1 = this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Ejecutar(entorno);
                        System.Diagnostics.Debug.WriteLine("EL bool 1" + ValorExpresion1);

                        ValorElse = ValorExpresion1.ToUpper();
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[0].Hijos[0].Hijos[1].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    break;
                                    //return "#Error";
                                }

                            }
                    }

                }
                // para el cuarto
                if (hijo1 == 4)
                {
                    if (Expresion4.Contains("SINO") && ValorElse.Contains("FALSE"))
                    {
                        String ValorExpresion1 = this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[1].Ejecutar(entorno);
                        System.Diagnostics.Debug.WriteLine("EL bool 2" + ValorExpresion1);
                        hijo1 = 5;
                        ValorElse = ValorExpresion1.ToUpper();
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[2].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    break;
                                    //return "#Error";
                                }

                            }
                        Expresion5= this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Nombre;
                        //System.Diagnostics.Debug.WriteLine("EL ESE 2" + Expresion2);
                    }
                    else if (ValorElse.Contains("FALSE"))
                    {
                        System.Diagnostics.Debug.WriteLine("caca");
                        String ValorExpresion1 = this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Ejecutar(entorno);
                        System.Diagnostics.Debug.WriteLine("EL bool 1" + ValorExpresion1);

                        ValorElse = ValorExpresion1.ToUpper();
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[1].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    break;
                                    //return "#Error";
                                }

                            }
                    }

                }
                // para el quinto
                if (hijo1 == 5)
                {
                    if (Expresion5.Contains("SINO") && ValorElse.Contains("FALSE"))
                    {
                        String ValorExpresion1 = this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[1].Ejecutar(entorno);
                        System.Diagnostics.Debug.WriteLine("EL bool 2" + ValorExpresion1);
                        hijo1 = 6;
                        ValorElse = ValorExpresion1.ToUpper();
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[2].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    break;
                                    //return "#Error";
                                }

                            }
                        Expresion6 = this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Nombre;
                        //System.Diagnostics.Debug.WriteLine("EL ESE 2" + Expresion2);
                    }
                    else if (ValorElse.Contains("FALSE"))
                    {
                        System.Diagnostics.Debug.WriteLine("caca");
                        String ValorExpresion1 = this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Ejecutar(entorno);
                        System.Diagnostics.Debug.WriteLine("EL bool 1" + ValorExpresion1);

                        ValorElse = ValorExpresion1.ToUpper();
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[1].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    break;
                                    //return "#Error";
                                }

                            }
                    }

                }
                // para el sexto
                if (hijo1 == 6)
                {
                    if (Expresion6.Contains("SINO") && ValorElse.Contains("FALSE"))
                    {
                        String ValorExpresion1 = this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[1].Ejecutar(entorno);
                        System.Diagnostics.Debug.WriteLine("EL bool 2" + ValorExpresion1);
                        hijo1 = 7;
                        ValorElse = ValorExpresion1.ToUpper();
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[2].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    break;
                                    //return "#Error";
                                }

                            }
                        Expresion7 = this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Nombre;
                        //System.Diagnostics.Debug.WriteLine("EL ESE 2" + Expresion2);
                    }
                    else if (ValorElse.Contains("FALSE"))
                    {
                        System.Diagnostics.Debug.WriteLine("caca");
                        String ValorExpresion1 = this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Ejecutar(entorno);
                        System.Diagnostics.Debug.WriteLine("EL bool 1" + ValorExpresion1);

                        ValorElse = ValorExpresion1.ToUpper();
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[1].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    break;
                                    //return "#Error";
                                }

                            }
                    }

                }
                // para el sieto
                if (hijo1 == 7)
                {
                    if (Expresion7.Contains("SINO") && ValorElse.Contains("FALSE"))
                    {
                        String ValorExpresion1 = this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[1].Ejecutar(entorno);
                        System.Diagnostics.Debug.WriteLine("EL bool 2" + ValorExpresion1);
                        hijo1 = 8;
                        ValorElse = ValorExpresion1.ToUpper();
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[2].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    break;
                                    //return "#Error";
                                }

                            }
                        Expresion8= this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Nombre;
                        //System.Diagnostics.Debug.WriteLine("EL ESE 2" + Expresion2);
                    }
                    else if (ValorElse.Contains("FALSE"))
                    {
                        System.Diagnostics.Debug.WriteLine("caca");
                        String ValorExpresion1 = this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Ejecutar(entorno);
                        System.Diagnostics.Debug.WriteLine("EL bool 1" + ValorExpresion1);

                        ValorElse = ValorExpresion1.ToUpper();
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[1].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    break;
                                    //return "#Error";
                                }

                            }
                    }

                }
                // para el ocho
                if (hijo1 == 8)
                {
                    if (Expresion8.Contains("SINO") && ValorElse.Contains("FALSE"))
                    {
                        String ValorExpresion1 = this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[1].Ejecutar(entorno);
                        System.Diagnostics.Debug.WriteLine("EL bool 2" + ValorExpresion1);
                        hijo1 = 9;
                        ValorElse = ValorExpresion1.ToUpper();
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[2].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    break;
                                    //return "#Error";
                                }

                            }
                        Expresion9 = this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Nombre;
                        //System.Diagnostics.Debug.WriteLine("EL ESE 2" + Expresion2);
                    }
                    else if (ValorElse.Contains("FALSE"))
                    {
                        System.Diagnostics.Debug.WriteLine("caca");
                        String ValorExpresion1 = this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Ejecutar(entorno);
                        System.Diagnostics.Debug.WriteLine("EL bool 1" + ValorExpresion1);

                        ValorElse = ValorExpresion1.ToUpper();
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[1].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    break;
                                    //return "#Error";
                                }

                            }
                    }

                }
                // para el nueve
                if (hijo1 == 9)
                {
                    if (Expresion9.Contains("SINO") && ValorElse.Contains("FALSE"))
                    {
                        String ValorExpresion1 = this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[1].Ejecutar(entorno);
                        System.Diagnostics.Debug.WriteLine("EL bool 2" + ValorExpresion1);
                        hijo1 = 10;
                        ValorElse = ValorExpresion1.ToUpper();
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[2].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    break;
                                    //return "#Error";
                                }

                            }
                        Expresion10 = this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Nombre;
                        //System.Diagnostics.Debug.WriteLine("EL ESE 2" + Expresion2);
                    }
                    else if (ValorElse.Contains("FALSE"))
                    {
                        System.Diagnostics.Debug.WriteLine("caca");
                        String ValorExpresion1 = this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Ejecutar(entorno);
                        System.Diagnostics.Debug.WriteLine("EL bool 1" + ValorExpresion1);

                        ValorElse = ValorExpresion1.ToUpper();
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[1].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    break;
                                    //return "#Error";
                                }

                            }
                    }

                }
                // para el nueve
                if (hijo1 == 10)
                {
                    if (Expresion10.Contains("SINO") && ValorElse.Contains("FALSE"))
                    {
                        String ValorExpresion1 = this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[1].Ejecutar(entorno);

                        System.Diagnostics.Debug.WriteLine("EL bool 10" + ValorExpresion1);
                        hijo1 = 11;
                        ValorElse = ValorExpresion1.ToUpper();
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[2].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    break;
                                    //return "#Error";
                                }

                            }
                        //ya esta para evaluar
                        //Expresion11 = this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Nombre;
                        //System.Diagnostics.Debug.WriteLine("EL ESE 2" + Expresion2);
                    }
                    else if (ValorElse.Contains("FALSE"))
                    {
                        System.Diagnostics.Debug.WriteLine("caca");
                        String ValorExpresion1 = this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Ejecutar(entorno);
                        System.Diagnostics.Debug.WriteLine("EL bool 1" + ValorExpresion1);

                        ValorElse = ValorExpresion1.ToUpper();
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[0].Hijos[1].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    break;
                                    //return "#Error";
                                }

                            }
                    }

                }

            }

            return "ELSE IF";
        }
    }
}