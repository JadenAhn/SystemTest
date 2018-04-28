/* global.js
* Assignment 4
*
*   Revision History
*       Jaden Ahn, 2018.04.06 : Created
*/
function btnClearDatabase_click() {
    clearDatabase();
}

function btnRegister_click() {
    registerCar();
}

function pgSearch_show() {
    searchCars();
}

function init() {
    $("#btnRegister").on("click", btnRegister_click);
    $("#btnClearDatabase").on("click", btnClearDatabase_click);
    $("#pgSearch").on("pageshow", pgSearch_show);
    localStorage.setItem("maxId", "0");
}

$(document).ready(function () {
    init();
});