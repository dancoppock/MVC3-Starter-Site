using TechTalk.SpecFlow;
using Moq;
using NUnit.Framework;
using Web.Infrastructure.Authentication;

namespace Specs.Steps {
    [Binding]
    public class UserLogin_Steps {
        //Run me with NUnit TestRunner
        //Or Gallio
        //Or ReSharper
        IAuthenticationService _authService;
        public UserLogin_Steps() {
            var mock = new Mock<IAuthenticationService>();
            mock.Expect(x => x.IsValidLogin("admin", "password")).Returns(true);
            mock.Expect(x => x.IsValidLogin(It.IsAny<string>(),It.IsAny<string>())).Returns(false);
            _authService = mock.Object;
        }
        //These "tests" are pretty dumb, but convey how to use the tooling
        //you shouldn't need to test the mocking container :)
        [Given(@"a user exists with username ""(.*)"" and password ""(.*)""")]
        public void GivenAUserExistsWithUsernameAdminAndPasswordPassword(string userName, string password) {

        }
        [Then(@"that user should be able to login using ""(.*)"" and ""(.*)""")]
        public void ThenThatUserShouldBeAbleToLoginUsingAdminAndPassword(string userName, string password) {
            Assert.IsTrue(_authService.IsValidLogin(userName, password));
        }
        [Then(@"that user should not be able to login using ""(.*)"" and ""(.*)""")]
        public void ThenThatUserShouldNotBeAbleToLoginUsingAdminAndPassword(string userName, string password) {
            Assert.IsFalse(_authService.IsValidLogin(userName, password));
        }



    }
}
