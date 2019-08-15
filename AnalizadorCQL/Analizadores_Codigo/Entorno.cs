using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalizadorCQL.Analizadores_Codigo
{
    public class Entorno
    {

        Hashtable Elementos;

        public Entorno()
        {
            Elementos = new Hashtable();
        }

        public bool Agregar(String id, String tipo, String valor)
        {
            if (!Elementos.ContainsKey(id))
            {
                Simbolo sim = new Simbolo(id, valor, tipo);
                Elementos.Add(id, sim);
                System.Diagnostics.Debug.WriteLine("La variables se agregó -> " + id);
                return true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("La variables ya existe -> " + id);
                return false;
            }
        }

        public String ObtenerValor(String id)
        {
            String Valor = "";
            if (Elementos.ContainsKey(id))
            {
                foreach (DictionaryEntry datos in Elementos)
                {
                    if (id == datos.Key.ToString())
                    {
                        Simbolo p = (Simbolo)datos.Value;
                        Valor = p.ObtenerValor();
                    }
                }
                return Valor;
            }
            else
            {
                return "#Error";
            }
        }

        public String ObtenerTipo(String id)
        {
            String tipo = "";
            if (Elementos.ContainsKey(id))
            {
                foreach (DictionaryEntry datos in Elementos)
                {
                    if (id == datos.Key.ToString())
                    {
                        Simbolo p = (Simbolo)datos.Value;
                        tipo = p.ObtenerTipo();
                    }
                }
                return tipo;
            }
            else
            {
                return "#Error";
            }

        }

    }
}
