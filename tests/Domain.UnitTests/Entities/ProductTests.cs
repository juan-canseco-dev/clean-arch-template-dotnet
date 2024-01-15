namespace CleanArchTemplate.Domain.UnitTests.Entities;

public class ProductTests
{

    static int SupplierId = 1;
    static int CategoryId = 2;
    static int UnitId = 3;
    static string ProductName = "New Product";
    static decimal PurchasePrice = 9.99m;
    static decimal GreaterPurchasePrice = 29.99m;
    static decimal SalePrice = 19.99m;


    [Test]
    public void CreateProductWhenPropertiesArePresentShouldCreateSuccessfully()
    {
        var product = new Product(
            supplierId: SupplierId,
            categoryId: CategoryId,
            unitId: UnitId,
            name: ProductName,
            purchasePrice: PurchasePrice,
            salePrice: SalePrice
        );

        product.Name.Should().Be(ProductName);
        product.SupplierId.Should().Be(SupplierId);
        product.CategoryId.Should().Be(CategoryId);
        product.UnitId.Should().Be(UnitId);
        product.PurchasePrice.Should().Be(PurchasePrice);
        product.SalePrice.Should().Be(SalePrice);
        product.Stock.Should().NotBeNull();
    }

    [Test]
    public void CreateProductWhenPropertiesAreInvalidShouldThrowException([ValueSource(nameof(ProductsData))] object[] productData)
    {
        Action createProduct = () =>
        {
            var product = new Product(
                supplierId: (int)productData[0],
                categoryId: (int)productData[1],
                unitId: (int)productData[2],
                name: (string)productData[3],
                purchasePrice: (decimal)productData[4],
                salePrice: (decimal)productData[5]
            );
        };
        createProduct.Should().Throw<ArgumentException>();
    }

    [Test]
    public void UpdateProductWhenPropertiesArePresentShouldUpdateSuccessfully()
    {
        var updatedSupplierId = 2;
        var updatedCategoryId = 3;
        var updatedUnitId = 4;
        var updatedProductName = "Updated Product Name";
        var updatedPurchasePrice = 5.99m;
        var updatedSalePrice = 15.99m;

        var product = new Product(
           supplierId: SupplierId,
           categoryId: CategoryId,
           unitId: UnitId,
           name: ProductName,
           purchasePrice: PurchasePrice,
           salePrice: SalePrice
       );

        product.Update(
            supplierId: updatedSupplierId,
            categoryId: updatedCategoryId,
            unitId: updatedUnitId,
            name: updatedProductName,
            purchasePrice: updatedPurchasePrice,
            salePrice: updatedSalePrice
        );

        product.Name.Should().Be(updatedProductName);
        product.SupplierId.Should().Be(updatedSupplierId);
        product.CategoryId.Should().Be(updatedCategoryId);
        product.UnitId.Should().Be(updatedUnitId);
        product.PurchasePrice.Should().Be(updatedPurchasePrice);
        product.SalePrice.Should().Be(updatedSalePrice);
    }


    [Test]
    public void UpdateProductWhenPropertiesAreNotPresentShouldThrowException([ValueSource(nameof(ProductsData))] object[] productData)
    {
        Action updateProduct = () =>
        {
            var product = new Product(
                supplierId: SupplierId,
                categoryId: CategoryId,
                unitId: UnitId,
                name: ProductName,
                purchasePrice: PurchasePrice,
                salePrice: SalePrice
            );

            var updatedSupplierId = (int)productData[0];
            var updatedCategoryId = (int)productData[1];
            var updatedUnitId = (int)productData[2];
            var updatedProductName = (string)productData[3];
            var updatedPurchasePrice = (decimal)productData[4];
            var updatedSalePrice = (decimal)productData[5];


            product.Update(
                supplierId: updatedSupplierId,
                categoryId: updatedCategoryId,
                unitId: updatedUnitId,
                name: updatedProductName,
                purchasePrice: updatedPurchasePrice,
                salePrice: updatedSalePrice
            );

        };
        updateProduct.Should().Throw<ArgumentException>();
    }

    static object[] ProductsData = 
    {
        new object[] {0, CategoryId, UnitId, ProductName, PurchasePrice, SalePrice },
        new object[] { SupplierId, 0, UnitId, ProductName, PurchasePrice, SalePrice },
        new object[] { SupplierId, CategoryId, 0 , ProductName, PurchasePrice, SalePrice },
        new object[] { SupplierId, CategoryId, UnitId, "", PurchasePrice, SalePrice },
        new object[] { SupplierId, CategoryId, UnitId, ProductName, 0.0m, SalePrice },
        new object[] { SupplierId, CategoryId, UnitId, ProductName, PurchasePrice, 0.0m },
        new object[] { SupplierId, CategoryId, UnitId, ProductName, GreaterPurchasePrice, SalePrice}
    };
}
