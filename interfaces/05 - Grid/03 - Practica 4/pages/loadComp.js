// Función para cargar e insertar HTML
async function loadHTML(selector, url) {
    try {
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error(`Failed to fetch ${url}: ${response.statusText}`);
        }
        const data = await response.text();
        document.querySelector(selector).insertAdjacentHTML("beforeend", data);
    } catch (error) {
        console.error(error); // Manejo de errores
    }
}


(async function loadPageComponents() {
    await loadHTML("body", "../components/header/header.html"); 
    await loadHTML("body", "../components/nav/nav.html");      
    await loadHTML("body", "../components/main/main.html");    
    await loadHTML("body", "../components/footer/footer.html");
})();