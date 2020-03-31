using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.ComponentModel;
using System.Collections;

using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WinForm;
using Nevron.Examples.Framework.WebForm;

namespace Nevron.Examples.Chart.WebForm.Examples.DataManipulation.Binding
{
	public partial class NBindingToIBindingListUC : NExampleUC
	{
		private MyBindingList m_MyBindingList = new MyBindingList();
		private MyList m_TypedList = new MyList();

		protected void Page_Load(object sender, System.EventArgs e)
		{
			// setup background
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;

			nChartControl1.Legends[0].Visible = false;

			// add a label
			NLabel header = nChartControl1.Labels.AddHeader("Binding to IBindingList");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(
                new NLength(2, NRelativeUnit.ParentPercentage),
                new NLength(2, NRelativeUnit.ParentPercentage));

			NChart chart = nChartControl1.Charts[0];

			chart.BoundsMode = BoundsMode.Stretch;
			chart.Location = new NPointL(
				new NLength(5, NRelativeUnit.ParentPercentage),
				new NLength(15, NRelativeUnit.ParentPercentage));
			chart.Size = new NSizeL(
				new NLength(90, NRelativeUnit.ParentPercentage),
				new NLength(80, NRelativeUnit.ParentPercentage));

			// add the bar series
			NBarSeries bar = (NBarSeries)chart.Series.Add(SeriesType.Bar);
			bar.Name = "Bar";
			bar.Legend.Format = "<label>";
			bar.DataLabelStyle.Format = "<label>";

            NLinearScaleConfigurator linear = new NLinearScaleConfigurator();
            linear.RoundToTickMax = true;
            linear.RoundToTickMin = true;
            chart.Axis(StandardAxis.PrimaryY).ScaleConfigurator = linear;
            chart.Axis(StandardAxis.PrimaryY).View = new NRangeAxisView(new NRange1DD(0, 20), false, true);

			if(!IsPostBack)
			{
				DropDownList1.Items.Add("List Of Custom Objects");
				DropDownList1.Items.Add("ITypedList");
				DropDownList1.SelectedIndex = 0;
			}
			SetChartControl();
		}

		private void SetChartControl()
		{
			m_MyBindingList.Clear();
			m_TypedList.Clear();

			nChartControl1.DataBindingManager.RemoveAllBindings();

			DataGrid1.DataSource = null;

			//Binding to a list of custom objects.
			if(DropDownList1.SelectedIndex == 0)
			{
				m_MyBindingList.Add(new MyCustomObject(5, "Violet", new NColorFillStyle(Color.Violet)));
				m_MyBindingList.Add(new MyCustomObject(7, "Blue", new NColorFillStyle(Color.Blue)));
				m_MyBindingList.Add(new MyCustomObject(3, "Green", new NColorFillStyle(Color.Green)));
				m_MyBindingList.Add(new MyCustomObject(15, "Yellow-Green", new NColorFillStyle(Color.YellowGreen)));
				m_MyBindingList.Add(new MyCustomObject(2, "Yellow", new NColorFillStyle(Color.Yellow)));
				m_MyBindingList.Add(new MyCustomObject(9, "Orange", new NColorFillStyle(Color.Orange)));
				m_MyBindingList.Add(new MyCustomObject(6, "Orange-Red", new NColorFillStyle(Color.OrangeRed)));
				m_MyBindingList.Add(new MyCustomObject(10, "Red", new NColorFillStyle(Color.Red)));
				m_MyBindingList.Add(new MyCustomObject(6, "Purple", new NColorFillStyle(Color.Purple))); 

				DataGrid1.DataSource = m_MyBindingList;
				DataGrid1.DataBind();

				nChartControl1.DataBindingManager.AddBinding(0, 0, "Values", m_MyBindingList, "ValueY");
				nChartControl1.DataBindingManager.AddBinding(0, 0, "Labels", m_MyBindingList, "Label");
				nChartControl1.DataBindingManager.AddBinding(0, 0, "FillStyles", m_MyBindingList, "FillStyle");
			}

			//Binding to a ITypedList
			if(DropDownList1.SelectedIndex == 1)
			{
				m_TypedList.Add(new MyCustomObject(1, "Violet", new NColorFillStyle(Color.Violet)));
				m_TypedList.Add(new MyCustomObject(5, "Blue", new NColorFillStyle(Color.Blue)));
				m_TypedList.Add(new MyCustomObject(14, "Green", new NColorFillStyle(Color.Green)));
				m_TypedList.Add(new MyCustomObject(6, "Yellow-Green", new NColorFillStyle(Color.YellowGreen)));
				m_TypedList.Add(new MyCustomObject(3, "Yellow", new NColorFillStyle(Color.Yellow)));
				m_TypedList.Add(new MyCustomObject(9, "Orange", new NColorFillStyle(Color.Orange)));
				m_TypedList.Add(new MyCustomObject(8, "Orange-Red", new NColorFillStyle(Color.OrangeRed)));
				m_TypedList.Add(new MyCustomObject(7, "Red", new NColorFillStyle(Color.Red)));
				m_TypedList.Add(new MyCustomObject(4, "Purple", new NColorFillStyle(Color.Purple)));
				
				DataGrid1.DataSource = m_TypedList;
				DataGrid1.DataBind();

				nChartControl1.DataBindingManager.AddBinding(0, 0, "Values", m_TypedList, "ValueY");
				nChartControl1.DataBindingManager.AddBinding(0, 0, "Labels", m_TypedList, "Label");
				nChartControl1.DataBindingManager.AddBinding(0, 0, "FillStyles", m_TypedList, "FillStyle");
			}
		}

		class MyCustomObject
		{
			#region Constructors

			public MyCustomObject()
			{
		
			}


			public MyCustomObject(double valueY, string label)
			{
				m_ValueY = valueY;
				m_Label = label;
			}


			public MyCustomObject(double valueY, string label, NFillStyle fillStyle)
			{
				m_ValueY = valueY;
				m_Label = label;
				m_FillStile = fillStyle;
			}


			#endregion

			#region Properties

			public double ValueY
			{
				get
				{
					return m_ValueY;
				}
				set
				{
					m_ValueY = value;
				}
			}

			public string Label
			{
				get
				{
					return m_Label;
				} 
				set
				{
					m_Label = value;
				}
			}


			public NFillStyle FillStyle
			{
				get
				{
					if (m_FillStile == null)
					{
						m_FillStile = new NColorFillStyle();
					}
					return m_FillStile;
				}
				set
				{
					m_FillStile = value;
				}
			}


			#endregion

			#region Fields

			private double m_ValueY;
			private string m_Label;
			private NFillStyle m_FillStile;

			#endregion	
		}

		class MyBindingList : IBindingList
		{
			#region Constructors

			public MyBindingList()
			{
				m_List = new ArrayList();   
				m_SortDirection = ListSortDirection.Ascending;			
				m_ResetEventArgs = new ListChangedEventArgs(ListChangedType.Reset, -1);
			}


			#endregion

			#region IBindingList Members

			#region Methods
			
			public void AddIndex(PropertyDescriptor property)
			{
				
			}
		

			public void ApplySort(PropertyDescriptor property, System.ComponentModel.ListSortDirection direction)
			{
				
			}


			public int Find(PropertyDescriptor property, object key)
			{
				return -1;
			}


			public void RemoveSort()
			{
				
			}


			public object AddNew()
			{
				object o = new object();
				int n = m_List.Add(o);
				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, n));
				return o;
			}


			public void RemoveIndex(PropertyDescriptor property)
			{
				
			}


			#endregion

			#region Properties

			public bool AllowNew
			{
				get
				{
					return true;
				}
			}


			public PropertyDescriptor SortProperty
			{
				get
				{
					return null;
				}
			}


			public bool SupportsSorting
			{
				get
				{
					return true;
				}
			}


			public bool IsSorted
			{
				get
				{
					return true;
				}
			}


			public bool AllowRemove
			{
				get
				{
					return true;
				}
			}


			public bool SupportsSearching
			{
				get
				{
					return true;
				}
			}


			public ListSortDirection SortDirection
			{
				get
				{
					return m_SortDirection;
				}
			}


			public event ListChangedEventHandler ListChanged
			{
				add
				{
					m_OnListChanged += value;
				}
				remove
				{
					m_OnListChanged -= value;
				}
			}


			public bool SupportsChangeNotification
			{
				get
				{
				
					return true;
				}
			}


			public bool AllowEdit
			{
				get
				{
					return true;
				}
			}


			#endregion

			#endregion

			#region IList Members

			#region Methods

			public void RemoveAt(int index)
			{
				m_List.RemoveAt(index);
				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
			}


			public void Insert(int index, object value)
			{
				m_List.Insert(index, value);
				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
			}


			public void Remove(object value)
			{
				m_List.Remove(value);
				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, m_List.IndexOf(value)));
			}


			public bool Contains(object value)
			{
				return m_List.Contains(value);
			}


			public void Clear()
			{
				m_List.Clear();
				OnListChanged(m_ResetEventArgs);
			}


			public int IndexOf(object value)
			{
				return m_List.IndexOf(value);
			}


			public int Add(object value)
			{
				m_List.Add(value);
				int last = m_List.IndexOf(value);
				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, last));
				return last;
			}


			#endregion

			#region Properties

			public bool IsReadOnly
			{
				get 
				{ 
					return m_List.IsReadOnly; 
				}
			}


			public object this[int index]
			{
				get
				{
					return m_List[index];
				}
				set
				{
					m_List[index] = value;
					OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, index));
				}
			}


			public bool IsFixedSize
			{
				get
				{
					return true; 
				}
			}


			#endregion

			#endregion

			#region ICollection Members

			public void CopyTo(Array array, int index)
			{
				m_List.CopyTo(array, index);
			}


			public bool IsSynchronized
			{
				get
				{
					return m_List.IsSynchronized;
				}
			}


			public int Count
			{
				get
				{
					return m_List.Count; 
				}
			}


			public object SyncRoot
			{
				get
				{
					return m_List.SyncRoot;
				}
			}


			#endregion

			#region IEnumerable Members

			public System.Collections.IEnumerator GetEnumerator()
			{
				return m_List.GetEnumerator();
			}


			#endregion

			protected virtual void OnListChanged(ListChangedEventArgs ev)
			{
				if (m_OnListChanged != null)
				{
					m_OnListChanged(this, ev);
				}
			}


			#region Fields

			private ArrayList m_List;
			private ListSortDirection m_SortDirection;
			private ListChangedEventHandler m_OnListChanged;
			internal static ListChangedEventArgs m_ResetEventArgs;

			#endregion
		}

		class MyList : IBindingList, ITypedList
		{
			#region Constructors

			public MyList()
			{
				m_List = new ArrayList();   
				m_SortDirection = ListSortDirection.Ascending;			
				m_ResetEventArgs = new ListChangedEventArgs(ListChangedType.Reset, -1);
			}


			#endregion

			#region IBindingList Members

			#region Methods
			
			public void AddIndex(PropertyDescriptor property)
			{
				
			}
		

			public void ApplySort(PropertyDescriptor property, System.ComponentModel.ListSortDirection direction)
			{
				
			}


			public int Find(PropertyDescriptor property, object key)
			{
				return -1;
			}


			public void RemoveSort()
			{
				
			}


			public object AddNew()
			{
				object o = new object();
				int n = m_List.Add(o);
				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, n));
				return o;
			}


			public void RemoveIndex(PropertyDescriptor property)
			{
				
			}


			#endregion

			#region Properties

			public bool AllowNew
			{
				get
				{
					return true;
				}
			}


			public PropertyDescriptor SortProperty
			{
				get
				{
					return null;
				}
			}


			public bool SupportsSorting
			{
				get
				{
					return true;
				}
			}


			public bool IsSorted
			{
				get
				{
					return true;
				}
			}


			public bool AllowRemove
			{
				get
				{
					return true;
				}
			}


			public bool SupportsSearching
			{
				get
				{
					return true;
				}
			}


			public ListSortDirection SortDirection
			{
				get
				{
					return m_SortDirection;
				}
			}


			public event ListChangedEventHandler ListChanged
			{
				add
				{
					m_OnListChanged += value;
				}
				remove
				{
					m_OnListChanged -= value;
				}
			}


			public bool SupportsChangeNotification
			{
				get
				{
				
					return true;
				}
			}


			public bool AllowEdit
			{
				get
				{
					return true;
				}
			}


			#endregion

			#endregion

			#region IList Members

			#region Methods

			public void RemoveAt(int index)
			{
				m_List.RemoveAt(index);
				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
			}


			public void Insert(int index, object value)
			{
				m_List.Insert(index, value);
				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
			}


			public void Remove(object value)
			{
				m_List.Remove(value);
				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, m_List.IndexOf(value)));
			}


			public bool Contains(object value)
			{
				return m_List.Contains(value);
			}


			public void Clear()
			{
				m_List.Clear();
				OnListChanged(m_ResetEventArgs);
			}


			public int IndexOf(object value)
			{
				return m_List.IndexOf(value);
			}


			public int Add(object value)
			{
				m_List.Add(value);
				int last = m_List.IndexOf(value);
				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, last));
				return last;
			}


			#endregion

			#region Properties

			public bool IsReadOnly
			{
				get 
				{ 
					return m_List.IsReadOnly; 
				}
			}


			public object this[int index]
			{
				get
				{
					return m_List[index];
				}
				set
				{
					m_List[index] = value;
					OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, index));
				}
			}


			public bool IsFixedSize
			{
				get
				{
					return true; 
				}
			}


			#endregion

			#endregion

			#region ICollection Members

			public void CopyTo(Array array, int index)
			{
				m_List.CopyTo(array, index);
			}


			public bool IsSynchronized
			{
				get
				{
					return m_List.IsSynchronized;
				}
			}


			public int Count
			{
				get
				{
					return m_List.Count; 
				}
			}


			public object SyncRoot
			{
				get
				{
					return m_List.SyncRoot;
				}
			}


			#endregion

			#region IEnumerable Members

			public System.Collections.IEnumerator GetEnumerator()
			{
				return m_List.GetEnumerator();
			}


			#endregion

			#region ITypedList Members

			public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] listAccessors)
			{
				return TypeDescriptor.GetProperties(typeof(MyCustomObject));
			}


			public string GetListName(PropertyDescriptor[] listAccessors)
			{
				return "MyCustomObject";
			}


			#endregion

			protected virtual void OnListChanged(ListChangedEventArgs ev)
			{
				if (m_OnListChanged != null)
				{
					m_OnListChanged(this, ev);
				}
			}


			#region Fields

			private ArrayList m_List;
			private ListSortDirection m_SortDirection;
			private ListChangedEventArgs m_ResetEventArgs;
			private ListChangedEventHandler m_OnListChanged;

			#endregion
		}
	}
}
