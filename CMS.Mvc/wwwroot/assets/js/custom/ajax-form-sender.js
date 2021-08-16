$('#ajaxFormSender').on('submit', function (e) {
    e.preventDefault();
    let url = $(this).attr('data-url');
    let serializedData = $(this).serialize();
    $.post(url, serializedData).done(function (data) {
        console.log(data);
        let returnedData = JSON.parse(data);
        let StatusCode = returnedData.StatusCode;
        if (StatusCode == 201) location.reload();
        if (StatusCode == 400) {
            let newContent = $(returnedData.PartialView)
            $('#ajaxFormSender').parent().html(newContent.find('#ajaxFormSender').parent().html())
        }
        
    })
});