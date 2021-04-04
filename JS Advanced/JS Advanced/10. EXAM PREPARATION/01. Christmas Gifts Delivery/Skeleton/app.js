function solution() {
    const [gifts, sent, discarded] = document.querySelectorAll('section ul');
    const input = document.querySelector('input');

    document.querySelector('button').addEventListener('click', addGift);

    function addGift() {
        const name = input.value;
        input.value = '';

        const element = e('li', name, 'gift');
        const sendBtn = e('button', 'Send', 'sendButton');
        const discardBtm = e('button', 'Discard', 'discardButton');
        element.appendChild(sendBtn);
        element.appendChild(discardBtm);

        sendBtn.addEventListener('click', () => sendGift(name, element));
        discardBtm.addEventListener('click', () => discardGift(name, element));

        gifts.appendChild(element);
        sortGifts();

    }

    function sendGift(name, gift) {
        gift.remove();
        const element = e('li', name, 'gift');
        sent.appendChild(element);
    }

    function discardGift(name, gift) {
        gift.remove();
        const element = e('li', name, 'gift');
        discarded.appendChild(element);
    }

    function sortGifts() {
        Array
            .from(gifts.children)
            .sort((a, b) => a.textContent.localeCompare(b.textContent))
            .forEach(g => gifts.appendChild(g));
    }


    function e(type, content, className) {
        const result = document.createElement(type);
        result.textContent = content;

        if (className) {
            result.className = className;
        }

        return result;
    }

}