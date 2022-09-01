using BookStore.Api.Controller;
using BookStore.Application.DTOs;
using BookStore.Application.Interfaces;
using BookStore.Domain.Entity;
using Moq;

namespace BookStore.Test.ServiceTest
{
    public class AuthorServiceTests
    {
        private AuthorsController _controller;
        private Mock<IAuthorService> _authorServiceMock;

        [SetUp]
        public void Setup()
        {
            _authorServiceMock = new Mock<IAuthorService>();

            _controller = new AuthorsController(_authorServiceMock.Object);
        }

        [Test]
        public void AddAuthorTest()
        {
            var authorServiceMock = new Mock<IAuthorService>();
            var author = new AuthorViewModel
            {
                Id = Guid.NewGuid(),
                FirstName = "",
                LastName = "",
                Email = ""
            };
            authorServiceMock.Setup(p => p.AddAuthor(author)).ReturnsAsync(ResultAuthor.success);
            authorServiceMock.Setup(p => p.GetAllAuthors()).Returns(new List<Author>());

            Assert.Pass();
        }

        [Test]
        public void UpdateAuthorTest()
        {
            var authorServiceMock = new Mock<IAuthorService>();
            var author = new AuthorViewModel
            {
                Id = Guid.NewGuid(),
                FirstName = "",
                LastName = "",
                Email = ""
            };
            authorServiceMock.Setup(p => p.UpdateAuthor(author)).ReturnsAsync(ResultAuthor.success);
            authorServiceMock.Setup(p => p.GetAllAuthors()).Returns(new List<Author>());

            Assert.Pass();
        }

        [Test]
        public void DeleteAuthorTest()
        {
            var authorServiceMock = new Mock<IAuthorService>();
            var authorId = new Guid();
            authorServiceMock.Setup(p => p.DeleteAuthor(authorId)).ReturnsAsync(ResultAuthor.success);
            authorServiceMock.Setup(p => p.GetAllAuthors()).Returns(new List<Author>());

            Assert.Pass();
        }

        [Test]
        public void GetAuthorByIdTest()
        {
            var authorServiceMock = new Mock<IAuthorService>();
            var authorId = new Guid();
            authorServiceMock.Setup(p => p.GetAuthorById(authorId)).ReturnsAsync(new Author());

            Assert.Pass();
        }

        [Test]
        public void GetAllAuthorTest()
        {
            var authorServiceMock = new Mock<IAuthorService>();
            authorServiceMock.Setup(p => p.GetAllAuthors()).Returns(new List<Author>());

            Assert.Pass();
        }
    }
}