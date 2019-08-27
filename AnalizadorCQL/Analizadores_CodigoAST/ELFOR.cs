﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class ELFOR : NodoAbstracto
    {
        public ELFOR(String Valor) : base(Valor)
        {

        
        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado FRO");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado FRO");
            String VariableContador = this.Hijos[0].Hijos[1].Nombre;
            System.Diagnostics.Debug.WriteLine("Se esta ejecutnado FRO" + VariableContador);
            this.Hijos[0].Ejecutar(entorno);
            String valor1 = "";
            while (this.Hijos[1].Ejecutar(entorno).ToString().ToUpper().Contains("TRUE") == true)
            {
                System.Diagnostics.Debug.WriteLine("dentro del while**************+++");
                foreach(NodoAbstracto sentencia in this.Hijos[3].Hijos)
                {
                    System.Diagnostics.Debug.WriteLine("ESTAMOS DENTRO DEL WHILE");
                    valor1 = sentencia.Ejecutar(entorno);
                    if (valor1.Contains("#Error") == true)
                    {
                        System.Diagnostics.Debug.WriteLine("errroESTAMOS DENTRO DEL WHILE");
                        //break;
                        return "#Error";
                    }
                    if (valor1.Contains("BREAK") == true)
                    {
                        return "FOR";
                        //return "#Error";
                        //elbreak = true;
                        //break;
                    }
                    if (valor1.Contains("RETORNO:") == true)
                    {

                        return valor1;
                    }

                }
                this.Hijos[2].Ejecutar(entorno);
                

            }
            System.Diagnostics.Debug.WriteLine("III");
         entorno.EliminarVariable(VariableContador);
            System.Diagnostics.Debug.WriteLine("III");
            return "FOR";
        }
    }
}