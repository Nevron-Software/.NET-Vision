namespace Nevron.Examples.Chart.WebForm {
    using System;
    using System.Data;
    using System.Xml;
    using System.Runtime.Serialization;
    
    [Serializable()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Diagnostics.DebuggerStepThrough()]
    [System.ComponentModel.ToolboxItem(true)]
    public class dsTable : DataSet {
        
        private MyTableDataTable tableMyTable;
        
        public dsTable() {
            this.InitClass();
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        protected dsTable(SerializationInfo info, StreamingContext context) {
            string strSchema = ((string)(info.GetValue("XmlSchema", typeof(string))));
            if ((strSchema != null)) {
                DataSet ds = new DataSet();
                ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
                if ((ds.Tables["MyTable"] != null)) {
                    this.Tables.Add(new MyTableDataTable(ds.Tables["MyTable"]));
                }
                this.DataSetName = ds.DataSetName;
                this.Prefix = ds.Prefix;
                this.Namespace = ds.Namespace;
                this.Locale = ds.Locale;
                this.CaseSensitive = ds.CaseSensitive;
                this.EnforceConstraints = ds.EnforceConstraints;
                this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
                this.InitVars();
            }
            else {
                this.InitClass();
            }
            this.GetSerializationData(info, context);
            System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
            this.Tables.CollectionChanged += schemaChangedHandler;
            this.Relations.CollectionChanged += schemaChangedHandler;
        }
        
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]
        public MyTableDataTable MyTable {
            get {
                return this.tableMyTable;
            }
        }
        
        public override DataSet Clone() {
            dsTable cln = ((dsTable)(base.Clone()));
            cln.InitVars();
            return cln;
        }
        
        protected override bool ShouldSerializeTables() {
            return false;
        }
        
        protected override bool ShouldSerializeRelations() {
            return false;
        }
        
        protected override void ReadXmlSerializable(XmlReader reader) {
            this.Reset();
            DataSet ds = new DataSet();
            ds.ReadXml(reader);
            if ((ds.Tables["MyTable"] != null)) {
                this.Tables.Add(new MyTableDataTable(ds.Tables["MyTable"]));
            }
            this.DataSetName = ds.DataSetName;
            this.Prefix = ds.Prefix;
            this.Namespace = ds.Namespace;
            this.Locale = ds.Locale;
            this.CaseSensitive = ds.CaseSensitive;
            this.EnforceConstraints = ds.EnforceConstraints;
            this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
            this.InitVars();
        }
        
        protected override System.Xml.Schema.XmlSchema GetSchemaSerializable() {
            System.IO.MemoryStream stream = new System.IO.MemoryStream();
            this.WriteXmlSchema(new XmlTextWriter(stream, null));
            stream.Position = 0;
            return System.Xml.Schema.XmlSchema.Read(new XmlTextReader(stream), null);
        }
        
        internal void InitVars() {
            this.tableMyTable = ((MyTableDataTable)(this.Tables["MyTable"]));
            if ((this.tableMyTable != null)) {
                this.tableMyTable.InitVars();
            }
        }
        
        private void InitClass() {
            this.DataSetName = "dsTable";
            this.Prefix = "";
            this.Namespace = "http://www.tempuri.org/dsTable.xsd";
            this.Locale = new System.Globalization.CultureInfo("bg-BG");
            this.CaseSensitive = false;
            this.EnforceConstraints = true;
            this.tableMyTable = new MyTableDataTable();
            this.Tables.Add(this.tableMyTable);
        }
        
        private bool ShouldSerializeMyTable() {
            return false;
        }
        
        private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e) {
            if ((e.Action == System.ComponentModel.CollectionChangeAction.Remove)) {
                this.InitVars();
            }
        }
        
        public delegate void MyTableRowChangeEventHandler(object sender, MyTableRowChangeEvent e);
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class MyTableDataTable : DataTable, System.Collections.IEnumerable {
            
            public DataColumn columnid;
            public DataColumn columncolors;
            public DataColumn columnvalues;
            
            internal MyTableDataTable() : 
                    base("MyTable") {
                this.InitClass();
            }
            
            internal MyTableDataTable(DataTable table) : 
                    base(table.TableName) {
                if ((table.CaseSensitive != table.DataSet.CaseSensitive)) {
                    this.CaseSensitive = table.CaseSensitive;
                }
                if ((table.Locale.ToString() != table.DataSet.Locale.ToString())) {
                    this.Locale = table.Locale;
                }
                if ((table.Namespace != table.DataSet.Namespace)) {
                    this.Namespace = table.Namespace;
                }
                this.Prefix = table.Prefix;
                this.MinimumCapacity = table.MinimumCapacity;
                this.DisplayExpression = table.DisplayExpression;
            }
            
            [System.ComponentModel.Browsable(false)]
            public int Count {
                get {
                    return this.Rows.Count;
                }
            }
            
            internal DataColumn idColumn {
                get {
                    return this.columnid;
                }
            }
            
            internal DataColumn colorsColumn {
                get {
                    return this.columncolors;
                }
            }
            
            internal DataColumn valuesColumn {
                get {
                    return this.columnvalues;
                }
            }
            
            public MyTableRow this[int index] {
                get {
                    return ((MyTableRow)(this.Rows[index]));
                }
            }
            
            public event MyTableRowChangeEventHandler MyTableRowChanged;
            
            public event MyTableRowChangeEventHandler MyTableRowChanging;
            
            public event MyTableRowChangeEventHandler MyTableRowDeleted;
            
            public event MyTableRowChangeEventHandler MyTableRowDeleting;
            
            public void AddMyTableRow(MyTableRow row) {
                this.Rows.Add(row);
            }
            
            public MyTableRow AddMyTableRow(string colors, int values) {
                MyTableRow rowMyTableRow = ((MyTableRow)(this.NewRow()));
                rowMyTableRow.ItemArray = new object[] {
                        null,
                        colors,
                        values};
                this.Rows.Add(rowMyTableRow);
                return rowMyTableRow;
            }
            
            public MyTableRow FindByid(int id) {
                return ((MyTableRow)(this.Rows.Find(new object[] {
                            id})));
            }
            
            public System.Collections.IEnumerator GetEnumerator() {
                return this.Rows.GetEnumerator();
            }
            
            public override DataTable Clone() {
                MyTableDataTable cln = ((MyTableDataTable)(base.Clone()));
                cln.InitVars();
                return cln;
            }
            
            protected override DataTable CreateInstance() {
                return new MyTableDataTable();
            }
            
            internal void InitVars() {
                this.columnid = this.Columns["id"];
                this.columncolors = this.Columns["colors"];
                this.columnvalues = this.Columns["values"];
            }
            
            private void InitClass() {
                this.columnid = new DataColumn("id", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnid);
                this.columncolors = new DataColumn("colors", typeof(string), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columncolors);
                this.columnvalues = new DataColumn("values", typeof(int), null, System.Data.MappingType.Element);
                this.Columns.Add(this.columnvalues);
                this.Constraints.Add(new UniqueConstraint("Constraint1", new DataColumn[] {
                                this.columnid}, true));
                this.columnid.AutoIncrement = true;
                this.columnid.AllowDBNull = false;
                this.columnid.Unique = true;
            }
            
            public MyTableRow NewMyTableRow() {
                return ((MyTableRow)(this.NewRow()));
            }
            
            protected override DataRow NewRowFromBuilder(DataRowBuilder builder) {
                return new MyTableRow(builder);
            }
            
            protected override System.Type GetRowType() {
                return typeof(MyTableRow);
            }
            
            protected override void OnRowChanged(DataRowChangeEventArgs e) {
                base.OnRowChanged(e);
                if ((this.MyTableRowChanged != null)) {
                    this.MyTableRowChanged(this, new MyTableRowChangeEvent(((MyTableRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowChanging(DataRowChangeEventArgs e) {
                base.OnRowChanging(e);
                if ((this.MyTableRowChanging != null)) {
                    this.MyTableRowChanging(this, new MyTableRowChangeEvent(((MyTableRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleted(DataRowChangeEventArgs e) {
                base.OnRowDeleted(e);
                if ((this.MyTableRowDeleted != null)) {
                    this.MyTableRowDeleted(this, new MyTableRowChangeEvent(((MyTableRow)(e.Row)), e.Action));
                }
            }
            
            protected override void OnRowDeleting(DataRowChangeEventArgs e) {
                base.OnRowDeleting(e);
                if ((this.MyTableRowDeleting != null)) {
                    this.MyTableRowDeleting(this, new MyTableRowChangeEvent(((MyTableRow)(e.Row)), e.Action));
                }
            }
            
            public void RemoveMyTableRow(MyTableRow row) {
                this.Rows.Remove(row);
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class MyTableRow : DataRow {
            
            private MyTableDataTable tableMyTable;
            
            internal MyTableRow(DataRowBuilder rb) : 
                    base(rb) {
                this.tableMyTable = ((MyTableDataTable)(this.Table));
            }
            
            public int id {
                get {
                    return ((int)(this[this.tableMyTable.idColumn]));
                }
                set {
                    this[this.tableMyTable.idColumn] = value;
                }
            }
            
            public string colors {
                get {
                    try {
                        return ((string)(this[this.tableMyTable.colorsColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableMyTable.colorsColumn] = value;
                }
            }
            
            public int values {
                get {
                    try {
                        return ((int)(this[this.tableMyTable.valuesColumn]));
                    }
                    catch (InvalidCastException e) {
                        throw new StrongTypingException("Cannot get value because it is DBNull.", e);
                    }
                }
                set {
                    this[this.tableMyTable.valuesColumn] = value;
                }
            }
            
            public bool IscolorsNull() {
                return this.IsNull(this.tableMyTable.colorsColumn);
            }
            
            public void SetcolorsNull() {
                this[this.tableMyTable.colorsColumn] = System.Convert.DBNull;
            }
            
            public bool IsvaluesNull() {
                return this.IsNull(this.tableMyTable.valuesColumn);
            }
            
            public void SetvaluesNull() {
                this[this.tableMyTable.valuesColumn] = System.Convert.DBNull;
            }
        }
        
        [System.Diagnostics.DebuggerStepThrough()]
        public class MyTableRowChangeEvent : EventArgs {
            
            private MyTableRow eventRow;
            
            private DataRowAction eventAction;
            
            public MyTableRowChangeEvent(MyTableRow tableRow, DataRowAction dataRowAction) {
                this.eventRow = tableRow;
                this.eventAction = dataRowAction;
            }
            
            public MyTableRow Row {
                get {
                    return this.eventRow;
                }
            }
            
            public DataRowAction Action {
                get {
                    return this.eventAction;
                }
            }
        }
    }
}
