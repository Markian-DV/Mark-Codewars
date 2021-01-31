using System;
using System.Data;
using System.Linq;
using System.Collections.Generic;
//Infix to Postfix and then Postfix to result
namespace codewars
{
    public class Evaluator
    {
        public double Evaluate(string expression)
        {
            string Postfix = this.ConverToPostfix(expression);
            Console.WriteLine(Postfix);
        
            return 0;
        }

        public string ConverToPostfix(string expression,string PostfixExp = "")
        {
            expression = string.Concat(expression.Where(c => !Char.IsWhiteSpace(c)));
            Stack<char> stack = new Stack<char>();
            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '('){ stack.Push('('); continue; }
                if (expression[i] == ')') { while (stack.Peek() != '(') PostfixExp += stack.Pop(); stack.Pop(); continue; }
                if (expression[i] == '+' || expression[i] == '-' || expression[i] == '*' || expression[i] == '/')
                {
                    if (stack.Count() == 0) stack.Push(expression[i]);
                    else
                    {
                        while (stack.Count != 0 && this.Precedence(expression[i]) <= this.Precedence(stack.Peek()))  PostfixExp += stack.Pop();          
                        stack.Push(expression[i]);
                    }
                }
                else PostfixExp += expression[i];
            }
            while (stack.Count != 0)  PostfixExp += stack.Pop();
            return PostfixExp;
        }
        public int Precedence(char a)
        {
            if (a == '+' || a == '-')return 1;
            if (a == '*' || a == '/')return 2;
            return - 1;
        }
        public double SolvePostfix(string exp)
        {
            var dict = new Dictionary<int, Delegate>();
            dict['+'] = new Func<char, char, int>((x, y) => x - '0' + y - '0');
            dict['-'] = new Func<char, char, int>((x, y) => x - '0' - y - '0');
            dict['*'] = new Func<char, char, int>((x, y) => x - '0' * y - '0');
            dict['/'] = new Func<char, char, int>((x, y) => x - '0' / y - '0');
            throw new NotImplementedException("not implemented SolvePostfix");

        }
    }
}
