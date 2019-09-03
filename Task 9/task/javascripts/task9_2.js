var error = "ERROR";
    
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