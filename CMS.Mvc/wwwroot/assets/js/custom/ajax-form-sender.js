$('#ajaxFormSender').on('submit', function (e) {
    e.preventDefault();
    let url = $(this).attr('data-url');
    let data = {};
    new FormData($(this)[0]).forEach((val, key) => data[key] = val);
    console.log(data);
    fetch(
        url,
        {
            method: "POST",
            body: JSON.stringify(data),
            headers: {
                'Content-Type':'application/json'
            }
        }
    ).then(respoonse => respoonse.json()).then(response => {
        if (response.StatusCode < 300 && response.StatusCode >= 200) {

            for (var message of response.Messages) {
                toastr.success(message, "Başarılı")
            }
        }
        else {
            for (var message of response.Messages) {
                toastr.error(message,"Hata!")
            }
        }
    })
});