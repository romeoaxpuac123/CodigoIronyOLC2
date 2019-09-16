using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class INSERSCION_SIMPLE : NodoAbstracto
    {

        public INSERSCION_SIMPLE(String Nombre) : base(Nombre)
        {
        }
        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR1");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR1");
            String Tabla = this.Hijos[0].Nombre;
            String BD = entorno.Tabla();
            List<Simbolo> Campos = new List<Simbolo>();
            List<Simbolo> Campos2 = new List<Simbolo>();
            Campos = entorno.TablaBD(Tabla, BD);
            System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR1 tabla->" + Tabla);
            System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR1 bd->" + BD);
            String IdCampo = "BRAY-CAM" + (entorno.CantidadDeCAMPOS()+1);
            List<String> Llaves = new List<String>();
            Llaves = entorno.LLaves(Tabla, BD);
            if (Campos.Count == this.ListaID1.Count)
            {
                for (int i = 0; i < this.ListaID1.Count; i++)
                {
                     String TipoRetorno = this.ListaID1[i];
                    String TipoRetornox = "";
                    System.Diagnostics.Debug.WriteLine(this.ListaID1[i]);
                    /// verificando el tipo de cada uno de los elementos y se agregará a una lista
                    if (TipoRetorno.ToUpper().Contains("NUMERO"))
                    {
                         TipoRetornox = "int";
                    }
                    else if (TipoRetorno.ToUpper().Contains("DECIMAL"))
                    {
                        TipoRetornox = "double";
                    }
                    else if (TipoRetorno.ToUpper().Contains("CADENA"))
                    {
                        TipoRetornox = "String";
                    }
                    else if (TipoRetorno.ToUpper().Contains("(KEYWORD)") && (TipoRetorno.ToUpper().Contains("TRUE") || TipoRetorno.ToUpper().Contains("FALSE")))
                    {
                        TipoRetornox = "Booleano";
                    }
                    else if (TipoRetorno.ToUpper().Contains("FECHAS"))
                    {
                        TipoRetornox = "Date";
                    }
                    else if (TipoRetorno.ToUpper().Contains("HORA"))
                    {
                        TipoRetornox = "Time";
                    }
                    else if (TipoRetorno.ToUpper().Contains("(ID2)"))
                    {
                        TipoRetornox = entorno.ObtenerTipo(TipoRetorno.Replace(" (id2)", ""));
                    }
                    System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR1 parametro " + i + " ValorNuevo->" + this.ListaID1[i] + " TipoNuevo->"+ TipoRetornox +    " Tipo->" + Campos[i].ObtenerTipo() + " Nombre->" + Campos[i].ObtenerId());
                    if (Llaves.Contains(Campos[i].ObtenerId()) == true)
                    {
                        String Valor = this.ListaID1[i].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (cadena)", "").Replace(" (id2)", "");
                        if(entorno.ValorPrimaryKey(Tabla,BD, Campos[i].ObtenerId(),Valor) == true)
                        {
                            return "#ERROR Llave primaria Duplicada";
                        }
                        System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR1 es llave primaria");
                    }
                    if (TipoRetornox.ToUpper() == Campos[i].ObtenerTipo().ToUpper().Replace("LIST","").Replace("SET","").Replace("<","").Replace(">",""))
                    {
                        string Valor = this.ListaID1[i].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (cadena)", "").Replace(" (id2)","");
                        if (Campos[i].ObtenerTipo() == "int")
                        {
                            if (Valor.Length == 1)
                            {
                                Valor = "000000" + Valor;
                            }
                            if (Valor.Length == 2)
                            {
                                Valor = "00000" + Valor;
                            }
                            if (Valor.Length == 3)
                            {
                                Valor = "0000" + Valor;
                            }
                            if (Valor.Length == 4)
                            {
                                Valor = "000" + Valor;
                            }
                            if (Valor.Length == 5)
                            {
                                Valor = "00" + Valor;
                            }
                            if (Valor.Length == 6)
                            {
                                Valor = "0" + Valor;
                            }
                        }
                        Simbolo Campito = new Simbolo(Campos[i].ObtenerId(),Valor, Campos[i].ObtenerTipo());
                        Campos2.Add(Campito);
                    }
                    else
                    {
                        return "#ERROR los campos no coinciden";
                    }

                }
            }
            else
            {
                return "#ERROR la cantidad de campos es distinta;";
            }
            entorno.AgregarCampo(IdCampo, Tabla, BD, Campos2);
            entorno.MostrarUTablas(Tabla, BD);
            entorno.MostrarCampos(Tabla, BD);

            return "INSERTAR1";
        }
    }
}