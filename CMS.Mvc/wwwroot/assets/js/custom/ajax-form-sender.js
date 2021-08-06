$('#ajaxFormSender').on('submit', function (e) {
    e.preventDefault();
    let url = $(this).attr('data-url');
    let serializedData = $(this).serialize();
    $.post(url, serializedData).done(function (data) {
        //alert(data)
        let returnedData = JSON.parse(data);
        console.log(returnedData);
        let statusCode = returnedData.StatusCode;
        if (statusCode == 201) location.reload();
        if (statusCode == 400) {
            let newContent = $(returnedData.PartialView)
            $('#ajaxFormSender').parent().html(newContent.find('#ajaxFormSender').parent().html())
        }
    })
});