!(function (n) {
  "use strict";
  function a() {
    n(window).width() < 1300
      ? n("body").addClass("enlarge-menu enlarge-menu-all")
      : n("body").removeClass("enlarge-menu enlarge-menu-all");
  }
  !(function () {
    if (0 != n("#Dash_Date").length) {
      var i = n("#Dash_Date"),
        a = moment(),
        t = moment();
      i.daterangepicker(
        {
          startDate: a,
          endDate: t,
          opens: "left",
          applyClass: "btn btn-sm btn-primary",
          cancelClass: "btn btn-sm btn-secondary",
          ranges: {
            Today: [moment(), moment()],
            Yesterday: [
              moment().subtract(1, "days"),
              moment().subtract(1, "days"),
            ],
            "Last 7 Days": [moment().subtract(6, "days"), moment()],
            "Last 30 Days": [moment().subtract(29, "days"), moment()],
            "This Month": [moment().startOf("month"), moment().endOf("month")],
            "Last Month": [
              moment().subtract(1, "month").startOf("month"),
              moment().subtract(1, "month").endOf("month"),
            ],
          },
        },
        e
      ),
        e(a, t, "");
    }
    function e(a, t, e) {
      var n = "",
        s = "";
      t - a < 100 || "Today" == e
        ? ((n = "Today:"), (s = a.format("MMM D")))
        : "Yesterday" == e
        ? ((n = "Yesterday:"), (s = a.format("MMM D")))
        : (s = a.format("MMM D") + " - " + t.format("MMM D")),
        i.find("#Select_date").html(s),
        i.find("#Day_Name").html(n);
    }
  })(),
    n(".metismenu").metisMenu(),
    n(window).resize(function () {
      a();
    }),
    n(".button-menu-mobile").on("click", function (a) {
      a.preventDefault(), n("body").toggleClass("enlarge-menu");
    }),
    a(),
    n(".main-icon-menu .nav-link").on("click", function (a) {
      n("body").removeClass("enlarge-menu"),
        a.preventDefault(),
        n(this).addClass("active"),
        n(this).siblings().removeClass("active"),
        n(".main-menu-inner").addClass("active");
      var t = n(this).attr("href");
      n(t).addClass("active"), n(t).siblings().removeClass("active");
    }),
    n(".leftbar-tab-menu a, .left-sidenav a").each(function () {
      var a = window.location.href.split(/[?#]/)[0];
      if (this.href == a) {
        n(this).addClass("active"),
          n(this).parent().addClass("active"),
          n(this).parent().parent().addClass("in"),
          n(this).parent().parent().addClass("mm-show"),
          n(this).parent().parent().parent().addClass("mm-active"),
          n(this).parent().parent().prev().addClass("active"),
          n(this).parent().parent().parent().addClass("active"),
          n(this).parent().parent().parent().parent().addClass("mm-show"),
          n(this)
            .parent()
            .parent()
            .parent()
            .parent()
            .parent()
            .addClass("mm-active");
        var t = n(this).closest(".main-icon-menu-pane").attr("id");
        n("a[href='#" + t + "']").addClass("active");
      }
    }),
    feather.replace(),
    n(".navigation-menu a").each(function () {
      var a = window.location.href.split(/[?#]/)[0];
      this.href == a &&
        (n(this).parent().addClass("active"),
        n(this).parent().parent().parent().addClass("active"),
        n(this)
          .parent()
          .parent()
          .parent()
          .parent()
          .parent()
          .addClass("active"));
    }),
    n(".navbar-toggle").on("click", function (a) {
      n(this).toggleClass("open"), n("#navigation").slideToggle(400);
    }),
    n(".navigation-menu>li").slice(-2).addClass("last-elements"),
    n('.navigation-menu li.has-submenu a[href="#"]').on("click", function (a) {
      n(window).width() < 992 &&
        (a.preventDefault(),
        n(this)
          .parent("li")
          .toggleClass("open")
          .find(".submenu:first")
          .toggleClass("open"));
    }),
    Waves.init();
})(jQuery);
$(function() {
  $('input[name="birthday"]').daterangepicker({
      singleDatePicker: true,
      showDropdowns: true,
      minYear: 1901,
      maxYear: parseInt(moment().format('YYYY'), 10)
  });
});