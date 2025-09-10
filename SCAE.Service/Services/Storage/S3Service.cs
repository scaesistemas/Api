using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.Runtime;
using System;
using System.IO;
using System.Threading.Tasks;
using SCAE.Domain.Models.Shared;
using Microsoft.Extensions.Options;
using SCAE.Service.Interfaces.S3Service;

namespace SCAE.Service.Services.Storage
{
  public class S3Service : IS3Service
  {
    private readonly IAmazonS3 _s3Client;
    private readonly IOptions<BucketAwsModel> _bucketAws;

    public S3Service(IOptions<BucketAwsModel> bucketAws)
    {
      _bucketAws = bucketAws;
       

      var config = new AmazonS3Config
      {
          RegionEndpoint = RegionEndpoint.USEast1,
          ForcePathStyle = false,
          UseHttp = false
      };

      if (_bucketAws?.Value?.AccesskeyID == null || string.IsNullOrWhiteSpace(_bucketAws.Value.AccesskeyID))
      {
          throw new Exception("AccessKeyID não configurada");
      }

      var credentials = new BasicAWSCredentials(_bucketAws.Value.AccesskeyID, _bucketAws.Value.SecretAccessKey);
      _s3Client = new AmazonS3Client(credentials, config);
    }

    public async Task<string> UploadAsync(Stream fileStream, string keyName, string contentType)
    {

      var request = new PutObjectRequest
      {
        BucketName = _bucketAws.Value.PublicBucketName,
        Key = keyName,
        InputStream = fileStream,
        ContentType = contentType,
      };

      try
      {        
        var response = await _s3Client.PutObjectAsync(request);

        if (response.HttpStatusCode != System.Net.HttpStatusCode.OK)
        {
          throw new Exception($"Falha ao fazer upload no S3. Status: {response.HttpStatusCode}");
        }

        return $"{_bucketAws.Value.CloudFront}{keyName}";
      }
      catch (AmazonS3Exception ex)
      {
        Console.WriteLine($"Erro AmazonS3: {ex.Message}");
        throw;
      }
      catch (Exception ex)
      {
        Console.WriteLine($"Erro inesperado: {ex.Message}");
        throw;
      }

    }

    public async Task DeleteAsync(string keyName)
    {
      var request = new DeleteObjectRequest
      {
        BucketName = _bucketAws.Value.PublicBucketName,
        Key = keyName
      };

      await _s3Client.DeleteObjectAsync(request);
    }
  }
}
