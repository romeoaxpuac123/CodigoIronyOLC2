using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;
using AnalizadorCQL.Zclases;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class USER_TYPE : NodoAbstracto
    {

        
        public USER_TYPE(String Nombre) : base(Nombre)
        {
            
        }

        public override void Ejecutar()
        {
         //   System.Diagnostics.Debug.WriteLine("CREACIÓN USER TYPE");
        }

        public override string Ejecutar(Entorno entorno)
        {
           // System.Diagnostics.Debug.WriteLine("CREACIÓN USER TYPE");
            String NombreObjeto = this.Hijos[0].Nombre.ToString().Replace(" (id)","");
          //  System.Diagnostics.Debug.WriteLine("nombre objeto:" + NombreObjeto);
            if (entorno.ExisteVariable(NombreObjeto) == false)
            {
                Boolean NuevoObjeto = entorno.Agregar(NombreObjeto, "Objeto", "Objeto");
                Boolean ExistenRepetidos = false;
                if (NuevoObjeto == true)
                {
                    System.Diagnostics.Debug.WriteLine("NUEVO OBJETO");
                    for (int i = 0; i < this.ListaID1.Count; i++)
                    {
                        String[] separadas;
                        separadas = ListaID1[i].Split(',');
                        String Valor = "";
                        //System.Diagnostics.Debug.WriteLine("CREACIÓN USER TYPE " + separadas[0]);
                        if (separadas[0].ToUpper().Contains("STRING") || separadas[0].ToUpper().Contains("DATE") || separadas[0].ToUpper().Contains("TIME")|| separadas[0].ToUpper().Contains("ID"))
                        {
                            Valor = "null";
                            if (separadas[0].ToUpper().Contains("ID") == true)
                            {
                                //System.Diagnostics.Debug.WriteLine("CREACIÓN USER TYPE " + separadas[0]);
                                if (entorno.ExisteVariable(separadas[0].Replace(" (id)", ""))==false)
                                {
                                    if(separadas[0].ToUpper().Contains("SET")== true|| separadas[0].ToUpper().Contains("LIST") == true)
                                    {
                                       
                                    }
                                    else
                                    {
                                        ExistenRepetidos = true;
                                    }
                                    
                                }
                            }
                        }
                        else if (separadas[0].ToUpper().Contains("INT"))
                        {
                            Valor = "0";
                        }
                        else if (separadas[0].ToUpper().Contains("DOUBLE"))
                        {
                            Valor = "0";
                        }
                        else if (separadas[0].ToUpper().Contains("BOOLEAN"))
                        {
                            Valor = "false";
                        }
                        Boolean procura = entorno.AgregarElementoObjeto(NombreObjeto + "." + separadas[1], Valor, separadas[0].Replace(" (id)", ""), (i + 1).ToString());
                        if (procura == false )
                        {
                            ExistenRepetidos = true;
                            //return "#ERROR7 atributos repetidos";
                        }

                    }

                    if (ExistenRepetidos == true)
                    {
                        entorno.EliminarVariable(NombreObjeto);
                        for (int i = 0; i < this.ListaID1.Count; i++)
                        {
                            String[] separadas;
                            separadas = ListaID1[i].Split(',');
                            entorno.EliminarVariable(NombreObjeto + "." + separadas[1]);
                        }

                        if(this.AutoIncrmentable2 != 5)
                        return "#ERROR6 ? Exception: TypeAlreadyExists: User Type con un nombre/parametro ya existente.";
                        else
                        {
                            return "#ERROR6 con Exist if";
                        }

                    }

                   




                }
                else
                {
                    // System.Diagnostics.Debug.WriteLine("OBJETO EXISTENTE");
                    if (this.AutoIncrmentable2 != 5)
                        return "#ERROR6 ? Exception: TypeAlreadyExists: User Type con un nombre ya existente.";
                    else
                    {
                        return "#ERROR6 con Exist if";
                    }

                }
                //reCORRAMOS LA LISTA DE IDS DEL OBJETO

            }
            else
            {
                // System.Diagnostics.Debug.WriteLine("OBJETO EXISTENTE");
                if (this.AutoIncrmentable2 != 5)
                    return "#ERROR6 ? Exception: TypeAlreadyExists: User Type con un nombre ya existente.";
                else
                {
                    return "#ERROR6 con Exist if";
                }
            }

            

            entorno.EliminarVariable(NombreObjeto);
            for (int i = 0; i < this.ListaID1.Count; i++)
            {
                String[] separadas;
                separadas = ListaID1[i].Split(',');
                entorno.EliminarVariable(NombreObjeto + "." + separadas[1]);
            }
            

            List<Simbolo> ElementosUT = new List<Simbolo>();

            for (int i = 0; i < this.ListaID1.Count; i++)
            {
                String[] separadas;
                separadas = ListaID1[i].Split(',');
                String Valor = "";
                //System.Diagnostics.Debug.WriteLine("CREACIÓN USER TYPE " + separadas[0]);
                if (separadas[0].ToUpper().Contains("STRING") || separadas[0].ToUpper().Contains("DATE") || separadas[0].ToUpper().Contains("TIME") || separadas[0].ToUpper().Contains("ID"))
                {
                    Valor = "null";
                }
                else if (separadas[0].ToUpper().Contains("INT"))
                {
                    Valor = "0";
                }
                else if (separadas[0].ToUpper().Contains("DOUBLE"))
                {
                    Valor = "0";
                }
                else if (separadas[0].ToUpper().Contains("BOOLEAN"))
                {
                    Valor = "false";
                }
                //Boolean procura = entorno.AgregarElementoObjeto(NombreObjeto + "." + separadas[1], Valor, separadas[0].Replace(" (id)", ""), (i + 1).ToString());
                Simbolo SimboloXD = new Simbolo(separadas[1], Valor,separadas[0].Replace(" (id)", ""));
                ElementosUT.Add(SimboloXD);

            }
            for(int i=0; i< ElementosUT.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine("PARAMETRO: "+ElementosUT[i].ObtenerId() + " Tipo: " + ElementosUT[i].ObtenerTipo() + " Valor" + ElementosUT[i].ObtenerValor());
            }

            entorno.AgregarObjeto(NombreObjeto, "Objeto", ElementosUT,NombreObjeto);
            

            return "PROCESO USER-TYPE CRADO";
        }
    }
}