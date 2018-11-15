<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/LegendAnnotation/Form1.cs) (VB: [Form1.vb](./VB/LegendAnnotation/Form1.vb))
<!-- default file list end -->
# How to create a movable legend


<p>This example illustrates how to make a chart legend movable, so that an end-user can change its position via drag & drop at runtime.<br>To accomplish this, the chart's Legend item is rendered to an image and linked to an <a href="https://documentation.devexpress.com/WindowsForms/7858/Controls-and-Libraries/Chart-Control/Fundamentals/Chart-Elements/Annotations">Image Annotation</a>. The annotation's <a href="https://documentation.devexpress.com/CoreLibraries/DevExpress.XtraCharts.Annotation.RuntimeMoving.property">RuntimeMoving</a> option is enabled to make the annotation element movable.</p>


<h3>Description</h3>

<p>For this, it is necessary to hide a legend and show an <strong>ImageAnnotaion </strong>instead of it. The legend image can be obtained via the <strong>DrawToBitmap </strong>method called for another helper <strong>ChartControl </strong>instance.</p><p>Note: To make an annotation movable, its <strong>RuntimeMoving </strong>property should be set to <strong>true</strong>.</p>

<br/>


