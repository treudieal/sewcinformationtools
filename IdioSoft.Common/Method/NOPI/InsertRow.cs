using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Common.Method.NOPI
{
   public static class InsertRow
    {
       public static void subExcel_InsertRow(NPOI.SS.UserModel.ISheet sheet, int intRowCounts, int intMaxRowCounts, NPOI.SS.UserModel.IRow sRow)
       {
           #region "批量移动行"
           sheet.ShiftRows(intRowCounts, sheet.LastRowNum, intMaxRowCounts, true, true);
           #endregion

           #region "对批量移动后空出的空行插，创建相应的行，并以intRowCounts的上一行为格式源(即：intRowCounts-1的那一行)"
           for (int i = intRowCounts; i < intRowCounts + intMaxRowCounts - 1; i++)
           {
               NPOI.SS.UserModel.IRow targetRow = null;
               NPOI.SS.UserModel.ICell sourceCell = null;
               NPOI.SS.UserModel.ICell targetCell = null;

               targetRow = sheet.CreateRow(i + 1);

               for (int m = sRow.FirstCellNum; m < sRow.LastCellNum; m++)
               {
                   sourceCell = sRow.GetCell(m);
                   if (sourceCell == null)
                       continue;
                   targetCell = targetRow.CreateCell(m);


                   targetCell.CellStyle = sourceCell.CellStyle;
                   targetCell.SetCellType(sourceCell.CellType);

               }
               //CopyRow(sourceRow, targetRow);

               //Util.CopyRow(sheet, sourceRow, targetRow);
           }

           NPOI.SS.UserModel.IRow firstTargetRow = sheet.GetRow(intRowCounts);
           NPOI.SS.UserModel.ICell firstSourceCell = null;
           NPOI.SS.UserModel.ICell firstTargetCell = null;

           for (int m = sRow.FirstCellNum; m < sRow.LastCellNum; m++)
           {
               firstSourceCell = sRow.GetCell(m);
               if (firstSourceCell == null)
                   continue;
               firstTargetCell = firstTargetRow.CreateCell(m);

               firstTargetCell.CellStyle = firstSourceCell.CellStyle;

               firstTargetCell.SetCellType(firstSourceCell.CellType);
           }
           #endregion
       }
    }
}
