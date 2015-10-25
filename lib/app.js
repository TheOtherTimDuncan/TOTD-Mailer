var app = module.exports;

app.sendEmailFromQueue = function (queueService, queueName, sendgrid) {

    app.createQueue(queueName, function (queueService, queueName) {

        app.getMessage(queueName, function (message, messageText) {

            app.deleteMessage(queueName, message, messageText, function (messageText) {

                app.sendEmail(queueName, messageText, sendgrid);

            });

        });

    });
}

app.createQueue = function (queueService, queueName, callback) {

    queueService.createQueueIfNotExists(queueName, function (error, result, response) {
        if (!error) {
            callback(queueName);
        } else {
            console.error('Error creating queue: ' + error);
        }
    });

}

app.getMessage = function getMessage(queueService, queueName, callback) {

    queueService.getMessages(queueName, function (error, result, response) {

        if (!error) {

            var message = result[0];
            var messageText = message.messagetext;
            console.log('Using message: ' + messageText);
            callback(message, messageText);

        } else {
            console.error('Error getting messages: ' + error);
        }

    });

}

app.deleteMessage = function deleteMessage(queueService, queueName, message, messageText, callback) {

    queueService.deleteMessage(queueName, message.messageid, message.popreceipt, function (error, response) {

        if (!error) {
            console.log('Message deleted');
            callback(messageText);

        } else {
            console.error('Error deleting message: ' + error);
        }

    });

}

app.sendEmail = function (queueService, queueName, sendgrid, messageText) {

    var data = JSON.parse(messageText);
    var email = new sendgrid.Email(data);

    sendgrid.send(email, function (error, json) {

        if (!error) {
            console.log('Email sent');
        } else {

            console.error('Error sending email: ' + error);

            queueService.createMessage(queueName, messageText, function (error, result, response) {
                if (!error) {
                    console.log('Message re-added to queue');
                } else {
                    console.error('Error recreating message: ' + error);
                }
            });

        }

    });

}
