
class FromApi extends HTMLElement {
    static get observedAttributes() {
        return ['url'];
    }
    render() {
        let _this = this;
        console.log("rendering");
        let template = this.getTemplate();
        let action = this.getAction();
        this.innerHTML = "Yükleniyor...";
        fetch(
            this.getAttribute("url"),
            {
                method: "GET",
                accept: "application/json"
            }
        ).then(response => response.json())
            .then(function (response) {

                _this.innerHTML = "";

                if (template != undefined) {
                    let write = "";
                    let html = template.innerHTML;
                    for (j = 0; j < response.Values.length; j++) {
                        let entry = response.Values[j];

                        write += eval(`\`${html}\``);
                    }
                    _this.innerHTML = write;
                }
                if (action != undefined) {
                    _this.innerHTML += eval(action.textContent);
                }

                //render(container)

            });
    }

    connectedCallback() {
        this.render();
    }

    getTemplate() {
        return this.getElementsByTagName("template")[0];
    }

    getAction() {
        return this.getElementsByTagName("action")[0];
    }
}

customElements.define(
    "from-api",
    FromApi
);