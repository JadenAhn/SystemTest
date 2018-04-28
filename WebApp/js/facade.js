/* facade.js
* Assignment 4
*
*   Revision History
*       Jaden Ahn, 2018.04.06 : Created
*/
function registerCar() {
    if (doValidate_frmRegister()) {
        var maxId = localStorage.getItem("maxId");
        var myCar = new Array();
        myCar[0] = $("#txtName").val();
        myCar[1] = $("#txtAddress").val();
        myCar[2] = $("#txtCity").val();
        myCar[3] = $("#txtPhone").val();
        myCar[4] = $("#txtEmail").val();
        myCar[5] = $("#txtMake").val();
        myCar[6] = $("#txtModel").val();
        myCar[7] = $("#txtYear").val();

        localStorage[maxId] = JSON.stringify(myCar);
        localStorage.setItem("maxId", (parseInt(localStorage.getItem("maxId")) + 1).toString());
        $("#frmRegister")[0].reset();

        $.mobile.changePage("#pgRegisteredInfo", {transition: 'none'});
        showRegisteredInfo();
    }
    else {
        console.error("Validation failed");
    }
}

function clearDatabase() {
    var result = confirm("Really want to clear database?")
    if (result) {
        localStorage.clear();
        localStorage.setItem('maxId', "0");

    }
}

function searchCars() {
    var htmlcode = "";
    var maxId = parseInt(localStorage.getItem("maxId"));
    for (var i = 0; i < maxId; i++) {
        var carInfo = JSON.parse(localStorage.getItem(i));
        var link = "http://www.jdpower.com/cars/" + carInfo[5] + "/" + carInfo[6] + "/" + carInfo[7];
        htmlcode += "<li>" +
            "<a href='" + link + "'>" + "<h1>Seller Name: " + carInfo[0] + "</h1>" +
            "<p>Address: " + carInfo[1] + "</p>" +
            "<p>City: " + carInfo[2] + "</p>" +
            "<p>Phone: " + carInfo[3] + "</p>" +
            "<p>Email: " + carInfo[4] + "</p>" +
            "<span>Make: " + carInfo[5] + "| Model: " + carInfo[6] + " | Year: " + carInfo[7] + "</span>" +
            "</a></li>";
        }
    var lv = $("#searchResult");
    lv = lv.html(htmlcode);
    lv.listview("refresh");
}

function showRegisteredInfo() {
    var htmlcode = "";
    var maxId = (parseInt(localStorage.getItem("maxId")) - 1).toString();
    var carInfo = JSON.parse(localStorage.getItem(maxId));

    var link = "http://www.jdpower.com/cars/" + carInfo[5] + "/" + carInfo[6] + "/" + carInfo[7];
    htmlcode += "<li>" +
        "<a href='" + link + "' id='linkToJDC'>" + "<h1>Seller Name: " + carInfo[0] + "</h1>" +
        "<p>Address: " + carInfo[1] + "</p>" +
        "<p>City: " + carInfo[2] + "</p>" +
        "<p>Phone: " + carInfo[3] + "</p>" +
        "<p>Email: " + carInfo[4] + "</p>" +
        "<span>Make: " + carInfo[5] + "| Model: " + carInfo[6] + " | Year: " + carInfo[7] + "</span>" +
        "</a></li>";

    var lv = $("#registerResult");
    lv = lv.html(htmlcode);
    lv.listview("refresh");
}