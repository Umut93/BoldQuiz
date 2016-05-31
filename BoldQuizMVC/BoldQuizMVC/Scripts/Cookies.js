//Cheked buttons must apperear when the user has cheked them already. Formatting to objects.
//$ -> jQuery --> attr. checked buttons!

var gettingcokie = getCookie("SelectedAnswers");
var answerArray = gettingcokie.split(","); 

for (var i = 0; i < answerArray.length; i++)
{
    var item = answerArray[i];
    var textAnswer = "#Answer-" + item;
    $(textAnswer).attr("Checked", true);
   
}

// The selector selects the id of the selected possible answers and then populating them in the array. Cookie name = SelectedAnswers, value = array, expire 10 days

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
//Setting a cookie by its name, value and expiredays. The values are the values in the array which is selected possible answers (ID)! The path is localhost
function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (10 * 24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = cname + "=" + cvalue + "; " + expires + "; path=/";
}
//Get cookie http://www.w3schools.com/js/js_cookies.asp
// Return the value of specified cookie.
//51 if cookies is found otherwise return "".
//charat takes a specific character from a string.
//substring takes character from a string in specific string.
//indexOF?
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
