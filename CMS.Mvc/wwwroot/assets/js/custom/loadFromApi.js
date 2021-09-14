
function render(doc) {
    let containers = doc.getElementsByClassName("load-from-api");
    for (i = 0; i < containers.length; i++) {

        let container = containers[i]
        let template = container.getElementsByTagName("template")[0];
        let action = container.getElementsByTagName("action")[0];
        container.innerHTML = "loading...";

        let url = container.getAttribute("api-url");
        fetch(
            url,
            {
                method: "GET",
                accept: "application/json"
            }
        ).then(response => response.json())
            .then(function (response) {
                
                container.innerHTML = "";

                if (template != undefined) {
                    let write = ""
                    let html = template.innerHTML
                    for (j = 0; j < response.Values.length; j++) {
                        let entry = response.Values[j];

                        write += eval(`\`${html}\``);
                    }
                    container.innerHTML = write
                }
                if (action != undefined) {
                    container.innerHTML += eval(action.textContent)
                }

                render(container)

            }).catch(err => console.log(err));
        
    }
}

(function () {
    render(document)
})();
