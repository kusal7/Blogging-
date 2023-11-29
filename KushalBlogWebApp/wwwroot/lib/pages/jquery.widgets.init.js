var dash_spark_1 = {
  chart: { type: "area", height: 60, sparkline: { enabled: !0 } },
  stroke: { curve: "smooth", width: 3 },
  fill: {
    opacity: 1,
    gradient: {
      shade: "#2c77f4",
      type: "horizontal",
      shadeIntensity: 0.5,
      inverseColors: !0,
      opacityFrom: 0.1,
      opacityTo: 0.1,
      stops: [0, 80, 100],
      colorStops: [],
    },
  },
  series: [
    { data: [4, 8, 5, 10, 4, 16, 5, 11, 6, 11, 30, 10, 13, 4, 6, 3, 6] },
  ],
  yaxis: { min: 0 },
  colors: ["#2c77f4"],
  tooltip: { show: !1 },
};
new ApexCharts(document.querySelector("#dash_spark_1"), dash_spark_1).render();
var dash_spark_2 = {
  chart: { type: "area", height: 60, sparkline: { enabled: !0 } },
  stroke: { curve: "smooth", width: 3 },
  fill: {
    opacity: 1,
    gradient: {
      shade: "#fdb5c8",
      type: "horizontal",
      shadeIntensity: 0.5,
      inverseColors: !0,
      opacityFrom: 0.1,
      opacityTo: 0.1,
      stops: [0, 80, 100],
      colorStops: [],
    },
  },
  series: [{ data: [4, 8, 5, 10, 4, 25, 5, 11, 6, 11, 5, 10, 3, 14, 6, 8, 6] }],
  yaxis: { min: 0 },
  colors: ["#fdb5c8"],
};
new ApexCharts(document.querySelector("#dash_spark_2"), dash_spark_2).render();
var options = {
  series: [76],
  chart: { type: "radialBar", offsetY: -20, sparkline: { enabled: !0 } },
  plotOptions: {
    radialBar: {
      startAngle: -90,
      endAngle: 90,
      hollow: { size: "75%", position: "front" },
      track: {
        background: ["rgba(42, 118, 244, .18)"],
        strokeWidth: "80%",
        opacity: 0.5,
        margin: 5,
      },
      dataLabels: {
        name: { show: !1 },
        value: { offsetY: -2, fontSize: "20px" },
      },
    },
  },
  stroke: { lineCap: "butt" },
  colors: ["#2a76f4"],
  grid: { padding: { top: -10 } },
  labels: ["Average Results"],
};
(chart = new ApexCharts(document.querySelector("#ana_1"), options)).render();
options = {
  chart: { height: 240, type: "donut" },
  plotOptions: { pie: { donut: { size: "85%" } } },
  dataLabels: { enabled: !1 },
  stroke: { show: !0, width: 2, colors: ["transparent"] },
  series: [65, 20, 10, 5],
  legend: {
    show: !1,
    position: "bottom",
    horizontalAlign: "center",
    verticalAlign: "middle",
    floating: !1,
    fontSize: "14px",
    offsetX: 0,
    offsetY: -13,
  },
  labels: ["Excellent", "Very Good", "Good", "Fair"],
  colors: ["#2a76f4", "#fdb5c8", "#67c8ff", "#c693ff"],
  responsive: [
    {
      breakpoint: 600,
      options: {
        plotOptions: { donut: { customScale: 0.2 } },
        chart: { height: 240 },
        legend: { show: !1 },
      },
    },
  ],
  tooltip: {
    y: {
      formatter: function (e) {
        return e + " %";
      },
    },
  },
};
(chart = new ApexCharts(
  document.querySelector("#ana_device"),
  options
)).render();
options = {
  chart: { height: 310, type: "donut" },
  plotOptions: { pie: { donut: { size: "85%" } } },
  dataLabels: { enabled: !1 },
  stroke: { show: !0, width: 2, colors: ["transparent"] },
  series: [50, 25, 25],
  legend: {
    show: !0,
    position: "bottom",
    horizontalAlign: "center",
    verticalAlign: "middle",
    floating: !1,
    fontSize: "13px",
    offsetX: 0,
    offsetY: 0,
  },
  labels: ["Mobile", "Tablet", "Desktop"],
  colors: ["#2a76f4", "rgba(42, 118, 244, .5)", "rgba(42, 118, 244, .18)"],
  responsive: [
    {
      breakpoint: 600,
      options: {
        plotOptions: { donut: { customScale: 0.2 } },
        chart: { height: 240 },
        legend: { show: !1 },
      },
    },
  ],
  tooltip: {
    y: {
      formatter: function (e) {
        return e + " %";
      },
    },
  },
};
(chart = new ApexCharts(
  document.querySelector("#ana_device2"),
  options
)).render();
var chart;
options = {
  chart: {
    type: "radialBar",
    height: 300,
    dropShadow: {
      enabled: !0,
      top: 5,
      left: 0,
      bottom: 0,
      right: 0,
      blur: 5,
      color: "#45404a2e",
      opacity: 0.35,
    },
  },
  plotOptions: {
    radialBar: {
      offsetY: -10,
      startAngle: 0,
      endAngle: 270,
      hollow: { margin: 5, size: "50%", background: "transparent" },
      track: { show: !1 },
      dataLabels: {
        name: { fontSize: "18px" },
        value: { fontSize: "16px", color: "#50649c" },
      },
    },
  },
  colors: ["#2a76f4", "rgba(42, 118, 244, .5)", "rgba(42, 118, 244, .18)"],
  stroke: { lineCap: "round" },
  series: [71, 63, 100],
  labels: ["Completed", "Active", "Assigned"],
  legend: {
    show: !0,
    floating: !0,
    position: "left",
    offsetX: -10,
    offsetY: 0,
  },
  responsive: [
    {
      breakpoint: 480,
      options: {
        legend: {
          show: !0,
          floating: !0,
          position: "left",
          offsetX: 10,
          offsetY: 0,
        },
      },
    },
  ],
};
(chart = new ApexCharts(
  document.querySelector("#task_status"),
  options
)).render();
