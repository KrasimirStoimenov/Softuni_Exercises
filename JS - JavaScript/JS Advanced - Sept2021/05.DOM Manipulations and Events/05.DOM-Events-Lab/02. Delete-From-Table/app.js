function deleteByEmail() {
    const customersEmailsElements = Array.from(document
        .querySelectorAll('tbody tr td'))
        .filter((v, i) => i % 2 != 0);
    const input = document.querySelector('input');
    let hasDeleteElement = false;
    for (const email of customersEmailsElements) {
        if (email.textContent == input.value) {
            email.parentElement.remove();
            document.getElementById('result').textContent = 'Deleted.';
            hasDeleteElement = true;
        }
    }

    if (!hasDeleteElement) {
        document.getElementById('result').textContent = 'Not found.';
    }
}