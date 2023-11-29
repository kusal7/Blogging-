var options = {
  chart: { height: 345, type: "bar", toolbar: { show: !1 } },
  plotOptions: { bar: { horizontal: !1, columnWidth: "30%" } },
  colors: ["#2a76f4"],
  dataLabels: { enabled: !1 },
  stroke: { show: !0, width: 2 },
  series: [
    {
      name: "Revenue",
      data: [
        0, 160, 100, 210, 145, 400, 155, 210, 120, 275, 110, 200, 100, 90, 220,
        100, 180, 140, 315, 130, 105, 165, 120, 160, 100, 210, 145, 400, 155,
        210, 120,
      ],
    },
  ],
  labels: [
    "01",
    "02",
    "03",
    "04",
    "05",
    "06",
    "07",
    "08",
    "09",
    "10",
    "11",
    "12",
    "13",
    "14",
    "15",
    "16",
    "17",
    "18",
    "19",
    "20",
    "21",
    "22",
    "23",
    "24",
    "25",
    "26",
    "27",
    "28",
    "29",
    "30",
    "31",
  ],
  yaxis: { labels: { offsetX: -12, offsetY: 0 } },
  grid: {
    borderColor: "#e0e6ed",
    strokeDashArray: 3,
    xaxis: { lines: { show: !1 } },
    yaxis: { lines: { show: !0 } },
  },
  legend: { show: !1 },
  tooltip: { marker: { show: !0 }, x: { show: !1 } },
  yaxis: {
    labels: {
      formatter: function (e) {
        return "Rs." + e;
      },
    },
  },
  fill: { opacity: 1 },
};
(chart = new ApexCharts(
  document.querySelector("#Revenu_Status"),
  options
)).render();
var chart;
options = {
  chart: { height: 270, type: "donut" },
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
  document.querySelector("#ana_device"),
  options
)).render();
var dash_spark_1 = {
  chart: { type: "area", height: 50, sparkline: { enabled: !0 } },
  stroke: { curve: "smooth", width: 1.5 },
  fill: {
    opacity: 1,
    gradient: {
      shade: "#e3ebf6",
      type: "horizontal",
      shadeIntensity: 0.5,
      inverseColors: !0,
      opacityFrom: 0.5,
      opacityTo: 0.5,
      stops: [0, 80, 100],
      colorStops: [],
    },
  },
  series: [
    { data: [4, 8, 5, 10, 4, 16, 5, 11, 6, 11, 30, 10, 13, 4, 6, 3, 6] },
  ],
  yaxis: { min: 0 },
  colors: ["#e3ebf6"],
  tooltip: { show: !1 },
};
new ApexCharts(document.querySelector("#dash_spark_1"), dash_spark_1).render();
