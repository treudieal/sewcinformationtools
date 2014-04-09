using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Tables.SEWC
{
    public class SEWC_Basic_RepairResult_Info : Columns
    {
        private static SEWC_Basic_RepairResult_Info instance;
        public static SEWC_Basic_RepairResult_Info GetInstance()
        {
            if (instance == null)
            {
                instance = new SEWC_Basic_RepairResult_Info();
            }
            return instance;
        }
        public SEWC_Basic_RepairResult_Info()
        {
            this.ID.Name = "ID";
            this.RepairResult.Name = "RepairResult";
            this.RepairResult.FieldLenght = 50;
            this.isDel.Name = "isDel";
        }
        private Column<System.Guid?> _ID = new Column<System.Guid?>();
        public Column<System.Guid?> ID
        {
            get
            {
                return _ID;
            }
            set
            {
                _ID = value;
            }
        }
        private Column<System.String> _RepairResult = new Column<System.String>();
        public Column<System.String> RepairResult
        {
            get
            {
                return _RepairResult;
            }
            set
            {
                _RepairResult = value;
            }
        }
        private Column<System.Boolean?> _isDel = new Column<System.Boolean?>();
        public Column<System.Boolean?> isDel
        {
            get
            {
                return _isDel;
            }
            set
            {
                _isDel = value;
            }
        }

    }
}
