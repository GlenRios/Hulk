namespace HULK;
public abstract class Expresion
{

    public class ExprUnaria : Expresion
    {
        public Token Token;
        public Expresion Derecha;
        public ExprUnaria(Token token, Expresion derecha)
        {
            Token = token;
            Derecha = derecha;
        }
        public object VisitExprUnaria(object derecha)
        {
            if (Token.Type == TokenType.Resta)
            {
                if (derecha is double)
                {
                    return -1 * (double)derecha;
                }
                throw new Exception("El Operador '-' no puede usarse delante de" + " " + derecha);
            }
            if (Token.Type == TokenType.Negacion)
            {
                if (derecha is bool)
                {
                    return !(bool)derecha;
                }
                throw new Exception("El Operador '!' no puede usarse delante de" + " " + derecha);
            }
            return null!;
        }
    }
    public class ExprBinaria : Expresion
    {
        public Expresion Izquierda;
        public Token Operador;
        public Expresion Derecha;
        public ExprBinaria(Expresion izquierda, Token operador, Expresion derecha)
        {
            Izquierda = izquierda;
            Operador = operador;
            Derecha = derecha;
        }
        public object VisitExprBinaria(object izquierda, object derecha)
        {
            if (Operador.Type == TokenType.IgualIgual)
            {
                return IgualIgual(izquierda, derecha);
            }
            if (Operador.Type == TokenType.NoIgual)
            {
                return NoIgual(izquierda, derecha);
            }
            if (Operador.Type == TokenType.MenorIgual)
            {
                return MenorIgual(izquierda, derecha);
            }
            if (Operador.Type == TokenType.MayorIgual)
            {
                return MayorIgual(izquierda, derecha);
            }
            if (Operador.Type == TokenType.Menor)
            {
                return Menor(izquierda, derecha);
            }
            if (Operador.Type == TokenType.Mayor)
            {
                return Mayor(izquierda, derecha);
            }
            if (Operador.Type == TokenType.And)
            {
                return And(izquierda, derecha);
            }
            if (Operador.Type == TokenType.Or)
            {
                return Or(izquierda, derecha);
            }
            if (Operador.Type == TokenType.Suma)
            {
                return Suma(izquierda, derecha);
            }
            if (Operador.Type == TokenType.Resta)
            {
                return Resta(izquierda, derecha);
            }
            if (Operador.Type == TokenType.Concatenar)
            {
                return Concatenar(izquierda, derecha);
            }
            if (Operador.Type == TokenType.Multiplicacion)
            {
                return Multiplicacion(izquierda, derecha);
            }
            if (Operador.Type == TokenType.Division)
            {
                return Division(izquierda, derecha);
            }
            if (Operador.Type == TokenType.Pow)
            {
                return Pow(izquierda, derecha);
            }
            if (Operador.Type == TokenType.Modulo)
            {
                return Modulo(izquierda, derecha);
            }
            return null!;
        }
        public object IgualIgual(object izquierda, object derecha)
        {
            if (izquierda is double && derecha is double)
            {
                if ((double)izquierda == (double)derecha) return true;
                else return false;
            }
            if (izquierda is bool && derecha is bool)
            {
                if ((bool)izquierda == (bool)derecha) return true;
                else return false;
            }
            if (izquierda is string && derecha is string)
            {
                if ((string)izquierda == (string)derecha) return true;
                else return false;
            }
            else throw new Exception("El Operador == no puede estar entre" + " " + izquierda + " " + derecha);

        }
        public object NoIgual(object izquierda, object derecha)
        {
            if (izquierda is double && derecha is double)
            {
                if ((double)izquierda != (double)derecha) return true;
                else return false;
            }
            if (izquierda is bool && derecha is bool)
            {
                if ((bool)izquierda != (bool)derecha) return true;
                else return false;
            }
            if (izquierda is string && derecha is string)
            {
                if ((string)izquierda != (string)derecha) return true;
                else return false;
            }
            else throw new Exception("El Operador != no puede estar entre" + " " + izquierda + " " + derecha);
        }

        public object MenorIgual(object izquierda, object derecha)
        {
            if (izquierda is double && derecha is double)
                return (double)izquierda <= (double)derecha;

            else throw new Exception("El Operador <= no puede estar entre" + " " + izquierda + " " + derecha);
        }
        public object MayorIgual(object izquierda, object derecha)
        {
            if (izquierda is double && derecha is double)
                return (double)izquierda >= (double)derecha;

            else throw new Exception("El Operador >= no puede estar entre" + " " + izquierda + " " + derecha);
        }
        public object Menor(object izquierda, object derecha)
        {
            if (izquierda is double && derecha is double)
                return (double)izquierda < (double)derecha;

            else throw new Exception("El Operador < no puede estar entre" + " " + izquierda + " " + derecha);
        }
        public object Mayor(object izquierda, object derecha)
        {
            if (izquierda is double && derecha is double)
                return (double)izquierda > (double)derecha;

            else throw new Exception("El Operador > no puede estar entre" + " " + izquierda + " " + derecha);
        }
        public object And(object izquierda, object derecha)
        {
            if (izquierda is bool && derecha is bool)
                return (bool)izquierda && (bool)derecha;

            else throw new Exception("El Operador && no puede estar entre" + " " + izquierda + " " + derecha);
        }
        public object Or(object izquierda, object derecha)
        {
            if (izquierda is bool && derecha is bool)
                return (bool)izquierda || (bool)derecha;

            else throw new Exception("El Operador || no puede estar entre" + " " + izquierda + " " + derecha);
        }
        public object Suma(object izquierda, object derecha)
        {
            if (izquierda is double && derecha is double)
                return (double)izquierda + (double)derecha;
            else throw new Exception("El Operador + no puede estar entre" + " " + izquierda + " " + derecha);
        }
        public object Resta(object izquierda, object derecha)
        {
            if (izquierda is double && derecha is double)
                return (double)izquierda - (double)derecha;
            else throw new Exception("El Operador - no puede estar entre" + " " + izquierda + " " + derecha);
        }
        public object Multiplicacion(object izquierda, object derecha)
        {
            if (izquierda is double && derecha is double)
                return (double)izquierda * (double)derecha;
            else throw new Exception("El Operador * no puede estar entre" + " " + izquierda + " " + derecha);
        }
        public object Division(object izquierda, object derecha)
        {
            if (izquierda is double && derecha is double)
                return (double)izquierda / (double)derecha;
            else throw new Exception("El Operador / no puede estar entre" + " " + izquierda + " " + derecha);
        }
        public object Pow(object izquierda, object derecha)
        {
            if (izquierda is double && derecha is double)
                return Math.Pow((double)izquierda, (double)derecha);
            else throw new Exception("El Operador ^ no puede estar entre" + " " + izquierda + " " + derecha);
        }
        public object Modulo(object izquierda, object derecha)
        {
            if (izquierda is double && derecha is double)
                return (double)izquierda % (double)derecha;
            else throw new Exception("El Operador + no puede estar entre" + " " + izquierda + " " + derecha);
        }
        public object Concatenar(object izquierda, object derecha)
        {
            string resultado = "";
            if (izquierda is string)
            {
                resultado += izquierda;
            }
            if (izquierda is double)
            {
                resultado += (double)izquierda;
            }
            if (izquierda is bool)
            {
                resultado += (bool)izquierda;
            }
            if (derecha is string)
            {
                resultado += derecha;
            }
            if (derecha is double)
            {
                resultado += (double)derecha;
            }
            if (derecha is bool)
            {
                resultado += (bool)derecha;
            }
            return resultado;
        }
    }
    public class ExprLiteral : Expresion
    {
        public object literal;
        public ExprLiteral(object literal)
        {
            this.literal = literal;
        }
        public object VisitExprLiteral(ExprLiteral expr)
        {
            return expr.literal;
        }
    }
    public class ExprAsignar : Expresion
    {
        public Token Nombre;
        public Expresion Valor;
        public ExprAsignar(Token nombre, Expresion valor)
        {
            Nombre = nombre;
            Valor = valor;
        }
    }
    public class ExprVariable : Expresion
    {
        public Token Nombre;
        public ExprVariable(Token nombre)
        {
            Nombre = nombre;
        }
        public object VisitExprVariable(Dictionary<object, object> asign, Token variable)
        {
            if (asign is null)
                throw new Exception("Variable " + variable.Value + " no tiene un valor asignado");
            foreach (var objecto in asign)
            {
                if (asign.ContainsKey(variable.Value))
                    return asign[variable.Value];
            }
            throw new Exception("Variable " + variable.Value + " no tiene un valor asignado");
        }
    }
    public class ExprLLamadaFuncion : Expresion
    {
        public string Identificador;
        public List<Expresion> Argumento;
        public Funcion funcion;
        public ExprLLamadaFuncion(string identificador, List<Expresion> argumento, Funcion funcion)
        {
            Identificador = identificador;
            Argumento = argumento;
            this.funcion = funcion;
        }
        public object VisitExprLlamada(ExprLLamadaFuncion call, Dictionary<object, object> valor)
        {
            Funcion funcion = call.funcion;

            string name = call.Identificador;

            List<Expresion> argument = call.Argumento;

            switch (name)
            {
                case "sen":
                    return Sen(argument, valor);

                case "cos":
                    return Cos(argument, valor);

                case "print":
                    return Print(argument, valor);

                case "log":
                    return Log(argument, valor);

                case "sqrt":
                    return Sqrt(argument, valor);

                default:
                    return VisitFuncion(call);
            }
        }
        public object Sen(List<Expresion> argument, Dictionary<object, object> valor)
        {
            if (argument.Count == 1)
            {
                return Math.Sin((double)Evaluador.GetValue(argument[0], valor));
            }
            throw new Exception("La funcion sen no admite mas de un argumento");
        }
        public object Cos(List<Expresion> argument, Dictionary<object, object> valor)
        {
            if (argument.Count == 1)
            {
                return Math.Cos((double)Evaluador.GetValue(argument[0], valor));
            }
            throw new Exception("La funcion cos no admite mas de un argumento");
        }
        public object Sqrt(List<Expresion> argument, Dictionary<object, object> valor)
        {
            if (argument.Count == 1)
            {
                return Math.Sqrt((double)Evaluador.GetValue(argument[0], valor));
            }
            throw new Exception("La funcion sqrt no admite mas de un argumento");
        }
        public object Log(List<Expresion> argument, Dictionary<object, object> valor)
        {
            if (argument.Count == 1)
            {
                return Math.Log10((double)Evaluador.GetValue(argument[0], valor));
            }
            throw new Exception("La funcion log no admite mas de un argumento");
        }
        public object Print(List<Expresion> argument, Dictionary<object, object> valor)
        {
            if (argument.Count == 1)
            {
                return Evaluador.GetValue(argument[0], valor);
            }

            throw new Exception("Una declaracion de print solo recibe un argumento");
        }
        public object VisitFuncion(ExprLLamadaFuncion call)
        {
            Dictionary<object, object> asig = Funcion.VisitarFuncion(call.Argumento, call.funcion.Parametros);
            return Evaluador.GetValue(call.funcion.Cuerpo, asig);
        }
    }
    public class Funcion : Expresion
    {
        public string Identificador;
        public List<object> Parametros;
        public Expresion Cuerpo;
        public Funcion(string identificador, List<object> parametros, Expresion cuerpo)
        {
            Identificador = identificador;
            Parametros = parametros;
            Cuerpo = cuerpo;
        }
        public Funcion()
        {
            Identificador = null!;
            Parametros = null!;
            Cuerpo = null!;
        }

        public static Dictionary<object, object> VisitarFuncion(List<Expresion> argument, List<object> parametros)
        {
            if (argument.Count == parametros.Count)
            {
                int count = 0;
                Dictionary<object, object> ValorDeLosParametros = new Dictionary<object, object>();
                foreach (var x in argument)
                {
                    object valor = Evaluador.GetValue(x, ValorDeLosParametros);
                    ValorDeLosParametros.Add(parametros[count], valor);
                    count++;
                }

                return ValorDeLosParametros;
            }

            throw new Exception("La cantidad de argumentos que recibe la funcion no es la dada");
        }
    }
    public class If : Expresion
    {
        public Expresion Condicion;
        public Expresion IfCuerpo;
        public Expresion ElseCuerpo;
        public If(Expresion condicion, Expresion ifCuerpo, Expresion elseCuerpo)
        {
            Condicion = condicion;
            IfCuerpo = ifCuerpo;
            ElseCuerpo = elseCuerpo;
        }
        public object VisitExprIF(object condicion, object ifCuerpo, object elseCuerpo)
        {
            if (condicion is bool)
            {
                bool Condicion = (bool)condicion;
                if (Condicion == true)
                {
                    return ifCuerpo;
                }
                else return elseCuerpo;
            }
            throw new Exception("Error");
        }
    }

    public class LetIn : Expresion
    {
        public List<ExprAsignar> LetCuerpo;
        public Expresion InCuerpo;
        public LetIn(List<ExprAsignar> letCuerpo, Expresion inCuerpo)
        {
            LetCuerpo = letCuerpo;
            InCuerpo = inCuerpo;
        }

    }
    public class ExprGrouping : Expresion
    {
        public Expresion Expr;
        public ExprGrouping(Expresion expr)
        {
            Expr = expr;
        }
    }
}