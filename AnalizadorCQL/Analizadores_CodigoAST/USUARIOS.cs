using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class USUARIOS:NodoAbstracto
    {

        public USUARIOS(String Nombre) : base(Nombre)
        {

        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion USUARIOS");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion USUARIOS");
            String Usuario = this.Hijos[0].Nombre;
            String Password = this.Hijos[1].Nombre;
            Boolean ExistenUsuario = entorno.ExisteUsuario(Usuario);
            String IdUsuario = "BRAY-US" + (entorno.CantidadDeUsuarios() + 1);
            System.Diagnostics.Debug.WriteLine("Ejecucion USUARIOS->"+Usuario);
            System.Diagnostics.Debug.WriteLine("Ejecucion USUARIOS->"+Password);
            System.Diagnostics.Debug.WriteLine("Ejecucion USUARIOS->" + ExistenUsuario);
            System.Diagnostics.Debug.WriteLine("Ejecucion USUARIOS->" + IdUsuario);

            if(ExistenUsuario == false)
            {
                entorno.AgregarUsuario(IdUsuario, Usuario, Password);
            }
            else
            {
               
                return "#ERROR: UserAlreadyExist: usuario con un nombre ya existente;";
            }

            entorno.MostrarUsuarios();

            return "USUARIOS";
        }
    }
}