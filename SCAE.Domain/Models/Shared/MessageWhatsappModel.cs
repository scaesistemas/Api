namespace SCAE.Domain.Models.Shared
{
    public class MessageWhatsappModel
    {
        public string To { get; set; }
        public string PhoneId { get; set; }
        public string TemplateName { get; set; }
        public string Language { get; set; }
        public VariablesZix Variables { get; set; }
        public bool SubmissionStatus { get; set; }
    }

    public class VariablesZix
    {
        public string Body_1 { get; set; }
        public string Body_2 { get; set; }
        public string Body_3 { get; set; }
        public string Body_4 { get; set; }
        public string Body_5 { get; set; }
        public string Body_6 { get; set; }
        public string Body_7 { get; set; }
        public string Body_8 { get; set; }
        public string Body_9 { get; set; }
        public string Body_10 { get; set; }
    }
}