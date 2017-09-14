using System;

namespace AlgoLundi
{
    public class ExpressionGrammar
    {
        string _forbidden = "()";
        string _forbiddenChar = "()*/";
        public BaseNode IsCorrectExpression(string expression)
        {
            int index = 0;
            BaseNode tree = null;
            return BaseGrammar(expression, ref index, ref tree) ? tree : null;
        }
        private bool BaseGrammar(string expression, ref int index, ref BaseNode tree, bool insideParentheses = false)
        {
            if (expression.Contains(_forbidden)) return false;
            // Char Verification
            // || _forbidden.Contains(expression[index - 1].ToString())
            while (Char.IsLetterOrDigit(expression[index]))
            {
                if (index != 0 && (Char.IsLetterOrDigit(expression[index - 1]) || expression[index - 1] == ')'))
                {
                    BaseNode letter = new BaseNode(expression[index].ToString());
                    ComplexNode concat = new ComplexNode("concat", tree, letter);
                    tree = concat;
                }
                else
                    tree = new BaseNode(expression[index].ToString());
                index++;
                if (index == expression.Length) return true;
            }

            // Parentheses Verification
            if (expression[index] == '(')
            {
                if (!ParenthesesGrammar(expression, ref index, ref tree, insideParentheses)) return false;
                if (index == expression.Length) return true;

            }

            //Expression can start with Char and Parentheses only
            if (index == 0) return false;

            // Star verification
            if (expression[index] == '*')
            {
                if (tree as ComplexNode == null || expression[index - 1] == ')')
                    tree = new SimpleNode("star", tree);
                else
                    tree = new ComplexNode("concat", (tree as ComplexNode).Left, new SimpleNode("star", (tree as ComplexNode).Rigth));
                if (!StarGrammar(expression, ref index, ref tree, insideParentheses)) return false;
                if (index == expression.Length) return true;
            }

            // Logic Verification
            if (expression[index] == '|')
            {
                BaseNode secondExpression = null;
                if (!LogicGrammar(expression, ref index, ref secondExpression, insideParentheses)) return false;
                ComplexNode complex = new ComplexNode("alt", tree, secondExpression);
                tree = complex;
                if (index == expression.Length) return true;
            }

            if (insideParentheses && expression[index] == ')')
            {
                return true;
            }
            return false;
        }

        private bool ParenthesesGrammar(string expression, ref int index, ref BaseNode tree, bool insideParentheses)
        {
            index++;
            BaseNode parentheses = null;
            if (expression[index] == '*' || expression[index] == '|')
                return false;
            if (BaseGrammar(expression, ref index, ref parentheses, true) && index < expression.Length && expression[index] == ')')
            {
                index++;
                if (tree == null)
                    tree = parentheses;
                else
                    tree = new ComplexNode("concat", tree, parentheses);
                if (index == expression.Length) return true;
                if (expression[index] == '*' || expression[index] == '|') return true;
                return BaseGrammar(expression, ref index, ref tree, insideParentheses);
            }
            return false;
        }

        private bool LogicGrammar(string expression, ref int index, ref BaseNode tree, bool insideParentheses)
        {
            index++;
            if (index == expression.Length) return false;
            if (expression[index] == ')' || expression[index] == '*' || expression[index] == '|') return false;
            return BaseGrammar(expression, ref index, ref tree, insideParentheses);
        }

        private bool StarGrammar(string expression, ref int index, ref BaseNode tree, bool insideParentheses)
        {
            index++;
            if (index == expression.Length) return true;
            if (expression[index] == '*') return false;
            return BaseGrammar(expression, ref index, ref tree, insideParentheses);
        }
    }

    public class BaseNode
    {
        public BaseNode(string name)
        {
            Name = name;
        }
        public string Name { get; private set; }
    }
    public class SimpleNode : BaseNode
    {
        public SimpleNode(string name, BaseNode left) : base(name)
        {
            Left = left;
        }
        public BaseNode Left { get; private set; }

    }
    public class ComplexNode : SimpleNode
    {
        public ComplexNode(string name, BaseNode left, BaseNode rigth)
            : base(name, left)
        {
            Rigth = rigth;
        }
        public BaseNode Rigth { get; private set; }
    }
}
