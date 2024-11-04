namespace Microsoft.eShopWeb.Web.Controllers;
using Azure.Communication.Messages;

public class EnvioWhatsapp
{
    public static async Task Main(string[] args)
    {
        Console.WriteLine("Azure Communication Services - Send WhatsApps Messages");

        // Retrieve connection string from environment variable
        string connectionString =
            Environment.GetEnvironmentVariable("COMMUNICATION_SERVICES_CONNECTION_STRING");

        // Instantiate the client
        var notificationMessagesClient = new NotificationMessagesClient(connectionString);
    }
}
