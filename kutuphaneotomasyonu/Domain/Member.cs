using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    namespace kutuphaneotomasyonu.Domain
    {
        public class Member
        {
            public int MemberId { get; set; }
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Phone { get; set; }
            public string Email { get; set; }
            public DateTime RegisterDate { get; set; }
        }
    }



