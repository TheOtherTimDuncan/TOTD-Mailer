var azure = require('azure-storage');
var sendgrid = require('sendgrid')(process.env.SENDGRIDKEY);

var queueName = 'email';

console.log('Using storage account ' + process.env.AZURE_STORAGE_ACCOUNT);

var queueSvc = azure.createQueueService();

queueSvc.createQueueIfNotExists(queueName, function (error, result, response) {

    if (error) {
        console.error("Unable to create queue: " + response);
    }

});

queueSvc.getMessages(queueName, function (error, result, response) {

    if (error) {
        return console.error('Get queue messages failed: ' + response);
    }

    var message = result[0];
    var messageText = message.messagetext;
    console.log('Using message: ' + messageText);

    var data = JSON.parse(messageText);
    var email = new sendgrid.Email(data);

    queueSvc.deleteMessage(queueName, message.messageid, message.popreceipt, function (error, response) {

        if (error) {
            return console.error('Delete queue message failed: ' + response);
        }

        console.log('Message deleted');

    });

    sendgrid.send(email, function (error, json) {

        if (error) {
            console.error('Error sending email: ' + error);
            queueSvc.createMessage(queueName, messageText, function (error, result, response) {
                if (error) {
                    return console.error('Create queue message failed: ' + response);
                }
            });
            return;
        }

        console.log('Email sent');

    });

});
