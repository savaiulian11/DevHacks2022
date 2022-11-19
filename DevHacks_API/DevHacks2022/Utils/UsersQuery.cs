using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using DevHacks2022.Models;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;

namespace DevHacks2022.Utils
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersQuery : ControllerBase
    {
        public static List<User> Match(DevHacks2022Context _context, string partialNumeUtilizator)
        {
            var utilizatori = _context.Users.Where(m => m.Username.Contains(partialNumeUtilizator)).ToList();
            if (utilizatori == null)
                throw new Exception("No users found");
            return utilizatori;
        }
        public static void ChangePassword(DevHacks2022Context _context, int ID, string parola)
        {
            var utilizator = _context.Users.Where(m => m.Id == ID).FirstOrDefault();
            if (utilizator == null)
                throw new Exception("No users found");
            utilizator.Password = parola;
            Update(_context, utilizator);
        }

        public static dynamic Login(DevHacks2022Context _context, string numeUtilizator, string parola)
        {
            var utilizator = _context.Users.Where(m => (m.Username == numeUtilizator && m.Password == parola)).FirstOrDefault();
            if (utilizator == null)
                throw new Exception("Login failed! Username or password wrong!");

            var response = new Dictionary<string, string>();
            response.Add("ID", utilizator.Id.ToString());
            response.Add("Message", "Login sucesfull");

            return response;
        }
        public static int IDExistent(int? ID, DevHacks2022Context _context)
        {
            var temp = _context.Users.Find(ID);
            if (temp == null)
                return -1;
            int _ID = temp.Id;
            temp = null;
            return _ID;
        }
        public static dynamic Insert(DevHacks2022Context _context, User utilizator)
        {
            var utilizatorExistent = _context.Users.Where(m => m.Email == utilizator.Email).FirstOrDefault();
            if (utilizatorExistent != null)
                throw new Exception("Email is already used!");
            utilizatorExistent = _context.Users.Where(m => m.Username == utilizator.Username).FirstOrDefault();
            if (utilizatorExistent != null)
                throw new Exception("Username is already used!");

            _context.Users.Add(utilizator);
            _context.SaveChanges();
            var response = new Dictionary<string, string>();
            response.Add("ID", utilizator.Id.ToString());
            response.Add("Message", "Insert into Utilizator succesfull");
            return response;
        }
        public static void Update(DevHacks2022Context _context, User utilizator)
        {
            _context.Entry(utilizator).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public static void Delete(DevHacks2022Context _context, int Id)
        {
            User Utilizator = _context.Users.Find(Id);
            if (Utilizator == null)
                throw new Exception("ID Utilizator not found!");
            _context.Users.Remove(Utilizator);
            _context.SaveChanges();
        }


        private static void sendEmail(string Body, string email)
        {
            var adresa = "scientometrieatm@gmail.com";
            var parola = "faxcvdpuxvgbsypd";
            var host = "smtp.gmail.com";
            MailMessage message = new MailMessage();
            message.From = new MailAddress(adresa.ToString());
            message.To.Add(new MailAddress(email.ToString()));
            message.Subject = "Request from Admin to send a verification code.";
            message.IsBodyHtml = true;
            message.Body = Body;

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Port = 587;
            smtpClient.Host = host.ToString();
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Credentials = new NetworkCredential(adresa.ToString(), parola.ToString());
            smtpClient.Send(message);
        }
    }
}
