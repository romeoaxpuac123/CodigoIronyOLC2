﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class DeclararLista : NodoAbstracto
    {
        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado declarar lista");
        }
        public DeclararLista(String Valor) : base(Valor)
        {

        }
        public override string Ejecutar(Entorno entorno)
        {
            String retorno = "";
            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado declarar listA");
            List<String> ListaID1x = new List<String>();
            ListaID1x = this.ListaID1;

            for (int i = 0; i < ListaID1x.Count; i++)
            {
                if (entorno.ExisteVariable(ListaID1x[i]))
                {
                    retorno = "#Error4" + "la variable YA EXISTE " + ListaID1x[i];
                }
            }
                for (int i = 0; i < ListaID1x.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine("la variable es:" + ListaID1x[i]);
                String sali = entorno.ObtenerValor(ListaID1x[i]);
                if (sali.ToUpper().Contains("#ERROR2"))
                {
                    //System.Diagnostics.Debug.WriteLine("VAMOS A VER EL TIPO: " + Hijos[0].Nombre.ToUpper());
                    //salida.Text = "#Error: No se ha encontrado la variables -> " + this.Hijos[0].Nombre + "\n";
                    if (Hijos[0].Nombre.ToUpper().Contains("INT"))
                    {
                        entorno.Agregar(ListaID1x[i], Hijos[0].Nombre.ToUpper(), "0");
                    }
                    else if (Hijos[0].Nombre.ToUpper().Contains("DOUBLE"))
                    {
                        entorno.Agregar(ListaID1x[i], Hijos[0].Nombre.ToUpper(), "0,0");
                    }
                    else if (Hijos[0].Nombre.ToUpper().Contains("BOOLEAN"))
                    {
                        entorno.Agregar(ListaID1x[i], Hijos[0].Nombre.ToUpper(), "false");
                    }
                    else if (Hijos[0].Nombre.ToUpper().Contains("STRING") || Hijos[0].Nombre.ToUpper().Contains("DATE") || Hijos[0].Nombre.ToUpper().Contains("TIME"))
                    {
                        entorno.Agregar(ListaID1x[i], Hijos[0].Nombre.ToUpper(), "null");
                    }

                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("la variable YA EXISTE");
                    retorno = "#Error4" + "la variable YA EXISTE " + NombreVariable;
                }
                sali = entorno.ObtenerValor(this.Hijos[1].Nombre);
                retorno = sali;
            }

            return retorno;
        }
    }
}