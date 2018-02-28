namespace ACM.BL
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? CustomerTypeId { get; set; }
        public string EmailAddress { get; set; }

        public override bool Equals(object obj)
        {
            // Implementing the Equals Method
            // https://msdn.microsoft.com/en-us/library/336aedhh(v=vs.100).aspx

            // Check for null values and compare run-time types.
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            var c = (Customer)obj;

            return CustomerId.Equals(c.CustomerId)
                && FirstName.Equals(c.FirstName)
                && LastName.Equals(c.LastName)
                && CustomerTypeId.Equals(c.CustomerTypeId)
                && EmailAddress.Equals(c.EmailAddress);
        }

        public override int GetHashCode()
        {
            // What is the best algorithm for an overridden System.Object.GetHashCode?
            // https://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-an-overridden-system-object-gethashcode

            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + CustomerId.GetHashCode();
                hash = hash * 23 + FirstName != null ? FirstName.GetHashCode() : 0;
                hash = hash * 23 + LastName != null ? LastName.GetHashCode() : 0;
                hash = hash * 23 + CustomerTypeId.GetValueOrDefault().GetHashCode();
                hash = hash * 23 + EmailAddress != null ? EmailAddress.GetHashCode() : 0;
                return hash;
            }
        }
    }
}
