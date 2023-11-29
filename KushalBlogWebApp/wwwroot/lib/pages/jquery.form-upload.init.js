$(function () {
  $(".dropify").dropify(),
    $(".dropify-fr").dropify({
      messages: {
        default: "Glissez-déposez un fichier ici ou cliquez",
        replace: "Glissez-déposez un fichier ou cliquez pour remplacer",
        remove: "Supprimer",
        error: "Désolé, le fichier trop volumineux",
      },
    });
  var e = $("#input-file-events").dropify();
  e.on("dropify.beforeClear", function (e, r) {
    return confirm('Do you really want to delete "' + r.file.name + '" ?');
  }),
    e.on("dropify.afterClear", function (e, r) {
      alert("File deleted");
    }),
    e.on("dropify.errors", function (e, r) {
      console.log("Has Errors");
    });
  var r = $("#input-file-to-destroy").dropify();
  (r = r.data("dropify")),
    $("#toggleDropify").on("click", function (e) {
      e.preventDefault(), r.isDropified() ? r.destroy() : r.init();
    });
});
