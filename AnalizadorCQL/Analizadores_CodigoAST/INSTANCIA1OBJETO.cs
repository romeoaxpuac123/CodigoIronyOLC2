using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class INSTANCIA1OBJETO : NodoAbstracto
    {
        public INSTANCIA1OBJETO(String Valor) : base(Valor)
        {

        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado ISNTANCIA OBJETO");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado ISNTANCIA OBJETO");
            String Objeto = this.Hijos[0].Nombre.ToString();
            String Variable = this.Hijos[1].Nombre.ToString();
            System.Diagnostics.Debug.WriteLine("Objeto " + Objeto);
            System.Diagnostics.Debug.WriteLine("NombreVariable " + Variable);
            Boolean ObjetoA = entorno.Agregar(Objeto, "Objeto", "Objeto");
            if (ObjetoA == true)
            {

                System.Diagnostics.Debug.WriteLine("#Error objeto no existen -> " + Objeto);
                return "#ERROR8 NO EXISTE OBJETO";
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("#VAMOS A INSTANCIAR -> " + Variable);
                String valorsito = entorno.ObtenerValor(Variable);
                if(valorsito == "1")
                {
                    String Cadena = entorno.ElementosObjetos(Objeto);
                    System.Diagnostics.Debug.WriteLine(Cadena);
                    String[] separadas;
                    separadas = Cadena.Split(',');
                    for(int i = 1; i < separadas.Length; i++)
                    {
                        String valor = entorno.ObtenerValor(Objeto + "." + separadas[i]);
                        String tipo = entorno.ObtenerTipo(Objeto + "." + separadas[i]);
                        System.Diagnostics.Debug.WriteLine("#VAMOS A INSTANCIAR -> " + Variable + "." + separadas[i] + " valor " + valor + " tipo " + tipo);
                        entorno.AgregarElementoObjeto(Variable + "." + separadas[i], valor, tipo, Objeto);
                    
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
            return "INSTANCIA";
        }
    }
}