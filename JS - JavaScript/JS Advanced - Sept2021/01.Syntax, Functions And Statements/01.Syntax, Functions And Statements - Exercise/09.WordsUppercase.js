function words(string) {
    let result = string.toUpperCase()
    .match(/\w+/g)
    .join(', ');
  
  console.log(result);
}

words('Hi, how are you?');
console.log('*'.repeat(10));
words('hello');