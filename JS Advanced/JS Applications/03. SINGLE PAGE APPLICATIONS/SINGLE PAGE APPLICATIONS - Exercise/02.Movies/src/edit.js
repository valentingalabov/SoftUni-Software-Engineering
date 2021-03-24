
async function onSubmit() {
    
}

let main;
let section;

export function setupEdit(mainTarget, sectionTarget){
    main = mainTarget;
    section = sectionTarget;
    const form = section.querySelector('form');
    form.addEventListener('submit', onSubmit );
}

export async function showEdit(id) {
    main.innerHTML = '';
    main.appendChild(section);
}