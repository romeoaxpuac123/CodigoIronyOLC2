using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class MIN_SELEC_WHERE_LIMIT : NodoAbstracto
    {
        public MIN_SELEC_WHERE_LIMIT(String Nombre) : base(Nombre)
        {
            
        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion MIN select-where-LIMIT");
        }

        public override string Ejecutar(Entorno entorno)
        {
            String Tabla = this.Hijos[0].Nombre;
            String BD = entorno.Tabla();
            System.Diagnostics.Debug.WriteLine("Ejecucion select-wherelimit tabla->" + Tabla);
            System.Diagnostics.Debug.WriteLine("Ejecucion select-wherelimit bd->" + BD);
            List<Simbolo> Campos = new List<Simbolo>();
            List<String> CamposAMostrar = new List<String>();
            Campos = entorno.TodosLosCampos(Tabla, BD);
            List<String> Resultado = new List<String>();
            List<String> Resultado2 = new List<String>();
            int totalCampos = entorno.Counter(Tabla, BD);

            for (int j = 0; j < totalCampos; j++)
            {
                System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR1 bd->" + j);
                Entorno Prueba = new Entorno();
                String IdTabla = "";
                //System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR1 bd->" + Campos.Count);

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
                if (ValorPrueba.ToUpper().Contains("ERROR"))
                {
                    return "#ERROR  EL CAMPO DE COMPARACION ES INCORRECTO;";
                }
                if (ValorPrueba.ToUpper().Contains("TRUE"))
                {
                    System.Diagnostics.Debug.WriteLine("Aca inicia---->");
                    if (this.ListaID1.Count == 1 && this.ListaID1[0] == "* (Key symbol)")
                    {
                        Resultado.Add(entorno.MostrarCampos33(Tabla, BD, IdTabla));

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
            String Ellimite = this.Hijos[2].Ejecutar(entorno).Replace(" (id)", "").Replace(" (id2)", "").Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "");

            if (Int32.Parse(Ellimite) > Resultado.Count)
            {
                return "#ERROR el limite es mayor que la cantidad de campos";
            }
            if (this.ListaID1.Count == 1 && this.ListaID1[0] == "* (Key symbol)")
            {
                entorno.MostrarUTablas2(Tabla, BD);
                for (int i = 0; i < Resultado.Count; i++)
                {
                    if (Int32.Parse(Ellimite) == i)
                    {
                        break;
                    }
                    //System.Diagnostics.Debug.WriteLine(Resultado[i]);
                }
                return "#ERROR * MIN-SELEC-WHERE-LIMIT";

            }
            String LineaDeCampos = "\n\nSELECION-where-limit\n\nTabla->" + Tabla + " BD:->" + BD + "\n";
            for (int i = 0; i < this.ListaID1.Count; i++)
            {
              // LineaDeCampos = LineaDeCampos + this.ListaID1[i].Replace(" (id)", "") + "         |";
            }
            //System.Diagnostics.Debug.WriteLine(LineaDeCampos);
            for (int i = 0; i < Resultado.Count; i++)
            {
                if (Int32.Parse(Ellimite) == i)
                {
                    break;
                }
                Resultado2.Add(Resultado[i]);
                //System.Diagnostics.Debug.WriteLine(Resultado[i]);
            }
            Resultado2.Sort();
            if(this.AutoIncrmentable2 == 2)
            {
                Resultado2.Reverse();
                return Resultado[0];
            }

            return Resultado2[0];
        }
    }
}