function createSortedList() {
    const array = [];

    const obj = {
        size: array.length,
        add: (element) => {
            array.push(element);
        },
        remove: (index) => {
            array.splice(index, 1);
        },
        get: (index) => {
            return array[index];
        },
    }

    return obj;
}

let list = createSortedList();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));
console.log(list.size);
