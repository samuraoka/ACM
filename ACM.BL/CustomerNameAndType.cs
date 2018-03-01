using Newtonsoft.Json;
using System.Collections.Generic;

namespace ACM.BL
{
    public class CustomerNameAndType
    {
        public string Name { get; set; }
        public string CustomerTypeName { get; set; }

        public override bool Equals(object obj)
        {
            var type = obj as CustomerNameAndType;
            return type != null &&
                   Name == type.Name &&
                   CustomerTypeName == type.CustomerTypeName;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 543736288;
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(CustomerTypeName);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
