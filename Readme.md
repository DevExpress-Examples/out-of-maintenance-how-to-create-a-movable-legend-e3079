<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128573516/10.2.6%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3079)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/LegendAnnotation/Form1.cs) (VB: [Form1.vb](./VB/LegendAnnotation/Form1.vb))
<!-- default file list end -->
# How to create a movable legend


<p>This example illustrates how to make a chart legend movable, so that an end-user can change its position via drag & drop at runtime.<br>To accomplish this, the chart's Legend item is rendered to an image and linked to an <a href="https://documentation.devexpress.com/WindowsForms/7858/Controls-and-Libraries/Chart-Control/Fundamentals/Chart-Elements/Annotations">Image Annotation</a>. The annotation's <a href="https://documentation.devexpress.com/CoreLibraries/DevExpress.XtraCharts.Annotation.RuntimeMoving.property">RuntimeMoving</a> option is enabled to make the annotation element movable.</p>


<h3>Description</h3>

<p>For this, it is necessary to hide a legend and show an <strong>ImageAnnotaion </strong>instead of it. The legend image can be obtained via the <strong>DrawToBitmap </strong>method called for another helper <strong>ChartControl </strong>instance.</p><p>Note: To make an annotation movable, its <strong>RuntimeMoving </strong>property should be set to <strong>true</strong>.</p>

<br/>


