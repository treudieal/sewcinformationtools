using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdioSoft.Business.Frames
{
    public interface IDBUnit
    {
        /// <summary>
        /// Operation Object View,Table
        /// </summary>
        Object ObjectUnit { get; set; }

        /// <summary>
        /// Find Where
        /// </summary>
        string RecordFindWhere { get; set; }

        /// <summary>
        /// Load Information
        /// </summary>
        void getData(string Where);


        /// <summary>
        /// Load Information
        /// </summary>
        void getData();

        /// <summary>
        /// load columns to List
        /// </summary>
        /// <param name="Where"></param>
        List<object> getDatas(string Where);

        /// <summary>
        /// customize columns to List
        /// </summary>
        /// <param name="Where"></param>
        List<object> getDatas(string Where, params Object[] args);

        /// <summary>
        /// is get data
        /// </summary>
        bool HasData { get; set; }



    }
}
