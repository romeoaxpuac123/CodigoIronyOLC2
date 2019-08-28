using AnalizadorCQL.Analizadores_Codigo;
using AnalizadorCQL.Analizadores_CodigoAST;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Linq;
namespace AnalizadorCQL.Analizadores
{
    public class Recorrido
    {
        public NodoAbstracto Raiz;
        List<String> primes = new List<String>();
        public NodoAbstracto Recorrido1(ParseTreeNode root)
        {
            Gramatica g = new Gramatica();
            switch (root.ChildNodes.Count)
            {
                case 0:

                    if (root.ToString().Contains("- (Key symbol)"))
                    {
                        //    Console.WriteLine("PASO POR UN NUMERO");
                        NodoAbstracto RESULT1 = null;
                        NodoAbstracto nuevox = new Nodo("Entero");
                        NodoAbstracto nuevovalor = new Nodo("-1");
                        nuevox.Hijos.Add(nuevovalor);
                        nuevox.TipoDato = "entero";
                        RESULT1 = nuevox;
                        //Raiz = nuevox;
                        return RESULT1;

                    }
                    else if (root.ToString().Contains("+ (Key symbol)"))
                    {
                        //    Console.WriteLine("PASO POR UN NUMERO");
                        NodoAbstracto RESULT1 = null;
                        NodoAbstracto nuevox = new Nodo("Entero");
                        NodoAbstracto nuevovalor = new Nodo("+0");
                        nuevox.Hijos.Add(nuevovalor);
                        nuevox.TipoDato = "entero";
                        RESULT1 = nuevox;
                        //Raiz = nuevox;
                        return RESULT1;

                    }
                    else if (root.ToString().Contains("++ (Key symbol)"))
                    {
                        //    Console.WriteLine("PASO POR UN NUMERO");
                        NodoAbstracto RESULT1 = null;
                        NodoAbstracto nuevox = new Nodo("Entero");
                        NodoAbstracto nuevovalor = new Nodo("+0");
                        nuevox.Hijos.Add(nuevovalor);
                        nuevox.TipoDato = "entero";
                        RESULT1 = nuevox;
                        //Raiz = nuevox;
                        return RESULT1;

                    }
                   
                    else if (root.ToString().Contains("arithmeticexception"))
                    {
                        NodoAbstracto RESULT1 = null;
                        NodoAbstracto nuevox = new Nodo("arithmeticexception");
                        NodoAbstracto nuevovalor = new Nodo("arithmeticexception");
                        nuevox.Hijos.Add(nuevovalor);
                        RESULT1 = nuevox;
                        //Raiz = nuevox;
                        return RESULT1;
                    }
                    else if (root.ToString().Contains("(id)"))
                    {
                        NodoAbstracto RESULT1 = null;
                        NodoAbstracto nuevox = new Nodo("id");
                        NodoAbstracto nuevovalor = new Nodo(root.ChildNodes.ElementAt(0).ToString());
                        nuevox.Hijos.Add(nuevovalor);
                        RESULT1 = nuevox;
                        //Raiz = nuevox;
                        return RESULT1;
                    }
                    else if (root.ToString().Contains("indexoutexception"))
                    {
                        NodoAbstracto RESULT1 = null;
                        NodoAbstracto nuevox = new Nodo("indexoutexception");
                        NodoAbstracto nuevovalor = new Nodo("indexoutexception");
                        nuevox.Hijos.Add(nuevovalor);
                        RESULT1 = nuevox;
                        //Raiz = nuevox;
                        return RESULT1;
                    }
                    break;

                case 1:
                  //  Recorrido1(root.ChildNodes.ElementAt(0));
                    System.Diagnostics.Debug.WriteLine("CAso1 -> " + root.ToString());
                    if (root.ToString() == "S")
                    {
                        //Console.WriteLine("PASO POR LA EXPRESION S (RAIZ)");
                        NodoAbstracto nuevo1 = new Nodo("INICIO");
                        nuevo1.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                        Raiz = nuevo1;

                    }
                    else if (root.ToString() == "SENTENCIA")
                    {
                        //Console.WriteLine("PASO POR LA EXPRESION S (RAIZ)");


                        return (Recorrido1(root.ChildNodes.ElementAt(0)));


                    }

                    else if (root.ToString() == "DEFINCION_GENERAL_CQL")
                    {
                        //Console.WriteLine("PASO POR LA EXPRESION S (RAIZ)");


                        return (Recorrido1(root.ChildNodes.ElementAt(0)));


                    }
                    else if (root.ToString() == "LISTA_ID2")
                    {
                        //Console.WriteLine("PASO POR LA EXPRESION S (RAIZ)");


                        return (Recorrido1(root.ChildNodes.ElementAt(0)));


                    }
                    else if (root.ToString() == "SENTENCIAS")
                    {
                        //Console.WriteLine("PASO POR LA EXPRESION S (RAIZ)");

                        NodoAbstracto nuevo = new Nodo("SENTENCIAS");
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));

                        return nuevo;


                    }
                    else if (root.ToString() == "TIPOS_VARIABLES")
                    {
                        //Console.WriteLine("PASO POR LA EXPRESION S (RAIZ)");

                        NodoAbstracto nuevo = new Nodo("TIPOS_VARIABLES");
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));

                        return nuevo;


                    }
                    else if (root.ToString() == "E")
                    {
                        //System.Diagnostics.Debug.WriteLine("sssssss" + root.ChildNodes.ElementAt(0).ToString() + "sssssss");
                        if (root.ChildNodes.ElementAt(0).FindToken().ToString().Contains("(numero)"))
                        {
                            System.Diagnostics.Debug.WriteLine("!!! -> " + root.ChildNodes.ElementAt(0).ToString());
                            //    Console.WriteLine("PASO POR UN NUMERO");
                            NodoAbstracto RESULT1 = null;
                            NodoAbstracto nuevox = new Nodo("Entero");
                            NodoAbstracto nuevovalor = new Nodo(root.ChildNodes.ElementAt(0).ToString());
                            nuevox.Hijos.Add(nuevovalor);
                            nuevox.TipoDato = "entero";
                            RESULT1 = nuevox;
                            //Raiz = nuevox;
                            return RESULT1;

                        }
                        else if (root.ChildNodes.ElementAt(0).FindToken().ToString().Contains("(numdecimal)"))
                        {
                            //    Console.WriteLine("PASO POR UN NUMERO");
                            NodoAbstracto RESULT1 = null;
                            NodoAbstracto nuevox = new Nodo("Decimal");
                            NodoAbstracto nuevovalor = new Nodo(root.ChildNodes.ElementAt(0).ToString());
                            nuevox.Hijos.Add(nuevovalor);
                            nuevox.TipoDato = "decimal";
                            RESULT1 = nuevox;
                            //Raiz = nuevox;
                            return RESULT1;

                        }
                        else if (root.ChildNodes.ElementAt(0).FindToken().ToString().Contains("(cadena)"))
                        {
                            NodoAbstracto RESULT1 = null;
                            String valor = root.ChildNodes.ElementAt(0).ToString().Replace("\"", "");
                            valor = valor.Replace(" (cadena)", "");
                            NodoAbstracto nuevo = new Nodo("Cadena");
                            NodoAbstracto nuevovalor = new Nodo(valor);
                            nuevo.Hijos.Add(nuevovalor);
                            nuevo.TipoDato = "cadena";
                            RESULT1 = nuevo;
                            return RESULT1;
                        }
                        else if (root.ChildNodes.ElementAt(0).FindToken().ToString().ToUpper().Contains("FALSE")
                            || root.ChildNodes.ElementAt(0).FindToken().ToString().ToUpper().Contains("TRUE")
                            )
                        {
                            //    Console.WriteLine("PASO POR UN NUMERO");
                            NodoAbstracto RESULT1 = null;
                            NodoAbstracto nuevox = new Nodo("Booleano");
                            NodoAbstracto nuevovalor = new Nodo(root.ChildNodes.ElementAt(0).ToString().Replace(" (Keyword)", ""));
                            nuevox.Hijos.Add(nuevovalor);
                            nuevox.TipoDato = "Booleano";
                            RESULT1 = nuevox;
                            //Raiz = nuevox;
                            return RESULT1;

                        }
                        else if (root.ChildNodes.ElementAt(0).FindToken().ToString().Contains("(fechas)"))
                        {
                            //    Console.WriteLine("PASO POR UN NUMERO");
                            NodoAbstracto RESULT1 = null;
                            NodoAbstracto nuevox = new Nodo("Fechas");
                            NodoAbstracto nuevovalor = new Nodo(root.ChildNodes.ElementAt(0).ToString());
                            nuevox.Hijos.Add(nuevovalor);
                            nuevox.TipoDato = "Fechas";
                            RESULT1 = nuevox;
                            //Raiz = nuevox;
                            return RESULT1;

                        }
                        else if (root.ChildNodes.ElementAt(0).FindToken().ToString().Contains("(hora)"))
                        {
                            //    Console.WriteLine("PASO POR UN NUMERO");
                            NodoAbstracto RESULT1 = null;
                            NodoAbstracto nuevox = new Nodo("hora");
                            NodoAbstracto nuevovalor = new Nodo(root.ChildNodes.ElementAt(0).ToString());
                            nuevox.Hijos.Add(nuevovalor);
                            nuevox.TipoDato = "hora";
                            RESULT1 = nuevox;
                            //Raiz = nuevox;
                            return RESULT1;

                        }
                        else if (root.ChildNodes.ElementAt(0).FindToken().ToString().Contains("(id2)"))
                        {
                            //      Console.WriteLine("PASO POR UN ID ");
                            NodoAbstracto nuevo = new Nodo("id2");
                            NodoAbstracto nuevovalor = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id2)", ""));
                            nuevo.Hijos.Add(nuevovalor);
                            nuevo.TipoDato = "id2";
                            nuevo.NombreVariable = root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id2)", "");
                            return nuevo;

                        }
                        else if (root.ChildNodes.ElementAt(0).FindToken().ToString().Contains("(id)"))
                        {
                            //      Console.WriteLine("PASO POR UN ID ");
                            NodoAbstracto RESULT1 = null;
                            NodoAbstracto nuevox = new Nodo("id");
                            NodoAbstracto nuevovalor = new Nodo(root.ChildNodes.ElementAt(0).ToString());
                            nuevox.Hijos.Add(nuevovalor);
                            RESULT1 = nuevox;
                            //Raiz = nuevox;
                            return RESULT1;
                        }
                    }
                    

                    break;
                case 2:
                   // Recorrido1(root.ChildNodes.ElementAt(0));
                   // Recorrido1(root.ChildNodes.ElementAt(1));
                    System.Diagnostics.Debug.WriteLine("CAso2 -> " + root.ToString());
                    if (root.ChildNodes.ElementAt(0).FindToken().ToString().Contains("id")
                        && root.ChildNodes.ElementAt(1).FindToken().ToString().Contains("id2")
                       )
                    {
                        System.Diagnostics.Debug.WriteLine("CODIGO PARA CREAR UN OJBETO Estudiante @est;");


                    }
                    else if (root.ToString() == "SENTENCIA")
                    {
                        //Console.WriteLine("PASO POR LA EXPRESION S (RAIZ)");


                        return (Recorrido1(root.ChildNodes.ElementAt(0)));


                    }
                    else if (root.ToString() == "SENTENCIAS")
                    {
                        NodoAbstracto nuevo = Recorrido1(root.ChildNodes.ElementAt(0));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(1)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                        //Recorrido1(root.ChildNodes.ElementAt(0)).Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(1)));
                        //*eSTO FUNCIONO PARA LA PARTE DE IMPRIMIR VARIAS COSAS :d
                        //NodoAbstracto nuevo = new Nodo("SENTENCIAS");
                        //nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                        //nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(1)));
                        return nuevo;
                    }
                    else if (root.ToString() == "E")
                    {

                        if (root.ChildNodes.ElementAt(1).FindToken().ToString().Contains("(numero)")
                            && root.ChildNodes.ElementAt(0).ToString().Contains("- (Key symbol"))
                        {
                            //    CODIGO PARA MENOS1;
                            NodoAbstracto RESULT = null;
                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("*");
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(1)));

                            RESULT = nuevo;
                            RESULT.TipoDato = "entero";
                            return RESULT;

                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("++ (Key symbol")))
                        {
                            System.Diagnostics.Debug.WriteLine("CODIGO PARA ++ CREAR UN OJBETO Estudiante @est;");

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("+");
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(1)));
                            nuevo.AutoIncrmentable = 1;
                            nuevo.TipoDato = "decimal";

                            return nuevo;


                        }
                        else if (root.ChildNodes.ElementAt(1).FindToken().ToString().Contains("(numdecimal)")
                           && root.ChildNodes.ElementAt(0).ToString().Contains("- (Key symbol"))
                        {
                            //    CODIGO PARA MENOS1;
                            NodoAbstracto RESULT = null;
                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("*");
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(1)));

                            RESULT = nuevo;
                            RESULT.TipoDato = "decimal";
                            return RESULT;

                        }
                        else if (root.ChildNodes.ElementAt(1).FindToken().ToString().Contains("(Keyword)")
                        && root.ChildNodes.ElementAt(0).ToString().Contains("! (Key symbol"))
                        {
                            //    CODIGO PARA MENOS1;
                            NodoAbstracto RESULT = null;
                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("!");
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(1)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(1)));

                            RESULT = nuevo;
                            RESULT.TipoDato = "Booleano";
                            return RESULT;

                        }
                        else if (root.ChildNodes.ElementAt(1).ToString().Contains("E")
                       && root.ChildNodes.ElementAt(0).ToString().Contains("! (Key symbol"))
                        {
                            //    CODIGO PARA MENOS1;
                            NodoAbstracto RESULT = null;
                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("!");
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(1)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(1)));

                            RESULT = nuevo;
                            RESULT.TipoDato = "Booleano";
                            return RESULT;

                        }
                    }
                    else if (root.ToString() == "ELBREAK")
                    {
                        NodoAbstracto nuevo = new BREAK("BREAK");
                        return nuevo;
                    }
                    else if (root.ToString() == "DEFINCION_GENERAL_CQL")
                    {
                        //System.Diagnostics.Debug.WriteLine("___" + root.ChildNodes.ElementAt(0).ToString());
                        if (root.ChildNodes.ElementAt(0).ToString() == "USER_TYPE")
                        {
                            if (root.ChildNodes.ElementAt(0).ChildNodes.Count == 2)
                            {
                                System.Diagnostics.Debug.WriteLine("Nombre Objeto" + root.ChildNodes.ElementAt(0).ChildNodes.ElementAt(0).ToString());
                                System.Diagnostics.Debug.WriteLine("Nombre Variable" + root.ChildNodes.ElementAt(0).ChildNodes.ElementAt(1).ToString());
                                NodoAbstracto nuevo = new DECOBJETO("INSTANCIA");
                                NodoAbstracto id = new Nodo(root.ChildNodes.ElementAt(0).ChildNodes.ElementAt(0).ToString().Replace(" (id)", ""));
                                NodoAbstracto id2 = new Nodo(root.ChildNodes.ElementAt(0).ChildNodes.ElementAt(1).ToString().Replace(" (id2)", ""));
                                nuevo.Hijos.Add(id);
                                nuevo.Hijos.Add(id2);
                                return nuevo;
                            }
                            else if (root.ChildNodes.ElementAt(0).ChildNodes.Count == 4)
                            {
                                NodoAbstracto nuevo = new INSTANCIA1OBJETO("INSTANCIA");
                                NodoAbstracto id = new Nodo(root.ChildNodes.ElementAt(0).ChildNodes.ElementAt(3).ToString().Replace(" (id)", ""));
                                NodoAbstracto id2 = new Nodo(root.ChildNodes.ElementAt(0).ChildNodes.ElementAt(0).ToString().Replace(" (id2)", ""));
                                nuevo.Hijos.Add(id);
                                nuevo.Hijos.Add(id2);
                                return nuevo;
                            }
                            else if (root.ChildNodes.ElementAt(0).ChildNodes.Count == 5)
                            {
                                NodoAbstracto nuevo = new DECLARACIONINSTANCIA("INSTANCIA");
                                NodoAbstracto id = new Nodo(root.ChildNodes.ElementAt(0).ChildNodes.ElementAt(0).ToString().Replace(" (id)", ""));
                                NodoAbstracto id2 = new Nodo(root.ChildNodes.ElementAt(0).ChildNodes.ElementAt(1).ToString().Replace(" (id2)", ""));
                                NodoAbstracto id3 = new Nodo(root.ChildNodes.ElementAt(0).ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));
                                nuevo.Hijos.Add(id);
                                nuevo.Hijos.Add(id2);
                                nuevo.Hijos.Add(id3);
                                return nuevo;
                            }
                        }
                    }

                    break;
                    
                case 3:                    
                    //Recorrido1(root.ChildNodes.ElementAt(0));
                    //Recorrido1(root.ChildNodes.ElementAt(1));
                    //Recorrido1(root.ChildNodes.ElementAt(2));
                    System.Diagnostics.Debug.WriteLine("CAso3 -> " + root.ToString());
                    if(root.ToString().Contains("INC_DEC")== true)
                    {
                        System.Diagnostics.Debug.WriteLine("INC_DEC");
                        NodoAbstracto nuevo = new Incremento("INCREMENTO");
                        Nodo nuevoid = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id2)", ""));
                        Nodo nuevoid2 = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (Key symbol)", ""));
                        nuevo.Hijos.Add(nuevoid);
                        nuevo.Hijos.Add(nuevoid2);
                        return nuevo;

                    }
                    else if (root.ToString() == "ASIGNACION")
                    {
                        if (root.ChildNodes.ElementAt(0).ToString().Contains("TIPOS_VARIABLES")
                        && root.ChildNodes.ElementAt(1).FindToken().ToString().Contains("id2") &&
                        root.ChildNodes.ElementAt(2).ToString().Contains("; (Key symbol)")
                        )
                        {
                            System.Diagnostics.Debug.WriteLine("CODIGO PARA DECALRAR UNA VARIABLE INT @VAR1;");
                            if (root.ChildNodes.ElementAt(1).ToString().Contains("LISTA_IDS2"))
                            {
                                //System.Diagnostics.Debug.WriteLine("PUTO");
                                
                                ListaID2(root.ChildNodes.ElementAt(1));
                                String tipo = root.ChildNodes.ElementAt(0).ChildNodes.ElementAt(0).ToString().Replace("(Keyword)", "");
                                NodoAbstracto nuevo = new DeclararLista("DECLARAR_Lista");
                                NodoAbstracto nuevotipo = new Nodo(root.ChildNodes.ElementAt(0).ChildNodes.ElementAt(0).ToString().Replace("(Keyword)", ""));
                                NodoAbstracto nuevoid = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id2)", ""));
                                nuevo.Hijos.Add(nuevotipo);
                                nuevo.Hijos.Add(nuevoid);
                                for(int i = 0; i < primes.Count; i++)
                                {
                                    nuevo.ListaID1.Add(primes[i]);
                                }
                                
                                primes.Clear();
                                return nuevo;


                            }
                            else
                            {
                                NodoAbstracto nuevo = new Declarar("DECLARAR");
                                NodoAbstracto nuevotipo = new Nodo(root.ChildNodes.ElementAt(0).ChildNodes.ElementAt(0).ToString().Replace("(Keyword)", ""));
                                NodoAbstracto nuevoid = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id2)", ""));
                                nuevo.Hijos.Add(nuevotipo);
                                nuevo.Hijos.Add(nuevoid);
                                return nuevo;
                            }
                           
                            
                         }
                    }
                    else if (root.ToString() == "E")
                    {
                        NodoAbstracto RESULT = null;
                        if ((root.ChildNodes.ElementAt(0).ToString().Contains(" (id2)"))&&
                            (root.ChildNodes.ElementAt(1).ToString().Contains("( (Key symbol)")) &&
                            (root.ChildNodes.ElementAt(2).ToString().Contains(") (Key symbol)"))
                            )
                        {
                            System.Diagnostics.Debug.WriteLine("FUNCIONES");
                            NodoAbstracto nuevo = new FUNCIONES_PROPIAS("EXP");
                            NodoAbstracto nuevohijo = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id2)", ""));
                            nuevo.Hijos.Add(nuevohijo);
                            nuevo.AutoIncrmentable2 = 101;
                            return nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(0).ToString().Contains(" (Keyword)")) &&
                            (root.ChildNodes.ElementAt(1).ToString().Contains("( (Key symbol)")) &&
                            (root.ChildNodes.ElementAt(2).ToString().Contains(") (Key symbol)"))
                            )
                        {
                            System.Diagnostics.Debug.WriteLine("FUNCIONES");
                            NodoAbstracto nuevo = new FUNCIONES_PROPIAS("EXP");
                            NodoAbstracto nuevohijo = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (Keyword)", ""));
                            nuevo.Hijos.Add(nuevohijo);
                            nuevo.AutoIncrmentable2 = 102;
                            return nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(0).ToString().Contains(" (id)")) &&
                            (root.ChildNodes.ElementAt(1).ToString().Contains("( (Key symbol)")) &&
                            (root.ChildNodes.ElementAt(2).ToString().Contains(") (Key symbol)"))
                            )
                        {
                            NodoAbstracto nuevo = new FUN_RETORNO("RETORNO");
                            NodoAbstracto Funcion = new  Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Funcion);
                            nuevo.AutoIncrmentable2 = 54;
                            return nuevo;


                        }


                        else if ((root.ChildNodes.ElementAt(2).ToString().Contains("+ (Key symbol")))
                        {
                            /* System.Diagnostics.Debug.WriteLine("entrooooooooooooooooo");
                             NodoAbstracto nuevo = new Aritmetica("EXP");
                             NodoAbstracto nuevooperador = new Nodo("+");
                             nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                             nuevo.Hijos.Add(nuevooperador);
                             nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                             nuevo.AutoIncrmentable = 1;
                             */
                            System.Diagnostics.Debug.WriteLine("INC_DEC");
                            NodoAbstracto nuevo2 = new Incremento("INCREMENTO");
                            Nodo nuevo2id = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id2)", ""));
                            Nodo nuevo2id2 = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (Key symbol)", ""));
                            nuevo2.Hijos.Add(nuevo2id);
                            nuevo2.Hijos.Add(nuevo2id2);
                            nuevo2.AutoIncrmentable = 1;
                            nuevo2.TipoDato = "decimal";

                            RESULT = nuevo2;

                        }
                        else if ((root.ChildNodes.ElementAt(2).ToString().Contains("- (Key symbol")))
                        {
                            //System.Diagnostics.Debug.WriteLine("entrooooooooooooooooo-");
                            System.Diagnostics.Debug.WriteLine("DECREMENTO");
                            NodoAbstracto nuevo2 = new Incremento("DECREMENTO");
                            Nodo nuevo2id = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id2)", ""));
                            Nodo nuevo2id2 = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (Key symbol)", ""));
                            nuevo2.Hijos.Add(nuevo2id);
                            nuevo2.Hijos.Add(nuevo2id2);
                            nuevo2.AutoMinision = 1;
                            nuevo2.TipoDato = "decimal";

                            RESULT = nuevo2;

                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("+ (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("+");
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            //Raiz = nuevo;

                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("- (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("-");
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            //Raiz = nuevo;

                        }
                        else if (repeticiones(root.ChildNodes.ElementAt(1).ToString()) == 1)
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("*");
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            //Raiz = nuevo;

                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("/ (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("/");
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            //Raiz = nuevo;
                        }

                        else if (repeticiones(root.ChildNodes.ElementAt(1).ToString()) == 2)
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("**");
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            //Raiz = nuevo;

                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("% (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("%");
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            //Raiz = nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("> (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo(">");
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            RESULT.TipoDato = "Booleano";
                            return RESULT;
                            //Raiz = nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains(">= (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo(">=");
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            RESULT.TipoDato = "Booleano";
                            return RESULT;
                            //Raiz = nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("< (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("<");
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            RESULT.TipoDato = "Booleano";
                            return RESULT;
                            //Raiz = nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("<= (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("<=");
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            RESULT.TipoDato = "Booleano";
                            return RESULT;
                            //Raiz = nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("== (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("==");
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            RESULT.TipoDato = "Booleano";
                            return RESULT;
                            //Raiz = nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("!= (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("!=");
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            RESULT.TipoDato = "Booleano";
                            return RESULT;
                            //Raiz = nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("|| (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("||");
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            RESULT.TipoDato = "Booleano";
                            return RESULT;
                            //Raiz = nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("&& (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("&&");
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            RESULT.TipoDato = "Booleano";
                            return RESULT;
                            //Raiz = nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("^ (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("^");
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            RESULT.TipoDato = "Booleano";
                            return RESULT;
                            //Raiz = nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("? (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("]");
                            NodoAbstracto tipoCasteo = new Nodo(root.ChildNodes.ElementAt(0).ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (Keyword)", ""));
                            //System.Diagnostics.Debug.WriteLine("EXPRESION DE 4);" + root.ChildNodes.ElementAt(1).FindToken().ToString());
                            nuevo.Hijos.Add(tipoCasteo);
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                            nuevo.TipoDato = "CAST";
                            return nuevo;
                            //Raiz = nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("E")))
                        {


                            return Recorrido1(root.ChildNodes.ElementAt(1));
                            //Raiz = nuevo;
                        }

                        if (Recorrido1(root.ChildNodes.ElementAt(0)).TipoDato == "decimal"
                            && Recorrido1(root.ChildNodes.ElementAt(2)).TipoDato == "decimal")
                        {
                            RESULT.TipoDato = "decimal";
                        }
                        else if(Recorrido1(root.ChildNodes.ElementAt(0)).TipoDato == "id2")
                        {
                            RESULT.TipoDato = Recorrido1(root.ChildNodes.ElementAt(2)).TipoDato;
                        }
                        else if (Recorrido1(root.ChildNodes.ElementAt(2)).TipoDato == "id2")
                        {
                            RESULT.TipoDato = Recorrido1(root.ChildNodes.ElementAt(0)).TipoDato;
                        }

                        else if (Recorrido1(root.ChildNodes.ElementAt(0)).TipoDato == "entero"
                            && Recorrido1(root.ChildNodes.ElementAt(2)).TipoDato == "entero")
                        {
                            RESULT.TipoDato = "entero";
                        }
                        else if (Recorrido1(root.ChildNodes.ElementAt(0)).TipoDato == "entero"
                           && Recorrido1(root.ChildNodes.ElementAt(2)).TipoDato == "decimal")
                        {
                            RESULT.TipoDato = "decimal";
                        }
                        else if (Recorrido1(root.ChildNodes.ElementAt(0)).TipoDato == "decimal"
                           && Recorrido1(root.ChildNodes.ElementAt(2)).TipoDato == "entero")
                        {
                            RESULT.TipoDato = "decimal";
                        }
                        else if (Recorrido1(root.ChildNodes.ElementAt(0)).TipoDato == "cadena"
                          && Recorrido1(root.ChildNodes.ElementAt(2)).TipoDato == "cadena")
                        {
                            RESULT.TipoDato = "cadena";
                        }
                        else if (Recorrido1(root.ChildNodes.ElementAt(0)).TipoDato == "entero"
                          && Recorrido1(root.ChildNodes.ElementAt(2)).TipoDato == "cadena")
                        {
                            RESULT.TipoDato = "cadena";
                        }
                        else if (Recorrido1(root.ChildNodes.ElementAt(0)).TipoDato == "cadena"
                         && Recorrido1(root.ChildNodes.ElementAt(2)).TipoDato == "entero")
                        {
                            RESULT.TipoDato = "cadena";
                        }
                        else if (Recorrido1(root.ChildNodes.ElementAt(0)).TipoDato == "cadena"
                         && Recorrido1(root.ChildNodes.ElementAt(2)).TipoDato == "decimal")
                        {
                            RESULT.TipoDato = "cadena";
                        }
                        else if (Recorrido1(root.ChildNodes.ElementAt(0)).TipoDato == "decimal"
                         && Recorrido1(root.ChildNodes.ElementAt(2)).TipoDato == "cadena")
                        {
                            RESULT.TipoDato = "cadena";
                        }
                        else if (Recorrido1(root.ChildNodes.ElementAt(0)).TipoDato == "cadena"
                         && Recorrido1(root.ChildNodes.ElementAt(2)).TipoDato == "Booleano")
                        {
                            RESULT.TipoDato = "cadena";
                        }
                        else if (Recorrido1(root.ChildNodes.ElementAt(0)).TipoDato == "Booleano"
                        && Recorrido1(root.ChildNodes.ElementAt(2)).TipoDato == "cadena")
                        {
                            RESULT.TipoDato = "cadena";
                        }
                        else if (Recorrido1(root.ChildNodes.ElementAt(0)).TipoDato == "Fechas"
                        && Recorrido1(root.ChildNodes.ElementAt(2)).TipoDato == "Fechas")
                        {
                            RESULT.TipoDato = "Fechas";
                        }
                        else if (Recorrido1(root.ChildNodes.ElementAt(0)).TipoDato == "hora"
                        && Recorrido1(root.ChildNodes.ElementAt(2)).TipoDato == "hora")
                        {
                            RESULT.TipoDato = "hora";
                        }
                        else if (Recorrido1(root.ChildNodes.ElementAt(0)).TipoDato == "Booleano"
                        && Recorrido1(root.ChildNodes.ElementAt(2)).TipoDato == "Booleano")
                        {
                            RESULT.TipoDato = "Booleano";
                        }
                        else
                        {
                            RESULT.TipoDato = "cadena";
                        }

                        return RESULT;
                    }
                    else if (root.ToString().ToUpper().Contains("LALISTA"))
                    {
                        NodoAbstracto nuevo = new LISTAS("LISTAPAR");
                        NodoAbstracto id = new Nodo(root.ChildNodes.ElementAt(1).ToString().Replace(" (id2)", ""));
                        nuevo.Hijos.Add(id);
                        nuevo.AutoIncrmentable2 = 22;
                        if (root.ChildNodes.ElementAt(0).FindToken().ToString().ToUpper().Contains("SET"))
                        {
                            nuevo.TipoDato = "SET";
                        }
                        return nuevo;
                    }else if (root.ToString().ToUpper().Contains("ELRETORNO"))
                    {
                        NodoAbstracto nuevo = new RETORNO("RETORNO");
                        ///NodoAbstracto id = new Nodo(root.ChildNodes.ElementAt(1).ToString().Replace(" (id2)", ""));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(1)));
                        return nuevo;
                    }
                  
                    break;

                case 4:
                    
                   // Recorrido1(root.ChildNodes.ElementAt(0));
                   // Recorrido1(root.ChildNodes.ElementAt(1));
                   // Recorrido1(root.ChildNodes.ElementAt(2));
                   // Recorrido1(root.ChildNodes.ElementAt(3));
                    System.Diagnostics.Debug.WriteLine("CAso4 -> " + root.ToString());
                    if (root.ToString() == "DDL") {
                        if (root.ChildNodes.ElementAt(0).FindToken().ToString().ToUpper().Contains("TRUNCATE"))
                        {
                            System.Diagnostics.Debug.WriteLine("CODIGO PARA TRUNCATE");

                        }
                        else if (root.ChildNodes.ElementAt(0).FindToken().ToString().ToUpper().Contains("DROP")
                        && root.ChildNodes.ElementAt(1).FindToken().ToString().Contains("table"))
                        {
                            System.Diagnostics.Debug.WriteLine("CODIGO PARA DROP TABLE");


                        }
                        else if (root.ChildNodes.ElementAt(0).FindToken().ToString().ToUpper().Contains("DROP")
                            && root.ChildNodes.ElementAt(1).FindToken().ToString().Contains("database"))
                        {
                            System.Diagnostics.Debug.WriteLine("CODIGO PARA DROP BD");

                        }
                    }
                    else if (root.ToString() == "ASIGNACION")
                    {
                        if (root.ChildNodes.ElementAt(2).ToString().Contains("E")
                        && root.ChildNodes.ElementAt(0).FindToken().ToString().Contains("id2") &&
                        root.ChildNodes.ElementAt(1).ToString().Contains("Key symbol")
                       )
                        {
                            System.Diagnostics.Debug.WriteLine("CODIGO PARA DECALRAR UNA VARIABLE @hola = 0;");
                            NodoAbstracto nuevo = new Asignar("ASIGNAR");
                            NodoAbstracto nuevoid = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id2)",""));
                            nuevo.Hijos.Add(nuevoid);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                            return  nuevo;



                        }
                    }
                    else if (root.ToString() == "DELETE_TYPE")
                    {
                        if (root.ChildNodes.ElementAt(0).FindToken().ToString().Contains("delete")
                        && root.ChildNodes.ElementAt(1).FindToken().ToString().Contains("type"))
                        {
                            System.Diagnostics.Debug.WriteLine("CODIGO PARA BORRAR UN TYPE");


                        }
                        
                    }
                    else if (root.ToString() == "USER_TYPE")
                    {
                        if (root.ChildNodes.ElementAt(0).FindToken().ToString().Contains("id2")
                         && root.ChildNodes.ElementAt(1).FindToken().ToString().Contains("Key symbol") &&
                          root.ChildNodes.ElementAt(2).FindToken().ToString().Contains("new") &&
                         root.ChildNodes.ElementAt(3).FindToken().ToString().Contains("id")
                        )
                        {
                            System.Diagnostics.Debug.WriteLine("CODIGO PARA INSTANCIAR UN OJBETO @est2 = new Estudiante;");


                        }
                    }
                    else if (root.ToString() == "E")
                    {
                        if ((root.ChildNodes.ElementAt(0).ToString().Contains(" (id2)")) &&
                          (root.ChildNodes.ElementAt(1).ToString().Contains("( (Key symbol)")) &&
                          (root.ChildNodes.ElementAt(3).ToString().Contains(") (Key symbol)"))
                          )
                        {
                            System.Diagnostics.Debug.WriteLine("FUNCIONES");
                            NodoAbstracto nuevo = new FUNCIONES_PROPIAS("EXP");
                            NodoAbstracto nuevohijo = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id2)", ""));
                            nuevo.Hijos.Add(nuevohijo);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                            nuevo.AutoIncrmentable2 = 103;
                            return nuevo;
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("EXPRESION DE 4);");
                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo(")");
                            NodoAbstracto tipoCasteo = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (Keyword)", ""));
                            //System.Diagnostics.Debug.WriteLine("EXPRESION DE 4);" + root.ChildNodes.ElementAt(1).FindToken().ToString());
                            nuevo.Hijos.Add(tipoCasteo);
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(3)));
                            nuevo.TipoDato = "CAST";
                            return nuevo;
                        }
                    }
                    else if (root.ToString().ToUpper().Contains("FUNCIONES_PROPIAS"))
                    {
                        NodoAbstracto nuevo = new FUNCIONESCOLEECTIONS("FUNCIONES");

                        NodoAbstracto tipoCasteo = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id2)", ""));
                        NodoAbstracto nuevoid = new Nodo(root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (id)", ""));
                        //System.Diagnostics.Debug.WriteLine("EXPRESION DE 4);" + root.ChildNodes.ElementAt(1).FindToken().ToString());
                        nuevo.Hijos.Add(tipoCasteo);
                        nuevo.AutoIncrmentable2 = 90;
                        return nuevo;
                    }
                   
                    break;
                case 5:
                    
                 //   Recorrido1(root.ChildNodes.ElementAt(0));
                 //   Recorrido1(root.ChildNodes.ElementAt(1));
                 //   Recorrido1(root.ChildNodes.ElementAt(2));
                 //   Recorrido1(root.ChildNodes.ElementAt(3));
                 //   Recorrido1(root.ChildNodes.ElementAt(4));
                    System.Diagnostics.Debug.WriteLine("CAso5 -> " + root.ToString());
                    if (root.ChildNodes.ElementAt(0).ToString().Contains("TIPOS_VARIABLES") &&
                       root.ChildNodes.ElementAt(1).FindToken().ToString().Contains("id2") &&
                       root.ChildNodes.ElementAt(2).FindToken().ToString().Contains("Key symbol") &&
                       root.ChildNodes.ElementAt(4).ToString().ToUpper().Contains("E")
                   )
                    {
                        System.Diagnostics.Debug.WriteLine("Codigo para Asignacion de una variable tipo @var1 = Exprsion");

                        if (root.ChildNodes.ElementAt(1).ToString().Contains("LISTA_IDS2"))
                        {
                            ListaID2(root.ChildNodes.ElementAt(1));
                            String tipo = root.ChildNodes.ElementAt(0).ChildNodes.ElementAt(0).ToString().Replace("(Keyword)", "");
                            NodoAbstracto nuevo = new DeclararAsignacionLista("DECLARAR_Lista");
                            NodoAbstracto nuevotipo = new Nodo(root.ChildNodes.ElementAt(0).ChildNodes.ElementAt(0).ToString().Replace("(Keyword)", ""));
                            NodoAbstracto nuevoid = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id2)", ""));
                            nuevo.Hijos.Add(nuevotipo);
                            nuevo.Hijos.Add(nuevoid);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(3)));
                            for (int i = 0; i < primes.Count; i++)
                            {
                                nuevo.ListaID1.Add(primes[i]);
                            }

                            primes.Clear();
                            return nuevo;
                        }
                        else
                        {
                            NodoAbstracto nuevo = new DeclararAsignacion("DECLARARASIGNAR");
                            NodoAbstracto nuevotipo = new Nodo(root.ChildNodes.ElementAt(0).ChildNodes.ElementAt(0).ToString().Replace("(Keyword)", ""));
                            NodoAbstracto nuevoid = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id2)", ""));
                            nuevo.Hijos.Add(nuevotipo);
                            nuevo.Hijos.Add(nuevoid);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(3)));
                            return nuevo;
                        }

                    }
                    else if (root.ChildNodes.ElementAt(0).ToString().Contains("LOG") ||
                        root.ChildNodes.ElementAt(0).ToString().Contains("log") ||
                        root.ChildNodes.ElementAt(0).ToString().Contains("Log") ||
                        root.ChildNodes.ElementAt(0).ToString().Contains("lOg") ||
                        root.ChildNodes.ElementAt(0).ToString().Contains("loG")
                        )
                    {
                        NodoAbstracto nuevo2 = new LOG("IMPRIMIR");
                        nuevo2.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                        return nuevo2;
                    }
                    else if (root.ToString().ToUpper().Contains("ASIGNACION_OPERACION"))
                    {
                        System.Diagnostics.Debug.WriteLine("asdjflasjdlfkjsald");
                        NodoAbstracto nuevo = new ASIGNACION_OPERACION("ASIGOP");
                        NodoAbstracto nuevoid = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id2)", ""));
                        NodoAbstracto nuevoid2 = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (Key symbol)", ""));
                        nuevo.Hijos.Add(nuevoid);
                        nuevo.Hijos.Add(nuevoid2);
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(3)));
                        return nuevo;
                    }
                    else if (root.ToString().ToUpper().Contains("USER_TYPE2"))
                    {
                        NodoAbstracto nuevo = new ASIGNACIONOBJETOS("INSTANCIA");
                        NodoAbstracto id = new Nodo(root.ChildNodes.ElementAt(0).ToString().Replace(" (id2)", ""));
                        NodoAbstracto id2 = new Nodo(root.ChildNodes.ElementAt(0).ToString().Replace(" (id2)", ""));
                        nuevo.Hijos.Add(id);
                        nuevo.Hijos.Add(id2);
                        nuevo.AutoIncrmentable2 = 9;
                        STN.Add("CADENA");
                        System.Diagnostics.Debug.WriteLine("sdaf");
                        Atributos(root.ChildNodes.ElementAt(3));
                        System.Diagnostics.Debug.WriteLine("sdaf");
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaID1.Add(STN[i]);
                        }
                        STN.Clear();

                        return nuevo;
                    }
                    else if (root.ToString().ToUpper().Contains("FUNCIONES_PROPIAS"))
                    {
                        NodoAbstracto nuevo = new FUNCIONESCOLEECTIONS("FUNCIONES");
                        NodoAbstracto nuevooperador = new Nodo(".");
                        NodoAbstracto tipoCasteo = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id2)", ""));
                        NodoAbstracto nuevoid = new Nodo(root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (id)", ""));

                        //System.Diagnostics.Debug.WriteLine("EXPRESION DE 4);" + root.ChildNodes.ElementAt(1).FindToken().ToString());
                        nuevo.Hijos.Add(tipoCasteo);
                        nuevo.Hijos.Add(nuevooperador);
                        nuevo.Hijos.Add(nuevoid);
                        nuevo.TipoDato = "funk";
                        return nuevo;
                    }
                        break;
                case 6:
                   
                 //   Recorrido1(root.ChildNodes.ElementAt(0));
                 //   Recorrido1(root.ChildNodes.ElementAt(1));
                 //   Recorrido1(root.ChildNodes.ElementAt(2));
                 //   Recorrido1(root.ChildNodes.ElementAt(3));
                 //   Recorrido1(root.ChildNodes.ElementAt(4));
                 //   Recorrido1(root.ChildNodes.ElementAt(5));
                    System.Diagnostics.Debug.WriteLine("CAso6 -> " + root.ToString());
                    if (root.ToString() == "E")
                    {
                        if ((root.ChildNodes.ElementAt(0).ToString().Contains(" (id2)")) &&
                          (root.ChildNodes.ElementAt(1).ToString().Contains("( (Key symbol)")) &&
                          (root.ChildNodes.ElementAt(5).ToString().Contains(") (Key symbol)"))
                          )
                        {
                            System.Diagnostics.Debug.WriteLine("FUNCIONES");
                            NodoAbstracto nuevo = new FUNCIONES_PROPIAS("EXP");
                            NodoAbstracto nuevohijo = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id2)", ""));
                            nuevo.Hijos.Add(nuevohijo);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(4)));
                            nuevo.AutoIncrmentable2 = 104;
                            return nuevo;
                        }
                    }
                   
                    if (root.ChildNodes.ElementAt(3).FindToken().ToString().ToUpper().Contains("DROP") && root.ChildNodes.ElementAt(0).FindToken().ToString().ToUpper().Contains("ALTER"))
                    {
                            System.Diagnostics.Debug.WriteLine("CODIGO PARA ALTER TABLE DROP");
                        
                    }
                    else if (root.ChildNodes.ElementAt(3).FindToken().ToString().ToUpper().Contains("ADD") && root.ChildNodes.ElementAt(0).FindToken().ToString().ToUpper().Contains("ALTER"))
                    {
                            System.Diagnostics.Debug.WriteLine("CODIGO PARA ALTER TABLE ADD");
                       
                    }
                    
                    break;
                case 7:
                    
                  //  Recorrido1(root.ChildNodes.ElementAt(0));
                  //  Recorrido1(root.ChildNodes.ElementAt(1));
                  //  Recorrido1(root.ChildNodes.ElementAt(2));
                  //  Recorrido1(root.ChildNodes.ElementAt(3));
                  //  Recorrido1(root.ChildNodes.ElementAt(4));
                  //  Recorrido1(root.ChildNodes.ElementAt(5));
                  //  Recorrido1(root.ChildNodes.ElementAt(6));
                    System.Diagnostics.Debug.WriteLine("CAso7 -> " + root.ToString());
                    if (root.ToString().Contains("ELWHILE"))
                    {
                        NodoAbstracto nuevo = new While("WHILE");
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(5)));
                        return nuevo;
                    }
                    else if (root.ToString() == "FUNCIONES_CREADAS")
                    {

                        System.Diagnostics.Debug.WriteLine("FUNCIONES_cREADAS");
                        NodoAbstracto nuevo = new FUNCIONES("FUN_CREADAS");
                        NodoAbstracto tipofuncion = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (Keyword)", ""));
                        NodoAbstracto NombreFuncion = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", ""));
                        nuevo.Hijos.Add(tipofuncion);
                        nuevo.Hijos.Add(NombreFuncion);
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(5)));
                        nuevo.AutoIncrmentable2 = 67;
                        return nuevo;

                    }
                    else if (root.ToString().Contains("EL_IF"))
                    {
                        NodoAbstracto nuevo = new ELIF("IF");
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(5)));
                        return nuevo;
                    }


                    else if (root.ChildNodes.ElementAt(0).FindToken().ToString().ToUpper().Contains("CREATE") && root.ChildNodes.ElementAt(1).FindToken().ToString().ToUpper().Contains("TABLE"))
                    {
                        System.Diagnostics.Debug.WriteLine("CODIGO PARA CREAR UNA TABLA");
                    }else if (root.ChildNodes.ElementAt(0).ToString().Contains("TIPOS_VARIABLES") &&
                        root.ChildNodes.ElementAt(1).FindToken().ToString().Contains("id2")&&
                        root.ChildNodes.ElementAt(2).FindToken().ToString().Contains("Key symbol") &&
                        root.ChildNodes.ElementAt(3).FindToken().ToString().Contains("id2")&&
                        root.ChildNodes.ElementAt(4).FindToken().ToString().Contains("Key symbol") &&
                        root.ChildNodes.ElementAt(5).FindToken().ToString().Contains("id")

                    )
                    {
                        System.Diagnostics.Debug.WriteLine("Codigo para asignarle a una variable un ojbeto: tipo @id = @id.id;");
                    }
                    else if (root.ChildNodes.ElementAt(0).FindToken().ToString().Contains("create") &&
                       root.ChildNodes.ElementAt(1).FindToken().ToString().Contains("type") &&
                       root.ChildNodes.ElementAt(2).FindToken().ToString().Contains("id") &&
                       root.ChildNodes.ElementAt(3).FindToken().ToString().Contains("Key symbol") &&
                       root.ChildNodes.ElementAt(4).ToString().Contains("LISTA_IDS") &&
                       root.ChildNodes.ElementAt(5).FindToken().ToString().Contains("Key symbol") &&
                       root.ChildNodes.ElementAt(6).FindToken().ToString().Contains("Key symbol")

                   )
                    {
                        
                        ListaIDSObjeto(root.ChildNodes.ElementAt(4));
                        System.Diagnostics.Debug.WriteLine("Codigo para LA CREACION DE OBJETOSXS;");
                        NodoAbstracto nuevo = new USER_TYPE("USER_TYPE");
                        NodoAbstracto nuevoid = new Nodo(root.ChildNodes.ElementAt(2).FindToken().ToString());
                        nuevo.Hijos.Add(nuevoid);
                        for(int i = 0; i<STN.Count; i++)
                        {
                            nuevo.ListaID1.Add(STN[i]);
                        }
                        

                        //ListaIDSObjeto(root.ChildNodes.ElementAt(4));
                        STN.Clear();
                        return nuevo;
                    }
                    else if (root.ToString().ToUpper().Contains("USER_TYPE2"))
                    {
                        NodoAbstracto nuevo = new ASIGNACIONOBJETOS("INSTANCIA");
                        NodoAbstracto id = new Nodo(root.ChildNodes.ElementAt(0).ToString().Replace(" (id2)", ""));
                        NodoAbstracto id2 = new Nodo(root.ChildNodes.ElementAt(0).ToString().Replace(" (id2)", ""));
                        NodoAbstracto id3 = new Nodo(root.ChildNodes.ElementAt(6).ToString().Replace(" (id)", ""));
                        nuevo.Hijos.Add(id);
                        nuevo.Hijos.Add(id2);

                        nuevo.Hijos.Add(id3);
                        nuevo.AutoIncrmentable2 = 9;
                        STN.Add("CADENA");
                        System.Diagnostics.Debug.WriteLine("sdaf");
                        Atributos(root.ChildNodes.ElementAt(3));
                        System.Diagnostics.Debug.WriteLine("sdaf");
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaID1.Add(STN[i]);
                        }
                        STN.Clear();

                        return nuevo;
                    }
                    else if (root.ToString().ToUpper().Contains("LALISTA"))
                    {
                        NodoAbstracto nuevo = new LISTAS("LISTAPAR");
                        NodoAbstracto id = new Nodo(root.ChildNodes.ElementAt(0).ToString().Replace(" (id2)", ""));
                        nuevo.Hijos.Add(id);
                        nuevo.AutoIncrmentable2 = 33;
                        System.Diagnostics.Debug.WriteLine("sdaf");
                        Atributos(root.ChildNodes.ElementAt(4));
                        System.Diagnostics.Debug.WriteLine("sdaf");
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaID1.Add(STN[i]);
                        }
                        STN.Clear();
                        if (root.ChildNodes.ElementAt(0).FindToken().ToString().ToUpper().Contains("SET"))
                        {
                            nuevo.TipoDato = "SET";
                        }
                        return nuevo;
                    }
                    else if (root.ToString().ToUpper().Contains("FUNCIONES_PROPIAS"))
                    {
                        NodoAbstracto nuevo = new FUNCIONESCOLEECTIONS("FUNCIONES");
                        NodoAbstracto tipoCasteo = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id2)", ""));
                        NodoAbstracto nuevoid = new Nodo(root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (id)", ""));
                        NodoAbstracto nuevoid2 = new Nodo(root.ChildNodes.ElementAt(4).FindToken().ToString().Replace(" (id)", ""));
                        nuevo.Hijos.Add(tipoCasteo);
                        nuevo.Hijos.Add(nuevoid);
                        nuevo.Hijos.Add(nuevoid2);
                        nuevo.AutoIncrmentable2 = 9099;
                        nuevo.TipoDato = "funk";
                        return nuevo;
                    }

                    break;
                case 8:

                 //   Recorrido1(root.ChildNodes.ElementAt(0));
                 //   Recorrido1(root.ChildNodes.ElementAt(1));
                  //  Recorrido1(root.ChildNodes.ElementAt(2));
                  //  Recorrido1(root.ChildNodes.ElementAt(3));
                  //  Recorrido1(root.ChildNodes.ElementAt(4));
                  //  Recorrido1(root.ChildNodes.ElementAt(5));
                  //  Recorrido1(root.ChildNodes.ElementAt(6));
                  //  Recorrido1(root.ChildNodes.ElementAt(7));
                    System.Diagnostics.Debug.WriteLine("CAso8 -> " + root.ToString());

                    if (root.ToString().Contains("EL_IF"))
                    {
                        NodoAbstracto nuevo = new ELSEIF("IF");
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(5)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(7)));
                        return nuevo;
                    }
                    else if (root.ToString() == "FUNCIONES_CREADAS")
                    {

                        System.Diagnostics.Debug.WriteLine("FUNCIONES_cREADAS");
                        NodoAbstracto nuevo = new FUNCIONES("FUN_CREADAS");
                        NodoAbstracto tipofuncion = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (Keyword)", ""));
                        NodoAbstracto NombreFuncion = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", ""));
                       // NodoAbstracto ListaDeSentenias = new Nodo(root.ChildNodes.ElementAt(6));
                        nuevo.Hijos.Add(tipofuncion);
                        nuevo.Hijos.Add(NombreFuncion);
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(6)));
                        AtributosFunciones(root.ChildNodes.ElementAt(3));
                        for(int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaID1.Add(STN[i]);
                        }
                        STN.Clear();
                        nuevo.AutoIncrmentable2 = 68;
                        return nuevo;

                    }
                    else if (root.ToString().Contains("SINO"))
                    {
                        NodoAbstracto nuevo = new Nodo("SINO");
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(3)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(6)));
                        return nuevo;
                    }
                    else if (root.ChildNodes.ElementAt(0).ToString().Contains("TIPOS_VARIABLES")
                        && root.ChildNodes.ElementAt(1).FindToken().ToString().Contains("(id2)")
                        && root.ChildNodes.ElementAt(2).FindToken().ToString().Contains("=")
                        && root.ChildNodes.ElementAt(3).FindToken().ToString().Contains("(")
                        && root.ChildNodes.ElementAt(4).ToString().Contains("TIPOS_VARIABLES")
                        && root.ChildNodes.ElementAt(5).FindToken().ToString().Contains(")")
                         && root.ChildNodes.ElementAt(6).ToString().Contains("E")
                    )
                    {
                        System.Diagnostics.Debug.WriteLine("CODIGO CASTEO OBLIGATORIO");
                    } 

                    else if (root.ChildNodes.ElementAt(0).ToString().Contains("alter") &&
                            root.ChildNodes.ElementAt(1).ToString().Contains("type")&&
                            root.ChildNodes.ElementAt(2).ToString().Contains("(id)") &&
                            root.ChildNodes.ElementAt(3).ToString().Contains("delete")

                    ){
                        System.Diagnostics.Debug.WriteLine("CODIGO ALTER TYPE DELETE");
                    }
                    else if (root.ChildNodes.ElementAt(0).ToString().Contains("alter") &&
                            root.ChildNodes.ElementAt(1).ToString().Contains("type") &&
                            root.ChildNodes.ElementAt(2).ToString().Contains("(id)") &&
                            root.ChildNodes.ElementAt(3).ToString().Contains("add")

                    )
                    {
                        System.Diagnostics.Debug.WriteLine("CODIGO ALTER TYPE ADD");
                    }
                    else if (root.ChildNodes.ElementAt(0).FindToken().ToString().Contains("id") &&
                              root.ChildNodes.ElementAt(1).FindToken().ToString().Contains("id2") &&
                              root.ChildNodes.ElementAt(2).FindToken().ToString().Contains("Key symbol") &&
                              root.ChildNodes.ElementAt(3).FindToken().ToString().Contains("Key symbol") &&
                              root.ChildNodes.ElementAt(4).ToString().Contains("LISTA_EXPRESION") &&
                              root.ChildNodes.ElementAt(5).FindToken().ToString().Contains("Key symbol")
                    )
                    {
                        System.Diagnostics.Debug.WriteLine("CODIGO ASIGNAR VALORES A UN OBJETO Estudiante @est3 = {201504481, \"Julio Arango\",@est2};");
                        NodoAbstracto nuevo = new ASIGNACIONOBJETOS("INSTANCIA");
                        NodoAbstracto id = new Nodo(root.ChildNodes.ElementAt(0).ToString().Replace(" (id)", ""));
                        NodoAbstracto id2 = new Nodo(root.ChildNodes.ElementAt(1).ToString().Replace(" (id2)", ""));
                        NodoAbstracto id3 = new Nodo(root.ChildNodes.ElementAt(7).ToString().Replace(" (id)", ""));
                        nuevo.Hijos.Add(id);
                        nuevo.Hijos.Add(id2);
                        nuevo.Hijos.Add(id3);
                        STN.Add("CADENA");
                        System.Diagnostics.Debug.WriteLine("sdaf");
                        Atributos(root.ChildNodes.ElementAt(4));
                        System.Diagnostics.Debug.WriteLine("sdaf");
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaID1.Add(STN[i]);
                        }
                        STN.Clear();

                        return nuevo;
                    }
                    else if (root.ToString().ToUpper().Contains("LALISTA") && root.ChildNodes.ElementAt(0).ToString().Contains("(Keyword")==true)
                    {
                        NodoAbstracto nuevo = new LISTAS("LISTAPAR");
                        NodoAbstracto id = new Nodo(root.ChildNodes.ElementAt(1).ToString().Replace(" (id2)", ""));
                        nuevo.Hijos.Add(id);
                        nuevo.AutoIncrmentable2 = 99;                        
                        System.Diagnostics.Debug.WriteLine("sdaf");
                        Atributos(root.ChildNodes.ElementAt(5));
                        System.Diagnostics.Debug.WriteLine("sdaf");
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaID1.Add(STN[i]);
                        }
                        STN.Clear();
                        if (root.ChildNodes.ElementAt(0).FindToken().ToString().ToUpper().Contains("SET"))
                        {
                            nuevo.TipoDato = "SET";
                        }
                        return nuevo;
                    }
                    else if (root.ToString().ToUpper().Contains("LALISTA") && root.ChildNodes.ElementAt(0).ToString().Contains("(id2)") == true)
                    {
                        NodoAbstracto nuevo = new LISTAS("LISTA");
                        NodoAbstracto NombreLista = new Nodo(root.ChildNodes.ElementAt(0).ToString());
                        NodoAbstracto TipoLista = new Nodo(root.ChildNodes.ElementAt(5).FindToken().ToString());
                        nuevo.Hijos.Add(NombreLista);
                        nuevo.Hijos.Add(TipoLista);
                        nuevo.AutoIncrmentable2 = 101;

                        return nuevo;
                    }
                    break;
                case 9:
                    System.Diagnostics.Debug.WriteLine("CAso9 -> " + root.ToString());
                    if (root.ToString().Contains("DO_WHILE"))
                    {
                        NodoAbstracto nuevo = new DOWHILE("DOWHILE");
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(6)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));                        
                        return nuevo;
                    }
                    else if (root.ToString().Contains("SINO"))
                    {
                        NodoAbstracto nuevo = new Nodo("SINO");
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(3)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(6)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(8)));
                        nuevo.AutoIncrmentable2 = 9090;
                        return nuevo;
                    }
                    else if (root.ToString().Contains("LALISTA"))
                    {
                        NodoAbstracto nuevo = new LISTAS("LISTA");
                        NodoAbstracto NombreLista = new Nodo(root.ChildNodes.ElementAt(1).ToString());
                        NodoAbstracto TipoLista = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString());
                        nuevo.Hijos.Add(NombreLista);
                        nuevo.Hijos.Add(TipoLista);
                        nuevo.AutoIncrmentable2 = 88;
                        if (root.ChildNodes.ElementAt(0).FindToken().ToString().ToUpper().Contains("SET"))
                        {
                            nuevo.TipoDato = "SET";
                        }
                        return nuevo;
                           
                    }

                    break;
                case 10:
                    if (root.ToString().Contains("EL_FOR"))
                    {
                        NodoAbstracto nuevo = new ELFOR("FOR");
                      
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(3)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(5)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(8)));
                        return nuevo;
                    }
                    break;
                case 11:
                    if (root.ToString().Contains("EL_IF"))
                    {
                        NodoAbstracto nuevo = new ELSEIF("ELSEIF");
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(5)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(9)));
                        return nuevo;
                    }
                    break;
                case 12:
                    /*   Recorrido1(root.ChildNodes.ElementAt(0));
                       Recorrido1(root.ChildNodes.ElementAt(1));
                       Recorrido1(root.ChildNodes.ElementAt(2));
                       Recorrido1(root.ChildNodes.ElementAt(3));
                       Recorrido1(root.ChildNodes.ElementAt(4));
                       Recorrido1(root.ChildNodes.ElementAt(5));
                       Recorrido1(root.ChildNodes.ElementAt(6));
                       Recorrido1(root.ChildNodes.ElementAt(7));
                       Recorrido1(root.ChildNodes.ElementAt(8));
                       Recorrido1(root.ChildNodes.ElementAt(9)); */
                    if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("TRY") &&
                           root.ChildNodes.ElementAt(4).ToString().ToUpper().Contains("CATCH"))
                    {
                        System.Diagnostics.Debug.WriteLine("CODIGO TRY_CATCH");


                        NodoAbstracto nuevo = new TRY_CATCH("TRY_CATCH");
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(10)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(6)));
                        return nuevo;


                        // nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(8).ChildNodes.ElementAt(0)));
                        // nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(8).ChildNodes.ElementAt(1)));
                        // return nuevo;

                        //return nuevo;

                    }
                    else if (root.ToString().Contains("SINO"))
                    {
                        NodoAbstracto nuevo = new ELSEIF("SINO");
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(3)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(6)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(10)));
                        nuevo.AutoIncrmentable2 = 666;
                        return nuevo;
                    }
                


                    else if (root.ToString().Contains("CREATE_TYPE")) {
                        ListaIDSObjeto(root.ChildNodes.ElementAt(9));
                        System.Diagnostics.Debug.WriteLine("Codigo para LA CREACION DE OBJETOSXS;");
                        NodoAbstracto nuevo = new USER_TYPE("USER_TYPE");
                        NodoAbstracto nuevoid = new Nodo(root.ChildNodes.ElementAt(7).FindToken().ToString());
                        nuevo.Hijos.Add(nuevoid);
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaID1.Add(STN[i]);
                        }
                        nuevo.AutoIncrmentable2 = 5;

                        //ListaIDSObjeto(root.ChildNodes.ElementAt(4));
                        STN.Clear();
                        return nuevo;
                    }
                    break;
                default:
                break;
                 
            }

            return null;
        }

        

        public void Ejecutar(NodoAbstracto raiz)
        {
            System.Diagnostics.Debug.WriteLine("ejecutar");
            Entorno entorno = new Entorno();
            Boolean elbreak = false;
            foreach (NodoAbstracto sentencia in raiz.Hijos[0].Hijos)
            {// para ejecutar solo sentencias 
             //Console.WriteLine("pureba for " + sentencia.Nombre + raiz.TipoDato);
             //System.Diagnostics.Debug.WriteLine("CA:"+sentencia.Hijos[0].Ejecutar(entorno).ToString());
                String valor1 = sentencia.Ejecutar(entorno);
                if (valor1.ToUpper().Contains("#ERROR") == true || valor1.Contains("BREAK") == true  
                    )
                {
                    System.Diagnostics.Debug.WriteLine("ERROR SEMANTICO");
                    elbreak = true;
                    break;
                    //return "#Error";
                }
                if (valor1.Contains("RETORNO:") == true)
                {
                    System.Diagnostics.Debug.WriteLine("ERROR SEMANTICO");
                    break;
                }
                if (elbreak)
                    break;


            }
        }


        public void Analizar(NodoAbstracto raiz)
        {
            try
            {
                Ejecutar(raiz);
            }
            catch (Exception e)
            {
               
            }
        }
        List<String> STN = new List<String>();
        public List<String> ListaIDSObjeto(ParseTreeNode root)
        {
            
            switch (root.ChildNodes.Count)
            {
                case 2:
                    System.Diagnostics.Debug.WriteLine("dos hijo");
                   // String valor1 = root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (Keyword)", "");
                   // String valor2 = root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", "");
                    STN.Add(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (Keyword)", "") + "," + root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", ""));
                    
                    break;
                case 4:
                    ListaIDSObjeto(root.ChildNodes.ElementAt(0));
                    System.Diagnostics.Debug.WriteLine("cuatro hijo");
                  //  String valor1 = root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (Keyword)","");
                  //  String valor2 = root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)","");
                    STN.Add(root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (Keyword)", "") + "," + root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                   
                    
                    break;
            }
                    return STN;
        }

        public void AtributosFunciones(ParseTreeNode root)
        {
            switch (root.ChildNodes.Count)
            {
                case 2:
                    String Tipo1 = root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (Keyword)", "");
                    String Valor1 = root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id2)", "");
                    String Parametro1 = Tipo1 + "*" + Valor1;
                    STN.Add(Parametro1);                    
                    System.Diagnostics.Debug.WriteLine("Dos hijos:" + Parametro1);
                    break;
                case 3:
                    String Hijo1 = root.ChildNodes.ElementAt(0).ToString();
                    String Valor31 = "";
                    String Tipo31 = "";
                    Boolean recorrido = false;
                    if (Hijo1.ToUpper().Contains("TIPOS_VARIABLES"))
                    {
                        
                        Tipo31 = root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (Keyword)", "");
                        Valor31 = root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id2)", "");
                        recorrido = true;
                        
                    }
                    else
                    {
                        Tipo31 = root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (Keyword)", "");
                        Valor31 = root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (id2)", "");
                    }
                    
                    String Parametro31 = Tipo31 + "*" + Valor31;
                    STN.Add(Parametro31);
                    System.Diagnostics.Debug.WriteLine("Tres Hijos:" + Parametro31);
                    if (recorrido == true)
                    {
                        AtributosFunciones(root.ChildNodes.ElementAt(2));
                    }
                    break;
                case 4:
                    String Hijo41 = root.ChildNodes.ElementAt(0).ToString();
                    String Valor41 = "";
                    String Tipo41 = "";
                    Boolean recorrido4 = false;
                    if (Hijo41.ToUpper().Contains("TIPOS_VARIABLES"))
                    {

                        Tipo41 = root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (Keyword)", "");
                        Valor41 = root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id2)", "");
                       

                    }
                    else
                    {
                        Tipo41 = root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (Keyword)", "");
                        Valor41 = root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (id2)", "");
                        recorrido4 = true;
                    }
                    String Parametro41 = Tipo41 + "*" + Valor41;
                    STN.Add(Parametro41);
                    System.Diagnostics.Debug.WriteLine("Cuatro Hijos:" + Parametro41);
                    if (recorrido4 == true)
                    {
                        AtributosFunciones(root.ChildNodes.ElementAt(3));
                    }
                    break;
            }
        }

        public void Atributos(ParseTreeNode root)
        {
            switch (root.ChildNodes.Count)
            {
                case 1:
                    String Var1 = root.ChildNodes.ElementAt(0).FindToken().ToString();
                    System.Diagnostics.Debug.WriteLine("un hijo" + Var1);
                    STN.Add(Var1);
                    //Atributos(root.ChildNodes.ElementAt(0));
                    break;
                case 3:
                    //                    Atributos(root.ChildNodes.ElementAt(0));                    
                    
                    String Var2 = root.ChildNodes.ElementAt(0).FindToken().ToString();
                    STN.Add(Var2);
                    System.Diagnostics.Debug.WriteLine("tres hijos" + Var2);
                    Atributos(root.ChildNodes.ElementAt(2));


                    break;
            }
        }
        public List<String> ListaID2(ParseTreeNode root)
        {
            List<String> Lista = new List<String>();
            Gramatica g = new Gramatica();
            switch (root.ChildNodes.Count)
            {
                case 1:
                    String Var1 = root.ChildNodes.ElementAt(0).ToString().Replace(" (id2)", "");
                    System.Diagnostics.Debug.WriteLine("un hijo" + Var1);
                    Lista.Add(Var1);
                    primes.Add(Var1);
                    //System.Diagnostics.Debug.WriteLine("se agrego" + root.ChildNodes.ElementAt(0).ToString().Replace(" (id2)", ""));

                    break;
                case 3:
                    String Var2 = root.ChildNodes.ElementAt(0).ToString().Replace(" (id2)", "");
                    System.Diagnostics.Debug.WriteLine("tres hijos" + Var2);
                    Lista.Add(Var2);
                    primes.Add(Var2);
                    ListaID2(root.ChildNodes.ElementAt(0));
                    //Lista.Add(root.ChildNodes.ElementAt(2).ToString().Replace(" (id2)", ""));
                    //System.Diagnostics.Debug.WriteLine("se agrego" + root.ChildNodes.ElementAt(0).ToString().Replace(" (id2)", ""));

                    break;
            }
                    return Lista;
        }
        
        public int repeticiones(String cadena)
        {
            int contador = 0;
            int posicion = 0;
            String patron = "*";
            for (int i = 0; i < cadena.Length ; i++)
            {
                posicion = cadena.IndexOf(patron);
                if (posicion != -1)
                {
                    contador++;
                    cadena = cadena.Substring(posicion + patron.Length);
                }
            }
            return contador;
        }

    }
}