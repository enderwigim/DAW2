// Función para cargar e insertar HTML
async function loadHTML(selector, url)  {
    fetch(url) // Cargar el archivo HTML
        .then(response => {
            if (!response.ok) throw new Error(`Failed to fetch ${url}: ${response.statusText}`);
            return response.text();
        })
        .then(data => {
            // Insertar el contenido HTML en el contenedor
            document.querySelector(selector).insertAdjacentHTML("beforeend",data);
        })
        .catch(error => console.error(error));
}


(async function loadPageComponents() {
    await Promise.all([
        loadHTML("body", "header/header.html"),
        loadHTML("body", "nav/nav.html"),
        loadHTML("body", "main/main.html"),
        loadHTML("body", "footer/footer.html")
    ]);
})();
