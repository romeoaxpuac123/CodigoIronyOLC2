using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class USER_TYPE : NodoAbstracto
    {
        public USER_TYPE(String Nombre) : base(Nombre)
        {
            
        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("CREACIÓN USER TYPE");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("CREACIÓN USER TYPE");
            String NombreObjeto = this.Hijos[0].Nombre.ToString().Replace(" (id)","");
            System.Diagnostics.Debug.WriteLine("nombre objeto:" + NombreObjeto);

            Boolean NuevoObjeto = entorno.Agregar(NombreObjeto, "Objeto", "Objeto");

            if(NuevoObjeto == true)
            {
                System.Diagnostics.Debug.WriteLine("NUEVO OBJETO");
                for (int i = 0; i < this.ListaID1.Count; i++)
                {
                    String[] separadas;
                    separadas = ListaID1[i].Split(',');
                    String Valor = "";
                    if(separadas[0].ToUpper().Contains("STRING") || separadas[0].ToUpper().Contains("DATE") || separadas[0].ToUpper().Contains("TIME"))
                    {
                        Valor = "null";
                    }else if (separadas[0].ToUpper().Contains("INT"))
                    {
                        Valor = "0";
                    }
                    else if (separadas[0].ToUpper().Contains("DOUBLE"))
                    {
                        Valor = "0";
                    }else if (separadas[0].ToUpper().Contains("BOOLEAN"))
                    {
                        Valor = "false";
                    }
                    Boolean procura =  entorno.AgregarElementoObjeto(NombreObjeto+"."+ separadas[1], Valor, separadas[0], NombreObjeto);
                    if(procura == false && this.AutoIncrmentable2 !=5)
                    {
                        return "#Error7 atributos repetidos";
                    }

                }

            }
            else
            {
                System.Diagnostics.Debug.WriteLine("OBJETO EXISTENTE");
                return "#ERROR6";

            }
            //reCORRAMOS LA LISTA DE IDS DEL OBJETO
            

                return "USER_TYPE";
        }
    }
}