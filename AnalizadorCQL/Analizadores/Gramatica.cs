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
            StringLiteral cadena = new StringLiteral("cadena", "\"");
            IdentifierTerminal id = new IdentifierTerminal("id");
            /*LO nuevo*/
            CommentTerminal comentarioLinea = new CommentTerminal("comentarioLinea", "//", "\n", "\r\n"); //si viene una nueva linea se termina de reconocer el comentario.
            CommentTerminal comentarioBloque = new CommentTerminal("comentarioBloque", "/*", "*/");
            RegexBasedTerminal id2 = new RegexBasedTerminal("id2", "[@](_|[0-9]|[a-z])*(\\.(_|[0-9]|[a-z])*)*");
            RegexBasedTerminal fechas = new RegexBasedTerminal("fechas", "'[0-9][0-9][0-9][0-9]-[0-1]*[0-9]-[0-3]*[0-9]'");
            RegexBasedTerminal hora = new RegexBasedTerminal("hora", "'[0-2]*[0-9]:[0-5]*[0-9]:[0-5]*[0-9]'");
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
            var igual = ToTerm("=");
            var nuevo = ToTerm("new");
            var falso = ToTerm("false", "falso");
            var verdadero = ToTerm("true", "verdadero");
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
            var laimpre = ToTerm("LOG");
            var potencia = ToTerm("**");
            var modulo = ToTerm("%");
            var mayor = ToTerm(">");
            var menor = ToTerm("<");
            var mayor_que = ToTerm(">=");
            var menor_que = ToTerm("<=");
            var igual_igual = ToTerm("==");
            var diferente = ToTerm("!=");
            var OR = ToTerm("||");
            var AND = ToTerm("&&");
            var XOR = ToTerm("^");
            var NOT = ToTerm("!");
            var TRY = ToTerm("try");
            var CATCH = ToTerm("catch");
            var elincre = ToTerm("++");
            var CorcheteA = ToTerm("[");
            var CorcheteC = ToTerm("]");
            var CorcheteAA = ToTerm("¿");
            var CorcheteCA = ToTerm("?");
            var ArithmeticException = ToTerm("ArithmeticException");
            var IndexOutException = ToTerm("IndexOutException");
            var WHILE = ToTerm("WHILE");
            var ELDO = ToTerm("DO");
            var FOR = ToTerm("FOR");
            var ELIF = ToTerm("IF");
            var ELELSE = ToTerm("ELSE");
            var ELBREAK = ToTerm("break");
            var exists = ToTerm("exists");
            var elnot = ToTerm("not");
            var ELAS = ToTerm("as");
            var LISTA = ToTerm("list");
            var INSERT = ToTerm("Insert");
            var GET = ToTerm("Get");
            var SET = ToTerm("Set");
            var REMOVE = ToTerm("Remove");
            var SIZE = ToTerm("Size");
            var CLEAR = ToTerm("Clear");
            var CONSTAINTS = ToTerm("Contains");
            var HOY = ToTerm("today");
            var AHORA = ToTerm("now");
            var RETORNO = ToTerm("return");
            var Procedure = ToTerm("procedure");
            var CALL = ToTerm("call");
            var NULO = ToTerm("null");

            this.RegisterOperators(8, Associativity.Left, "?");
            this.RegisterOperators(1, Associativity.Left, "+", "-");
            this.RegisterOperators(2, Associativity.Left, "*", "/", "%");            
            this.RegisterOperators(3, Associativity.Left, "**");
            this.RegisterOperators(4, Associativity.Left, ">", "<", ">=", "<=");
            this.RegisterOperators(5, Associativity.Left, "!=", "==");
            this.RegisterOperators(6, Associativity.Left, "&&", "||", "^");
            this.RegisterOperators(7, Associativity.Left, "!");
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
            NonTerminal USER_TYPE2 = new NonTerminal("USER_TYPE2");
            NonTerminal LISTA_EXPRESION = new NonTerminal("LISTA_EXPRESION");
            NonTerminal ASIGNACION = new NonTerminal("ASIGNACION");
            NonTerminal ALTER_TYPE = new NonTerminal("ALTER_TYPE");
            NonTerminal DELETE_TYPE = new NonTerminal("DELETE_TYPE");
            NonTerminal IMP = new NonTerminal("IMP");
            NonTerminal TRY_CATCH = new NonTerminal("TRY_CATCH");
            NonTerminal LISTA_IDS2 = new NonTerminal("LISTA_IDS2");
            NonTerminal INC_DEC = new NonTerminal("INC_DEC");
            NonTerminal ASIGNACION_OPERACION = new NonTerminal("ASIGNACION_OPERACION");
            NonTerminal ELWHILE = new NonTerminal("ELWHILE");
            NonTerminal DO_WHILE = new NonTerminal("DO_WHILE");
            NonTerminal EL_FOR = new NonTerminal("EL_FOR");
            NonTerminal EL_IF = new NonTerminal("EL_IF");
            NonTerminal SINO = new NonTerminal("SINO");
            NonTerminal EL_BREAK = new NonTerminal("ELBREAK");
            NonTerminal LALISTA = new NonTerminal("LALISTA");
            NonTerminal LISTAPARASITOS = new NonTerminal("LISTAPARASITOS");
            NonTerminal FUNCIONES_PROPIAS= new NonTerminal("FUNCIONES_PROPIAS");
            NonTerminal FUNCIONES_PROPIAS_DEL_SISTEMA = new NonTerminal("FUNCIONES_PROPIAS_DEL_SISTEMA");
            NonTerminal FUNCIONES_CREADAS = new NonTerminal("FUNCIONES_CREADAS");
            NonTerminal LISTA_PARAMETROS_FUNCIONES = new NonTerminal("LISTA_PARAMETROS_FUNCIONES");
            NonTerminal TIPOS_VARIABLES2 = new NonTerminal("TIPOS_VARIABLES2");
            NonTerminal PROCEDIMIENTOS = new NonTerminal("PROCEDIMIENTOS");
            NonTerminal ELCALL = new NonTerminal("ELCALL");
            //DDL
            NonTerminal DDL = new NonTerminal("DDL");
            NonTerminal CREATE_TABLA_PAR = new NonTerminal("CREATE_TABLA_PAR");
            NonTerminal ELRETORNO = new NonTerminal("ELRETORNO");
            NonTerminal LISTA_IDSxx = new NonTerminal("LISTA_IDSxx");
            NonTerminal LISTA_EXPRESIONobjetos = new NonTerminal("LISTA_EXPRESIONobjetos");

            #endregion

            #region Gramatica
            S.Rule = SENTENCIAS;
            SENTENCIAS.Rule = SENTENCIAS + SENTENCIA
                                | SENTENCIA;

            SENTENCIA.Rule = DEFINCION_GENERAL_CQL
                             | DDL
                             | IMP
                             | TRY_CATCH
                             | INC_DEC + PYC
                             | ASIGNACION_OPERACION
                             | ELWHILE
                             | DO_WHILE
                             | EL_FOR
                             | EL_IF
                             | EL_BREAK
                             | FUNCIONES_PROPIAS
                             | FUNCIONES_CREADAS
                             | ELRETORNO
                             | PROCEDIMIENTOS
                             | ELCALL;

            ELCALL.Rule = LISTA_EXPRESION + igual + CALL + id + ParA + LISTA_EXPRESION + ParC + PYC;


            PROCEDIMIENTOS.Rule = Procedure + id + ParA + ParC + coma + ParA + ParC + llaveAbierta + SENTENCIAS + llaverCerrada
                | Procedure + id + ParA + LISTA_PARAMETROS_FUNCIONES + ParC + coma + ParA + ParC + llaveAbierta + SENTENCIAS + llaverCerrada
                | Procedure + id + ParA + ParC + coma + ParA + LISTA_PARAMETROS_FUNCIONES+ ParC + llaveAbierta + SENTENCIAS + llaverCerrada
                | Procedure + id + ParA + LISTA_PARAMETROS_FUNCIONES + ParC + coma + ParA + LISTA_PARAMETROS_FUNCIONES + ParC + llaveAbierta + SENTENCIAS + llaverCerrada;


            ELRETORNO.Rule =  RETORNO + E + PYC
                             | RETORNO + LISTA_EXPRESION + PYC;

            FUNCIONES_CREADAS.Rule = TIPOS_VARIABLES + id + ParA + LISTA_PARAMETROS_FUNCIONES + ParC + llaveAbierta + SENTENCIAS + llaverCerrada
                                    | TIPOS_VARIABLES + id + ParA + ParC + llaveAbierta + SENTENCIAS + llaverCerrada
                                    | TIPOS_VARIABLES2 + id + ParA + LISTA_PARAMETROS_FUNCIONES + ParC + llaveAbierta + SENTENCIAS + llaverCerrada
                                    | TIPOS_VARIABLES2 + id + ParA + ParC + llaveAbierta + SENTENCIAS + llaverCerrada;

            LISTA_PARAMETROS_FUNCIONES.Rule = TIPOS_VARIABLES + id2 + LISTA_PARAMETROS_FUNCIONES
                                             | coma + TIPOS_VARIABLES + id2 + LISTA_PARAMETROS_FUNCIONES
                                             | coma + TIPOS_VARIABLES + id2
                                             | TIPOS_VARIABLES + id2
                                             | TIPOS_VARIABLES2 + id2 + LISTA_PARAMETROS_FUNCIONES
                                             | coma + TIPOS_VARIABLES2 + id2 + LISTA_PARAMETROS_FUNCIONES
                                             | coma + TIPOS_VARIABLES2 + id2
                                             | TIPOS_VARIABLES2 + id2;
            TIPOS_VARIABLES2.Rule = LISTA | SET | id;
                        
            EL_BREAK.Rule = ELBREAK + PYC;

            EL_IF.Rule = ELIF + ParA + E + ParC + llaveAbierta + SENTENCIAS + llaverCerrada
                         | ELIF + ParA + E + ParC + llaveAbierta + SENTENCIAS + llaverCerrada + SINO
                         | ELIF + ParA + E + ParC + llaveAbierta + SENTENCIAS + llaverCerrada + ELELSE + llaveAbierta + SENTENCIAS + llaverCerrada;


            SINO.Rule =  ELELSE + ELIF + ParA + E+  ParC + llaveAbierta + SENTENCIAS + llaverCerrada + SINO 
                             | ELELSE + ELIF + ParA + E + ParC + llaveAbierta + SENTENCIAS + llaverCerrada
                             | ELELSE + ELIF + ParA + E + ParC + llaveAbierta + SENTENCIAS + llaverCerrada + ELELSE + llaveAbierta + SENTENCIAS + llaverCerrada;


            EL_FOR.Rule = FOR + ParA + ASIGNACION + E+ PYC + INC_DEC+ ParC + llaveAbierta + SENTENCIAS +  llaverCerrada;
            ELWHILE.Rule = WHILE + ParA + E + ParC + llaveAbierta + SENTENCIAS + llaverCerrada;
            DO_WHILE.Rule = ELDO + llaveAbierta + SENTENCIAS + llaverCerrada + WHILE + ParA + E + ParC + PYC;

             ASIGNACION_OPERACION.Rule = id2 + mas + igual + E + PYC
                                       | id2 + menos + igual + E + PYC
                                       | id2 + por + igual + E + PYC
                                       | id2 + div + igual + E + PYC;
                                                  



            INC_DEC.Rule = id2 + mas + mas
                         | id2 + menos + menos;

            TRY_CATCH.Rule = TRY + llaveAbierta + SENTENCIAS + llaverCerrada + CATCH + ParA + ArithmeticException + id +  ParC + llaveAbierta + SENTENCIAS + llaverCerrada
                           | TRY + llaveAbierta + SENTENCIAS + llaverCerrada + CATCH + ParA + IndexOutException +   id +  ParC + llaveAbierta + SENTENCIAS + llaverCerrada; ;
            
            IMP.Rule = laimpre + ParA + E + ParC + PYC;

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
                                        | USER_TYPE2
                                        | ASIGNACION
                                        | ALTER_TYPE
                                        | DELETE_TYPE
                                        | LALISTA;

           

            LALISTA.Rule = LISTA + id2 + igual + nuevo + LISTA + menor + TIPOS_VARIABLES + mayor + PYC
                          | LISTA + id2 + PYC
                          | id2 + igual + nuevo + LISTA + menor + TIPOS_VARIABLES + mayor + PYC
                          | id2 + igual + nuevo + CorcheteA + LISTA_EXPRESION + CorcheteC + PYC
                          | LISTA + id2 + igual + nuevo + CorcheteA  + LISTA_EXPRESION + CorcheteC + PYC
                          | SET + id2 + igual + nuevo + SET + menor + TIPOS_VARIABLES + mayor + PYC
                          | SET + id2 + PYC
                          | id2 + igual + nuevo + SET + menor + TIPOS_VARIABLES + mayor + PYC
                          | SET + id2 + igual + nuevo + CorcheteA + LISTA_EXPRESION + CorcheteC + PYC;

            FUNCIONES_PROPIAS.Rule = id2 + ParA + ParC + PYC
                                    | id2 + ParA + E + ParC + PYC
                                    | id2 + ParA + E + coma + E + ParC + PYC
                                    | id2 + ParA + ParC+PYC;


            


            DELETE_TYPE.Rule = borrar1 + type + id + PYC;
            ALTER_TYPE.Rule = ALTERAR + type + id + add1 + ParA +  LISTA_IDS+ ParC + PYC
                            | ALTERAR + type + id + borrar1 + ParA + LISTA_IDS + ParC + PYC;

            ASIGNACION.Rule = id2 + igual + E + PYC
                              | TIPOS_VARIABLES + id2 + igual + E + PYC
                              | TIPOS_VARIABLES + id2 + PYC
                              | TIPOS_VARIABLES + LISTA_IDS2 + PYC
                              | TIPOS_VARIABLES + LISTA_IDS2 + igual + E + PYC
                              | id2 + igual + id2 + punto+ id + PYC
                              | TIPOS_VARIABLES + id2 + igual + id2 + punto + id + PYC
                              | id2 + punto + id + igual + E                              
                             // | id2 + igual + ParA + TIPOS_VARIABLES + ParC+ E + PYC
                             // | TIPOS_VARIABLES + id2 + igual + ParA + TIPOS_VARIABLES + ParC + E + PYC
                              | id2 + punto + id + igual + ParA + TIPOS_VARIABLES + ParC + E;

            LISTA_IDS2.Rule = LISTA_IDS2 + coma + id2
                             | id2;




            #region CREACION_USER_TYPE
            // GRAMATICA PARA LA CREACIÓN DE USER TYPE**************************
            CREATE_TYPE.Rule = create + type + id + ParA + LISTA_IDSxx + ParC + PYC
                              | create + type  + ELIF + elnot + exists  + id + ParA + LISTA_IDSxx + ParC + PYC;
            CREATE_TYPE.ErrorRule = SyntaxError + "}";
            #endregion


            #region PARAMETROS_USER_TYPE
            // GRAMATICA PARA LOS PARAMETROS DEL USER TYPE
            LISTA_IDSxx.Rule = LISTA_IDSxx + coma + id + TIPOS_VARIABLES
                              | LISTA_IDSxx + coma + id + id
                              | id + TIPOS_VARIABLES
                              | id + id;
            LISTA_IDSxx.ErrorRule = SyntaxError + "}";
            #endregion


            #region CREACIO1 DE UT

            USER_TYPE.Rule = id + id2
                             | id + id2 + igual + NULO
                             | id2 + igual + nuevo + id
                             | id + id2 + igual + nuevo + id;
            USER_TYPE.ErrorRule = SyntaxError + ";";
            #endregion




            #region ASIGNAR VALORES UT
            USER_TYPE2.Rule = id + id2 + igual + llaveAbierta + LISTA_EXPRESIONobjetos + llaverCerrada + ELAS + id + PYC
                             | id2 + igual + llaveAbierta + LISTA_EXPRESIONobjetos + llaverCerrada + ELAS + id + PYC;
            //  | id + id2 + igual + llaveAbierta + LISTA_EXPRESION + llaverCerrada;
            USER_TYPE2.ErrorRule = SyntaxError + ";";
            
            LISTA_EXPRESIONobjetos.Rule = E
                                    | E + coma + LISTA_EXPRESIONobjetos
                                    | llaveAbierta + LISTA_EXPRESIONobjetos + llaverCerrada + ELAS + id
                                    | llaveAbierta + LISTA_EXPRESIONobjetos + llaverCerrada + ELAS + id + coma + LISTA_EXPRESIONobjetos;
            LISTA_EXPRESIONobjetos.ErrorRule = SyntaxError + ";";

            #endregion




            LISTA_EXPRESION.Rule = E  
                                | E + coma + LISTA_EXPRESION;
            LISTA_EXPRESION.ErrorRule = SyntaxError + ";";


            LISTA_IDS.Rule = LISTA_IDS + coma + TIPOS_VARIABLES + id
                            | LISTA_IDS + coma + USER_TYPE
                            | TIPOS_VARIABLES + id
                            | USER_TYPE;


            TIPOS_VARIABLES.Rule = Entero | Decimal | Cadena | Boolenano | Date | Time;

            E.Rule = E + mas + E
                    | E + menos + E
                    | E + por + E
                    | E + div + E
                    | E + potencia + E
                    | E + modulo + E
                    | E + mayor + E
                    | E + menor + E
                    | E + mayor_que + E
                    | E + menor_que + E
                    | E + igual_igual + E
                    | E + diferente + E
                    | E + OR + E
                    | E + AND + E
                    | E + XOR + E
                    | E + mas + mas
                    | E + menos + menos
                    | NOT + E
                    | menos + E
                    | numero
                    | numdecimal
                    | cadena
                    | id
                    | id + ParA + ParC // para las funciones sin parametros que un usuario creo
                    | id + ParA + LISTA_EXPRESION + ParC
                    | id2
                    | id2 + ParA + ParC  // para las funciones que retornan algo, sin parametros
                    | id2 + ParA + E + ParC // para para una expresion
                    | id2 + ParA + E + coma + E + ParC // PARA UNA FUNCION CON DOS PARAMETROS
                    | falso
                    | verdadero
                    | fechas
                    | hora
                    | ParA + E + ParC
                    | E + CorcheteCA + E
                    | CorcheteAA + TIPOS_VARIABLES
                    | HOY + ParA + ParC
                    | AHORA + ParA + ParC;

           

            #endregion

            #region Preferencias
            this.Root = S;
            #endregion


        }

    }
}