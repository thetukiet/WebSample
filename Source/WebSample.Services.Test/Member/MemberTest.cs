using System;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using Rhino.Mocks;
using WebSample.Data.Query;
using WebSample.Services.QueryCommands;
using WebSample.Services.Resources;

namespace WebSample.Services.Test.Member
{
    [TestFixture]
    public class MemberTest
    {
        private ICommandExecutor _commandExecutor;
        private IMemberService _memberService;

        [SetUp]
        public void RunBeforeEachTest()
        {
            _commandExecutor = MockRepository.GenerateMock<ICommandExecutor>();
            _memberService = new MemberService(_commandExecutor);
        }

        [Test]
        public void InsertOrUpdateMember_InputNull_MustRaiseErrorMessage()
        {
            // Arrange
            Data.Entities.Member inputMember = null;

            // Act
            ActualValueDelegate<int> calling = () => _memberService.InsertOrUpdateMember(inputMember);            

            // Assert
            Assert.That(calling, Throws.TypeOf<ArgumentNullException>(), ErrorMessages.InvalidInput);
        }

        // This test case just written in case using data access mocking
        [Test]
        public void GetMemberById_InputExistingId_MustReturnMemberObject()
        {
            // Arrange
            const int memberId = 1;
            var testMember = new Data.Entities.Member
            {
                Id = memberId,
                DoB = new DateTime(1990, 1, 1),
                FirstName = "Test",
                LastName = "Guy",
                Email = "something@email.com"
            };
            var memberQueryCommand = new MemberQueryCommand(memberId);

            // Act
            _commandExecutor.Expect(x => x.Execute(Arg<MemberQueryCommand>.Is.Equal(memberQueryCommand))).Return(testMember);
            var foundMember = _memberService.GetMemberById(memberId);

            // Assert
            Assert.That(foundMember.Equals(testMember));
        }
    }
}
