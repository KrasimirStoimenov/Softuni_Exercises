function solve() {
  let text = document.querySelector('#text').value;
  let namingConvention = document.querySelector('#naming-convention').value;

  const textSplitted = text.toLowerCase().split(' ');

  let result = '';


  if (namingConvention == 'Pascal Case') {
    result = textSplitted
      .map(x => x[0].toUpperCase() + x.slice(1))
      .join('');
  }
  else if (namingConvention == 'Camel Case') {
    result = textSplitted
      .map((x, i) => i == 0 ? x : x[0].toUpperCase() + x.slice(1))
      .join('');

    console.log(result);
  }
  else {
    result = 'Error!';
  }

  let resultElement = document.getElementById('result');
  resultElement.textContent = result;
}