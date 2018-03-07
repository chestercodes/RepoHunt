var brit = require("brittanica-g");
var guy = brit.glimmer.description;
var lines = guy.split("\n");

function sleep(ms) {
  var unixtime_ms = new Date().getTime();
  while(new Date().getTime() < unixtime_ms + ms) {}
}

lines.forEach(function(element) {
  console.log(element);
  sleep(5);
});