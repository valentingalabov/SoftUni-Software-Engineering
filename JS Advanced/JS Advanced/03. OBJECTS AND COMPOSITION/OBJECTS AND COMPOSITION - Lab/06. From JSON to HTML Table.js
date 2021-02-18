function fromJSONToHTMLTable(json) {
 
    let arr = JSON.parse(json);
 
    let outputArr = ["<table>"];
    outputArr.push(makeKeyRow(arr));
    arr.forEach(obj => outputArr.push(makeValueRow(obj)));
    outputArr.push("</table>");
 
    console.log(outputArr.join('\n'));
 
 
    function makeKeyRow(arr) {
        let result = '';
        if (arr.length < 3) {
            let [name, score] = Object.keys(arr[0]);

            result = `  <tr><th>${name}</th><th>${score}</th></tr>`;
        } else {
            let [name, score, grade] = Object.keys(arr[0]);
            result = `  <tr><th>${name}</th><th>${score}</th><th>${grade}</th></tr>`;
        }
        return result;
    }
    function makeValueRow(obj) {
        let result = '';
        let values = Object.values(obj);

        if (arr.length < 3) {
            let [name, score] = [...values];
            result = `<tr><td>${name}</td><td>${score}</td></tr>`;
        } else {
            let [name, score, grade] = [...values]
            result = `<tr><td>${name}</td><td>${score}</td><td>${grade}</td></tr>`;
        }
 
        return result;
    }
 
    function escapeHtml(value) {
        return value
        .toString()
            .replace(/&/g, "&amp;")
            .replace(/</g, "&lt;")
            .replace(/>/g, "&gt;")
            .replace(/"/g, "&quot;")
            .replace(/'/g, "&#39;");
    }
}

fromJSONToHTMLTable(`[{"Name":"Stamat",
"Score":5.5},
{"Name":"Rumen",
"Score":6}]`
)

fromJSONToHTMLTable(`[{"Name":"Pesho",
"Score":4,
" Grade":8},
{"Name":"Gosho",
"Score":5,
" Grade":8},
{"Name":"Angel",
"Score":5.50,
" Grade":10}]`
);