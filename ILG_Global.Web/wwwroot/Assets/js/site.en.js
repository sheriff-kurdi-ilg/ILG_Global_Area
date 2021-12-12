
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

$("#frmShareViaEmail").submit(function (e) {
    e.preventDefault();
});

$(document).on("click", "[data-share-via-email-a]", function () {
    /*
            $(".modal").removeClass("fade").modal("hide");
    */
    $('.btn-close').trigger('click');
    $('.shareViaMailModal-launch-btn').trigger('click');

    var nSuccessStoryID = $(this).attr("data-success-story-id");
    $("#txtLastClickedSuccessStoryID").val(nSuccessStoryID);

    var nLanguageCode = $(this).attr("data-language-code");
    $("#txtCurrentLanguageCode").val(nLanguageCode);

});

$(document).on("click", "#btnSuccessStorySend", function () {

    var nSuccessStoryID = $("#txtLastClickedSuccessStoryID").val();
    var sLanguageCode = $("#txtCurrentLanguageCode").val();
    var sSuccessStoryEmail = $("#txtSuccessStoryUserEmail").val();

    console.log("nSuccessStoryID is: " + nSuccessStoryID);
    console.log("sLanguageCode is: " + sLanguageCode);
    console.log("sSuccessStoryEmail is: " + sSuccessStoryEmail);

    var oApiRequest = { "SuccessStoryID": nSuccessStoryID, "LanguauageCode": sLanguageCode, "SuccessStoryEmail": sSuccessStoryEmail };

    // alert(JSON.stringify(oApiRequest));
    oApiRequest = JSON.stringify(oApiRequest);
    vCallSuccessStoryShareViaEmailAPI(oApiRequest);

});

var oSuccessStoryShareViaEmailResponse; //  = { "SubscriptionID": 0, "IsSucceeded": false, "UserMessage": "" };
function vCallSuccessStoryShareViaEmailAPI(oApiRequest) { // languageID
    var sUrl = "/api/SuccessStoryShareViaEmail";

    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        url: sUrl,
        async: true,
        data: oApiRequest,
    
        success: function (xmlResponse) {
            oSuccessStoryShareViaEmailResponse = JSON.parse(JSON.stringify(xmlResponse) );
            console.log('returned response is: ', xmlResponse);

            $('.btn-close').trigger('click');

            $('#dvApiResultMessage').html(oSuccessStoryShareViaEmailResponse.userMessage);
    
            $('.shareViaMailModalGreeting-launch-btn').trigger('click');
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log('error is: ', errorThrown)
        },
    });
}

$(document).on("click", "#btnUserMessage", function () {
    $('.btn-close').trigger('click');
});




$(document).ready(function () {
    if ($('body').children().has('.home')) {
        addBgToNavWhenScroll()
    }
    if (isInViewport($('footer'))) {
        $('header').addClass('d-none');
        $('.contact-details').addClass('d-none');
    } else {
        $('header').removeClass('d-none');
        $('.contact-details').removeClass('d-none');
    }


    $(document).scroll(function () {

        if ($('body').children().has('.home')) {
            addBgToNavWhenScroll()
        }
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


$('#success-story-slider').owlCarousel({
    autoPlay: 3000,
    speed: 0.5,
    loop: true,
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


//// data-successStoryItem
//$("[data-successStoryItem]").mouseenter(function () {
//    $(this).insertBefore(".overlay.w-100.h-100.position-absolute");
//    console.log("enter");
//});

//$("[data-successStoryItem]").mouseleave(function () {
//    //$(this).prev().remove();
//    console.log("leave");
//});

