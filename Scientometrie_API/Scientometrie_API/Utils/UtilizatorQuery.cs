using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using Scientometrie_API.Models;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;

namespace Scientometrie_API.Utils
{
    public class UtilizatorQuery
    { 
        public static List<Utilizator> Match(ScientometrieDbContext _context, string partialNumeUtilizator)
        {
            var utilizatori = _context.Utilizator.Where(m => m.NumeUtilizator.Contains(partialNumeUtilizator)).ToList();
            if (utilizatori == null)
                throw new Exception("No users found");
            return utilizatori;
        }
        public static void ChangePassword(ScientometrieDbContext _context, int ID, string parola)
        {
            var utilizator = _context.Utilizator.Where(m => m.ID == ID).FirstOrDefault();
            if (utilizator == null)
                throw new Exception("No users found");
            utilizator.Parola = parola;
            Update(_context, utilizator);
        }
        public static void VerifyCode(ScientometrieDbContext _context,int ID ,string code)
        {
            var utilizator = _context.Utilizator.Where(m => m.ID == ID).FirstOrDefault();
            if (utilizator == null)
                throw new Exception("Verify recover code failed! Internal error!");
            if(code != utilizator.Cod)
                throw new Exception("Verify recover code failed! Wrong code!");
        }
        public static dynamic GenerateCode(ScientometrieDbContext _context, string Email)
        {
            var utilizator = _context.Utilizator.Where(m => m.Email == Email).FirstOrDefault();
            if (utilizator == null)
                throw new Exception("Generate recover code failed! Email not found!");
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var stringChars = new char[6];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            utilizator.Cod = finalString;

            string Body = "<table><tr><td>User's Code</td><td>#UserCode#</td></tr></table>";
            Body = Body.Replace("#UserCode#", finalString);
            sendEmail(Body, Email);
            BasicQuery.Update(_context, utilizator, BasicQuery.UTILIZATOR);

            var response = new Dictionary<string, string>();
            response.Add("ID", utilizator.ID.ToString());
            response.Add("Message", "Genereate code sucesfull! Verify your email.");

            return response;
        }
        public static dynamic Login(ScientometrieDbContext _context, string numeUtilizator, string parola)
        {
            var utilizator = _context.Utilizator.Where(m => (m.NumeUtilizator == numeUtilizator && m.Parola == parola)).FirstOrDefault();
            if (utilizator == null)
                throw new Exception("Login failed! Username or password wrong!");

            var response = new Dictionary<string, string>();
            response.Add("ID", utilizator.ID.ToString());
            response.Add("Message", "Login sucesfull");

            return response;
        }
        public static int IDExistent(int? ID, ScientometrieDbContext _context)
        {
            var temp = _context.Utilizator.Find(ID);
            if (temp == null)
                return -1;
            int _ID = temp.ID;
            temp = null;
            return _ID;
        }
        public static dynamic Insert(ScientometrieDbContext _context, Utilizator utilizator)
        {
            var utilizatorExistent = _context.Utilizator.Where(m => m.Email == utilizator.Email).FirstOrDefault();
            if (utilizatorExistent != null)
                throw new Exception("Email is already used!");
            utilizatorExistent = _context.Utilizator.Where(m => m.NumeUtilizator == utilizator.NumeUtilizator).FirstOrDefault();
            if (utilizatorExistent != null)
                throw new Exception("Username is already used!");

            utilizator.Drepturi = 1;
            utilizator.Cod = "000000";

            _context.Utilizator.Add(utilizator);
            _context.SaveChanges();
            var response = new Dictionary<string, string>();
            response.Add("ID", utilizator.ID.ToString());
            response.Add("Message", "Insert into Utilizator succesfull");
            return response;
        }
        public static void Update(ScientometrieDbContext _context, Utilizator utilizator)
        {
            _context.Entry(utilizator).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public static void Delete(ScientometrieDbContext _context, int ID)
        {
            Utilizator Utilizator = _context.Utilizator.Find(ID);
            if (Utilizator == null)
                throw new Exception("ID Utilizator not found!");
            _context.Utilizator.Remove(Utilizator);
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
