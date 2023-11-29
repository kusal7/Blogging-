ShowPopUp = (Url, title = '', aclass = null) => {
  
    var decodeurl = decodeURIComponent(Url);

    $.ajax({
        type: "GET",
        url: decodeurl,
        success: function (res) {
         
            aclass == null ? $("#add-new .modal-dialog").addClass("modal-lg") : $("#add-new .modal-dialog").removeClass().addClass(aclass);
            $("#add-new .modal-body").html(res);
            /*//$("#add-new .modal-body").append("<div id='modalloading'  class='loader'><center><span class='fa fa-spinner fa-spin fa-3x'></span></center></div >");*/
            $("#add-new .modal-title").html(title);
            $("#add-new").modal({ backdrop: 'static', keyboard: false });
            $("#add-new").modal('show');
        }, error: function (err) {
            console.log(err, "error");
            //new PNotify({
            //    // title: 'Success ',
            //    text: 'Internal Server Error',
            //    type: 'Error',

            //    animation: {
            //        effect_in: 'fade',
            //        effect_out: 'slide'
            //    }

            //});
        }

    })

}

PopUp = (Url, title = '', aclass = null) => {
    var decodeurl = decodeURIComponent(Url);
    $.ajax({
        type: "GET",
        url: decodeurl,
        success: function (res) {
            aclass == null ? $("#adminteam .modal-dialog").addClass("modal-lg") : $("#adminteam .modal-dialog").removeClass().addClass(aclass);
            $("#adminteam .modal-body").html(res);
            /*//$("#add-new .modal-body").append("<div id='modalloading'  class='loader'><center><span class='fa fa-spinner fa-spin fa-3x'></span></center></div >");*/
            $("#adminteam .modal-title").html(title);
            $("#adminteam").modal({ backdrop: 'static', keyboard: false });
            $("#adminteam").modal('show');
        }, error: function (err) {
            console.log(err, "error");
            //new PNotify({
            //    // title: 'Success ',
            //    text: 'Internal Server Error',
            //    type: 'Error',

            //    animation: {
            //        effect_in: 'fade',
            //        effect_out: 'slide'
            //    }

            //});
        }

    })

}


function readURL(input, id) {

    if (input.files && input.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {

            var data = e.target.result;

            $('#' + id).attr('src', e.target.result);

        }
        reader.readAsDataURL(input.files[0]);
    }
};
function isNumber(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 46 || charCode > 57 || charCode == 47)) {
        return false;
    }

    return true;
}

$('input[type="number"]').click(function () {
    if (this.value < 0) {
        this.value = 0;
    }
});


function isPhoneNumber(evt) {
    var theEvent = evt || window.event;

    // Handle paste
    if (theEvent.type === 'paste') {
        key = event.clipboardData.getData('text/plain');
    } else {
        // Handle key press
        var key = theEvent.keyCode || theEvent.which;
        key = String.fromCharCode(key);
    }
    var regex = /[0-9]|\./;
    if (!regex.test(key)) {
        theEvent.returnValue = false;
        if (theEvent.preventDefault) theEvent.preventDefault();
    }
}
function lettersOnly(evt) {
    evt = (evt) ? evt : event;
    var charCode = (evt.charCode) ? evt.charCode : ((evt.keyCode) ? evt.keyCode :
        ((evt.which) ? evt.which : 0));
    if (charCode > 32 && (charCode < 65 || charCode > 90) &&
        (charCode < 97 || charCode > 122)) {
        return false;
    }
    return true;
}

function containsOnlySpecialCharacters(event) {

    // Define a regular expression to match only "-" "/", and "\" characters
    const regex = /^[\/\-\\\.]+$/;

    // Test if the input matches the regex, and return false if it does not
    if (!regex.test(event.key)) {
        return false;
    }

    // If the input matches the regex, return true
    return true;
}



function onimagechange(data, id) {
    debugger;
    var isValid = validateImageFile(data, id);
    if (isValid) {
        $('#' + id).removeAttr('hidden');
        readURL(data, id);
    }
}

function onimagechangefornotification(data, id) {
    debugger;
    var isValid = validateImageFileForNotification(data, id);
    if (isValid) {
        $('#' + id).removeAttr('hidden');
        readURL(data, id);
    }
}

function validateImageFile(fileInput, id) {
    var file = fileInput.files[0];
    debugger;
    if (file) {
        var allowedExtensions = ["jpg", "jpeg", "png", "svg", "gif", "bmp"];
        var fileExtension = file.name.split(".").pop().toLowerCase();

        if (!allowedExtensions.includes(fileExtension)) {
            fileInput.value = ""; // Clear the file input
            $(id + "0").html("Invalid image format. Only JPEG, PNG, SVG, GIF, and BMP formats are allowed.");

            alert("Invalid image format. Only JPEG, PNG, SVG, GIF, and BMP formats are allowed.");
            return false;
        }
        // Check file size
        var fileSize = file.size / 1024; // Size in KB
        var maxFileSize = 2000; // Maximum file size in KB

        if (fileSize > maxFileSize) {
            fileInput.value = ""; // Clear the file input
            $(id + "0").html("File size exceeds the maximum limit of 2000 KB.");

            alert("File size exceeds the maximum limit of 2000 KB.");
            return false;
        }
    }
    return true;
}
function validateImageFileForNotification(fileInput, id) {
    var file = fileInput.files[0];
    debugger;
    if (file) {
        var allowedExtensions = ["jpg", "jpeg", "png", "svg", "gif", "bmp"];
        var fileExtension = file.name.split(".").pop().toLowerCase();

        if (!allowedExtensions.includes(fileExtension)) {
            fileInput.value = ""; // Clear the file input
            $(id + "0").html("Invalid image format. Only JPEG, PNG, SVG, GIF, and BMP formats are allowed.");

            alert("Invalid image format. Only JPEG, PNG, SVG, GIF, and BMP formats are allowed.");
            return false;
        }
        var fileSize = file.size / 1024; // Size in KB
        var maxFileSize = 280; // Maximum file size in KB (changed from 2000)

        if (fileSize > maxFileSize) {
            fileInput.value = ""; // Clear the file input
            $(id + "0").html("File size exceeds the maximum limit of 280 KB.");

            alert("File size exceeds the maximum limit of 280 KB.");
            return false;
        }

    }
    return true;
}

//open image in new tab

$(document).ready(function () {
    $('.open-image').click(function () {
        var imageUrl = $(this).attr('src');
        window.open(imageUrl, '_blank');
    });
});

//script for calculating values in contest

//$(document).ready(function () {

//    // Get the input fields and result element
//    var amountElement = $('#amount');
//    var contestSizeInput = $('#contestSize');
//    var entryFeeInput = $('#entryFee');
//    var marginInput = $('#margin')

//    var totalWinningAmountElement = $('#totalWinningAmount')
//    if (entryFee <= 1) {
//        alert("Entry Fee must be greater than 1");
//        return false
//    }

//    function calculateTotalAmount() {

//        var entryFee = parseFloat(entryFeeInput.val()) || 0;
//        var contestSize = parseFloat(contestSizeInput.val()) || 0;
//        var margin = parseFloat(marginInput.val()) || 0;


//        var amount = entryFee * contestSize;
//        amountElement.val(amount);


//        var calculateMargin = (amount * margin) / 100;
//        var calculateTotalWinningAmount = amount - calculateMargin;
//        totalWinningAmountElement.val(calculateTotalWinningAmount);
//    }
//    entryFeeInput.on('change', calculateTotalAmount);
//    contestSizeInput.on('change', calculateTotalAmount);
//    marginInput.on('change', calculateTotalAmount);

//});

//start date should be lesser than end date
//var startDateInput = document.getElementById("startDate");
//var endDateInput = document.getElementById("endDate");

//startDateInput.addEventListener("change", function () {
//    validateDates();
//});

//endDateInput.addEventListener("change", function () {
//    validateDates();
//});

//function validateDates() {
//    var startDate = new Date(startDateInput.value);
//    var endDate = new Date(endDateInput.value);

//    if (isNaN(startDate) || isNaN(endDate)) {
//        return;
//    }

//    if (startDate > endDate) {
//        alert("Start date cannot be greater than end date.");
//        startDateInput.value = null;
//        endDateInput.value = null;
//    }
//}
function validateDates() {
    var startDate = new Date(startDateInput.value);
    var endDate = new Date(endDateInput.value);

    if (isNaN(startDate) || isNaN(endDate)) {
        return;
    }

    if (startDate > endDate) {
        alert("Start date cannot be greater than end date.");
        startDateInput.value = null;
        endDateInput.value = null;
    }
}


//toggle eye button for password and confirm password

function toggleConfirmPasswordVisibility() {
    var passwordInput = document.getElementById("confirmPassword");
    var eyeIcon = document.getElementById("confirmEyeIcon");

    if (passwordInput.type === "password") {
        passwordInput.type = "text";
        eyeIcon.classList.remove("la-eye");
        eyeIcon.classList.add("la-eye-slash");
    } else {
        passwordInput.type = "password";
        eyeIcon.classList.remove("la-eye-slash");
        eyeIcon.classList.add("la-eye");
    }
}
function togglePasswordVisibility() {
    var passwordInput = document.getElementById("password");
    var eyeIcon = document.getElementById("passwordEyeIcon");

    if (passwordInput.type === "password") {
        passwordInput.type = "text";
        eyeIcon.classList.remove("la-eye");
        eyeIcon.classList.add("la-eye-slash");
    } else {
        passwordInput.type = "password";
        eyeIcon.classList.remove("la-eye-slash");
        eyeIcon.classList.add("la-eye");
    }
}
function toggleEmployeePinVisibility() {
    var pinInput = document.getElementById("adminPin");
    var eyeIcon = document.getElementById("pinEyeIcon");

    if (pinInput.type === "password") {
        pinInput.type = "text";
        eyeIcon.classList.remove("la-eye");
        eyeIcon.classList.add("la-eye-slash");
    } else {
        pinInput.type = "password";
        eyeIcon.classList.remove("la-eye-slash");
        eyeIcon.classList.add("la-eye");
    }
}


function GetDistrictByProvince() {
    var ProvinceId = $("#province").val();
    var url = "/AdminUser/GetDistrictByProvinceId" + '?' + "ProvinceId=" + ProvinceId;
    var decodeurl = decodeURIComponent(url);
    debugger;
    $.ajax({
        type: "GET",
        url: decodeurl,
        //data: GameTypeId,
        success: function (res) {
            var items = '<option value=" ">-- Select District --</option > ';
            $.each(res, function (i, District) {
                items += "<option value='" + District.value + "'>" + District.text + "</option>";

            });

            var muniItems = '<option value=" ">-- Select Municipality --</option > ';

            $("#district").html(items);
            $("#municipality").html(muniItems);

        }
    })
}
function GetMunicipalityByDistrictId() {
    var DistrictId = $("#district").val();
    var url = "/AdminUser/GetMunicipalityByDistrict" + '?' + "DistrictId=" + DistrictId;
    var decodeurl = decodeURIComponent(url);
    $.ajax({
        type: "GET",
        url: decodeurl,
        //data: GameTypeId,
        success: function (res) {
            var items = '<option value=" ">-- Select Municipality --</option > ';
            $.each(res, function (i, Municipality) {
                items += "<option value='" + Municipality.value + "'>" + Municipality.text + "</option>";

            });

            $("#municipality").html(items);

        }
    })
}




