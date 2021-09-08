function MyFunction() {
    var checkbox1 = document.getElementById("check1");
    var checkbox2 = document.getElementById("check2");
    var checkbox3 = document.getElementById("check3");
    var checkbox4 = document.getElementById("check4");
    var checkbox5 = document.getElementById("check5"); // check everybox indiviually  
    var checkbox6 = document.getElementById("check6");
    var checkbox7 = document.getElementById("check7");
    var checkbox8 = document.getElementById("check8"); // if checked open formulier page else box needs to be check
    var checkbox9 = document.getElementById("check9");
    var checkbox10 = document.getElementById("check10");
    var checkbox11 = document.getElementById("check11");
    var checkbox12 = document.getElementById("check12");

    if (checkbox1.checked || checkbox2.checked || checkbox3.checked || checkbox4.checked || checkbox5.checked || checkbox6.checked || checkbox7.checked || checkbox8.checked || checkbox9.checked || checkbox10.checked || checkbox11.checked || checkbox12.checked) {

        window.location.href = "formulier.html";
    }
    else {
        alert("Kies een fiets a.u.b!");
    }

}
function myClick() {
    alert("We hebben uw informatie ontvangen !!! En we nemen spoedig contact met u op. Bedankt voor het winkelen bij Fluitende Fietser");
}

function myFunct() {
    var zoeken = document.getElementById("zoeken");
    document.getElementById("zoeken").style.display = "block";

}

var myIndex = 0;
carousel();

function carousel() {
    var i;
    var x = document.getElementsByClassName("mySlides");
    for (i = 0; i < x.length; i++) {
        x[i].style.display = "none";
    }
    myIndex++;
    if (myIndex > x.length) { myIndex = 1 }
    x[myIndex - 1].style.display = "block";
    setTimeout(carousel, 2500);
}


var timer;

function setTime() {
    var objDate = new Date();// get exact date of today ""
    var Hours = objDate.getHours() * 100 + objDate.getMinutes(); /// get exact hour  * 100  + exact minutes
    var day;
    switch (new Date().getDay()) {
        case 0://Sunday
            display.innerHTML = "We zijn vandaag gesloten en gaan maandag weer openen om 12:30pm";
            display.style.color = "red"; // if date is sunday it display it in id="display "
            display.fontSize = "33px";
            break;
        case 1: //Monday
            if (Hours >= 1230 && Hours <= 1800) { // date is monday between 1230 and 1800 display open elase it display closed
                display.innerHTML = "We zijn vandaag open van 12:30 - 18:00";
                display.style.color = "green";
                display.style.fontSize = "1em";
            }
            else {
                display.innerHTML = "We zijn nu gesloten en gaan morgen weer openen";
                display.style.color = "red";
                display.style.fontSize = "33px";
            }
            break;
        case 2://Tuesday
        case 3://Wednesday
        case 4://Thursday
            if (Hours >= 830 && Hours <= 1800) { /// check hours like army hour 
                display.innerHTML = "We zijn vandaag open van 08:30 - 18:00";
                display.style.color = "green";
                display.style.fontSize = "1em";
            }
            else {
                display.innerHTML = "We zijn nu gesloten en gaan morgen weer openen";
                display.style.color = "red";
                display.style.fontSize = "33px";
            }
            break;
        case 5://Friday
            if (Hours >= 830 && Hours <= 1930) {
                display.innerHTML = "We zijn vandaag open van 08:30 - 19:30";
                display.style.fontSize = "1em";
                display.style.color = "green";
            }
            else {
                display.innerHTML = "We zijn nu gesloten en gaan morgen weer openen";
                display.style.color = "red";
                display.style.fontSize = "33px";
            }
            break;
        case 6://Saturday
            if (Hours >= 900 && Hours <= 1700) {
                display.innerHTML = "We zijn vandaag open van 09:00 - 17:00";
                display.style.fontSize = "1em";
                display.style.color = "green";
            }
            else {
                display.innerHTML = "We zijn nu gesloten en gaan morgen weer openen";
                display.style.color = "red";
                display.style.fontSize = "33px";
            }
            break;
        default:
            alert("Er is iets die mis gaat");
            break;
    }

}
setTime();



