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
        $("#content").addClass("large-push-6");
    }
    // Dectivate image
    else {
        console.log("!");
        $(".cover-img.active").removeClass("active");
        $(".cover-img.inactive-left").removeClass("inactive-left");
        $(".cover-img.inactive-right").removeClass("inactive-right");
        $("#content").removeClass("large-push-6");
    }
});
