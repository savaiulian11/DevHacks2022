namespace Scientometrie_API.Utils
{
    public class Uzual
    {
        public static int NumarParametrii(params string[] Parametrii)
        {
            int num = 0;
            foreach (var parametru in Parametrii)
            {
                if(parametru != null)
                    num++;
            }
            return num;
        }
    }
}
