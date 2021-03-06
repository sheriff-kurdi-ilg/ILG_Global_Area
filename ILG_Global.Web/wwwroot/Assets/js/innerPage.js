

function addBgToNavWhenScroll() {
    var scroll_pos = 0;
    scroll_pos = $(this).scrollTop();
    if (scroll_pos > 10) {
        $("header").addClass('sticky-nav');
    } else {
        $("header").removeClass('sticky-nav');
    }

}

function isInViewport(element) {
    var elementTop = element.offset().top;
    var elementBottom = elementTop + element.outerHeight();

    var viewportTop = $(window).scrollTop();
    var viewportBottom = viewportTop + $(window).height();

    return elementBottom > viewportTop && elementTop < viewportBottom;
}

$(document).on("click", "#share-via-mail", function () {
    /*
            $(".modal").removeClass("fade").modal("hide");
    */
    $('.btn-close').trigger('click')
    $('.shareViaMailModal-launch-btn').trigger('click')
});

$(document).ready(function () {

    $(".arrow-top").click(function () {
        $([document.documentElement, document.body]).animate({
            scrollTop: $("header").offset().top
        }, 100);
    });
    if (isInViewport($('footer'))) {
        //$('header').addClass('d-none');
        $('.contact-details').addClass('d-none');
    } else {
        //$('header').removeClass('d-none');
        $('.contact-details').removeClass('d-none');
    }


    $(document).scroll(function () {
        if (isInViewport($('footer'))) {
            $('header').addClass('d-none');
            $('.contact-details').addClass('d-none');
        } else {
            $('header').removeClass('d-none');
            $('.contact-details').removeClass('d-none');
        }
    });



    if($('.navbar-toggler').css('display') !== 'none'){
        $(document).on("click", ".nav-link", function () {
            setTimeout(function (){
                $('.navbar-toggler').trigger('click');

            },500)
        });
    }

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


//// data-successStoryItem
//$("[data-successStoryItem]").mouseenter(function () {
//    $(this).insertBefore(".overlay.w-100.h-100.position-absolute");
//    console.log("enter");
//});

//$("[data-successStoryItem]").mouseleave(function () {
//    //$(this).prev().remove();
//    console.log("leave");
//});
let langAr = false;
if (window.location.href.indexOf("ar") > -1) {
    langAr = true
}else{
    langAr = false
}

$(document).ready(function(){
    $("#our-service-slider").owlCarousel({
        rtl: langAr,
        autoplay: true,
        autoPlaySpeed: 5000,
        autoPlayTimeout: 500,
        stopOnHover : true,
        speed: 2,
        loop: true,
        margin: 20,
        items: 1,
        autoplayHoverPause:true,

    });

});



$(document).ready(function () {

    if (isInViewport($('footer'))) {
        $('.new-call-action').addClass('d-none');
    } else {
        $('.new-call-action').removeClass('d-none');
    }

    let player = document.querySelector("lottie-player");
    let play = document.querySelector("#steps-lottie-item");

    if(langAr){
        player.load(
            '/Assets/js/lottie-ar.json'
        );
    }else {
        player.load(
            '/Assets/js/lottie.json'
        );
    }


    if (isInViewport($('#steps-lottie-item'))) {
        player.play();
    } else {
        player.stop();
    }

    $(document).scroll(function () {

        if (isInViewport($('footer'))) {
            $('.new-call-action').addClass('d-none');
        } else {
            $('.new-call-action').removeClass('d-none');
        }
        if (isInViewport($('#steps-lottie-item'))) {
            player.play();
        } else {
            player.stop();
        }
    });

});
