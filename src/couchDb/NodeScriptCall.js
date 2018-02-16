var emit = function (key, value) {
  console.log("emit - " + key + " - " + value);
}

var nodeScriptCall = function (doc) {
  var latestVersion = doc['dist-tags'] && doc['dist-tags'].latest
  latestVersion = latestVersion && doc.versions && doc.versions[latestVersion]
  if (!latestVersion) return

  if ("scripts" in latestVersion === false) {
    return;
  }

  var scripts = latestVersion["scripts"];
  var npmInstallEvents = [
    "preinstall", "install", "postinstall",
    "prepublish", "prepare", "prepack"
  ]

  for (var i in npmInstallEvents) {
    var eventName = npmInstallEvents[i];
    var script = scripts[eventName];
    if (script) {
      var scriptContainsNode = script.toLowerCase().indexOf("node ") !== -1
      if (scriptContainsNode) {
        emit(doc._id, script)
      }
    }
  }
}

module.exports = nodeScriptCall;