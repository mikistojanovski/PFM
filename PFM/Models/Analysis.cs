namespace PFM.Models
{
    public class Analysis<T>
    {
        public string CatCode {get; set;}
        public string StartDate {get; set;}
        public string EndDate {get; set;}
        public string Direction {get;set;}
        public List<T> Items {get;set;}
    }
}