using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class LLAMADA_CURSOR:NodoAbstracto
    {
        public LLAMADA_CURSOR(String Nombre) : base(Nombre)
        {

        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion LLLAMADA CURSOR");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion LLLAMADA CURSOR");
            String Cursor = this.Hijos[0].Nombre.Replace(" (id2)","");
            NodoAbstracto Sentencia = this.Hijos[1];
            System.Diagnostics.Debug.WriteLine("Ejecucion LLLAMADA CURSOR -nombre->"+Cursor);
            String ValorCursor = entorno.EstadoCursor(Cursor);
            List<String> Parametros = new List<String>();
          
            if (ValorCursor == "1")
            {
                //leeemos el archivo en primer lugar
                string text = System.IO.File.ReadAllText(@"C:\Users\Bayyron\Desktop\RoshiEIrack\"+Cursor+".txt");
                string[] separadas;
                separadas = text.Split('\n');
                for (int x = 0; x < separadas.Length; x++) {
                    if (separadas[x].Contains("*"))
                    {
                        //System.Diagnostics.Debug.WriteLine("Ejecucion LLLAMADA CURSOR -archivi->" + separadas[x]);
                        string[] Comas;
                        Comas = separadas[x].Split(',');
                        List<String> ParametrostAbla = new List<String>();
                        for(int p = 0; p < Comas.Length - 1; p++)
                        {
                            ParametrostAbla.Add(Comas[p]);
                        }
                        for (int p = 0; p < ParametrostAbla.Count; p++)
                        {
                            //System.Diagnostics.Debug.WriteLine("Archivro->" + ParametrostAbla[p]);
                        }
                        if(ParametrostAbla.Count == this.ListaID1.Count)
                        {
                            //empezamos con los entornos
                            System.Diagnostics.Debug.WriteLine("Nuevo entorno->");
                            Entorno NuevoEntorno = new Entorno();
                            for (int p = 0; p < ParametrostAbla.Count; p++)
                            {
                                //System.Diagnostics.Debug.WriteLine("Archivro->" + ParametrostAbla[p] + " Lista->" + this.ListaID1[p]);
                                string[] AteriscoTabla;
                                AteriscoTabla = ParametrostAbla[p].Split('*');

                                string[] AteriscoLista;
                                AteriscoLista = this.ListaID1[p].Split('*');

                                if(AteriscoLista[0].ToUpper()== AteriscoTabla[1].ToUpper())
                                {
                                    
                                    if(NuevoEntorno.Agregar(AteriscoLista[1], AteriscoLista[0], AteriscoTabla[0]))
                                    {
                                        System.Diagnostics.Debug.WriteLine("Archivro Variable->" + AteriscoLista[1] + "->" + AteriscoLista[0] + "->" + AteriscoTabla[0]);
                                    }
                                    else {
                                        return "#ERROR, uno de los parametros ya fue declarado";
                                    }
                                }
                                else
                                {
                                    return "#ERROR, los parametros no coinciden de tipo con los resltados de la tabla";
                                }

                                //ejecuando sentencias.
                               
                            }
                            for (int ix = 1; ix < this.Hijos.Count; ix++)
                            {
                                this.Hijos[ix].Ejecutar(NuevoEntorno);
                            }
                        }
                        else
                        {
                            return "#ERROR, LA CANTIDAD DE PARAMETROS NO SON IGUALES";  
                        }

                    }
                    
                }
            }
            else
            {
                return "#ERROR el cursos no ha sido activado";
            }
            /*
            //System.Diagnostics.Debug.WriteLine("Ejecucion LLLAMADA CURSOR -seteca->" + Sentencia.ToString());
            for (int i = 0; i < this.ListaID1.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine("Ejecucion LLLAMADA CURSOR -aratro->" + this.ListaID1[i]);
            }
            for(int i = 1; i < this.Hijos.Count; i++)
            {
                this.Hijos[i].Ejecutar(entorno);
            }
            */
            return "llamada cursor";
        }
    }
}