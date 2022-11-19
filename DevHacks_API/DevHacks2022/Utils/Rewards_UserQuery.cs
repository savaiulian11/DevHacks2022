using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DevHacks2022.Models;
using Newtonsoft.Json.Linq;

namespace DevHacks2022.Utils
{
    [Route("api/[controller]")]
    [ApiController]
    public class Rewards_UserQuery : ControllerBase
    {
        public static int IDExistent(int? ID, DevHacks2022Context _context)
        {
            var temp = _context.RewardsUsers.Find(ID);
            if (temp == null)
                return -1;
            return temp.Id;
        }

        public static dynamic Insert(DevHacks2022Context _context, RewardsUser rewards)
        {
            _context.RewardsUsers.Add(rewards);
            _context.SaveChanges();
            var response = new Dictionary<string, string>();
            response.Add("ID", rewards.Id.ToString());
            response.Add("Message", "Insert into Rewards_User succesfull");
            return response;
        }

        public static void Update(DevHacks2022Context _context, RewardsUser rewarduser)
        {
            _context.Entry(rewarduser).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public static void Delete(DevHacks2022Context _context, int ID)
        {
            RewardsUser rewarduser = _context.RewardsUsers.Find(ID);
            if (rewarduser == null)
                throw new Exception("ID Rewards_Users not found!");
            _context.RewardsUsers.Remove(rewarduser);
            _context.SaveChanges();
        }
    }
}
