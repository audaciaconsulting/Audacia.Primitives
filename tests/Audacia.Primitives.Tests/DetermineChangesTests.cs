using Audacia.Primitives.Tests.Models;
using Audacia.Random.Extensions;
using FluentAssertions;

namespace Audacia.Primitives.Tests;

public class DetermineChangesTests
{
    private readonly IEnumerable<Person> _existingSource;

    public DetermineChangesTests()
    {
        _existingSource = new List<Person>
        {
            new(1, Random.Data.FemaleNames.Random(), Random.Data.Surnames.Random()),
            new(2, Random.Data.MaleNames.Random(), Random.Data.Surnames.Random()),
            new(3, Random.Data.FemaleNames.Random(), Random.Data.Surnames.Random()),
            new(4, Random.Data.MaleNames.Random(), Random.Data.Surnames.Random()),
            new(5, Random.Data.FemaleNames.Random(), Random.Data.Surnames.Random()),
            new(6, Random.Data.MaleNames.Random(), Random.Data.Surnames.Random())
        };
    }

    [Fact]
    public void Should_return_all_entities_to_add()
    {
        // Arrange
        var existingSource = Array.Empty<Person>();
        var newSource = new List<Person>()
        {
            new(0, Random.Data.FemaleNames.Random(), Random.Data.Surnames.Random()),
            new(0, Random.Data.MaleNames.Random(), Random.Data.Surnames.Random()),
            new(0, Random.Data.FemaleNames.Random(), Random.Data.Surnames.Random())
        };

        // Act
        var (toAdd, toUpdate, toRemove) = existingSource.DetermineChanges(newSource);

        // Assert
        toAdd.Should().BeEquivalentTo(newSource);
        toUpdate.Should().BeEmpty();
        toRemove.Should().BeEmpty();
    }

    [Fact]
    public void Should_return_all_entities_to_update()
    {
        // Arrange
        var newSource = _existingSource.Select(person =>
            {
                person.FirstName = Random.Data.MaleNames.Random();
                person.LastName = Random.Data.Surnames.Random();

                return person;
            })
            .ToList();

        // Act
        var (toAdd, toUpdate, toRemove) = _existingSource.DetermineChanges(newSource);

        // Assert
        toAdd.Should().BeEmpty();
        toUpdate.Should().BeEquivalentTo(newSource);
        toRemove.Should().BeEmpty();
    }

    [Fact]
    public void Should_return_all_entities_to_remove()
    {
        // Arrange
        var newSource = Array.Empty<Person>();

        // Act
        var (toAdd, toUpdate, toRemove) = _existingSource.DetermineChanges(newSource);

        // Assert
        toAdd.Should().BeEmpty();
        toUpdate.Should().BeEmpty();
        toRemove.Should().BeEquivalentTo(_existingSource);
    }

    [Fact]
    public void Should_return_an_entity_to_add_update_and_remove()
    {
        // Arrange
        var peopleToAdd = new List<Person>
        {
            new(0, Random.Data.FemaleNames.Random(), Random.Data.Surnames.Random())
        };
        var peopleToRemove = new List<Person>
        {
            _existingSource.First()
        };
        var peopleToUpdate = _existingSource.Skip(1)
            .Select(person =>
            {
                person.FirstName = Random.Data.MaleNames.Random();
                person.LastName = Random.Data.Surnames.Random();

                return person;
            })
            .ToList();
        var newSource = new List<Person>();
        newSource.AddRange(peopleToAdd);
        newSource.AddRange(peopleToUpdate);

        // Act
        var (toAdd, toUpdate, toRemove) = _existingSource.DetermineChanges(newSource);

        // Assert
        toAdd.Should().BeEquivalentTo(peopleToAdd);
        toUpdate.Should().BeEquivalentTo(peopleToUpdate);
        toRemove.Should().BeEquivalentTo(peopleToRemove);
    }
}
