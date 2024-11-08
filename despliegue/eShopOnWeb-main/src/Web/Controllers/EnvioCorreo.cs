namespace Microsoft.eShopWeb.Web.Controllers;
using Azure;
using Azure.Communication.Email;

public class EnvioCorreo
{
    public static async Task Main(string[] args)
    {
        string connectionString = "endpoint=https:////commmservice.europe.communication.azure.com/;" +
            "accesskey=FAR0dORAhE3Kcywk0pkF8Uys9H97b9UsJnyWqyC5zw4nBCMEmGP5JQQJ99AKACULyCplepTYAAAAAZCS8CAC";


        var emailClient = new EmailClient(connectionString);


        var emailMessage = new EmailMessage(
            senderAddress: "DoNotReply@61332e89-1303-4407-b9ec-7f8ae4217fb0.azurecomm.net",
            content: new EmailContent("Prueba :)")
            {
                PlainText = "Hola mundo por correo electrónico.",
                Html = @"
		<html>
			<body>
				<h1>Hola mundo por correo electrónico.</h1>
			</body>
		</html>"
            },
            recipients: new EmailRecipients(new List<EmailAddress> { new EmailAddress("enderwigim@gmail.com") }));


        EmailSendOperation emailSendOperation = emailClient.Send(
            WaitUntil.Completed,
            emailMessage);

    }
}
