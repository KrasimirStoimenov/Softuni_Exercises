class Hex {
    constructor(value) {
        this.value = value;
    }

    valueOf() {
        return this.value;
    }

    toString() {
        return `0x${this.value.toString(16).toUpperCase()}`;
    }

    plus(number) {
        return new Hex(this.value + number);
    }

    minus(number) {
        return new Hex(this.value - number);
    }

    parse(string) {
        return parseInt(string, 16);
    }
}

let FF = new Hex(255);
console.log(FF.toString());
FF.valueOf() + 1 == 256;
let a = new Hex(10);
let b = new Hex(5);
console.log(a.plus(b).toString());
console.log(a.plus(b).toString() === '0xF');
console.log(FF.parse('AAA'));

console.log('*'.repeat(50));

let FF2 = new Hex(255);

let act = FF2.toString();
let exp = "0xFF";
console.log(act === exp);

console.log(FF2.valueOf() - 1 == 254);
let a2 = new Hex(10);
let b2 = new Hex(5);
let c2 = new Hex(155);
let act2 = a2.plus(c2).toString();
let exp2 = "0xA5";
console.log(act2 === exp2);
let act3 = a2.minus(b2).toString();
let exp3 = "0x5";
console.log(act3 === exp3);