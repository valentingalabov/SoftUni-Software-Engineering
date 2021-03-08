function solve(arr) {
    let juices = [];
    let bottles = [];
    let result = '';
    for (let line of arr) {
        let token = line.split(' => ');
        let juice = token[0];
        let quantity = Number(token[1]);
        if (!juices[juice]) {
            juices[juice] = 0;
        }
        juices[juice] += quantity;

        if (juices[juice] >= 1000) {
            if (juice in bottles) {
                bottles[juice] +=quantity;
            } else {
                bottles[juice] = juices[juice];
            }
        }  
    }

    for (const [key, value] of Object.entries(bottles)) {
           
            result += `${key} => ${Math.floor(value/1000)}\n`    
    }

    return result.trim();
}


console.log(solve(
    ['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']

));