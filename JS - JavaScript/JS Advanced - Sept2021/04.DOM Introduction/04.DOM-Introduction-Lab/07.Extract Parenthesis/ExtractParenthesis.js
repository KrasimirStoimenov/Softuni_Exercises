function extract(content) {
    const text = document.getElementById(content).textContent;
    const pattern = /\(([^)]+)\)/g;

    let match = pattern.exec(text);
    const result = [];

    while (match) {
        result.push(match[1]);
        match = pattern.exec(text);
    }

    return result.join('; ');
}