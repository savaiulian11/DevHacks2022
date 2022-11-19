using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using DevHacks2022.Models;
using System.Web.Http.Results;


namespace DevHacks2022.Utils
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicQuery 
    {
        public const int Users = 1;
        public const int Rewards_User = 2;
        public const int Company_Users = 3;
        public const int Work_Hours = 4;
        public const int Rewards = 5;
        public const int User_Activity = 6;
        public const int Activities = 7;
        public const int Activity_Types = 8;
        public const int Company = 9;

        public static dynamic Insert<T>(DevHacks2022Context _context, T obiect, int tabel)
        {
            dynamic result = new JObject();
            switch (tabel)
            {
                case Users:
                    result = UsersQuery.Insert(_context, (User)Convert.ChangeType(obiect, typeof(User)));
                    break;
                case Rewards_User:
                    result = Rewards_UserQuery.Insert(_context, (RewardsUser)Convert.ChangeType(obiect, typeof(RewardsUser)));
                    break;
                case Company_Users:
                    result = Company_UsersQuery.Insert(_context, (CompanyUser)Convert.ChangeType(obiect, typeof(CompanyUser)));
                    break;
                case Work_Hours:
                    result = Work_HoursQuery.Insert(_context, (WorkHour)Convert.ChangeType(obiect, typeof(WorkHour)));
                    break;
                case Rewards:
                    result = RewardsQuery.Insert(_context, (Reward)Convert.ChangeType(obiect, typeof(Reward)));
                    break;
                case User_Activity:
                    result = User_ActivityQuery.Insert(_context, (UserActivity)Convert.ChangeType(obiect, typeof(UserActivity)));
                    break;
                case Activities:
                    result = ActivitiesQuery.Insert(_context, (Activity)Convert.ChangeType(obiect, typeof(Activity)));
                    break;
                case Activity_Types:
                    result = Activity_TypesQuery.Insert(_context, (ActivityType)Convert.ChangeType(obiect, typeof(ActivityType)));
                    break;
                case Company:
                    result = CompanyQuery.Insert(_context, (Company)Convert.ChangeType(obiect, typeof(Company)));
                    break;

            }
            return result;
        }
        public static void Update<T>(DevHacks2022Context _context, T obiect, int tabel)
        {
            switch (tabel)
            {
                case Users:
                   UsersQuery.Update(_context, (User)Convert.ChangeType(obiect, typeof(User)));
                    break;
                case Rewards_User:
                   Rewards_UserQuery.Update(_context, (RewardsUser)Convert.ChangeType(obiect, typeof(RewardsUser)));
                    break;
                case Company_Users:
                 Company_UsersQuery.Update(_context, (CompanyUser)Convert.ChangeType(obiect, typeof(CompanyUser)));
                    break;
                case Work_Hours:
                    Work_HoursQuery.Update(_context, (WorkHour)Convert.ChangeType(obiect, typeof(WorkHour)));
                    break;
                case Rewards:
                    RewardsQuery.Update(_context, (Reward)Convert.ChangeType(obiect, typeof(Reward)));
                    break;
                case User_Activity:
                    User_ActivityQuery.Update(_context, (UserActivity)Convert.ChangeType(obiect, typeof(UserActivity)));
                    break;
                case Activities:
                  ActivitiesQuery.Update(_context, (Activity)Convert.ChangeType(obiect, typeof(Activity)));
                    break;
                case Activity_Types:
                    Activity_TypesQuery.Update(_context, (ActivityType)Convert.ChangeType(obiect, typeof(ActivityType)));
                    break;
                case Company:
                    CompanyQuery.Update(_context, (Company)Convert.ChangeType(obiect, typeof(Company)));
                    break;
            }
        }
        public static void Delete(DevHacks2022Context _context, int ID, int tabel)
        {
            switch (tabel)
            {
                case Users:
                    UsersQuery.Delete(_context, ID);
                    break;
                case Rewards_User:
                    Rewards_UserQuery.Delete(_context, ID);
                    break;
                case Company_Users:
                    Company_UsersQuery.Delete(_context, ID);
                    break;
                case Work_Hours:
                    Work_HoursQuery.Delete(_context, ID);
                    break;
                case Rewards:
                    RewardsQuery.Delete(_context, ID);
                    break;
                case User_Activity:
                    User_ActivityQuery.Delete(_context, ID);
                    break;
                case Activities:
                    ActivitiesQuery.Delete(_context, ID);
                    break;
                case Activity_Types:
                    Activity_TypesQuery.Delete(_context, ID);
                    break;
                case Company:
                   CompanyQuery.Delete(_context, ID);
                    break;
            }
        }

    }
}
