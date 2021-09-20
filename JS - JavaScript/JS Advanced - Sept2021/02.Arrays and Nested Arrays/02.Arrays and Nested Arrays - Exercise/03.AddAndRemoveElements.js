function addAndRemoveElements(array) {
    const elementsArray = [];
    let counter = 0;

    array.forEach(element => {
        if (element == 'add') {
            elementsArray.push(++counter);
        }
        else if (element == 'remove') {
            ++counter;
            elementsArray.pop();
        }
        else {
            console.log("Invalid element");
        }
    });
    if (elementsArray.length == 0) {
        console.log("Empty");   
    }
    else {
        console.log(elementsArray.join('\n'))
    }
}

addAndRemoveElements(['add',
    'add',
    'add',
    'add']);
console.log('*'.repeat(10));
addAndRemoveElements(['add',
    'add',
    'remove',
    'add',
    'add']);
console.log('*'.repeat(10));
addAndRemoveElements(['remove',
    'remove',
    'remove']);