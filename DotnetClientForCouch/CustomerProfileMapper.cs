using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesco.Com.Services.CustomerProfile.Contracts;

namespace DotnetClientForCouch
{
    public static class CustomerProfileMapper
    {

        public static Profile MapToJson()
        {
            var profileJsonObject = new Profile
                                        {
                                            Type="Profile",
                                            Title = "Mr",
                                            Forename = "Bharath",
                                            Nickname = "",
                                            Surname = "Dhananjaya",
                                            MiddleInitials = "D",
                                            Gender = Gender.MALE,
                                            DateOfBirth = DateTime.Now,
                                            ElectronicAddresses = new ElectronicAddress[]{new ElectronicAddress(){ElectronicAddressType="Email",Value="Bharath@gmail.com"}},
                                            Clubcards=new string[]{"23232232323232"}
                                        };
            return profileJsonObject;
        }


        public static Profile UpdateJsonRecord()
        {
            var profileJsonObject = new Profile
            {
                Type = "Profile",
                Title = "Mr",
                Forename = "Bharath",
                Nickname = "",
                Surname = "Dhananjaya",
                MiddleInitials = "D",
                Gender = Gender.MALE,
                DateOfBirth = DateTime.Now,
                ElectronicAddresses = new ElectronicAddress[] { new ElectronicAddress() { ElectronicAddressType = "Email", Value = "Bharath@tesco.com" } },
                Clubcards = new string[] { "23232232323232" }
            };
            return profileJsonObject;
        
        }





    }
}
