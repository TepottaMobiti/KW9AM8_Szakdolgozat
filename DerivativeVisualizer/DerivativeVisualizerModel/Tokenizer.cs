﻿namespace DerivativeVisualizerModel
{
    /*
     Tokeneket csinál az inputból.
     A whitespaceket törli.
     Elfogad az inputban: whitespaceket, x-et mint változó, függvényeket, +, -, *, /, ^, (, ), számokat, e-t mint szimbólum.
     Függvények: "log", "sin", "cos", "tan", "cot", "arcsin", "arccos", "arctan", "arccot", "sinh", "cosh", "tanh", "coth", "arsinh", "arcosh", "artanh", "arcoth"
     Szekánsékat kihagyjuk, nem szeretnék abszolútértékkel szórakozni, azok lesznek, amik voltak az egyetemen.
     Kérdés: Legyen pi? Most még nem lesz, aztán ha kell, majd lesz.
     */

    public class Tokenizer
    {
        private string input;
        private int currentIndex;

        public Tokenizer(string input)
        {
            this.input = input;
            currentIndex = 0;
        }

        public List<Token> Tokenize()
        {
            List<Token> tokens = new List<Token>();
            while (currentIndex < input.Length)
            {
                char c = input[currentIndex];
                if (char.IsWhiteSpace(c))
                {
                    currentIndex++;
                    continue;
                }
                if (char.IsDigit(c))
                {
                    tokens.Add(TokenizeNumber());
                    continue;
                }
                if (char.IsLetter(c))
                {
                    tokens.Add(TokenizeFunctionOrVariable());
                    continue;
                }
                switch (c)
                {
                    case '+':
                    case '-':
                    case '*':
                    case '/':
                    case '^':
                        tokens.Add(new Token(c.ToString(), TokenType.Operator));
                        currentIndex++;
                        continue;
                    case '(':
                        tokens.Add(new Token(c.ToString(), TokenType.LeftParen));
                        currentIndex++;
                        continue;
                    case ')':
                        tokens.Add(new Token(c.ToString(), TokenType.RightParen));
                        currentIndex++;
                        continue;
                    case ',':
                        tokens.Add(new Token(c.ToString(), TokenType.Comma));
                        currentIndex++;
                        continue;
                }
                throw new Exception($"Unexpected character: {c}");
            }
            return tokens;
        }

        private Token TokenizeNumber()
        {
            string number = string.Empty;
            bool hasDecimal = false;
            while(currentIndex < input.Length && (char.IsDigit(input[currentIndex]) || input[currentIndex] == '.'))
            {
                if (input[currentIndex] == '.')
                {
                    if(hasDecimal)
                    {
                        throw new Exception("Invalid number format: multiple decimal points.");
                    }
                    hasDecimal = true;
                }
                number += input[currentIndex];
                currentIndex++;
            }
            return new Token(number,TokenType.Number);
        }

        private Token TokenizeFunctionOrVariable()
        {
            string name = string.Empty;
            while(currentIndex < input.Length && char.IsLetter(input[currentIndex]))
            {
                name += input[currentIndex];
                currentIndex++;
            }

            string[] functions = {"log", "sin", "cos", "tan", "cot", "arcsin", "arccos", "arctan", "arccot", "sinh", "cosh", "tanh", "coth", "arsinh", "arcosh", "artanh", "arcoth"};
            if (Array.Exists(functions, func => func == name))
            {
                return new Token(name, TokenType.Function);
            }
            if (name == "x")
            {
                return new Token(name, TokenType.Variable);
            }
            if (name == "e")
            {
                return new Token(name, TokenType.Number);
            }
            throw new Exception($"Unexpected identifier: {name}. Only variable 'x' and known functions are allowed"); // Legyen egyértelmű az appból, hogy mik az ismert függvények.
        }
    }
}