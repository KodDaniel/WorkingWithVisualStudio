﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WorkingWithVisualStudio.Controllers;
using WorkingWithVisualStudio.Models;
using Xunit;

namespace WorkingWithVisualStudio.Tests
{
    public class HomeControllerTests
    {
        [Theory]
        [ClassData(typeof(ProductTestData))]
        public void IndexActionModelIsCompleted(Product[] products)
        {
            //Arrange
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(products);
            var controller = new HomeController { _repository = mock.Object };

            //Act
            var model = (controller.Index() as ViewResult)?.ViewData.Model as IEnumerable<Product>;

            // Assert 
            Assert.Equal(controller._repository.Products, model, Comparer.Get<Product>((p1, p2) =>
                p1.Name == p2.Name && p1.Price == p2.Price));
        }

        [Fact]
        public void RepositoryPropertyCalledOnce()
        {
            // Arrange
            var mock = new Mock<IRepository>();

            mock.SetupGet(m => m.Products)
                .Returns(new List<Product> { new Product { Name = "P1", Price = 100 } });

            var controller = new HomeController { _repository = mock.Object };

            //Act
            var result = controller.Index();

            //Assert
            mock.VerifyGet(m => m.Products, Times.Once);
        }
    }
}
