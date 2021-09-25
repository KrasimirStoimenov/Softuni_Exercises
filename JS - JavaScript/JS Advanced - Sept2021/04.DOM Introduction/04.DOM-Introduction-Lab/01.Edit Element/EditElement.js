function editElement(htmlElement, match, replacer) {
    const text = htmlElement.textContent;
    const matcher = new RegExp(match, 'g');
    htmlElement.textContent = text.replace(matcher, replacer);
}