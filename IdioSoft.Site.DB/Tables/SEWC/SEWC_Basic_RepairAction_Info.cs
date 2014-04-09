using IdioSoft.Business.Frames;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Site.DB.Tables.SEWC
{
    public class SEWC_Basic_RepairAction_Info : Columns
    {
        private static SEWC_Basic_RepairAction_Info instance;
        public static SEWC_Basic_RepairAction_Info GetInstance()
        {
            if (instance == null)
            {
                instance = new SEWC_Basic_RepairAction_Info();
            }
            return instance;
        }
        public SEWC_Basic_RepairAction_Info()
        {
            this.ID.Name = "ID";
            this.RepairAction.Name = "RepairAction";
            this.RepairAction.FieldLenght = 50;
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
        private Column<System.String> _RepairAction = new Column<System.String>();
        public Column<System.String> RepairAction
        {
            get
            {
                return _RepairAction;
            }
            set
            {
                _RepairAction = value;
            }
        }

    }
}
