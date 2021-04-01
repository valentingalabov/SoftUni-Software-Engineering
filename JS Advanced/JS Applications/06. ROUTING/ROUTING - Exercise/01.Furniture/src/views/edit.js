import { html } from "../../node_modules/lit-html/lit-html.js";
import { getItemById, editRecord } from '../api/data.js';


const editTemplate = (item, onSubmit, invalidMake, invalidModel,
    invalidYear, invalidDescription,
    ivalidPrice, invalidImage) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Edit Furniture</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit=${onSubmit}>
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-make">Make</label>
                <input class=${'form-control' + (invalidMake ? ' is-invalid' : '' )} id="new-make" type="text"
                    name="make" value=${item.make}>
            </div>
            <div class="form-group has-success">
                <label class="form-control-label" for="new-model">Model</label>
                <input class=${'form-control' + (invalidModel ? ' is-invalid' : '' )} id="new-model" type="text"
                    name="model" value=${item.model}>
            </div>
            <div class="form-group has-danger">
                <label class="form-control-label" for="new-year">Year</label>
                <input class=${'form-control' + (invalidYear ? ' is-invalid' : '' )} id="new-year" type="number"
                    name="year" value=${item.year}>
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-description">Description</label>
                <input class=${'form-control' + (invalidDescription ? ' is-invalid' : '' )} id="new-description"
                    type="text" name="description" value=${item.description}>
            </div>
        </div>
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="new-price">Price</label>
                <input class=${'form-control' + (ivalidPrice ? ' is-invalid' : '' )} id="new-price" type="number"
                    name="price" value=${item.price}>
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-image">Image</label>
                <input class=${'form-control' + (invalidImage ? ' is-invalid' : '' )} id="new-image" type="text"
                    name="img" value=${item.img}>
            </div>
            <div class="form-group">
                <label class="form-control-label" for="new-material">Material (optional)</label>
                <input class='form-control' id="new-material" type="text" name="material" value=${item.material}>
            </div>
            <input type="submit" class="btn btn-info" value="Edit" />
        </div>
    </div>
</form>`;

export async function editpage(ctx) {
    const id = ctx.params.id;

    const item = await getItemById(id);

    ctx.render(editTemplate(item, onSubmit));

    async function onSubmit(event) {
        event.preventDefault();
        const formData = new FormData(event.target);
        const make = formData.get('make');
        const model = formData.get('model');
        const year = formData.get('year');
        const description = formData.get('description');
        const price = formData.get('price');
        const img = formData.get('img');
        const material = formData.get('material');

        if (make.length < 4 || model.length < 4
            || year < 1950 || year > 2050 || description.length < 10
            || price < 0 || img.length < 1) {
            alert('Invalid entries!');
            return ctx.render(editTemplate(item, onSubmit, make.length < 4, model.length < 4,
                year < 1950 || year > 2050, description.length < 10, price < 0 || price.length < 1, img.length < 1));
        }

        const furniture = {
            make,
            model,
            year,
            description,
            price,
            img,
            material
        }
        await editRecord(item._id, furniture);

        ctx.page.redirect('/');



    }
}