﻿using System;
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
        public List<Object> Objetos = new List<Object>();
        public Hashtable Elementos;
        public String UseTabla = "NULITO";

        public Entorno()
        {
            Elementos = new Hashtable();
        }

        public void LaBD(String tabla)
        {
            this.UseTabla = tabla;
        }
        public String Tabla()
        {
            return this.UseTabla;
        }

        public void AgregarObjeto(Object objetodeclarado)
        {
            Objetos.Add(objetodeclarado);
        }

        public void MostrarObjetos()
        {
            for(int i = 0; i< Objetos.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine("EL OBJETO -> " + Objetos[i].ToString());
            }
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

        public Boolean AgregarObjeto(String id, String valor, List<Simbolo> ElementosUT,String tipo)
        {
            if (!Elementos.ContainsKey(id))
            {
                Simbolo sim = new Simbolo(id, valor, ElementosUT,tipo) ;
                Elementos.Add(id, sim);
                System.Diagnostics.Debug.WriteLine("SE agregó objetoAVici -> " + id);
                return true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("La variables ya existe -> " + id);
                return false;
            }

        }

        public void MostrarObjetosx()
        {
           
            foreach (DictionaryEntry datos in Elementos)
            {
                
                    Simbolo p = (Simbolo)datos.Value;
                if (p.ObtenerValor() == "OBJETO_BRAY" )
                {
                    if(p.ListaElementos() == null)
                    {
                        System.Diagnostics.Debug.WriteLine(p.ObtenerId() + "<--->" + p.ObtenerTipo());
                        System.Diagnostics.Debug.WriteLine("INICIOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine(p.ObtenerId() + "<--->" + p.ObtenerTipo());
                        System.Diagnostics.Debug.WriteLine("INICIOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
                        for (int i = 0; i < p.ListaElementos().Count; i++)
                        {
                            System.Diagnostics.Debug.WriteLine(p.ListaElementos()[i].ObtenerId() + "--" + p.ListaElementos()[i].ObtenerTipo() + "--" + p.ListaElementos()[i].ObtenerValor());
                        }
                    }
                   
                }
            }
        }

        public List<Simbolo> ElementosUT (String id)
        {
            
            List<Simbolo> Listaxx = new List<Simbolo>();
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    Listaxx = p.ListaElementos();
                }
            }
            return Listaxx;
        }

        public Boolean ExisteVariable(String id)
        {
            if (Elementos.ContainsKey(id) ==true)
            {
                
                return true;
            }
            else
            {
                
                return false;
            }
        }
        #region PROCEDIMIENTOS

        public Boolean AgregarProcedimiento(String id, String NombreFuncion, String Tipo, List<String> Listax, List<String> Listaxy, NodoAbstracto nuevo)
        {
            if (!Elementos.ContainsKey(id))
            {
                Simbolo sim = new Simbolo(id, NombreFuncion, Tipo, Listax, Listaxy, nuevo);
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
        public Boolean ExisteProcedimiento(String Nombre)
        {
            String id = "PROC-BRAY";
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    if (p.NombreFuncionGuardada().ToString().ToUpper() == Nombre.ToUpper())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public int CantidadDeProcedimientos()
        {
            String id = "PROC-BRAY";
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
        public Boolean ExisteListaConLaMismaCantidadDeParametrosEnProc(String Nombre, int elementos)
        {

            String id = "PROC-BRAY";
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    System.Diagnostics.Debug.WriteLine(Nombre + ";");
                    Simbolo p = (Simbolo)datos.Value;
                    System.Diagnostics.Debug.WriteLine(p.lalista().Count + ";");
                    if (p.lalista().Count == elementos)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public Boolean MismosParametrosEnProc(String Nombre, List<String> Listax)
        {
            String id = "PROC-BRAY";

            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    if (p.NombreFuncionGuardada().ToString().ToUpper() == Nombre.ToUpper())
                    {
                        if (p.lalista().Count == Listax.Count)
                        {
                            for (int i = 0; i < Listax.Count; i++)
                            {
                                string[] separadas;
                                separadas = Listax[i].Split('*');
                                if (p.lalista()[i].ToUpper().Contains(separadas[0].ToUpper()) == true)
                                {
                                    return true;
                                }
                                else
                                {
                                    for (int j = 0; j < p.lalista().Count; j++)
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
        public void MostrarProcedimientos()
        {
            String id = "PROC-BRAY";
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    System.Diagnostics.Debug.WriteLine("NombreFuncion -> " + datos.Key.ToString() + " funcion " + p.NombreFuncionGuardada() + " #Par " + p.lalista().Count  + " #retu " + p.lalista2().Count );
                }
            }
        }
        public Boolean MismosParametros2Proc(String Nombre, List<String> Listax)
        {
            String id = "PROC-BRAY";
            Boolean Mismos = false;
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    if (p.NombreFuncionGuardada().ToString().ToUpper() == Nombre.ToUpper())
                    {
                        if (p.lalista().Count == Listax.Count)
                        {

                            for (int i = 0; i < Listax.Count; i++)
                            {
                                System.Diagnostics.Debug.WriteLine(p.lalista()[i] + "JJ" + Listax[i]);
                                if (p.lalista()[i].ToUpper().Contains(Listax[i].ToUpper()) == true)
                                {
                                    Mismos = true;
                                }
                                else
                                {
                                    Mismos = false;
                                }
                            }

                        }
                    }
                }
            }

            return Mismos;
        }
        public List<String> MismosParametros3Proc(String Nombre, List<String> Listax)
        {
            String id = "PROC-BRAY";
            Boolean Mismos = false;
            List<String> Listaxx = new List<String>();
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    if (p.NombreFuncionGuardada().ToString().ToUpper() == Nombre.ToUpper())
                    {
                        if (p.lalista().Count == Listax.Count)
                        {

                            for (int i = 0; i < Listax.Count; i++)
                            {
                                System.Diagnostics.Debug.WriteLine(p.lalista()[i] + "JJ" + Listax[i]);
                                if (p.lalista()[i].ToUpper().Contains(Listax[i].ToUpper()) == true)
                                {
                                    Mismos = true;
                                    Listaxx = p.lalista();
                                }
                                else
                                {
                                    Mismos = false;
                                }
                            }

                        }
                    }
                }
            }
            return Listaxx;

        }
        public NodoAbstracto ElNodoParametrosProc(String Nombre, List<String> Listax)
        {
            String id = "PROC-BRAY";
            Boolean Mismos = false;
            NodoAbstracto nodo = null;
            List<String> Listaxx = new List<String>();
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    if (p.NombreFuncionGuardada().ToString().ToUpper() == Nombre.ToUpper())
                    {
                        if (p.lalista().Count == Listax.Count)
                        {

                            for (int i = 0; i < Listax.Count; i++)
                            {
                                System.Diagnostics.Debug.WriteLine(p.lalista()[i] + "JJ" + Listax[i]);
                                if (p.lalista()[i].ToUpper().Contains(Listax[i].ToUpper()) == true)
                                {
                                    Mismos = true;
                                    nodo = p.Sentencias();
                                }
                                else
                                {
                                    Mismos = false;
                                }
                            }

                        }
                    }
                }
            }
            return nodo;

        }
        #endregion


        #region USUARIOS
        public int CantidadDeUsuarios()
        {
            String id = "BRAY-US";
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

        public Boolean AgregarUsuario(String id, String NombreUsuario, String pass)
        {
            if (!Elementos.ContainsKey(id))
            {
                Simbolo sim = new Simbolo(id, NombreUsuario, pass, 1);
                Elementos.Add(id, sim);
                System.Diagnostics.Debug.WriteLine("EL USUARIO  se agregó -> " + id);
                return true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("EL USUARIO ya existe -> " + id);
                return false;
            }
        }

        public Boolean ExisteUsuario(String Nombre)
        {
            String id = "BRAY-US";
            Boolean Mismos = false;
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    if(p.Nombre().ToUpper() == Nombre.ToUpper())
                    {
                        Mismos = true;
                    }
                  
                }
            }

            return Mismos;
        }

        public void MostrarUsuarios()
        {
            String id = "BRAY-US";
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    System.Diagnostics.Debug.WriteLine("USUARIOS->" + p.Nombre()  + " Password:->" + p.Pass());

                }
            }
        }

        #endregion

        #region BASE DE DATOS
        public int CantidadDeBD()
        {
            String id = "BRAY-BD";
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
        public Boolean AgregarBD(String id, String NombreUsuario)
        {
            if (!Elementos.ContainsKey(id))
            {
                Simbolo sim = new Simbolo(id, NombreUsuario);
                Elementos.Add(id, sim);
                System.Diagnostics.Debug.WriteLine("LA BD  se agregó -> " + id);
                return true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("LA BD ya existe -> " + id);
                return false;
            }
        }
        public Boolean ExisteBD(String Nombre)
        {
            String id = "BRAY-BD";
            Boolean Mismos = false;
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    if (p.Nombre().ToUpper() == Nombre.ToUpper())
                    {
                        Mismos = true;
                    }

                }
            }

            return Mismos;
        }
        public void MostrarBD()
        {
            String id = "BRAY-BD";
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    System.Diagnostics.Debug.WriteLine("USUARIOS->" + p.Nombre() + " Password:->" + p.Pass());

                }
            }
        }

        #endregion

        #region FUNCIONES
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

        public void NuevasFunciones (Entorno x)
        {
            String id = "BRAY-FUNC";
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    //System.Diagnostics.Debug.WriteLine("NombreFuncion -> " + datos.Key.ToString() + " funcion " + p.NombreFuncionGuardada() + " #Par " + p.lalista().Count);
                    Boolean y = x.AgregarFuncion(datos.Key.ToString(), p.NombreFuncionGuardada(), p.ObtenerTipo(),p.lalista(),p.Sentencias());
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


        public Boolean MismosParametros2(String Nombre, List<String> Listax)
        {
            String id = "BRAY-FUNC";
            Boolean Mismos = false;
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    if (p.NombreFuncionGuardada().ToString().ToUpper() == Nombre.ToUpper())
                    {
                        if (p.lalista().Count == Listax.Count)
                        {

                            for(int i =0; i<Listax.Count; i++)
                            {
                                System.Diagnostics.Debug.WriteLine(p.lalista()[i] + "JJ" + Listax[i]);
                                if(p.lalista()[i].ToUpper().Contains(Listax[i].ToUpper()) == true)
                                {
                                    Mismos = true;
                                }
                                else
                                {
                                    Mismos = false;
                                }
                            }

                        }
                    }
                }
            }

            return Mismos;
        }


        public List<String> MismosParametros3(String Nombre, List<String> Listax)
        {
            String id = "BRAY-FUNC";
            Boolean Mismos = false;
            List<String> Listaxx = new List<String>();
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    if (p.NombreFuncionGuardada().ToString().ToUpper() == Nombre.ToUpper())
                    {
                        if (p.lalista().Count == Listax.Count)
                        {

                            for (int i = 0; i < Listax.Count; i++)
                            {
                                System.Diagnostics.Debug.WriteLine(p.lalista()[i] + "JJ" + Listax[i]);
                                if (p.lalista()[i].ToUpper().Contains(Listax[i].ToUpper()) == true)
                                {
                                    Mismos = true;
                                    Listaxx = p.lalista();
                                }
                                else
                                {
                                    Mismos = false;
                                }
                            }

                        }
                    }
                }
            }
            return Listaxx;
            
        }

        public NodoAbstracto ElNodoParametros(String Nombre, List<String> Listax)
        {
            String id = "BRAY-FUNC";
            Boolean Mismos = false;
            NodoAbstracto nodo = null;
            List<String> Listaxx = new List<String>();
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    if (p.NombreFuncionGuardada().ToString().ToUpper() == Nombre.ToUpper())
                    {
                        if (p.lalista().Count == Listax.Count)
                        {

                            for (int i = 0; i < Listax.Count; i++)
                            {
                                System.Diagnostics.Debug.WriteLine(p.lalista()[i] + "JJ" + Listax[i]);
                                if (p.lalista()[i].ToUpper().Contains(Listax[i].ToUpper()) == true)
                                {
                                    Mismos = true;
                                    nodo = p.Sentencias();
                                }
                                else
                                {
                                    Mismos = false;
                                }
                            }

                        }
                    }
                }
            }
            return nodo;

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
                    System.Diagnostics.Debug.WriteLine(Nombre + ";");
                    Simbolo p = (Simbolo)datos.Value;
                    System.Diagnostics.Debug.WriteLine(p.lalista().Count + ";");
                    if (p.lalista().Count == elementos)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        #endregion

        #region PERMISOS
        public int CantidadPERMISOS()
        {
            String id = "BRAY-PER";
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
        public Boolean AgregarPermiso(String id, String NombreUsuario, String BaseDeDatos)
        {
            if (!Elementos.ContainsKey(id))
            {
                Simbolo sim = new Simbolo(id, BaseDeDatos, NombreUsuario, true);
                Elementos.Add(id, sim);
                System.Diagnostics.Debug.WriteLine("EL USUARIO  se agregó -> " + id);
                return true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("EL USUARIO ya existe -> " + id);
                return false;
            }
        }
        public Boolean ExistePermiso(String Nombre, String BD)
        {
            String id = "BRAY-PER";
            Boolean Mismos = false;
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    if ( (p.NombreBDP().ToUpper() == Nombre.ToUpper()) && (p.UsuarioBDP().ToUpper() == BD.ToUpper() ))
                    {
                        Mismos = true;
                    }

                }
            }

            return Mismos;
        }
        public void MostrarPermisos()
        {
            String id = "BRAY-PER";
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    System.Diagnostics.Debug.WriteLine("USUARIOS->" + p.NombreBDP() + " Password:->" + p.UsuarioBDP());

                }
            }
        }
        public String idPermiso(String Nombre, String BD)
        {
            String id = "BRAY-PER";
            String Mismos = "NOT";
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    if ((p.NombreBDP().ToUpper() == Nombre.ToUpper()) && (p.UsuarioBDP().ToUpper() == BD.ToUpper()))
                    {
                        return  p.ObtenerId();
                    }

                }
            }

            return Mismos;
        }

        #endregion

        #region Tablas
        public int CantidadDeTablas()
        {
            String id = "BRAY-TAB";
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
        public Boolean AgregarTabla(String id, String NombreTabla, String BD, List<Simbolo> Simblosx, List<String> ListaPK)
        {
            if (!Elementos.ContainsKey(id))
            {
                Simbolo sim = new Simbolo(id, NombreTabla,BD,Simblosx,ListaPK);
                Elementos.Add(id, sim);
                System.Diagnostics.Debug.WriteLine("EL USUARIO  se tabla -> " + NombreTabla + " A BD->"+BD);
                return true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("la tabla ya existe -> " + NombreTabla + " en bd->" + BD);
                return false;
            }
        }
        public Boolean ExisteTabla(String Nombre, String BD)
        {
            String id = "BRAY-TAB";
            Boolean Mismos = false;
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    if ( (p.Nombre().ToUpper() == Nombre.ToUpper()) && ( p.NombreBDP().ToUpper() == BD.ToUpper()))
                    {
                        Mismos = true;
                    }

                }
            }

            return Mismos;
        }
        public void MostrarUTablas()
        {
            String id = "BRAY-TAB";
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    System.Diagnostics.Debug.WriteLine("\n\n\n\nTabla->" + p.Nombre() + " BD:->" + p.NombreBDP());
                    String LLaves = "";
                    for(int i = 0; i < p.lalista().Count; i++)
                    {
                        LLaves = LLaves + p.lalista()[i] + ",";
                    }
                    String LosCampos = "";
                    System.Diagnostics.Debug.WriteLine("Llaves->" + LLaves);
                    for(int i = 0; i < p.ListaElementos().Count; i++)
                    {
                        LosCampos = LosCampos + p.ListaElementos()[i].ObtenerId() + " " + p.ListaElementos()[i].ObtenerTipo() + "  |  ";
                    }
                    System.Diagnostics.Debug.WriteLine(LosCampos);

                }
            }
        }
        public void MostrarUTablas(String tabla, String BD)
        {
            String id = "BRAY-TAB";
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    if(p.Nombre().ToUpper() == tabla.ToUpper() && p.NombreBDP().ToUpper() == BD.ToUpper())
                    {
                        System.Diagnostics.Debug.WriteLine("\n\n\n\nTabla->" + p.Nombre() + " BD:->" + p.NombreBDP());
                        String LLaves = "";
                        for (int i = 0; i < p.lalista().Count; i++)
                        {
                            LLaves = LLaves + p.lalista()[i] + ",";
                        }
                        String LosCampos = "";
                        System.Diagnostics.Debug.WriteLine("Llaves->" + LLaves);
                        for (int i = 0; i < p.ListaElementos().Count; i++)
                        {
                            LosCampos = LosCampos + p.ListaElementos()[i].ObtenerId() + " " + p.ListaElementos()[i].ObtenerTipo() + "  |  ";
                        }
                        System.Diagnostics.Debug.WriteLine(LosCampos);
                    }
                   

                }
            }
        }

        public List<Simbolo> TablaBD(String Nombre, String BD)
        {
            String id = "BRAY-TAB";
            Boolean Mismos = false;
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    if ((p.Nombre().ToUpper() == Nombre.ToUpper()) && (p.NombreBDP().ToUpper() == BD.ToUpper()))
                    {
                        return p.ListaElementos();
                    }

                }
            }
            return null;
        }

        public List<String> LLaves(String Nombre, String BD)
        {
            String id = "BRAY-TAB";
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    if ((p.Nombre().ToUpper() == Nombre.ToUpper()) && (p.NombreBDP().ToUpper() == BD.ToUpper()))
                    {
                        return p.lalista();
                    }

                }
            }
            return null;
        }
        #endregion

        #region Campos
        public int CantidadDeCAMPOS()
        {
            String id = "BRAY-CAM";
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
        public Boolean AgregarCampo(String id, String NombreTabla, String BD, List<Simbolo> Simblosx)
        {
            if (!Elementos.ContainsKey(id))
            {
                Simbolo sim = new Simbolo(id, NombreTabla, BD, Simblosx);
                Elementos.Add(id, sim);
                System.Diagnostics.Debug.WriteLine("se agrego campo a -> " + NombreTabla + " A BD->" + BD);
                return true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("la tabla ya existe -> " + NombreTabla + " en bd->" + BD);
                return false;
            }
        }
        public void MostrarCampos(String tabla, String BD)
        {
            String id = "BRAY-CAM";
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    String Cadena = "";
                    Simbolo p = (Simbolo)datos.Value;
                    //System.Diagnostics.Debug.WriteLine("\n\n\n\nTabla->" + p.Nombre() + " BD:->" + p.NombreBDP());
                    if(p.Nombre() == tabla && p.NombreBDP() == BD)
                    {
                        for(int i = 0; i < p.ListaElementos().Count; i++)
                        {
                            Cadena = Cadena + p.ListaElementos()[i].ObtenerValor() + "             |  ";
                        }
                    }
                    System.Diagnostics.Debug.WriteLine(Cadena);

                }
            }
        }

        public Boolean ValorPrimaryKey(String tabla, String BD, String Campo, String Valor)
        {
            String id = "BRAY-CAM";
            foreach (DictionaryEntry datos in Elementos)
            {
                if (datos.Key.ToString().Contains(id))
                {
                    Simbolo p = (Simbolo)datos.Value;
                    //System.Diagnostics.Debug.WriteLine("\n\n\n\nTabla->" + p.Nombre() + " BD:->" + p.NombreBDP());
                    if (p.Nombre() == tabla && p.NombreBDP() == BD)
                    {
                        for (int i = 0; i < p.ListaElementos().Count; i++)
                        {
                            if(p.ListaElementos()[i].ObtenerId().ToUpper() == Campo.ToUpper())
                            {
                                if (p.ListaElementos()[i].ObtenerValor().ToUpper() == Valor.ToUpper())
                                {
                                    return true;
                                }
                            }
                        }
                    }
                    

                }
            }
            return false;
        }
        #endregion


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
               // System.Diagnostics.Debug.WriteLine("La variableeeee ->" + x.Key.ToString());
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



        public String PosicionLista2(String id, int pos)
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
                            if (i == pos)
                            {
                                //p.lalista().Remove(valor);
                                return p.lalista()[i];
                            }
                        }

                    }
                }
            }
            return "null";
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
