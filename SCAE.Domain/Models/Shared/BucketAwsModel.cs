namespace SCAE.Domain.Models.Shared
{
    public class BucketAwsModel
    {
        public string PrivateBucketName { get; set; }

        public string PublicBucketName { get; set; }

        public string CloudFront { get; set; }

        public string AccesskeyID{ get; set; }
        
        public string SecretAccessKey { get; set; }
    }
}