namespace Tesco.Com.Services.CustomerProfile.Contracts
{
    using System;

    public class Profile
    {

        public Profile()
        {
        }
           

        

        public DateTime? JoinDate { get; set; }

        public string Type { get; set; }

        public string Title { get; set; }

        public string Forename { get; set; }

        public string MiddleInitials { get; set; }

        public string Surname { get; set; }

        public string Nickname { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public Gender? Gender { get; set; }

        public bool? Alive { get; set; }

       // public PostalAddress[] PostalAddresses { get; set; }

        public string HouseholdId { get; set; }

        public ElectronicAddress[] ElectronicAddresses { get; set; }
        
        public DateTime? LastLocationTimestamp { get; set; }

        public string[] Clubcards { get; set; }

    }

    public enum Gender
    {

        MALE,
        FEMALE,
        OTHER,
        UNKNOWN

    }
    public class ElectronicAddress
    {
        private string electronicAddressType;

        private string value;

        public ElectronicAddress()
        {
        }

        public string ElectronicAddressType { get { return this.electronicAddressType; } set { this.electronicAddressType = value; } }
        public string Value { get { return this.value; } set { this.value = value; } }


    }

}


