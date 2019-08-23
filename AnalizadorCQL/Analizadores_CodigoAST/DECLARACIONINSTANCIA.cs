using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class DECLARACIONINSTANCIA : NodoAbstracto
    {
        public DECLARACIONINSTANCIA(String Valor) : base(Valor)
        {

        }
        public override void Ejecutar()
        {

            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado DELCARCION-INSTANCIA OBJETO");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado DELCARCION-INSTANCIA OBJETO");
            String Objeto1 = this.Hijos[0].Nombre.ToString();
            String Variable = this.Hijos[1].Nombre.ToString();
            String Objeto2 = this.Hijos[2].Nombre.ToString();
            if(Objeto1.ToUpper() == Objeto2.ToUpper())
            {
                System.Diagnostics.Debug.WriteLine("LOS OBJETOS SON IGUALES SE PUEDEN INSTANCIAR");
                if(entorno.Agregar(Objeto1,"Objeto","Objeto") == false)
                {
                    System.Diagnostics.Debug.WriteLine("EL OBJETO SI EXISTE");
                    Boolean B = entorno.Agregar(Variable,Objeto1,"1");
                    if (B == true)
                    {
                        System.Diagnostics.Debug.WriteLine("SE AGREGO VARIABLE-OBJETO SI EXISTE");
                        System.Diagnostics.Debug.WriteLine("#VAMOS A INSTANCIAR -> " + Variable);
                        String valorsito = entorno.ObtenerValor(Variable);
                        if (valorsito == "1")
                        {
                            String Cadena = entorno.ElementosObjetos(Objeto1);
                            System.Diagnostics.Debug.WriteLine(Cadena);
                            String[] separadas;
                            separadas = Cadena.Split(',');
                            for (int i = 1; i < separadas.Length; i++)
                            {
                                String valor = entorno.ObtenerValor(Objeto1 + "." + separadas[i]);
                                String tipo = entorno.ObtenerTipo(Objeto1 + "." + separadas[i]);
                                System.Diagnostics.Debug.WriteLine("#VAMOS A INSTANCIAR -> " + Variable + "." + separadas[i] + " valor " + valor + " tipo " + tipo);
                                entorno.AgregarElementoObjeto(Variable + "." + separadas[i], valor, tipo, i.ToString());

                            }
                            //objeto no instanciado
                            entorno.AsignarValor(Variable, "2");
                        }
                        else
                        {
                            //objeto ya instanciado
                            return "#ERROR objeto ya instanciado";
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("LA VARIBALE YA EXISTE");
                        return "#ERROR9 LA VARIABLE YA EXISTE";
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("EL OBJETO NO EXISTE");
                    return "#ERROR9 OBJETOS NO EXISTENE";
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("OBJETOS DIFERENTES");
                return "#ERROR9 OBJETOS DIFERENTES";
            }

            return "DECLARACION-INSTANCIA OBJETOS";
        }
    }
}