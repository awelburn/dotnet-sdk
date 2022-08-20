﻿namespace ABSmartly.DotNet.Standard.UnitTests;

[TestFixture]
public class ContextConfigTests : TestCases
{
    [TestCase("session_id", "0ab1e23f4eee")]
    [TestCase("testType", "123456")]
    public void Unit_SetAndGet_Returns_ExpectedResult(string unitType, string uid)
    {
        var config = new ContextConfig();
        config.SetUnit(unitType, uid);

        var resultUid = config.GetUnit(unitType);

        Assert.That(resultUid, Is.EqualTo(uid));
    }

    [TestCaseSource(nameof(DictionaryOfStringString))]
    public void Units_SetAndGet_Returns_ExpectedResult(Dictionary<string, string> units)
    {
        var config = new ContextConfig();
        config.SetUnits(units);

        var resultUnits = config.GetUnits();

        Assert.That(resultUnits.Count, Is.EqualTo(units.Count));
        foreach (var kvp in units)
        {
            Assert.That(resultUnits[kvp.Key], Is.EqualTo(kvp.Value));
        }
    }
}