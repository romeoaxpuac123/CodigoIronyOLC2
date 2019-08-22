using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class Nodo : NodoAbstracto
    {
        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Ejecutar nodo ");
        }

        public Nodo(String val)
        {
            this.Nombre = val;
            this.id = 0;
            this.linea = 0;
            this.columna = 0;
            //this.Hijos = new ArrayList();
            this.Hijos = new List<NodoAbstracto>();
        }

        public Nodo(String val, int lin, int col)
        {
            this.Nombre = val;
            this.id = 0;
            this.linea = lin;
            this.columna = col;
            //this.Hijos = new ArrayList();
            this.Hijos = new List<NodoAbstracto>();
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("ejecutar nodoxd" + this.Nombre);
            String sali = "";
            switch (this.Nombre)
            {
                case "Entero":
                    //Console.WriteLine("puto el que lo leaxd");
                    sali = this.Hijos[0].Nombre;
                    break;
                case "Decimal":
                    sali = this.Hijos[0].Nombre;
                    break;
                case "Cadena":
                    sali = this.Hijos[0].Nombre;
                    break;
                case "Booleano":
                    sali = this.Hijos[0].Nombre;
                    break;
                case "Fechas":
                    sali = this.Hijos[0].Nombre;
                    break;
                case "hora":
                    sali = this.Hijos[0].Nombre;
                    break;
                case "id":
                    sali = this.Hijos[0].Nombre;
                    break;
                case "id2":
                    sali = entorno.ObtenerValor(this.Hijos[0].Nombre);
                    if ("#Error2".Equals(sali))
                    {
                        //salida.Text = "#Error: No se ha encontrado la variables -> " + this.Hijos[0].Nombre + "\n";
                        System.Diagnostics.Debug.WriteLine("#Error: No se ha encontrado la variables -> " + this.Hijos[0].Nombre + "\n");
                    }
                    break;
                case "arithmeticexception":
                    sali = this.Hijos[0].Nombre;
                    break;
                case "indexoutexception":
                    sali = this.Hijos[0].Nombre;
                    break;
                

                case "x":

                    break;

            }
            return sali;
        }
    }
}