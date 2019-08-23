using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnalizadorCQL.Analizadores_Codigo
{
    public class Simbolo
    {
        String Id;
        String Valor;
        String Tipo;
        String Objeto;
        List<String> Lista = new List<String>();
        public Simbolo(String Id, String Valor, String Tipo)
        {
            this.Id = Id;
            this.Valor = Valor;
            this.Tipo = Tipo;
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

        public String ObtenerValor()
        {
            return Valor;
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
    }
}