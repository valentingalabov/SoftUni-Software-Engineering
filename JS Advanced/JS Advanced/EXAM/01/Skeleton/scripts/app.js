function solve() {

    const addBtn = document.querySelector('form button');
    addBtn.addEventListener('click', addBook);

    function addBook(event) {
        event.preventDefault();
        const inputs = document.querySelectorAll('form input');
        const title = inputs[0].value;
        const year = inputs[1].value;
        const price = inputs[2].value;

        if (title == '' || year < 0 || year == '' || price < 0 || price == '') {
            return;
        }


        const shelfs = document.querySelectorAll('.shelf');
        const oldBooksShelf = shelfs[0];
        const newBooksShelf = shelfs[1];
        if (year < 2000) {

            const oldBook =
                e('div', { className: 'book' },
                    e('p', {}, `${title} [${year}]`),
                    e('button', { onClick: (event) => buyIt(event) }, `Buy it only for ${(Number(price) * 0.85).toFixed(2)} BGN`));
            oldBooksShelf.appendChild(oldBook);
        } else {

            const newBook =
                e('div', { className: 'book' },
                    e('p', {}, `${title} [${year}]`),
                    e('button', { onClick: (event) => buyIt(event) }, `Buy it only for ${Number(price).toFixed(2)} BGN`),
                    e('button', { onClick: (event) => moveToOld(event) }, 'Move to old section'));

            newBooksShelf.appendChild(newBook);
        }




    }

    function buyIt(event) {
        const globalRegex = new RegExp('[0-9.]+', 'g');
        const price = Number(event.target.textContent.match(globalRegex));
        event.target.parentNode.remove();
        const total = document.querySelectorAll('h1')[1];
        const totalPrice = Number(total.textContent.match(globalRegex));
        total.innerHTML = `Total Store Profit: ${totalPrice + price} BGN`
    }
    function moveToOld(event) {
        const globalRegex = new RegExp('[0-9.]+', 'g');

        const currBook = event.target.parentNode;


        const btns = currBook.querySelectorAll('button');
        const priceBtn = btns[0];
        const price = Number(priceBtn.textContent.match(globalRegex) * 0.85).toFixed(2);
        priceBtn.textContent = `Buy it only for ${price} BGN`;

        const btnToRemove = btns[1];
        btnToRemove.remove();

        const oldShaft = document.querySelectorAll('.shelf')[0];
        console.log(oldShaft);
        console.log(currBook);
        oldShaft.appendChild(currBook);
    }




    function e(type, attributes, ...content) {
        const result = document.createElement(type);

        for (let [attr, value] of Object.entries(attributes || {})) {
            if (attr.substring(0, 2) == 'on') {
                result.addEventListener(attr.substring(2).toLocaleLowerCase(), value);
            } else {
                result[attr] = value;
            }
        }

        content = content.reduce((a, c) => a.concat(Array.isArray(c) ? c : [c]), []);

        content.forEach(e => {
            if (typeof e == 'string' || typeof e == 'number') {
                const node = document.createTextNode(e);
                result.appendChild(node);
            } else {
                result.appendChild(e);
            }
        });

        return result;
    }


}