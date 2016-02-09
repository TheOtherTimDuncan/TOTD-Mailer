var app = module.exports;

app.sendEmailFromQueue = function (queueService, queueName, sendgrid, handlebars) {

    app.createQueue(queueService, queueName, function () {

        app.getMessage(queueService, queueName, function (message, messageText) {

            app.deleteMessage(queueService, queueName, message, messageText, function () {

                app.sendEmail(queueService, queueName, sendgrid, handlebars, messageText);

            });

        });

    });
}

app.createQueue = function (queueService, queueName, callback) {

    queueService.createQueueIfNotExists(queueName, function (error, result, response) {
        if (!error) {
            callback();
        } else {
            console.error('Error creating queue: ' + error);
        }
    });

}

app.getMessage = function getMessage(queueService, queueName, callback) {

    queueService.getMessages(queueName, function (error, result, response) {

        if (!error) {

            if (result.length == 0) { 
                return console.log('No message found in queue');
            }
            
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
            callback();

        } else {
            console.error('Error deleting message: ' + error);
        }

    });

}

app.sendEmail = function (queueService, queueName, sendgrid, handlebars, messageText) {

    var data = JSON.parse(messageText);

    var subjectTemplate = handlebars.compile(data.subjectTemplate);
    var htmlTemplate = handlebars.compile(data.htmlTemplate);
    var txtTemplate = handlebars.compile(data.textTemplate);

    var email = new sendgrid.Email({
        to: data.to,
        from: data.from,
        subject: subjectTemplate(data.emailData),
        text: txtTemplate(data.emailData),
        html: htmlTemplate(data.emailData)
    });

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

app.buildEmail = function (handlebars, source, data) {
    var template = handlebars.compile(source);
    var result = template(data);
    console.log(result);
}