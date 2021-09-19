function smallestTwoElements(array) {
    const smallestTwoElementsResultArray = [];

    array.sort((a, b) => a - b);

    smallestTwoElementsResultArray.push(array[0]);
    smallestTwoElementsResultArray.push(array[1]);

    console.log(smallestTwoElementsResultArray.join(' '));
}

smallestTwoElements([30, 15, 50, 5]);
console.log('*'.repeat(10));
smallestTwoElements([3, 0, 10, 4, 7, 3]);