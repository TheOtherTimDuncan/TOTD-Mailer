var app = module.exports;

app.sendEmailFromQueue = function (queueService, queueName, sg, sgmail, handlebars) {

    app.createQueue(queueService, queueName, function () {

        app.getMessage(queueService, queueName, function (message, messageText) {

            app.deleteMessage(queueService, queueName, message, messageText, function () {

                app.sendEmail(queueService, queueName, sg, sgmail, handlebars, messageText);

            });

        });

    });
};

app.createQueue = function (queueService, queueName, callback) {

    queueService.createQueueIfNotExists(queueName, function (error, result, response) {
        if (!error) {
            callback();
        } else {
            console.error('Error creating queue: ' + error);
        }
    });

};

app.getMessage = function getMessage(queueService, queueName, callback) {

    queueService.getMessages(queueName, function (error, result, response) {

        if (!error) {

            if (result.length === 0) {
                return console.log('No message found in queue');
            }

            var message = result[0];
            var buffer = new Buffer(message.messageText, 'base64');
            var messageText = buffer.toString('ascii');
            console.log('Using message: ' + messageText);
            callback(message, messageText);

        } else {
            console.error('Error getting messages: ' + error);
        }

    });

};

app.deleteMessage = function deleteMessage(queueService, queueName, message, messageText, callback) {

    queueService.deleteMessage(queueName, message.messageId, message.popReceipt, function (error, response) {

        if (!error) {
            console.log('Message deleted');
            callback();

        } else {
            console.error('Error deleting message: ' + error);
        }

    });

};

app.sendEmail = function (queueService, queueName, sg, sgmail, handlebars, messageText) {

    var data = JSON.parse(messageText);

    var subjectTemplate = handlebars.compile(data.subjectTemplate);
    var htmlTemplate = handlebars.compile(data.htmlTemplate);
    var txtTemplate = handlebars.compile(data.textTemplate);

    var emailFrom = new sgmail.Email(data.from);
    var emailTo = new sgmail.Email(data.to[0]);
    var htmlContent = new sgmail.Content('text/html', htmlTemplate(data.emailData));
    var email = new sgmail.Mail(emailFrom, subjectTemplate(data.emailData), emailTo, htmlContent);

    var txtEmail = txtTemplate(data.emailData);
    if (txtEmail) {
        var txtContent = new sgmail.Content('text/plain', txtEmail);
        email.addContent(txtContent);
    }

    if (data.to.length > 1) {
        for (var i = 1; i < data.to.length; i++) {
            var extraEmail = new sgmail.Email(data.to[i]);
            email.personalizations[0].addTo(extraEmail);
        }
    }

    var request = sg.emptyRequest();
    request.method = 'POST';
    request.path = '/v3/mail/send';
    request.body = email.toJSON();

    sg.API(request, function (error, response) {
        if (response.statusCode >= 200 && response.statusCode < 300) {
            console.log('Email sent');
        } else {

            console.log(response.statusCode);
            console.log(response.body);
            console.log(response.headers);

            queueService.createMessage(queueName, messageText, function (error, result, response) {
                if (!error) {
                    console.log('Message re-added to queue');
                } else {
                    console.error('Error recreating message: ' + error);
                }
            });
        }
    });

};

app.buildEmail = function (handlebars, source, data) {
    var template = handlebars.compile(source);
    var result = template(data);
    console.log(result);
};