using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using AnalizadorCQL.Analizadores_Codigo;
using System.IO;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class CURSOR_SELECT_WHERE_ORDER_BY : NodoAbstracto
    {
        public CURSOR_SELECT_WHERE_ORDER_BY(String Nombre) : base(Nombre)
        {
        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion CURSOR_SELECT_WHERE_ORDER_BYT");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion CURSOR_SELECT_WHERE_ORDER_BYT");
            String Tabla = this.Hijos[0].Nombre;
            String BD = entorno.Tabla();
            entorno.Devolver2();
            System.Diagnostics.Debug.WriteLine("Ejecucion select-ORDER_BYE tabla->" + Tabla);
            System.Diagnostics.Debug.WriteLine("Ejecucion select-ORDER_BYE bd->" + BD);
            entorno.AgregarADiccionario(Tabla, BD);


            List<Simbolo> Campos = new List<Simbolo>();
            Campos = entorno.TablaBD(Tabla, BD);
            if (this.ListaID1.Count == 1 && this.ListaID1[0] == "* (Key symbol)")
            {
                //entorno.MostrarUTablas2(Tabla, BD);
                //entorno.MostrarCampos2(Tabla, BD);
                //return "SELECT SIMPLE";
            }
            else
            {
                for (int i = 0; i < this.ListaID1.Count; i++)
                {
                    Boolean Existencia = false;
                    for (int x = 0; x < Campos.Count; x++)
                    {
                        //System.Diagnostics.Debug.WriteLine(this.ListaID1[i].Replace(" (id)", "") + "->" + Campos[x].ObtenerId());
                        if (this.ListaID1[i].Replace(" (id)", "") == Campos[x].ObtenerId())
                        {
                            Existencia = true;
                        }

                    }
                    if (Existencia == false)
                    {
                        return "#ERROR PARAMETRO SELEC NO EXISTE";
                    }
                }
            }
            for (int i = 0; i < this.ListaR1.Count; i++)
            {
                string[] separadas;
                separadas = this.ListaR1[i].Split(',');
                Boolean Existencia = false;
                for (int x = 0; x < Campos.Count; x++)
                {
                    //System.Diagnostics.Debug.WriteLine(this.ListaR1[i].Replace(" (id)", "") + "->" + Campos[x].ObtenerId());
                    if (separadas[0] == Campos[x].ObtenerId())
                    {
                        Existencia = true;
                    }

                }
                if (Existencia == false)
                {
                    return "#ERROR PARAMETRO order by NO EXISTE";
                }
            }
            entorno.MostrarDiccionario();
            Dictionary<String, Simbolo> ResultadoOrdenar = new Dictionary<String, Simbolo>();
            Dictionary<String, String> OrdenarrDiccionario;
            for (int i = 0; i < this.ListaR1.Count; i++)
            {
                entorno.Devolver2();
                System.Diagnostics.Debug.WriteLine("Ejecucion select-ORDER_BYE Campo a ordenarr->" + i + "->" + this.ListaR1[i]);
                List<String> Auxiliar = new List<String>();
                string[] separadas;
                separadas = this.ListaR1[i].Split(',');
                OrdenarrDiccionario = entorno.OrdenarrDiccionario(separadas[0]);

                ArrayList aKeys = new ArrayList(OrdenarrDiccionario.Values);
                aKeys.Sort();
                if (separadas[1].ToUpper().Contains("DESC"))
                {
                    aKeys.Reverse();
                }



                for (int j = 0; j < OrdenarrDiccionario.Count; j++)
                {
                    //System.Diagnostics.Debug.WriteLine("Ejecucion select-ORDER_BYE HASH ->" + aKeys[j]);

                    foreach (KeyValuePair<String, String> kvp in OrdenarrDiccionario)
                    {
                        if (kvp.Value == aKeys[j].ToString())
                        {
                            if (Auxiliar.Contains(kvp.Key) == false)
                            {
                                System.Diagnostics.Debug.WriteLine("Ejecucion select-ORDER_BYE HASH ->" + aKeys[j] + "->" + kvp.Key.ToString());
                                Auxiliar.Add(kvp.Key);
                                entorno.OrdenarDiccionarioFinal(kvp.Key.ToString());
                            }

                        }
                    }

                }

                //entorno.IgualarDic();
                entorno.MostrarDiccionario2x();

                entorno.LImpiar2();
            }
            //System.Diagnostics.Debug.WriteLine("soy romoeit");
            //entorno.MostrarDiccionario2();


            #region parte where
            //List<Simbolo> Campos = new List<Simbolo>();
            List<String> CamposAMostrar = new List<String>();
            List<Simbolo> Camposx = entorno.TodosLosCampos2(Tabla, BD);
            List<String> Resultado = new List<String>();
            List<String> Lasllaves = new List<String>();
            int totalCampos = entorno.Counter(Tabla, BD);
            for (int j = 0; j < totalCampos; j++)
            {
                System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR1 bd->" + j);
                Entorno Prueba = new Entorno();
                String IdTabla = "";
                //System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR1 bd->" + Campos.Count);
                String VAriableCampo = Camposx[j].RetornarPosicionObjeto();
                for (int i = 0; i < Camposx.Count; i++)
                {
                    //->  System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR1 bd-55555>" + Camposx[i].RetornarPosicionObjeto());
                    if (Lasllaves.Contains(Camposx[i].RetornarPosicionObjeto()) == false)
                    {
                        Lasllaves.Add(Camposx[i].RetornarPosicionObjeto());
                    }
                    //Prueba.Agregar(Camposx[i].ObtenerId(), Camposx[i].ObtenerTipo(), Camposx[i].ObtenerValor());
                    //IdTabla = Camposx[i].RetornarPosicionObjeto();

                }
                for (int i = 0; i < Camposx.Count; i++)
                {
                    //->  System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR1 bd-55555>" + Camposx[i].RetornarPosicionObjeto());
                    if (Camposx[i].RetornarPosicionObjeto() == Lasllaves[j])
                    {
                        Prueba.Agregar(Camposx[i].ObtenerId(), Camposx[i].ObtenerTipo(), Camposx[i].ObtenerValor());
                        IdTabla = Camposx[i].RetornarPosicionObjeto();
                    }
                    //Prueba.Agregar(Camposx[i].ObtenerId(), Camposx[i].ObtenerTipo(), Camposx[i].ObtenerValor());
                    //IdTabla = Camposx[i].RetornarPosicionObjeto();

                }

                String ValorPrueba = this.Hijos[1].Ejecutar(Prueba);
                if (ValorPrueba.ToUpper().Contains("ERROR"))
                {
                    return "#ERROR  EL CAMPO DE COMPARACION ES INCORRECTO;";
                }
                if (ValorPrueba.ToUpper().Contains("TRUE"))
                {
                    System.Diagnostics.Debug.WriteLine("Aca inicia---->");
                    if (this.ListaID1.Count == 1 && this.ListaID1[0] == "* (Key symbol)")
                    {
                        Resultado.Add(entorno.MostrarCampos33DiccionarioArchivo(Tabla, BD, IdTabla));

                    }
                    else
                    {
                        for (int y = 0; y < this.ListaID1.Count; y++)
                        {
                            String Campito = this.ListaID1[y].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (cadena)", "").Replace(" (id2)", "").Replace(" (id)", "");
                            CamposAMostrar.Add(Campito);
                            Boolean Exitencia = false;
                            for (int x = 0; x < Camposx.Count; x++)
                            {
                                if (Camposx[x].ObtenerId() == Campito)
                                {
                                    Exitencia = true;
                                    CamposAMostrar.Add(Campito);
                                }
                            }
                            if (Exitencia == false)
                            {
                                return "#ERROR el campo a mostrar no existe;";
                            }
                        }
                        if (ValorPrueba.ToUpper().Contains("TRUE"))
                        {
                            Resultado.Add(entorno.MostrarCamposExactos3DiccionarioArchivo(Tabla, BD, CamposAMostrar, IdTabla));

                        }
                    }
                }


            }
            String texto = "";
            for (int i = 0; i < Resultado.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(Resultado[i]);
                texto = texto + Resultado[i] + "\n";
            }
            #endregion
            String rutaCompleta = @"C:\Users\Bayyron\Desktop\RoshiEIrack\" + entorno.CursorEnUso() + ".txt";
            //System.Diagnostics.Debug.WriteLine(texto);
            //System.Diagnostics.Debug.WriteLine(rutaCompleta);
            if (File.Exists(rutaCompleta))
            {
                File.Delete(rutaCompleta);
            }

            using (StreamWriter mylogs = File.AppendText(rutaCompleta))         //se crea el archivo
            {
                mylogs.WriteLine(texto);
                mylogs.Close();
            }
            return "CURSOR-SELECT-WHERE-ORDER-BY";
        }
    }
}