
function solve(area, vol, dataJSON) {
    const figures = JSON.parse(dataJSON);

    const result = [];

    for (let figure of figures) {
        result.push({
            area: area.call(figure),
            volume: objVolume = vol.call(figure)
        });

    }

    return result;

}

const example1 = `[
    {"x":"1","y":"2","z":"10"},
    {"x":"7","y":"7","z":"10"},
    {"x":"5","y":"2","z":"10"}
    ]`;


console.log(solve(area, vol, example1));


function area() {
    return Math.abs(this.x * this.y);
};

function vol() {
    return Math.abs(this.x * this.y * this.z);
};



