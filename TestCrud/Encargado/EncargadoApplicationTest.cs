using ARQUICAPAS.Application.Dtos.Encargado.Request;
using ARQUICAPAS.Application.Interfaces;
using ARQUICAPAS.Utilities.Static;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCrud.Encargado
{
    [TestClass]
    public class EncaragdoApplicationTest
    {
        private static WebApplicationFactory<Program>? _factory = null;

        private static IServiceScopeFactory? _scopeFactory = null;

        [ClassInitialize]
        public static void Initialize(TestContext _testContext)
        {
            _factory = new CustomWebApplicationFactory();
            _scopeFactory = _factory.Services.GetService<IServiceScopeFactory>();
        }

        [TestMethod]
        public async Task Registercategory_WhenSendingNullValuesOrEmpty_ValidationErrors()
        {
            using var scope = _scopeFactory!.CreateScope();
            var context = scope?.ServiceProvider.GetService<IEncargadoApplication>();

            //Arrange
            var name = "";
            var lastName = "";
            var email = "";
            var phone = "";
            var state = 1;
            var expected = ReplyMessage.MESSAGE_VALIDATE;

            //Act
            var result = await context!.RegisterEncargado(new EncargadoRequestDto()
            {
                Name = name,
                LastName = lastName,
                Email = email,
                Phone = phone,
                State = state
            });
            var current = result.Message;

            //Assert
            Assert.AreEqual(expected, current);

        }


        [TestMethod]
        public async Task Registerencargado_WhenSendingCorrectValues_RegisteredSuccessfully()
        {
            using var scope = _scopeFactory!.CreateScope();
            var context = scope?.ServiceProvider.GetService<IEncargadoApplication>();

            //Arrange
            var name = "Nuevo Registro";
            var lastName = "nuevo apellido";
            var email = "email@gmail.com";
            var phone = "986758426";
            var state = 1;
            var expected = ReplyMessage.MESSAGE_SAVE;

            //Act
            var result = await context!.RegisterEncargado(new EncargadoRequestDto()
            {
                Name = name,
                LastName = lastName,
                Email = email,
                Phone = phone,
                State = state
            });
            var current = result.Message;

            //Assert
            Assert.AreEqual(expected, current);
        }
    }
}
