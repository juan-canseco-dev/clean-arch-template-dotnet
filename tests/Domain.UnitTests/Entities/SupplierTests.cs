namespace CleanArchTemplate.Domain.UnitTests.Entities;

public class SupplierTests
{
    static int SupplierId = 1;
    static string SupplierName = "ABC Corp";
    static string SupplierPhone = "555-1234-3";
    static ContactPerson ContactPerson = new ContactPerson(fullname: "John Doe", phone: "555-1234-2");
    static Address Address = new Address(country: "Mexico", state: "Sonora", city: "Hermosillo", zipCode: "83200", street: "Center");

    [Test]
    public void CreateSupplierWhenAllPropertiesArePresentShouldCreateSuccessfully()
    {
        var supplier = new Supplier(
            id: SupplierId, 
            name: SupplierName, 
            phone: SupplierPhone, 
            address: Address, 
            contactPerson: ContactPerson
        );

        supplier.Id.Should().Be(SupplierId);
        supplier.Name.Should().Be(SupplierName);
        supplier.Phone.Should().Be(SupplierPhone);
        supplier.Address.Should().Be(Address);
        supplier.ContactPerson.Should().Be(ContactPerson);
    }


    [Test]
    public void CreateSupplierWhenPropertiesAreNotPresentShouldThrowException([ValueSource(nameof(CreateSuppliersData))] object[] supplierData)
    {
        Action createSupplier = () =>
        {
            int id = (int)supplierData[0];
            string name = (string)supplierData[1];
            string phone = (string)supplierData[2];
            Address address = (Address)supplierData[3];
            ContactPerson contactPerson = (ContactPerson)supplierData[4];

            var supplier = new Supplier(
                id: id, 
                name: name, 
                phone: phone, 
                address: address, 
                contactPerson: contactPerson
            );
        };

        createSupplier.Should().Throw<ArgumentException>();
    }

    [Test]
    public void UpdateSupplierWhenPropertiesArePresentShouldUpdateSuccessfully()
    {

        var updatedName = "ABC Corporation";
        var updatedPhone = "555-1234-9";
        var updatedAddress = new Address(
            country: "United States",
            state: "California",
            city: "San Francisco",
            zipCode: "94105",
            street: "123 Main St"
        );
        var updatedContactPerson = new ContactPerson(
            fullname: "Jane Smith",
            phone: "555-1234-7"
        );

        var supplier = new Supplier(
            id: SupplierId,
            name: SupplierName,
            phone: SupplierPhone,
            address: Address,
            contactPerson: ContactPerson
        );

        supplier.Update(
            name: updatedName, 
            phone: updatedPhone, 
            address: updatedAddress, 
            contactPerson: updatedContactPerson
        );

        supplier.Name.Should().Be(updatedName);
        supplier.Phone.Should().Be(updatedPhone);
        supplier.Address.Should().Be(updatedAddress);
        supplier.ContactPerson.Should().Be(updatedContactPerson);
    }

    [Test]
    public void UpdateSupplierWhenPropertiesAreNotPresentShouldThrowException([ValueSource(nameof(UpdateSuppliersData))] object[] supplierData)
    {
        Action updateSupplier = () =>
        {
            var supplier = new Supplier(
                id: SupplierId,
                name: SupplierName,
                phone: SupplierPhone,
                address: Address,
                contactPerson: ContactPerson
            );

            string name = (string)supplierData[1];
            string phone = (string)supplierData[2];
            Address address = (Address)supplierData[3];
            ContactPerson contactPerson = (ContactPerson)supplierData[4];

            supplier.Update(name, phone, address, contactPerson);
        };
        updateSupplier.Should().Throw<ArgumentException>();
    }


    static object[] CreateSuppliersData =
    {
        new object[] {0, SupplierName, SupplierPhone, Address, ContactPerson},
        new object[] {SupplierId, "", SupplierPhone, Address, ContactPerson},
        new object[] {SupplierId, SupplierName, "", Address, ContactPerson},
        new object[] {SupplierId, SupplierName, SupplierPhone, null, ContactPerson},
        new object[] {SupplierId, SupplierName, SupplierPhone, Address, null},
    };

    static object[] UpdateSuppliersData =
    {
        new object[] {SupplierId, "", SupplierPhone, Address, ContactPerson},
        new object[] {SupplierId, SupplierName, "", Address, ContactPerson},
        new object[] {SupplierId, SupplierName, SupplierPhone, null, ContactPerson},
        new object[] {SupplierId, SupplierName, SupplierPhone, Address, null},
    };
}
