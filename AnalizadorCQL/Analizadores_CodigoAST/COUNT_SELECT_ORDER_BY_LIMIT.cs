using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class COUNT_SELECT_ORDER_BY_LIMIT:NodoAbstracto
    {
        public COUNT_SELECT_ORDER_BY_LIMIT(String Nombre) : base(Nombre)
        {

        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion cOUNTER_SELECT_ORDER_BY_LIMIT");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion cOUNTER_SELECT_ORDER_BY_LIMIT");
            String Tabla = this.Hijos[0].Nombre;
            String BD = entorno.Tabla();
            entorno.Devolver2();
            System.Diagnostics.Debug.WriteLine("Ejecucion SELECT_ORDER_BY_LIMIT tabla->" + Tabla);
            System.Diagnostics.Debug.WriteLine("Ejecucion SELECT_ORDER_BY_LIMIT bd->" + BD);
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
            int numero = 0;
            String Limite = this.Hijos[1].Ejecutar(entorno);
            int ellimite = Int32.Parse(Limite.Replace(" (id)", "").Replace(" (id2)", "").Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", ""));

            if (ellimite > entorno.Counter(Tabla, BD))
            {
                return "#ERROR EL LIMITE SOBREPASA LOS CAMPOS";
            }

            if (this.ListaID1.Count == 1 && this.ListaID1[0] == "* (Key symbol)")
            {
                //entorno.MostrarDiccionario2(ellimite);
                return ellimite.ToString();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("\n\n\n\nDICCIONARIO-Tabla->\n\n");
                String Cadena = "";
                for (int x = 0; x < this.ListaID1.Count; x++)
                {
                    Cadena = Cadena + this.ListaID1[x].Replace(" (id)", "") + "             |  ";
                }
                System.Diagnostics.Debug.WriteLine(Cadena);
                //entorno.MostrarDiccionario2(this.ListaID1, ellimite);
                return ellimite.ToString();
            }

        }
    }
}