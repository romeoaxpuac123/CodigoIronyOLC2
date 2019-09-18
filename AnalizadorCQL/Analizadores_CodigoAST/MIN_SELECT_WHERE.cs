using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class MIN_SELECT_WHERE : NodoAbstracto
    {
        public MIN_SELECT_WHERE(String Nombre) : base(Nombre)
        {
        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion MIN-select-where");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion MIN-select-where");
            String Tabla = this.Hijos[0].Nombre;
            String BD = entorno.Tabla();
            System.Diagnostics.Debug.WriteLine("Ejecucion select-where tabla->" + Tabla);
            System.Diagnostics.Debug.WriteLine("Ejecucion select-where bd->" + BD);
            List<Simbolo> Campos = new List<Simbolo>();
            List<String> CamposAMostrar = new List<String>();
            Campos = entorno.TodosLosCampos(Tabla, BD);
            List<String> Resultado = new List<String>();
            int totalCampos = entorno.Counter(Tabla, BD);
            Resultado.Clear();
            for (int j = 0; j < totalCampos; j++)
            {
                System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR1 bd->" + j);
                Entorno Prueba = new Entorno();
                String IdTabla = "";
                System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR1 bd->" + Campos.Count);

                for (int i = 0; i < Campos.Count; i++)
                {
                    if (Campos[i].RetornarPosicionObjeto().Replace("BRAY-CAM", "") == (j + 1).ToString())
                    {
                        //System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR1 bd->" + Campos[i].RetornarPosicionObjeto() + "->" + i);
                        Prueba.Agregar(Campos[i].ObtenerId(), Campos[i].ObtenerTipo(), Campos[i].ObtenerValor());
                        IdTabla = Campos[i].RetornarPosicionObjeto();
                    }

                }

                String ValorPrueba = this.Hijos[1].Ejecutar(Prueba);
                System.Diagnostics.Debug.WriteLine(ValorPrueba + "->Romeo");

                if (ValorPrueba.ToUpper().Contains("ERROR"))
                {
                    return "#ERROR  EL CAMPO DE COMPARACION ES INCORRECTO;";
                }
                if (ValorPrueba.ToUpper().Contains("TRUE"))
                {
                    System.Diagnostics.Debug.WriteLine("Aca inicia---->");
                    if (this.ListaID1.Count == 1 && this.ListaID1[0] == "* (Key symbol)")
                    {
                        //Resultado.Add(entorno.MostrarCampos33(Tabla, BD, IdTabla));
                        return "#ERROR * en funcion MIN/MAX";
                    }
                    else
                    {

                        for (int y = 0; y < this.ListaID1.Count; y++)
                        {
                            String Campito = this.ListaID1[y].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (cadena)", "").Replace(" (id2)", "").Replace(" (id)", "");
                            CamposAMostrar.Add(Campito);
                            Boolean Exitencia = false;
                            for (int x = 0; x < Campos.Count; x++)
                            {
                                if (Campos[x].ObtenerId() == Campito)
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
                            Resultado.Add(entorno.MostrarCamposExactos3(Tabla, BD, CamposAMostrar, IdTabla));

                        }
                    }
                }

            }
            String LineaDeCampos2 = "\n\nSELECION-WHERE\n\nTabla->" + Tabla + " BD:->" + BD + "\n";
            System.Diagnostics.Debug.WriteLine(LineaDeCampos2);
            if (this.ListaID1.Count == 1 && this.ListaID1[0] == "* (Key symbol)")
            {
                return "#ERORR EN MIN7MAS-SELECT-WHERE";

            }
            String LineaDeCampos = "\n\nSELECION-WHERE\n\nTabla->" + Tabla + " BD:->" + BD + "\n";
            for (int i = 0; i < this.ListaID1.Count; i++)
            {
                LineaDeCampos = LineaDeCampos + this.ListaID1[i].Replace(" (id)", "") + "         |";
            }
            System.Diagnostics.Debug.WriteLine(LineaDeCampos);
            for (int i = 0; i < Resultado.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(Resultado[i]);
            }
            
            
            String TipoCampo = "";
            for(int i = 0; i< Campos.Count; i++)
            {
                if (Campos[i].ObtenerId() == this.ListaID1[0])
                {
                    TipoCampo = Campos[i].ObtenerTipo();
                    break;
                }
            }
            
            if (TipoCampo.ToUpper() == "INT")
            {
                List<int> ListaN = new List<int>();
                for(int i = 0; i < Resultado.Count; i++)
                {
                    ListaN.Add(Int32.Parse(Resultado[i]));
                }
                Resultado.Sort();
                if(this.AutoIncrmentable2 == 2)
                {
                    Resultado.Reverse();
                }
                if (this.AutoIncrmentable2 == 3)
                {
                    int total = 0;
                    for(int i = 0; i < ListaN.Count; i++)
                    {
                        total = total + ListaN[i];
                    }
                    return total.ToString();
                }
                if (this.AutoIncrmentable2 == 4)
                {
                    int total = 0;
                    for (int i = 0; i < ListaN.Count; i++)
                    {
                        total = total + ListaN[i];
                    }
                    return (total/ListaN.Count).ToString();
                }
                this.TipoDato = "entero";
                return Resultado[0].ToString();
            }
            
            if (TipoCampo.ToUpper() == "DATE")
            {
                List<DateTime> ListaN = new List<DateTime>();
                for (int i = 0; i < Resultado.Count; i++)
                {
                    ListaN.Add(DateTime.Parse(Resultado[i]));
                }
                ListaN.Sort();
                if (this.AutoIncrmentable2 == 2)
                {
                    ListaN.Reverse();
                }
                this.TipoDato = "entero";
                return "'"+ListaN[0].ToString()+"'";
            }
            

            return "#ERROR EN MIN SELEC WHERE";
        }
    }
}