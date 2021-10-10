//Load Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
});

//Load Data function  
function loadData() {
    $.ajax({
        type: "GET",
        url: "/api/Positions",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.key + '</td>';
                html += '<td>' + item.value + '</td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },   //End of AJAX Success function

        failure: function (data) {
            alert(data.responseText);
        }, //End of AJAX failure function
        error: function (data) {
            alert(data.responseText);
        } //End of AJAX error function

    });
}

//Add Data Function   
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var movingRequest = {
        MaxPoints: [$('#MaxX').val(),
                    $('#MaxY').val()],
        Moves: $('#Moves').val(),
        X: $('#X').val(),
        Y: $('#Y').val(),
        Direction: Number($('#Direction').val())
    };
    $.ajax({
        url: "/api/Positions",
        data: JSON.stringify(movingRequest),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            //$('#myModal').modal('hide');
            $('#myModal').hide();
            $('.modal-backdrop').hide();

        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for clearing the textboxes  
function clearTextBox() {
    $('#MaxX').val("");
    $('#MaxY').val("");
    $('#Moves').val("");
    $('#X').val("");
    $('#Y').val("");
    $('#Direction').val("");
    $('#btnAdd').show();
    $('#MaxX').css('border-color', 'lightgrey');
    $('#MaxY').css('border-color', 'lightgrey');
    $('#Moves').css('border-color', 'lightgrey');
    $('#X').css('border-color', 'lightgrey');
    $('#Y').css('border-color', 'lightgrey');
    $('#Direction').css('border-color', 'lightgrey');
}

//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#MaxX').val().trim() == "") {
        $('#MaxX').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MaxX').css('border-color', 'lightgrey');
    }
    if ($('#MaxY').val().trim() == "") {
        $('#MaxY').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#MaxY').css('border-color', 'lightgrey');
    }
    if ($('#X').val().trim() == "") {
        $('#X').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#X').css('border-color', 'lightgrey');
    }
    if ($('#Y').val().trim() == "") {
        $('#Y').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Y').css('border-color', 'lightgrey');
    }

    if ($('#Moves').val().trim() == "") {
        $('#Moves').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Moves').css('border-color', 'lightgrey');
    }

    if ($('#Direction').val().trim() == "") {
        $('#Direction').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Direction').css('border-color', 'lightgrey');
    }
    return isValid;
}