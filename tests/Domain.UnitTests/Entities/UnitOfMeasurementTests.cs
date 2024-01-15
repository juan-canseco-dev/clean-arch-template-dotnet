namespace CleanArchTemplate.Domain.UnitTests.Entities;

public class UnitOfMeasurementTests
{
    [Test]
    public void CreateUnitWhenAllPropertiesArePresentShouldCreateSuccessful()
    {
        var id = 1;
        var name = "Each";
        var unit = new UnitOfMeasurement(id, name);
        unit.Id.Should().Be(id);
        unit.Name.Should().Be(name);
    }

    [Test]
    public void CreateUnitWhenPropertiesAreNotPresentShouldThrowException([ValueSource(nameof(UnitData))] object[] unitData)
    {
        Action createUnit = () =>
        {
            int id = (int)unitData[0];
            string name = (string)unitData[1];
            var unit = new UnitOfMeasurement(id, name);
        };
        createUnit.Should().Throw<ArgumentException>();
    }

    [Test]
    public void UpdateUnitWhenNameIsPresentShouldUpdateSuccessfull()
    {
        var oldName = "Old Name";
        var newName = "New Name";
        var unit = new UnitOfMeasurement(1, oldName);
        unit.Update(newName);
        unit.Name.Should().Be(newName);
    }


    [Test]
    public void UpdateUnitWhenNameIsNotPresentShouldThrowException()
    {
        Action updateUnit = () =>
        {
            var unit = new UnitOfMeasurement(1, "Each");
            unit.Update("");
        };
        updateUnit.Should().Throw<ArgumentException>();
    }


    static object[] UnitData = new object[]
    {
        new object[] {0, "Kilogram"},
        new object[] {1, ""}
    };
}
