using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnalizadorCQL.Analizadores_Codigo;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public class ASIGNACIONOBJETOS : NodoAbstracto
    {
        public ASIGNACIONOBJETOS(String Valor) : base(Valor)
        {

        }

        public override void Ejecutar()
        {
            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado ASIGNACION OBJETO");
        }

        public override string Ejecutar(Entorno entorno)
        {
            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado ASIGNACION OBJETO");
            System.Diagnostics.Debug.WriteLine("Se está Ejecutnado DELCARCION-INSTANCIA OBJETO");
            String Objeto1 = this.Hijos[0].Nombre.ToString();
            String Variable = this.Hijos[1].Nombre.ToString();
            if (entorno.Agregar(Objeto1, "Objeto", "Objeto") == false)
            {
                System.Diagnostics.Debug.WriteLine("EL OBJETO SI EXISTE");
                Boolean B = entorno.Agregar(Variable, Objeto1, "1");
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
                            //String valor = entorno.ObtenerValor(Objeto1 + "." + separadas[i]);
                            //String tipo = entorno.ObtenerTipo(Objeto1 + "." + separadas[i]);
                            //System.Diagnostics.Debug.WriteLine("#VAMOS A INSTANCIAR -> " + Variable + "." + separadas[i] + " valor " + valor + " tipo " + tipo);
                            //entorno.AgregarElementoObjeto(Variable + "." + separadas[i], valor, tipo, i.ToString() ) ;
                            //vamos a mostrar los valores del mero objeto en orden
                            String Atributo = entorno.ObtenerPosicion(Objeto1, i.ToString());
                            System.Diagnostics.Debug.WriteLine("#VAMOS A INSTANCIAR con " + Atributo);
                            String valor = entorno.ObtenerValor(Atributo);
                            String tipo = entorno.ObtenerTipo(Atributo);
                            String NuevaVariable = Variable + "."+ Atributo.Replace(Objeto1, "").Replace(".", "");
                            entorno.AgregarElementoObjeto(NuevaVariable, valor, tipo, i.ToString());
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
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("EL OBJETO NO EXISTE");
                return "#ERROR9 OBJETOS NO EXISTENE";
            }
            String valorsito2 = entorno.ObtenerValor(Variable);
            if (valorsito2 == "2")
            {
                System.Diagnostics.Debug.WriteLine("EL OBJETO ya intanciado procedemos a la asignacion");
                String Cadena2 = entorno.ElementosVariableObjeto(Variable);
                String[] separadas;
                separadas = Cadena2.Split(',');
                System.Diagnostics.Debug.WriteLine("EL OBJETO ya intanciado procedemos a la asignacionxd");
                System.Diagnostics.Debug.WriteLine("lista" + this.ListaID1.Count);
                System.Diagnostics.Debug.WriteLine("arreglo" + separadas.Length);

                if (this.ListaID1.Count == separadas.Length)
                {
                    System.Diagnostics.Debug.WriteLine("LA LISTA DE PARAMETROS COINCIDE");
                    for (int i = 1; i < separadas.Length; i++)
                    {
                        String ElTipo = entorno.ObtenerTipo(separadas[i]);
                        if (separadas[i].ToUpper() != Variable.ToUpper())
                        {
                            Boolean SonIguales = false;
                            String TipoVariable = ElTipo;
                            String Variablex = "";
                            String posicion = entorno.ObtenerPosicion(Variable,i.ToString());
                            System.Diagnostics.Debug.WriteLine("variable vol " +i+"-> " + posicion);
                            String TipoXD = entorno.ObtenerTipo(posicion);
                            System.Diagnostics.Debug.WriteLine("variable vol " + i + "-> " + posicion + "<>" + TipoXD + "%" + ListaID1[i]);
                            if (TipoXD.ToUpper().Contains("STRING") && ListaID1[i].ToUpper().Contains("(CADENA)"))
                            {
                                SonIguales = true;
                                Variablex = ListaID1[i].Replace(" (cadena)", "");
                            }
                            if (TipoXD.ToUpper().Contains("INT") && ListaID1[i].ToUpper().Contains("(NUMERO)"))
                            {
                                SonIguales = true;
                                Variablex = ListaID1[i].Replace(" (numero)", "");
                            }
                            if (TipoXD.ToUpper().Contains("BOOLEAN") && ((ListaID1[i].ToUpper().Contains("TRUE")|| ListaID1[i].ToUpper().Contains("FALSE"))&& ListaID1[i].ToUpper().Contains("KEYWORD")))
                            {
                                SonIguales = true;
                                Variablex = ListaID1[i].Replace(" (Keyword)", "");
                            }
                            if (TipoXD.ToUpper().Contains("TIME") && (ListaID1[i].ToUpper().Contains("(HORA)")))
                            {
                                SonIguales = true;
                                Variablex = ListaID1[i].Replace(" (hora)", "");
                            }
                            if (TipoXD.ToUpper().Contains("DATE") && (ListaID1[i].ToUpper().Contains("(FECHAS)")))
                            {
                                SonIguales = true;
                                Variablex = ListaID1[i].Replace(" (fechas)", "");
                            }

                            if (SonIguales == true)
                            {
                                entorno.AsignarValor(posicion, Variablex);
                            }
                            else
                            {
                                System.Diagnostics.Debug.WriteLine("error");
                                //entorno.EliminarVariablecONTENIDA(Variable);
                                System.Diagnostics.Debug.WriteLine("LA LISTA DE PARAMETROS NO COINCIDE");
                                String Cadena2x = entorno.ElementosVariableObjeto(Variable);
                                String[] separadasx;
                                separadasx = Cadena2x.Split(',');
                                for (int x = 1; i < separadasx.Length; i++)
                                {
                                    System.Diagnostics.Debug.WriteLine(separadasx[x]);
                                    entorno.EliminarVariable(separadasx[x]);

                                }
                                entorno.EliminarVariable(Variable);
                                System.Diagnostics.Debug.WriteLine("EL OBJETO NO EXISTEyyyy");
                                return "#ERROR9 OBJETOS NO EXISTENE";
                            }
                            System.Diagnostics.Debug.WriteLine(posicion + entorno.ObtenerValor(posicion));


                        }
                        

                    }

                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("LA LISTA DE PARAMETROS NO COINCIDE");
                    String Cadena2x = entorno.ElementosVariableObjeto(Variable);
                    String[] separadasx;
                    separadasx = Cadena2x.Split(',');
                    for(int i = 1; i<separadasx.Length; i++)
                    {
                        System.Diagnostics.Debug.WriteLine(separadasx[i]);
                        entorno.EliminarVariable(separadasx[i]);

                    }
                    entorno.EliminarVariable(Variable);
                    System.Diagnostics.Debug.WriteLine("***");
                    System.Diagnostics.Debug.WriteLine("EL OBJETO NO EXISTExs");
                    return "#ERROR9 OBJETOS NO EXISTENE";
                }
               
                
            }

           // Entorno x = new Entorno();
           // x.Agregar("Bayron", "romoe", "a");
           // x.EliminarVariable("Bayron");
            return "ASIGNACION-OBJETO";
        }
    }
}