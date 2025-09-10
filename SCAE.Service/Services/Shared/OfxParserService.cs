using OFXParser.Core;
using OFXParser.Entities;
using SCAE.Domain.Models.Shared;
using SCAE.Framework.Exceptions;
using SCAE.Service.Interfaces.Shared;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCAE.Service.Services.Shared;

public class OfxParserService : IOfxParserService
{

    public List<OfxParserModel> Parser(string caminho)
    {
        var settings = new ParserSettings()
        {
            CustomConverterCurrency = x => ParsePersonalizado(x)
        };



        Extract ofxParser = OFXParser.Parser.GenerateExtract(caminho, settings);

        if (ofxParser == null)
            throw new BadRequestException("Erro ao ler o arquivo OFX");


        return ofxParser
                    .Transactions
                    .Select(x => new OfxParserModel
                    {
                        Descricao = x.Description,
                        Data = x.Date,
                        Valor = (decimal)Math.Abs(x.TransactionValue),
                        TipoTransacao = x.TransactionValue < 0 ? OfxParserModel.TipoTransacaoScae.Despesa : OfxParserModel.TipoTransacaoScae.Receita,
                        Tipo = x.Type,
                        TransactionId = x.Id
                    }).ToList();
    }
    private double ParsePersonalizado(string input)
    {
        // Remove espaços e símbolos monetários, se houver
        input = input.Trim();

        // Caso especial: se o número tiver vírgula e ponto
        if (input.Contains(",") && input.Contains("."))
        {
            // Heurística comum: se a vírgula vier depois do ponto, normalmente a vírgula é separador decimal
            if (input.LastIndexOf(',') > input.LastIndexOf('.'))
            {
                input = input.Replace(".", ""); // Remove separador de milhar
                input = input.Replace(",", "."); // Usa ponto como decimal
            }
            else
            {
                input = input.Replace(",", ""); // Remove separador de milhar
                // ponto já é decimal
            }
        }
        else if (input.Contains(",")) // Só vírgula
        {
            input = input.Replace(",", "."); // Trata vírgula como decimal
        }
        // else: já está com ponto decimal, OK

        return double.Parse(input, new CultureInfo("en"));
}
    //private double 
}
