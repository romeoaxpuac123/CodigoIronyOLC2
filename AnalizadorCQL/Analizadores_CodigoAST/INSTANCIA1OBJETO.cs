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
          //  System.Diagnostics.Debug.WriteLine("Objeto " + Objeto);
          //  System.Diagnostics.Debug.WriteLine("NombreVariable " + Variable);

            if(Objeto.ToUpper().Contains("NULL"))
            {
                //INSTANCIA CON VALOR NULO;
                if(entorno.ExisteVariable(Variable.Replace(" (id)",""))==true)
                {
                    if(entorno.ExisteVariable(this.Hijos[2].Nombre.Replace(" (id2)", ""))== false){
                        entorno.AgregarObjeto(this.Hijos[2].Nombre.Replace(" (id2)", ""), Variable.Replace(" (id)", ""), null);

                    }
                    else
                    {
                        return "#ERROR6 ? Exception: TypeAlreadyExists: User Type con un nombre ya existente.";
                    }
                    
                }
                else
                {
                    return "#ERROR6 ? Exception: NullPointerException: Objeto no existente o apunta a null.";
                }

            }
            else
            {
                if (entorno.ExisteVariable(Objeto) == true)
                {
                    if (entorno.ExisteVariable(Variable) == true)
                    {
                        entorno.EliminarVariable(Variable);
                        List<Simbolo> Lista = entorno.ElementosUT(Objeto);
                        entorno.AgregarObjeto(Variable, "OBJETO_BRAY", Lista);
                     
                    }
                    else{
                        return "#ERROR6 ? Exception: NullPointerException: Objeto no existente o apunta a null.";
                    }
                }
                else
                {
                    return "#ERROR6 ? Exception: NullPointerException: Objeto no existente o apunta a null.";
                }
            }
            
            /*
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
            */
            return "INSTANCIA";
        }
    }
}