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
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado IF ELSErr");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado IF ELSEeee" + this.AutoIncrmentable2);
            if(this.AutoIncrmentable2 == 1)
            {
                System.Diagnostics.Debug.WriteLine("Se esta ejecutnado IF ELSEeee true 1");
                String valor1 = "";
                Entorno NuevoEntorno = new Entorno();
                entorno.NuevasVariables(NuevoEntorno);
                entorno.NuevasFunciones(NuevoEntorno);
                //entorno.NuevasFunciones(NuevoEntorno);
               
                String ValorExpresion = this.Hijos[0].Ejecutar(NuevoEntorno);
                
                if (ValorExpresion.ToUpper().Contains("TRUE") == true)
                {
                   
                    for (int ix = 0; ix < this.Hijos[1].Hijos.Count; ix++)
                    {
                        valor1 = this.Hijos[1].Hijos[ix].Ejecutar(NuevoEntorno);
                        System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL ify " + valor1);
                        if (valor1.Contains("BREAK") == true)
                        {
                            return "BREAK";
                            //return "#Error";
                        }
                        if (valor1.Contains("RETORNO:") == true)
                        {

                            return valor1;
                        }
                        if (valor1.ToUpper().Contains("#ERROR") == true)
                        {

                            return valor1;

                        }
                    }
                    NuevoEntorno.AsignarNuevosValores(entorno);

                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Se esta ejecutnado IF ELSEeee false");
                    for (int ix = 0; ix < this.Hijos[2].Hijos.Count; ix++)
                    {
                        valor1 = this.Hijos[2].Hijos[ix].Ejecutar(NuevoEntorno);
                        System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL ifyy " + valor1);
                        if (valor1.Contains("BREAK") == true)
                        {
                            return "BREAK";
                            //return "#Error";
                        }
                        if (valor1.Contains("RETORNO:") == true)
                        {

                            return valor1;
                        }
                        if (valor1.ToUpper().Contains("#ERROR") == true)
                        {

                            return valor1;

                        }
                    }
                    NuevoEntorno.AsignarNuevosValores(entorno);
                }

            }


            if (this.AutoIncrmentable2 == 2)
            {
                System.Diagnostics.Debug.WriteLine("Se esta ejecutnado IF ELSEeee true2");
                String valor1 = "";
                Entorno NuevoEntorno = new Entorno();
                entorno.NuevasVariables(NuevoEntorno);
                //entorno.NuevasFunciones(NuevoEntorno);
                String ValorExpresion = this.Hijos[0].Ejecutar(NuevoEntorno);
                if (ValorExpresion.ToUpper().Contains("TRUE") == true)
                {
                    for (int ix = 0; ix < this.Hijos[1].Hijos.Count; ix++)
                    {
                        valor1 = this.Hijos[1].Hijos[ix].Ejecutar(NuevoEntorno);
                        System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL ifx " + valor1);
                        if (valor1.Contains("BREAK") == true)
                        {
                            return "BREAK";
                            //return "#Error";
                        }
                        if (valor1.Contains("RETORNO:") == true)
                        {

                            return valor1;
                        }
                        if (valor1.ToUpper().Contains("#ERROR") == true)
                        {

                            return valor1;

                        }
                    }
                    NuevoEntorno.AsignarNuevosValores(entorno);

                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("fallamos perro");
                    valor1 = this.Hijos[2].Ejecutar(entorno);
                    
                }

            }
            /*
            
            String ValorExpresion = this.Hijos[0].Ejecutar(entorno);
            String valor1 = "";
            String ValorElse = "FALSE";
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
                        //break;
                        return "#Error";
                    }
                    if (valor1.Contains("BREAK") == true)
                    {
                        return "BREAK";
                        //return "#Error";
                    }
                    if (valor1.Contains("RETORNO:") == true)
                    {

                        return valor1;
                    }

                }
                //ValorExpresion = this.Hijos[0].Ejecutar(entorno);
            }
            else
            {

                // primer ELSE IF 
                String Expresion1 = this.Hijos[2].Hijos[0].Nombre;
                System.Diagnostics.Debug.WriteLine("EL ESE 1" + Expresion1);
                System.Diagnostics.Debug.WriteLine("EL ESE 2" + this.Hijos[2].Nombre);
                String TipoNodo2 = this.Hijos[2].Nombre;

                ///PARA EL PRIMER ELSE IF
                ///
                if (TipoNodo2.ToUpper().Contains("SENTENCIAS") == true)
                {
                    ValorElse = "TRUE";
                    if (ValorElse.ToUpper().Contains("TRUE"))
                        foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos)
                        {
                            //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                            valor1 = sentencia.Ejecutar(entorno);
                            if (valor1.Contains("#Error") == true)
                            {
                                System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                // break;
                                return "#Error";
                            }
                            if (valor1.Contains("BREAK") == true)
                            {
                                return "BREAK";
                                //return "#Error";
                            }
                            if (valor1.Contains("RETORNO:") == true)
                            {

                                return valor1;
                            }

                        }
                    return "ELSE IF";
                }
                else if (TipoNodo2.ToUpper().Contains("SINO") && ValorElse.Contains("FALSE"))
                {
                    ValorElse = this.Hijos[2].Hijos[0].Ejecutar(entorno);
                    // System.Diagnostics.Debug.WriteLine("debus Romeo: x" + ValorElse);
                    if (ValorElse.ToUpper().Contains("TRUE"))
                    {
                        foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[1].Hijos)
                        {
                            //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                            valor1 = sentencia.Ejecutar(entorno);
                            if (valor1.Contains("#Error") == true)
                            {
                                System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                // break;
                                return "#Error";
                            }
                            if (valor1.Contains("BREAK") == true)
                            {
                                return "BREAK";
                                //return "#Error";
                            }
                            if (valor1.Contains("RETORNO:") == true)
                            {

                                return valor1;
                            }

                        }
                        return "ELSE IF";
                    }

                }

                //para el segundo else if
                if (ValorElse.ToUpper().Contains("FALSE"))
                {
                    //if(this.Hijos[2].Hijos[])

                    //System.Diagnostics.Debug.WriteLine("probando else del nivel 2 " + this.Hijos[2].Hijos[2].Nombre);
                    if (this.Hijos[2].AutoIncrmentable2 == 9090)
                    {
                        ValorElse = this.Hijos[2].Hijos[2].Hijos[0].Ejecutar(entorno);
                        // System.Diagnostics.Debug.WriteLine("debus Romeo: x" + ValorElse);
                        if (ValorElse.ToUpper().Contains("TRUE"))
                        {
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[2].Hijos[1].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    // break;
                                    return "#Error";
                                }
                                if (valor1.Contains("BREAK") == true)
                                {
                                    return "BREAK";
                                    //return "#Error";
                                }
                                if (valor1.Contains("RETORNO:") == true)
                                {

                                    return valor1;
                                }

                            }
                            return "ELSE IF";
                        }
                        //fin
                    }
                    else if (this.Hijos[2].AutoIncrmentable2 == 666)
                    {
                        ValorElse = "TRUE";
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[2].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    // break;
                                    return "#Error";
                                }
                                if (valor1.Contains("BREAK") == true)
                                {
                                    return "BREAK";
                                    //return "#Error";
                                }
                                if (valor1.Contains("RETORNO:") == true)
                                {

                                    return valor1;
                                }

                            }
                        return "ELSE IF";
                    }
                    else
                    {
                        return "IF-ESLE";
                    }
                }
                //para el tercer else if
                if (ValorElse.ToUpper().Contains("FALSE"))
                {
                    System.Diagnostics.Debug.WriteLine("probando else del nivel 3 " + this.Hijos[2].Hijos[2].AutoIncrmentable2);
                    if (this.Hijos[2].Hijos[2].AutoIncrmentable2 == 9090)
                    {
                        ValorElse = this.Hijos[2].Hijos[2].Hijos[2].Hijos[0].Ejecutar(entorno);
                        // System.Diagnostics.Debug.WriteLine("debus Romeo: x" + ValorElse);
                        if (ValorElse.ToUpper().Contains("TRUE"))
                        {
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[2].Hijos[2].Hijos[1].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    // break;
                                    return "#Error";
                                }
                                if (valor1.Contains("BREAK") == true)
                                {
                                    return "BREAK";
                                    //return "#Error";
                                }
                                if (valor1.Contains("RETORNO:") == true)
                                {

                                    return valor1;
                                }

                            }
                            return "ELSE IF";
                        }
                        //fin
                    }
                    else if (this.Hijos[2].Hijos[2].AutoIncrmentable2 == 666)
                    {

                        ValorElse = "TRUE";
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[2].Hijos[2].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    // break;
                                    return "#Error";
                                }
                                if (valor1.Contains("BREAK") == true)
                                {
                                    return "BREAK";
                                    //return "#Error";
                                }
                                if (valor1.Contains("RETORNO:") == true)
                                {

                                    return valor1;
                                }

                            }
                        return "ELSE IF";

                    }
                    else
                    {
                        return "IF-ESLE";
                    }
                }

                //para el cuarto else if
                if (ValorElse.ToUpper().Contains("FALSE"))
                {
                    System.Diagnostics.Debug.WriteLine("probando else del nivel 4 " + this.Hijos[2].Hijos[2].Hijos[2].AutoIncrmentable2);
                    if (this.Hijos[2].Hijos[2].Hijos[2].AutoIncrmentable2 == 9090)
                    {
                        ValorElse = this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[0].Ejecutar(entorno);
                        // System.Diagnostics.Debug.WriteLine("debus Romeo: x" + ValorElse);
                        if (ValorElse.ToUpper().Contains("TRUE"))
                        {
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[1].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    // break;
                                    return "#Error";
                                }
                                if (valor1.Contains("BREAK") == true)
                                {
                                    return "BREAK";
                                    //return "#Error";
                                }
                                if (valor1.Contains("RETORNO:") == true)
                                {

                                    return valor1;
                                }

                            }
                            return "ELSE IF";
                        }
                        //fin
                    }
                    else if (this.Hijos[2].Hijos[2].Hijos[2].AutoIncrmentable2 == 666)
                    {

                        ValorElse = "TRUE";
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    // break;
                                    return "#Error";
                                }
                                if (valor1.Contains("BREAK") == true)
                                {
                                    return "BREAK";
                                    //return "#Error";
                                }
                                if (valor1.Contains("RETORNO:") == true)
                                {

                                    return valor1;
                                }

                            }
                        return "ELSE IF";

                    }
                    else
                    {
                        return "IF-ESLE";
                    }

                }
                //para el quinto else if
                if (ValorElse.ToUpper().Contains("FALSE"))
                {
                    System.Diagnostics.Debug.WriteLine("probando else del nivel 5 " + this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].AutoIncrmentable2);
                    if (this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].AutoIncrmentable2 == 9090)
                    {
                        ValorElse = this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[0].Ejecutar(entorno);
                        // System.Diagnostics.Debug.WriteLine("debus Romeo: x" + ValorElse);
                        if (ValorElse.ToUpper().Contains("TRUE"))
                        {
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[1].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    // break;
                                    return "#Error";
                                }
                                if (valor1.Contains("BREAK") == true)
                                {
                                    return "BREAK";
                                    //return "#Error";
                                }
                                if (valor1.Contains("RETORNO:") == true)
                                {

                                    return valor1;
                                }

                            }
                            return "ELSE IF";
                        }
                        //fin
                    }
                    else if (this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].AutoIncrmentable2 == 666)
                    {

                        ValorElse = "TRUE";
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    // break;
                                    return "#Error";
                                }
                                if (valor1.Contains("BREAK") == true)
                                {
                                    return "BREAK";
                                    //return "#Error";
                                }
                                if (valor1.Contains("RETORNO:") == true)
                                {

                                    return valor1;
                                }

                            }
                        return "ELSE IF";

                    }
                    else
                    {
                        return "IF-ESLE";
                    }
                }
                //para el sexto else if
                if (ValorElse.ToUpper().Contains("FALSE"))
                {
                    System.Diagnostics.Debug.WriteLine("probando else del nivel 6 " + this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].AutoIncrmentable2);
                    if (this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].AutoIncrmentable2 == 9090)
                    {
                        ValorElse = this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[0].Ejecutar(entorno);
                        // System.Diagnostics.Debug.WriteLine("debus Romeo: x" + ValorElse);
                        if (ValorElse.ToUpper().Contains("TRUE"))
                        {
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[1].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    // break;
                                    return "#Error";
                                }
                                if (valor1.Contains("BREAK") == true)
                                {
                                    return "BREAK";
                                    //return "#Error";
                                }
                                if (valor1.Contains("RETORNO:") == true)
                                {

                                    return valor1;
                                }

                            }
                            return "ELSE IF";
                        }
                        //fin
                    }
                    else if (this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].AutoIncrmentable2 == 666)
                    {

                        ValorElse = "TRUE";
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    // break;
                                    return "#Error";
                                }
                                if (valor1.Contains("BREAK") == true)
                                {
                                    return "BREAK";
                                    //return "#Error";
                                }
                                if (valor1.Contains("RETORNO:") == true)
                                {

                                    return valor1;
                                }

                            }
                        return "ELSE IF";

                    }
                    else
                    {
                        return "IF-ESLE";
                    }
                }
                //para el septimo else if
                if (ValorElse.ToUpper().Contains("FALSE"))
                {
                    System.Diagnostics.Debug.WriteLine("probando else del nivel 7 " + this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].AutoIncrmentable2);
                    if (this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].AutoIncrmentable2 == 9090)
                    {
                        ValorElse = this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[0].Ejecutar(entorno);
                        // System.Diagnostics.Debug.WriteLine("debus Romeo: x" + ValorElse);
                        if (ValorElse.ToUpper().Contains("TRUE"))
                        {
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[1].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    // break;
                                    return "#Error";
                                }
                                if (valor1.Contains("BREAK") == true)
                                {
                                    return "BREAK";
                                    //return "#Error";
                                }
                                if (valor1.Contains("RETORNO:") == true)
                                {

                                    return valor1;
                                }

                            }
                            return "ELSE IF";
                        }
                        //fin
                    }
                    else if (this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].AutoIncrmentable2 == 666)
                    {

                        ValorElse = "TRUE";
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    // break;
                                    return "#Error";
                                }
                                if (valor1.Contains("BREAK") == true)
                                {
                                    return "BREAK";
                                    //return "#Error";
                                }
                                if (valor1.Contains("RETORNO:") == true)
                                {

                                    return valor1;
                                }

                            }
                        return "ELSE IF";

                    }
                    else
                    {
                        return "IF-ESLE";
                    }

                }
                //para el octavo
                if (ValorElse.ToUpper().Contains("FALSE"))
                {
                    System.Diagnostics.Debug.WriteLine("probando else del nivel 8 " + this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].AutoIncrmentable2);
                    if (this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].AutoIncrmentable2 == 9090)
                    {
                        ValorElse = this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[0].Ejecutar(entorno);
                        // System.Diagnostics.Debug.WriteLine("debus Romeo: x" + ValorElse);
                        if (ValorElse.ToUpper().Contains("TRUE"))
                        {
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[1].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    // break;
                                    return "#Error";
                                }
                                if (valor1.Contains("BREAK") == true)
                                {
                                    return "BREAK";
                                    //return "#Error";
                                }
                                if (valor1.Contains("RETORNO:") == true)
                                {

                                    return valor1;
                                }

                            }
                            return "ELSE IF";
                        }
                        //fin
                    }
                    else if (this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].AutoIncrmentable2 == 666)
                    {

                        ValorElse = "TRUE";
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    // break;
                                    return "#Error";
                                }
                                if (valor1.Contains("BREAK") == true)
                                {
                                    return "BREAK";
                                    //return "#Error";
                                }
                                if (valor1.Contains("RETORNO:") == true)
                                {

                                    return valor1;
                                }

                            }
                        return "ELSE IF";

                    }
                    else
                    {
                        return "IF-ESLE";
                    }


                }
                //para el noveno
                if (ValorElse.ToUpper().Contains("FALSE"))
                {
                    System.Diagnostics.Debug.WriteLine("probando else del nivel 9 " + this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].AutoIncrmentable2);
                    if (this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].AutoIncrmentable2 == 9090)
                    {
                        ValorElse = this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[0].Ejecutar(entorno);
                        // System.Diagnostics.Debug.WriteLine("debus Romeo: x" + ValorElse);
                        if (ValorElse.ToUpper().Contains("TRUE"))
                        {
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[1].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    // break;
                                    return "#Error";
                                }
                                if (valor1.Contains("BREAK") == true)
                                {
                                    return "BREAK";
                                    //return "#Error";
                                }
                                if (valor1.Contains("RETORNO:") == true)
                                {

                                    return valor1;
                                }

                            }
                            return "ELSE IF";
                        }
                        //fin
                    }
                    else if (this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].AutoIncrmentable2 == 666)
                    {

                        ValorElse = "TRUE";
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    // break;
                                    return "#Error";
                                }
                                if (valor1.Contains("BREAK") == true)
                                {
                                    return "BREAK";
                                    //return "#Error";
                                }
                                if (valor1.Contains("RETORNO:") == true)
                                {

                                    return valor1;
                                }

                            }
                        return "ELSE IF";

                    }

                    else
                    {
                        return "IF-ESLE";
                    }
                }
                //para el decimo
                if (ValorElse.ToUpper().Contains("FALSE"))
                {
                    System.Diagnostics.Debug.WriteLine("probando else del nivel 10 " + this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].AutoIncrmentable2);
                    if (this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].AutoIncrmentable2 == 9090)
                    {
                        ValorElse = this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[0].Ejecutar(entorno);
                        // System.Diagnostics.Debug.WriteLine("debus Romeo: x" + ValorElse);
                        if (ValorElse.ToUpper().Contains("TRUE"))
                        {
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[1].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    // break;
                                    return "#Error";
                                }
                                if (valor1.Contains("BREAK") == true)
                                {
                                    return "BREAK";
                                    //return "#Error";
                                }
                                if (valor1.Contains("RETORNO:") == true)
                                {

                                    return valor1;
                                }

                            }
                            return "ELSE IF";
                        }
                        //fin
                    }
                    else if (this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].AutoIncrmentable2 == 666)
                    {

                        ValorElse = "TRUE";
                        if (ValorElse.ToUpper().Contains("TRUE"))
                            foreach (NodoAbstracto sentencia in this.Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos[2].Hijos)
                            {
                                //System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL if");
                                valor1 = sentencia.Ejecutar(entorno);
                                if (valor1.Contains("#Error") == true)
                                {
                                    System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL if");
                                    // break;
                                    return "#Error";
                                }
                                if (valor1.Contains("BREAK") == true)
                                {
                                    return "BREAK";
                                    //return "#Error";
                                }
                                if (valor1.Contains("RETORNO:") == true)
                                {

                                    return valor1;
                                }

                            }
                        return "ELSE IF";

                    }

                    else
                    {
                        return "IF-ESLE";
                    }
                }

            }

            */
            return "ELSE IF";
        }
           
    }
}