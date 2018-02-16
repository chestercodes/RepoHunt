var emit = function (key, value) {
  console.log("emit - " + key + " - " + value);
}

var frequentlyReleasedAfterCreation = function (doc) {
  // check for 5 packages created an hour after creation.
  var times = [];
  var docTime = doc.time;
  for (var name in docTime) {
    var asStr = name.toString();
    if (docTime.hasOwnProperty(name)) {
      if (name !== "created" && name !== "modified" && asStr.indexOf("security") === -1) {
        times.push(new Date(docTime[name]));
      }
    }
  }

  var sorted = times.sort(function (a, b) {
    if (a < b) {
      return -1;
    } else if (a == b) {
      return 0;
    } else {
      return 1;
    }
  });

  if (("created" in docTime) === false) {
    emit(doc._id, "Error, no created");
    return;
  }

  var createdAt = new Date(docTime["created"]);

  var numberOfDatesAfterCreation = 5;
  if (times.length < numberOfDatesAfterCreation) {
    return;
  }

  var intervalInHours = 1;
  var intervalInMilliseconds = intervalInHours * 60 * 60 * 1000;

  var nthDate = sorted[numberOfDatesAfterCreation - 1];
  if ((nthDate - createdAt) <= intervalInMilliseconds) {
    emit(doc._id, nthDate);
  }
}

module.exports = frequentlyReleasedAfterCreation;