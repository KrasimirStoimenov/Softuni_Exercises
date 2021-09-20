function rotateArray(array, rotationCount) {
    for (let i = 0; i < rotationCount; i++) {
        array.unshift(array.pop());
    }

    console.log(array.join(' '));
}

rotateArray(['1',
    '2',
    '3',
    '4'],
    2);
console.log('*'.repeat(10));
rotateArray(['Banana',
    'Orange',
    'Coconut',
    'Apple'],
    15);