using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using kutuphaneotomasyonu.Domain;

using kutuphaneotomasyonu.DAL;

namespace kutuphaneotomasyonu.Service
{
    public class MemberService
    {
        MemberDAL memberDAL = new MemberDAL();

        public void AddMember(Member member)
        {
            if (string.IsNullOrWhiteSpace(member.Name))
                throw new Exception("Üye adı boş olamaz");

            if (string.IsNullOrWhiteSpace(member.Surname))
                throw new Exception("Üye soyadı boş olamaz");

            member.RegisterDate = DateTime.Now;

            memberDAL.Add(member);
        }

        public void DeleteMember(int memberId)
        {
            memberDAL.Delete(memberId);
        }

        public List<Member> GetAllMembers()
        {
            return memberDAL.GetAll();
        }
    }
}