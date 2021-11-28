
console.log(" en loaded");
$(document).ready(function () {

});


$(document).ready(function () {

    $(".quick-contact-container").mouseenter(function () {
        $(".wings").css('visibility', 'visible');
    });

    $(".quick-contact-container").mouseleave(function () {
        $(".wings").css('visibility', 'hidden');
    });
});


$(document).ready(function () {
    $(".arrow-bottom").click(function () {
        $([document.documentElement, document.body]).animate({
            scrollTop: $("footer").offset().top
        }, 100);
    });

    $(".arrow-top").click(function () {
        $([document.documentElement, document.body]).animate({
            scrollTop: $("header").offset().top
        }, 100);
    });

    $(".ourService").click(function () {
        $([document.documentElement, document.body]).animate({
            scrollTop: $(".our-service-section").offset().top
        }, 100);
    });
    $(".succesStories").click(function () {
        $([document.documentElement, document.body]).animate({
            scrollTop: $(".success-story-section").offset().top
        }, 100);
    });
    $(".contactUs").click(function () {
        $([document.documentElement, document.body]).animate({
            scrollTop: $(".contact-us-section").offset().top
        }, 100);
    });
})



$('#success-story-slider').owlCarousel({
    autoPlay: 3000,
    speed: 0.5,
    loop: true,
    margin: 20,
    nav: true,
    navText: ["<i class=\"fas fa-arrow-left\"></i>", " <i class=\"fas fa-arrow-right\"></i>"],
    dots: false,
    responsiveClass: true,
    responsive: {
        0: {
            items: 1,
            nav: true
        },
        991: {
            items: 3,
            nav: false
        },
        1400: {
            items: 5,
            nav: true,
            loop: false
        },
        3500: {
            items: 8
        }
    }

})
$('#our-service-slider').owlCarousel({
    autoPlay: 3000,
    speed: 0.5,
    loop: true,
    margin: 20,
    items: 1,
    rtl: false
})

$.noConflict();

$(document).ready(function () {
    let sizer = $('#sizer').find('div:visible').data('size');
    console.log(sizer);
    if (sizer == 'xs') {
        $('#floatCall').hide();
    } else {
        $('#floatCall').show();

    }
});


// to hide quick call icon once the popup opens 
$('.ilg-modal-popup-window').on('hidden.bs.modal', function (e) {
    $(".quick-contact").show(500);
});

$('.ilg-modal-popup-window').on('show.bs.modal', function (e) {
    $(".quick-contact").hide(500);
});