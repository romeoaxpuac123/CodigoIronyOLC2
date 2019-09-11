using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;
using AnalizadorCQL.Analizadores_CodigoAST;

namespace AnalizadorCQL.Analizadores_Codigo
{
    public class Simbolo
    {
        String Id;
        String NombreFuncion;
        String Valor;
        String Tipo;
        String Objeto;
        List<String> Lista = new List<String>();
        List<String> Lista2 = new List<String>();
        List<Simbolo> Simblosxd = new List<Simbolo>();
        NodoAbstracto nuevo;
        String NombreUsuario;
        String Password;
        String UsuarioPermiso;
        String BaseDeDatosPermiso;
        int numero = 0;

        public Simbolo(String id, String NombreUsuairo, String Password, int tipo)
        {
            this.Id = id;
            this.NombreUsuario = NombreUsuairo;
            this.Password = Password;
            this.numero = tipo;
        }
        public Simbolo(String id, String BaseDeDatos, String Usuario, Boolean autorizo)
        {
            this.Id = id;
            this.UsuarioPermiso = Usuario;
            this.BaseDeDatosPermiso = BaseDeDatos;
        }
        
        public Simbolo(String id, String NombreTabla, String BD, List<Simbolo> Simblosx, List<String> ListaPK)
        {
            this.Id = id;
            this.NombreUsuario = NombreTabla;
            this.BaseDeDatosPermiso = BD;
            this.Simblosxd = Simblosx;
            this.Lista = ListaPK;
        }


        public String NombreBDP()
        {
            return this.BaseDeDatosPermiso;
        }
        public String UsuarioBDP()
        {
            return this.UsuarioPermiso;
        }
        public Simbolo(String id, String NombreBD)
        {
            this.Id = id;
            this.NombreUsuario = NombreBD;
        }

        public String Nombre()
        {
            return this.NombreUsuario;
        }
        public String Pass()
        {
            return this.Password;
        }
        public Simbolo(String Id, String Valor, String Tipo)
        {
            this.Id = Id;
            this.Valor = Valor;
            this.Tipo = Tipo;
        }

        public void DarleUnValor(String Valor)
        {
            this.Valor = Valor;
        }
        public Simbolo (String id, String Valor, List<Simbolo> Simblosxd)
        {
            this.Id = id;
            this.Valor = Valor;
            this.Simblosxd = Simblosxd;
        }
        public List<Simbolo> ListaElementos()
        {
            return this.Simblosxd;
        }
        public Simbolo(String id, String NombreFuncion, String Tipo, List<String> Listax, NodoAbstracto nodo)
        {
            this.Id = id;
            this.NombreFuncion = NombreFuncion;
            this.Tipo = Tipo;
            this.Lista = Listax;
            this.nuevo = nodo;
        }
        public Simbolo(String id, String NombreFuncion, String Tipo, List<String> Listax, List<String> Listaxy, NodoAbstracto nodo)
        {
            this.Id = id;
            this.NombreFuncion = NombreFuncion;
            this.Tipo = Tipo;
            this.Lista = Listax;
            this.Lista2 = Listaxy;
            this.nuevo = nodo;
        }
        public NodoAbstracto Sentencias()
        {
            return this.nuevo;
        }
       
        public void AgregarALista(String elemento)
        {
            this.Lista.Add(elemento);
        }
        public Simbolo(String Id, String Valor, String Tipo,String objetox)
        {
            this.Id = Id;
            this.Valor = Valor;
            this.Tipo = Tipo;
            this.Objeto = objetox;
        }

        public String ObtenerId()
        {
            return Id;
        }
        public List<String> lalista()
        {
            return this.Lista;
        }
        public List<String> lalista2()
        {
            return this.Lista2;
        }
        public String NombreFuncionGuardada()
        {
            return this.NombreFuncion;
        }
        public void EliminarDeLista(String dato)
        {
            this.Lista.Remove(dato);
        }
        public String ObtenerValor()
        {
            return Valor;
        }

        public Boolean ExistenEnLista(String dato)
        {
            Boolean eso = false;
            for(int i = 0; i< this.Lista.Count; i++)
            {
                if (this.Lista[i] == dato)
                    eso = true;
            }
            return eso;
        }

        public String ObtenerTipo()
        {
            return Tipo;
        }

        public void AsignarValor(String Valor)
        {
            this.Valor = Valor;
        }
        public void Cambiar(String Valor)
        {
            this.Id = Valor;
        }
        public String RetornarPosicionObjeto()
        {
            return this.Objeto;
        }

        public void NuevaLista(List<String> Listax)
        {
            this.Lista = Listax;
        }
    }
}