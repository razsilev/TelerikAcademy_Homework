using ClassLibrary1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class MessageService : IMessageService
    {
        public IEnumerable<Message> GetMessage()
        {
            return new Message[] 
                        {
                            new Message()
                                {
                                    PostDate = DateTime.Now,
                                    Text = "Ala bala nica",
                                    User = new User() {Name = "Pesho"}
                                }
                        };
        }

        public void AddMessage(Message message)
        {
            
        }
    }
}
