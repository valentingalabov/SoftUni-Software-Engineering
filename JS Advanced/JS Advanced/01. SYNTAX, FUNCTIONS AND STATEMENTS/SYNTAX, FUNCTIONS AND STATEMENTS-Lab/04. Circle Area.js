function solve(input) {
    let intputType = typeof(input);

    if (intputType === 'number') {
        result = Math.pow(input, 2) * Math.PI;
        console.log(result.toFixed(2));
    }
    else{
        console.log(`We can not calculate the circle area, because we receive a ${intputType}.`)
    }
}

solve(5);
solve('name');