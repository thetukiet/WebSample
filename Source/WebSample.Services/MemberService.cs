using System;
using WebSample.Data.Entities;
using WebSample.Data.Query;
using WebSample.Services.QueryCommands;
using WebSample.Services.Resources;

namespace WebSample.Services
{
    public class  MemberService: IMemberService
    {
        // This declaration helps us do mocking stuff in Unit-Testing
        private readonly ICommandExecutor _commandExecutor;

        public MemberService(ICommandExecutor commandExecutor)
        {
            _commandExecutor = commandExecutor;
        }

        public int InsertOrUpdateMember(Member member)
        {
            if (member == null)
            {
                throw new ArgumentNullException(ErrorMessages.InvalidInput);
            }
            /* Properly call
            const string usingStoreProcedureName = "[Sample].[MemberInsertOrUpdate]";
            return _commandExecutor.ExecuteNonQuery(usingStoreProcedureName, CommandType.StoredProcedure,
                new {
                    FirstName = member.FirstName,
                    LastName = member.LastName,
                    Email = member.Email,
                    DoB = member.DoB
                });
            */

            // Assuming this command has been done successfully.
            return 0;
        }

        public Member GetMemberById(int memberId)
        {
            return _commandExecutor.Execute(new MemberQueryCommand(memberId));
        }
    }
}
