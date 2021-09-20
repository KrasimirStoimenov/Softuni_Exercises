function print(stringArray, delimeter) {
    const lastElement = stringArray.pop();
    const resultArray = stringArray
        .map(v => v + delimeter);
    resultArray.push(lastElement);
    
    console.log(resultArray.join(''));
}

print(['One',
    'Two',
    'Three',
    'Four',
    'Five'],
    '-');
console.log('*'.repeat(10));
print(['How about no?',
    'I',
    'will',
    'not',
    'do',
    'it!'],
    '_');