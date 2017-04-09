
// Playing around
$(".mag-cover").click(function () {
    $(".mag-grid").removeClass("mag-grid--expandright");
    $(".blogitem--image").removeClass("blogitem--imageexpanded");
});
$(".blogitem--image").click(function () {
    $(".mag-grid").addClass("mag-grid--expandright");
    $('html, body').animate({
        scrollTop: $(this).offset().top - 50
    }, 300);
    $(".blogitem--image").addClass("blogitem--imageexpanded");
});

// Load Foundation
$(document).foundation();

// Mag Cover //////////////////////////

// OnClick for cover images
$(".cover-img").click(function () {
    // Activate image
    if (!$(this).hasClass("active")) {
        $(this).addClass("active");
        var foundActive = false;
        $(".cover-img").each(function () {
            if (foundActive) $(this).addClass("inactive-right");
            else if ($(this).hasClass("active")) foundActive = true;
            else $(this).addClass("inactive-left");
        });
        window.scrollTo(0, 0);
    }
    // Dectivate image
    else {
        $(".cover-img.active").removeClass("active");
        $(".cover-img.inactive-left").removeClass("inactive-left");
        $(".cover-img.inactive-right").removeClass("inactive-right");
    }
});

// Auto-size all textarea elements to content
autosize($('textarea'));
