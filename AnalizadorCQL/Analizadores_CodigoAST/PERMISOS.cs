using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class PERMISOS : NodoAbstracto
    {

        public PERMISOS(String Nombre) : base(Nombre)
        {

        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion PERMISOS");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion PERMISOS");
            String Usuario = this.Hijos[0].Nombre;
            String bd = this.Hijos[1].Nombre;
            System.Diagnostics.Debug.WriteLine("Ejecucion PERMISOS->" + Usuario);
            System.Diagnostics.Debug.WriteLine("Ejecucion PERMISOS->" + bd);
            Boolean ExisteUsuario = entorno.ExisteUsuario(Usuario);
            Boolean ExisteBD = entorno.ExisteBD(bd);

            if(ExisteUsuario == true && ExisteBD == true)
            {
                if (this.AutoIncrmentable2 == 1)
                {
                    String idPermiso = "BRAY-PER" + (entorno.CantidadPERMISOS() + 1);
                    Boolean ExistePermiso = entorno.ExistePermiso(Usuario, bd);
                    if (ExistePermiso == true)
                    {
                        return "EL PERMISO YA FUE AUTORIZADO";
                    }
                    else
                    {
                        entorno.AgregarPermiso(idPermiso, Usuario, bd);
                    }

                }
                else if (this.AutoIncrmentable2 == 2)
                {
                    Boolean ExistePermiso = entorno.ExistePermiso(Usuario, bd);
                    if (ExistePermiso == true)
                    {
                        String IDPE = entorno.idPermiso(Usuario, bd);
                        entorno.EliminarVariable(IDPE);
                        return "PERMISO ELIMINADO";
                    }
                    else
                    {
                        return "EL PERMISO NO EXISTE";
                    }
                }

            }

            else
            {
                return "#ERROR NO EXISTE LA BD O EL USUARIO";
            }
            entorno.MostrarPermisos();
            return "PERMISOS";
        }
    }

}