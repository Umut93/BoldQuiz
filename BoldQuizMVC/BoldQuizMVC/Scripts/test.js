$('ul > li').hide();
$('button').click(function () {
    $('ul > li:hidden:first').show();
});