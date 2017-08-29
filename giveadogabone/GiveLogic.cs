using System.Text;
using System;
using giveadogabone;
using System.Collections.Generic;

namespace Core
{
    
        public class GiveLogic
        {
            static List<User> users = new List<User>();
            public bool Login(string user, string pass)
            {
                for(int i =0; i<users.Count; i++)
            {
                if (user == users[i].name)
                {
                    if (pass == users[i].pass)
                        return true;
                }
            }
            return false;
            }
            public void PopulateUsers()
            {
                for (int i = 0; i < 10; i++)
                {
                    User user = new User();
                    user.userId = i;
                    user.name = i.ToString();
                    user.pass = i.ToString();
                    user.bones = 0;
                    users.Add(user);


                }
            }
            public User findUser(string name)
            {
            
            User temp = users.Find(x=>x.name.Contains(name));
            
            return temp;
            }
            public void givebone()
            {
            int member;
            Random r = new Random();
            member = r.Next(0, 9);
            users[member].bones = 1;
            }

        }
    

}