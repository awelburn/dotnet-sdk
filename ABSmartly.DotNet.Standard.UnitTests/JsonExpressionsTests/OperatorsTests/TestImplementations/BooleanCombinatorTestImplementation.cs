﻿using ABSmartly.JsonExpressions;
using ABSmartly.JsonExpressions.Operators;

namespace ABSmartly.DotNet.Standard.UnitTests.JsonExpressionsTests.OperatorsTests.TestImplementations;

public class BooleanCombinatorTestImplementation : BooleanCombinator
{
    public static object ValidResult => "Boolean Pass";

    public override object Combine(IEvaluator evaluator, IList<object> args)
    {
        return ValidResult;
    }
}