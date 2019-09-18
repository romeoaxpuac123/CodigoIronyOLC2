using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class CURSOR_SELECT_WHERE : NodoAbstracto
    {
        public CURSOR_SELECT_WHERE(String Nombre) : base(Nombre)
        {
        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion CURSOR-select-where");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion CURSOR-select-where");
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
                        Resultado.Add(entorno.MostrarCampos33Archivos(Tabla, BD, IdTabla,entorno.CursorEnUso()));

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
                            Resultado.Add(entorno.MostrarCamposExactos3Archivo(Tabla, BD, CamposAMostrar, IdTabla));

                        }
                    }
                }

            }
            String texto = "";
            String LineaDeCampos2 = "\n\nSELECION-WHERE\n\nTabla->" + Tabla + " BD:->" + BD + "\n";
           // System.Diagnostics.Debug.WriteLine(LineaDeCampos2);
         
           // System.Diagnostics.Debug.WriteLine(LineaDeCampos);
            for (int i = 0; i < Resultado.Count; i++)
            {
              
                    //System.Diagnostics.Debug.WriteLine(Resultado[i]);
                    texto = texto + Resultado[i] + "\n";
            }

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
            return "CURSOR-SELECT-WHERE";
        }
    }
}