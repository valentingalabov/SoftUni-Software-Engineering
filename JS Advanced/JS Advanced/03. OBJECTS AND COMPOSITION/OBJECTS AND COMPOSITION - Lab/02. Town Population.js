function solve(inputArr) {
let cities = [];

for (let i = 0; i < inputArr.length; i++) {
    let el = inputArr[i].split(' <-> ');

    let nameToAdd = el[0];
    let populationToAdd = Number(el[1]);
   
    if (cities.some(a => a.name == nameToAdd)) {
        cities.find(x=>x.name == nameToAdd).population +=populationToAdd;
    }else{
        let city = {
            name: nameToAdd,
            population: populationToAdd
        };
        cities.push(city);
    }
}
    
let result = '';
// cities.forEach(element => {
//    result += `${element.name} : ${element.population} ` + '\n';
// });

const  entries = Object.entries(cities);

for (let [key, value] in entries) {
    result += `${key} : ${value} ` + '\n';
}

return result;

}

console.log(solve(
    ['Istanbul <-> 100000',
    'Honk Kong <-> 2100004',
    'Jerusalem <-> 2352344',
    'Mexico City <-> 23401925',
    'Istanbul <-> 1000']
));