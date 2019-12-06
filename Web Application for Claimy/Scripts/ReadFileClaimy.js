function readFile() {
    jQuery.get('ClaimyText.txt', function (txt) {
        $('#output').text(txt);
    });
}