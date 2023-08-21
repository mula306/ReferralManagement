// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
let menu = document.querySelector('.menu')
let sidebar = document.querySelector('.sidebar')
let mainContent = document.querySelector('.main--content')

menu.onclick = function () {
    sidebar.classList.toggle('active')
    mainContent.classList.toggle('active')
}

//const surveyJson = {
//    elements: [{
//        name: "FirstName",
//        title: "Enter your first name:",
//        type: "text",
//        isRequired: "true",
//        requiredErrorText: "Value cannot be empty"
//    }, {
//        name: "LastName",
//        title: "Enter your last name:",
//        type: "text"
//    }]
//};

//const survey = new Survey.Model(surveyJson);
//survey.focusFirstQuestionAutomatic = false;

//function alertResults(sender) {
//    const results = JSON.stringify(sender.data);
//    alert(results);
//}

//survey.onComplete.add(alertResults);

//$(function () {
//    $("#surveyContainer").Survey({ model: survey });
//});