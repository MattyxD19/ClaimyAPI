function retrieveNewUser() {
    var newUser = new XMLHttpRequest();
    var allText = "User not found"
    newUser.onreadystatechange = function () {
        if (txtFile.readyState === XMLHttpRequest.DONE && txtFile.status == 200) {
            allText = txtFile.responseText; 
        }
    }
    newUser.open("GET")
}



var txtFile = new XMLHttpRequest();
var allText = "file not found";
txtFile.onreadystatechange = function () {
    if (txtFile.readyState === XMLHttpRequest.DONE && txtFile.status == 200) {
        allText = txtFile.responseText;
        allText = allText.split("\n").join("<br>");
    }

    document.getElementById('txt').innerHTML = allText;
}
txtFile.open("GET", '/Resources/ClaimyText.txt', true);
txtFile.send(null);
