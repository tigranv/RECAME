using BisolCRM.DAL;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace BisolUITest.v1.Helpers
{
    static class XlsConverters
    {
        public static void CreateExcelDoc(List<fnRESIDENTCONTRACT> marketType, string path)
        {
            var fileName = path + @"\Export.xls";
            using (SpreadsheetDocument document = SpreadsheetDocument.Create(fileName, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new DocumentFormat.OpenXml.Spreadsheet.Workbook();

                DocumentFormat.OpenXml.Spreadsheet.Sheets sheets = workbookPart.Workbook.AppendChild(new DocumentFormat.OpenXml.Spreadsheet.Sheets());

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new DocumentFormat.OpenXml.Spreadsheet.Worksheet();
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Residents" };
                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Constructing header
                Row row = new Row();

                row.Append(
                    ConstructCell("ID", CellValues.Number),
                    ConstructCell("NAME", CellValues.String),
                     ConstructCell("FAMILY", CellValues.String),
                    ConstructCell("FATHERNAME", CellValues.String),
                    ConstructCell("BRANCH", CellValues.Number),
                    ConstructCell("STREET", CellValues.Boolean),
                    ConstructCell("CITY", CellValues.Boolean));

                // Insert the header row to the Sheet Data
                sheetData.AppendChild(row);
                sheets.Append(sheet);


                foreach (var temp in marketType)
                {
                    row = new Row();

                    row.Append(
                        ConstructCell(temp.ID.ToString(), CellValues.Number),
                        ConstructCell(temp.NAME.ToString(), CellValues.String),
                        ConstructCell(temp.FAMILY.ToString(), CellValues.String),
                        ConstructCell(temp.FATHERNAME.ToString(), CellValues.String),
                        ConstructCell(temp.BRANCH.ToString(), CellValues.Number),
                        ConstructCell(temp.STREET.ToString(), CellValues.String),
                        ConstructCell(temp.CITY.ToString(), CellValues.Boolean));
                    sheetData.AppendChild(row);
                }

                worksheetPart.Worksheet.Save();

                document.Close();
            }
        }

        private static Cell ConstructCell(string value, CellValues dataType)
        {
            return new Cell()
            {
                CellValue = new CellValue(value),
                DataType = new EnumValue<CellValues>(dataType)
            };
        }
    }
}
