$(".ajax-content").each(function (index, element) {
    $(element).on("click", function () {
        let url = $(element).attr("ac-url");
        let target = $(element).attr("ac-target");
        $.ajax({
            url: url,
            method: "GET",
            success(data) {
                $(target).html(data)
            },
            error(err) {
                console.log(err);
            }
        });
    })
})

