using System;

namespace kursProjectV3
{
    public class SendedObject
    {
        public DBUsers SendedUser;
        public Object Data;

        public SendedObject()
        { }

        public SendedObject(DBUsers User, Object data)
        {
            SendedUser = User;
            Data = data;
        }

        public SendedObject(DBUsers User)
        {
            SendedUser = User;
        }
    }
}
