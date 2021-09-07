
function render(doc) {
    let containers = doc.getElementsByClassName("load-from-api");
    for (var container of containers) {
        let url = container.getAttribute("api-url");

        fetch(
            url,
            {
                method: "GET",
                accept: "application/json"
            }
        ).then(response => response.json())
            .then(function (response) {

                var template = container.getElementsByTagName("template")[0];
                var action = container.getElementsByTagName("action")[0];
                container.innerHTML = "";

                if (template != undefined) {
                    let write = ""
                    let html = template.innerHTML
                    for (var entry of response.Values) {
                        write += eval(`\`${html}\``)
                    }
                    container.innerHTML = write
                }
                if (action != undefined) {
                    console.log("action area")
                    container.innerHTML += eval(action.textContent)
                }
                console.log(action)

                render(container)

            });
    }
}

$(document).ready(function () {

    render(document)

});
