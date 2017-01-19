using WebSample.Data.Entities;

namespace WebSample.Services
{
    public interface  IMemberService
    {
        int InsertOrUpdateMember(Member member);

        Member GetMemberById(int memberId);
    }
}
