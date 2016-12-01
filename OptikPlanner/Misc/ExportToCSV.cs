using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptikPlanner.Misc
{
    static class ExportToCSV
    {
        public static void ExportToCsv(ListView listView, string filePath, bool includeHidden)
        {
            //make header string
            StringBuilder result = new StringBuilder();
            WriteCSVRow(result, listView.Columns.Count, i => includeHidden || listView.Columns[i].Width > 0, i => listView.Columns[i].Text);

            //export data rows
            foreach (ListViewItem listItem in listView.Items)
                WriteCSVRow(result, listView.Columns.Count, i => includeHidden || listView.Columns[i].Width > 0, i => listItem.SubItems[i].Text);

            File.WriteAllText(filePath, result.ToString());
        }

        private static void WriteCSVRow(StringBuilder result, int itemsCount, Func<int, bool> isColumnNeeded, Func<int, string> columnValue)
        {
            bool isFirstTime = true;
            for (int i = 0; i < itemsCount; i++)
            {
                if (!isColumnNeeded(i))
                    continue;

                if (!isFirstTime)
                    result.Append(",");
                isFirstTime = false;

                result.Append(String.Format("\"{0}\"", columnValue(i)));
            }
            result.AppendLine();
        }

    //    private const string ListSeparator = ";";

    //    public IList<T> Objects;

    //    public CsvExport(IList<T> objects)
    //    {
    //        Objects = objects;
    //    }

    //    public string Export()
    //    {
    //        return Export(true);
    //    }

    //    public string Export(bool includeHeaderLine)
    //    {

    //        var sb = new StringBuilder();

    //        //Get properties using reflection.
    //        var propertyInfos = typeof(T).GetTypeInfo();

    //        if (includeHeaderLine)
    //        {
    //            //add header line.
    //            foreach (var propertyInfo in propertyInfos.DeclaredProperties)
    //            {
    //                sb.Append(propertyInfo.Name).Append(ListSeparator);
    //            }
    //            sb.Remove(sb.Length - 1, 1).AppendLine();
    //        }

    //        //add value for each property.
    //        foreach (T obj in Objects)
    //        {
    //            foreach (var propertyInfo in propertyInfos.DeclaredProperties)
    //            {
    //                sb.Append(MakeValueCsvFriendly(propertyInfo.GetValue(obj, null))).Append(ListSeparator);
    //            }

    //            sb.Remove(sb.Length - 1, 1).AppendLine();
    //        }

    //        return sb.ToString();
    //    }

    //    //export to a file.
    //    public async void ExportToFile(string filename)
    //    {
    //        try
    //        {
    //            var folderPicker = new FolderPicker();
    //            folderPicker.CommitButtonText = "Chose this folder";
    //            folderPicker.FileTypeFilter.Add(".UnknownExt");
    //            folderPicker.SettingsIdentifier = "Folderpicker";
    //            folderPicker.ViewMode = PickerViewMode.List;
    //            folderPicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;


    //            var storageFolder = await folderPicker.PickSingleFolderAsync();
    //            if (storageFolder == null) return;
    //            var file = await storageFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
    //            await FileIO.WriteTextAsync(file, Export());


    //        }
    //        catch (Exception ex)
    //        {
    //            var msg = new MessageDialog(ex.Message);
    //            msg.ShowAsync();
    //        }


    //    }

    //    //export as binary data.
    //    public byte[] ExportToBytes()
    //    {
    //        return Encoding.UTF8.GetBytes(Export());
    //    }

    //    //get the csv value for field.
    //    private string MakeValueCsvFriendly(object value)
    //    {
    //        if (value == null) return "";

    //        if (value is DateTime)
    //        {
    //            if (((DateTime)value).TimeOfDay.TotalSeconds == 0)
    //                return ((DateTime)value).ToString("yyyy-MM-dd");
    //            return ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss");
    //        }
    //        string output = value.ToString();

    //        if (output.Contains(",") || output.Contains("\""))
    //            output = '"' + output.Replace("\"", "\"\"") + '"';

    //        return output;

    //    }
    //}
}
}
