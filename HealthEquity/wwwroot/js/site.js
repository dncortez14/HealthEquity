var hiddenClass = "visually-hidden";
var carId = $('#Car_CarId').val();
var guessModal = $('#guessModal');
var txtPrice = $('#txtPrice');
var btnGuess = $('#btnGuess');
var successMsg = $("#successMsg");
var errorMsg = $("#errorMsg");

guessModal.on('shown.bs.modal', function () {
    txtPrice.focus();
})

guessModal.on('hide.bs.modal', function () {
    txtPrice.val('');
    successMsg.addClass(hiddenClass);
    errorMsg.addClass(hiddenClass);
    btnGuess.removeClass(hiddenClass);
})

btnGuess.on('click', function () {
    var value = txtPrice.val();

    if (value != "") {
        guessPrice(value);
    } else {
        alert("insert a value");
    }
})

function guessPrice(value) {
    $.ajax({
        url: "/api/riddle",
        type: 'POST',
        data: JSON.stringify({ id: carId, price: value }),
        dataType: 'json',
        contentType: "application/json; charset=utf-8",
        success: function success(data) {
            btnGuess.addClass(hiddenClass);
            if (data === true) {
                successMsg.removeClass(hiddenClass);
            } else {
                errorMsg.removeClass(hiddenClass);
            }
        },
        error: function () {
            alert('something went wrong, try again');
        }
    });
}