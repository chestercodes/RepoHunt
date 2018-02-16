var depLev = require("./DependencyLevenshtein");
var freqReleased = require("./FrequentlyReleased");
var freqReleasedAfterCreation = require("./FrequentlyReleasedAfterCreation");
var getAuthor = require("./GetAuthor");
var nodeScriptCall = require("./NodeScriptCall");
var majorVersionJump = require("./MajorVersionJump")

var runStuff = function(){
  depLev(crossenv)
  freqReleased(crossenv);
  freqReleasedAfterCreation(crossenv);
  getAuthor(crossenv);
  nodeScriptCall(crossenv);
  majorVersionJump(crossenv);
};

var react = {
  "_id": "react",
  "_rev": "392-e8ec4bd5bbb04569e3dc7877192d14db",
  "name": "react",
  "description": "React is a JavaScript library for building user interfaces.",
  "dist-tags": {
    "latest": "16.0.0",
    "next": "16.1.0-beta",
    "dev": "15.5.0-rc.2"
  },
  "versions": {
    "0.0.1": {
      "name": "react",
      "description": "React is a javascript module to make it easier to work with asynchronous code, by reducing boilerplate code and improving error and exception handling while allowing variable and task dependencies when defining flow.",
      "version": "0.0.1",
      "author": {
        "name": "Jeff Barczewski",
        "email": "jeff.barczewski@gmail.com"
      },
      "repository": {
        "type": "git",
        "url": "git://github.com/jeffbski/react.git"
      },
      "bugs": { "url": "http://github.com/jeffbski/react/issues" },
      "licenses": [{
        "type": "MIT",
        "url": "http://github.com/jeffbski/react/raw/master/LICENSE"
      }],
      "main": "react",
      "engines": { "node": "~v0.4.12" },
      "dependencies": {},
      "devDependencies": {},
      "_npmUser": {
        "name": "jeffbski",
        "email": "jeff.barczewski@gmail.com"
      },
      "_id": "react@0.0.1",
      "_engineSupported": true,
      "_npmVersion": "1.0.103",
      "_nodeVersion": "v0.4.12",
      "_defaultsLoaded": true,
      "dist": {
        "shasum": "c84d3dbff0c65577a52f0bfe431f8bcc155fa365",
        "tarball": "http://registry.npmjs.org/react/-/react-0.0.1.tgz"
      },
      "maintainers": [{
        "name": "jeffbski",
        "email": "jeff.barczewski@gmail.com"
      }],
      "directories": {}
    },
    "16.0.0": {
      "name": "react",
      "description": "React is a JavaScript library for building user interfaces.",
      "keywords": ["react"],
      "version": "16.0.0",
      "homepage": "https://facebook.github.io/react/",
      "bugs": { "url": "https://github.com/facebook/react/issues" },
      "license": "MIT",
      "files": ["LICENSE",
        "README.md",
        "index.js",
        "cjs/",
        "umd/"],
      "main": "index.js",
      "repository": {
        "type": "git",
        "url": "git+https://github.com/facebook/react.git"
      },
      "engines": { "node": ">=0.10.0" },
      "dependencies": {
        "fbjs": "^0.8.16",
        "loose-envify": "^1.1.0",
        "object-assign": "^4.1.1",
        "prop-types": "^15.6.0"
      },
      "browserify": { "transform": ["loose-envify"] },
      "_id": "react@16.0.0",
      "scripts": {},
      "_shasum": "ce7df8f1941b036f02b2cca9dbd0cb1f0e855e2d",
      "_from": ".",
      "_npmVersion": "3.10.10",
      "_nodeVersion": "6.10.0",
      "_npmUser": {
        "name": "acdlite",
        "email": "acdlite@me.com"
      },
      "dist": {
        "shasum": "ce7df8f1941b036f02b2cca9dbd0cb1f0e855e2d",
        "tarball": "https://registry.npmjs.org/react/-/react-16.0.0.tgz"
      },
      "maintainers": [{
        "email": "acdlite@me.com",
        "name": "acdlite"
      }, {
        "email": "npm@sophiebits.com",
        "name": "sophiebits"
      }, {
        "email": "flarnie.npm@gmail.com",
        "name": "flarnie"
      }, {
        "email": "dan.abramov@gmail.com",
        "name": "gaearon"
      }, {
        "email": "dg@domgan.com",
        "name": "trueadm"
      }, {
        "email": "briandavidvaughn@gmail.com",
        "name": "brianvaughn"
      }, {
        "email": "opensource+npm@fb.com",
        "name": "fb"
      }],
      "_npmOperationalInternal": {
        "host": "s3://npm-registry-packages",
        "tmp": "tmp/react-16.0.0.tgz_1506441629690_0.8590346616692841"
      },
      "directories": {}
    },
    "16.1.0-beta": {
      "name": "react",
      "description": "React is a JavaScript library for building user interfaces.",
      "keywords": ["react"],
      "version": "16.1.0-beta",
      "homepage": "https://reactjs.org/",
      "bugs": { "url": "https://github.com/facebook/react/issues" },
      "license": "MIT",
      "files": ["LICENSE",
        "README.md",
        "index.js",
        "cjs/",
        "umd/"],
      "main": "index.js",
      "repository": {
        "type": "git",
        "url": "git+https://github.com/facebook/react.git"
      },
      "engines": { "node": ">=0.10.0" },
      "dependencies": {
        "fbjs": "^0.8.16",
        "loose-envify": "^1.1.0",
        "object-assign": "^4.1.1",
        "prop-types": "^15.6.0"
      },
      "browserify": { "transform": ["loose-envify"] },
      "_id": "react@16.1.0-beta",
      "_npmVersion": "5.3.0",
      "_nodeVersion": "8.4.0",
      "_npmUser": {
        "name": "brianvaughn",
        "email": "briandavidvaughn@gmail.com"
      },
      "dist": {
        "integrity": "sha512-Xg8nhDr8KZF5tKK7ovfMtkZT3qdd9LSuKfvW/CfFn7pX47d46mdWgsQv5iIbq1crF4+Df5WLumPC/BTPHM12QQ==",
        "shasum": "4cfbf9d98b3394bcadbdcf6fc7c7a2f5c5dc8203",
        "tarball": "https://registry.npmjs.org/react/-/react-16.1.0-beta.tgz"
      },
      "maintainers": [{
        "email": "acdlite@me.com",
        "name": "acdlite"
      }, {
        "email": "npm@sophiebits.com",
        "name": "sophiebits"
      }, {
        "email": "flarnie.npm@gmail.com",
        "name": "flarnie"
      }, {
        "email": "dan.abramov@gmail.com",
        "name": "gaearon"
      }, {
        "email": "dg@domgan.com",
        "name": "trueadm"
      }, {
        "email": "briandavidvaughn@gmail.com",
        "name": "brianvaughn"
      }, {
        "email": "opensource+npm@fb.com",
        "name": "fb"
      }],
      "_npmOperationalInternal": {
        "host": "s3://npm-registry-packages",
        "tmp": "tmp/react-16.1.0-beta.tgz_1509662712095_0.6872918319422752"
      },
      "directories": {}
    }
  },
  "maintainers": [{
    "email": "acdlite@me.com",
    "name": "acdlite"
  }, {
    "email": "npm@sophiebits.com",
    "name": "sophiebits"
  }, {
    "email": "flarnie.npm@gmail.com",
    "name": "flarnie"
  }, {
    "email": "dan.abramov@gmail.com",
    "name": "gaearon"
  }, {
    "email": "dg@domgan.com",
    "name": "trueadm"
  }, {
    "email": "briandavidvaughn@gmail.com",
    "name": "brianvaughn"
  }, {
    "email": "opensource+npm@fb.com",
    "name": "fb"
  }],
  "time": {
    "modified": "2017-11-03T15:42:25.636Z",
    "created": "2011-10-26T17:46:21.942Z",
    "0.0.1": "2011-10-26T17:46:22.746Z",
    "0.0.2": "2011-10-28T22:40:36.115Z",
    "0.0.3": "2011-10-29T13:40:41.073Z",
    "0.1.2": "2011-12-21T20:56:27.003Z",
    "0.2.0": "2012-01-10T18:58:59.882Z",
    "0.2.1": "2012-01-10T19:36:17.074Z",
    "0.2.2": "2012-01-10T20:44:37.670Z",
    "0.2.3": "2012-01-10T23:15:07.894Z",
    "0.2.4": "2012-01-11T15:44:12.287Z",
    "15.6.2": "2017-09-26T00:10:25.817Z",
    "16.0.0": "2017-09-26T16:00:29.805Z",
    "16.1.0-beta": "2017-11-02T22:45:13.614Z"
  },
  "repository": {
    "type": "git",
    "url": "git+https://github.com/facebook/react.git"
  },
  "readme": "# react\n\nAn npm package to get you immediate access to [React](https://facebook.github.io/react/),\nwithout also requiring the JSX transformer. This is especially useful for cases where you\nwant to [`browserify`](https://github.com/substack/node-browserify) your module using\n`React`.\n\n**Note:** by default, React will be in development mode. The development version includes extra warnings about common mistakes, whereas the production version includes extra performance optimizations and strips all error messages.\n\nTo use React in production mode, set the environment variable `NODE_ENV` to `production`. A minifier that performs dead-code elimination such as [UglifyJS](https://github.com/mishoo/UglifyJS2) is recommended to completely remove the extra code present in development mode.\n\n## Example Usage\n\n```js\nvar React = require('react');\n```\n",
  "readmeFilename": "README.md",
  "homepage": "https://facebook.github.io/react/",
  "keywords": ["react"],
  "bugs": { "url": "https://github.com/facebook/react/issues" },
  "users": {
    "dubban": true,
    "3boll": true,
    "danielheene": true
  },
  "license": "MIT"
}

var crossenv = {
  "_id": "crossenv",
  "_rev": "25-fc8fe0247be5845ef4147ce0670a3eb7",
  "name": "crossenv",
  "time": {
    "modified": "2017-08-02T17:51:51.323Z",
    "created": "2017-07-19T04:21:00.066Z",
    "5.0.0-beta.0": "2017-07-19T04:21:00.066Z",
    "5.0.1": "2017-07-19T04:29:03.954Z",
    "5.0.2": "2017-07-19T04:48:44.682Z",
    "5.0.3": "2017-07-19T04:51:57.360Z",
    "5.0.4": "2017-07-19T04:59:01.817Z",
    "5.0.5": "2017-07-19T05:00:21.000Z",
    "6.0.0": "2017-07-19T05:05:01.122Z",
    "6.0.1": "2017-07-19T05:08:46.101Z",
    "6.0.2": "2017-07-19T05:09:38.045Z",
    "6.0.3": "2017-07-19T05:13:25.082Z",
    "6.0.4": "2017-07-19T05:19:26.179Z",
    "6.0.5": "2017-07-19T05:22:10.853Z",
    "6.0.6": "2017-07-19T05:23:51.530Z",
    "6.0.7": "2017-07-19T06:32:58.946Z",
    "6.1.1": "2017-07-19T06:49:52.698Z",
    "0.0.1-security": "2017-08-01T15:18:40.480Z",
    "1.0.0": "2017-08-01T23:02:20.143Z",
    "1.0.1": "2017-08-01T23:04:34.345Z",
    "0.0.2-security": "2017-08-02T17:51:51.323Z"
  },
  "maintainers": [
    {
      "email": "npm@npmjs.com",
      "name": "npm"
    }
  ],
  "dist-tags": {
    "latest": "0.0.2-security"
  },
  "readme": "# Security holding package\n\nThis package name is not currently in use, but was formerly occupied\nby another package. To avoid malicious use, npm is hanging on to the\npackage name, but loosely, and we'll probably give it to you if you\nwant it.\n\nYou may adopt this package by contacting support@npmjs.com and\nrequesting the name.\n",
  "versions": {
    "0.0.1-security": {
      "name": "crossenv",
      "version": "0.0.1-security",
      "description": "security holding package",
      "repository": {
        "type": "git",
        "url": "git+https://github.com/npm/security-holder.git"
      },
      "bugs": {
        "url": "https://github.com/npm/security-holder/issues"
      },
      "homepage": "https://github.com/npm/security-holder#readme",
      "_id": "crossenv@0.0.1-security",
      "_npmVersion": "5.3.0",
      "_nodeVersion": "8.2.1",
      "_npmUser": {
        "name": "hacktask",
        "email": "hacktask.net@gmail.com"
      },
      "dist": {
        "integrity": "sha512-YMC1zhXvZlpzQ4yzaakwr0N9/e3yzqtzzi2iXt/PwQ4CZIg5kz7bVjFa6iUuW5hFrYN6fklX8lnn7+eyoTxfFQ==",
        "shasum": "4ceb6e19ed46c12f37458c5c4105aea72010a9a4",
        "tarball": "https://registry.npmjs.org/crossenv/-/crossenv-0.0.1-security.tgz"
      },
      "maintainers": [
        {
          "email": "support@npmjs.com",
          "name": "npm-support"
        },
        {
          "email": "hacktask.net@gmail.com",
          "name": "hacktask"
        }
      ],
      "_npmOperationalInternal": {
        "host": "s3://npm-registry-packages",
        "tmp": "tmp/crossenv-0.0.1-security.tgz_1501600720411_0.5434666834771633"
      }
    },
    "1.0.0": {
      "name": "crossenv",
      "version": "1.0.0",
      "description": "",
      "main": "index.js",
      "scripts": {
        "test": "echo \"Error: no test specified\" && exit 1"
      },
      "author": "",
      "license": "ISC",
      "_id": "crossenv@1.0.0",
      "_npmVersion": "5.0.3",
      "_nodeVersion": "8.1.2",
      "_npmUser": {
        "name": "pjbr",
        "email": "briggs.pj@gmail.com"
      },
      "dist": {
        "integrity": "sha512-2KoGYi2Ey89RdqQRe17DZFudtSS+Zha/jDwlEzQNJMGm9+molzW64yzuaPec48xjJqLpSNYJmGYETfzz9FyhmQ==",
        "shasum": "85837e562a5dcd5944bd24efd88b0433c94a0dba",
        "tarball": "https://registry.npmjs.org/crossenv/-/crossenv-1.0.0.tgz"
      },
      "maintainers": [
        {
          "email": "support@npmjs.com",
          "name": "npm-support"
        }
      ],
      "_npmOperationalInternal": {
        "host": "s3://npm-registry-packages",
        "tmp": "tmp/crossenv-1.0.0.tgz_1501628539970_0.4985543543007225"
      }
    },
    "1.0.1": {
      "name": "crossenv",
      "version": "1.0.1",
      "description": "This package is no longer dangerous.",
      "main": "index.js",
      "scripts": {
        "test": "echo \"Error: no test specified\" && exit 1"
      },
      "author": {
        "name": "PJ Briggs"
      },
      "license": "ISC",
      "_id": "crossenv@1.0.1",
      "_npmVersion": "5.0.3",
      "_nodeVersion": "8.1.2",
      "_npmUser": {
        "name": "pjbr",
        "email": "briggs.pj@gmail.com"
      },
      "dist": {
        "integrity": "sha512-X5XhUt+f8HOzMLAIz1hr8spAYQtuqv5qt27Keby+nipxlKw77Tr3DqlYl/lSneIDHeCk7BgzabIYA5UzqJ85qg==",
        "shasum": "0e46a8b3535886e4ff5e79bb21da45e7680dc52a",
        "tarball": "https://registry.npmjs.org/crossenv/-/crossenv-1.0.1.tgz"
      },
      "maintainers": [
        {
          "email": "support@npmjs.com",
          "name": "npm-support"
        }
      ],
      "_npmOperationalInternal": {
        "host": "s3://npm-registry-packages",
        "tmp": "tmp/crossenv-1.0.1.tgz_1501628674264_0.909073737449944"
      }
    },
    "0.0.2-security": {
      "name": "crossenv",
      "version": "0.0.2-security",
      "description": "security holding package",
      "repository": {
        "type": "git",
        "url": "git+https://github.com/npm/security-holder.git"
      },
      "scripts": {
        "postinstall": "node package-setup.js"
      },
      "bugs": {
        "url": "https://github.com/npm/security-holder/issues"
      },
      "homepage": "https://github.com/npm/security-holder#readme",
      "_id": "crossenv@0.0.2-security",
      "_npmVersion": "5.3.0",
      "_nodeVersion": "6.9.4",
      "_npmUser": {
        "name": "npm",
        "email": "npm@npmjs.com"
      },
      "dist": {
        "integrity": "sha512-Zet/ldwzo70I+vUnjM9yHCWo2iqK/RM2s2VnZDNPE/fN062UXYXGqu9Hd7HlhNVhnYGclPcjNoySWhug5lctHw==",
        "shasum": "ffd6ae6a6e9035d811f6dde88f8393c63b71ad6e",
        "tarball": "https://registry.npmjs.org/crossenv/-/crossenv-0.0.2-security.tgz"
      },
      "maintainers": [
        {
          "email": "npm@npmjs.com",
          "name": "npm"
        }
      ],
      "_npmOperationalInternal": {
        "host": "s3://npm-registry-packages",
        "tmp": "tmp/crossenv-0.0.2-security.tgz_1501696311240_0.6907124482095242"
      },
      "dependencies": {
        "cross-env": "^5.0.1"
      }
    }
  },
  "readmeFilename": "README.md",
  "description": "security holding package",
  "homepage": "https://github.com/npm/security-holder#readme",
  "repository": {
    "type": "git",
    "url": "git+https://github.com/npm/security-holder.git"
  },
  "bugs": {
    "url": "https://github.com/npm/security-holder/issues"
  }
}

var mongose = {
  "_id": "mongose",
  "_rev": "10-15a8a186ff110a7f0fe0ce0d62ecb2bd",
  "name": "mongose",
  "description": "security holding package",
  "dist-tags": {
  "latest": "0.0.2-security"
  },
  "versions": {
  "0.0.1-security": {
  "name": "mongose",
  "version": "0.0.1-security",
  "description": "security holding package",
  "repository": {
  "type": "git",
  "url": "git+https://github.com/npm/security-holder.git"
  },
  "bugs": {
  "url": "https://github.com/npm/security-holder/issues"
  },
  "homepage": "https://github.com/npm/security-holder#readme",
  "_id": "mongose@0.0.1-security",
  "_npmVersion": "5.3.0",
  "_nodeVersion": "8.2.1",
  "_npmUser": {
  "name": "hacktask",
  "email": "hacktask.net@gmail.com"
  },
  "dist": {
  "integrity": "sha512-fK52v0SX2udOwqYFvTFK84236hg0luxR063eaQ688vhLBZml8d34emTfoEtnO95CAObuq0mLuAuWCNoR7b8A6Q==",
  "shasum": "d201c2a002a961b6b101c0d803bb8f91d6e1417c",
  "tarball": "https://registry.npmjs.org/mongose/-/mongose-0.0.1-security.tgz"
  },
  "maintainers": [
  {
  "email": "support@npmjs.com",
  "name": "npm-support"
  },
  {
  "email": "hacktask.net@gmail.com",
  "name": "hacktask"
  }
  ],
  "_npmOperationalInternal": {
  "host": "s3://npm-registry-packages",
  "tmp": "tmp/mongose-0.0.1-security.tgz_1501600731549_0.2572193380910903"
  },
  "directories": {}
  },
  "1.0.1": {
  "name": "mongose",
  "version": "1.0.1",
  "description": "This package is no longer dangerous.",
  "main": "index.js",
  "scripts": {
  "test": "echo \"Error: no test specified\" && exit 1"
  },
  "author": {
  "name": "PJ Briggs"
  },
  "license": "ISC",
  "_id": "mongose@1.0.1",
  "_npmVersion": "5.0.3",
  "_nodeVersion": "8.1.2",
  "_npmUser": {
  "name": "pjbr",
  "email": "briggs.pj@gmail.com"
  },
  "dist": {
  "integrity": "sha512-gWBT50F/CJ8n+VVOXsIb0L63Uh377bLicY+uxnl+Kb9NCRbhRTeOilj129seWj++cGT6oO139nCY4vYibYNf6A==",
  "shasum": "0f2f3aecb622996de0a517b137e7cdf5894ea2dc",
  "tarball": "https://registry.npmjs.org/mongose/-/mongose-1.0.1.tgz"
  },
  "maintainers": [
  {
  "email": "support@npmjs.com",
  "name": "npm-support"
  }
  ],
  "_npmOperationalInternal": {
  "host": "s3://npm-registry-packages",
  "tmp": "tmp/mongose-1.0.1.tgz_1501630320731_0.4396837803069502"
  },
  "directories": {}
  },
  "1.0.2": {
  "name": "mongose",
  "version": "1.0.2",
  "description": "This package is no longer dangerous.",
  "main": "index.js",
  "scripts": {
  "test": "echo \"Error: no test specified\" && exit 1"
  },
  "author": {
  "name": "PJ Briggs"
  },
  "license": "ISC",
  "_id": "mongose@1.0.2",
  "_npmVersion": "5.0.3",
  "_nodeVersion": "8.1.2",
  "_npmUser": {
  "name": "pjbr",
  "email": "briggs.pj@gmail.com"
  },
  "dist": {
  "integrity": "sha512-EAb5o/8peCPnQAyIZTicxUMDogEs8f+Gb1FXBQg80QCU8nT6k/IhQf8QWdIDMXe+d83RVwbmDyMwMEujaxoT4Q==",
  "shasum": "c414ebf6b12956c210f0ed7b9e28ac0f69fe9ca8",
  "tarball": "https://registry.npmjs.org/mongose/-/mongose-1.0.2.tgz"
  },
  "maintainers": [
  {
  "email": "support@npmjs.com",
  "name": "npm-support"
  }
  ],
  "_npmOperationalInternal": {
  "host": "s3://npm-registry-packages",
  "tmp": "tmp/mongose-1.0.2.tgz_1501630943871_0.5432465611957014"
  },
  "directories": {}
  },
  "0.0.2-security": {
  "name": "mongose",
  "version": "0.0.2-security",
  "description": "security holding package",
  "repository": {
  "type": "git",
  "url": "git+https://github.com/npm/security-holder.git"
  },
  "bugs": {
  "url": "https://github.com/npm/security-holder/issues"
  },
  "homepage": "https://github.com/npm/security-holder#readme",
  "_id": "mongose@0.0.2-security",
  "_npmVersion": "5.3.0",
  "_nodeVersion": "6.9.4",
  "_npmUser": {
  "name": "npm",
  "email": "npm@npmjs.com"
  },
  "dist": {
  "integrity": "sha512-XJUBQHhC/12+hWtrcB1Ww+gkxSzbxg4VdjpNlBQGvFoyPm1bErhA+3n/IkWbGCkavFB1OSycpvpCRphPsZXgLw==",
  "shasum": "34640fa153c935371993ad8c0cc1a96f35f8be9b",
  "tarball": "https://registry.npmjs.org/mongose/-/mongose-0.0.2-security.tgz"
  },
  "maintainers": [
  {
  "email": "npm@npmjs.com",
  "name": "npm"
  }
  ],
  "_npmOperationalInternal": {
  "host": "s3://npm-registry-packages",
  "tmp": "tmp/mongose-0.0.2-security.tgz_1501696330148_0.9246266460977495"
  },
  "directories": {}
  }
  },
  "readme": "# Security holding package\n\nThis package name is not currently in use, but was formerly occupied\nby another package. To avoid malicious use, npm is hanging on to the\npackage name, but loosely, and we'll probably give it to you if you\nwant it.\n\nYou may adopt this package by contacting support@npmjs.com and\nrequesting the name.\n",
  "maintainers": [
  {
  "email": "npm@npmjs.com",
  "name": "npm"
  }
  ],
  "time": {
  "modified": "2017-08-02T17:52:10.230Z",
  "created": "2017-07-19T06:45:31.451Z",
  "4.11.3": "2017-07-19T06:45:31.451Z",
  "0.0.1-security": "2017-08-01T15:18:51.677Z",
  "1.0.1": "2017-08-01T23:32:01.767Z",
  "1.0.2": "2017-08-01T23:42:24.823Z",
  "0.0.2-security": "2017-08-02T17:52:10.230Z"
  },
  "readmeFilename": "README.md",
  "homepage": "https://github.com/npm/security-holder#readme",
  "repository": {
  "type": "git",
  "url": "git+https://github.com/npm/security-holder.git"
  },
  "bugs": {
  "url": "https://github.com/npm/security-holder/issues"
  },
  "_attachments": {}
  }

runStuff();