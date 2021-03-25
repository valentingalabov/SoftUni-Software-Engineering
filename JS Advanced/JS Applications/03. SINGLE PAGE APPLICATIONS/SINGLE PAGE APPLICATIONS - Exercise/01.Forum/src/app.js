import { showHome, setupHome } from "./home.js";
import { showDetails, setupDetails } from "./details.js";
import { showCreateComment, setupCreateConmment} from "./createComment.js";

const main = document.querySelector('main');

const links = {
    'home-page': showHome,
    'post-details': showDetails,
    'create-Comment': showCreateComment
}

setupSection('home-page', setupHome);
setupSection('post-details', setupDetails);
setupSection('create-Comment', setupCreateConmment);

setupNabBar();
showHome();


function setupSection(sectionId, setup) {
    const section = document.getElementById(sectionId);
    setup(main, section)
}


function setupNabBar() {
    const navBar = document.getElementById('nav-bar');

    navBar.addEventListener('click', (e) => {
        e.preventDefault();
        showHome();

    });
}