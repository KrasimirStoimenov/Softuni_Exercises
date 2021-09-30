function generateReport() {
    const inputElements = Array.from(document.querySelectorAll('input'));
    const columns = [];
    for (let i = 0; i < inputElements.length; i++) {
        const element = inputElements[i];
        if (element.checked) {
            columns.push(i, element.name)
        }
    }

    const tableElements = Array.from(document.querySelectorAll('tbody tr'));
    const result = [];

    for (let i = 0; i < tableElements.length; i++) {
        const trElement = tableElements[i];
        const tdElements = trElement.children;
        const currentObj = {};
        for (let j = 0; j < columns.length; j += 2) {
            const currentColumnIndex = columns[j];
            const currentColumnName = columns[j + 1];

            currentObj[currentColumnName] = tdElements[currentColumnIndex].textContent;
        }
        result.push(currentObj);
    }

    document.getElementById('output').textContent = JSON.stringify(result);
}
