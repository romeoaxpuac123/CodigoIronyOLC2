using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class BD:NodoAbstracto
    {

        public BD (String Nombre) : base(Nombre)
        {
            
        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion bd");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion bd");

            String Usuario = this.Hijos[0].Nombre;
            Boolean ExistenUsuario = entorno.ExisteBD(Usuario);
            String IdUsuario = "BRAY-BD" + (entorno.CantidadDeBD() + 1);
            System.Diagnostics.Debug.WriteLine("Ejecucion USUARIOS->" + Usuario); 
            System.Diagnostics.Debug.WriteLine("Ejecucion USUARIOS->" + ExistenUsuario);
            System.Diagnostics.Debug.WriteLine("Ejecucion USUARIOS->" + IdUsuario);

            if (ExistenUsuario == false)
            {
                entorno.AgregarBD(IdUsuario, Usuario);
            }
            else
            {
                if (this.AutoIncrmentable2 == 2)
                {
                    return "#ERROR: con if  BDAlreadyExists: base de datos con un nombre ya existente;";
                }
                return "#ERROR: BDAlreadyExists: base de datos con un nombre ya existente;";
            }

            return "BD";
        }
    }
}