function createSortedList() {
    let result = [];

    function sort(arr) {
        return arr.sort((a, b) => a - b);
    }
    return {
        size: 0,
        add(num) {
            sort(result);
            result.push(num);
            this.size ++;

        },
        remove(index) {
            sort(result);
            if (index > -1 && index < result.length) {
                result.splice(index, 1);
                this.size --;
            }

        },
        get(index) {
            sort(result);
            if (index > -1 && index < result.length) {
                return result[index];
            }

        },
       
    }

}


let list = createSortedList();
list.add(7);
list.add(6);
list.add(5);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
console.log(list.size);
