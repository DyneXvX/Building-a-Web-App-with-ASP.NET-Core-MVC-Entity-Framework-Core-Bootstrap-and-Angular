
$(document).ready(function() {                  //this handles the weird timing issues with javascript. load with the page is ready.
    var x = 0;
    var s = "";

    console.log("Hello");


    var theForm = $("#theForm"); //added jquery to this project. replaced document.getelementbyId with $
    theForm.hide();

    var button = $("#buyButton");
    button.on("click",
        function() {
            console.log("Buying Item");

        });


    var productInfo = $(".product-info li");
    productInfo.on("click",
        function() {
            console.log("You clicked on " + $(this).text());
        });

    $.re

    var $loginToggle = $("#loginToggle");
    var $popupForm = $(".popup-form");

    $loginToggle.on("click", function() {
        $popupForm.toggle(1000);
    });


});//end ready check