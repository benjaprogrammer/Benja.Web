using Newtonsoft.Json;

namespace Benja.Model
{
    public class DtResult<T>
    {
        [JsonProperty("draw")]
        public int Draw { get; set; }
        [JsonProperty("recordsTotal")]
        public int RecordsTotal { get; set; }
        [JsonProperty("recordsFiltered")]
        public int RecordsFiltered { get; set; }
        [JsonProperty("data")]
        public IEnumerable<T> Data { get; set; }
        [JsonProperty("error", NullValueHandling = NullValueHandling.Ignore)]
        public string Error { get; set; }

        public string PartialView { get; set; }
    }

    public abstract class DtRow
    {
        [JsonProperty("DT_RowId")]
        public virtual string DtRowId => null;
        [JsonProperty("DT_RowClass")]
        public virtual string DtRowClass => null;
        [JsonProperty("DT_RowData")]
        public virtual object DtRowData => null;
        [JsonProperty("DT_RowAttr")]
        public virtual object DtRowAttr => null;
    }

    public class DtParameters
    {
        public int draw { get; set; }
        public DtColumn[] columns { get; set; }
        public DtOrder[] order { get; set; }
        public int start { get; set; }
        public int length { get; set; } = 5;
        public DtSearch search { get; set; }
        public string sortOrder => columns != null && order != null && order.Length > 0
            ? (columns[order[0].Column].Data +
               (order[0].Dir == DtOrderDir.Desc ? " " + order[0].Dir : string.Empty))
            : null;
        public IEnumerable<string> additionalValues { get; set; }
        public string param1 { get; set; }
        public string param2 { get; set; }
        public string param3 { get; set; }
        public string param4 { get; set; }
        public string param5 { get; set; }
        public string param6 { get; set; }
        public string param7 { get; set; }
        public string param8 { get; set; }
        public string param9 { get; set; }
        public string param10 { get; set; }
        public string param11 { get; set; }
        public string param12 { get; set; }
        public string param13 { get; set; }
        public string param14 { get; set; }
        public string param15 { get; set; }
        public string param16 { get; set; }
        public string param17 { get; set; }
        public string param18 { get; set; }
        public string param19 { get; set; }
        public string param20 { get; set; }
        public string param21 { get; set; }
        public string param22 { get; set; }
        public string param23 { get; set; }
        public string param24 { get; set; }
        public string param25 { get; set; }
        public string param26 { get; set; }
        public string param27 { get; set; }
        public string param28 { get; set; }
        public string param29 { get; set; }
        public string param30 { get; set; }
    }

    public class DtColumn
    {
        public string Data { get; set; }
        public string Name { get; set; }
        public bool Searchable { get; set; }
        public bool Orderable { get; set; }
        public DtSearch Search { get; set; }
    }
    public class DtOrder
    {
        public int Column { get; set; }
        public DtOrderDir Dir { get; set; }
    }
    public enum DtOrderDir
    {
        Asc,
        Desc
    }
    public class DtSearch
    {
        public string Value { get; set; }
        public bool Regex { get; set; }
    }
}
