function sortArray(numbers) {
    numbers = numbers.sort((a,b)=>a.length - b.length || a.localeCompare(b));

    console.log(numbers.join('\n'));
}

sortArray(['alpha',
    'beta',
    'gamma']);
console.log('*'.repeat(10));
sortArray(['Isacc',
    'Theodor',
    'Jack',
    'Harrison',
    'George']);
console.log('*'.repeat(10));
sortArray(['test',
    'Deny',
    'omen',
    'Default']);