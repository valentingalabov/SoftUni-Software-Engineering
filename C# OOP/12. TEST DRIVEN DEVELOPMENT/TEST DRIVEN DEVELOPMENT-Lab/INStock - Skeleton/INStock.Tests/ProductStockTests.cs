namespace INStock.Tests
{
    using INStock.Contracts;
    using NUnit.Framework;
    using System.Linq;
    using System;
    [TestFixture]
    public class ProductStockTests
    {

        private IProductStock productStock;

        [SetUp]
        public void CreateTestObject()
        {
            productStock = new ProductStock();
            productStock.Add(new Product()
            {
                Label = "MyProduct",
                Quantity = 1,
                Price = 100m
            });
        }


        [Test]
        public void DuplicateLabelAfterAddingNewProduct()
        {
            int countBeforeAdd = productStock.Count;
            productStock.Add(new Product()
            {
                Label = "MyProduct",
                Price = 100m
            });

            Assert.That(productStock.Count == countBeforeAdd);
        }

        [Test]
        public void ProductQuantityIncreasedByQuantityAdded()
        {
            int quantityBefore = productStock
                .FirstOrDefault()
                .Quantity;

            productStock.Add(new Product()
            {
                Label = "MyProduct",
                Quantity = 5,
                Price = 100m
            });

            Assert.That(productStock.FirstOrDefault().Quantity == 6);
        }

        [Test]
        public void PricePreservedAfterNewProductAdded()
        {
            var product = new Product()
            {
                Label = "MyProduct",
                Price = 5.9m
            };

            Assert.That(() => productStock.Add(product),
                Throws.ArgumentException);

        }

        [Test]
        public void TrueIfContainsProduct()
        {
            var product = new Product()
            {
                Label = "MyProduct",
                Quantity = 5,
                Price = 100m
            };

            Assert.That(productStock.Contains(product));
        }

        [Test]
        public void FalseIfContainsProduct()
        {
            var product = new Product()
            {
                Label = "MyProduct1",
                Quantity = 5,
                Price = 100m
            };

            Assert.That(!productStock.Contains(product));
        }

        [Test]
        public void FindsNthProductInsStock()
        {
            var product = new Product()
            {
                Label = "Product",
                Quantity = 5,
                Price = 100m
            };

            productStock.Add(product);

            var findedProduct = productStock.Find(2);

            Assert.That(findedProduct.Label, Is.EqualTo(product.Label));
        }

        [Test]
        public void ErrorIfProductIndexIsNotValid()
        {
            Assert.Throws<IndexOutOfRangeException>(() => productStock.Find(8));
        }

        [Test]
        public void ProductFoundByLabel()
        {
            var product = productStock.FindByLabel("MyProduct");

            Assert.AreEqual(product, productStock.First());
        }

        [Test]
        public void ErrorIfLabelNotFound()
        {
            Assert.Throws<ArgumentException>(() => productStock.FindByLabel("alabala"));
        }


        [Test]
        public void EmptyListIfNotFound()
        {
            var products = productStock.FindAllInPriceRange(1.0m, 2.0m);

            Assert.That(products.Count() == 0);
        }

        

        [TearDown]
        public void DestroyObjects()
        {

            productStock = null;
        }
    }
}
