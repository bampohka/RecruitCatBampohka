document.addEventListener("DOMContentLoaded", function () {
    // Highlight the current page's nav link
    var links = document.querySelectorAll(".main-nav .nav-link");
    var path = window.location.pathname.toLowerCase();
    links.forEach(function (link) {
        var href = (link.getAttribute("href") || "").toLowerCase();
        if (href === path || (path === "/" && href.endsWith("/index"))) {
            link.classList.add("active");
        }
    });
});
