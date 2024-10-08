﻿
namespace Benja.Service
{
    public interface IExportService<TModel> where TModel : class
    {
        Task<byte[]> ExportToExcel(List<TModel> registers);

        byte[] ExportToCsv(List<TModel> registers);

        byte[] ExportToHtml(List<TModel> registers);

        byte[] ExportToJson(List<TModel> registers);

        byte[] ExportToXml(List<TModel> registers);

        byte[] ExportToYaml(List<TModel> registers);
    }
}
