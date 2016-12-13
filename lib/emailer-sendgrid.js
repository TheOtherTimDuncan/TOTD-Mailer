'use strict';

var emailer = require('./emailer.js');
var sg = require('sendgrid');

module.exports = function (options) {
    return new EmailerSendGrid(options);
};

function EmailerSendGrid(options) {
    this.sendgrid = sg(process.env.SENDGRIDKEY);
}

EmailerSendGrid.prototype = emailer;

EmailerSendGrid.prototype.send = function (mail) {
    console.log('sendgrid');
}
