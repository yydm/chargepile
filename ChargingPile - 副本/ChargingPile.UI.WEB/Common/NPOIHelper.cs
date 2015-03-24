using System;
using System.Data;
using System.IO;
using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;

namespace ChargingPile.UI.WEB.Common
{
    public class NpoiHelper
    {
        private string[] titles;
        private DataTable data;
        public NpoiHelper(string[] titles, DataTable data)
        {
            this.titles = titles;
            this.data = data;
        }

        public Stream ToExcel()
        {
            int rowIndex = 0;
            //创建workbook
            HSSFWorkbook workbook = new HSSFWorkbook();
            MemoryStream ms = new MemoryStream();
            ISheet sheet = workbook.CreateSheet("sheet1");
            IRow row = sheet.CreateRow(rowIndex);
            row.Height = 200 * 3;

            //表头样式
            ICellStyle style = workbook.CreateCellStyle();
            style.Alignment = HorizontalAlignment.LEFT;//居中对齐
            //表头单元格背景色
            style.FillForegroundColor = HSSFColor.LIGHT_GREEN.index;
            style.FillPattern = FillPatternType.SOLID_FOREGROUND;
            //表头单元格边框
            style.BorderTop = CellBorderType.THIN;
            style.TopBorderColor = HSSFColor.BLACK.index;
            style.BorderRight = CellBorderType.THIN;
            style.RightBorderColor = HSSFColor.BLACK.index;
            style.BorderBottom = CellBorderType.THIN;
            style.BottomBorderColor = HSSFColor.BLACK.index;
            style.BorderLeft = CellBorderType.THIN;
            style.LeftBorderColor = HSSFColor.BLACK.index;
            style.VerticalAlignment = VerticalAlignment.CENTER;
            //表头字体设置
            IFont font = workbook.CreateFont();
            font.FontHeightInPoints = 12;//字号
            font.Boldweight = 600;//加粗
            //font.Color = HSSFColor.WHITE.index;//颜色
            style.SetFont(font);

            //数据样式
            ICellStyle datastyle = workbook.CreateCellStyle();
            datastyle.Alignment = HorizontalAlignment.LEFT;//左对齐
            //数据单元格的边框
            datastyle.BorderTop = CellBorderType.THIN;
            datastyle.TopBorderColor = HSSFColor.BLACK.index;
            datastyle.BorderRight = CellBorderType.THIN;
            datastyle.RightBorderColor = HSSFColor.BLACK.index;
            datastyle.BorderBottom = CellBorderType.THIN;
            datastyle.BottomBorderColor = HSSFColor.BLACK.index;
            datastyle.BorderLeft = CellBorderType.THIN;
            datastyle.LeftBorderColor = HSSFColor.BLACK.index;
            //数据的字体
            IFont datafont = workbook.CreateFont();
            datafont.FontHeightInPoints = 11;//字号
            datastyle.SetFont(datafont);
            //设置列宽
            sheet.SetColumnWidth(0, 20 * 256);

            sheet.DisplayGridlines = false;

            try
            {
                //表头数据
                for (int i = 0; i < titles.Length; i++)
                {
                    ICell cell = row.CreateCell(i);
                    cell.SetCellValue(titles[i]);
                    cell.CellStyle = style;
                }
                for (int k = 0; k < data.Rows.Count; k++)
                {
                    row = sheet.CreateRow(k + 1);
                    row.Height = 200 * 2;
                    for (int j = 0; j < data.Columns.Count; j++)
                    {
                        ICell cell = row.CreateCell(j);
                        cell.SetCellValue(data.Rows[k][j].ToString());
                        cell.CellStyle = datastyle;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                workbook.Write(ms);
                ms.Flush();
                ms.Position = 0;
                workbook = null;
                sheet = null;
                row = null;
            }
            return ms;
        }
    }
}