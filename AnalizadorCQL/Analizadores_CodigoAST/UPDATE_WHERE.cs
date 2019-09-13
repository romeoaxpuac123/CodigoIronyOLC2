using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class UPDATE_WHERE : NodoAbstracto
    {
        public UPDATE_WHERE(String Nombre) : base(Nombre)
        {
        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion UPDATE2");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Ejecucion UPDATE2");

            String Tabla = this.Hijos[0].Nombre;
            String BD = entorno.Tabla();
            System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR1 tabla->" + Tabla);
            System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR1 bd->" + BD);
            //String CumpleSentencia = this.Hijos[1].Ejecutar(entorno);
            List<Simbolo> Campos = new List<Simbolo>();
            Campos = entorno.TodosLosCampos(Tabla, BD);
            int totalCampos = entorno.Counter(Tabla, BD);
            for(int j = 0; j < totalCampos; j++)
            {
                System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR1 bd->" + j);
                Entorno Prueba = new Entorno();
                String IdTabla = "";
                //System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR1 bd->" + Campos.Count);
                
                for (int i = 0; i < Campos.Count; i++)
                {   
                    if(Campos[i].RetornarPosicionObjeto().Contains((j+1).ToString()) == true)
                    {
                        //System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR1 bd->" + Campos[i].RetornarPosicionObjeto() + "->" + i);
                        Prueba.Agregar(Campos[i].ObtenerId(), Campos[i].ObtenerTipo(), Campos[i].ObtenerValor());
                        IdTabla = Campos[i].RetornarPosicionObjeto();
                    }
                    //Prueba.Agregar("@" + Campos[i].ObtenerId(), Campos[i].ObtenerTipo(), Campos[i].ObtenerValor());
                    //String Resultado = this.Hijos[1].Ejecutar(Prueba);
                    //System.Diagnostics.Debug.WriteLine("Ejecucion INSERTAR1 bd->" + Campos[i].RetornarPosicionObjeto() + "->" + Campos[i].ObtenerValor());

                }

                String ValorPrueba = this.Hijos[1].Ejecutar(Prueba);
                if (ValorPrueba.ToUpper().Contains("ERROR"))
                {
                    return "#ERROR  EL CAMPO DE COMPARACION ES INCORRECTO;";
                }
                if (ValorPrueba.ToUpper().Contains("TRUE"))
                {
                    System.Diagnostics.Debug.WriteLine("Aca inicia");
                    for (int p = 0; p < this.ListaID1.Count;p++)
                    {
                        System.Diagnostics.Debug.WriteLine("asdjfljaslkd->" + ListaID1[p]);
                        string[] separadas;
                        separadas = ListaID1[p].Split('=');
                        String Campo = separadas[0];
                        String Valor = separadas[1].Replace(" (numero)", "").Replace(" (hora)", "").Replace(" (numdecimal)", "").Replace(" (fechas)", "").Replace(" (cadena)", "").Replace(" (id2)", "");
                        entorno.ActualizarCampos2(IdTabla, Tabla, BD, Campo, Valor);
                    }
                    //entorno.ActualizarCampos2(IdTabla,Tabla,BD,)
                }
                System.Diagnostics.Debug.WriteLine("Aca son las comparaciones->" + IdTabla + "->" + ValorPrueba);
            }

            entorno.MostrarUTablas(Tabla, BD);
            entorno.MostrarCampos(Tabla, BD);

            return "UPDATE_WHERE";
        }
    }
}