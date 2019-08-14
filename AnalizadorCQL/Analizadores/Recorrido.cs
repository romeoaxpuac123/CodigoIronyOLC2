using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Irony.Parsing;
namespace AnalizadorCQL.Analizadores
{
    public class Recorrido
    {

        public static void Recorrido1(ParseTreeNode root)
        {
            Gramatica g = new Gramatica();
            switch (root.ChildNodes.Count)
            {
                case 1:
                    Recorrido1(root.ChildNodes.ElementAt(0));
                    System.Diagnostics.Debug.WriteLine("CAso1 -> " + root.ToString());
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
        }

    }
}