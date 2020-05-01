using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithm
{
    class Calculator : IAlgorithm
    {
        public void Execute()
        {
            string expression = "1+2*3-(4+2)/3";
            double ret = 0;
            try
            {
                ret = Calculate(expression);
                Console.WriteLine($"{expression}={ret}");
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Expression {expression} invalid:{ex.Message}");
            }
        }

        private bool IsNumber(char c)
        {
            char[] target = { '.', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            bool ret = false;
            foreach (char item in target)
            {
                if (c == item)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        private bool IsOperator(char c)
        {
            char[] target = { '+', '-', '*', '/', '(', ')' };
            bool ret = false;
            foreach (char item in target)
            {
                if (c == item)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        /// <summary>
        /// 计算结果
        /// </summary>
        /// <param name="left">左操作数</param>
        /// <param name="right">右操作数</param>
        /// <param name="op">操作符</param>
        /// <returns>计算结果</returns>
        private double Compute(double left, double right, char op)
        {
            if (op == '+')
            {
                return left + right;
            }
            else if (op == '-')
            {
                return left - right;
            }
            else if (op == '*')
            {
                return left * right;
            }
            else if (op == '/')
            {
                return left / right;
            }
            else
            {
                throw new ArgumentException($"Operator {op} invalid");
            }
        }

        /// <summary>
        /// 计算括号内的值
        /// </summary>
        /// <param name="args">操作数栈</param>
        /// <param name="operators">操作符栈</param>
        private void ComputeBracket(Stack<double> args, Stack<char> operators)
        {
            char op = operators.Pop();
            double left = 0;
            double right = 0;
            double val = 0;
            while (op != '(')
            {
                right = args.Pop();
                left = args.Pop();
                val = Compute(left, right, op);
                args.Push(val);
                op = operators.Pop();
            }
        }

        /// <summary>
        /// 比较优先级并计算优先级较高的操作符
        /// </summary>
        /// <param name="args">操作数栈</param>
        /// <param name="operators">操作符栈</param>
        /// <param name="op">比较的操作符</param>
        private void ComparePriority(Stack<double> args, Stack<char> operators, char op)
        {
            Dictionary<char, int> priority = new Dictionary<char, int> 
                { { '+', 1 }, { '-', 1 }, { '*', 2 }, { '/', 2 }, { '(', 0 }, { ')', 0 } };
            // 操作符栈为空时直接返回
            if (operators.Count == 0)
            {
                return;
            }

            char top = operators.Peek();
            char operatorChar = default(char);
            double left = 0;
            double right = 0;
            double val = 0;
            // 当前操作符比栈顶的操作符优先级更低
            while (priority[top] >= priority[op])
            {
                right = args.Pop();
                left = args.Pop();
                operatorChar = operators.Pop();
                val = Compute(left, right, operatorChar);
                args.Push(val);
                //操作符栈已经为空就退出
                if (operators.Count == 0)
                {
                    break;
                }
                else
                {
                    top = operators.Peek();
                }
            }
        }

        /// <summary>
        /// 计算表达式结果
        /// </summary>
        /// <param name="expression">中缀表达式</param>
        /// <returns>计算结果</returns>
        private double Calculate(string expression)
        {
            Stack<double> args = new Stack<double>();
            Stack<char> operators = new Stack<char>();
            StringBuilder argStr = new StringBuilder();
            double arg = 0;
            // 为了省事, 直接加括号
            expression = $"({expression})";
            // 循环获取每个字符
            foreach (char c in expression)
            {
                if(IsOperator(c))
                {
                    // 解析操作数字符串并将操作数加入栈中
                    if (argStr.Length > 0)
                    {
                        arg = double.Parse(argStr.ToString());
                        argStr.Clear();
                        args.Push(arg);
                    }
                    // 括号结束了, 把括号内的值运算出来
                    if (c == ')')
                    {
                        ComputeBracket(args, operators);
                    }
                    // 括号开始, 直接加入
                    else if (c == '(')
                    {
                        operators.Push(c);
                    }
                    else
                    {
                        // 操作符比对后加入栈中
                        ComparePriority(args, operators, c);
                        operators.Push(c);
                    }
                }
                else
                {
                    // 组建操作数字符串
                    if (IsNumber(c))
                    {
                        argStr.Append(c);
                    }
                    else
                    {
                        throw new ArgumentException($"format error [{expression}] is not valid expression");
                    }
                }
            }
            // 因为开始的时候直接加了括号，括号也算运算符，所以这里直接就能拿到结果
            return args.Peek();
        }
    }
}
