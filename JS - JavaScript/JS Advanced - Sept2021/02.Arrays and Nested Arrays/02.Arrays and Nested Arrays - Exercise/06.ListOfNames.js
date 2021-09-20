function sortNames(names) {
    const resultArray = [];
    names  = names.sort((a,b)=>a.localeCompare(b));
    
    for (let i = 0; i < names.length; i++) {
        resultArray.push(`${i+1}.${names[i]}`)
    }

    console.log(resultArray.join('\n'));
}

sortNames(["John", "Bob", "Christina", "Ema"]);