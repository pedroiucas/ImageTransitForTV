let slideIndex = 1;
let tempo = document.getElementById("idTempoTransicao").value;
showDivs(slideIndex);
interval;

var interval = setInterval(function () {
    plusDivs(1);
}, tempo);

function plusDivs(n) {
    showDivs((slideIndex += n));
}

function showDivs(n) {
    let slides = document.getElementsByClassName('mySlides');

    if (n > slides.length) {
        slideIndex = 1;
    }

    if (n < 1) {
        slideIndex = slides.length;
    }

    for (let i = 0; i < slides.length; i++) {
        slides[i].style.display = 'none';
    }

    slides[slideIndex - 1].style.display = 'block';
}