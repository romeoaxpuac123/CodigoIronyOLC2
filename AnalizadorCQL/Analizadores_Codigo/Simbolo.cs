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
        public Simbolo(String Id, String Valor, String Tipo)
        {
            this.Id = Id;
            this.Valor = Valor;
            this.Tipo = Tipo;
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
        public String RetornarObjeto(String id)
        {
            return this.Objeto;
        }
    }
}