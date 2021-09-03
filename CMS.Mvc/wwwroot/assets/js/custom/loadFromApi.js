(function () {
  let containers = document.getElementsByClassName("load-from-api");
  for (var container of containers) {
    let url = container.getAttribute("api-url");

    fetch(
      url,
      {
        method:"GET"
      }
    ).then(response => response.json)
      .then(function (responseObject) {
        let html = container.getElementsByClassName("template")[0].outerHTML;
        container.innerHTML = "";
        for (var entry of responseObject.$values) {
          container.innerHTML += eval(`\`${html}\``)
        }
    })
  }
})();