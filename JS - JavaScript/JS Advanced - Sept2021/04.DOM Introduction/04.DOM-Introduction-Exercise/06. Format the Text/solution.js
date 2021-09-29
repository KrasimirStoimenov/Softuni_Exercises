function solve() {
  const text = document.getElementById('input').value;
  const output = document.getElementById('output');

  const sentences = text.split('.').filter(x => x != '');

  const paragraphs = [];

  for (let i = 0; i < sentences.length; i += 3) {
    const result = [];
    let currentParagraph = '<p>';
    for (let j = 0; j < 3; j++) {
      if (sentences.length > i + j) {
        result.push(sentences[i + j]);
      }
    }

    currentParagraph += result.join('.') + '.' + '</p>';

    paragraphs.push(currentParagraph);
  }

  output.innerHTML = paragraphs.join('');
}