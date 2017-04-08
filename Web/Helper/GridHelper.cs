﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Helper
{
    public class GridHelper
    {
        private String _columnName = null;
        public GridHelper()
        {
            Sortable = true;
            Visible = true;
        }
        public String ColumnName
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
        public String ColumnHeader { get; set; }
        public Boolean Sortable { get; set; }
        public Boolean Visible { get; set; }
    }

    public class GridModelData
    {
        public GridModelData()
        {
            ShowActionColumn = true;
        }

        public GridModelData(Tuple<IEnumerable<Web.Helper.GridHelper>, String> data, bool actionColumn = true)
        {
            ColumnDefinitions = data.Item1.ToList();
            ControllerName = data.Item2;
            ShowActionColumn = actionColumn;
        }
        public List<GridHelper> ColumnDefinitions { get; set; }
        public string ControllerName { get; set; }
        public bool ShowActionColumn { get; set; }
    }
}