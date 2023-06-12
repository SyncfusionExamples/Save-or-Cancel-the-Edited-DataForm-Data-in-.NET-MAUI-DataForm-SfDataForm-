using Syncfusion.Maui.DataForm;

namespace SaveDataForm
{
    public class ItemSourceProvider : IDataFormSourceProvider
    {
        public object GetSource(string sourceName)
        {
            if (sourceName == "EventName")
            {
                List<string> country = new List<string>() { "Hackathon", "Innovation program", "Tech Spotlight" };
                return country;
            }

            return new List<string>();
        }
    }
}