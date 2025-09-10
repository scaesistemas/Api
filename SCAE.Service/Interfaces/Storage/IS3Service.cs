
using System.IO;

using System.Threading.Tasks;

namespace SCAE.Service.Interfaces.S3Service
{
  public interface IS3Service
  {
    Task<string> UploadAsync(Stream fileStream, string keyName, string contentType);

  }
}