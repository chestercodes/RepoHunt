var emit = function (key, value) {
  console.log("emit - " + key + " - " + value);
}

var frequentlyReleased = function (doc) {
  var numberOfDatesInInterval = 5;
  var intervalInHours = 2;
  
  var times = [];
  var docTime = doc.time;
  for (var name in docTime) {
    if (docTime.hasOwnProperty(name)) {
      if (name !== "created" && name !== "modified" && name.indexOf("security") === -1) {
        times.push(new Date(docTime[name]));
      }
    }
  }
  if (times.length < numberOfDatesInInterval) {
    return;
  }
  var sorted = times.sort(function (a, b) {
    if (a < b) { return -1; }
    else if (a == b) { return 0; }
    else { return 1; }
  });
  var intervalInMilliseconds = intervalInHours * 60 * 60 * 1000;
  var upperBound = times.length - numberOfDatesInInterval + 1;
  for (var i = 0; i < upperBound; i++) {
    var min = times[i];
    var max = times[i + (numberOfDatesInInterval - 1)];
    var diff = max - min;
    if (diff < intervalInMilliseconds) {
      emit(doc._id, min);
      return;
    }
  }
}

module.exports = frequentlyReleased;