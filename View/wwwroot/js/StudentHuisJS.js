﻿
var ShowGebruikersHuis = function (event) {
    event.preventDefault(); // Blocks following of hyperlink

    var targetElement = $('#HuisDetail');
    targetElement.html('Loading...');

    var element = $(event.currentTarget);
    var url = element.attr('href');

    $.get(url).done(function (view) {
        targetElement.html(view);
    });
}

var HideReserveringsForm = function (event) {
    $('#ShowRequestForm').empty();
}

