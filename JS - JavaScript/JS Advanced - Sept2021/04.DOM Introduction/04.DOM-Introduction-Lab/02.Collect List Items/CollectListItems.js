function extractText() {
    const elements = document.getElementById('items').children;

    const result = [];

    for (const element of Array.from(elements)) {
        result.push(element.textContent);
    }

    document.getElementById('result').textContent = result.join('\n');
}