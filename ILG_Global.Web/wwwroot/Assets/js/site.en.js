
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
    // e.preventDefault();
    // var x = $("#frmShareViaEmail").validate();
    // console.log('x',x);
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



$("#frmShareViaEmail").submit(function(e){

    vPreventFormSubmition(e);

    var oApiRequest = oSuccessStoryShareViaEmailRequestCreate();

    if (isEmail(oApiRequest.SuccessStoryEmail)) {
        vRemoveErrorCssClassesFromTextField(this);
        vCallSuccessStoryShareViaEmailAPI(oApiRequest);
    }
    else{
        vAddErrorCssClassesToTextField(this);
        vPreventFormSubmition(e);
    }

});

function vPreventFormSubmition(oFormEventArg) {
    oFormEventArg.preventDefault();
    oFormEventArg.stopPropagation();
}

function oSuccessStoryShareViaEmailRequestCreate() {

    let nSuccessStoryID = $("#txtLastClickedSuccessStoryID").val();
    let sLanguageCode = $("#txtCurrentLanguageCode").val();
    let sSuccessStoryEmail = $("#SuccessStoryUserEmail").val();

    let oApiRequest = { "SuccessStoryID": nSuccessStoryID, "LanguauageCode": sLanguageCode, "SuccessStoryEmail": sSuccessStoryEmail };

    oApiRequest = JSON.stringify(oApiRequest);

    return oApiRequest;
}

function isEmail(email) {
    let regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    return regex.test(email);
}

function vRemoveErrorCssClassesFromTextField(oFormToValidate) {
    $(".invalid-feedback").removeClass("error");
    $(oFormToValidate).removeClass('was-validated');
    $("#SuccessStoryUserEmail").removeClass("error-text");
}

function vAddErrorCssClassesToTextField(oFormToValidate) {
    $(oFormToValidate).addClass('was-validated');
    $(".invalid-feedback").html("Email Invalid");
    $(".invalid-feedback").addClass("error");
    $("#SuccessStoryUserEmail").addClass("error-text");
}




let oSuccessStoryShareViaEmailResponse; //  = { "SubscriptionID": 0, "IsSucceeded": false, "UserMessage": "" };
function vCallSuccessStoryShareViaEmailAPI(oApiRequest) { // languageID
    let sUrl = "/api/SuccessStoryShareViaEmail";

    console.log('before send to api:', oApiRequest);
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json",
        url: sUrl,
        async: true,
        data: oApiRequest,

        success: function (xmlResponse) {
            oSuccessStoryShareViaEmailResponse = JSON.parse(JSON.stringify(xmlResponse) );
            if (xmlResponse.isSucceeded){
                $('.btn-close').trigger('click');
                $('#dvApiResultMessage').html(oSuccessStoryShareViaEmailResponse.userMessage);
                $('.shareViaMailModalGreeting-launch-btn').trigger('click');
                $("#SuccessStoryUserEmail").val('')
            }
        },

        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log('error is: ', XMLHttpRequest)
        },
    });
}

$(document).on("click", "#btnUserMessage", function () {
    $('.btn-close').trigger('click');
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
    autoplay: true,
    autoPlaySpeed: 1000,
    autoPlayTimeout: 100,
    margin: 20,
    nav: true,
    navText: ["<i class=\"fas fa-arrow-left px-5\"></i>", " <i class=\"fas fa-arrow-right px-5\"></i>"],
    dots: false,
    responsive: {
        0: {
            items: 1,
            nav: true,
            loop:true,
        },
        991: {
            items: 3,
            nav: false,
            loop:true,
        },
        1366: {
            items: 5,
            nav: true,
            loop: true,
        },
        3500: {
            items: 8,
            nav: true,
            loop:true,
        }
    }

})
$('#our-service-slider').owlCarousel({
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

