function strLength(a, b, c) {
    let totalLength = a.length + b.length + c.length;
    let average = Math.floor(totalLength / 3);

    console.log(totalLength);
    console.log(average);
}

strLength('chocolate', 'ice cream', 'cake');
console.log("-------------")
strLength('pasta', '5', '22.3');