const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

let browser, page;

describe('E2E tests', function () {
    before(async () => {
        browser = await chromium.launch({ headless: false, slowMo: 500 });
    });

    after(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        page = await browser.newPage();
    });

    afterEach(async () => {
        await page.close();
    });

    it('Check messages is showed when click refresh', async () => {
        await page.goto('http://localhost:3000/');
        await page.click('text=Refresh');


        const content = await page.$eval('#messages', el => el.value);
        expect(content).to.contains(`Spami: Hello, are you there?`);
        expect(content).to.contains(`Garry: Yep, whats up :?`);
        expect(content).to.contains(`Spami: How are you? Long time no see? :)`);
        expect(content).to.contains(`George: Hello, guys! :))`);
        expect(content).to.contains(`Spami: Hello, George nice to see you! :)))`);
    });

    it.only('Check send new messages', async () => {
        // await page.route('**/jsonstore/messenger', route => route.fulfill(json({ author: name, content: message, _id: "0001" })));
        const name = 'Valio';
        const message = 'Hello from here!';


        await page.goto('http://localhost:3000/');

        await page.fill('#author', name);
        await page.fill('#content', message);

       const [response] = await Promise.all([
                page.waitForResponse('**/jsonstore/messenger'),
                page.click('[text="send"]')
            ]);

            const postData = JSON.parse(response.request().postData());
            expect(postData.author).to.equal(name);
            expect(postData.content).to.equal(message);


    });
});
