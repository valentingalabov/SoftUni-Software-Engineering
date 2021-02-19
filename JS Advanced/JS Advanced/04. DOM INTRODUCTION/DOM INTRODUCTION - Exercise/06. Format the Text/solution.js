function solve() {
  const text = document.querySelector('#input').value;
  let out = document.querySelector('#output');

  let sentences = text.split(/(?<=\.)/);
  let result = '';
  let currParagraphs = '';
  let counter = 0;
  for (let i = 0; i < sentences.length; i++) {
    if (counter == 3) {
      result += `<p>${currParagraphs}</p>`;
      currParagraphs = '';
      counter = 0;
    }

    currParagraphs += sentences[i];
    counter++;
    if (i == sentences.length - 1) {
      result += `<p> ${currParagraphs} </p>`;
    }
  }
  out.innerHTML = result;
}