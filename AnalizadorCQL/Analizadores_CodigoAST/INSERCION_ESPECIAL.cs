using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class INSERCION_ESPECIAL : NodoAbstracto
    {
        public INSERCION_ESPECIAL(String Nombre) : base(Nombre)
        {
        }
        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR2");
        
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR2");
            String Tabla = this.Hijos[0].Nombre;
            String BD = entorno.Tabla();
            System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR2 tabla->" + Tabla);
            System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR2 bd->" + BD);
            List<Simbolo> LosCampos = new List<Simbolo>();
            LosCampos = entorno.TablaBD(Tabla, BD);
            if (this.ListaID1.Count == this.ListaR1.Count)
            {
                for (int i = 0; i < this.ListaID1.Count; i++) {
                    String Campo = this.ListaID1[i].Replace(" (id)", "");
                    String Valor = this.ListaR1[i].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (cadena)", "").Replace(" (id2)", "");
                    int ValorCounter = entorno.Counter(Tabla, BD);
                    System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR2 Campo->" + Campo + " Valor->" + Valor);
                    Boolean CampoExistente = false;
                    for (int j = 0; j < LosCampos.Count; j++)
                    {
                        //System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR2 Campo->" + LosCampos[i].ObtenerId() + ".." + Campo);
                        if (LosCampos[j].ObtenerId() == Campo)
                        {
                            if(LosCampos[j].ObtenerTipo().ToUpper() == "COUNTER")
                            {
                                return "#ERROR Un parametro ES DE TIPO COUNTER";
                            }
                            CampoExistente = true;
                        }
                    }
                    if(CampoExistente == false)
                    {
                        return "#ERROR Un parametro no existe en la tabla";
                    }


                }
            }
            else
            {
                return "#ERROR la cantidad de parametros no coinide";
            }
            List<String> LLaves = entorno.LLaves(Tabla, BD);
            List<Simbolo> LosCampos2 = new List<Simbolo>();
            //Asigando a cada parametro de la tabla un valor
            for (int h = 0; h<LosCampos.Count; h++)
            {
                String ValorReal = "null";
                for (int i = 0; i < this.ListaID1.Count; i++)
                {
                    String Campo = this.ListaID1[i].Replace(" (id)", "");
                    String Valor = this.ListaR1[i].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (cadena)", "").Replace(" (id2)", "");
                    if(LosCampos[h].ObtenerId() == Campo)
                    {
                        ValorReal = Valor;
                    }

                }
                if(LosCampos[h].ObtenerTipo().ToUpper() == "COUNTER")
                {
                    ValorReal = (entorno.Counter(Tabla, BD) +1).ToString();
                }
                if( (LLaves.Contains(LosCampos[h].ObtenerId())==true) && (ValorReal == "null"))
                {
                   return "#ERROR la llave primaria no puede ser null";
                }
                if(LLaves.Contains(LosCampos[h].ObtenerId()) == true)
                {
                    if(entorno.LlaveRepetida(Tabla,BD, LosCampos[h].ObtenerId(), ValorReal) == true)
                    {
                        return "#ERROR la llave primaria esta repetida";
                    }
                }
                System.Diagnostics.Debug.WriteLine("Valor a isnertar Campo->" + LosCampos[h].ObtenerId() + " Tipo->" + LosCampos[h].ObtenerTipo() + " Valor->" + ValorReal);
                if (LosCampos[h].ObtenerTipo() == "int")
                {
                    if (ValorReal.Length == 1)
                    {
                        ValorReal = "000000" + ValorReal;
                    }
                    if (ValorReal.Length == 2)
                    {
                        ValorReal = "00000" + ValorReal;
                    }
                    if (ValorReal.Length == 3)
                    {
                        ValorReal = "0000" + ValorReal;
                    }
                    if (ValorReal.Length == 4)
                    {
                        ValorReal = "000" + ValorReal;
                    }
                    if (ValorReal.Length == 5)
                    {
                        ValorReal = "00" + ValorReal;
                    }
                    if (ValorReal.Length == 6)
                    {
                        ValorReal = "0" + ValorReal;
                    }
                }
                Simbolo S = new Simbolo(LosCampos[h].ObtenerId(),ValorReal, LosCampos[h].ObtenerTipo());
                LosCampos2.Add(S);
            }
            String IdCampo = "BRAY-CAM" + (entorno.CantidadDeCAMPOS() + 1);
            entorno.AgregarCampo(IdCampo, Tabla, BD, LosCampos2);
            entorno.MostrarUTablas(Tabla, BD);
            entorno.MostrarCampos(Tabla, BD);
            return "INSERTAR DATOS2";
          }
    }
}