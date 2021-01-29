function solve(num) {
    if (num >1 ) {
        rep(num);
    }else if (num == 1) {
       console.log('*');
        }else {
            rep(5);
        }

function rep(row) {
    for (let currRow = 0; currRow < row; currRow++) {
        console.log("* ".repeat(row));
        }         
    }
}     
solve(1)
solve(2);
solve(5);
solve();

