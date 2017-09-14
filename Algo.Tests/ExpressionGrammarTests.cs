using AlgoLundi;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo.Tests
{
    [TestFixture]
    public class ExpressionGrammarTests
    {
        [TestCase("a")]
        [TestCase("ab")]
        [TestCase("abc")]
        [TestCase("abcdabcdabcd")]
        [TestCase("ab*")]
        [TestCase("a*")]
        [TestCase("(a)")]
        [TestCase("(ab)")]
        [TestCase("(a*)")]
        [TestCase("(ab*)")]
        [TestCase("a|b")]
        [TestCase("ab|a")]
        [TestCase("(ab)|a")]
        [TestCase("(ab)*|a")]
        [TestCase("(ab)*|ab")]
        [TestCase("(ab)*|(ab)")]
        [TestCase("((ab)*|(ab))")]
        [TestCase("a(b|a)b|a")]
        [TestCase("ab*|ab|a*")]
        public void Expression_Should_Be_Valid(string expression)
        {
            ExpressionGrammar e = new ExpressionGrammar();
            Assert.IsNotNull(e.IsCorrectExpression(expression));
        }

        [TestCase("*a")]
        [TestCase("a**")]
        [TestCase("a|")]
        [TestCase("(a|b")]
        [TestCase("()")]
        [TestCase("(*)")]
        [TestCase("(a|(ba)")]
        [TestCase("(a||(ba)")]
        [TestCase("(a*|()b")]
        public void Expression_Should_Not_Be_Valid(string expression)
        {
            ExpressionGrammar e = new ExpressionGrammar();
            Assert.IsNull(e.IsCorrectExpression(expression));
        }
    }
}
