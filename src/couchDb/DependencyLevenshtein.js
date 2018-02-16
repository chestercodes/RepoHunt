var emit = function (key, value) {
  console.log("emit - " + key + " - " + value);
}

var dependencyLevenshtein = function (doc) {
  var getLevDistance = function (a, b) {
    if (a.length == 0) return b.length;
    if (b.length == 0) return a.length;

    var matrix = [];

    // increment along the first column of each row
    var i;
    for (i = 0; i <= b.length; i++) {
      matrix[i] = [i];
    }

    // increment each column in the first row
    var j;
    for (j = 0; j <= a.length; j++) {
      matrix[0][j] = j;
    }

    // Fill in the rest of the matrix
    for (i = 1; i <= b.length; i++) {
      for (j = 1; j <= a.length; j++) {
        if (b.charAt(i - 1) == a.charAt(j - 1)) {
          matrix[i][j] = matrix[i - 1][j - 1];
        } else {
          matrix[i][j] = Math.min(matrix[i - 1][j - 1] + 1, // substitution
            Math.min(matrix[i][j - 1] + 1, // insertion
              matrix[i - 1][j] + 1)); // deletion
        }
      }
    }

    return matrix[b.length][a.length];
  };
  var maxDistance = 3;
  var l = doc['dist-tags'] && doc['dist-tags'].latest
  l = l && doc.versions && doc.versions[l]
  if (!l) return

  if ("dependencies" in l === false) {
    return;
  }
  var results = [];
  var dependencies = l["dependencies"];
  for (var property in dependencies) {
    if (property !== doc.name) {
      if (dependencies.hasOwnProperty(property)) {
        var distance = getLevDistance(doc.name, property);
        if (distance <= maxDistance) {
          results.push(property);
        }
      }
    }
  }
  if (results.length > 0) {
    emit(doc._id, results);
  }
}

module.exports = dependencyLevenshtein;