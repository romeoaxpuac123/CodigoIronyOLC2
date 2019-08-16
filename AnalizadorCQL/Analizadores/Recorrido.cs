using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Irony.Parsing;
using AnalizadorCQL.Analizadores_Codigo;
using AnalizadorCQL.Analizadores_CodigoAST;
namespace AnalizadorCQL.Analizadores
{
    public class Recorrido
    {
        public NodoAbstracto Raiz;
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
                    break;

                case 1:
                    Recorrido1(root.ChildNodes.ElementAt(0));
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
                    else if (root.ToString() == "SENTENCIAS")
                    {
                        //Console.WriteLine("PASO POR LA EXPRESION S (RAIZ)");

                        NodoAbstracto nuevo = new Nodo("SENTENCIAS");
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(0)));

                        return nuevo;


                    }
                    else if (root.ToString() == "E")
                    {
                        //Console.WriteLine("sssssss" + root.ChildNodes.ElementAt(0).FindToken() + "sssssss");
                        if (root.ChildNodes.ElementAt(0).FindToken().ToString().Contains("(numero)"))
                        {
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
                            NodoAbstracto nuevovalor = new Nodo(root.ChildNodes.ElementAt(0).ToString().Replace(" (Keyword)",""));
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
                        else if (root.ChildNodes.ElementAt(0).FindToken().ToString().Contains("(id)"))
                        {
                            //      Console.WriteLine("PASO POR UN ID ");

                        }
                    }
                        break;
                case 2:
                    Recorrido1(root.ChildNodes.ElementAt(0));
                    Recorrido1(root.ChildNodes.ElementAt(1));
                    System.Diagnostics.Debug.WriteLine("CAso2 -> " + root.ToString());
                    if (root.ChildNodes.ElementAt(0).FindToken().ToString().Contains("id")
                        && root.ChildNodes.ElementAt(1).FindToken().ToString().Contains("id2") 
                       )
                    {
                        System.Diagnostics.Debug.WriteLine("CODIGO PARA CREAR UN OJBETO Estudiante @est;");


                    }
                    else if(root.ToString() == "SENTENCIAS")
                    {
                        NodoAbstracto nuevo = Recorrido1(root.ChildNodes.ElementAt(0));
                        nuevo.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(1)));
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
                            && root.ChildNodes.ElementAt(0).ToString().Contains("- (Key symbol") )
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
                    }


                        break;
                case 3:                    
                    Recorrido1(root.ChildNodes.ElementAt(0));
                    Recorrido1(root.ChildNodes.ElementAt(1));
                    Recorrido1(root.ChildNodes.ElementAt(2));
                    System.Diagnostics.Debug.WriteLine("CAso3 -> " + root.ToString());
                    if (root.ToString() == "ASIGNACION")
                    {
                        if (root.ChildNodes.ElementAt(0).ToString().Contains("TIPOS_VARIABLES")
                        && root.ChildNodes.ElementAt(1).FindToken().ToString().Contains("id2") &&
                        root.ChildNodes.ElementAt(2).ToString().Contains("Key symbol")
                       )
                        {
                            System.Diagnostics.Debug.WriteLine("CODIGO PARA DECALRAR UNA VARIABLE INT @VAR1;");


                        }
                    }
                    else if (root.ToString() == "E")
                    {
                        NodoAbstracto RESULT = null;
                        if ((root.ChildNodes.ElementAt(1).ToString().Contains("+ (Key symbol")))
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

                        else if (repeticiones(root.ChildNodes.ElementAt(1).ToString())==2)
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
                            return RESULT;
                            //Raiz = nuevo;
                        }


                        if (Recorrido1(root.ChildNodes.ElementAt(0)).TipoDato == "decimal"
                            && Recorrido1(root.ChildNodes.ElementAt(2)).TipoDato == "decimal")
                        {
                            RESULT.TipoDato = "decimal";
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

                        return RESULT;
                    }
                        
                   
                    break;
                case 4:
                    
                    Recorrido1(root.ChildNodes.ElementAt(0));
                    Recorrido1(root.ChildNodes.ElementAt(1));
                    Recorrido1(root.ChildNodes.ElementAt(2));
                    Recorrido1(root.ChildNodes.ElementAt(3));
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
                    else if (root.ToString() == "DELETE_TYPE")
                    {
                        if (root.ChildNodes.ElementAt(0).FindToken().ToString().Contains("delete")
                        && root.ChildNodes.ElementAt(1).FindToken().ToString().Contains("type"))
                        {
                            System.Diagnostics.Debug.WriteLine("CODIGO PARA BORRAR UN TYPE");


                        }
                        
                    }else if (root.ToString() == "ASIGNACION")
                    {
                        if (root.ChildNodes.ElementAt(0).FindToken().ToString().Contains("id2")
                         && root.ChildNodes.ElementAt(1).FindToken().ToString().Contains("Key symbol")&&
                         root.ChildNodes.ElementAt(2).ToString().Contains("E")
                        )
                        {
                            System.Diagnostics.Debug.WriteLine("CODIGO PARA ASIGNAR UNA VARIABLE @VAR=EXPRESION;");


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



                    break;
                case 5:
                    
                    Recorrido1(root.ChildNodes.ElementAt(0));
                    Recorrido1(root.ChildNodes.ElementAt(1));
                    Recorrido1(root.ChildNodes.ElementAt(2));
                    Recorrido1(root.ChildNodes.ElementAt(3));
                    Recorrido1(root.ChildNodes.ElementAt(4));
                    System.Diagnostics.Debug.WriteLine("CAso5 -> " + root.ToString());
                    if (root.ChildNodes.ElementAt(0).FindToken().ToString().Contains("id2") && 
                        root.ChildNodes.ElementAt(1).FindToken().ToString().Contains("Key symbol") &&
                        root.ChildNodes.ElementAt(2).FindToken().ToString().Contains("id") &&
                        root.ChildNodes.ElementAt(3).FindToken().ToString().Contains("Key symbol") &&
                        root.ChildNodes.ElementAt(4).ToString().ToUpper().Contains("E")
                    )
                    {
                        System.Diagnostics.Debug.WriteLine("Codigo para Asignacion de Objeto de la forma @id2.id = e");
                    }else if (root.ChildNodes.ElementAt(0).ToString().Contains("TIPOS_VARIABLES") &&
                        root.ChildNodes.ElementAt(1).FindToken().ToString().Contains("id2") &&
                        root.ChildNodes.ElementAt(2).FindToken().ToString().Contains("Key symbol") &&
                        root.ChildNodes.ElementAt(4).ToString().ToUpper().Contains("E")
                    )
                    {
                        System.Diagnostics.Debug.WriteLine("Codigo para Asignacion de una variable tipo @var1 = Exprsion");
                    }
                    else if (root.ChildNodes.ElementAt(0).ToString().Contains("LOG") ||
                        root.ChildNodes.ElementAt(0).ToString().Contains("log")||
                        root.ChildNodes.ElementAt(0).ToString().Contains("Log") ||
                        root.ChildNodes.ElementAt(0).ToString().Contains("lOg")||
                        root.ChildNodes.ElementAt(0).ToString().Contains("loG")
                        )
                    {
                        NodoAbstracto nuevo2 = new LOG("IMPRIMIR");
                        nuevo2.Hijos.Add(Recorrido1(root.ChildNodes.ElementAt(2)));
                        return nuevo2;
                    }
                    break;
                case 6:
                   
                    Recorrido1(root.ChildNodes.ElementAt(0));
                    Recorrido1(root.ChildNodes.ElementAt(1));
                    Recorrido1(root.ChildNodes.ElementAt(2));
                    Recorrido1(root.ChildNodes.ElementAt(3));
                    Recorrido1(root.ChildNodes.ElementAt(4));
                    Recorrido1(root.ChildNodes.ElementAt(5));
                    System.Diagnostics.Debug.WriteLine("CAso6 -> " + root.ToString());
                    if (root.ChildNodes.ElementAt(3).FindToken().ToString().ToUpper().Contains("DROP") && root.ChildNodes.ElementAt(0).FindToken().ToString().ToUpper().Contains("ALTER"))
                    {
                            System.Diagnostics.Debug.WriteLine("CODIGO PARA ALTER TABLE DROP");
                        
                    }
                    else if (root.ChildNodes.ElementAt(3).FindToken().ToString().ToUpper().Contains("ADD") && root.ChildNodes.ElementAt(0).FindToken().ToString().ToUpper().Contains("ALTER"))
                    {
                            System.Diagnostics.Debug.WriteLine("CODIGO PARA ALTER TABLE ADD");
                       
                    }else if (root.ChildNodes.ElementAt(0).FindToken().ToString().Contains("id") &&
                              root.ChildNodes.ElementAt(1).FindToken().ToString().Contains("id2") &&
                              root.ChildNodes.ElementAt(2).FindToken().ToString().Contains("Key symbol") &&
                              root.ChildNodes.ElementAt(3).FindToken().ToString().Contains("Key symbol") &&
                              root.ChildNodes.ElementAt(4).ToString().Contains("LISTA_EXPRESION") &&
                              root.ChildNodes.ElementAt(5).FindToken().ToString().Contains("Key symbol") 
                    ) {
                        System.Diagnostics.Debug.WriteLine("CODIGO ASIGNAR VALORES A UN OBJETO Estudiante @est3 = {201504481, \"Julio Arango\",@est2};");
                    }
                    
                    break;
                case 7:
                    
                    Recorrido1(root.ChildNodes.ElementAt(0));
                    Recorrido1(root.ChildNodes.ElementAt(1));
                    Recorrido1(root.ChildNodes.ElementAt(2));
                    Recorrido1(root.ChildNodes.ElementAt(3));
                    Recorrido1(root.ChildNodes.ElementAt(4));
                    Recorrido1(root.ChildNodes.ElementAt(5));
                    Recorrido1(root.ChildNodes.ElementAt(6));
                    System.Diagnostics.Debug.WriteLine("CAso7 -> " + root.ToString());
                    if (root.ChildNodes.ElementAt(0).FindToken().ToString().ToUpper().Contains("CREATE") && root.ChildNodes.ElementAt(1).FindToken().ToString().ToUpper().Contains("TABLE"))
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
                        System.Diagnostics.Debug.WriteLine("Codigo para LA CREACION DE OBJETOS;");
                    }
                    break;
                case 8:

                    Recorrido1(root.ChildNodes.ElementAt(0));
                    Recorrido1(root.ChildNodes.ElementAt(1));
                    Recorrido1(root.ChildNodes.ElementAt(2));
                    Recorrido1(root.ChildNodes.ElementAt(3));
                    Recorrido1(root.ChildNodes.ElementAt(4));
                    Recorrido1(root.ChildNodes.ElementAt(5));
                    Recorrido1(root.ChildNodes.ElementAt(6));
                    Recorrido1(root.ChildNodes.ElementAt(7));
                    System.Diagnostics.Debug.WriteLine("CAso8 -> " + root.ToString());
                    if (root.ChildNodes.ElementAt(0).ToString().Contains("TIPOS_VARIABLES")
                        && root.ChildNodes.ElementAt(1).FindToken().ToString().Contains("(id2)")
                        && root.ChildNodes.ElementAt(2).FindToken().ToString().Contains("=")
                        && root.ChildNodes.ElementAt(3).FindToken().ToString().Contains("(")
                        && root.ChildNodes.ElementAt(4).ToString().Contains("TIPOS_VARIABLES")
                        && root.ChildNodes.ElementAt(5).FindToken().ToString().Contains(")")
                         && root.ChildNodes.ElementAt(6).ToString().Contains("E")
                    )
                    {
                        System.Diagnostics.Debug.WriteLine("CODIGO CASTEO OBLIGATORIO");
                    }else if (root.ChildNodes.ElementAt(0).ToString().Contains("alter") &&
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
            foreach (NodoAbstracto sentencia in raiz.Hijos[0].Hijos)
            {// para ejecutar solo sentencias 
                //Console.WriteLine("pureba for " + sentencia.Nombre + raiz.TipoDato);
                sentencia.Ejecutar(entorno);
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