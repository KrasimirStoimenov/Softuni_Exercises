class List {
    constructor() {
        this.elements = [];
        this.size = 0;
    }

    add(element) {
        this.elements.push(element);
        this.elements.sort((a, b) => a - b);
        this.size++;
    }

    remove(index) {
        this.validateIndex(index);
        this.elements.splice(index, 1);
        this.size--;
    }

    get(index) {
        this.validateIndex(index);
        return this.elements[index];
    }

    validateIndex(index) {
        if (index < 0 || index >= this.elements.length) {
            throw new Error('Index was outside of bounds of the array');
        }
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1));
list.remove(1);
console.log(list.get(1));