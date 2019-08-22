﻿using System;
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

        public Boolean AgregarElementoObjeto(String id, String valor, String tipo, String Objeto)
        {
            if (!Elementos.ContainsKey(id))
            {
                Simbolo sim = new Simbolo(id, valor, tipo ,Objeto);
                Elementos.Add(id, sim);
                System.Diagnostics.Debug.WriteLine("La variables Del objeto se agregó -> " + id);
                return true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("La variables ya existe -> " + id);
                return false;
            }

        }

        public String ElementosObjetos(String Objeto)
        { String supercadena = "INICIO"; 
                foreach (DictionaryEntry datos in Elementos)
                {
                    if (datos.Key.ToString().Contains(Objeto))
                    {
                        String id = datos.Key.ToString().Replace("@","").Replace(".","").Replace(Objeto,"").Replace(" ","");
                    if (id != "") {
                        supercadena = supercadena + "," + id;
                        System.Diagnostics.Debug.WriteLine("Parametro del objeto -> " + id);
                    }
                        
                    }
                }
            return supercadena;
            
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

        public void EliminarVariable(String id)
        {
            if (Elementos.ContainsKey(id))
            {
                foreach (DictionaryEntry datos in Elementos)
                {
                    if (id == datos.Key.ToString())
                    {
                        Simbolo p = (Simbolo)datos.Value;
                        Elementos.Remove(id);
                    }
                }
            }
        }

        public void AsignarValor(String id, String valor)
        {
            if (Elementos.ContainsKey(id))
            {
                foreach (DictionaryEntry datos in Elementos)
                {
                    if (id == datos.Key.ToString())
                    {
                        Simbolo p = (Simbolo)datos.Value;
                        p.AsignarValor(valor);
                    }
                }
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
                return "#Error2";
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
