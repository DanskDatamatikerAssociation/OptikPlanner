using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace OptikPlanner.Misc
{
    public class ExportToCsv
    {
        public static void ExportToCSV(ListView listView)
        {
            var logPath2 = Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData), "statistics " + DateTime.Now.ToShortDateString() + ".csv");

            DialogResult dialogResult = MessageBox.Show("Er du sikker på at du ønsker at exportere nuværende data til CSV?", "Exportér til CSV", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                using (StreamWriter sw = new StreamWriter(new FileStream(logPath2, FileMode.Create, FileAccess.Write, FileShare.ReadWrite), Encoding.UTF8))
                {
                    StringBuilder result = new StringBuilder();

                    foreach (ColumnHeader column in listView.Columns)
                    {
                        result.Append(column.Text + ",");
                    }
                    result.AppendLine();

                    foreach (ListViewItem listItem in listView.Items)
                        WriteCSVRow(result, listView.Columns.Count, i => listView.Columns[i].Width > 0, i => listItem.SubItems[i].Text);


                    sw.WriteLine(result);
                    sw.Flush();
                    sw.Close();
                }
            }
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
    }
}

