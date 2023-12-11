using System.Collections.Generic;

using NUnit.Framework;

namespace TestApp.Tests;

[TestFixture]
public class DictionaryIntersectionTests
{
    [Test]
    public void Test_Intersect_TwoEmptyDictionaries_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> input1 = new();
        Dictionary<string, int> input2 = new();

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(input1, input2);

        // Assert
        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Test_Intersect_OneEmptyDictionaryAndOneNonEmptyDictionary_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> input1 = new();
        Dictionary<string, int> input2 = new()
        {
            ["first"] = 5,
            ["second"] = 10,
            ["third"] = 15
        };

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(input1, input2);

        // Assert
        Assert.That (result, Is.Empty);
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithNoCommonKeys_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> input1 = new()
        {
            ["first"] = 1,
            ["second"] = 2,
        };
        Dictionary<string, int> input2 = new()
        {
            ["third"] = 3,
            ["first"] = 4,
        };
        Dictionary<string, int> expected = new();

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(input1 , input2);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndValues_ReturnsIntersectionDictionary()
    {
        // Arrange
        Dictionary<string, int> input1 = new()
        {
            ["first"] = 1,
            ["second"] = 2,
        };
        Dictionary<string, int> input2 = new()
        {
            ["third"] = 3,
            ["first"] = 1,
        };
        Dictionary<string, int> expected = new()
        {
            ["first"] = 1
        };

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(input1, input2);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void Test_Intersect_TwoNonEmptyDictionariesWithCommonKeysAndDifferentValues_ReturnsEmptyDictionary()
    {
        // Arrange
        Dictionary<string, int> input1 = new()
        {
            ["first"] = 1,
            ["second"] = 2,
        };
        Dictionary<string, int> input2 = new()
        {
            ["third"] = 3,
            ["first"] = 5,
        };
        Dictionary<string, int> expected = new();

        // Act
        Dictionary<string, int> result = DictionaryIntersection.Intersect(input1, input2);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }
}
