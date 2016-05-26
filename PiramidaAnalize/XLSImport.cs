using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace PiramidaAnalize
{
    class XLSImport : IDisposable
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
            catch (Exception ex)
            {
                throw new Exception("Невозможно открыть файл " + fName, ex);
            }
            ws = (Excel.Worksheet)wb.Worksheets[1];
            firstCell = (Excel.Range)ws.Cells[1, 1];
        }

        public object[] GetColumn(int columnIndex, int rowCount)
        {
            object[] result = new object[rowCount];
            Excel.Range currentCell;
            string value;
            for (int i = 1; i <= rowCount; i++)
            {
                currentCell = (Excel.Range)ws.Cells[i, columnIndex];
                if (currentCell.Value == null)
                    value = "";
                else
                    value = currentCell.Value.ToString();
                result[i - 1] = (value == "") ? null : currentCell.Value;
            }
            return result;
        }

        public static string GetColumnHeader(int columnIndex)
        {
            string result = "";
            string letters = "ABCDEFGHIGKLMNOPQRSTUVWXYZ";
            int len = letters.Length;
            int remainder = columnIndex;
            int currentIndex = 0;
            if (remainder <= len)
                result = letters[remainder - 1].ToString();
            else
            {
                do
                {
                    currentIndex = remainder % len;
                    if (currentIndex == 0)
                    {
                        currentIndex = len;
                        remainder--;
                    }
                    result = letters[currentIndex - 1] + result;
                    remainder = remainder / len;
                } while (remainder > 0);
            }
            return result;
        }

        public void Close()
        {
            wb.Close(Excel.XlSaveAction.xlDoNotSaveChanges);
            xls.Quit();
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

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.
                releaseObject(firstCell);
                releaseObject(ws);
                releaseObject(wb);
                releaseObject(xls);
                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        ~XLSImport()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(false);
        }

        // This code added to correctly implement the disposable pattern.
        void IDisposable.Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            GC.SuppressFinalize(this);
        }
        #endregion

        #endregion
    }
}
