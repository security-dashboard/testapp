using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using System.IO.Compression;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;

namespace poc1
{
    public class SomeClass 
    {   
        public SomeClass()    
        { 
           
        }
        public string ConnectionString { get; set; } = "Server=10.0.0.101;Database=CustomerData";

        public SqlConnection ConnectToDatabase(HttpRequest request) 
        {
            string connectionString = string.Format("{0};User ID={1};Password={2}",
                ConnectionString,
                request.Form["username"],
                request.Form["password"]);

            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString; // Noncompliant
            connection.Open();
            return connection; 
        }

        public int CalculateResultInNestedLoops()
        {
            var a = 0; 
            var b = 0;
            var c = 0;   
            var d = 0;
            var e = 0; 
            var f = 0;   
            var g = 0; 
            var h = 0;    
            var result = 0;
            for(var i  = 0; i < 5; i++)
            {
                for (var j = 0; j < 5; j++)
                {
                    for (var k = 0; k < 5; k++) 
                    {
                        for (var l = 0; l < 5; l++)
                        {
                            for (var m = 0; m < 5; m++)
                            {
                                result++;
                            }
                        }
                    }
                }
            }

            return result;
        }

        private static string TargetDirectory = "/example/directory/";

        public async void ExtractEntry(IEnumerator<ZipArchiveEntry> entriesEnumerator)
        {
            ZipArchiveEntry entry = entriesEnumerator.Current;
            string destinationPath = Path.Combine(TargetDirectory, entry.FullName);

            entry.ExtractToFile(destinationPath);
        }

        public string MapUserInputToIpAddress(string input)
        {

            //check to make sure an ip address was provided
            if (!string.IsNullOrEmpty(input))
            {
                // Create an instance of IPAddress for the specified address string (in
                // dotted-quad, or colon-hexadecimal notation).
                if (IPAddress.TryParse(input, out var address))
                {
                    // Display the address in standard notation.
                    return address.ToString();
                }
            }
            return input;
        }
        
        public void SomeMethod(Stream stream)
        {
            var myBinaryFormatter = new BinaryFormatter();
            myBinaryFormatter.Deserialize(stream);
        }

        public int OverComplicatedMethod(int value)
        {
            if(value == 0)
            {
                return 0;
            }
            if (value == 1)
            {
                return 1;
            }
            if (value == 2)
            {
                return 2;
            }
            if (value == 3)
            {
                return 3;
            }
            if (value == 4)
            {
                return 4;
            }
            if (value == 5)
            {
                return 5;
            }
            if (value == 6)
            {
                return 6;
            }
            if (value == 7)
            {
                return 7;
            }
            return value;
        } 
    }
}
