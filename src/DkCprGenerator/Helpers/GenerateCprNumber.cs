
namespace DkCprGenerator.Helpers
{
    public class GenerateCprNumber
    {
        public string Generate()
        {
            Random random = new Random();
            var daysOld = random.Next(20 * 365, 100 * 365);
            var bday = DateTime.Today.AddDays(-daysOld);
            var seq = random.Next(1000, 9999);
            return bday.ToString("ddMMyy") + "-" + seq.ToString();
        }
    }
}
