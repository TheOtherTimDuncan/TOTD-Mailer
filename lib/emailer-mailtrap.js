'use strict';

var emailer = require('./emailer.js');
var nodemailer = require('nodemailer');

module.exports = function (options) {

    options = options || {};

    return new EmailerMailTrap(options);
};

function EmailerMailTrap(options) {
}

EmailerMailTrap.prototype = emailer;

EmailerMailTrap.prototype.send = function (mail) {

    var transport = nodemailer.createTransport({
        host: "mailtrap.io",
        port: 2525,
        auth: {
            user: "xxx",
            pass: "xxx"
        }
    });

}
