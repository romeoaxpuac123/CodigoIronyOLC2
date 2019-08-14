using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Irony.Ast;
using Irony.Parsing;

namespace AnalizadorCQL.Analizadores
{
    public class Gramatica : Grammar
    {
        public Gramatica() : base(caseSensitive: false)
        {
            #region ExpresionesRegulares
            RegexBasedTerminal numero = new RegexBasedTerminal("numero", "[0-9]+");
            RegexBasedTerminal numdecimal = new RegexBasedTerminal("numdecimal", "[0-9]+\\.[0-9]+");
            RegexBasedTerminal cadena = new RegexBasedTerminal("cadena", "[\"]([^\"\n]|(\\\"))*[\"]");
            IdentifierTerminal id = new IdentifierTerminal("id");
            /*LO nuevo*/
            CommentTerminal comentarioLinea = new CommentTerminal("comentarioLinea", "//", "\n", "\r\n"); //si viene una nueva linea se termina de reconocer el comentario.
            CommentTerminal comentarioBloque = new CommentTerminal("comentarioBloque", "/*", "*/");
            RegexBasedTerminal id2 = new RegexBasedTerminal("id2", "[@](_|[0-9]|[a-z])*");
            #endregion
            NonGrammarTerminals.Add(comentarioLinea);
            NonGrammarTerminals.Add(comentarioBloque);

            #region Terminales
            var mas = ToTerm("+");
            var menos = ToTerm("-");
            var por = ToTerm("*");
            var div = ToTerm("/");
            var PYC = ToTerm(";");
            var ParA = ToTerm("(");
            var ParC = ToTerm(")");
            var laimpre = ToTerm("imprimir");
            this.RegisterOperators(1, Associativity.Left, "+", "-");
            this.RegisterOperators(2, Associativity.Left, "*", "/");
            this.RegisterOperators(3, Associativity.Left, "^");
            /*LO nuevo*/
            var create = ToTerm("create");
            var type = ToTerm("type");
            var llaveAbierta = ToTerm("{");
            var llaverCerrada = ToTerm("}");
            var Entero = ToTerm("int");
            var Decimal = ToTerm("double");
            var Cadena = ToTerm("String");
            var Boolenano = ToTerm("boolean");
            var Date = ToTerm("date");
            var Time = ToTerm("time");
            var coma = ToTerm(",");
            var igual= ToTerm("=");
            var nuevo = ToTerm("new");
            var falso = ToTerm("true");
            var verdadero = ToTerm("false");
            var punto = ToTerm(".");
            var ALTERAR = ToTerm("alter");
            var borrar1 = ToTerm("delete");
            var add1 = ToTerm("add");
            var bd = ToTerm("DATABASE");
            var use = ToTerm("USE");
            var drope = ToTerm("drop");
            var tabla = ToTerm("table");
            var PRIMARIKEY = ToTerm("PRIMARY");
            var PRIMARIKEY2 = ToTerm("KEY");
            var truncate = ToTerm("truncate");
            #endregion


            #region NoTerminales
            NonTerminal S = new NonTerminal("S");
            NonTerminal SENTENCIAS = new NonTerminal("SENTENCIAS");
            NonTerminal SENTENCIA = new NonTerminal("SENTENCIA");
            NonTerminal E = new NonTerminal("E");
            /*LO nuevo*/
            NonTerminal DEFINCION_GENERAL_CQL = new NonTerminal("DEFINCION_GENERAL_CQL");
            NonTerminal TIPOS_VARIABLES = new NonTerminal("TIPOS_VARIABLES");
            NonTerminal CREATE_TYPE = new NonTerminal("CREATE_TYPE");
            NonTerminal LISTA_IDS = new NonTerminal("LISTA_IDS");
            NonTerminal USER_TYPE = new NonTerminal("USER_TYPE");
            NonTerminal LISTA_EXPRESION = new NonTerminal("LISTA_EXPRESION");
            NonTerminal ASIGNACION = new NonTerminal("ASIGNACION");
            NonTerminal ALTER_TYPE = new NonTerminal("ALTER_TYPE");
            NonTerminal DELETE_TYPE = new NonTerminal("DELETE_TYPE");
            //DDL
            NonTerminal DDL = new NonTerminal("DDL");
            NonTerminal CREATE_TABLA_PAR= new NonTerminal("CREATE_TABLA_PAR");
            #endregion

            #region Gramatica
            S.Rule = SENTENCIAS;
            SENTENCIAS.Rule =     SENTENCIAS + SENTENCIA
                                | SENTENCIA;

            SENTENCIA.Rule = DEFINCION_GENERAL_CQL
                             |DDL;

            DDL.Rule = create + bd + id + PYC
                       |drope + bd + id + PYC
                       |use +id + PYC
                       |create + tabla + id + ParA  + CREATE_TABLA_PAR + ParC+ PYC
                       |ALTERAR + tabla + id + add1 + CREATE_TABLA_PAR + PYC
                       |ALTERAR + tabla + id + drope + LISTA_EXPRESION + PYC
                       |drope + tabla + id+ PYC
                       |truncate + tabla + id + PYC;

            CREATE_TABLA_PAR.Rule = CREATE_TABLA_PAR + coma + id + TIPOS_VARIABLES
                                   | CREATE_TABLA_PAR + coma + id + id
                                   | id + TIPOS_VARIABLES
                                   | id + id 
                                   | CREATE_TABLA_PAR + coma + id + TIPOS_VARIABLES + PRIMARIKEY + PRIMARIKEY2
                                   | CREATE_TABLA_PAR + coma + id + id + PRIMARIKEY + PRIMARIKEY2
                                   | id + TIPOS_VARIABLES + PRIMARIKEY + PRIMARIKEY2
                                   | id + id + PRIMARIKEY + PRIMARIKEY2
                                   | PRIMARIKEY + PRIMARIKEY2 + ParA + LISTA_EXPRESION + ParC
                                   | CREATE_TABLA_PAR + coma + PRIMARIKEY + PRIMARIKEY2 + ParA + LISTA_EXPRESION+ ParC;

           

            DEFINCION_GENERAL_CQL.Rule = comentarioLinea
                                        | comentarioBloque
                                        | CREATE_TYPE
                                        | USER_TYPE + PYC
                                        | ASIGNACION
                                        | ALTER_TYPE
                                        | DELETE_TYPE;

            DELETE_TYPE.Rule = borrar1 + type + id + PYC;
            ALTER_TYPE.Rule = ALTERAR + type + id + add1 + ParA +  LISTA_IDS+ ParC + PYC
                            | ALTERAR + type + id + borrar1 + ParA + LISTA_IDS + ParC + PYC;
            ASIGNACION.Rule = id2 + igual + E+ PYC
                              |TIPOS_VARIABLES + id2 + igual + E + PYC
                              | TIPOS_VARIABLES+ id2 + PYC
                              | id2 + igual + id2 + punto+ id + PYC
                              | TIPOS_VARIABLES + id2 + igual + id2 + punto + id + PYC
                              | id2 + punto + id + igual + E                              
                              | id2 + igual + ParA + TIPOS_VARIABLES + ParC+ E + PYC
                              | TIPOS_VARIABLES + id2 + igual + ParA + TIPOS_VARIABLES + ParC + E + PYC
                              | id2 + punto + id + igual + ParA + TIPOS_VARIABLES + ParC + E; 


            CREATE_TYPE.Rule = create + type + id + ParA  + LISTA_IDS + ParC+ PYC ;

            USER_TYPE.Rule = id +id2
                             | id2 + igual + nuevo +id
                             | id + id2 + igual + llaveAbierta + LISTA_EXPRESION + llaverCerrada;

            LISTA_IDS.Rule = LISTA_IDS + coma + TIPOS_VARIABLES + id
                            | LISTA_IDS + coma + USER_TYPE
                            | TIPOS_VARIABLES + id
                            | USER_TYPE;

            LISTA_EXPRESION.Rule = LISTA_EXPRESION + coma + E
                                | E;


            TIPOS_VARIABLES.Rule = Entero | Decimal | Cadena | Boolenano | Date | Time;
           
            E.Rule = E + mas + E
                    | E + menos + E
                    | E + por + E
                    | E + div + E
                    | numero
                    | numdecimal
                    | cadena
                    | id
                    |id2
                    |falso
                    |verdadero;
            
            #endregion

            #region Preferencias
            this.Root = S;
            #endregion


        }

    }
}