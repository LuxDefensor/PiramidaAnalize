using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace PiramidaAnalize
{
    class XLSImport
    {
        private Excel.Application xls;
        private Excel.Workbook wb;
        private Excel.Worksheet ws;
        private Excel.Range firstCell;

        public XLSImport(string fName)
        {
            if (!File.Exists(fName))
                throw new FileNotFoundException("Файл не найден", fName);
            xls = new Excel.Application();
            try
            {
                wb = xls.Workbooks.Open(fName);
            }
            catch(Exception ex)
            {
                throw new Exception("Невозможно открыть файл " + fName, ex);
            }
            ws = (Excel.Worksheet)wb.Worksheets[1];
            firstCell = (Excel.Range)ws.Cells[1, 1];
        }

        public object[] GetColumn(int columnIndex,int rowCount)
        {
            object[] result = new object[rowCount];
            Excel.Range currentCell;
            string value;
            for (int i = 1; i <= rowCount; i++)
            {
                currentCell = (Excel.Range)ws.Cells[i, columnIndex];
                value = currentCell.Value.ToString();
                result[i] = (value == "") ? null : currentCell.Value;
            }
            return result;
        }

        #region Private methods

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception e)
            {
                obj = null;
                System.Windows.Forms.MessageBox.Show("Ошибка при освобождении ресурса Excel " + e.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        #endregion
    }
}
