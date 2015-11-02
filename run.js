'use strict';

var azure = require('azure-storage');
var sendgrid = require('sendgrid')(process.env.SENDGRIDKEY);
var handlebars = require('handlebars');

var app = require('./lib/app.js');

console.log('Using storage account ' + process.env.AZURE_STORAGE_ACCOUNT);

var queueService = azure.createQueueService();
app.sendEmailFromQueue(queueService, 'email', sendgrid, handlebars);
