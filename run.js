'use strict';

var azure = require('azure-storage');
var sg = require('sendgrid').SendGrid(process.env.SENDGRIDKEY);
var sgmail = require('sendgrid').mail;
var handlebars = require('handlebars');

var app = require('./lib/app.js');

console.log('Using storage account ' + process.env.AZURE_STORAGE_ACCOUNT);

var queueService = azure.createQueueService();
app.sendEmailFromQueue(queueService, 'email', sg, sgmail, handlebars);
