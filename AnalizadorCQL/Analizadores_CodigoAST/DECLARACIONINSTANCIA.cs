using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class DECLARACIONINSTANCIA : NodoAbstracto
    {
        public DECLARACIONINSTANCIA(String Valor) : base(Valor)
        {

        }
        public override void Ejecutar()
        {

            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado DELCARCION-INSTANCIA OBJETO");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado DELCARCION-INSTANCIA OBJETO");
            String Objeto1 = this.Hijos[0].Nombre.ToString();
            String Variable = this.Hijos[1].Nombre.ToString();
            String Objeto2 = this.Hijos[2].Nombre.ToString();
            if (Objeto1.ToUpper() == Objeto2.ToUpper())
            {
                if (entorno.ExisteVariable(Objeto1) == true)
                {
                    List<Simbolo> Lista =  entorno.ElementosUT(Objeto1);
                    entorno.AgregarObjeto(Variable, "OBJETO_BRAY", Lista,Objeto1);
                    System.Diagnostics.Debug.WriteLine("Elemenos");
                    for (int i = 0; i < Lista.Count; i++)
                    {
                        System.Diagnostics.Debug.WriteLine("Elemenos" + Lista[i].ObtenerId() + "-" + Lista[i].ObtenerTipo());
                       if( (Lista[i].ObtenerTipo().ToUpper() == ("STRING") )|| (Lista[i].ObtenerTipo().ToUpper() == ("DOUBLE")) 
                            || (Lista[i].ObtenerTipo().ToUpper() == ("TIME")) || (Lista[i].ObtenerTipo().ToUpper() == ("INT"))
                            ||(Lista[i].ObtenerTipo().ToUpper() == ("DATE"))

                        ){
                            //entorno.AgregarObjeto(Variable + "." + Lista[i].ObtenerId(), "OBJETO_BRAY", null);
                            entorno.Agregar(Variable + "." + Lista[i].ObtenerId(), Lista[i].ObtenerTipo(), "nulo");
                        }
                        if ((Lista[i].ObtenerTipo().ToUpper() != ("LIST"))
                            && (Lista[i].ObtenerTipo().ToUpper() != ("SET")))
                        {

                        }
                    }
                }
                else
                {
                    return "#ERROR6 ? Exception: ObjectAlreadyExists: instancia con identificador ya existente. 3";
                }
            }
            else
            {
                return "#ERROR6 ? Exception: TypeAlreadyExists: User Type con un nombre no existente. 3";
            }
               
                return "DECLARACION-INSTANCIA OBJETOS";
        }
    }
}