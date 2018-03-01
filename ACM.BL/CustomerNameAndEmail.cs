using Newtonsoft.Json;
using System.Collections.Generic;

namespace ACM.BL
{
    public class CustomerNameAndEmail
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }

        public override bool Equals(object obj)
        {
            var email = obj as CustomerNameAndEmail;
            return email != null &&
                   Name == email.Name &&
                   EmailAddress == email.EmailAddress;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = 1027875531;
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(EmailAddress);
                return hashCode;
            }
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
