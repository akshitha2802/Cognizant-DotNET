using NUnit.Framework;
using CalcLibrary;

namespace CalcLibrary.Tests;

[TestFixture]
public class SimpleCalculatorTests
{
    private SimpleCalculator calculator;

    [SetUp]
    public void Setup()
    {
        calculator = new SimpleCalculator();
    }

    [TearDown]
    public void Cleanup()
    {
        calculator.AllClear();
    }

    [TestCase(10, 20, 30)]
    [TestCase(5, 7, 12)]
    [TestCase(-5, 5, 0)]
    public void Addition_Test(double a, double b, double expected)
    {
        Assert.That(calculator.Addition(a, b), Is.EqualTo(expected));
    }

    [TestCase(20, 10, 10)]
    [TestCase(7, 5, 2)]
    public void Subtraction_Test(double a, double b, double expected)
    {
        Assert.That(calculator.Subtraction(a, b), Is.EqualTo(expected));
    }

    [TestCase(5, 4, 20)]
    [TestCase(3, 3, 9)]
    public void Multiplication_Test(double a, double b, double expected)
    {
        Assert.That(calculator.Multiplication(a, b), Is.EqualTo(expected));
    }

    [TestCase(20, 4, 5)]
    [TestCase(9, 3, 3)]
    public void Division_Test(double a, double b, double expected)
    {
        Assert.That(calculator.Division(a, b), Is.EqualTo(expected));
    }

    [Test]
    public void Division_By_Zero_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => calculator.Division(10, 0));
    }

    [Test]
    public void AllClear_Should_Reset_Result()
    {
        calculator.Addition(5, 10);
        calculator.AllClear();

        Assert.That(calculator.GetResult, Is.EqualTo(0));
    }
}