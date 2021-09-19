function sum(array){
    const first =parseInt(array.shift());
    const second = parseInt(array.pop());

    return first+second;
}

console.log(sum(['20', '30', '40']));
console.log('*'.repeat(10));
console.log(sum(['5', '10']));