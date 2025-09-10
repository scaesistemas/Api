namespace SCAE.Domain.Models.Shared
{
    public class BaseSettingModel
    {
        public string Host { get; set; }
        public int Port { get; set; }
        public bool Pooling { get; set; }
        public string PrefixDatabase { get; set; }
        public string Database { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
    }
}
