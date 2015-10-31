using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseModel
{
    public interface ISerializable<T> where T : new()
    {
        string Serialize();
        T Deserialize(string itemObjectSerialized);
    }
}
