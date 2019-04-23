using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Email
{
    class Program
        //Variables 
    {public static string t, s, m = " ";
        static void Main(string[] args)
        { //Console Dimensions
            Console.WindowHeight = 10;
            Console.WindowWidth = 30;
            //Console user input 
            Console.WriteLine("Enter email");
            t = Console.ReadLine();
            Console.WriteLine("Enter Subject ");
            s= Console.ReadLine();
            Console.WriteLine("Enter Message");
            m= Console.ReadLine();
            Console.WriteLine("Enter any key To exit ");
            Console.ReadKey();
            //Send Email
            Execute().Wait();
        }
        //Sending email method
        static async Task Execute()
        { 
            
           
            var apiKey = Environment.GetEnvironmentVariable("ApiKey");//Start/System/Systeminfo/Advancesettings/Environmentvariables
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@example.com", "Example User");
            var subject =s;
            var to = new EmailAddress(t, "Example User");
            var plainTextContent = m;
            var htmlContent = m;
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);
        }
    }
}
