using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;

using Nevron.Diagram;
using Nevron.Diagram.Layout;
using Nevron.Diagram.Shapes;
using Nevron.GraphicsCore;

namespace Nevron.Examples.Diagram.Webform
{
	/// <summary>
	/// Summary description for NDrawingDocumentHelper.
	/// </summary>
	public class NDrawingDocumentHelper
	{
		#region Constructors

		public NDrawingDocumentHelper(NDrawingDocument document)
		{
			this.document = document;
		}

		#endregion

		#region Properties

		/// <summary>
		/// Gets/sets the default grid cell size
		/// </summary>
		public NSizeF DefaultGridCellSize
		{
			get
			{
				return defaultGridCellSize;
			}
			set
			{
				defaultGridCellSize = value;
			}
		}
		/// <summary>
		/// Gets/sets the default grid origin
		/// </summary>
		public NPointF DefaultGridOrigin
		{
			get
			{
				return defaultGridOrigin;
			}
			set
			{
				defaultGridOrigin = value;
			}
		}
		/// <summary>
		/// Gets/sets the default grid spacing
		/// </summary>
		public NSizeF DefaultGridSpacing
		{
			get
			{
				return defaultGridSpacing;
			}
			set
			{
				defaultGridSpacing = value;
			}
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Creates a connector between the ports of the specified shapes
		/// </summary>
		/// <param name="fromShape"></param>
		/// <param name="fromPortName"></param>
		/// <param name="toShape"></param>
		/// <param name="toPortName"></param>
		/// <param name="connectorType"></param>
		/// <param name="text"></param>
		/// <returns></returns>
		public NShape CreateConnector(NShape fromShape, string fromPortName, NShape toShape, string toPortName, ConnectorType connectorType, string text)
		{
			// check input
			if (fromShape == null)
				throw new ArgumentNullException("fromShape");

			if (toShape == null)
				throw new ArgumentNullException("toShape");

			NPort fromPort = (fromShape.Ports.GetChildByName(fromPortName, 0) as NPort);
			if (fromPort == null)
				throw new ArgumentException("Was not able to find fromPortName in the ports collection of the fromShape", "fromPortName");

			NPort toPort = (toShape.Ports.GetChildByName(toPortName, 0) as NPort);
			if (toPort == null)
				throw new ArgumentException("Was not able to find toPortName in the ports collection of the toShape", "toPortName");

			// create the connector
			NShape connector = null;
			switch (connectorType)
			{
				case ConnectorType.Line:
					connector = new NLineShape();
					break;

				case ConnectorType.Bezier:
					connector = new NBezierCurveShape();
					break;

				case ConnectorType.SingleArrow:
					connector = new NArrowShape(ArrowType.SingleArrow); 
					break;

				case ConnectorType.DoubleArrow:
					connector = new NArrowShape(ArrowType.DoubleArrow);
					break;
					
				case ConnectorType.SideToTopBottom:
					connector = new NStep2Connector(false);
					break;

				case ConnectorType.TopBottomToSide:
					connector = new NStep2Connector(true);
					break;

				case ConnectorType.SideToSide:
					connector = new NStep3Connector(false, 50, 0, true);
					break;

				case ConnectorType.TopToBottom:
					connector = new NStep3Connector(true, 50, 0, true);
					break;

				case ConnectorType.DynamicHV:
					connector = new NRoutableConnector(RoutableConnectorType.DynamicHV);
					break;

				case ConnectorType.DynamicPolyline:
					connector = new NRoutableConnector(RoutableConnectorType.DynamicPolyline);
					break;

				case ConnectorType.DynamicCurve:
					connector = new NRoutableConnector(RoutableConnectorType.DynamicCurve);
					break;

				default:
					Debug.Assert(false, "New graph connector type?");
					break;
			}

			// the connector must be added to the document prior to connecting it
			document.ActiveLayer.AddChild(connector);

			connector.StartPlug.Connect(fromPort);
			connector.EndPlug.Connect(toPort);

			connector.Style.TextStyle = (connector.ComposeTextStyle().Clone() as NTextStyle);
			connector.Style.TextStyle.Offset = new Nevron.GraphicsCore.NPointL(0, -7);

			connector.Text = text;
			return connector;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="basicShape"></param>
		/// <param name="bounds"></param>
		/// <param name="text"></param>
		/// <param name="fillStyle"></param>
		/// <returns></returns>
		public NShape CreateBasicShape(BasicShapes basicShape, NRectangleF bounds, string text, NFillStyle fillStyle)
		{
			return CreateBasicShape(basicShape, bounds, text, fillStyle, true);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="basicShape"></param>
		/// <param name="bounds"></param>
		/// <param name="text"></param>
		/// <param name="fillStyle"></param>
		/// <param name="addToActiveLayer"></param>
		/// <returns></returns>
		public NShape CreateBasicShape(BasicShapes basicShape, NRectangleF bounds, string text, NFillStyle fillStyle, bool addToActiveLayer)
		{
			NBasicShapesFactory factory = new NBasicShapesFactory(document);
			NShape shape = factory.CreateShape((int)basicShape);

			shape.Bounds = bounds;
			shape.Text = text;
			shape.Style.FillStyle = (NFillStyle)fillStyle.Clone();

			if (addToActiveLayer)
				document.ActiveLayer.AddChild(shape);

			return shape;
		}
		/// <summary>
		/// Creates a new basic shape and adds it to the document's active layer.
		/// </summary>
		/// <param name="basicShape"></param>
		/// <param name="bounds"></param>
		/// <param name="text"></param>
		/// <param name="styleSheetName"></param>
		/// <returns></returns>
		public NShape CreateBasicShape(BasicShapes basicShape, NRectangleF bounds, string text, string styleSheetName)
		{
			NBasicShapesFactory factory = new NBasicShapesFactory(document);
			NShape shape = factory.CreateShape((int)basicShape);

			shape.Bounds = bounds;
			shape.Text = text;
			shape.StyleSheetName = styleSheetName;
			document.ActiveLayer.AddChild(shape);

			return shape;

		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="flowChartingShape"></param>
		/// <param name="bounds"></param>
		/// <param name="text"></param>
		/// <param name="fillStyle"></param>
		/// <returns></returns>
		public NShape CreateFlowChartingShape(FlowChartingShapes flowChartingShape, NRectangleF bounds, string text, NFillStyle fillStyle)
		{
			NFlowChartingShapesFactory factory = new NFlowChartingShapesFactory(document);
			NShape shape = factory.CreateShape((int)flowChartingShape);

			shape.Bounds = bounds;
			shape.Text = text;
			shape.Style.FillStyle = (NFillStyle)fillStyle.Clone();

			document.ActiveLayer.AddChild(shape);

			return shape;		
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="row"></param>
		/// <param name="col"></param>
		/// <returns></returns>
		public NRectangleF GetGridCell(int row, int col)
		{
			return GetGridCell(row, col, defaultGridOrigin, defaultGridCellSize, defaultGridSpacing);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="row"></param>
		/// <param name="col"></param>
		/// <param name="rowSpan"></param>
		/// <param name="colSpan"></param>
		/// <returns></returns>
		public NRectangleF GetGridCell(int row, int col, int rowSpan, int colSpan)
		{
			NRectangleF cell1 = GetGridCell(row, col, defaultGridOrigin, defaultGridCellSize, defaultGridSpacing);
			NRectangleF cell2 = GetGridCell(row + rowSpan, col + colSpan, defaultGridOrigin, defaultGridCellSize, defaultGridSpacing);
			return NRectangleF.Union(cell1, cell2);
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="row"></param>
		/// <param name="col"></param>
		/// <param name="origin"></param>
		/// <param name="size"></param>
		/// <param name="spacing"></param>
		/// <returns></returns>
		public NRectangleF GetGridCell(int row, int col, NPointF origin, NSizeF size, NSizeF spacing)
		{
			return new NRectangleF(	origin.X + col * (size.Width + spacing.Width), 
				origin.Y + row * (size.Height + spacing.Height), 
				size.Width, size.Height); 
		}
		/// <summary>
		/// Parses the given string to float using the proper decimal separator.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		public float ParseFloat(string value)
		{
			if (value.Contains("."))
				value = value.Replace(".", DecimalSeparator);
			else if (value.Contains(","))
				value = value.Replace(",", DecimalSeparator);

			return Single.Parse(value);
		}

		/// <summary>
		/// Configures the layout using the property/value pairs in the specified dictionary.
		/// </summary>
		/// <param name="layout"></param>
		/// <param name="settings"></param>
		public void ConfigureLayout(NLayout layout, Dictionary<string, string> settings)
		{
			Type layoutType = layout.GetType();
			Dictionary<string, string>.Enumerator iter = settings.GetEnumerator();

			while(iter.MoveNext())
			{
				string name = iter.Current.Key;
				string value = iter.Current.Value;

				PropertyInfo p = layoutType.GetProperty(name);
				if (p == null)
					continue;

				try
				{
					object propertyValue = null;
					if (p.PropertyType.Equals(FloatType))
					{
						propertyValue = ParseFloat(value);
					}
					else
					{
						propertyValue = p.PropertyType.IsEnum ?
							Enum.Parse(p.PropertyType, value) :
							Convert.ChangeType(value, p.PropertyType);
					}

					p.SetValue(layout, propertyValue, null);
				}
				catch
				{
					throw new Exception(String.Format("The value '{0}' is not valid for the '{1}' property", value, name));
				}
			}
		}
		/// <summary>
		/// Parses the given string of key/value pairs to a dictionary. The string should be in the format:
		/// <para>
		/// name1=value1
		/// </para>
		/// <para>
		/// name2=value2
		/// </para>
		/// <para>
		/// etc.
		/// </para>
		/// </summary>
		/// <param name="settings"></param>
		/// <returns></returns>
		public Dictionary<string, string> ParseSettings(string settings)
		{
			Dictionary<string, string> dict = new Dictionary<string, string>();
			string[] lines = settings.Split(LineSeparators, StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0, lineCount = lines.Length; i < lineCount; i++)
			{
				string[] lineData = lines[i].Split('=');
				dict.Add(lineData[0], lineData[1]);
			}

			return dict;
		}

		#endregion

		#region Fields

		// document and view
		protected NDrawingDocument document;

		// random number generator
		protected Random random;
		
		// form controls event handling lock
		//private int suspendEventHandlingLock = 0;

		// grid
		private NSizeF defaultGridCellSize;
		private NPointF defaultGridOrigin;
		private NSizeF defaultGridSpacing;

		#endregion

		#region Constants

		private readonly string DecimalSeparator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

		private static readonly Type FloatType = typeof(float);
		private static readonly char[] LineSeparators = new char[] { '\n' };

		#endregion
	}
}