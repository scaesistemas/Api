namespace SCAE.Framework.Domain
{
    public class UrlQueryPagination
    {
        /// <summary>Número da página a ser listada</summary>
        public int? Page { get; set; }
        /// <summary>Tamanho de registros que a página terá. (O padrão é 25)</summary>
        public int PageSize { get; set; }
        /// <summary>Nome do campo que será ordenado</summary>
        public string SortBy { get; set; }
        /// <summary>Responsável por definir se a ordenação será decrescente</summary>
        public bool SortDesc { get; set; }

        public UrlQueryPagination()
        {
            PageSize = 25;
            SortDesc = false;
        }
    }
}
