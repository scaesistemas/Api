using OfficeOpenXml;
using OfficeOpenXml.Attributes;
using SCAE.Framework.Exceptions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using static OfficeOpenXml.ExcelErrorValue;

namespace SCAE.Framework.Helper
{
    public class ExcelHelper
    {
        public static List<T> GetList<T>(ExcelWorksheet sheet, Dictionary<string, string> mapeamento, int cabecalho, int conteudo, int? ultimoConteudo = null)
        {
            List<T> list = new List<T>();    ///range(1,12)
            var columns = Enumerable.Range(1, mapeamento.Count).ToList().Select(x =>
                new { Index = x, ColumnName = sheet.Cells[cabecalho, x].Value.ToString() }
            );

            int rowCount = 0;
            string propertyName = "";

            try
            {
                for (int row = conteudo; row <= sheet.Dimension.Rows; row++)
                {
                    rowCount = row;

                    if (ultimoConteudo.HasValue && row > ultimoConteudo)
                        break;

                    T obj = (T)Activator.CreateInstance(typeof(T));
                    foreach (var property in typeof(T).GetProperties())
                    {
                        propertyName = property.Name;

                        var coluna = "";
                        mapeamento.TryGetValue(property.Name, out coluna);

                        if (string.IsNullOrEmpty(coluna))
                            continue;

                        int colIndex = columns.SingleOrDefault(x => x.ColumnName == coluna).Index;

                        var value = sheet.Cells[row, colIndex].Value;

                        if (value is string && (string)value == "")
                        {
                            continue;
                        }

                        if (value == null)
                        {
                            continue;
                        }

                        var propertyType = property.PropertyType;

                        //Evitar erro com variáveis numéricas nullable no modelo
                        if (propertyType != typeof(string))
                        {
                            if (propertyType == typeof(int?))
                                propertyType = typeof(int);
                            else if (propertyType == typeof(decimal?))
                                propertyType = typeof(decimal);
                            else if (propertyType == typeof(DateTime?)) 
                                propertyType = typeof(DateTime);
                            else if(propertyType == typeof(double?))
                                propertyType = typeof(double);
                        }

                        property.SetValue(obj, Convert.ChangeType(value, propertyType, new CultureInfo("pt-BR")));
                    }

                    list.Add(obj);

                }
            }
            catch (Exception ex) 
            {
                throw new BadRequestException($"Algum erro ocorreu! Erro detectado ao chegar na linha {rowCount} na propriedade '{propertyName}'<br>{ex.Message}<br>");
            }
            return list;
        }

        /// <summary>
        /// Sem problema com colunas de mesmo nome
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sheet"></param>
        /// <param name="mapeamento"></param>
        /// <param name="cabecalho"></param>
        /// <param name="conteudo"></param>
        /// <returns></returns>
        public static List<T> GetList<T>(ExcelWorksheet sheet, List<string> listaPropriedades, int cabecalho, int conteudo)
        {
            List<T> list = new List<T>();    ///range(1,12)
            var columns = Enumerable.Range(1, listaPropriedades.Count).ToList().Select(x =>
                new { Index = x, ColumnName = sheet.Cells[cabecalho, x].Value.ToString() }
            );

            var mapeamento = new Dictionary<string, string>();

            var auxColumns = columns.ToList();

            for (int i = 0; i < listaPropriedades.Count; i++) 
            {
                mapeamento.Add(listaPropriedades[i], auxColumns[i].ColumnName);
            }

            var sameNameList = new List<ColumnHolder>();

            int rowCount = 0;

            try
            {

                for (int row = conteudo; row <= sheet.Dimension.Rows; row++)
                {

                    rowCount = row;
                    T obj = (T)Activator.CreateInstance(typeof(T));
                    foreach (var property in typeof(T).GetProperties())
                    {

                        var coluna = "";
                        mapeamento.TryGetValue(property.Name, out coluna);

                        if (string.IsNullOrEmpty(coluna))
                            continue;

                        int colIndex;
                        var colIndexes = columns.Where(x => x.ColumnName == coluna).Select(x => x.Index).ToList();
                        if (colIndexes.Count > 1)
                        {
                            ColumnHolder holder = null;
                            foreach (var nameHolder in sameNameList)
                            {
                                if (nameHolder.Name == coluna)
                                {
                                    holder = nameHolder;
                                    break;
                                }
                            }
                            if (holder == null)
                            {
                                holder = new ColumnHolder() { Name = coluna, Indexes = colIndexes };
                                sameNameList.Add(holder);
                            }
                            colIndex = holder.Indexes[0];
                            holder.Indexes.RemoveAt(0);
                        }
                        else
                        {
                            colIndex = colIndexes[0];
                        }


                        var value = sheet.Cells[row, colIndex].Value;



                        if (value is string && (string)value == "")
                        {
                            continue;
                        }

                        if (value == null)
                        {
                            continue;
                        }

                        var propertyType = property.PropertyType;
                        var valueTest = value.ToString();

                        if (valueTest.Substring(valueTest.Length - 1).Equals("%"))
                        {
                            valueTest = valueTest.Substring(0, valueTest.Length - 1);
                            property.SetValue(obj, Convert.ChangeType(valueTest, propertyType));
                        }
                        else
                        {
                            property.SetValue(obj, Convert.ChangeType(value, propertyType));
                        }

                    }

                    list.Add(obj);
                    sameNameList.Clear();
                }
            }
            catch (Exception ex)
            {
                throw new BadRequestException($"Algum erro ocorreu! Erro detectado ao chegar na linha {rowCount}<br>{ex.Message}<br>");
            }
            return list;
        }

        private class ColumnHolder
        {
            public string Name;
            public List<int> Indexes;
        }

    }
}
