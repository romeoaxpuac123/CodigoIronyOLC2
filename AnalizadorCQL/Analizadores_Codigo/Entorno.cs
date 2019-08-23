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

        public Hashtable Elementos;

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

        public String ElementosVariableObjeto(String Objeto)
        {
            String supercadena = "INICIO";
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(Objeto))
                {
                    String id = datos.Key.ToString().Replace(" ", "");
                    if (id != "" && id.Contains(".")==true)
                    {
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
            Boolean i = false;
            Hashtable Reemplazo = new Hashtable();
            if (Elementos.ContainsKey(id))
            {
                foreach (DictionaryEntry datos in Elementos)
                {
                    Simbolo p = (Simbolo)datos.Value;
                    //Reemplazo.Add(p.ObtenerId(), p);
                    if (id != datos.Key.ToString())
                    {
                        //Simbolo p = (Simbolo)datos.Value;
                        //Elementos.Remove(id);
                        Reemplazo.Add(p.ObtenerId(), p);
                        
                    }
                }
                i = true;
            }

            foreach(DictionaryEntry x in Reemplazo)
            {
                System.Diagnostics.Debug.WriteLine("La variableeeee ->" + x.Key.ToString());
            }
            if (i == true)
            {
                Elementos = Reemplazo;
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

        public void AgregarLista(String id, String valor)
        {
            if (Elementos.ContainsKey(id))
            {
                foreach (DictionaryEntry datos in Elementos)
                {
                    if (id == datos.Key.ToString())
                    {
                        Simbolo p = (Simbolo)datos.Value;
                        p.AgregarALista(valor);
                        
                    }
                }
            }
        }

        public Boolean RemoverLista(String id, String valor)
        {
            if (Elementos.ContainsKey(id))
            {
                foreach (DictionaryEntry datos in Elementos)
                {
                    if (id == datos.Key.ToString())
                    {
                        Simbolo p = (Simbolo)datos.Value;

                        
                        for (int i = 0; i < p.lalista().Count; i++)
                        {
                           // System.Diagnostics.Debug.WriteLine("sadfdsa" + p.lalista()[i] + "<id>" + valor);
                            if (p.lalista()[i] == valor)
                            {
                                p.lalista().Remove(valor);
                                return true;
                            }
                        }

                    }
                }
            }
            return false;
        }

        public Boolean ExisteEnLista(String id, String valor)
        {
            if (Elementos.ContainsKey(id))
            {
                foreach (DictionaryEntry datos in Elementos)
                {
                    if (id == datos.Key.ToString())
                    {
                        Simbolo p = (Simbolo)datos.Value;


                        for (int i = 0; i < p.lalista().Count; i++)
                        {
                            // System.Diagnostics.Debug.WriteLine("sadfdsa" + p.lalista()[i] + "<id>" + valor);
                            if (p.lalista()[i] == valor)
                            {
                                
                                return true;
                            }
                        }

                    }
                }
            }
            return false;
        }

        public int PosicionLista(String id, String valor)
        {
            if (Elementos.ContainsKey(id))
            {
                foreach (DictionaryEntry datos in Elementos)
                {
                    if (id == datos.Key.ToString())
                    {
                        Simbolo p = (Simbolo)datos.Value;


                        for (int i = 0; i < p.lalista().Count; i++)
                        {
                            // System.Diagnostics.Debug.WriteLine("sadfdsa" + p.lalista()[i] + "<id>" + valor);
                            if (p.lalista()[i] == valor)
                            {
                                //p.lalista().Remove(valor);
                                return i;
                            }
                        }

                    }
                }
            }
            return -1;
        }

        public void Mostrar(String id)
        {
            if (Elementos.ContainsKey(id))
            {
                foreach (DictionaryEntry datos in Elementos)
                {
                    if (id == datos.Key.ToString())
                    {
                        Simbolo p = (Simbolo)datos.Value;
                        System.Diagnostics.Debug.WriteLine("La lista" + " " + id);
                        for (int i = 0; i< p.lalista().Count; i++)
                        {
                            System.Diagnostics.Debug.WriteLine(p.lalista()[i]);
                        }

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
        public String ObtenerPosicion(String id, String numero)
        {
            String Valor = "";
            String Valor2 = "";
            if (Elementos.ContainsKey(id))
            {
                
                foreach (DictionaryEntry datos in Elementos)
                {
                    if (datos.Key.ToString().Contains(id))
                    {
                        
                        Simbolo p = (Simbolo)datos.Value;
                        Valor = p.RetornarPosicionObjeto();
                       // System.Diagnostics.Debug.WriteLine("sososos" + Valor);
                        if (Valor== numero)
                        {
                            Valor2 = p.ObtenerId();
                        }
                    }
                }
                return Valor2;
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
        public String ObtenerObjeto(String id)
        {
            String tipo = "";
            if (Elementos.ContainsKey(id))
            {
                foreach (DictionaryEntry datos in Elementos)
                {
                    if (id == datos.Key.ToString())
                    {
                        Simbolo p = (Simbolo)datos.Value;
                        tipo = p.RetornarPosicionObjeto();
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
