function solve(fruit, weight, pricePerKg) {
 const weightKg = weight / 1000;
 const price = pricePerKg * weightKg;
 return `I need $${price.toFixed(2)} to buy ${weightKg.toFixed(2)} kilograms ${fruit}.`;
}

console.log(solve('orange', 2500, 1.80));
console.log(solve('apple', 1563, 2.35));