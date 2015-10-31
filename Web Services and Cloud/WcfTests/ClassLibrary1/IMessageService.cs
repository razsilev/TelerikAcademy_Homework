using ClassLibrary1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    [ServiceContract]
    public interface IMessageService
    {
        [OperationContract]
        IEnumerable<Message> GetMessage();

        [OperationContract]
        void AddMessage(Message message);
    }
}
