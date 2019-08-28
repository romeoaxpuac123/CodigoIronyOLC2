using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnalizadorCQL.Analizadores_CodigoAST;

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

        public Boolean AgregarFuncion(String id, String NombreFuncion, String Tipo, List<String> Listax, NodoAbstracto nuevo)
        {
            if (!Elementos.ContainsKey(id))
            {
                Simbolo sim = new Simbolo(id, NombreFuncion, Tipo, Listax, nuevo);
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

        public int CantidadDeFunciones()
        {
            String id = "BRAY-FUNC";
            int a = 0;
           
                foreach (DictionaryEntry datos in Elementos)
                {
                if (datos.Key.ToString().Contains(id))
                    {
                        a++;
                    }
                }
            

            return a;
        }

        public void MostrarFunciones()
        {
            String id = "BRAY-FUNC";
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    System.Diagnostics.Debug.WriteLine("NombreFuncion -> " + datos.Key.ToString() + " funcion "+ p.NombreFuncionGuardada() + " #Par " + p.lalista().Count);
                }
            }
        }

        public NodoAbstracto NodoSinParametros(String NombreFuncion)
        {
            String id = "BRAY-FUNC";
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    if (p.NombreFuncionGuardada().ToUpper().Contains(NombreFuncion.ToUpper()) == true)
                    {
                        if(p.lalista().Count == 0)
                        {
                            return p.Sentencias();
                        }
                    }
                }
            }
            return null;
        }

        public Boolean MismosParametros(String Nombre, List<String> Listax)
        {
            String id = "BRAY-FUNC";
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    if (p.NombreFuncionGuardada().ToString().ToUpper() == Nombre.ToUpper())
                    {
                       if(p.lalista().Count == Listax.Count)
                        {
                            for(int i = 0; i < Listax.Count; i++)
                            {
                                string[] separadas;
                                separadas = Listax[i].Split('*');
                                if(p.lalista()[i].ToUpper().Contains(separadas[0].ToUpper()) == true)
                                {
                                    return true;
                                }
                                else
                                {
                                    for(int j = 0; j < p.lalista().Count; j++)
                                    {
                                        if (p.lalista()[j].ToUpper().Contains(separadas[1].ToUpper()) == true)
                                        {
                                            return true;
                                        }
                                    }
                                }
                            }
                            
                        }
                    }
                }
            }

            return false;
        }

      public Boolean ExisteFuncion(String Nombre)
        {
            String id = "BRAY-FUNC";
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    if(p.NombreFuncionGuardada().ToString().ToUpper() == Nombre.ToUpper())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public Boolean ExisteListaConLaMismaCantidadDeParametros(String Nombre, int elementos)
        {

            String id = "BRAY-FUNC";
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    if (p.lalista().Count == elementos)
                    {
                        return true;
                    }
                }
            }
            return false;
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

      

        public void ordenarlista(String id, String Tipo)
        {
            if (Elementos.ContainsKey(id))
            {
                foreach (DictionaryEntry datos in Elementos)
                {
                    if (id == datos.Key.ToString())
                    {
                        Simbolo p = (Simbolo)datos.Value;
                        if (Tipo.ToUpper().Contains("INT"))
                        {
                            List<int> numros = p.lalista().Select(int.Parse).ToList();
                            numros.Sort();
                            List<String> nueva = new List<String>();
                            for (int i = 0; i < numros.Count; i++)
                            {
                                nueva.Add(numros[i].ToString());
                            }
                            p.NuevaLista(nueva);
                        }else if (Tipo.ToUpper().Contains("DOUBLE"))
                        {
                            List<float> numros = p.lalista().Select(float.Parse).ToList();
                            numros.Sort();
                            List<String> nueva = new List<String>();
                            for (int i = 0; i < numros.Count; i++)
                            {
                                nueva.Add(numros[i].ToString());
                            }
                            p.NuevaLista(nueva);
                        }
                        else
                        {
                            p.lalista().Sort();
                        }
                       
                    }
                }
            }
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

        public void EliminarRepetidos(String id)
        {
            if (Elementos.ContainsKey(id))
            {
                foreach (DictionaryEntry datos in Elementos)
                {
                    if (id == datos.Key.ToString())
                    {
                        Simbolo p = (Simbolo)datos.Value;
                        List<String> NuevaLista = new List<String>();
                        for (int i = 0;i < p.lalista().Count; i++)
                        {
                            if (NuevaLista.Contains(p.lalista()[i]) == false)
                            {
                                NuevaLista.Add((p.lalista()[i]));
                            }
                        }
                        p.NuevaLista(NuevaLista);
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
                        for (int i = 0; i < p.lalista().Count; i++)                        {
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

        public int TotalLista(String id)
        {
            int cantidad = 0;
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
                            cantidad++;
                        }

                    }
                }
            }
            return cantidad;
        }


        public int liMPIARLista(String id)
        {
            int cantidad = 0;
            if (Elementos.ContainsKey(id))
            {
                foreach (DictionaryEntry datos in Elementos)
                {
                    if (id == datos.Key.ToString())
                    {
                        Simbolo p = (Simbolo)datos.Value;
                        p.lalista().Clear();

                    }
                }
            }
            return cantidad;
        }
        public Boolean MODIFICARLista(String id, int posicion, String Valor)
        {
           
            if (Elementos.ContainsKey(id))
            {
                foreach (DictionaryEntry datos in Elementos)
                {
                    if (id == datos.Key.ToString())
                    {
                        Simbolo p = (Simbolo)datos.Value;
                        for(int i = 0; i < p.lalista().Count; i++)
                        {
                            if (i == posicion)
                            {
                                p.lalista()[i] = Valor;
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
