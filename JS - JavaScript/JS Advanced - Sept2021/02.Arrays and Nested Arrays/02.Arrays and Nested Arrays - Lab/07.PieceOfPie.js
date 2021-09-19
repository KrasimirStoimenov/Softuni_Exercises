function piePieces(flavors, firstTargetFlavour, secondTargetFlavour) {
    const firstFlavorIndex = flavors.indexOf(firstTargetFlavour);
    const secondFlavorIndex = flavors.indexOf(secondTargetFlavour);

    const resultArray = [];

    for (let i = firstFlavorIndex; i <= secondFlavorIndex; i++) {
        resultArray.push(flavors[i]);
    }

    return resultArray;
}

console.log(piePieces(['Pumpkin Pie',
    'Key Lime Pie',
    'Cherry Pie',
    'Lemon Meringue Pie',
    'Sugar Cream Pie'],
    'Key Lime Pie',
    'Lemon Meringue Pie'));

console.log('*'.repeat(10));
console.log(piePieces(['Apple Crisp',
    'Mississippi Mud Pie',
    'Pot Pie',
    'Steak and Cheese Pie',
    'Butter Chicken Pie',
    'Smoked Fish Pie'],
    'Pot Pie',
    'Smoked Fish Pie'
));