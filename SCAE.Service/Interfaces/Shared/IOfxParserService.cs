using SCAE.Domain.Models.Shared;
using System.Collections.Generic;

namespace SCAE.Service.Interfaces.Shared;

public interface IOfxParserService 
{
    List<OfxParserModel> Parser(string caminho);
}
