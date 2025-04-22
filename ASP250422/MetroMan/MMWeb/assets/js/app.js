// ---------- MetroMan global script ----------
document.addEventListener('DOMContentLoaded', () => {
    const navCities = document.getElementById('navCities');

    if (!navCities) return;

    /* 每次展开下拉时：聚焦搜索框、重绑过滤器 */
    navCities.addEventListener('shown.bs.dropdown', () => {
        const search = document.getElementById('citySearch');
        if (!search) return;

        // 获取此次展开可见的热门城市条目
        const items = navCities.parentElement.querySelectorAll('.dropdown-menu a.dropdown-item');

        // 初始化
        search.value = '';
        search.focus();
        items.forEach(a => a.classList.remove('d-none'));

        /* 防重复绑定：先清掉旧监听 */
        search.onkeyup = null;

        search.addEventListener('keyup', () => {
            const kw = search.value.trim().toLowerCase();
            items.forEach(a => {
                const keep = a.classList.contains('fw-semibold')    // All Cities 固留
                    || a.textContent.toLowerCase().includes(kw);
                a.classList.toggle('d-none', !keep);                // 用 d‑none 隐藏
            });
        });
    });
});
