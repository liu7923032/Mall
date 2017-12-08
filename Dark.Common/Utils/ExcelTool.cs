using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Dark.Common.Attributes;
using Dark.Common.Extension;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;


namespace Dark.Common.Utils
{
    /// <summary>
    /// 操作Excel的通用类库
    /// </summary>
    public class ExcelTool<T> where T : class
    {

        private IWorkbook workbook;
        private ICellStyle _dateStyle;

        private PropertyInfo[] properties;

        /// <summary>
        /// 
        /// </summary>
        public int MaxColumnLength { get; set; }

        public ExcelTool(string dateFormate = "yyyy-mm-dd")
        {
            workbook = new XSSFWorkbook();

            //1:设置日期样式
            _dateStyle = workbook.CreateCellStyle();
            IDataFormat format = workbook.CreateDataFormat();
            _dateStyle.DataFormat = format.GetFormat(dateFormate);
            //2:设置属性
            properties = typeof(T).GetProperties();

            //3:设置Col的默认最大长度
            MaxColumnLength = 50;
        }



        private Dictionary<string, ExcelDataAttribute> GetTitles()
        {
            Dictionary<string, ExcelDataAttribute> dictionary = new Dictionary<string, ExcelDataAttribute>();
            //List<string> titles = new List<string>();
            Type type = typeof(T);
            foreach (var item in properties)
            {
                var attributes = item.GetCustomAttributes(typeof(ExcelDataAttribute), true);
                if (attributes.Length > 0)
                {
                    dictionary[item.Name] = attributes[0] as ExcelDataAttribute;
                    dictionary[item.Name].Property = item;
                }
            }
            return dictionary;
        }

        private ISheet FillData(IReadOnlyList<T> list, string sheetName = "sheet1")
        {
            //1:构建sheet 
            ISheet sheet = workbook.CreateSheet(sheetName);
            //2:创建标题
            var titleRow = sheet.CreateRow(0);
            var dictTitles = GetTitles();
            var titles = dictTitles.GetKeys();
            for (int i = 0; i < titles.Count; i++)
            {
                CreateAndSetCell(titleRow, i, typeof(string), dictTitles[titles[i]].Name);
            }

            //3:创建body体
            var rowLen = list.Count;
            for (int i = 1; i <= rowLen; i++)
            {
                //3.1 创建行
                var row = sheet.CreateRow(i);
                //3.2 创建列
                for (int j = 0; j < titles.Count; j++)
                {
                    string title = titles[j];
                    ExcelDataAttribute excelData = dictTitles[title];
                    var property = excelData.Property;
                    CreateAndSetCell(row, j, property.PropertyType, property.GetValue(list[i - 1]));
                }
            }

            return sheet;
        }
        /// <summary>
        /// 给Cell 赋值
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="type"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        private ICell CreateAndSetCell(IRow row, int col, Type type, object entity)
        {
            //1.创建cell
            var cell = row.CreateCell(col);
            var typeName = string.Empty;
            //2.得到属性的类型
            if (type.IsCanNull())
            {
                typeName = type.GetGenericArguments()[0].FullName;
            }
            else
            {
                typeName = type.FullName;
            }
            switch (typeName)
            {
                case "System.String":
                    {
                        cell.SetCellValue(entity.ToString());
                        break;
                    }
                case "System.Int16":
                case "System.Int32":
                case "System.Double":
                case "System.Decimal":
                    if (entity == null)
                    {
                        cell.SetCellValue(0);
                    }
                    else
                    {
                        cell.SetCellValue(Convert.ToDouble(entity));
                    }
                    break;
                case "System.DateTime":
                    DateTime dateV;
                    DateTime.TryParse(entity.ToString(), out dateV);
                    cell.SetCellValue(dateV.Date);
                    cell.CellStyle = _dateStyle;
                    break;
                default:

                    break;
            }
            return cell;
        }

        /// <summary>
        /// 设置Excel列宽度
        /// </summary>
        private void AutoSizeWidth(ISheet sheet)
        {
            var arrayDicColumW = new Dictionary<int, int>();
            var ie = sheet.GetRowEnumerator();
            while (ie.MoveNext())
            {
                var row = (IRow)ie.Current;
                var rowcells = row.Cells;
                for (int i = 0; i < rowcells.Count; i++)
                {
                    int length = System.Text.Encoding.Default.GetBytes(rowcells[i].ToString()).Length;

                    if (arrayDicColumW.ContainsKey(i))
                    {
                        int temp = arrayDicColumW[i];
                        if (length > temp)
                            arrayDicColumW[i] = length;
                    }
                    else
                    {
                        arrayDicColumW[i] = length;
                    }
                }
            }

            foreach (var item in arrayDicColumW)
            {
                int num = item.Value;
                if (num > MaxColumnLength)
                {
                    num = MaxColumnLength;
                }
                sheet.SetColumnWidth(item.Key, (num + 1) * 256);
            }
        }


        /// <summary>
        /// 通过excel导出
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        public Stream GetStream(string filePath, IReadOnlyList<T> list, string sheetName = "sheet")
        {
            //1:构建body
            var sheet = FillData(list, sheetName);
            //2:整理行
            AutoSizeWidth(sheet);
            //3:检查是否有文件夹,不存在那么就创建
            if (!Directory.Exists(filePath))
            {
                Directory.CreateDirectory(filePath);
            }

            var _fName = $"{Guid.NewGuid().ToString()}.xlsx";
            var fileName = $"{filePath}.{_fName}";
            //3:创建文件
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            //4:将数据写入的文件流中
            using (FileStream memoryStream = File.Open(fileName, FileMode.OpenOrCreate))
            {
                workbook.Write(memoryStream);
                workbook.Close();
            }
            //读取文件
            return File.OpenRead(fileName);
        }

        /// <summary>
        /// 通过excel来读取数据
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public List<T> FromExcel(string file)
        {
            return new List<T>();
        }
    }


}
