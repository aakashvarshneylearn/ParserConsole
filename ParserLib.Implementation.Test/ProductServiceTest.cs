using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using ParserLib.Implementation.DataProvider;
using ParserLib.Implementation.DataProvider.Implementation;
using ParserLib.Implementation.Services;
using ParserLib.Model;

namespace ParserLib.Implementation.Test
{
    public class ProductServiceTest
    {
        IProductProvider _ProductProvider;
        IProductService _ProductService;

        [SetUp]
        public void Setup()
        {
            _ProductProvider = new ProductProvider();
            _ProductService = new ProductService(_ProductProvider);
        }

        [Test]
        public void ConstructorTest()
        {
            Assert.Throws<ArgumentNullException>(() => new ProductService(null));
        }

        [Test]
        public void AddRangeTest()
        {
            var products = new List<Product>();
            products.Add(new Product() { Title="Test1",Twitter="Twitter"});
            _ProductService.AddRange(products);
            var response= _ProductService.GetAll();
            Assert.AreEqual(products.Count, response.Count);
        }
    }
}