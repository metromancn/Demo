// 多语言字段映射
function getCityName(item) {
    const lang = (window.CURRENT_LANG || '').toLowerCase();
    if (lang.startsWith('en')) return item.city_en;
    if (lang.startsWith('ja')) return item.city_ja;
    if (lang.startsWith('zh-hant')) return item.city_zh_hant;
    return item.city_zh;
}
function getOpenDate(item) {
    const lang = (window.CURRENT_LANG || '').toLowerCase();
    if (lang.startsWith('en')) return item.open_en;
    if (lang.startsWith('ja')) return item.open_ja;
    if (lang.startsWith('zh-hant')) return item.open_zh_hant;
    return item.open;
}

// 排序
let sortField = 'rank';
let sortOrder = 'asc';

function renderTable() {
    const tbody = document.querySelector('#metroRankTable tbody');
    tbody.innerHTML = '';
    let data = METRO_RANKING_DATA.slice();
    data.sort((a, b) => {
        let v1 = a[sortField], v2 = b[sortField];
        if (typeof v1 === 'string') v1 = v1.toLowerCase();
        if (typeof v2 === 'string') v2 = v2.toLowerCase();
        if (v1 < v2) return sortOrder === 'asc' ? -1 : 1;
        if (v1 > v2) return sortOrder === 'asc' ? 1 : -1;
        return 0;
    });
    data.forEach(item => {
        const tr = document.createElement('tr');
        tr.innerHTML = `
            <td>${item.rank}</td>
            <td>${getCityName(item)}</td>
            <td>${item.mileage}</td>
            <td>${item.stations}</td>
            <td>${item.lines}</td>
            <td>${getOpenDate(item)}</td>
            <td><img src="${item.thumb}" alt="${getCityName(item)}" width="48" height="48" class="rounded" /></td>
        `;
        tbody.appendChild(tr);
    });
}

// 表头点击排序
function setupSort() {
    document.querySelectorAll('#metroRankTable th[data-sort]').forEach(th => {
        th.style.cursor = 'pointer';
        th.addEventListener('click', () => {
            const field = th.getAttribute('data-sort');
            if (sortField === field) {
                sortOrder = sortOrder === 'asc' ? 'desc' : 'asc';
            } else {
                sortField = field;
                sortOrder = 'asc';
            }
            renderTable();
        });
    });
}

document.addEventListener('DOMContentLoaded', function() {
    setupSort();
    renderTable();
});
