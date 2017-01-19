using System.Data;
using System.Data.SqlClient;
using WebSample.Data.Entities;
using WebSample.Data.Query;

namespace WebSample.Services.QueryCommands
{    
    // TODO: Should use dynamic object parsing like Dapper
    // Then this class is redundant
    public class MemberQueryCommand : ICommand<Member>
    {
        public int MemberId { set; get; }

        public MemberQueryCommand(int memberId)
        {
            MemberId = memberId;
        }

        public Member Execute(SqlConnection connection)
        {
            Member result = null;
            ExecuteStrategy.ExecuteDataReader(connection, CommandType.StoredProcedure, "[Sample].[MemberGetInformation]",
                dataReader =>
                {
                    while (dataReader.Read())
                    {
                        result = LoadMember(dataReader);
                        break;
                    }
                },
                DbParameterFactory.CreateParameter("MemberId", MemberId)
            );

            return result;
        }
        
        private Member LoadMember(IDataReader reader)
        {
            return new Member
            {
                Id = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2),
                Email = reader.GetString(3),
                DoB = reader.GetDateTime(4)
            };
        }


        public override bool Equals(object obj)
        {
            var comparingCommand = obj as MemberQueryCommand;

            if (comparingCommand == null)
            {
                return false;
            }

            return MemberId.Equals(comparingCommand.MemberId);
        }
    }
}
