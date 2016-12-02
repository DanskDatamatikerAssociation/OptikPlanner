using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OptikPlanner.Misc
{
    public class ExportToCsv
    {
        public static void ExportToCSV(ListView listView)
        {
            string logPath2 = @"C:\Users\Danny\Desktop\statistics 02-12-2016.csv";

            using (StreamWriter sw = new StreamWriter(new FileStream(logPath2, FileMode.Create, FileAccess.ReadWrite), Encoding.UTF8))
            {
                StringBuilder result = new StringBuilder();

                foreach (ColumnHeader column in listView.Columns)
                {
                    result.Append(column.Text + ",");
                }
                result.AppendLine();
                


                result.AppendLine();

                

                sw.WriteLine(result);
                sw.Flush();
                sw.Close();
            }

                //DialogResult dialogResult = MessageBox.Show("Er du sikker på at du ønsker at exportere nuværende data til CSV?", "Exportér til CSV", MessageBoxButtons.YesNo);
                //if (dialogResult == DialogResult.Yes)
                //{

                //}
                //else if (dialogResult == DialogResult.No)
                //{
                //}
        }

        public static void ExportToCSV(ListView listView, string filePath, bool includeHidden)
        {
            //using (StreamWriter sw = new StreamWriter(new FileStream(filePath, FileMode.Create, FileAccess.ReadWrite), Encoding.UTF8))
            //{
            //    StringBuilder result = new StringBuilder();
            //    result.AppendLine()
            //}
            ////make header string
            //WriteCSVRow(result, listView.Columns.Count, i => includeHidden || listView.Columns[i].Width > 0,
            //    i => listView.Columns[i].Text);

            ////export data rows
            //foreach (ListViewItem listItem in listView.Items)
            //    WriteCSVRow(result, listView.Columns.Count, i => includeHidden || listView.Columns[i].Width > 0,
            //        i => ((ListViewItem)listItem).SubItems[i].Text);

            //File.WriteAllText(filePath, result.ToString());
        }

        private static void WriteCSVRow(StringBuilder result, int itemsCount, Func<int, bool> isColumnNeeded,
            Func<int, string> columnValue)
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
    }
}

