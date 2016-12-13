'use strict';

module.exports = function () {
    return new Emailer();
};

function Emailer() {
}

Emailer.prototype.send = function (mail) {
    console.log('send');
};

