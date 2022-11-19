using DevHacks2022.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DevHacks2022.Utils
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardsQuery : ControllerBase
    {
        public static int IDExistent(int? ID, DevHacks2022Context _context)
        {
            var temp = _context.Rewards.Find(ID);
            if (temp == null)
                return -1;
            return temp.Id;
        }

        public static dynamic Insert(DevHacks2022Context _context, Reward reward)
        {
            _context.Rewards.Add(reward);
            _context.SaveChanges();
            var response = new Dictionary<string, string>();
            response.Add("ID", reward.Id.ToString());
            response.Add("Message", "Insert into Rewards succesfull");
            return response;
        }

        public static void Update(DevHacks2022Context _context, Reward reward)
        {
            _context.Entry(reward).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public static void Delete(DevHacks2022Context _context, int ID)
        {
            Reward reward = _context.Rewards.Find(ID);
            if (reward == null)
                throw new Exception("ID Reward not found!");
            _context.Rewards.Remove(reward);
            _context.SaveChanges();
        }
    }
}
