
//Selecting all the checked buttons inclusive their ID's. It is stores in a array.
function handleSeleteced()
{
    var array = [];
    $(".button-answer:checked").each(function (i, e) {

        array.push($(e).val())

    })
    console.log(array);
    setCookie("SelectedAnswers", array, 10)
}

//http://www.w3schools.com/js/js_cookies.asp = 10 days

function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (10 * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + "; " + expires;
}
//Get cookie http://www.w3schools.com/js/js_cookies.asp
function getCookie(cname) {
    var name = cname + "=";
    var ca = document.cookie.split(';');
    for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}
