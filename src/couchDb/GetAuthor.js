var emit = function (key, value) {
  console.log("emit - " + key + " - " + value);
}

var getAuthor = function (doc) {
  var getNameOrEmailOrNull = function (data) {
    if (!data) {
      return null;
    }
    if ("name" in data) {
      return data.name;
    }
    if ("email" in data) {
      return data.email;
    }
    return null;
  }

  var getSafe = function (p, o) {
    return p.reduce(function (xs, x) {
      return (xs && xs[x]) ? xs[x] : null
    }, o)
  }

  var namesSet = Object.create(null);
  var addToNameSetIfPathExists = function (path) {
    var authorOrNull = getSafe(path, doc);
    var valueOrNull = getNameOrEmailOrNull(authorOrNull);
    if (valueOrNull && (valueOrNull in namesSet === false)) {
      namesSet[valueOrNull] = true;
    }
  };

  var searchThroughUsers = function (prefixProperties) {
    addToNameSetIfPathExists(prefixProperties.concat(["_npmUser"]));
    addToNameSetIfPathExists(prefixProperties.concat(["maintainers", 0]));
    addToNameSetIfPathExists(prefixProperties.concat(["maintainers", 1]));
    addToNameSetIfPathExists(prefixProperties.concat(["maintainers", 2]));
    addToNameSetIfPathExists(prefixProperties.concat(["contributors", 0]));
    addToNameSetIfPathExists(prefixProperties.concat(["contributors", 1]));
    addToNameSetIfPathExists(prefixProperties.concat(["contributors", 2]));
  }

  // doc._npmUser, doc.maintainers[0], doc.contributors[0] etc
  searchThroughUsers([]);

  // the npm procedure when a malicious package is found is to change the author to npm
  // searching for the '0.0.1-security' version of the package finds the original author
  searchThroughUsers(["versions", "0.0.1-security"]);

  var latest = getSafe(["dist-tags", "latest"], doc);
  if (latest) {
    searchThroughUsers(["versions", latest]);
  }

  emit(doc._id, Object.keys(namesSet));
}

module.exports = getAuthor;