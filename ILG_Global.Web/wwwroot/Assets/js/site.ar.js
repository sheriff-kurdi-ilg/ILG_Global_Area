
console.log(" en loaded");


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
    const {scrollTop, scrollHeight, clientHeight} = document.documentElement;

    if (clientHeight + scrollTop >= scrollHeight - 5) {
        return true;
    }
    return false;
}

$(document).ready(function () {
    if ($('body').children().has('.home')) {
        addBgToNavWhenScroll()
    }
    if (isInViewport($('footer'))) {
        $('header').addClass('d-none');
        $('.quick-contact-main-container').addClass('d-none');
    } else {
        $('header').removeClass('d-none');
        $('.quick-contact-main-container').removeClass('d-none');
    }


    $(document).scroll(function () {

        if ($('body').children().has('.home')) {
            addBgToNavWhenScroll()
        }
        if (isInViewport($('footer'))) {
            $('header').addClass('d-none');
            $('.quick-contact-main-container').addClass('d-none');
        } else {
            $('header').removeClass('d-none');
            $('.quick-contact-main-container').removeClass('d-none');
        }
    });
    $(document).on("click", "#share-via-mail", function () {
        /*
                $(".modal").removeClass("fade").modal("hide");
        */
        $('.btn-close').trigger('click')
        $('.shareViaMailModal-launch-btn').trigger('click')
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
    loop: true,
    rtl: true,
    autoplay: true,
    autoPlaySpeed: 1000,
    autoPlayTimeout: 100,
    stopOnHover : true,
    margin: 20,
    nav: true,
    navText: ["<i class=\"fas fa-arrow-left px-5\"></i>", " <i class=\"fas fa-arrow-right px-5\"></i>"],
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
    rtl:true,
    loop: true,
    autoplay: true,
    autoPlaySpeed: 1000,
    autoPlayTimeout: 200,
    stopOnHover : true,
    margin: 20,
    items: 1,
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


//// data-successStoryItem
//$("[data-successStoryItem]").mouseenter(function () {
//    $(this).insertBefore(".overlay.w-100.h-100.position-absolute");
//    console.log("enter");
//});

//$("[data-successStoryItem]").mouseleave(function () {
//    //$(this).prev().remove();
//    console.log("leave");
//});

