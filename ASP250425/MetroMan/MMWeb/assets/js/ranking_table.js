// 多语言字段映射
function getCityName(item) {
    const lang = (window.CURRENT_LANG || '').toLowerCase();
    if (lang.startsWith('en')) return item.en;
    if (lang.startsWith('ja')) return item.ja;
    if (lang.startsWith('zh-hant')) return item.tw;
    return item.cn;
}

function formatOpen(item) {
    const open = item.open;
    if (!open || isNaN(open)) return '';
    const year = Math.floor(open / 100);
    const month = open % 100;
    const lang = (window.CURRENT_LANG || '').toLowerCase();
    if (lang.startsWith('en')) {
        // 英文月份
        const months = ["", "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];
        return `${months[month]} ${year}`;
    } else {
        // 中文、日文格式
        return `${year}年${month}月`;
    }
}

function getThumb(item) {
    return `/assets/img/metro/thum/rank_${item.key}.png`;
}

// 排序
let sortField = 'mileage';
let sortOrder = 'desc';

function calcRanks(data, field, order) {
    // 默认按field排序，降序。排名相同则rank相同，跳号
    let arr = data.slice();
    arr.sort((a, b) => {
        let v1 = a[field], v2 = b[field];
        if (typeof v1 === 'string') v1 = v1.toLowerCase();
        if (typeof v2 === 'string') v2 = v2.toLowerCase();
        if (v1 < v2) return order === 'asc' ? -1 : 1;
        if (v1 > v2) return order === 'asc' ? 1 : -1;
        return 0;
    });
    let lastValue = null, lastRank = 0, skip = 1;
    arr.forEach((item, idx) => {
        let v = item[field];
        if (v === lastValue) {
            item._rank = lastRank;
            skip++;
        } else {
            item._rank = lastRank + skip;
            lastRank = item._rank;
            skip = 1;
            lastValue = v;
        }
    });
    return arr;
}

function renderTable() {
    const tbody = document.querySelector('#metroRankTable tbody');
    tbody.innerHTML = '';
    let data = METRO_RANKING_DATA.slice();
    // 排序并计算排名
    let arr = calcRanks(data, sortField, sortOrder);
    // 按当前排序显示
    arr.sort((a, b) => {
        let v1 = a[sortField], v2 = b[sortField];
        if (typeof v1 === 'string') v1 = v1.toLowerCase();
        if (typeof v2 === 'string') v2 = v2.toLowerCase();
        if (v1 < v2) return sortOrder === 'asc' ? -1 : 1;
        if (v1 > v2) return sortOrder === 'asc' ? 1 : -1;
        return 0;
    });
    arr.forEach(item => {
        const tr = document.createElement('tr');
        tr.innerHTML = `
            <td>${item._rank}</td>
            <td>${getCityName(item)}</td>
            <td>${item.mileage}</td>
            <td>${item.stations}</td>
            <td>${item.lines}</td>
            <td>${formatOpen(item)}</td>
            <td><img src="${getThumb(item)}" alt="${getCityName(item)}" width="48" height="48" class="rounded" /></td>
        `;
        tbody.appendChild(tr);
    });

    // 更新排序标记
    document.querySelectorAll('#metroRankTable th[data-sort]').forEach(th => {
        th.classList.remove('table-sort-active');
        const icon = th.querySelector('.sort-indicator');
        if (icon) icon.remove();
        const field = th.getAttribute('data-sort');
        if (field === sortField) {
            th.classList.add('table-sort-active');
            const mark = document.createElement('span');
            mark.className = 'sort-indicator ms-1';
            mark.innerHTML = sortField === 'open' ? '↑' : '↓';
            th.appendChild(mark);
        }
    });
}

// 表头点击排序（仅允许mileage, stations, lines, open，且只支持单向排序）
function setupSort() {
    const allowed = {
        mileage: 'desc',
        stations: 'desc',
        lines: 'desc',
        open: 'asc'
    };
    document.querySelectorAll('#metroRankTable th[data-sort]').forEach(th => {
        const field = th.getAttribute('data-sort');
        if (!allowed.hasOwnProperty(field)) {
            th.style.cursor = 'default';
            th.onclick = null;
            th.classList.remove('table-sort-active');
            return;
        }
        th.style.cursor = 'pointer';
        th.addEventListener('click', () => {
            if (sortField !== field) {
                sortField = field;
                sortOrder = allowed[field];
                renderTable();
            }
            // 如果点的是当前排序列，不做任何操作
        });
    });
}

document.addEventListener('DOMContentLoaded', function() {
    setupSort();
    renderTable();
});

// 添加简单排序标记样式
const style = document.createElement('style');
style.innerHTML = `.table-sort-active { color: #007bff; font-weight: bold; } .sort-indicator { font-size: 0.9em; }`;
document.head.appendChild(style);
