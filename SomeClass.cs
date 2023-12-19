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
    }
}
