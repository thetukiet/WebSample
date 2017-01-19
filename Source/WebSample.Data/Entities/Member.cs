using System;

namespace WebSample.Data.Entities
{
    public class Member
    {
        public int Id { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public DateTime DoB  { set; get; }

        public override bool Equals(object obj)
        {
            var comparingMember = obj as Member;

            if (comparingMember == null)
            {
                return false;
            }

            var check1 = Id.Equals(comparingMember.Id);
            var check2 = FirstName.Equals(comparingMember.FirstName);
            var check3 = LastName.Equals(comparingMember.LastName);
            var check4 = Email.Equals(comparingMember.Email);
            var check5 = DoB.Date.Equals(comparingMember.DoB.Date);

            return check1 && check2 && check3 && check4 && check5;
        }
    }
}
