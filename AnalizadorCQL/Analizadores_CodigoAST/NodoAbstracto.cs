using AnalizadorCQL.Analizadores_Codigo;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AnalizadorCQL.Analizadores_CodigoAST
{
    public abstract class NodoAbstracto
    {
        public String Nombre;
        public int id, linea, columna;
        public String Cadena;
        public String TipoDato;
        public String NombreVariable;
        public int AutoIncrmentable = 0;
        public int AutoMinision;
        public List<NodoAbstracto> Hijos;
        public List<String> ListaID1  ;
        public NodoAbstracto()
        {
        }

        public NodoAbstracto(String Cadena, int codigo)
        {

            this.Cadena = Cadena;
        }

        public NodoAbstracto(String nom)
        {

            this.Nombre = nom;
            this.id = 0;
            this.linea = 0;
            this.columna = 0;
            //this.Hijos = new ArrayList();
            this.Hijos = new List<NodoAbstracto>();
            ListaID1 = new List<String>();
        }

        public NodoAbstracto(String nom, int lin, int col)
        {

            this.Nombre = nom;
            this.id = 0;
            this.linea = lin;
            this.columna = col;
            //this.Hijos = new ArrayList();
            this.Hijos = new List<NodoAbstracto>();
            ListaID1 = new List<String>();
        }
        public abstract void Ejecutar();
        public abstract String Ejecutar(Entorno entorno);
    }
}