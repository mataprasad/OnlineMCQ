﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Helper
{
    public enum GridColumnType
    {
        Text,
        Date,
        Time,
        DateTime,
        Button,
        Submit
    }

    public class GridHelper
    {
        private string _columnName = null;
        public GridHelper()
        {
            Sortable = true;
            Visible = true;
            ColumnType = GridColumnType.Text;
        }
        public string ColumnName
        {
            get
            {
                return _columnName;
            }
            set
            {
                _columnName = value;
                ColumnHeader = value;
            }
        }
        public string ColumnHeader { get; set; }
        public bool Sortable { get; set; }
        public bool Visible { get; set; }
        public GridColumnType ColumnType { get; set; }
        public GridColumnTypeSubmitModel SubmitModel { get; set; }
    }

    public class GridColumnTypeSubmitModel
    {
        public string ButtonText { get; set; }
        public string PostUrl { get; set; }
        public string HiddenName { get; set; }
        public string HiddenValue { get; set; }
    }

    public class GridModelData
    {
        public GridModelData()
        {
            ShowActionColumn = true;
            MakeDateTable = true;
        }

        public GridModelData(Tuple<IEnumerable<Web.Helper.GridHelper>, String> data, bool actionColumn = true)
        {
            ColumnDefinitions = data.Item1.ToList();
            ControllerName = data.Item2;
            ShowActionColumn = actionColumn;
            MakeDateTable = true;
            SortingEnabled = true;
        }
        public List<GridHelper> ColumnDefinitions { get; set; }
        public string ControllerName { get; set; }
        public bool ShowActionColumn { get; set; }
        public bool MakeDateTable { get; set; }
        public string UrlPart { get; set; }
        public bool SortingEnabled { get; set; }
    }
}