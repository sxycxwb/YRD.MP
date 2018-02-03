namespace YRD.SO.helpers
{
    public class Requestsafe
    {
        public static string Get(string input)
        {
            var output = input;
            if (input == null || input.Trim() == "") return output;
            output = output.Replace("<", "");
            output = output.Replace("(", "");
            output = output.Replace(")", "");
            output = output.Replace("《", "");
            output = output.Replace(">", "");
            output = output.Replace("》", "");
            output = output.Replace("\\", "");
            output = output.Replace("'", "");
            output = output.Replace("’", "");
            output = output.Replace(",", "");
            output = output.Replace("，", "");
            output = output.Trim();

            return output;
        }
    }
}