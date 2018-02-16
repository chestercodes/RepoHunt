var emit = function (key, value) {
  console.log("emit - " + key + " - " + value);
}

var majorVersionJump = function (doc) {
  if (!String.prototype.startsWith) {
    String.prototype.startsWith = function (search, pos) {
      return this.substr(!pos || pos < 0 ? 0 : +pos, search.length) === search;
    };
  }
  // detect jumps from nothing to a non 1 major version.
  var docTime = doc.time;
  for (var name in docTime) {
    if (docTime.hasOwnProperty(name)) {
      if (name !== "created" && name !== "modified" && name.indexOf("security") === -1) {
        var firstVersion = name;
        if ((firstVersion.startsWith("0.") === false) && (firstVersion.startsWith("1.") === false)) {
          emit(doc._id, firstVersion);
        }
        return;
      }
    }
  }
}

module.exports = majorVersionJump;