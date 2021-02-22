function solve(input) {
    let result = [];

    function add(str) {
         result.push(str);
    };
    function remove(str) {
        result = result.filter(item => item !== str);
    }
    function print() {
        console.log(result.join(','));

    }

    for (let command of input) {
        let token = command.split(' ');
        let currCommand = token[0];
        let currValue = token[1];

        if (currCommand == 'add') {
            add(currValue);
        } else if (currCommand == 'remove') {
            remove(currValue);
        } else {
            print();
        }
    }


}

solve(['add hello', 'add again', 'remove hello', 'add again', 'print']);
solve(['add pesho', 'add george', 'add peter', 'remove peter','print']);