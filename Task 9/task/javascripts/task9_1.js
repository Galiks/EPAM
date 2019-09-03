function charRemover() {
    var str = document.getElementById("task1-input").value;
    var separators = [" ", "\t", "?", "!", ":", ";", ",", "."];
    var letters = {};
    var startIndex = 0;
    var words = splitMulti(str, separators);
    var result;
    var chars = str.split("");

    words.forEach(function(word) {
      word.split("").forEach(function(letter, i) {
        console.log(letters[letter])
        if (word.indexOf(letter, i + 1) !== -1) {
          letters[letter] = true;
        }
      });
    });

    result = chars
      .filter(function(char) {
        return !letters[char];
      })
      .join("");
    document.getElementById("task1-output").value = result;
}
    
function splitMulti(str, separators) {
      for (var i = 0; i < str.length; i++) {
        if (separators.indexOf(str[i]) !== -1) {
          str = str.replace(str[i], " ");
        }
      }
    
      var words = str.split(" ");
      return words.filter(function(word) {
        if (word.length > 0) {
          return word;
        }
      })
}