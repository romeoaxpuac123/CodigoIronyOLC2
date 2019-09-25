using AnalizadorCQL.Analizadores_Codigo;
using AnalizadorCQL.Analizadores_CodigoAST;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace AnalizadorCQL.Analizadores
{
    public class Recorrido
    {
        public NodoAbstracto Raiz;
        List<String> primes = new List<String>();
        List<String> FuncionesXD = new List<String>();
        
        public NodoAbstracto Recorrido1(ParseTreeNode root)
        {
            System.Diagnostics.Debug.WriteLine(root.ChildNodes.Count);
            Gramatica g = new Gramatica();
            switch (root.ChildNodes.Count)
            {
                case 0:
                    #region HIJOS 0
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
                        nuevox.TipoDato = "id";
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
                #endregion
                case 1:                
                    #region HIJOS 1
                    System.Diagnostics.Debug.WriteLine("CAso1 -> " + root.ToString());
                    if (root.ToString() == "S")
                    {
                        //Console.WriteLine("PASO POR LA EXPRESION S (RAIZ)");
                        NodoAbstracto nuevo1 = new Nodo("INICIO");
                        nuevo1.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                        Raiz = nuevo1;

                    }
                    if (root.ToString() == "SENTENCIA")
                    {
                        //Console.WriteLine("PASO POR LA EXPRESION S (RAIZ)");

                           return (Recorrido1(root.ChildNodes.ElementAt(0)));


                    }
                  
                    else if (root.ToString() == "DEFINCION_GENERAL_CQL")
                    {
                        //Console.WriteLine("PASO POR LA EXPRESION S (RAIZ)");

                      // if(root.ChildNodes.ElementAt(0).ToString()!="CREATE_TYPE" || root.ChildNodes.ElementAt(0).ToString() != "USER_TYPE2")
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
                            String valor = root.ChildNodes.ElementAt(0).ToString();
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
                            nuevox.TipoDato = "id";
                            nuevox.NombreVariable = root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", "");
                            RESULT1 = nuevox;
                            //Raiz = nuevox;
                            return RESULT1;
                        }
                    }
                    else if (root.ToString() == "LISTA_EXPRESION")
                    {

                        NodoAbstracto nuevo = Recorrido1(root.ChildNodes.ElementAt(0));
                        // esto que pexNodoAbstracto nuevo = new Nodo(root.ChildNodes.ElementAt(0).ToString());
                        //NodoAbstracto nuevx = new Nodo(root.ChildNodes.ElementAt(0).ToString());
                        //nuevo.Hijos.Add(nuevx);
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                       // nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                        return nuevo;
                    }

                    break;
                #endregion
                case 2:                
                    #region HIJOS 2
                    System.Diagnostics.Debug.WriteLine("CAso2 -> " + root.ToString());
                    if (root.ToString() == "SENTENCIA")
                    {
                        //Console.WriteLine("PASO POR LA EXPRESION S (RAIZ)");
                        NodoAbstracto  nuevo = Recorrido1(root.ChildNodes.ElementAt(0));

                        //return (Recorrido1(root.ChildNodes.ElementAt(0)));
                        return nuevo;


                    }
                    else if (root.ToString() == "SENTENCIAS")
                    {
                       
                        NodoAbstracto nuevo = Recorrido1(root.ChildNodes.ElementAt(0));
                       
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(1)));
                        
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
                                NodoAbstracto id3 = new Nodo(root.ChildNodes.ElementAt(0).ChildNodes.ElementAt(1).ToString().Replace(" (id2)", ""));
                                nuevo.Hijos.Add(id);
                                nuevo.Hijos.Add(id2);
                                nuevo.Hijos.Add(id3);
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
                    else if (root.ChildNodes.ElementAt(0).FindToken().ToString().Contains("id")
                       && root.ChildNodes.ElementAt(1).FindToken().ToString().Contains("id2")
                      )
                    {
                        System.Diagnostics.Debug.WriteLine("CODIGO PARA CREAR UN OJBETO Estudiante @est;");
                        NodoAbstracto nuevox = new Nodo("SENTENCIAS");
                        NodoAbstracto nuevo1 = new Nodo(root.ChildNodes.ElementAt(0).ToString());
                        NodoAbstracto nuevo2 = new Nodo(root.ChildNodes.ElementAt(1).ToString());
                        nuevox.Hijos.Add(nuevo1);
                        nuevox.Hijos.Add(nuevo2);
                        return nuevox;

                    }

                    break;
                #endregion
                case 3:                 
                    #region HIJOS 3
                   System.Diagnostics.Debug.WriteLine("CAso3 -> " + root.ToString());
                    if (root.ToString().Contains("INC_DEC")== true)
                    {
                        System.Diagnostics.Debug.WriteLine("INC_DEC");
                        NodoAbstracto nuevo = new Incremento("INCREMENTO");
                        Nodo nuevoid = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id2)", ""));
                        Nodo nuevoid2 = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (Key symbol)", ""));
                        nuevo.Hijos.Add(nuevoid);
                        nuevo.Hijos.Add(nuevoid2);
                        return nuevo;

                    }
                    else if(root.ToString() == "LISTA_EXPRESION")
                    {
                        NodoAbstracto nuevo = Recorrido1(root.ChildNodes.ElementAt(0));
                        // esto que pexNodoAbstracto nuevo = new Nodo(root.ChildNodes.ElementAt(0).ToString());
                        //NodoAbstracto nuevx = new Nodo(root.ChildNodes.ElementAt(0).ToString());
                        //nuevo.Hijos.Add(nuevx);
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
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
                            NodoAbstracto nuevo = new FUN_RETORNO("EXP");
                            NodoAbstracto Funcion = new  Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", ""));
                           
                            nuevo.Hijos.Add(Funcion);
                            String TipoRetorno = "";
                            for(int i = 0; i < FuncionesXD.Count; i++)
                            {
                                string[] separadas;
                                separadas = FuncionesXD[i].Split('*');
                                TipoRetorno = separadas[1];
                                if (separadas[0].ToUpper().Contains(root.ChildNodes.ElementAt(0).FindToken().ToString().ToUpper().Replace(" (ID)", "")))
                                {
                                    if(separadas[2] == "0")
                                    {
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
                                    }
                                }
                            }

                            nuevo.TipoDato = TipoRetorno;
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
                    }
                    else if (root.ToString().ToUpper().Contains("ELRETORNO"))
                    {
                        
                        NodoAbstracto nuevo = new RETORNO("RETORNO");
                        ///NodoAbstracto id = new Nodo(root.ChildNodes.ElementAt(1).ToString().Replace(" (id2)", ""));
                        if (root.ChildNodes.ElementAt(1).ToString() == "E")
                        {
                            nuevo.AutoIncrmentable2 = 100;
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(1)));
                        }
                        else
                        {
                            nuevo.AutoIncrmentable2 = 200;
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for(int i = 0; i< STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                        }
                        

                        return nuevo;
                    }
                    else if (root.ToString().ToUpper().Contains("DDL")){
                        NodoAbstracto nuevo = new USE("USE");
                        NodoAbstracto bd = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", ""));
                        nuevo.Hijos.Add(bd);
                        return nuevo;
                    }
                    break;
                #endregion
                case 4:                   
                    #region HIJOS 4
                    System.Diagnostics.Debug.WriteLine("CAso4 -> " + root.ToString());
                    if (root.ToString() == "DDL") {
                        if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("CREATE"))
                        {
                            NodoAbstracto nuevo = new BD("BD");
                            NodoAbstracto BDS = new Nodo(root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(BDS);
                            return nuevo;
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
                        else if ((root.ChildNodes.ElementAt(0).ToString().Contains(" (id)")) &&
                          (root.ChildNodes.ElementAt(1).ToString().Contains("( (Key symbol)")) &&
                          (root.ChildNodes.ElementAt(3).ToString().Contains(") (Key symbol)"))
                          )
                        {
                            System.Diagnostics.Debug.WriteLine("FUNCIONES usuario----------");
                            NodoAbstracto nuevo = new  FUN_RETORNO("EXP");
                            NodoAbstracto nuevohijo = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", ""));
                            //NodoAbstracto Parametro1 =  Recorrido1(root.ChildNodes.ElementAt(2));
                            
                            nuevo.Hijos.Add(nuevohijo);
                            nuevo.Parametros = new List<NodoAbstracto>();
                            AtributosFuncionesUsuario(root.ChildNodes.ElementAt(2));
                            LalistaPTN.Clear();
                            contador = 0;
                            nuevo.Parametros.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                            AtributosDeNodosExpresiones(root);
                            for (int i = 0; i < LalistaPTN.Count; i++)
                            {
                                nuevo.Parametros.Add(LalistaPTN[i]);
                            }

                            LalistaPTN.Clear();
                            for (int i=0; i< STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            String TipoRetorno = "";
                            String TipoRetornox = "";
                            for (int i = 0; i < FuncionesXD.Count; i++)
                            {
                                string[] separadas;
                                separadas = FuncionesXD[i].Split('*');
                                TipoRetorno = separadas[1];
                                if (separadas[0].ToUpper().Contains(root.ChildNodes.ElementAt(0).FindToken().ToString().ToUpper().Replace(" (ID)", "")))
                                {
                                    if (separadas[2].ToString() == STN.Count.ToString())
                                    {
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
                                        else if (TipoRetorno.ToUpper().Contains("BOOLEANO"))
                                        {
                                            TipoRetornox = "Booleano";
                                        }
                                        else if (TipoRetorno.ToUpper().Contains("DATE"))
                                        {
                                            TipoRetornox = "Fechas";
                                        }
                                        else if (TipoRetorno.ToUpper().Contains("TIME"))
                                        {
                                            TipoRetornox = "hora";
                                        }
                                    }
                                }
                            }

                            nuevo.TipoDato = TipoRetornox;
                            //nuevo.TipoDato = "entero";
                            STN.Clear();
                            //nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                            nuevo.AutoIncrmentable2 = 345;
                            return nuevo;
                        }
                        else if (root.ChildNodes.ElementAt(1).FindToken().ToString().Contains(" (Keyword)")) 
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
                #endregion
                case 5:
                    #region HIJOS 5
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
                    else if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("LOG")
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

                    else if (root.ToString() == "PERMISOSUSUARIO")
                    {
                        NodoAbstracto nuevo = new PERMISOS("PERMISOS");
                        NodoAbstracto USUARIO = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", ""));
                        NodoAbstracto BD = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                        nuevo.Hijos.Add(USUARIO);
                        nuevo.Hijos.Add(BD);
                        if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("GRANT"))
                        {
                            nuevo.AutoIncrmentable2 = 1;
                        }
                        else
                        {
                            nuevo.AutoIncrmentable2 = 2;
                        }
                        return nuevo;

                    }
                    else if (root.ToString() == "DDL")
                    {
                        //System.Diagnostics.Debug.WriteLine("CAso5 ---------------------------> " + root.ChildNodes.ElementAt(0).ToString().ToUpper());
                        if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT") == true)
                        {
                            System.Diagnostics.Debug.WriteLine("CAso5 -> " + root.ToString());
                            NodoAbstracto nuevo = new SELECT_SIMPLE("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                            // NodoAbstracto UNO = new Nodo(root.ChildNodes.ElementAt(1).ToString());
                            nuevo.Hijos.Add(Tabla);

                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            return nuevo;

                        }
                        else
                        {
                            NodoAbstracto nuevo = new UPDATE("ACTUALIZAR");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Parametros_Update(root.ChildNodes.ElementAt(3));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            return nuevo;

                        }

                    }
                    else if (root.ToString() == "DDL2")
                    {
                        //System.Diagnostics.Debug.WriteLine("CAso5 ---------------------------> " + root.ChildNodes.ElementAt(0).ToString().ToUpper());
                        if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT") == true)
                        {
                            System.Diagnostics.Debug.WriteLine("CAso5 -> " + root.ToString());
                            NodoAbstracto nuevo = new CURSOR_SELECT("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                            // NodoAbstracto UNO = new Nodo(root.ChildNodes.ElementAt(1).ToString());
                            nuevo.Hijos.Add(Tabla);

                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            return nuevo;

                        }
                    }
                        break;

                #endregion
                case 6:                    
                    #region HIJOS 6
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

                    else if (root.ToString() == "DDL")
                    {

                        if (root.ChildNodes.ElementAt(3).FindToken().ToString().ToUpper().Contains("DROP") && root.ChildNodes.ElementAt(0).FindToken().ToString().ToUpper().Contains("ALTER"))
                        {
                            System.Diagnostics.Debug.WriteLine("CODIGO PARA ALTER TABLE DROP");
                            NodoAbstracto nuevo = new ALTER_TABLE_DROP("ELIMINAR");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            nuevo.AutoIncrmentable2 = 2;
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(4));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            return nuevo;
                        }
                        else if (root.ChildNodes.ElementAt(3).FindToken().ToString().ToUpper().Contains("ADD") && root.ChildNodes.ElementAt(0).FindToken().ToString().ToUpper().Contains("ALTER"))
                        {
                            System.Diagnostics.Debug.WriteLine("CODIGO PARA ALTER TABLE ADD");
                            NodoAbstracto nuevo = new ALTER_TABLE_ADD("INSERTAR");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            nuevo.AutoIncrmentable2 = 2;
                            STN.Clear();
                            ParametrosTabla(root.ChildNodes.ElementAt(4));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            return nuevo;

                        }
                      

                    }
                    
                    
                    break;
                #endregion
                case 7:
                    #region HIJOS 7
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
                        FuncionesXD.Add(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", "") + "*" + root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", "") + "*" + 0);
                        
                        return nuevo;

                    }
                    else if (root.ToString().Contains("EL_IF"))
                    {
                        NodoAbstracto nuevo = new ELIF("IF");
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(5)));
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
                    else if (root.ToString().ToUpper().Contains("CREARUSUARIO"))
                    {
                        NodoAbstracto nuevo = new USUARIOS("USUARIO");
                        NodoAbstracto elusuario = new Nodo(root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (id)", ""));
                        NodoAbstracto password = new Nodo(root.ChildNodes.ElementAt(5).FindToken().ToString().Replace(" (cadena)", ""));
                        nuevo.Hijos.Add(elusuario);
                        nuevo.Hijos.Add(password);
                        return nuevo;
                    }
                    if (root.ToString() == "DDL")
                    {
                        if (root.ChildNodes.ElementAt(1).ToString().ToUpper().Contains("DATABASE"))
                        {
                            NodoAbstracto nuevo = new BD("BD");
                            NodoAbstracto BDS = new Nodo(root.ChildNodes.ElementAt(5).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(BDS);
                            nuevo.AutoIncrmentable2 = 2;
                            return nuevo;
                        }
                        else if (root.ChildNodes.ElementAt(1).ToString().ToUpper().Contains("TABLE"))
                        {
                            NodoAbstracto nuevo = new Tabla("Tabla");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            ParametrosTabla(root.ChildNodes.ElementAt(4));
                            for(int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            return nuevo;
                        }
                        else if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("UPDATE"))
                        {
                            NodoAbstracto nuevo = new UPDATE_WHERE("ACTUALIZAR2");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Parametros_Update(root.ChildNodes.ElementAt(3));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(5)));
                            return nuevo;
                        }
                        else if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT") == true
                            && root.ChildNodes.ElementAt(4).ToString().ToUpper().Contains("LIMIT") == true)
                        {
                            //System.Diagnostics.Debug.WriteLine("CAso5 -> " + root.ToString());
                            NodoAbstracto nuevo = new SELECT_LIMIT("SLEEC-LIMIT");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(5)));
                            return nuevo;

                        }
                        else if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT") == true)
                        {
                            //System.Diagnostics.Debug.WriteLine("CAso5 -> " + root.ToString());
                            NodoAbstracto nuevo = new SELECT_WHERE("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(5)));
                            return nuevo;

                        }

                    }

                    #endregion
                    break;
                case 8:                    
                    #region HIJOS 8
                    System.Diagnostics.Debug.WriteLine("CAso8 -> " + root.ToString());

                    if (root.ToString().ToUpper().Contains("USER_TYPE2"))
                    {
                        NodoAbstracto nuevo = new ASIGNACIONOBJETOS("INSTANCIA");
                        NodoAbstracto id = new Nodo(root.ChildNodes.ElementAt(6).ToString().Replace(" (id2)", ""));
                        NodoAbstracto id2 = new Nodo(root.ChildNodes.ElementAt(0).ToString().Replace(" (id)", ""));
                        NodoAbstracto id3 = new Nodo(root.ChildNodes.ElementAt(6).ToString().Replace(" (id2)", ""));
                        nuevo.Hijos.Add(id);
                        nuevo.Hijos.Add(id2);
                        nuevo.Hijos.Add(id3);
                        nuevo.AutoIncrmentable2 = 181890;

                        STN.Clear();
                        System.Diagnostics.Debug.WriteLine("__________________________________________________");


                      
                        AtributosUT(root.ChildNodes.ElementAt(3));
                        
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaID1.Add(STN[i]);
                        }
                        STN.Clear();
                        
                        System.Diagnostics.Debug.WriteLine("__________________________________________________");
                        return nuevo;
                    }

                
                    else if (root.ToString().Contains("EL_IF"))
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
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaID1.Add(STN[i]);
                        }

                        nuevo.AutoIncrmentable2 = 68;
                        FuncionesXD.Add(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", "") + "*" + root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", "") + "*" + STN.Count);
                        STN.Clear();
                        return nuevo;

                    }
                    else if (root.ToString().Contains("ELCALL"))
                    {
                        NodoAbstracto nuevo = new CALL("EXP");
                        NodoAbstracto proc = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)",""));
                        STN.Clear();
                        Atributos(root.ChildNodes.ElementAt(0));
                        for(int i = 0; i<STN.Count; i++)
                        {
                            nuevo.ListaID1.Add(STN[i].Replace( " (id2)",""));
                        }
                        STN.Clear();

                        STN.Clear();
                        nuevo.ListaR1 = new List<String>();
                        Atributos(root.ChildNodes.ElementAt(5));
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaR1.Add(STN[i].Replace(" (id2)", ""));
                        }
                        STN.Clear();


                        nuevo.Hijos.Add(proc);
                        return nuevo;

                    }

                    else if (root.ToString().Contains("SINO"))
                    {
                        NodoAbstracto nuevo = new Nodo("SINO");
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(3)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(6)));
                        return nuevo;
                    }
                
                    else if (root.ToString().ToUpper().Contains("LALISTA") && root.ChildNodes.ElementAt(0).ToString().Contains("(Keyword") == true)
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
                    if (root.ToString().ToUpper().Contains("DDL"))
                    {
                        if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT"))
                        {
                            NodoAbstracto nuevo = new SELECT_ORDER_BY("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(6));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            return nuevo;
                        }
                        if(root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("INSERT"))
                        {
                            NodoAbstracto nuevo = new INSERSCION_SIMPLE("INSERTAR1");
                            NodoAbstracto id = new Nodo(root.ChildNodes.ElementAt(2).ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(id);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(5));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            return nuevo;
                        }
                      

                    }
                    break;
                #endregion
                case 9:
                    #region HIJOS 9
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
                    else if (root.ToString().ToUpper().Contains("USER_TYPE2"))
                    {
                        NodoAbstracto nuevo = new ASIGNACIONOBJETOS("INSTANCIA");
                        NodoAbstracto id = new Nodo(root.ChildNodes.ElementAt(0).ToString().Replace(" (id2)", ""));
                        NodoAbstracto id2 = new Nodo(root.ChildNodes.ElementAt(1).ToString().Replace(" (id2)", ""));
                        NodoAbstracto id3 = new Nodo(root.ChildNodes.ElementAt(7).ToString().Replace(" (id)", ""));
                        nuevo.Hijos.Add(id);
                        nuevo.Hijos.Add(id2);
                        nuevo.Hijos.Add(id3);
                        nuevo.AutoIncrmentable2 = 9999;

                        STN.Clear();
                        System.Diagnostics.Debug.WriteLine("______x____________________________________________");


                        System.Diagnostics.Debug.WriteLine("sdaf");
                        AtributosUT(root.ChildNodes.ElementAt(4));
                        System.Diagnostics.Debug.WriteLine("sdaf");
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaID1.Add(STN[i]);
                        }
                        STN.Clear();
                        System.Diagnostics.Debug.WriteLine("_______f___________________________________________");
                        return nuevo;
                    }
                    else if (root.ToString() == "E")
                    {
                        System.Diagnostics.Debug.WriteLine("CAso9SDSSSS -> " + root.ToString());
                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("COUNT")))
                        {
                            NodoAbstracto nuevo = new COUNT_SELECT("EXP");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(4));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("MIN")))
                        {
                            NodoAbstracto nuevo = new MIN_SELECT("EXP");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            nuevo.ListaR1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", "") + ",ASC");
                            STN.Clear();
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("MAX")))
                        {
                            NodoAbstracto nuevo = new MIN_SELECT("EXP");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            nuevo.ListaR1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", "") + ",ASC");
                            STN.Clear();
                            nuevo.TipoDato = "entero";
                            nuevo.AutoIncrmentable2 = 2;
                            return nuevo;
                        }

                    }

                        if (root.ToString() == "DDL")
                    {
                        if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT") == true)
                        {
                            //System.Diagnostics.Debug.WriteLine("CAso5 -> " + root.ToString());
                            NodoAbstracto nuevo = new SELECT_WHERE_LIMITE("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(5)));
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(7)));
                            return nuevo;

                        }
                    }
                        break;
                #endregion
                case 10:
                    #region HIJOS 10
                    System.Diagnostics.Debug.WriteLine("CAso10 -> " + root.ToString());
                    if (root.ToString().Contains("EL_FOR"))
                    {
                        NodoAbstracto nuevo = new ELFOR("FOR");
                      
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(3)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(5)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(8)));
                        return nuevo;
                    }
                    else if (root.ToString().Contains("PROCEDIMIENTOS"))
                    {
                        NodoAbstracto nuevo = new PROCEDIMIENTOS("PROC");
                        NodoAbstracto Nombre = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", ""));
                        nuevo.Hijos.Add(Nombre);
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(8)));
                        nuevo.ListaID1 = new List<String>();
                        nuevo.ListaR1 = new List<String>();
                        nuevo.AutoIncrmentable2 = 9000;
                        return nuevo;
                    }
                    else if (root.ToString().Contains("CREATE_TYPE"))
                    {
                       ListaIDSObjetoXX(root.ChildNodes.ElementAt(7));
                        System.Diagnostics.Debug.WriteLine("Codigo para LA CREACION DE OBJETOSXS;");
                        NodoAbstracto nuevo = new USER_TYPE("USER_TYPE");
                        NodoAbstracto nuevoid = new Nodo(root.ChildNodes.ElementAt(5).FindToken().ToString());
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
                   else if (root.ToString() == "DDL")
                    {
                        
                        if (root.ChildNodes.ElementAt(1).ToString().ToUpper().Contains("TABLE"))
                        {
                            NodoAbstracto nuevo = new Tabla("Tabla");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(5).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            nuevo.AutoIncrmentable2 = 2;
                            STN.Clear();
                            ParametrosTabla(root.ChildNodes.ElementAt(7));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            return nuevo;
                        }
                        else if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT") == true &&
                            root.ChildNodes.ElementAt(6).ToString().ToUpper().Contains("ORDER"))
                        {
                            //System.Diagnostics.Debug.WriteLine("CAso5 -> " + root.ToString());
                            NodoAbstracto nuevo = new SELECT_WHERE_ORDER_BY("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(6));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(5)));
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(8));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(9)));
                            return nuevo;

                        }
                        else if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT"))
                        {
                            NodoAbstracto nuevo = new SELECT_ORDER_BY_LIMIT("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(6));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(8)));
                            return nuevo;
                        }

                    }
                    break;
                #endregion
                case 11:
                    #region HIJOS 11
                    System.Diagnostics.Debug.WriteLine("CAso11 -> " + root.ToString());
                    if (root.ToString().Contains("EL_IF"))
                    {
                        NodoAbstracto nuevo = new ELSEIF("ELSEIF");
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(5)));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(9)));
                        return nuevo;
                    }
                    else if (root.ToString().Contains("PROCEDIMIENTOS"))
                    {
                        if (root.ChildNodes.ElementAt(3).ToString().Contains("LISTA"))
                        {
                            NodoAbstracto nuevo = new PROCEDIMIENTOS("PROC");
                            NodoAbstracto Nombre = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Nombre);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(9)));
                            //nuevo.ListaID1 = new List<String>();
                            STN.Clear();
                            AtributosFunciones(root.ChildNodes.ElementAt(3));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            nuevo.AutoIncrmentable2 = 9000;
                            return nuevo;
                        }
                        else
                        {
                            NodoAbstracto nuevo = new PROCEDIMIENTOS("EXP");
                            NodoAbstracto Nombre = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Nombre);
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(9)));
                            //nuevo.ListaID1 = new List<String>();
                            nuevo.ListaR1 = new List<String>();
                            STN.Clear();
                            AtributosFunciones(root.ChildNodes.ElementAt(6));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            //nuevo.ListaR1 = new List<String>();
                            nuevo.AutoIncrmentable2 = 9000;
                            return nuevo;
                        }
                       
                    }
                    else if (root.ToString() == "DDL")
                    {

                            System.Diagnostics.Debug.WriteLine("CODIGO PARA insertadardatos TABLE DROP");
                            NodoAbstracto nuevo = new INSERCION_ESPECIAL("INSERTAR");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(4));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                       
                            nuevo.Hijos.Add(Tabla);
                            nuevo.AutoIncrmentable2 = 2;
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Atributos(root.ChildNodes.ElementAt(8));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            return nuevo;

                        

                    }
                    else if (root.ToString() == "E")
                    {

                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("COUNT"))
                            && ((root.ChildNodes.ElementAt(7).ToString().ToUpper().Contains("LIMIT"))) )
                        {
                            NodoAbstracto nuevo = new COUNT_SELECT_LIMIT("EXP");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(4));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(8)));
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("COUNT"))
                           && ((root.ChildNodes.ElementAt(7).ToString().ToUpper().Contains("WHERE"))))
                        {
                            NodoAbstracto nuevo = new COUNT_SELECT_WHERE("EXP");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(4));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(8)));
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                         if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("MIN"))
                            && ((root.ChildNodes.ElementAt(7).ToString().ToUpper().Contains("LIMIT"))))
                        {
                            NodoAbstracto nuevo = new MIN_SELECT_LIMIT("EXP");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));
                            
                            nuevo.ListaR1 = new List<String>();
                            nuevo.ListaR1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", "") + ",ASC");
                            
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(8)));
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("MAX"))
                            && ((root.ChildNodes.ElementAt(7).ToString().ToUpper().Contains("LIMIT"))))
                        {
                            NodoAbstracto nuevo = new MIN_SELECT_LIMIT("EXP");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);

                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));

                            nuevo.ListaR1 = new List<String>();
                            nuevo.ListaR1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", "") + ",ASC");

                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(8)));
                            nuevo.AutoIncrmentable2 = 2;
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                    }
                    break;
                #endregion
                case 12:                    
                    #region HIJOS 12
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
                    else if (root.ToString().Contains("PROCEDIMIENTOS"))
                    {
                        NodoAbstracto nuevo = new PROCEDIMIENTOS("PROC");
                        NodoAbstracto Nombre = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", ""));
                        nuevo.Hijos.Add(Nombre);
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(10)));
                        //nuevo.ListaID1 = new List<String>();
                        nuevo.ListaR1 = new List<String>();
                        STN.Clear();
                        AtributosFunciones(root.ChildNodes.ElementAt(7));
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaR1.Add(STN[i]);
                        }
                        STN.Clear();

                        STN.Clear();
                        AtributosFunciones(root.ChildNodes.ElementAt(3));
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaID1.Add(STN[i]);
                        }
                        STN.Clear();



                        //nuevo.ListaR1 = new List<String>();
                        nuevo.AutoIncrmentable2 = 9000;
                        return nuevo;

                    }
                    else if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT") == true &&
                       root.ChildNodes.ElementAt(6).ToString().ToUpper().Contains("ORDER"))
                    {
                        //System.Diagnostics.Debug.WriteLine("CAso5 -> " + root.ToString());
                        NodoAbstracto nuevo = new SELECT_WHERE_ORDER_BY_LIMIT("SIMPLE");
                        NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                        nuevo.Hijos.Add(Tabla);
                        STN.Clear();
                        Atributos(root.ChildNodes.ElementAt(1));
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaID1.Add(STN[i]);
                        }
                        STN.Clear();
                        nuevo.ListaR1 = new List<String>();
                        Parametros_Order_By(root.ChildNodes.ElementAt(6));
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaR1.Add(STN[i]);
                        }
                        STN.Clear();
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(5)));
                        nuevo.ListaR1 = new List<String>();
                        Parametros_Order_By(root.ChildNodes.ElementAt(8));
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaR1.Add(STN[i]);
                        }
                        STN.Clear();
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(10)));
                        return nuevo;

                    }
                    else if (root.ToString() == "E")
                    {

                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("COUNT"))
                            )
                        {
                            NodoAbstracto nuevo = new COUNT_SELECT_ORDER_BY("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(4));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(9));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                    }

                    break;
                #endregion
                case 13:
                    #region hijos13
                    if (root.ToString() == "E")
                    {

                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("COUNT"))
                            )
                        {
                            NodoAbstracto nuevo = new COUNT_SELECT_WHERE_LIMIT("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(4));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(8)));
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(10)));
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                    }
                        break;
                #endregion 
                case 14:
                   #region hijos14
                    if (root.ToString() == "E")
                    {

                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("COUNT"))
                            && (root.ChildNodes.ElementAt(9).ToString().ToUpper().Contains("ORDER"))
                           )
                        {
                            NodoAbstracto nuevo = new COUNT_SELECT_WHERE_ORDER_BY("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(4));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(9));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(8)));
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(11));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(12)));
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("COUNT"))
                            )
                        {
                            NodoAbstracto nuevo = new COUNT_SELECT_ORDER_BY_LIMIT("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(4));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(9));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(11)));
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                    }
                    break;
                #endregion

                case 16:
                    #region hijos16
                    if (root.ToString() == "E")
                    {

                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("COUNT"))

                           )
                        {
                            if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("COUNT"))
                             )
                            {
                                NodoAbstracto nuevo = new COUNT_SELECT_WHERE_ORDER_BY_LIMIT("SIMPLE");
                                NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                                nuevo.Hijos.Add(Tabla);
                                STN.Clear();
                                Atributos(root.ChildNodes.ElementAt(4));
                                for (int i = 0; i < STN.Count; i++)
                                {
                                    nuevo.ListaID1.Add(STN[i]);
                                }
                                STN.Clear();
                                nuevo.ListaR1 = new List<String>();
                                Parametros_Order_By(root.ChildNodes.ElementAt(9));
                                for (int i = 0; i < STN.Count; i++)
                                {
                                    nuevo.ListaR1.Add(STN[i]);
                                }
                                STN.Clear();
                                nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(8)));
                                nuevo.ListaR1 = new List<String>();
                                Parametros_Order_By(root.ChildNodes.ElementAt(11));
                                for (int i = 0; i < STN.Count; i++)
                                {
                                    nuevo.ListaR1.Add(STN[i]);
                                }
                                STN.Clear();
                                nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(13)));
                                nuevo.TipoDato = "entero";
                                return nuevo;
                            }
                        }
                    }
                    break;
                #endregion
              
                 
            }

            return null;
        }
        public NodoAbstracto Recorrido12(ParseTreeNode root)
        {
            switch (root.ChildNodes.Count)
            {
                case 0:
                    #region hijos0
                    System.Diagnostics.Debug.WriteLine("RECORRIDO12->0" + root.ToString());
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
                    #endregion
                    break;
                case 1:
                    #region hijos1
                    System.Diagnostics.Debug.WriteLine("RECORRIDO12->1" + root.ToString());
                    if (root.ToString() == "S")
                    {
                        NodoAbstracto nuevo1 = new Nodo("INICIO");
                        NodoAbstracto nuevo2 = new Nodo(root.ChildNodes.ElementAt(0).ToString());
                        nuevo1.Hijos.Add(nuevo2);
                        for (int i = 0; i < root.ChildNodes.ElementAt(0).ChildNodes.Count; i++)
                        {
                            nuevo2.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(0).ChildNodes.ElementAt(i)));
                        }


                        Raiz = nuevo1;

                    }

                    if (root.ToString() == "SENTENCIA")
                    {
                        //Console.WriteLine("PASO POR LA EXPRESION S (RAIZ)");

                        return (Recorrido12(root.ChildNodes.ElementAt(0)));


                    }
                    if (root.ToString() == "SENTENCIAS")
                    {
                        //Recorrido12(root.ChildNodes.ElementAt(0));
                        //return (Recorrido12(root.ChildNodes.ElementAt(0)));
                        NodoAbstracto nuevo = new Nodo("SENTENCIAS");
                        nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(0)));

                        return nuevo;
                    }
                    else if (root.ToString() == "E")
                    {
                        if (root.ChildNodes.ElementAt(0).FindToken().ToString().Contains("(numero)"))
                        {
                            //System.Diagnostics.Debug.WriteLine("!!! -> " + root.ChildNodes.ElementAt(0).ToString());
                            NodoAbstracto RESULT1 = null;
                            NodoAbstracto nuevox = new Nodo("Entero");
                            NodoAbstracto nuevovalor = new Nodo(root.ChildNodes.ElementAt(0).ToString());
                            nuevox.Hijos.Add(nuevovalor);
                            nuevox.TipoDato = "entero";
                            RESULT1 = nuevox;
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
                            String valor = root.ChildNodes.ElementAt(0).ToString();
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
                            nuevox.TipoDato = "id";
                            nuevox.NombreVariable = root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", "");
                            RESULT1 = nuevox;
                            //Raiz = nuevox;
                            return RESULT1;
                        }
                    }

                    else if (root.ToString() == "DEFINCION_GENERAL_CQL")
                    {
                        //Console.WriteLine("PASO POR LA EXPRESION S (RAIZ)");

                        // if(root.ChildNodes.ElementAt(0).ToString()!="CREATE_TYPE" || root.ChildNodes.ElementAt(0).ToString() != "USER_TYPE2")
                        return (Recorrido12(root.ChildNodes.ElementAt(0)));


                    }
                    else if (root.ToString() == "LISTA_EXPRESION")
                    {
                        NodoAbstracto nuevo = Recorrido12(root.ChildNodes.ElementAt(0));
                        // esto que pexNodoAbstracto nuevo = new Nodo(root.ChildNodes.ElementAt(0).ToString());
                        //NodoAbstracto nuevx = new Nodo(root.ChildNodes.ElementAt(0).ToString());
                        //nuevo.Hijos.Add(nuevx);
                        nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(0)));
                        //nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                        return nuevo;
                    }

                    #endregion
                    break;
                case 2:
                    #region hijos2
                    System.Diagnostics.Debug.WriteLine("RECORRIDO12->2" + root.ToString());
                    if (root.ToString() == "DEFINCION_GENERAL_CQL")
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
                                NodoAbstracto id3 = new Nodo(root.ChildNodes.ElementAt(0).ChildNodes.ElementAt(1).ToString().Replace(" (id2)", ""));
                                nuevo.Hijos.Add(id);
                                nuevo.Hijos.Add(id2);
                                nuevo.Hijos.Add(id3);
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
                    else if (root.ToString() == "E")
                    {

                        if (root.ChildNodes.ElementAt(1).ToString().Contains("-- (Key symbol"))
                        {
                            //    CODIGO PARA MENOS1;
                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("-");
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(1)));
                            nuevo.AutoIncrmentable = 1;
                            nuevo.TipoDato = "decimal";

                            return nuevo;

                        }
                        if (root.ChildNodes.ElementAt(1).FindToken().ToString().Contains("(numero)")
                            && root.ChildNodes.ElementAt(0).ToString().Contains("- (Key symbol"))
                        {
                            //    CODIGO PARA MENOS1;
                            NodoAbstracto RESULT = null;
                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("*");
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(1)));

                            RESULT = nuevo;
                            RESULT.TipoDato = "entero";
                            return RESULT;

                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("++ (Key symbol")))
                        {
                            System.Diagnostics.Debug.WriteLine("CODIGO PARA ++ CREAR UN OJBETO Estudiante @est;");

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("+");
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(1)));
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
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(1)));

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
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(1)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(1)));

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
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(1)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(1)));

                            RESULT = nuevo;
                            RESULT.TipoDato = "Booleano";
                            return RESULT;

                        }
                    }
                    else if (root.ToString() == "USER_TYPE2")
                    {
                  
                                NodoAbstracto nuevo = new ERROR("USER_TYPE");
                             
                                return nuevo;
                          
                     

                    }

                    else if (root.ToString() == "ELBREAK")
                    {
                        NodoAbstracto nuevo = new BREAK("BREAK");
                        return nuevo;
                    }
                    #endregion
                    break;
                case 3:
                    #region hijos3
                    if (root.ToString() == "E")
                    {


                        NodoAbstracto RESULT = null;


                        if ((root.ChildNodes.ElementAt(0).ToString().Contains(" (id2)")) &&
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
                            NodoAbstracto nuevo = new FUN_RETORNO("EXP");
                            NodoAbstracto Funcion = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", ""));

                            nuevo.Hijos.Add(Funcion);
                            String TipoRetorno = "";
                            for (int i = 0; i < FuncionesXD.Count; i++)
                            {
                                string[] separadas;
                                separadas = FuncionesXD[i].Split('*');
                                TipoRetorno = separadas[1];
                                if (separadas[0].ToUpper().Contains(root.ChildNodes.ElementAt(0).FindToken().ToString().ToUpper().Replace(" (ID)", "")))
                                {
                                    if (separadas[2] == "0")
                                    {
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
                                    }
                                }
                            }

                            nuevo.TipoDato = TipoRetorno;
                            nuevo.AutoIncrmentable2 = 54;
                            return nuevo;


                        }


                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("+ (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("+");
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            //Raiz = nuevo;

                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("- (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("-");
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            //Raiz = nuevo;

                        }
                        else if (repeticiones(root.ChildNodes.ElementAt(1).ToString()) == 1)
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("*");
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            //Raiz = nuevo;

                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("/ (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("/");
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            //Raiz = nuevo;
                        }

                        else if (repeticiones(root.ChildNodes.ElementAt(1).ToString()) == 2)
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("**");
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            //Raiz = nuevo;

                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("% (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("%");
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            //Raiz = nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("> (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo(">");
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            RESULT.TipoDato = "Booleano";
                            return RESULT;
                            //Raiz = nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains(">= (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo(">=");
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            RESULT.TipoDato = "Booleano";
                            return RESULT;
                            //Raiz = nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("< (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("<");
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            RESULT.TipoDato = "Booleano";
                            return RESULT;
                            //Raiz = nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("<= (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("<=");
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            RESULT.TipoDato = "Booleano";
                            return RESULT;
                            //Raiz = nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("== (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("==");
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            RESULT.TipoDato = "Booleano";
                            return RESULT;
                            //Raiz = nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("!= (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("!=");
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            RESULT.TipoDato = "Booleano";
                            return RESULT;
                            //Raiz = nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("|| (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("||");
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            RESULT.TipoDato = "Booleano";
                            return RESULT;
                            //Raiz = nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("&& (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("&&");
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                            RESULT = nuevo;
                            RESULT.TipoDato = "Booleano";
                            return RESULT;
                            //Raiz = nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("^ (Key symbol")))
                        {

                            NodoAbstracto nuevo = new Aritmetica("EXP");
                            NodoAbstracto nuevooperador = new Nodo("^");
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(0)));
                            nuevo.Hijos.Add(nuevooperador);
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
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
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                            nuevo.TipoDato = "CAST";
                            return nuevo;
                            //Raiz = nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(1).ToString().Contains("E")))
                        {


                            return Recorrido12(root.ChildNodes.ElementAt(1));
                            //Raiz = nuevo;
                        }

                        if (Recorrido12(root.ChildNodes.ElementAt(0)).TipoDato == "decimal"
                            && Recorrido12(root.ChildNodes.ElementAt(2)).TipoDato == "decimal")
                        {
                            RESULT.TipoDato = "decimal";
                        }
                        else if (Recorrido12(root.ChildNodes.ElementAt(0)).TipoDato == "id2")
                        {
                            RESULT.TipoDato = Recorrido12(root.ChildNodes.ElementAt(2)).TipoDato;
                        }
                        else if (Recorrido12(root.ChildNodes.ElementAt(2)).TipoDato == "id2")
                        {
                            RESULT.TipoDato = Recorrido12(root.ChildNodes.ElementAt(0)).TipoDato;
                        }

                        else if (Recorrido12(root.ChildNodes.ElementAt(0)).TipoDato == "entero"
                            && Recorrido12(root.ChildNodes.ElementAt(2)).TipoDato == "entero")
                        {
                            RESULT.TipoDato = "entero";
                        }
                        else if (Recorrido12(root.ChildNodes.ElementAt(0)).TipoDato == "entero"
                           && Recorrido12(root.ChildNodes.ElementAt(2)).TipoDato == "decimal")
                        {
                            RESULT.TipoDato = "decimal";
                        }
                        else if (Recorrido12(root.ChildNodes.ElementAt(0)).TipoDato == "decimal"
                           && Recorrido12(root.ChildNodes.ElementAt(2)).TipoDato == "entero")
                        {
                            RESULT.TipoDato = "decimal";
                        }
                        else if (Recorrido12(root.ChildNodes.ElementAt(0)).TipoDato == "cadena"
                          && Recorrido12(root.ChildNodes.ElementAt(2)).TipoDato == "cadena")
                        {
                            RESULT.TipoDato = "cadena";
                        }
                        else if (Recorrido12(root.ChildNodes.ElementAt(0)).TipoDato == "entero"
                          && Recorrido12(root.ChildNodes.ElementAt(2)).TipoDato == "cadena")
                        {
                            RESULT.TipoDato = "cadena";
                        }
                        else if (Recorrido12(root.ChildNodes.ElementAt(0)).TipoDato == "cadena"
                         && Recorrido12(root.ChildNodes.ElementAt(2)).TipoDato == "entero")
                        {
                            RESULT.TipoDato = "cadena";
                        }
                        else if (Recorrido12(root.ChildNodes.ElementAt(0)).TipoDato == "cadena"
                         && Recorrido12(root.ChildNodes.ElementAt(2)).TipoDato == "decimal")
                        {
                            RESULT.TipoDato = "cadena";
                        }
                        else if (Recorrido12(root.ChildNodes.ElementAt(0)).TipoDato == "decimal"
                         && Recorrido12(root.ChildNodes.ElementAt(2)).TipoDato == "cadena")
                        {
                            RESULT.TipoDato = "cadena";
                        }
                        else if (Recorrido12(root.ChildNodes.ElementAt(0)).TipoDato == "cadena"
                         && Recorrido12(root.ChildNodes.ElementAt(2)).TipoDato == "Booleano")
                        {
                            RESULT.TipoDato = "cadena";
                        }
                        else if (Recorrido12(root.ChildNodes.ElementAt(0)).TipoDato == "Booleano"
                        && Recorrido12(root.ChildNodes.ElementAt(2)).TipoDato == "cadena")
                        {
                            RESULT.TipoDato = "cadena";
                        }
                        else if (Recorrido12(root.ChildNodes.ElementAt(0)).TipoDato == "Fechas"
                        && Recorrido12(root.ChildNodes.ElementAt(2)).TipoDato == "Fechas")
                        {
                            RESULT.TipoDato = "Fechas";
                        }
                        else if (Recorrido12(root.ChildNodes.ElementAt(0)).TipoDato == "hora"
                        && Recorrido12(root.ChildNodes.ElementAt(2)).TipoDato == "hora")
                        {
                            RESULT.TipoDato = "hora";
                        }
                        else if (Recorrido12(root.ChildNodes.ElementAt(0)).TipoDato == "Booleano"
                        && Recorrido12(root.ChildNodes.ElementAt(2)).TipoDato == "Booleano")
                        {
                            RESULT.TipoDato = "Booleano";
                        }
                        else
                        {
                            RESULT.TipoDato = "cadena";
                        }

                        return RESULT;
                    }
                    else if (root.ToString().ToUpper().Contains("DDL"))
                    {
                        NodoAbstracto nuevo = new USE("USE");
                        NodoAbstracto bd = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", ""));
                        nuevo.Hijos.Add(bd);
                        return nuevo;
                    }
                    else if (root.ToString().ToUpper().Contains("ESTADO_CURSOR"))
                    {
                        NodoAbstracto nuevo = new ESTADO_CURSOR("ESTADO");
                        NodoAbstracto TIPO = new Nodo(root.ChildNodes.ElementAt(0).ToString());
                        NodoAbstracto CURSOR = new Nodo(root.ChildNodes.ElementAt(1).ToString());
                        nuevo.Hijos.Add(TIPO);
                        nuevo.Hijos.Add(CURSOR);
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
                                for (int i = 0; i < primes.Count; i++)
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
                    else if (root.ToString().Contains("INC_DEC") == true)
                    {
                        System.Diagnostics.Debug.WriteLine("INC_DEC");
                        NodoAbstracto nuevo = new Incremento("INCREMENTO");
                        Nodo nuevoid = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id2)", ""));
                        Nodo nuevoid2 = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (Key symbol)", ""));
                        nuevo.Hijos.Add(nuevoid);
                        nuevo.Hijos.Add(nuevoid2);
                        return nuevo;

                    }
                    else if (root.ToString() == "LISTA_EXPRESION")
                    {
                        NodoAbstracto nuevo = Recorrido12(root.ChildNodes.ElementAt(0));
                        // esto que pexNodoAbstracto nuevo = new Nodo(root.ChildNodes.ElementAt(0).ToString());
                        //NodoAbstracto nuevx = new Nodo(root.ChildNodes.ElementAt(0).ToString());
                        //nuevo.Hijos.Add(nuevx);
                        nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(0)));
                        nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                        return nuevo;
                    }
                    else if (root.ToString().ToUpper().Contains("ELRETORNO"))
                    {

                        NodoAbstracto nuevo = new RETORNO("RETORNO");
                        ///NodoAbstracto id = new Nodo(root.ChildNodes.ElementAt(1).ToString().Replace(" (id2)", ""));
                        if (root.ChildNodes.ElementAt(1).ToString() == "E")
                        {
                            nuevo.AutoIncrmentable2 = 100;
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(1)));
                        }
                        else
                        {
                            nuevo.AutoIncrmentable2 = 200;
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                        }


                        return nuevo;
                    }
                    #endregion
                    break;
                case 4:
                    #region hijos4
                    System.Diagnostics.Debug.WriteLine("RECORRIDO12->4" + root.ToString());
                    if (root.ToString().Contains("INC_DEC") == true)
                    {
                        System.Diagnostics.Debug.WriteLine("INC_DEC");
                        NodoAbstracto nuevo = new Incremento("INCREMENTO");
                        Nodo nuevoid = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id2)", ""));
                        Nodo nuevoid2 = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (Key symbol)", ""));
                        nuevo.Hijos.Add(nuevoid);
                        nuevo.Hijos.Add(nuevoid2);
                        return nuevo;

                    }
                    else if (root.ToString() == "DDL")
                    {
                        if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("CREATE"))
                        {
                            NodoAbstracto nuevo = new BD("BD");
                            NodoAbstracto BDS = new Nodo(root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(BDS);
                            return nuevo;
                        }

                    }
                    else if (root.ToString() == "CREAR_CURSOR")
                    {
                        NodoAbstracto nuevo = new CURSOR("CURSOR");
                        NodoAbstracto id = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", ""));
                        nuevo.Hijos.Add(id);
                        nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(3)));
                        return nuevo;

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
                            NodoAbstracto nuevoid = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id2)", ""));
                            nuevo.Hijos.Add(nuevoid);
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                            return nuevo;

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
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                            nuevo.AutoIncrmentable2 = 103;


                            return nuevo;
                        }

                        else if ((root.ChildNodes.ElementAt(0).ToString().Contains(" (id)")) &&
                          (root.ChildNodes.ElementAt(1).ToString().Contains("( (Key symbol)")) &&
                          (root.ChildNodes.ElementAt(3).ToString().Contains(") (Key symbol)"))
                          )
                        {
                            System.Diagnostics.Debug.WriteLine("FUNCIONES usuario----------");
                            NodoAbstracto nuevo = new FUN_RETORNO("EXP");
                            NodoAbstracto nuevohijo = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(nuevohijo);
                            AtributosFuncionesUsuario(root.ChildNodes.ElementAt(2));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                          
                            //NodoAbstracto Parametro1 =  Recorrido1(root.ChildNodes.ElementAt(2));
                            /*
                            nuevo.Hijos.Add(nuevohijo);
                            nuevo.Parametros = new List<NodoAbstracto>();
                            AtributosFuncionesUsuario(root.ChildNodes.ElementAt(2));
                            LalistaPTN.Clear();
                            contador = 0;
                            nuevo.Parametros.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                            AtributosDeNodosExpresiones(root);
                            for (int i = 0; i < LalistaPTN.Count; i++)
                            {
                                nuevo.Parametros.Add(LalistaPTN[i]);
                            }

                            LalistaPTN.Clear();
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            */
                            String TipoRetorno = "";
                            String TipoRetornox = "";
                            for (int i = 0; i < FuncionesXD.Count; i++)
                            {
                                string[] separadas;
                                separadas = FuncionesXD[i].Split('*');
                                TipoRetorno = separadas[1];
                                if (separadas[0].ToUpper().Contains(root.ChildNodes.ElementAt(0).FindToken().ToString().ToUpper().Replace(" (ID)", "")))
                                {
                                    if (separadas[2].ToString() == STN.Count.ToString())
                                    {
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
                                        else if (TipoRetorno.ToUpper().Contains("BOOLEANO"))
                                        {
                                            TipoRetornox = "Booleano";
                                        }
                                        else if (TipoRetorno.ToUpper().Contains("DATE"))
                                        {
                                            TipoRetornox = "Fechas";
                                        }
                                        else if (TipoRetorno.ToUpper().Contains("TIME"))
                                        {
                                            TipoRetornox = "hora";
                                        }
                                    }
                                }
                            }

                            nuevo.TipoDato = TipoRetornox;
                            //nuevo.TipoDato = "entero";
                            STN.Clear();


                            nuevo.Parametros = new List<NodoAbstracto>();
                            LalistaPTN.Clear();
                            AtributosDeNodosExpresiones(root);
                            for (int i = 0; i < LalistaPTN.Count; i++)
                            {
                                nuevo.Parametros.Add(LalistaPTN[i]);
                            }

                            LalistaPTN.Clear();

                            //nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                            nuevo.AutoIncrmentable2 = 345;
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
                    #endregion
                    break;
                case 5:
                    #region hijos5
                    System.Diagnostics.Debug.WriteLine("RECORRIDO12->5" + root.ToString());

                    if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("LOG"))
                    {
                        NodoAbstracto nuevo2 = new LOG("IMPRIMIR");
                        nuevo2.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                        return nuevo2;
                    }
                    else if (root.ToString().ToUpper().Contains("ASIGNACION"))
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
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(3)));
                            for (int i = 0; i < primes.Count; i++)
                            {
                                nuevo.ListaID1.Add(primes[i]);
                            }

                            primes.Clear();
                            return nuevo;
                        }
                        else if (root.ToString() == "DDL")
                        {
                            //System.Diagnostics.Debug.WriteLine("CAso5 ---------------------------> " + root.ChildNodes.ElementAt(0).ToString().ToUpper());
                            if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT") == true)
                            {
                                System.Diagnostics.Debug.WriteLine("CAso5 -> " + root.ToString());
                                NodoAbstracto nuevo = new SELECT_SIMPLE("SIMPLE");
                                NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                                // NodoAbstracto UNO = new Nodo(root.ChildNodes.ElementAt(1).ToString());
                                nuevo.Hijos.Add(Tabla);

                                STN.Clear();
                                Atributos(root.ChildNodes.ElementAt(1));
                                for (int i = 0; i < STN.Count; i++)
                                {
                                    nuevo.ListaID1.Add(STN[i]);
                                }
                                STN.Clear();
                                return nuevo;

                            }
                            else
                            {
                                NodoAbstracto nuevo = new UPDATE("ACTUALIZAR");
                                NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", ""));
                                nuevo.Hijos.Add(Tabla);
                                STN.Clear();
                                Parametros_Update(root.ChildNodes.ElementAt(3));
                                for (int i = 0; i < STN.Count; i++)
                                {
                                    nuevo.ListaID1.Add(STN[i]);
                                }
                                STN.Clear();
                                return nuevo;

                            }

                        }
                       
                        else
                        {
                            NodoAbstracto nuevo = new DeclararAsignacion("DECLARARASIGNAR");
                            NodoAbstracto nuevotipo = new Nodo(root.ChildNodes.ElementAt(0).ChildNodes.ElementAt(0).ToString().Replace("(Keyword)", ""));
                            NodoAbstracto nuevoid = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id2)", ""));
                            nuevo.Hijos.Add(nuevotipo);
                            nuevo.Hijos.Add(nuevoid);
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(3)));
                            return nuevo;
                        }

                    }
                    else if (root.ToString() == "PERMISOSUSUARIO")
                    {
                        NodoAbstracto nuevo = new PERMISOS("PERMISOS");
                        NodoAbstracto USUARIO = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", ""));
                        NodoAbstracto BD = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                        nuevo.Hijos.Add(USUARIO);
                        nuevo.Hijos.Add(BD);
                        if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("GRANT"))
                        {
                            nuevo.AutoIncrmentable2 = 1;
                        }
                        else
                        {
                            nuevo.AutoIncrmentable2 = 2;
                        }
                        return nuevo;

                    }
                    else if (root.ToString() == "DDL")
                    {
                        //System.Diagnostics.Debug.WriteLine("CAso5 ---------------------------> " + root.ChildNodes.ElementAt(0).ToString().ToUpper());
                        if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT") == true)
                        {
                            System.Diagnostics.Debug.WriteLine("CAso5 -> " + root.ToString());
                            NodoAbstracto nuevo = new SELECT_SIMPLE("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                            // NodoAbstracto UNO = new Nodo(root.ChildNodes.ElementAt(1).ToString());
                            nuevo.Hijos.Add(Tabla);

                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            return nuevo;

                        }
                        else
                        {
                            NodoAbstracto nuevo = new UPDATE("ACTUALIZAR");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Parametros_Update(root.ChildNodes.ElementAt(3));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            return nuevo;

                        }

                    }
                    else if (root.ToString() == "DDL2")
                    {
                        //System.Diagnostics.Debug.WriteLine("CAso5 ---------------------------> " + root.ChildNodes.ElementAt(0).ToString().ToUpper());
                        if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT") == true)
                        {
                            System.Diagnostics.Debug.WriteLine("CAso5 -> " + root.ToString());
                            NodoAbstracto nuevo = new CURSOR_SELECT("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                            // NodoAbstracto UNO = new Nodo(root.ChildNodes.ElementAt(1).ToString());
                            nuevo.Hijos.Add(Tabla);

                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            return nuevo;

                        }
                    }
                    else if (root.ToString().ToUpper().Contains("FUNCIONES_PROPIAS"))
                    {
                        NodoAbstracto nuevo = new FUNCIONESCOLEECTIONS("FUNCIONES");
                        NodoAbstracto nuevooperador = new Nodo(".");
                        NodoAbstracto tipoCasteo = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id2)", ""));
                        // NodoAbstracto nuevoid = new Nodo(root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (id)", ""));
                        NodoAbstracto nuevoid = Recorrido12(root.ChildNodes.ElementAt(2));
                        //System.Diagnostics.Debug.WriteLine("EXPRESION DE 4);" + root.ChildNodes.ElementAt(1).FindToken().ToString());
                        nuevo.Hijos.Add(tipoCasteo);
                        nuevo.Hijos.Add(nuevooperador);
                        nuevo.Hijos.Add(nuevoid);
                        nuevo.TipoDato = "funk";
                        return nuevo;
                    }

                    #endregion
                    break;
                case 6:
                    #region hijos6
                    if (root.ToString() == "DDL")
                    {

                        if (root.ChildNodes.ElementAt(3).FindToken().ToString().ToUpper().Contains("DROP") && root.ChildNodes.ElementAt(0).FindToken().ToString().ToUpper().Contains("ALTER"))
                        {
                            System.Diagnostics.Debug.WriteLine("CODIGO PARA ALTER TABLE DROP");
                            NodoAbstracto nuevo = new ALTER_TABLE_DROP("ELIMINAR");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            nuevo.AutoIncrmentable2 = 2;
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(4));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            return nuevo;
                        }
                        else if (root.ChildNodes.ElementAt(3).FindToken().ToString().ToUpper().Contains("ADD") && root.ChildNodes.ElementAt(0).FindToken().ToString().ToUpper().Contains("ALTER"))
                        {
                            System.Diagnostics.Debug.WriteLine("CODIGO PARA ALTER TABLE ADD");
                            NodoAbstracto nuevo = new ALTER_TABLE_ADD("INSERTAR");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            nuevo.AutoIncrmentable2 = 2;
                            STN.Clear();
                            ParametrosTabla(root.ChildNodes.ElementAt(4));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            return nuevo;

                        }


                    }


                    #endregion
                    break;
                case 7:
                    #region hijos7
                    System.Diagnostics.Debug.WriteLine("RECORRIDO12->7" + root.ToString());
                    if (root.ToString().Contains("CREATE_TYPE"))
                    {
                        ListaIDSObjetoXX(root.ChildNodes.ElementAt(4));

                        NodoAbstracto nuevo = new USER_TYPE("USER_TYPE");
                        NodoAbstracto nuevoid = new Nodo(root.ChildNodes.ElementAt(2).FindToken().ToString());
                        nuevo.Hijos.Add(nuevoid);
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaID1.Add(STN[i]);
                        }

                        //ListaIDSObjeto(root.ChildNodes.ElementAt(4));
                        STN.Clear();
                        return nuevo;
                    }
                    else if (root.ToString() == "DDL")
                    {
                        if (root.ChildNodes.ElementAt(1).ToString().ToUpper().Contains("DATABASE"))
                        {
                            NodoAbstracto nuevo = new BD("BD");
                            NodoAbstracto BDS = new Nodo(root.ChildNodes.ElementAt(5).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(BDS);
                            nuevo.AutoIncrmentable2 = 2;
                            return nuevo;
                        }
                        else if (root.ChildNodes.ElementAt(1).ToString().ToUpper().Contains("TABLE"))
                        {
                            NodoAbstracto nuevo = new Tabla("Tabla");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            ParametrosTabla(root.ChildNodes.ElementAt(4));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            return nuevo;
                        }
                        else if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("UPDATE"))
                        {
                            NodoAbstracto nuevo = new UPDATE_WHERE("ACTUALIZAR2");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Parametros_Update(root.ChildNodes.ElementAt(3));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(5)));
                            return nuevo;
                        }
                        else if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT") == true
                            && root.ChildNodes.ElementAt(4).ToString().ToUpper().Contains("LIMIT") == true)
                        {
                            //System.Diagnostics.Debug.WriteLine("CAso5 -> " + root.ToString());
                            NodoAbstracto nuevo = new SELECT_LIMIT("SLEEC-LIMIT");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(5)));
                            return nuevo;

                        }
                        else if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT") == true
                             && root.ChildNodes.ElementAt(4).ToString().ToUpper().Contains("WHERE") == true
                            )
                        {
                            //System.Diagnostics.Debug.WriteLine("CAso5 -> " + root.ToString());
                            NodoAbstracto nuevo = new SELECT_WHERE("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(5)));
                            return nuevo;

                        }

                    }
                    else if (root.ToString().ToUpper().Contains("CREARUSUARIO"))
                    {
                        NodoAbstracto nuevo = new USUARIOS("USUARIO");
                        NodoAbstracto elusuario = new Nodo(root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (id)", ""));
                        NodoAbstracto password = new Nodo(root.ChildNodes.ElementAt(5).FindToken().ToString().Replace(" (cadena)", ""));
                        nuevo.Hijos.Add(elusuario);
                        nuevo.Hijos.Add(password);
                        return nuevo;
                    }
                    else if(root.ToString() == "DDL2")
                    {
                        if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT") == true
                            && root.ChildNodes.ElementAt(4).ToString().ToUpper().Contains("LIMIT") == true)
                        {
                            //System.Diagnostics.Debug.WriteLine("CAso5 -> " + root.ToString());
                            NodoAbstracto nuevo = new CURSOR_SELECT_LIMIT("SLEEC-LIMIT");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(5)));
                            return nuevo;

                        }
                        else if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT") == true
                         && root.ChildNodes.ElementAt(4).ToString().ToUpper().Contains("WHERE") == true
                        )
                        {
                            //System.Diagnostics.Debug.WriteLine("CAso5 -> " + root.ToString());
                            NodoAbstracto nuevo = new CURSOR_SELECT_WHERE("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(5)));
                            return nuevo;

                        }
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
                    else if (root.ToString().Contains("EL_IF"))
                    {
                        NodoAbstracto nuevo = new ELIF("IF");
                        nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                        //nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(5)));
                        for (int x = 0; x < root.ChildNodes.ElementAt(5).ChildNodes.Count; x++)
                        {
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(5).ChildNodes.ElementAt(x)));
                        }
                        return nuevo;
                    }
                    else if (root.ToString().Contains("ELWHILE"))
                    {
                        NodoAbstracto nuevo = new While("WHILE");
                        nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                        //nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(5)));
                        for (int x = 0; x < root.ChildNodes.ElementAt(5).ChildNodes.Count; x++)
                        {
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(5).ChildNodes.ElementAt(x)));
                        }
                        return nuevo;
                        //return nuevo;
                    }
                    else if (root.ToString() == "FUNCIONES_CREADAS")
                    {

                        System.Diagnostics.Debug.WriteLine("FUNCIONES_cREADAS");
                        NodoAbstracto nuevo = new FUNCIONES("FUN_CREADAS");
                        NodoAbstracto tipofuncion = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (Keyword)", ""));
                        NodoAbstracto NombreFuncion = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", ""));
                        nuevo.Hijos.Add(tipofuncion);
                        nuevo.Hijos.Add(NombreFuncion);
                        //nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(5)));
                        NodoAbstracto Extra = new Nodo("EXTRA");
                        for (int x = 0; x < root.ChildNodes.ElementAt(5).ChildNodes.Count; x++)
                        {
                            Extra.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(5).ChildNodes.ElementAt(x)));
                        }
                        nuevo.Hijos.Add(Extra);
                        nuevo.AutoIncrmentable2 = 67;
                        FuncionesXD.Add(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", "") + "*" + root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", "") + "*" + 0);

                        return nuevo;

                    }
                    #endregion
                    break;
                case 8:
                    #region hijo8
                    if (root.ToString().ToUpper().Contains("USER_TYPE2"))
                    {
                        NodoAbstracto nuevo = new ASIGNACIONOBJETOS("INSTANCIA");
                        NodoAbstracto id = new Nodo(root.ChildNodes.ElementAt(6).ToString().Replace(" (id2)", ""));
                        NodoAbstracto id2 = new Nodo(root.ChildNodes.ElementAt(0).ToString().Replace(" (id)", ""));
                        NodoAbstracto id3 = new Nodo(root.ChildNodes.ElementAt(6).ToString().Replace(" (id2)", ""));
                        nuevo.Hijos.Add(id);
                        nuevo.Hijos.Add(id2);
                        nuevo.Hijos.Add(id3);
                        nuevo.AutoIncrmentable2 = 181890;

                        STN.Clear();
                        System.Diagnostics.Debug.WriteLine("__________________________________________________");



                        AtributosUT(root.ChildNodes.ElementAt(3));

                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaID1.Add(STN[i]);
                        }
                        STN.Clear();

                        System.Diagnostics.Debug.WriteLine("__________________________________________________");
                        return nuevo;
                    }
                    else if (root.ToString().ToUpper() == ("DDL"))
                    {
                        if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT"))
                        {
                            NodoAbstracto nuevo = new SELECT_ORDER_BY("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(6));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            return nuevo;
                        }
                        if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("INSERT"))
                        {
                            NodoAbstracto nuevo = new INSERSCION_SIMPLE("INSERTAR1");
                            NodoAbstracto id = new Nodo(root.ChildNodes.ElementAt(2).ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(id);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(5));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            return nuevo;
                        }


                    }
                    else if (root.ToString().ToUpper() == ("DDL2"))
                    {
                        if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT"))
                        {
                            NodoAbstracto nuevo = new CURSOR_SELECT_ORDER_BY("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(6));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            return nuevo;
                        }
                    }
                    else if (root.ToString().Contains("EL_IF"))
                    {
                        NodoAbstracto nuevo = new ELSEIF("IF");
                        NodoAbstracto IFSITO = new Nodo("XTRA");
                        NodoAbstracto Extras = new Nodo("XTRA");
                        nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                        //nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(5)));
                        for (int x = 0; x < root.ChildNodes.ElementAt(5).ChildNodes.Count; x++)
                        {
                            IFSITO.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(5).ChildNodes.ElementAt(x)));
                        }
                        nuevo.Hijos.Add(IFSITO);
                        nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(7)));
                        nuevo.AutoIncrmentable2 = 2;
                        return nuevo;
                    }
                    else if (root.ToString().Contains("SINO"))
                    {
                        NodoAbstracto nuevo = new SINO("SINO");
                        nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(3)));
                        NodoAbstracto IFSITO = new Nodo("XTRA");
                        //nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(6)));
                        for (int x = 0; x < root.ChildNodes.ElementAt(6).ChildNodes.Count; x++)
                        {
                            IFSITO.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(6).ChildNodes.ElementAt(x)));
                        }
                        nuevo.Hijos.Add(IFSITO);
                        nuevo.AutoIncrmentable2 = 1;
                        return nuevo;
                    }
                    else if (root.ToString() == "FUNCIONES_CREADAS")
                    {

                        System.Diagnostics.Debug.WriteLine("FUNCIONES_cREADAS");
                        NodoAbstracto nuevo = new FUNCIONES("FUN_CREADAS");
                        NodoAbstracto tipofuncion = new Nodo(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (Keyword)", ""));
                        NodoAbstracto NombreFuncion = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", ""));
                        NodoAbstracto Extra= new Nodo("EXTRA");
                        // NodoAbstracto ListaDeSentenias = new Nodo(root.ChildNodes.ElementAt(6));
                        nuevo.Hijos.Add(tipofuncion);
                        nuevo.Hijos.Add(NombreFuncion);
                        for (int x = 0; x < root.ChildNodes.ElementAt(6).ChildNodes.Count; x++) {
                            Extra.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(6).ChildNodes.ElementAt(x)));
                        }
                        nuevo.Hijos.Add(Extra);
                        AtributosFunciones(root.ChildNodes.ElementAt(3));
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaID1.Add(STN[i]);
                        }

                        nuevo.AutoIncrmentable2 = 68;
                        FuncionesXD.Add(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", "") + "*" + root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", "") + "*" + STN.Count);
                        STN.Clear();
                        return nuevo;

                    }
                    else if (root.ToString().Contains("ELCALL"))
                    {
                        NodoAbstracto nuevo = new CALL("EXP");
                        NodoAbstracto proc = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                        STN.Clear();
                        Atributos(root.ChildNodes.ElementAt(0));
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaID1.Add(STN[i].Replace(" (id2)", ""));
                        }
                        STN.Clear();

                        STN.Clear();
                        nuevo.ListaR1 = new List<String>();
                        Atributos(root.ChildNodes.ElementAt(5));
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaR1.Add(STN[i].Replace(" (id2)", ""));
                        }
                        STN.Clear();


                        nuevo.Hijos.Add(proc);
                        return nuevo;

                    }

                    #endregion
                    break;
                case 9:
                    #region hijos9
                    if (root.ToString().ToUpper().Contains("USER_TYPE2"))
                    {
                        NodoAbstracto nuevo = new ASIGNACIONOBJETOS("INSTANCIA");
                        NodoAbstracto id = new Nodo(root.ChildNodes.ElementAt(0).ToString().Replace(" (id2)", ""));
                        NodoAbstracto id2 = new Nodo(root.ChildNodes.ElementAt(1).ToString().Replace(" (id2)", ""));
                        NodoAbstracto id3 = new Nodo(root.ChildNodes.ElementAt(7).ToString().Replace(" (id)", ""));
                        nuevo.Hijos.Add(id);
                        nuevo.Hijos.Add(id2);
                        nuevo.Hijos.Add(id3);
                        nuevo.AutoIncrmentable2 = 9999;

                        STN.Clear();
                        System.Diagnostics.Debug.WriteLine("______x____________________________________________");


                        System.Diagnostics.Debug.WriteLine("sdaf");
                        AtributosUT(root.ChildNodes.ElementAt(4));
                        System.Diagnostics.Debug.WriteLine("sdaf");
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaID1.Add(STN[i]);
                        }
                        STN.Clear();
                        System.Diagnostics.Debug.WriteLine("_______f___________________________________________");
                        return nuevo;
                    }
                    else if (root.ToString() == "DDL")
                    {
                        if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT") == true)
                        {
                            //System.Diagnostics.Debug.WriteLine("CAso5 -> " + root.ToString());
                            NodoAbstracto nuevo = new SELECT_WHERE_LIMITE("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(5)));
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(7)));
                            return nuevo;

                        }
                    }
                    else if (root.ToString() == "E")
                    {
                        System.Diagnostics.Debug.WriteLine("CAso9SDSSSS -> " + root.ToString());
                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("COUNT")))
                        {
                            NodoAbstracto nuevo = new COUNT_SELECT("EXP");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(4));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("MIN")))
                        {
                            NodoAbstracto nuevo = new MIN_SELECT("EXP");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            nuevo.ListaR1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", "") + ",ASC");
                            STN.Clear();
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("MAX")))
                        {
                            NodoAbstracto nuevo = new MIN_SELECT("EXP");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            nuevo.ListaR1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", "") + ",ASC");
                            STN.Clear();
                            nuevo.TipoDato = "entero";
                            nuevo.AutoIncrmentable2 = 2;
                            return nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SUM")))
                        {
                            NodoAbstracto nuevo = new MIN_SELECT("EXP");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            nuevo.ListaR1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", "") + ",ASC");
                            STN.Clear();
                            nuevo.TipoDato = "entero";
                            nuevo.AutoIncrmentable2 = 3;
                            return nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("AVG")))
                        {
                            NodoAbstracto nuevo = new MIN_SELECT("EXP");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            nuevo.ListaR1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", "") + ",ASC");
                            STN.Clear();
                            nuevo.TipoDato = "entero";
                            nuevo.AutoIncrmentable2 = 4;
                            return nuevo;
                        }

                    }
                    else if (root.ToString() == "DDL2")
                    {
                        if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT") == true)
                        {
                            //System.Diagnostics.Debug.WriteLine("CAso5 -> " + root.ToString());
                            NodoAbstracto nuevo = new CURSOR_SELECT_WHERE_LIMIT("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(5)));
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(7)));
                            return nuevo;

                        }
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
                    else if (root.ToString().Contains("DO_WHILE"))
                    {
                        NodoAbstracto nuevo = new DOWHILE("DOWHILE");
                        nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(6)));
                        for (int x = 0; x < root.ChildNodes.ElementAt(2).ChildNodes.Count; x++)
                        {
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2).ChildNodes.ElementAt(x)));
                        }
                        return nuevo;
                    }
                    else if (root.ToString().Contains("SINO"))
                    {
                        NodoAbstracto nuevo = new SINO("SINO");
                        nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(3)));
                        NodoAbstracto IFSITO = new Nodo("XTRA");
                        //nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(6)));
                        for (int x = 0; x < root.ChildNodes.ElementAt(6).ChildNodes.Count; x++)
                        {
                            IFSITO.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(6).ChildNodes.ElementAt(x)));
                        }
                        nuevo.Hijos.Add(IFSITO);
                        nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                        nuevo.AutoIncrmentable2 = 2;
                        return nuevo;
                    }
                    #endregion
                    break;
                case 10:
                    #region hijo10
                    if (root.ToString().Contains("CREATE_TYPE"))
                    {
                        ListaIDSObjetoXX(root.ChildNodes.ElementAt(7));
                        
                        NodoAbstracto nuevo = new USER_TYPE("USER_TYPE");
                        NodoAbstracto nuevoid = new Nodo(root.ChildNodes.ElementAt(5).FindToken().ToString());
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
                    else if (root.ToString() == "DDL")
                    {

                        if (root.ChildNodes.ElementAt(1).ToString().ToUpper().Contains("TABLE"))
                        {
                            NodoAbstracto nuevo = new Tabla("Tabla");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(5).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            nuevo.AutoIncrmentable2 = 2;
                            STN.Clear();
                            ParametrosTabla(root.ChildNodes.ElementAt(7));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            return nuevo;
                        }
                        else if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT") == true &&
                            root.ChildNodes.ElementAt(6).ToString().ToUpper().Contains("ORDER"))
                        {
                            //System.Diagnostics.Debug.WriteLine("CAso5 -> " + root.ToString());
                            NodoAbstracto nuevo = new SELECT_WHERE_ORDER_BY("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(6));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(5)));
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(8));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(9)));
                            return nuevo;

                        }
                        else if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT"))
                        {
                            NodoAbstracto nuevo = new SELECT_ORDER_BY_LIMIT("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(6));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            return nuevo;
                        }

                    }
                    else if(root.ToString() == "DDL2")
                    {
                        if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT") == true &&
                            root.ChildNodes.ElementAt(6).ToString().ToUpper().Contains("ORDER"))
                        {
                            //System.Diagnostics.Debug.WriteLine("CAso5 -> " + root.ToString());
                            NodoAbstracto nuevo = new CURSOR_SELECT_WHERE_ORDER_BY("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(6));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(5)));
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(8));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(9)));
                            return nuevo;

                        }
                        else if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT"))
                        {
                            NodoAbstracto nuevo = new CURSOR_SELECT_ORDER_BY_LIMIT("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(6));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            return nuevo;
                        }
                    }
                    else if(root.ToString() == "LLAMADA_A_CURSOR")
                    {
                        NodoAbstracto nuevo = new LLAMADA_CURSOR("LLAMADA");
                        NodoAbstracto cursor = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString());
                        STN.Clear();
                        AtributosFunciones(root.ChildNodes.ElementAt(3));
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaID1.Add(STN[i]);
                        }
                        STN.Clear();
                        nuevo.Hijos.Add(cursor);
                        
                        for(int x = 0; x< root.ChildNodes.ElementAt(8).ChildNodes.Count; x++)
                        {
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8).ChildNodes.ElementAt(x)));
                        }
                        return nuevo;

                    }
                    else if (root.ToString().Contains("EL_FOR"))
                    {
                        NodoAbstracto nuevo = new ELFOR("FOR");

                        nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                        nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(3)));
                        nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(5)));
                        for (int x = 0; x < root.ChildNodes.ElementAt(8).ChildNodes.Count; x++)
                        {
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8).ChildNodes.ElementAt(x)));
                        }
                        return nuevo;
                    }


                    #endregion
                    break;
                case 11:
                    #region hijos11
                    if (root.ToString() == "DDL")
                    {

                        System.Diagnostics.Debug.WriteLine("CODIGO PARA insertadardatos TABLE DROP");
                        NodoAbstracto nuevo = new INSERCION_ESPECIAL("INSERTAR");
                        NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (id)", ""));
                        nuevo.Hijos.Add(Tabla);
                        STN.Clear();
                        Atributos(root.ChildNodes.ElementAt(4));
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaID1.Add(STN[i]);
                        }
                        STN.Clear();

                        nuevo.Hijos.Add(Tabla);
                        nuevo.AutoIncrmentable2 = 2;
                        STN.Clear();
                        nuevo.ListaR1 = new List<String>();
                        Atributos(root.ChildNodes.ElementAt(8));
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaR1.Add(STN[i]);
                        }
                        STN.Clear();
                        return nuevo;



                    }
                    else if (root.ToString() == "E")
                    {

                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("COUNT"))
                            && ((root.ChildNodes.ElementAt(7).ToString().ToUpper().Contains("LIMIT"))))
                        {
                            NodoAbstracto nuevo = new COUNT_SELECT_LIMIT("EXP");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(4));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("COUNT"))
                           && ((root.ChildNodes.ElementAt(7).ToString().ToUpper().Contains("WHERE"))))
                        {
                            NodoAbstracto nuevo = new COUNT_SELECT_WHERE("EXP");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(4));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("MIN"))
                           && ((root.ChildNodes.ElementAt(7).ToString().ToUpper().Contains("LIMIT"))))
                        {
                            NodoAbstracto nuevo = new MIN_SELECT_LIMIT("EXP");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);

                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));

                            nuevo.ListaR1 = new List<String>();
                            nuevo.ListaR1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", "") + ",ASC");

                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("MAX"))
                            && ((root.ChildNodes.ElementAt(7).ToString().ToUpper().Contains("LIMIT"))))
                        {
                            NodoAbstracto nuevo = new MIN_SELECT_LIMIT("EXP");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);

                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));

                            nuevo.ListaR1 = new List<String>();
                            nuevo.ListaR1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", "") + ",ASC");

                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            nuevo.AutoIncrmentable2 = 2;
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }

                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("MIN"))
                           && ((root.ChildNodes.ElementAt(7).ToString().ToUpper().Contains("WHERE"))))
                        {
                            NodoAbstracto nuevo = new MIN_SELECT_WHERE("EXP");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);

                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));

                            nuevo.ListaR1 = new List<String>();
                            nuevo.ListaR1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", "") + ",ASC");

                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            //nuevo.AutoIncrmentable2 = 2;
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }

                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("MAX"))
                           && ((root.ChildNodes.ElementAt(7).ToString().ToUpper().Contains("WHERE"))))
                        {
                            NodoAbstracto nuevo = new MIN_SELECT_WHERE("EXP");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);

                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));

                            nuevo.ListaR1 = new List<String>();
                            nuevo.ListaR1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", "") + ",ASC");

                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            nuevo.AutoIncrmentable2 = 2;
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }

                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SUM"))
                           && ((root.ChildNodes.ElementAt(7).ToString().ToUpper().Contains("LIMIT"))))
                        {
                            NodoAbstracto nuevo = new MIN_SELECT_LIMIT("EXP");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);

                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));

                            nuevo.ListaR1 = new List<String>();
                            nuevo.ListaR1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", "") + ",ASC");

                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            nuevo.AutoIncrmentable2 = 3;
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("AVG"))
                        && ((root.ChildNodes.ElementAt(7).ToString().ToUpper().Contains("LIMIT"))))
                        {
                            NodoAbstracto nuevo = new MIN_SELECT_LIMIT("EXP");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);

                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));

                            nuevo.ListaR1 = new List<String>();
                            nuevo.ListaR1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", "") + ",ASC");

                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            nuevo.AutoIncrmentable2 = 4;
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }

                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SUM"))
                          && ((root.ChildNodes.ElementAt(7).ToString().ToUpper().Contains("WHERE"))))
                        {
                            NodoAbstracto nuevo = new MIN_SELECT_WHERE("EXP");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);

                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));

                            nuevo.ListaR1 = new List<String>();
                            nuevo.ListaR1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", "") + ",ASC");

                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            nuevo.AutoIncrmentable2 = 3;
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("AVG"))
                       && ((root.ChildNodes.ElementAt(7).ToString().ToUpper().Contains("WHERE"))))
                        {
                            NodoAbstracto nuevo = new MIN_SELECT_WHERE("EXP");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);

                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));

                            nuevo.ListaR1 = new List<String>();
                            nuevo.ListaR1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", "") + ",ASC");

                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            nuevo.AutoIncrmentable2 = 4;
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }

                    }
                    else if (root.ToString().Contains("EL_IF"))
                    {
                        System.Diagnostics.Debug.WriteLine("------------------------------------------romeo entro al el if 11");
                        NodoAbstracto nuevo = new ELSEIF("ELSEIF");
                        NodoAbstracto IFSITO = new Nodo("XTRA");
                        NodoAbstracto Extras = new Nodo("XTRA");
                        nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(2)));
                        //nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(5)));
                        for (int x = 0; x < root.ChildNodes.ElementAt(5).ChildNodes.Count; x++)
                        {
                            IFSITO.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(5).ChildNodes.ElementAt(x)));
                        }
                        nuevo.Hijos.Add(IFSITO);
                        //nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(9)));
                        for (int x = 0; x < root.ChildNodes.ElementAt(9).ChildNodes.Count; x++)
                        {
                            Extras.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(9).ChildNodes.ElementAt(x)));
                        }
                        nuevo.Hijos.Add(Extras);
                        nuevo.AutoIncrmentable2 = 1;
                        return nuevo;
                    }

                    #endregion
                    break;
                case 12:
                    #region hijos12
                    if(root.ToString() == "DDL2")
                    {
                        if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT") == true &&
                                              root.ChildNodes.ElementAt(6).ToString().ToUpper().Contains("ORDER"))
                        {
                            //System.Diagnostics.Debug.WriteLine("CAso5 -> " + root.ToString());
                            NodoAbstracto nuevo = new CURSOR_SELECT_WHERE_ORDER_BY_LIMIT("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(1));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(6));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(5)));
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(8));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(10)));
                            return nuevo;

                        }
                    }
                    else if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SELECT") == true &&
                       root.ChildNodes.ElementAt(6).ToString().ToUpper().Contains("ORDER"))
                    {
                        //System.Diagnostics.Debug.WriteLine("CAso5 -> " + root.ToString());
                        NodoAbstracto nuevo = new SELECT_WHERE_ORDER_BY_LIMIT("SIMPLE");
                        NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", ""));
                        nuevo.Hijos.Add(Tabla);
                        STN.Clear();
                        Atributos(root.ChildNodes.ElementAt(1));
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaID1.Add(STN[i]);
                        }
                        STN.Clear();
                        nuevo.ListaR1 = new List<String>();
                        Parametros_Order_By(root.ChildNodes.ElementAt(6));
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaR1.Add(STN[i]);
                        }
                        STN.Clear();
                        nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(5)));
                        nuevo.ListaR1 = new List<String>();
                        Parametros_Order_By(root.ChildNodes.ElementAt(8));
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaR1.Add(STN[i]);
                        }
                        STN.Clear();
                        nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(10)));
                        return nuevo;

                    }
                    else if (root.ToString() == "E")
                    {

                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("COUNT"))
                            )
                        {
                            NodoAbstracto nuevo = new MIN_SELECT_ORDER_BY("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(4));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(9));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("MIN"))
                        )
                        {
                            NodoAbstracto nuevo = new MIN_SELECT_ORDER_BY("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));

                            nuevo.ListaR1 = new List<String>();
                            nuevo.ListaR1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", "") + ",ASC");
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("MAX"))
                        )
                        {
                            NodoAbstracto nuevo = new MIN_SELECT_ORDER_BY("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));

                            nuevo.ListaR1 = new List<String>();
                            nuevo.ListaR1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", "") + ",ASC");
                            nuevo.TipoDato = "entero";
                            nuevo.AutoIncrmentable2 = 2;
                            return nuevo;
                        }
                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SUM"))
                   )
                        {
                            NodoAbstracto nuevo = new MIN_SELECT_ORDER_BY("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));

                            nuevo.ListaR1 = new List<String>();
                            nuevo.ListaR1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", "") + ",ASC");
                            nuevo.TipoDato = "entero";
                            nuevo.AutoIncrmentable2 = 3;
                            return nuevo;
                        }
                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("AVG"))
                   )
                        {
                            NodoAbstracto nuevo = new MIN_SELECT_ORDER_BY("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));

                            nuevo.ListaR1 = new List<String>();
                            nuevo.ListaR1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", "") + ",ASC");
                            nuevo.TipoDato = "entero";
                            nuevo.AutoIncrmentable2 = 4;
                            return nuevo;
                        }
                    }
                    else if (root.ToString().Contains("SINO"))
                    {
                        NodoAbstracto nuevo = new SINO("SINO");
                        nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(3)));
                        NodoAbstracto IFSITO = new Nodo("XTRA");
                        NodoAbstracto ELIFSITO = new Nodo("XTRA");
                        //nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(6)));
                        for (int x = 0; x < root.ChildNodes.ElementAt(6).ChildNodes.Count; x++)
                        {
                            IFSITO.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(6).ChildNodes.ElementAt(x)));
                        }
                        nuevo.Hijos.Add(IFSITO);
                        // nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(10)));
                        for (int x = 0; x < root.ChildNodes.ElementAt(10).ChildNodes.Count; x++)
                        {
                            ELIFSITO.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(10).ChildNodes.ElementAt(x)));
                        }
                        nuevo.Hijos.Add(ELIFSITO);
                        nuevo.AutoIncrmentable2 = 3;
                        return nuevo;
                    }
                    else if (root.ToString().Contains("PROCEDIMIENTOS"))
                    {
                        NodoAbstracto nuevo = new PROCEDIMIENTOS("PROC");
                        NodoAbstracto Nombre = new Nodo(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", ""));
                        nuevo.Hijos.Add(Nombre);
                        NodoAbstracto Extra = new Nodo("EXTRA");
                        for(int i = 0; i< root.ChildNodes.ElementAt(10).ChildNodes.Count; i++)
                        {
                            Extra.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(10).ChildNodes.ElementAt(i)));
                        }
                        nuevo.Hijos.Add(Extra);
                        //nuevo.ListaID1 = new List<String>();
                        nuevo.ListaR1 = new List<String>();
                        STN.Clear();
                        AtributosFunciones(root.ChildNodes.ElementAt(7));
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaR1.Add(STN[i]);
                        }
                        STN.Clear();

                        STN.Clear();
                        AtributosFunciones(root.ChildNodes.ElementAt(3));
                        for (int i = 0; i < STN.Count; i++)
                        {
                            nuevo.ListaID1.Add(STN[i]);
                        }
                        STN.Clear();



                        //nuevo.ListaR1 = new List<String>();
                        nuevo.AutoIncrmentable2 = 9000;
                        return nuevo;

                    }
                    #endregion
                    break;
                case 13:                    
                    #region hijos13
                    if (root.ToString() == "E")
                    {

                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("COUNT"))
                            )
                        {
                            NodoAbstracto nuevo = new COUNT_SELECT_WHERE_LIMIT("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(4));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(10)));
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("MIN"))
                           )
                        {
                            NodoAbstracto nuevo = new MIN_SELEC_WHERE_LIMIT("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(10)));
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("MAX"))
                        )
                        {
                            NodoAbstracto nuevo = new MIN_SELEC_WHERE_LIMIT("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(10)));
                            nuevo.AutoIncrmentable2 = 2;
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }

                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SUM"))
                       )
                        {
                            NodoAbstracto nuevo = new MIN_SELEC_WHERE_LIMIT("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(10)));
                            nuevo.AutoIncrmentable2 = 3;
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }

                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("AVG"))
                       )
                        {
                            NodoAbstracto nuevo = new MIN_SELEC_WHERE_LIMIT("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(10)));
                            nuevo.AutoIncrmentable2 = 4;
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                    }
                    #endregion
                    break;
                case 14:
                    #region hijos14
                    if (root.ToString() == "E")
                    {

                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SUM"))
                           && (root.ChildNodes.ElementAt(9).ToString().ToUpper().Contains("ORDER"))
                          )
                        {
                            NodoAbstracto nuevo = new COUNT_SELECT_WHERE_ORDER_BY("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            STN.Clear();
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(9));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(11));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(12)));
                            nuevo.TipoDato = "entero";
                            nuevo.AutoIncrmentable2 = 3;
                            return nuevo;
                        }

                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("AVG"))
                           && (root.ChildNodes.ElementAt(9).ToString().ToUpper().Contains("ORDER"))
                          )
                        {
                            NodoAbstracto nuevo = new COUNT_SELECT_WHERE_ORDER_BY("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(9));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(11));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(12)));
                            nuevo.TipoDato = "entero";
                            nuevo.AutoIncrmentable2 = 4;
                            return nuevo;
                        }

                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("COUNT"))
                            && (root.ChildNodes.ElementAt(9).ToString().ToUpper().Contains("ORDER"))
                           )
                        {
                            NodoAbstracto nuevo = new COUNT_SELECT_WHERE_ORDER_BY("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(4));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(9));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(11));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(12)));
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("COUNT"))
                            )
                        {
                            NodoAbstracto nuevo = new COUNT_SELECT_ORDER_BY_LIMIT("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(4));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(9));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(11)));
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }

                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("MIN"))
                          && (root.ChildNodes.ElementAt(9).ToString().ToUpper().Contains("ORDER"))
                         )
                        {
                            NodoAbstracto nuevo = new COUNT_SELECT_WHERE_ORDER_BY("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(9));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(11));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(12)));
                            nuevo.TipoDato = "entero";
                            nuevo.AutoIncrmentable2 = 1;
                            return nuevo;
                        }

                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("MAX"))
                          && (root.ChildNodes.ElementAt(9).ToString().ToUpper().Contains("ORDER"))
                         )
                        {
                            NodoAbstracto nuevo = new COUNT_SELECT_WHERE_ORDER_BY("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(4));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaID1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(11));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(12)));
                            nuevo.TipoDato = "entero";
                            nuevo.AutoIncrmentable2 = 2;
                            return nuevo;
                        }

                        else if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("MIN"))
                       )
                        {
                            NodoAbstracto nuevo = new MIN_SELECT_ORDER_BY_LIMIT("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            Atributos(root.ChildNodes.ElementAt(4));
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));
                            nuevo.ListaR1 = new List<String>();
                            nuevo.ListaR1.Add(root.ChildNodes.ElementAt(9).FindToken().ToString().Replace(" (id)", "") + ",ASC");
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(11)));
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("MAX"))
                       )
                        {
                            NodoAbstracto nuevo = new MIN_SELECT_ORDER_BY_LIMIT("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));
                            nuevo.ListaR1 = new List<String>();
                            nuevo.ListaR1.Add(root.ChildNodes.ElementAt(9).FindToken().ToString().Replace(" (id)", "") + ",ASC");
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(11)));
                            nuevo.AutoIncrmentable2 = 2;
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }

                        else if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SUM"))
                      )
                        {
                            NodoAbstracto nuevo = new MIN_SELECT_ORDER_BY_LIMIT("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));
                            nuevo.ListaR1 = new List<String>();
                            nuevo.ListaR1.Add(root.ChildNodes.ElementAt(9).FindToken().ToString().Replace(" (id)", "") + ",ASC");
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(11)));
                            nuevo.AutoIncrmentable2 = 3;
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                        else if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("AVG"))
                      )
                        {
                            NodoAbstracto nuevo = new MIN_SELECT_ORDER_BY_LIMIT("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));
                            nuevo.ListaR1 = new List<String>();
                            nuevo.ListaR1.Add(root.ChildNodes.ElementAt(9).FindToken().ToString().Replace(" (id)", "") + ",ASC");
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(11)));
                            nuevo.AutoIncrmentable2 = 4;
                            nuevo.TipoDato = "entero";
                            return nuevo;
                        }
                    }
                    #endregion
                    break;

                case 16:
                    #region hijos16
                    if (root.ToString() == "E")
                    {

                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("COUNT")))
                        {
                            
                                NodoAbstracto nuevo = new COUNT_SELECT_WHERE_ORDER_BY_LIMIT("SIMPLE");
                                NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                                nuevo.Hijos.Add(Tabla);
                                STN.Clear();
                                Atributos(root.ChildNodes.ElementAt(4));
                                for (int i = 0; i < STN.Count; i++)
                                {
                                    nuevo.ListaID1.Add(STN[i]);
                                }
                                STN.Clear();
                                nuevo.ListaR1 = new List<String>();
                                Parametros_Order_By(root.ChildNodes.ElementAt(9));
                                for (int i = 0; i < STN.Count; i++)
                                {
                                    nuevo.ListaR1.Add(STN[i]);
                                }
                                STN.Clear();
                                nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                                nuevo.ListaR1 = new List<String>();
                                Parametros_Order_By(root.ChildNodes.ElementAt(11));
                                for (int i = 0; i < STN.Count; i++)
                                {
                                    nuevo.ListaR1.Add(STN[i]);
                                }
                                STN.Clear();
                                nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(13)));
                                nuevo.TipoDato = "entero";
                                return nuevo;
                            
                        }

                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("MIN")))
                        {

                            NodoAbstracto nuevo = new COUNT_SELECT_WHERE_ORDER_BY_LIMIT("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            STN.Clear();
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(9));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(11));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(13)));
                            nuevo.TipoDato = "entero";
                            nuevo.AutoIncrmentable2 = 1;
                            return nuevo;

                        }
                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("MAX")))
                        {

                            NodoAbstracto nuevo = new COUNT_SELECT_WHERE_ORDER_BY_LIMIT("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            STN.Clear();
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(9));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(11));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(13)));
                            nuevo.TipoDato = "entero";
                            nuevo.AutoIncrmentable2 = 2;
                            return nuevo;

                        }
                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("SUM")))
                        {

                            NodoAbstracto nuevo = new COUNT_SELECT_WHERE_ORDER_BY_LIMIT("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            STN.Clear();
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(9));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(11));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(13)));
                            nuevo.TipoDato = "entero";
                            nuevo.AutoIncrmentable2 = 3;
                            return nuevo;

                        }
                        if ((root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("AVG")))
                        {

                            NodoAbstracto nuevo = new COUNT_SELECT_WHERE_ORDER_BY_LIMIT("SIMPLE");
                            NodoAbstracto Tabla = new Nodo(root.ChildNodes.ElementAt(6).FindToken().ToString().Replace(" (id)", ""));
                            nuevo.Hijos.Add(Tabla);
                            STN.Clear();
                            STN.Clear();
                            nuevo.ListaID1.Add(root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", ""));
                            STN.Clear();
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(9));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(8)));
                            nuevo.ListaR1 = new List<String>();
                            Parametros_Order_By(root.ChildNodes.ElementAt(11));
                            for (int i = 0; i < STN.Count; i++)
                            {
                                nuevo.ListaR1.Add(STN[i]);
                            }
                            STN.Clear();
                            nuevo.Hijos.Add(Recorrido12(root.ChildNodes.ElementAt(13)));
                            nuevo.TipoDato = "entero";
                            nuevo.AutoIncrmentable2 = 4;
                            return nuevo;

                        }
                    }

                    #endregion
                    break;

            }
            return null;
        }
       

        public void Ejecutar(NodoAbstracto raiz)
        {
            String rutaCompleta = @"C:\Users\Bayyron\Desktop\Salida.txt";
            //System.Diagnostics.Debug.WriteLine("ejecutar");
            Entorno entorno = new Entorno();
            Boolean elbreak = false;
            foreach (NodoAbstracto sentencia in raiz.Hijos[0].Hijos)
            {// para ejecutar solo sentencias 
             //Console.WriteLine("pureba for " + sentencia.Nombre + raiz.TipoDato);
             //System.Diagnostics.Debug.WriteLine("CA:"+sentencia.Hijos[0].Ejecutar(entorno).ToString());
                String valor1 = sentencia.Ejecutar(entorno);
               // System.Diagnostics.Debug.WriteLine("--------------" + valor1 + "-----------");
                if (valor1.ToUpper().Contains("#ERROR") == true )
                {
                    //System.Diagnostics.Debug.WriteLine("ERROR SEMANTICO");
                    System.Diagnostics.Debug.WriteLine("--------------" + valor1 + "-----------");
                    if(valor1 == "#Error")
                    {
                        using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
                        {
                            mylogs.WriteLine(">>" + "ArithmeticExceptionexpresión: que viola las reglas definidas sobre las operaciones aritméticas. ");
                            mylogs.Close();
                        }
                    }
                    else if (valor1.Contains("#Error2"))
                    {
                        using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
                        {
                            mylogs.WriteLine(">>" + valor1.Replace("RETORNO:0,","").Replace(",int?","").Replace("#Error2","").Replace("int? ",""));
                            mylogs.Close();
                        }
                        break;
                    }
                    else if (valor1.Contains("#ERROR6 ? Exception:"))
                    {
                        using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
                        {
                            mylogs.WriteLine(">>" + valor1.Replace("#ERROR6 ? ",""));
                            mylogs.Close();
                        }
                    }
                    else if (valor1.Contains("#Error2 al momento de asignar valor a"))
                    {
                        using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
                        {
                            mylogs.WriteLine(">>" + "#ERROR" + valor1.Replace("#Erro2", ""));
                            mylogs.Close();
                        }
                        break;
                    }
                    else if (valor1.ToUpper().Contains("#ERROR3"))
                    {
                        using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
                        {
                            mylogs.WriteLine(">>" + valor1.Replace("#Error3", ""));
                            mylogs.Close();
                        }
                        break;
                    }
                    else if (valor1.ToUpper().Contains("#ERROR4"))
                    {
                        using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
                        {
                            mylogs.WriteLine(">>" + valor1.Replace("#ERROR4", ""));
                            mylogs.Close();
                        }
                        break;
                    }
                    else if (valor1.Contains("#ERRORfc"))
                    {
                        using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
                        {
                            mylogs.WriteLine(">>" + valor1.Replace("#ERRORfc", "ERROR"));
                            mylogs.Close();
                        }
                        break;
                    }
                    else if (valor1.Contains("#ERROR-BRAY"))
                    {
                        using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
                        {
                            mylogs.WriteLine(">>" + "ERROR EN EL SISTEMA COMANDO MAL INGRESADO");
                            mylogs.Close();
                        }
                        break;
                    }
                    else if (valor1.Contains("#ERROR101"))
                    {
                        using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
                        {
                            mylogs.WriteLine(">>" + "ERROR EN EL LLAMADO DE FUNCIONES");
                            mylogs.Close();
                        }
                        break;
                    }
                    else if (valor1.Contains("#ERROR102"))
                    {
                        using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
                        {
                            mylogs.WriteLine(">>" + "ERROR EL LLAMADO DE FUNCIONES, NO EXISTE");
                            mylogs.Close();
                        }
                        break;
                    }
                    else if (valor1.Contains("#ERROR103"))
                    {
                        using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
                        {
                            mylogs.WriteLine(">>" + "LA FUNCION NO EXISTE NO EXISTE");
                            mylogs.Close();
                        }
                        break;
                    }
                    else if (valor1.Contains("FunctionAlreadyExists:"))
                    {
                        using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
                        {
                            mylogs.WriteLine(">>" + valor1.Replace("#ERROR",""));
                            mylogs.Close();
                        }
                        //break;
                    }
                    else if (valor1.Contains("PROC123"))
                    {
                        using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
                        {
                            mylogs.WriteLine(">>" + valor1.Replace("#ERROR", "").Replace(" EN PROC123 ",""));
                            mylogs.Close();
                        }
                        break;
                    }
                    //elbreak = true;
                    // break;
                    //return "#Error";
                }
                if (valor1.Contains("BREAK") == true)
                {
                    elbreak = true;
                }
                if (valor1.Contains("RETORNO:") == true)
                {
                    System.Diagnostics.Debug.WriteLine("ERROR SEMANTICO");
                    break;
                }
                if (elbreak)
                {
                    System.Diagnostics.Debug.WriteLine("ERROR acá no puede usar el break");
                    using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
                    {
                        mylogs.WriteLine(">>" + "ERROR USO INCORRECTO DEL BREAK");
                        mylogs.Close();
                    }
                    break;
                }
                    


            }
        }
        #region PARAMETROS TABLA
        public void ParametrosTabla(ParseTreeNode root)
        {
            switch (root.ChildNodes.Count)
            {
                case 2:
                    String Parametro2 = root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", "");
                    String Tipo2 = root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", "");
                    System.Diagnostics.Debug.WriteLine("dos hijo Par->" + Parametro2 + " Tipo->" + Tipo2);
                    STN.Add(Parametro2 + "*" + Tipo2);
                    break;
                case 4:                    
                    String Parametro4 = root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)","");
                    String Tipo4 = root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)","");
                    System.Diagnostics.Debug.WriteLine("cuatro hijo Par->" +Parametro4 + " Tipo->" + Tipo4);
                    if (root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (Keyword)", "").ToUpper() == "PRIMARY")
                    {
                        STN.Add(Parametro4 + "*" + Tipo4 + "*" + "*PRIMARY*KEY*");
                        //ParametrosTabla(root.ChildNodes.ElementAt(6));
                    }
                    else
                    {
                        STN.Add(Parametro4 + "*" + Tipo4);
                        ParametrosTabla(root.ChildNodes.ElementAt(3));
                    }
                    break;
                case 6:
                    String Parametro6 = root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", "");
                    String Tipo6 = root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", "");
                    System.Diagnostics.Debug.WriteLine("Sies hijo Par->" + Parametro6 + " Tipo->" + Tipo6 + "*PRIMARY*KEY");
                    STN.Add(Parametro6 + "*" + Tipo6+"*PRIMARY*KEY*");
                    ParametrosTabla(root.ChildNodes.ElementAt(5));
                    break;
                case 5:
                    String Parametro5 = root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", "");
                    String Tipo5 = root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", "");
                    Cadena = "";
                    Lista1(root.ChildNodes.ElementAt(3));
                    System.Diagnostics.Debug.WriteLine("Cinco Hijos->Primary"   + "*key"   + " Lista->" +Cadena);
                    STN.Add("PRIMARY*KEY*"+Cadena);
                    break;
                case 7:
                    String Parametro7 = root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", "");
                    String Tipo7 = root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", "");
                    String TipoC = root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", "");
                    System.Diagnostics.Debug.WriteLine("sIETE Hijos->" + Parametro7 + "cOLEE->" + Tipo7);
                    if (root.ChildNodes.ElementAt(5).FindToken().ToString().Replace(" (Keyword)", "").ToUpper() == "PRIMARY")
                    {
                        STN.Add(Parametro7 + "*" + Tipo7 + "*" + TipoC+"*PRIMARY*KEY*");
                        //ParametrosTabla(root.ChildNodes.ElementAt(6));
                    }
                    else
                    {
                        STN.Add(Parametro7 + "*" + Tipo7 + "*" + TipoC);
                        ParametrosTabla(root.ChildNodes.ElementAt(6));
                    }
                                  
                    break;

                case 9:
                    String Parametro8 = root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", "");
                    String Tipo8 = root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", "");
                    String Tipoc8 = root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", "");
                    System.Diagnostics.Debug.WriteLine("sIETE Hijos->" + Parametro8 + "cOLEE->" + Tipo8);
                    STN.Add(Parametro8 + "*" + Tipo8 + "*" + Tipoc8 + "*PRIMARY*KEY*");
                    ParametrosTabla(root.ChildNodes.ElementAt(8));
                    break;
            }
        }
        String Cadena = "";
        public void Lista1(ParseTreeNode root)
        {
            switch (root.ChildNodes.Count)
            {
                case 3:
                    String Parametro2 = root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", "");
                    String Tipo2 = root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (id)", "");
                    //System.Diagnostics.Debug.WriteLine("dos hijo Par->" + Parametro2 + " Tipo->" + Tipo2);
                    Cadena = Cadena + Parametro2 + ",";
                    Lista1(root.ChildNodes.ElementAt(2));
                    break;

                case 1:
                    String Parametro1 = root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", "");
                    //System.Diagnostics.Debug.WriteLine("dos hijo Par->" + Parametro2 + " Tipo->" + Tipo2);
                    Cadena = Cadena + Parametro1;
                    break;

            }
            //return Cadena;
        }

        public void Parametros_Update(ParseTreeNode root)
        {
            switch (root.ChildNodes.Count)
            {
                case 3:
                    String Parametro2 = root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", "");
                    String Tipo2 = root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (id)", "");
                    //System.Diagnostics.Debug.WriteLine("dos hijo Par->" + Parametro2 + " Tipo->" + Tipo2);
                    //Cadena = Cadena + Parametro2 + ",";
                    STN.Add(Parametro2 + "=" + Tipo2);
                    //Lista1(root.ChildNodes.ElementAt(2));
                    break;

                case 5:
                    String Parametro3 = root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", "");
                    String Tipo3 = root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (id)", "");
                    //System.Diagnostics.Debug.WriteLine("dos hijo Par->" + Parametro2 + " Tipo->" + Tipo2);
                    //Cadena = Cadena + Parametro2 + ",";
                    STN.Add(Parametro3 + "=" + Tipo3);
                    Parametros_Update(root.ChildNodes.ElementAt(4));

                    break;
            }
        }

                    #endregion
        public void Analizar(NodoAbstracto raiz)
        {
            try
            {
                Ejecutar(raiz);
            }
            catch (Exception e)
            {
                e.ToString();
            }
        }
        List<String> STN = new List<String>();

        #region LISTAS DE PARAMETROS
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

        public List<String> ListaIDSObjetoXX(ParseTreeNode root)
        {

            switch (root.ChildNodes.Count)
            {
                case 2:
                    System.Diagnostics.Debug.WriteLine("dos hijo" + root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (Keyword)", "") + "," + root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", ""));

                    // String valor1 = root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (Keyword)", "");
                    // String valor2 = root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)", "");
                    STN.Add(root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (Keyword)", "") + "," + root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", ""));

                    break;
                case 4:
                   
                    System.Diagnostics.Debug.WriteLine("cuatro hijo"+ root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (Keyword)", "") + "," + root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (id)", ""));

                    //  String valor1 = root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (Keyword)","");
                    //  String valor2 = root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (id)","");
                    STN.Add(root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (Keyword)", "")+ "," + root.ChildNodes.ElementAt(2).FindToken().ToString().Replace(" (id)", ""));

                    ListaIDSObjetoXX(root.ChildNodes.ElementAt(0));
                    break;
            }
            return STN;
        }
        
        public void Parametros_Order_By(ParseTreeNode root)
        {
            switch (root.ChildNodes.Count)
            {
                case 1:
                    STN.Add(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", "") + "," + "ASC");
                     break;
                case 2:
                      STN.Add(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", "") + "," + root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (Keyword)", ""));

                    break;
                case 3:

                    STN.Add(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", "") + "," +"ASC");
                    Parametros_Order_By(root.ChildNodes.ElementAt(2));
                    break;
                case 4:

                     STN.Add(root.ChildNodes.ElementAt(0).FindToken().ToString().Replace(" (id)", "") + "," + root.ChildNodes.ElementAt(1).FindToken().ToString().Replace(" (Keyword)", ""));
                    Parametros_Order_By(root.ChildNodes.ElementAt(3));
                    break;
            }
        }

        public void AtributosFuncionesUsuario(ParseTreeNode root)
        {
            switch (root.ChildNodes.Count)
            {
                case 1:
                    String Var1 = root.ChildNodes.ElementAt(0).FindToken().ToString();
                    System.Diagnostics.Debug.WriteLine("un hijoxxx" + Var1);
                    STN.Add(Var1);
                    //Atributos(root.ChildNodes.ElementAt(0));
                    break;
                case 3:
                    //                    Atributos(root.ChildNodes.ElementAt(0));                    

                    String Var2 = root.ChildNodes.ElementAt(0).FindToken().ToString();
                    STN.Add(Var2);
                    System.Diagnostics.Debug.WriteLine("tres hijosxxx" + Var2);
                    AtributosFuncionesUsuario(root.ChildNodes.ElementAt(2));


                    break;
            }
        }
        List<NodoAbstracto> LalistaPTN = new List<NodoAbstracto>();
        int contador = 0;
        public void AtributosDeNodosExpresiones(ParseTreeNode root)
        {
            switch (root.ChildNodes.Count)
            {
                case 4:
                    //NodoAbstracto Var1 = Recorrido1(root.ChildNodes.ElementAt(0));

                    //NodoAbstracto Var1 = Recorrido1(root.ChildNodes.ElementAt(2).ChildNodes.ElementAt(0));
                    //LalistaPTN.Add(Var1);
                     AtributosDeNodosExpresiones((root.ChildNodes.ElementAt(2)));
                    //Atributos(root.ChildNodes.ElementAt(0));
                    break;
                case 3:
                    //                    Atributos(root.ChildNodes.ElementAt(0));                    
                    // NodoAbstracto Var2 = Recorrido1(root.ChildNodes.ElementAt(0));
               
                    NodoAbstracto Var2 = Recorrido12(root);
                  
                    LalistaPTN.Add(Var2);
                    AtributosDeNodosExpresiones((root.ChildNodes.ElementAt(2)));


                    break;

                case 1:
                    NodoAbstracto Var2x = Recorrido12(root);

                    LalistaPTN.Add(Var2x);
                    break;
            }
        }
        public void AtributosUT(ParseTreeNode root)
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
                    AtributosUT(root.ChildNodes.ElementAt(2));
                    break;
                case 5:
                    //                    Atributos(root.ChildNodes.ElementAt(0));                    

                    //String Var3 = root.ChildNodes.ElementAt(0).FindToken().ToString();
                    //STN.Add(Var2);
                    //System.Diagnostics.Debug.WriteLine("tres hijos" + Var3);
                    if(root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("NEW"))
                    {
                        STN.Add("NEW," + root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (Keyword)", ""));
                    }
                    else
                    {
                        AtributoLargo = "";
                        AtributoLargo = "{";
                        AtributosUT2(root.ChildNodes.ElementAt(1));
                        AtributoLargo = AtributoLargo + "} AS " + root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", "");
                        System.Diagnostics.Debug.WriteLine("Cinco hijos" + AtributoLargo);
                        STN.Add(AtributoLargo);
                    }

                  
                    break;
                case 6:
                    STN.Add("NEW," + root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (Keyword)", ""));
                    break;
                case 7:
                    //                    Atributos(root.ChildNodes.ElementAt(0));                    

                    //String Var3 = root.ChildNodes.ElementAt(0).FindToken().ToString();
                    //STN.Add(Var2);
                    //System.Diagnostics.Debug.WriteLine("tres hijos" + Var3);
                    if (root.ChildNodes.ElementAt(0).ToString().ToUpper().Contains("NEW"))
                    {
                        STN.Add("NEW," + root.ChildNodes.ElementAt(3).FindToken().ToString().Replace(" (Keyword)",""));
                    }
                    else
                    {
                        AtributoLargo = "";
                        AtributoLargo = "{";
                        AtributosUT2(root.ChildNodes.ElementAt(1));
                        AtributoLargo = AtributoLargo + "} AS " + root.ChildNodes.ElementAt(4).ToString().Replace(" (id)", "");
                        System.Diagnostics.Debug.WriteLine("Siete hijos" + AtributoLargo);
                        STN.Add(AtributoLargo);
                    }
                    
                    AtributosUT(root.ChildNodes.ElementAt(6));
                    break;
            }
        }
        String AtributoLargo = "";
        public void AtributosUT2(ParseTreeNode root)
        {
            
            switch (root.ChildNodes.Count)
            {
                case 1:
                    String Var1 = root.ChildNodes.ElementAt(0).FindToken().ToString();
                    System.Diagnostics.Debug.WriteLine("un hijo" + Var1);
                    AtributoLargo = AtributoLargo + Var1; 
                    //STN.Add(Var1);
                    //Atributos(root.ChildNodes.ElementAt(0));
                    break;
                case 3:
                    //                    Atributos(root.ChildNodes.ElementAt(0));                    

                    String Var2 = root.ChildNodes.ElementAt(0).FindToken().ToString();
                    //STN.Add(Var2);
                    AtributoLargo = AtributoLargo + Var2 + ",";
                    System.Diagnostics.Debug.WriteLine("tres hijos" + Var2);
                    AtributosUT2(root.ChildNodes.ElementAt(2));
                    break;
               
            }
            
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
                     ListaID2(root.ChildNodes.ElementAt(0));
                    String Var2 = root.ChildNodes.ElementAt(2).ToString().Replace(" (id2)", "");
                    System.Diagnostics.Debug.WriteLine("tres hijos" + Var2);
                    Lista.Add(Var2);
                    primes.Add(Var2);
                   
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
        #endregion
    }
}