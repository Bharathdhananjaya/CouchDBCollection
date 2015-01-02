
namespace DotnetClientForCouch
{
    using Couchbase;
    using Newtonsoft.Json;
    using Enyim.Caching;
    using System;
    using Couchbase.Extensions;
    using Tesco.Com.Services.CustomerProfile.Contracts;


    class CouchDBClient
    {
        private static string KEY = Guid.NewGuid().ToString();
        static void Main(string[] args)
        {
            using (var couchClient = new CouchbaseClient())
            {
               /// Create Document
               bool isWriteSuccess= CreateJsonDocument(couchClient);
               if (isWriteSuccess)
               {

                   Console.WriteLine("############################################### Before Update ##################"); 
                   /// Get Document
                   var getProfileData = GetJsonDocument(couchClient);
                   Console.WriteLine("My Profile Details " +" Title = " + getProfileData.Title + " Given Name = " + getProfileData.Forename + " Familiy Name = "+ getProfileData.Surname + " Mail = " + getProfileData.ElectronicAddresses[0].Value);         

                   ///Update Document
                   bool isSuccess=UpdateDataInCouch(couchClient);

                   Console.WriteLine(" ################################################ After Update ###################");

                   var getUpdatedProfileData = GetJsonDocument(couchClient);
                   Console.WriteLine("My Profile Details " + " Title = " + getUpdatedProfileData.Title + " Given Name = " + getUpdatedProfileData.Forename + " Familiy Name = " + getUpdatedProfileData.Surname + " Mail = " + getUpdatedProfileData.ElectronicAddresses[0].Value);


                   Console.WriteLine("########Get Profile By Index#############");
                   var myView = couchClient.GetView("dev_myview", "CPSVIEW"); 

                   foreach(var view in myView)
                   {
                       Console.WriteLine("Key: {0}, Title: {1}, forename: {2}, surname: {3}", view.Info["key"], ((object[])(view.Info["value"]))[0],((object[])(view.Info["value"]))[1],((object[])(view.Info["value"]))[2]);
                   }
               }
                
                Console.Read();
            }
        }


       
        /// <summary>
        ///  Create the Document inside the Couch
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        private static bool CreateJsonDocument(CouchbaseClient client)
        {
             Profile profileObj= CustomerProfileMapper.MapToJson();
             var isSuccess = CouchbaseClientExtensions.StoreJson(client, Enyim.Caching.Memcached.StoreMode.Add, KEY, profileObj);
             return isSuccess;
        }

        /// <summary>
        /// Read the JSON document from the Couch DB.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        private static Profile GetJsonDocument(CouchbaseClient client)
        {
            var profileData = client.GetJson<Profile>(KEY);
            return profileData;
        }


              

        private static void ReadDataFromCouch(CouchbaseClient client)
        {
            var readObject = client.Get(KEY);
            Console.WriteLine(readObject); 
        }



        private static bool UpdateDataInCouch(CouchbaseClient client)
        {
            var jsonDoc = CustomerProfileMapper.UpdateJsonRecord();
            var isSuccess = client.StoreJson(Enyim.Caching.Memcached.StoreMode.Set, KEY, jsonDoc); 
            return isSuccess;
        }


        private static Object DeleteDataFromCouch(CouchbaseClient client)
        {
            var readObject = client.Remove(KEY); 
            return readObject;
        }
               

    }
}
