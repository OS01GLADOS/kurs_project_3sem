using System;

namespace kursProjectV3
{
    public class DBUsers
    {
        public string UsernameV { get; set; }
        public string UserPasswordV { get; set; }
        public long PhoneNumberV { get; set; }
        public string UserStatusV { get; set; }
        public DateTime RegistrarionDateV { get; set; }
        public int RankingV { get; set; }

        public DBUsers(string usernameIn, string passwordIn, long phoneNumberIn, string UserStatusIn, DateTime RedistrationDateIn, int RankingIn)
        {
            UsernameV = usernameIn;
            UserPasswordV = passwordIn;
            PhoneNumberV = phoneNumberIn;
            UserStatusV = UserStatusIn;
            RegistrarionDateV = RedistrationDateIn;
            RankingV = RankingIn;
        }

        public DBUsers(string usernameIn, string passwordIn, long phoneNumberIn)
        {
            UsernameV = usernameIn;
            UserPasswordV = passwordIn;
            PhoneNumberV = phoneNumberIn;
            UserStatusV = "User";
            RegistrarionDateV = DateTime.Now;
            RankingV = 5;
        }
    }
}
