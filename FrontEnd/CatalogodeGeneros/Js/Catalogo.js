document.addEventListener('DOMContentLoaded', function () {
    new Splide('#splide', {
        type       : 'loop',
        perPage    : 3,
        autoplay   : true,
        pauseOnHover: false,
        gap        : '1rem',
    }).mount();
});
