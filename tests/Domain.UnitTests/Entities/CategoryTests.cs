namespace CleanArchTemplate.Domain.UnitTests.Entities;

public class CategoryTests
{
    [Test]
    public void CreateCategoryWhenAllPropertiesArePresentShouldCreateSuccessful()
    {
        var id = 1;
        var name = "Electronics";
        var category = new Category(id, name);
        category.Id.Should().Be(id);
        category.Name.Should().Be(name);
    }

    [Test]
    public void CreateCategoryWhenPropertiesAreNotPresentShouldThrowException([ValueSource(nameof(CategoryData))] object[] categoryData)
    {
        Action createCategory = () =>
        {
            int id = (int)categoryData[0];
            string name = (string)categoryData[1];
            var category = new Category(id, name);
        };
        createCategory.Should().Throw<ArgumentException>();
    }

    [Test]
    public void UpdateCategoryWhenNameIsPresentShouldUpdateSuccessfull()
    {
        var oldName = "Old Category";
        var newName = "New Name";
        var category = new Category(1, oldName);
        category.Update(newName);
        category.Name.Should().Be(newName);
    }


    [Test]
    public void UpdateCategoryWhenNameIsNotPresentShouldThrowException()
    {
        Action updateCategory = () =>
        {
            var category = new Category(1, "Electronics");
            category.Update("");
        };
        updateCategory.Should().Throw<ArgumentException>();
    }


    static readonly object[] CategoryData = new object[]
    {
        new object[] {0, "Electronics"},
        new object[] {1, ""}
    };
}
