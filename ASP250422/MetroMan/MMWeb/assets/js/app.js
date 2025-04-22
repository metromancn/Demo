document.addEventListener('DOMContentLoaded', () => {
    const search = document.getElementById('citySearch');
    if (!search) return;

    search.addEventListener('keyup', () => {
        const q = search.value.toLowerCase();
        document.querySelectorAll('#hotCities a').forEach(a => {
            a.style.display = a.textContent.toLowerCase().includes(q) ? '' : 'none';
        });
    });
});
