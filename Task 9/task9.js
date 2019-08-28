// var str = "? ???? ???? ??????";
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

var error = "ERROR";

//var massife = "5????+5???????*??4????????/??2????????=".match(/\d+(\.\d+)?|([+\-*/=])/g);
    
function mathCalculator() {
      var massife = document
        .getElementById("task2-input")
        .value.match(/\d+(\.\d+)?|([+\-*/=])/g);
    
      var result;
    
      check(massife);
    
      var operations = {
        "+": function(x, y) {
          return x + y;
        },
    
        "-": function(x, y) {
          return x - y;
        },
    
        "*": function(x, y) {
          return x * y;
        },
    
        "/": function(x, y) {
          return y !== 0 ? x / y : 0;
        }
      };
    
      result = massife[0];
      for (var i = 1; i + 2 < massife.length; i += 2) {
        result = operations[massife[i]](Number(result), Number(massife[i + 1])).toFixed(2);
      }
    
      document.getElementById("task2-output").value = result;
}
    
function check(massife) {
      if (
        massife.filter(function(x) {
          return x === "=";
        }).length !== 1 &&
        massife[massife.lastIndex] !== "="
      ) {
        document.getElementById("task2-output").value = error;
      }
      for (let i = 0; i < massife.length; i++) {
        if (i % 2 === 0 && isNaN(massife[i])) {
          document.getElementById("task2-output").value = error;
        }
        if (i % 2 === 1 && !isNaN(massife[i])) {
          document.getElementById("task2-output").value = error;
        }
      }
      return true;
}
    