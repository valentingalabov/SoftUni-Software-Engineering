function solve(text) {
    let result = text.toUpperCase()
      .match(/\w+/g)
      .join(', ');
    
    return result
  }
console.log(solve('Hi, how are you?'));
console.log(solve('hello'));