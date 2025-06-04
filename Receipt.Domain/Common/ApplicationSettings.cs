namespace Receipt.Domain.Common
{
    public partial class ApplicationSettings
    {
        public string jwtKey { get; set; }  
        public string jwtIssuer { get; set; }
        public string Audience {  get; set; }
        public int DurationInMinutes { get; set; }
        public string DefaultConnection { get; set; }
    }
}
