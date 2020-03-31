using System;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

using Nevron.Examples.Framework.WebForm;
using Nevron.UI;
using Nevron.UI.WebForm.Controls;
using Nevron.GraphicsCore;
using Nevron.Chart;
using Nevron.Chart.WebForm;
using Nevron.SmartShapes;

namespace Nevron.Examples.Chart.WebForm
{
	public partial class NRadialGaugeIndicatorsUC : NExampleUC
	{
        protected NRadialGaugePanel m_RadialGauge;
        protected NLinearGaugePanel m_LinearGauge;

        protected void Page_Load(object sender, System.EventArgs e)
        {
            // first clear all gauges
            nChartControl1.BackgroundStyle.FrameStyle.Visible = false;
            nChartControl1.Panels.Clear();

            // set a chart title
            NLabel header = nChartControl1.Labels.AddHeader("Gauge Glass and Gel Effects");
            header.TextStyle.FontStyle = new NFontStyle("Times New Roman", 14, FontStyle.Italic);
            header.TextStyle.FillStyle = new NColorFillStyle(Color.FromArgb(60, 90, 108));
            header.TextStyle.ShadowStyle.Type = ShadowType.LinearBlur;
            header.ContentAlignment = ContentAlignment.BottomRight;
            header.Location = new NPointL(new NLength(2, NRelativeUnit.ParentPercentage), new NLength(2, NRelativeUnit.ParentPercentage));

            // create the radial gauge
            CreateRadialGauge();

            // create the linear gauge
            CreateLinearGauge();

            m_RadialGauge.Location = new NPointL(new NLength(10, NRelativeUnit.ParentPercentage), new NLength(10, NRelativeUnit.ParentPercentage));
            m_RadialGauge.Size = new NSizeL(new NLength(45, NRelativeUnit.ParentPercentage), new NLength(80, NRelativeUnit.ParentPercentage));
            m_RadialGauge.ContentAlignment = ContentAlignment.BottomRight;

            m_LinearGauge.Location = new NPointL(new NLength(60, NRelativeUnit.ParentPercentage), new NLength(10, NRelativeUnit.ParentPercentage));
            m_LinearGauge.Size = new NSizeL(new NLength(80, NGraphicsUnit.Point), new NLength(80, NRelativeUnit.ParentPercentage));
            m_LinearGauge.Padding = new NMarginsL(0, 13, 0, 13);

            if (!IsPostBack)
            {
                ShowGlassOnRadialGauge.Checked = true;
                ShowGelOnLinearGauge.Checked = true;
            }

            // apply paint effects to the gauges
            if (ShowGlassOnRadialGauge.Checked)
            {
                m_RadialGauge.PaintEffect = new NGlassEffectStyle();
            }

            if (ShowGelOnLinearGauge.Checked)
            {
                m_LinearGauge.PaintEffect = new NGelEffectStyle();
            }
        }

        private void ApplyScaleSectionToAxis(NLinearScaleConfigurator scale)
        {
            NScaleSectionStyle scaleSection = new NScaleSectionStyle();

            scaleSection.Range = new NRange1DD(70, 100);
            scaleSection.LabelTextStyle = new NTextStyle();
            scaleSection.LabelTextStyle.FillStyle = new NColorFillStyle(KnownArgbColorValue.DarkRed);
            scaleSection.LabelTextStyle.FontStyle = new NFontStyle("Arial", 8, FontStyle.Bold);
            scaleSection.MajorTickStrokeStyle = new NStrokeStyle(Color.DarkRed);

            scale.Sections.Add(scaleSection);
        }

        private void CreateLinearGauge()
        {
            m_LinearGauge = new NLinearGaugePanel();
            m_LinearGauge.Orientation = LinearGaugeOrientation.Vertical;
            nChartControl1.Panels.Add(m_LinearGauge);

            // create the background panel
            m_LinearGauge.BackgroundFillStyle = new NColorFillStyle(Color.Black);
            m_LinearGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.RoundedRect);

            NGaugeAxis axis = (NGaugeAxis)m_LinearGauge.Axes[0];
            axis.Anchor = new NModelGaugeAxisAnchor(new NLength(10, NGraphicsUnit.Point), VertAlign.Center, RulerOrientation.Left);
            ConfigureScale((NLinearScaleConfigurator)axis.ScaleConfigurator);

            // add some indicators
            AddRangeIndicatorToGauge(m_LinearGauge);
            m_LinearGauge.Indicators.Add(new NMarkerValueIndicator(60));
        }

        private void CreateRadialGauge()
        {
            // create the radial gauge
            m_RadialGauge = new NRadialGaugePanel();
            m_RadialGauge.BorderStyle = new NEdgeBorderStyle(BorderShape.Auto);
            nChartControl1.Panels.Add(m_RadialGauge);

            // create the radial gauge
            m_RadialGauge.SweepAngle = 270;
            m_RadialGauge.BeginAngle = -90;

            // set some background
            m_RadialGauge.BackgroundFillStyle = new NColorFillStyle(Color.Black); ;

            // configure the axis
            NGaugeAxis axis = (NGaugeAxis)m_RadialGauge.Axes[0];
            axis.Range = new NRange1DD(0, 100);
            axis.Anchor.RulerOrientation = RulerOrientation.Right;
            axis.Anchor = new NDockGaugeAxisAnchor(GaugeAxisDockZone.Top, true, RulerOrientation.Right, 0, 100);

            ConfigureScale((NLinearScaleConfigurator)axis.ScaleConfigurator);

            // add some indicators
            AddRangeIndicatorToGauge(m_RadialGauge);

            NNeedleValueIndicator needle = new NNeedleValueIndicator(60);
			needle.OffsetOriginMode = IndicatorOffsetOriginMode.ScaleMiddle;
            m_RadialGauge.Indicators.Add(needle);
        }

        private void AddRangeIndicatorToGauge(NGaugePanel gauge)
        {
            // add some indicators
            NRangeIndicator rangeIndicator = new NRangeIndicator(new NRange1DD(75, 100));
            rangeIndicator.FillStyle = new NColorFillStyle(Color.Red);
            rangeIndicator.StrokeStyle.Width = new NLength(0);
            rangeIndicator.BeginWidth = new NLength(5);
            rangeIndicator.EndWidth = new NLength(10);
			rangeIndicator.OffsetFromScale = new NLength(-10);
            rangeIndicator.PaintOrder = IndicatorPaintOrder.BeforeScale;

            gauge.Indicators.Add(rangeIndicator);
        }

        private void ConfigureScale(NLinearScaleConfigurator scale)
        {
            scale.SetPredefinedScaleStyle(PredefinedScaleStyle.PresentationNoStroke);
            scale.LabelFitModes = new LabelFitMode[0];
            scale.MinorTickCount = 3;
            scale.RulerStyle.FillStyle = new NColorFillStyle(Color.FromArgb(40, Color.White));
            scale.OuterMajorTickStyle.FillStyle = new NColorFillStyle(Color.Orange);
            scale.LabelStyle.TextStyle.FontStyle = new NFontStyle("Arial", 8, FontStyle.Bold);
            scale.LabelStyle.TextStyle.FillStyle = new NColorFillStyle(Color.White);
        }
	}
}
