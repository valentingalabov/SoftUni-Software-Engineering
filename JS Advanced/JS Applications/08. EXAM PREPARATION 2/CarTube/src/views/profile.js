import { html } from '../../node_modules/lit-html/lit-html.js';

import { getMyListing } from '../api/data.js';
import { carTemplate } from './common/car.js';

const profileTemplate = (cars) => html`
<section id="my-listings">
    <h1>My car listings</h1>
    <div class="listings">

        ${cars.length == 0 ? html`<p class="no-cars">No cars in database.</p>` : cars.map(carTemplate)}

        <!-- Display if there are no records -->
        <p class="no-cars"> You haven't listed any cars yet.</p>
    </div>
</section>
`;

export async function profilePage(ctx){
    const cars = await getMyListing(ctx.user._id);

    ctx.render(profileTemplate(cars));
}