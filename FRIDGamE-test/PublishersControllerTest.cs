using FRIDGamE.Controllers;
using FRIDGamE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Policy;
using Xunit.Sdk;
using Publisher = FRIDGamE.Models.Publisher;

namespace FRIDGamE_test
{
    public class PublishersControllerTest
    {
        private PublishersApiController controller;
        private IPublisherService service;

        public PublishersControllerTest()
        {
            service = new PublisherServiceTest();
            controller = new PublishersApiController(service);
        }

        [Fact]
        public void Get()
        {
            IEnumerable<Publisher> publishers = controller.GetPublishers().ToList();
            Assert.IsType<List<Publisher>>(publishers);
            Assert.Equal(publishers.Count(), 4);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(4)]
        public void GetById(int id)
        {
            var task = controller.GetPublisher(id);
            Publisher publisher = Assert.IsType<Publisher>(task.Value);
            Assert.Equal(publisher.Id, service.FindById(id).Id);
        }

        [Theory]
        [InlineData(7)]
        [InlineData(-14)]
        public void GetById2(int id)
        {
            var task = controller.GetPublisher(id);
            Assert.IsType<NotFoundResult>(task.Result);
        }

        [Fact]
        public void Post()
        {
            int count = service.FindAll().ToList().Count();
            Publisher publisher = new Publisher() { Id = 5, PublisherName = "Ubisoft", NIP = "2590358583" };
            var task = controller.PostPublisher(publisher);
            Assert.IsType<CreatedResult>(task.Result);
            count -= service.FindAll().ToList().Count();
            Assert.Equal(count, -1);
        }

        [Theory]
        [InlineData(3)]
        public void Put(int id)
        {
            var publisher = new Publisher() { Id = 3, PublisherName = "Take-Two Interactive", NIP = "2095394933" };
            var task = controller.PutPublisher(publisher);
            Assert.IsType<OkObjectResult>(task.Result);
            Assert.Equal(publisher.NIP, service.FindById(id).NIP);
        }

        [Theory]
        [InlineData(30)]
        public void Put2(int id)
        {
            var publisher = new Publisher() { Id = 30, PublisherName = "Take-Two Interactive", NIP = "2095394934" };
            var task = controller.PutPublisher(publisher);
            Assert.IsType<NotFoundResult>(task.Result);
        }

        [Theory]
        [InlineData(4)]
        public void Delete(int id)
        {
            int count = service.FindAll().ToList().Count();
            var task = controller.DeletePublisher(id);
            Assert.IsType<NoContentResult>(task.Result);
            count -= service.FindAll().ToList().Count();
            Assert.Equal(count, 1);
        }
    }
}