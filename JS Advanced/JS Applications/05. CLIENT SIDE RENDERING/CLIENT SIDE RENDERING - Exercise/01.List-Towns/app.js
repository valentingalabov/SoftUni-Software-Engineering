import {html, render} from 'https://unpkg.com/lit-html?module';

const listTemplate = (data) => html`
<ul>
    ${data.map(t => html`<li>${t}</li>`)}
</ul>`;

document.getElementById('btnLoadTowns').addEventListener('click', updateList);




function updateList(event) {
    event.preventDefault();
    const townsAsString = document.getElementById('towns').value;
    const towns = townsAsString.split(', ').map(x => x.trim());

    const result = listTemplate(towns);
    const root = document.getElementById('root');
    render(result, root);
}