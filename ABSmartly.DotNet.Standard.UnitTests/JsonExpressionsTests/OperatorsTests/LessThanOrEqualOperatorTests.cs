﻿using ABSmartly.JsonExpressions;
using ABSmartly.JsonExpressions.Operators;
using Moq;

namespace ABSmartly.DotNet.Standard.UnitTests.JsonExpressionsTests.OperatorsTests;

[TestFixture]
public class LessThanOrEqualOperatorTests
{
#pragma warning disable CS8618
    private Mock<IEvaluator> evaluator;
    private LessThanOrEqualOperator lessThanOrEqualOperator;
#pragma warning restore CS8618

    [SetUp]
    public void Init()
    {
        evaluator = new Mock<IEvaluator>();

        evaluator.Setup(x => x.Evaluate(It.IsAny<object>()))
            .Returns(Evaluate);

        evaluator.Setup(x => x.Compare(It.IsAny<object>(), It.IsAny<object>()))
            .Returns(Compare);

        lessThanOrEqualOperator = new LessThanOrEqualOperator();
    }

    [Test]
    public void Evaluate_CompareResultNull_ReturnsNull()
    {
        var parameters = new List<object> 
            { "null", "unused" };

        var result = lessThanOrEqualOperator.Evaluate(evaluator.Object, parameters);

        Assert.That(result, Is.EqualTo(null));
    }

    [Test]
    public void Evaluate_CompareResultMinusOne_ReturnsTrue()
    {
        var parameters = new List<object> { -1, "unused" };

        var result = lessThanOrEqualOperator.Evaluate(evaluator.Object, parameters);

        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void Evaluate_CompareResultZero_ReturnsTrue()
    {
        var parameters = new List<object> { 0, "unused" };

        var result = lessThanOrEqualOperator.Evaluate(evaluator.Object, parameters);

        Assert.That(result, Is.EqualTo(true));
    }

    [Test]
    public void Evaluate_CompareResultOne_ReturnsFalse()
    {
        var parameters = new List<object> { 1, "unused" };

        var result = lessThanOrEqualOperator.Evaluate(evaluator.Object, parameters);

        Assert.That(result, Is.EqualTo(false));
    }


    #region Helper

    private static object Evaluate(object ob)
    {
        return ob;
    }
    private static int? Compare(object lhs, object rhs)
    {
        if (lhs.ToString() == "null")
            return null;

        if (lhs.ToString() == "-1")
            return -1;

        if (lhs.ToString() == "0")
            return 0;

        if (lhs.ToString() == "1")
            return 1;

        return null;
    }

    #endregion
}